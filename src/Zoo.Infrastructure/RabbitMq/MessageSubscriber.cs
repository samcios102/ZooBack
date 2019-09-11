using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Zoo.Infrastructure.RabbitMq
{
    internal class MessageSubscriber : IMessageSubscriber
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly RabbitMqOptions _options;

        public MessageSubscriber(IServiceProvider serviceProvider, IConnection connection, RabbitMqOptions options)
        {
            _serviceProvider = serviceProvider;
            _connection = connection;
            _options = options;
        }

        public void Subscribe<TMessage>(Func<IServiceProvider, TMessage, Task> onReceived) where TMessage : class
        {
            var channel = _connection.CreateModel();
            var queueName = typeof(TMessage).Name;
            
            channel.ExchangeDeclare(
                _options.Exchange,
                durable: true,
                autoDelete: false,
                arguments: null,
                type: "topic");

            channel.QueueDeclare(
                queueName,
                true,
                false,
                false,
                null);
            
            channel.QueueBind(
                queueName,
                _options.Exchange,
                $"#.{queueName}.#");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body;
                var json = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<TMessage>(json);
                await onReceived(_serviceProvider, message);
            };

            channel.BasicConsume(
                queueName,
                true,
                consumer);
        }
    }
}
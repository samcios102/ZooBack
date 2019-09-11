using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Zoo.Infrastructure.RabbitMq
{
    internal class MessagePublischer : IMessagePublischer
    {
        private readonly IConnection _connection;
        private readonly RabbitMqOptions _options;

        public MessagePublischer(IConnection connection, RabbitMqOptions options)
        {
            _connection = connection;
            _options = options;
        }

        public Task PublishAsync<TMessage>(TMessage message) where TMessage : class
        {
            using (var channel = _connection.CreateModel())
            {
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                
                channel.BasicPublish(
                    _options.Exchange,
                    message.GetType().Name,
                    null,
                    body
                    );
            }
            
            return Task.CompletedTask;
        }
        
    }
}
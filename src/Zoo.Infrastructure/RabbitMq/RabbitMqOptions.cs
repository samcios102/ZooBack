namespace Zoo.Infrastructure.RabbitMq
{
    public class RabbitMqOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string Exchange { get; set; }
    }
}
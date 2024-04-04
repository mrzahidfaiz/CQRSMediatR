using Confluent.Kafka;

namespace CQRSMediatR.ApiGateway.Api.Kafka_Service
{
    public class KafkaService
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<Null, string> _producer;

        public KafkaService(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        }
        public async Task AddStudent(string topic, string message)
        {

            var kafkamessage = new Message<Null, string>
            {
                Value = message,
            };

            await _producer.ProduceAsync(topic, kafkamessage);
        }


    }
}

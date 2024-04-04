using Confluent.Kafka;
using CQRSMediatR.Microservices.StudentApi.Commands;
using CQRSMediatR.Microservices.StudentApi.Model;
using MediatR;
using System.Text.Json;

namespace CQRSMediatR.Microservices.StudentApi.Kafka_Consumer
{
    public class KafkaConsumer : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<KafkaConsumer> _logger;
        private readonly IMediator _mediator;

        public KafkaConsumer(IConfiguration configuration, ILogger<KafkaConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = "InventoryConsumerGroup",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("AddStudent");

            while (!stoppingToken.IsCancellationRequested)
            {
                ProcessKafkaMessage(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _consumer.Close();
        }
        public async void ProcessKafkaMessage(CancellationToken stoppingToken)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);
                var payload = consumeResult.Message.Value;

                var data = JsonSerializer.Deserialize<Student>(payload);

                if (data != null)
                {
                    await _mediator.Send(new AddStudentCommand(data));
                }


                _logger.LogInformation($"Received inventory update: {payload}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing Kafka message: {ex.Message}");
            }
        }
    }
}

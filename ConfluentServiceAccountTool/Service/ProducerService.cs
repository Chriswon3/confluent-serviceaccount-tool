using Confluent.Kafka;
using ConfluentServiceAccountTool.Model;

namespace ConfluentServiceAccountTool.Service;

public class ProducerService
{
    public async Task ProduceEvents(KafkaConfig kafkaConfig)
    {
        ProducerConfig producerConfig = new()
            {
                BootstrapServers = kafkaConfig.BootstrapServer,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = kafkaConfig.ServiceAccountId,
                SaslPassword = kafkaConfig.ServiceAccountSecret
            };
        
        using var producer = new ProducerBuilder<Ignore, string>(producerConfig).Build();
        
        try
        {
            var delivery = await producer.ProduceAsync(kafkaConfig.Topic, new Message<Ignore, string>
            {
                Value = "Testing producer"
            });

            Console.WriteLine($"Produced message to {delivery.TopicPartitionOffset}");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Produce error: {e.Error.Reason}");
        }
    }
}
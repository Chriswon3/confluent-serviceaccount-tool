using ConfluentServiceAccountTool.Model;
using Confluent.Kafka;
using Confluent.SchemaRegistry;

namespace ConfluentServiceAccountTool.Service;

public class ConsumerService
{
    public void ConsumeEvents(KafkaConfig kafkaConfig)
    {
        ConsumerConfig consumerConfig = new()
        {
            BootstrapServers = kafkaConfig.BootstrapServer,
            GroupId = kafkaConfig.GroupId,
            SaslUsername = kafkaConfig.ServiceAccountId,
            SaslPassword = kafkaConfig.ServiceAccountSecret,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            SaslMechanism = SaslMechanism.Plain,
        };
        
        using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        
        try
        {
            Console.WriteLine("Consuming events");
            consumer.Subscribe(kafkaConfig.Topic);
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Consume error: {e.Error.Reason}");
        }
    }
}
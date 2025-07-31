using ConfluentServiceAccountTool.Service;

namespace ConfluentServiceAccountTool;

public class Handler
{
    public async void HandleAsync()
    {
        ConfigurationInputsService inputsService = new ConfigurationInputsService();

        var kafkaConfig = inputsService.GetKafkaConfig();
        
        var stream = inputsService.GetStream();

        if (stream == "C")
        {
            ConsumerService consumer = new ConsumerService();
            Console.WriteLine("Consumer Service has been selected. Commencing testing of consuming events");

            await consumer.ConsumeEvents(kafkaConfig);
        }
        else if (stream == "P")
        {
            ProducerService producer = new ProducerService();
            Console.WriteLine("Producer Service has been selected. Commencing testing of producing events");

            await producer.ProduceEvents(kafkaConfig);
        }
        
    }
    
}
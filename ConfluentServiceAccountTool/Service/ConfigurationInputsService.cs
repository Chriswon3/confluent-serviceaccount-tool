using ConfluentServiceAccountTool.Enum;
using ConfluentServiceAccountTool.Model;

namespace ConfluentServiceAccountTool.Service;

public class ConfigurationInputsService()
{
    public KafkaConfig GetKafkaConfig()
    {
        KafkaConfig kafkaConfig = new()
        {
            BootstrapServer = ValidateInput("Please enter your Bootstrap Server", InputServiceEnum.KafkaConfig),
            ServiceAccountId = ValidateInput("Please enter your Service Account ID: ", InputServiceEnum.KafkaConfig),
            ServiceAccountSecret = ValidateInput("Please enter your Service Account Secret: ", InputServiceEnum.KafkaConfig),
            Topic = ValidateInput("Please enter the Kafka Topic: ", InputServiceEnum.KafkaConfig),
            GroupId = ValidateInput("Please enter the Group ID: ", InputServiceEnum.KafkaConfig)
        };

        return kafkaConfig;
    }

    public string GetStream()
    {
        var input = ValidateInput("Would you like to test Consumer or Producer for {topic}: (C) for Consumer | (P) for Producer", InputServiceEnum.StreamConfig);

        return input.ToUpper();
    }

    private string ValidateInput(string prompt, InputServiceEnum mode)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Your input is empty. Please re-enter");
            return ValidateInput(prompt, mode);
        }

        if (mode == InputServiceEnum.StreamConfig)
        {
            if (input.ToUpper() != "C" || input.ToUpper() != "P")
            {
                Console.WriteLine("Your input is invalid. Please re-enter");
                return ValidateInput(prompt, mode);
            }
        }

        return input;

    }
}


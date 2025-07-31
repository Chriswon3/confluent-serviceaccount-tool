namespace ConfluentServiceAccountTool.Model;

public class KafkaConfig
{
    public string ServiceAccountId { get; set; } = string.Empty!;
    public string ServiceAccountSecret { get; set; } = string.Empty!;
    public string GroupId { get; set; } = string.Empty!;
    public string Topic { get; set; } = string.Empty!;

}
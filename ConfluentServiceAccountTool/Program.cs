using ConfluentServiceAccountTool.Model;

namespace ConfluentServiceAccountTool;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("This confluent service account tool is used to consume/produce from/to confluent kafka topics. Please enter the parameters required:");
        
        Handler handler = new Handler();
        
        handler.HandleAsync();
    }

}
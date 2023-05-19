using Azure;
using Azure.AI.TextAnalytics;
ConsoleApp.CreateBuilder(args).
ConfigureServices((context, services) =>
{
    var cfg = context.Configuration;
    var key = cfg["key"] ?? "";
    var endpoint = new Uri(cfg["endpoint"] ?? "");
    var cred = new AzureKeyCredential(key);
    var client = new TextAnalyticsClient(endpoint, cred);
    services.AddSingleton(client);
}).Build().AddRootCommand(Command).Run();

void Command(TextAnalyticsClient client, string text)
{
    DetectedLanguage detectedLanguage = client.DetectLanguage(text);
    Console.WriteLine("Detected language:");
    Console.WriteLine($"\tName: {detectedLanguage.Name}");
    Console.WriteLine($"\tISO 639-1: {detectedLanguage.Iso6391Name}");
}
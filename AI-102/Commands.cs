using Azure.AI.Language.Conversations;
using System.Text.Json;
using Azure;
using Azure.Core;
class Commands : ConsoleAppBase
{
    public void Clock(ConversationAnalysisClient client, IConfiguration config, string input)
    {
        System.Console.WriteLine(input);
        string projectName = "Clock";
        string deploymentName = "Clock";
        var data = new
        {
            analysisInput = new
            {
                conversationItem = new
                { text = input, id = "1", participantId = "1", }
            },
            parameters = new
            {
                projectName,
                deploymentName,
                vervose = true,
                // Use Utf16CodeUnit for strings in .NET.
                stringIndexType = "Utf16CodeUnit",
            },
            kind = "Conversation",
        };
        Response response = client.AnalyzeConversation(RequestContent.Create(data));
        if (response.ContentStream == null)
        {
            Console.WriteLine("stream is null");
            return;
        }
        using JsonDocument result = JsonDocument.Parse(response.ContentStream);
        JsonElement conversationalTaskResult = result.RootElement;
        JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction"); var topIntent = conversationPrediction.GetProperty("topIntent").GetString();
        Console.WriteLine($"Top intent: {topIntent}");
        switch (topIntent)
        {
            case "GetDate": GetDate(); break;
            case "GetTime": GetTime(); break;
            default: Console.WriteLine("can't detect intent"); break;
        }
    }
    private void GetDate()
    {
        Console.WriteLine("はい、今日の日付をお答えします。");
        Console.WriteLine(DateTime.Now.ToShortDateString());
    }
    private void GetTime()
    {
        Console.WriteLine("はい、現在時刻をお答えします。");
        Console.WriteLine(DateTime.Now.ToShortTimeString());
    }
}
using Azure.Identity;
using Azure.Messaging.EventGrid;

var credential = new DefaultAzureCredential();
var endpoint = Environment.GetEnvironmentVariable("EVENTGRID_ENDPOINT") ?? throw new Exception("EVENTGRID_ENDPOINT is null");

var client = new EventGridPublisherClient(new Uri(endpoint), credential);
ConsoleApp.Create(args)
.AddRootCommand(async (string subject, string eventType, string dataVersion, object data) =>
{
  var _event = new EventGridEvent(subject, eventType, dataVersion, data);
  await client.SendEventAsync(_event);
})
.Run();

using Microsoft.Azure.Cosmos;
using Azure.Identity;

ConsoleApp.CreateBuilder(args)
.ConfigureServices((context, services) =>
{
    var endpoint = context.Configuration["cosmosdb:endpoint"];
    var credential = new DefaultAzureCredential();
    var client = new CosmosClient(endpoint, credential);
    services.AddSingleton(client);
})
.Build().AddCommands<Commands>().Run();
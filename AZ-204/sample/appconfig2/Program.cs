using Azure.Identity;
using Microsoft.FeatureManagement;

ConsoleApp.CreateBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
  var endpoint = config.Build()["appconfig:endpoint"] ?? "";
  config.AddAzureAppConfiguration(options =>
  {
    var credential = new DefaultAzureCredential();
    options.Connect(new Uri(endpoint), credential);
    // 機能フラグを利用する
    options.UseFeatureFlags();
    // Key Vault参照を利用する
    options.ConfigureKeyVault(kv =>
      kv.SetCredential(credential));
  });
})
.ConfigureServices((context, services) =>
    services.AddFeatureManagement()
).Build().AddCommands<Commands>().Run();
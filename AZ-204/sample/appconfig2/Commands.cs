using Microsoft.FeatureManagement;

class Commands : ConsoleAppBase
{
  private readonly IConfiguration _config;
  private readonly IFeatureManager _feature;
  public Commands(IConfiguration config, IFeatureManager fm) =>
      (_config, _feature) = (config, fm);
  public async Task Test()
  {
    // (1)構成の読み取り
    var value = _config["key1"];
    Console.WriteLine($"key1: {value}");

    // (2)機能フラグの読み取り
    if (await _feature.IsEnabledAsync("Feature1"))
      Console.WriteLine("Feature1: 有効");
    else
      Console.WriteLine("Feature1: 無効");

    // (3)Key Vault参照を使用したシークレットの読み取り
    var secretValue = _config["secret1"];
    Console.Write($"secret1: {secretValue}");
  }
}
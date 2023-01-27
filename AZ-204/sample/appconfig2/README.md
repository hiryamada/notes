# プロジェクトの作成

```
dotnet new worker
rm {Program,Worker}.cs; touch {Program,Commands}.cs

dotnet add package ConsoleAppFramework --version 4.2.4
dotnet add package Azure.Identity --version 1.8.1
dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration --version 5.2.0
dotnet add package Microsoft.FeatureManagement --version 2.5.1
```

# Azureリソースの作成

- App Configuration
- Key Vault

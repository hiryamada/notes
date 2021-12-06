# Azure SDKについての情報

[各言語用の最新SDKの情報](https://azure.github.io/azure-sdk/releases/latest/index.html)

[GitHub](https://github.com/Azure/azure-sdk/)

# Azure SDK for .NET

[ドキュメント](https://azure.github.io/azure-sdk-for-net/)

[.NET 開発者向けの Azure](https://docs.microsoft.com/ja-jp/dotnet/azure/)

[Azure SDK 設計ガイドライン](https://azure.github.io/azure-sdk/dotnet_introduction.html)

[Azure Management SDK for .NET](https://github.com/Azure/azure-libraries-for-net)

# mod 1 Azure App Service / mod 2 Azure Functions

マネジメントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Management.AppService.Fluent

バインド拡張機能（トリガー、バインド）

- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions 4.0.1 - timer and file
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.CosmosDB 3.0.10
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.WebHooks 1.0.0-beta4
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.Sql - Azure SQL Database
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.ServiceBus
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.RabbitMQ 1.0.0
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventGrid
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.EventHubs
- https://www.nuget.org/packages/Microsoft.Azure.Functions.Worker.Extensions.EventHubs 4.2.1 - for .NET isolated functions
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
- https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.Storage.Queues

Not Released

- https://github.com/Azure/azure-functions-iothub-extension
- https://github.com/Azure/azure-functions-datalake-extension
- https://github.com/Azure/azure-functions-appinsights-extension
- https://github.com/Azure/azure-functions-dropbox-extension

Microsoft Graph
- https://github.com/Azure/azure-functions-microsoftgraph-extension - no longer maintained
- https://docs.microsoft.com/en-us/graph/tutorials/azure-functions

Azure Functions バインド拡張機能を登録する
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-register

イベント ドリブンのバックグラウンド処理で Azure WebJobs SDK の使用を開始する
https://docs.microsoft.com/ja-jp/azure/app-service/webjobs-sdk-get-started

MSBuild task for Azure Functions
https://github.com/Azure/azure-functions-vs-build-sdk

# mod 3 Azure Blob Storage

クライアントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/ 11.2.3 (deprecated)
- https://www.nuget.org/packages/Azure.Storage.Blobs/ 12.9.1

クライアントライブラリ - 旧

- https://www.nuget.org/packages/WindowsAzure.Storage/

マネジメントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Management.Storage.Fluent/

# mod 4 Azure Cosmos DB

クライアントライブラリ(SQL API)

- https://www.nuget.org/packages/Microsoft.Azure.DocumentDB.Core 2.15.0 - DocumentDB (SQL) API
- https://www.nuget.org/packages/Microsoft.Azure.Cosmos 3.20.1 - SQL API
- https://www.nuget.org/packages/Azure.Cosmos 4.0.0-preview3 - SQL API

クライアントライブラリ(SQL API以外)
- https://www.nuget.org/packages/Microsoft.Azure.Cosmos.Table 2.0.0-preview - Table
- https://www.nuget.org/packages/MongoDB.Driver 2.13.0
- https://www.nuget.org/packages/CassandraCSharpDriver 3.16.3 - DataStax C# Driver for Apache Cassandra
- https://tinkerpop.apache.org/dotnetdocs/3.3.11/

マネジメントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Management.CosmosDB.Fluent 1.37.1
- https://www.nuget.org/packages/Microsoft.Azure.Management.CosmosDB 3.1.0

Entity Framework 

- https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Cosmos

# mod 5 VM, ARM Template

- https://www.nuget.org/packages/Microsoft.Azure.Management.Compute.Fluent
- https://www.nuget.org/packages/Microsoft.Azure.Management.ResourceManager.Fluent

# mod 5 ACI, ACR, AKS

- https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerInstance.Fluent
- https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerRegistry.Fluent
- https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerService.Fluent

Getting started on managing Kubernetes clusters (AKS) using C#
https://github.com/azure-samples/aks-dotnet-manage-kubernetes-cluster/tree/master/

Docker用のSDK
https://docs.docker.com/engine/api/sdk/

Kubernetes API
https://kubernetes.io/ja/docs/concepts/overview/kubernetes-api/

Kubernetes Client Libraries
https://kubernetes.io/docs/reference/using-api/client-libraries/


# mod 6 Microsoft ID Platform / MSAL

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-overview

- https://www.nuget.org/packages/Microsoft.Identity.Client - MSAL.NET
- https://www.nuget.org/packages/Microsoft.Identity.Web - Microsoft ID Platform for ASP.NET Core

# mod 6 Microsoft Graph

https://docs.microsoft.com/ja-jp/graph/sdks/sdks-overview

- https://www.nuget.org/packages/Microsoft.Graph

# mod 7 Key Vault

クライアントライブラリ
- https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets/
- https://www.nuget.org/packages/Azure.Security.KeyVault.Keys/
- https://www.nuget.org/packages/Azure.Security.KeyVault.Certificates/
- Microsoft.Extensions.Configuration.AzureKeyVault - [構成プロバイダー](https://docs.microsoft.com/ja-jp/dotnet/core/extensions/configuration-providers)

マネジメントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Management.KeyVault.Fluent
- https://www.nuget.org/packages/Microsoft.Azure.Management.KeyVault/

# mod 7 App Configuratins

クライアントライブラリ

- https://www.nuget.org/packages/Azure.Data.AppConfiguration
- https://www.nuget.org/packages/Microsoft.Azure.AppConfiguration.AspNetCore - ASP.NET Core
- https://www.nuget.org/packages/Microsoft.Extensions.Configuration.AzureAppConfiguration - [構成プロバイダー](https://docs.microsoft.com/ja-jp/dotnet/core/extensions/configuration-providers)

# mod 8 API Management

マネジメントライブラリ

https://www.nuget.org/packages/Microsoft.Azure.Management.ApiManagement

# mod 9 Event Grid

クライアントライブラリ

- https://www.nuget.org/packages/Azure.Messaging.EventGrid
- https://www.nuget.org/packages/Microsoft.Azure.EventGrid - deprecated

マネジメントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Management.EventGrid

# mod 9 Event Hubs

クライアントライブラリ

- https://www.nuget.org/packages/Azure.Messaging.EventHubs

マネジメントライブラリ

- https://www.nuget.org/packages/Azure.ResourceManager.EventHubs

# mod 10 Service Bus

クライアントライブラリ

- https://www.nuget.org/packages/Azure.Messaging.ServiceBus

マネジメントライブラリ

- https://www.nuget.org/packages/Microsoft.Azure.Management.ServiceBus/
- https://www.nuget.org/packages/Microsoft.Azure.Management.ServiceBus.Fluent/

# mod 10 Azure Queue Storage

クライアントライブラリ

- https://www.nuget.org/packages/Azure.Storage.Queues

# mod 11 Azure Monitor, Application Insights

https://github.com/microsoft/ApplicationInsights-dotnet

https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/metrics-custom-overview

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/api-custom-events-metrics

# mod 12 Azure Cache for Redis

クライアントライブラリ

- https://www.nuget.org/packages/StackExchange.Redis/
- https://redis.io/clients - 一覧

マネジメントライブラリ
- https://www.nuget.org/packages/Microsoft.Azure.Management.Redis
- https://www.nuget.org/packages/Microsoft.Azure.Management.Redis.Fluent/

# Identity Client Library

The Azure Identity library provides Azure Active Directory token authentication support across the Azure SDK. It provides a set of TokenCredential implementations which can be used to construct Azure SDK clients which support AAD token authentication.

DefaultAzureCredential は以下の順で認証情報を探す。

- 環境変数 - AZURE_CLIENT_ID(テナントID), AZURE_USERNAME, AZURE_PASSWORD 等
- マネージドID
- Visual Studio - Tools / Options
- Visual Studio Code - Azure Account Extension
- Azure CLI
- Azure PowerShell
- インタラクティブ（デフォルトでは無効化されている）

ドキュメント
https://docs.microsoft.com/en-us/dotnet/api/overview/azure/identity-readme

パッケージ
https://www.nuget.org/packages/Azure.Identity

# その他

- https://www.nuget.org/packages/Newtonsoft.Json/
- https://devblogs.microsoft.com/azure-sdk/announcing-the-new-azure-data-tables-libraries/

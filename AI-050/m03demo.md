# 講師デモ Azure OpenAI をアプリに統合する

[手順書（日本語）](https://microsoftlearning.github.io/mslearn-openai.ja-jp/Instructions/Labs/02-natural-language-azure-openai.html)

[手順書（英語）](https://microsoftlearning.github.io/mslearn-openai/Instructions/Labs/02-natural-language-azure-openai.html)

■概要

- Azure OpenAIリソースをデプロイする（前のデモと同様）
- モデルをデプロイする（前のデモと同様）
- エンドポイント、APIキー、デプロイ名を環境変数に設定する。例:
  - `setx oaiEndpoint "https://test233653542.openai.azure.com/"`
  - `setx oaiKey "**************************"`
  - `setx oaiModelName "my-gpt-model"`
- .NET コンソールアプリを作成する
  - `dotnet new console`
- Azure OpenAIのSDK(NuGetパッケージ)を追加する。
  - `dotnet add package Azure.AI.OpenAI --prerelease`
- コードを記述する。例:
    ```c#
    using Azure.AI.OpenAI;
    using Azure;

    var oaiEndpoint = System.Environment.GetEnvironmentVariable("oaiEndpoint") ?? "";
    var oaiKey = System.Environment.GetEnvironmentVariable("oaiKey") ?? "";
    var oaiModelName = System.Environment.GetEnvironmentVariable("oaiModelName") ?? "";

    var client = new OpenAIClient(new Uri(oaiEndpoint), new AzureKeyCredential(oaiKey));

    var chatCompletionsOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
        new ChatMessage(ChatRole.System, "あなたはAIアシスタントです。日本語で回答してください。"),
        new ChatMessage(ChatRole.User, "Microsoft Azureとは？"),
        },
        MaxTokens = 800,
        Temperature = 0.7f
    };

    ChatCompletions response = client.GetChatCompletions(
        deploymentOrModelName: oaiModelName,
        chatCompletionsOptions);
    string completion = response.Choices[0].Message.Content;

    Console.WriteLine(completion);
    ```
- 実行する。`dotnet run`


実行結果例:

```
$ dotnet run
Microsoft Azure（マイクロソフト・アジュール）は、Microsoftが提供するクラウドコンピューティングプラットフォー
ムです。インフラストラクチャー（IaaS）、プラットフォーム（PaaS）、ソフトウェア（SaaS）などの各種クラウドサービスを提供しており、ビジネスのデジタル変革やアプリケーション開発、データ処理などの様々な用途に利用されています。また、機械学習や人工知能（AI）の分野でも強みを持っています。
```
# ラボ09 「会話言語理解(CLU)」リソースの作成

Cognitive Servicesリソースを作成し、それを使用して「Clock」というプロジェクトを作成する。

このプロジェクトにモデル「Clock」を作成し、現在の日付や時刻を尋ねる質問の文章を理解できるように、トレーニングする。

■はじめに

このラボはわりと時間がかかります。（慣れていれば30分程度、慣れていなければ60分程度）

途中、延長するか聞かれた場合は「はい」を選んでください。

![](images/ss-2023-06-06-15-22-12.png)

■ラボ9を起動

- 仮想デスクトップ(Windows)にログイン
- Webブラウザーを開き、Azure portalにサインイン
- 日本語化

■手順書

以降、次のページをラボ環境内のブラウザで開き、参照してください。

https://github.com/hiryamada/notes/blob/main/AI-102/lab09cs.md

※ラボ環境右側の手順書は、このラボではこれ以降使用しません。

■Cognitive Servicesリソースの作成

「言語サービス」に、「会話言語理解(CLU)」が含まれているので、「言語サービス」リソースを作成する。

![](images/ss-2023-06-06-14-38-48.png)

![](images/ss-2023-06-06-14-39-56.png)

![](images/ss-2023-06-06-14-40-50.png)

![](images/ss-2023-06-06-14-41-10.png)

作成したら「キーとエンドポイント」画面に移動し、「キー1」の値と「エンドポイント」の値をコピーして、メモ帳などに控えておく。次のラボで使用する。

■Language Studioにアクセス

https://language.cognitive.azure.com

画面右上でサインイン、リソースを選択。

![](images/ss-2023-06-06-14-42-41.png)

![](images/ss-2023-06-06-14-43-22.png)

![](images/ss-2023-06-06-14-44-03.png)

日本語化

![](images/ss-2023-06-06-14-45-01.png)

■「会話言語理解」プロジェクトの作成

![](images/ss-2023-06-06-14-45-28.png)

プロジェクト名: `Clock` ※大文字で始める

![](images/ss-2023-06-06-14-49-11.png)

![](images/ss-2023-06-06-14-49-39.png)

■「意図」(intent)を追加

<!--
参考: https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/how-to/build-schema#add-intents
-->

意図「GetDate」を追加

![](images/ss-2023-06-06-14-50-35.png)

「発話の例」を書き込む

![](images/ss-2023-06-06-14-51-17.png)


- 今日は何日？
- 今日は？
- 何日ですか？
- 何日？
- 今日の日付は？
- 日付は？
- 何月何日？
- 今何日？
- 日付

![](images/ss-2023-06-06-14-54-21.png)
![](images/ss-2023-06-06-14-56-03.png)


意図「GetTime」を追加し、「発話の例」を書き込む

![](images/ss-2023-06-06-14-57-27.png)
![](images/ss-2023-06-06-14-57-55.png)
![](images/ss-2023-06-06-14-58-49.png)

- 何時？
- 何時何分？
- 今何時？
- 今何時ですか？
- 何時ですか？
- 現在時刻
- 現在時刻は？
- 現在時刻を教えてください

![](images/ss-2023-06-06-15-00-03.png)
![](images/ss-2023-06-06-15-00-19.png)

最後に「変更の保存」をクリック。

![](images/ss-2023-06-06-15-00-35.png)

■トレーニング ジョブの開始

<!--
参考: https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/how-to/train-model?tabs=language-studio#training-modes
-->

![](images/ss-2023-06-06-15-01-53.png)

![](images/ss-2023-06-06-15-02-09.png)

![](images/ss-2023-06-06-15-02-27.png)

- モデル名: `Clock` ※大文字で始める
- トレーニングモード: 高度なトレーニング ※「標準トレーニング」は英語の場合のみ使用可能。

![](images/ss-2023-06-06-15-03-12.png)

![](images/ss-2023-06-06-15-04-11.png)

トレーニングジョブが「キュー」に入ると、「Job in queue. Starting soon ...」 などと表示される。

![](images/ss-2023-06-06-15-04-28.png)

※トレーニングジョブが「キュー」に入ると、あとはトレーニングは自動で進行する。始まるまで10分ほど時間がかかる（ここで休憩をおとりください。）

<!-- 15:04 start -->

トレーニングが開始されると、「Training - 0% complete, Evaluation - 0% complete.」などと表示される。

![](images/ss-2023-06-06-15-13-09.png)

トレーニングが完了（成功）すると、「トレーニングに成功しました」などと表示される。

![](images/ss-2023-06-06-15-16-16.png)


※トレーニングは15分ほどかかるので、この画面はこのままにしておき、別の作業を進めます。


## .NET 7.0 をインストール

Webブラウザーの新しいタブで以下を開き、.NET 7をダウンロードしてインストールします。

https://dotnet.microsoft.com/en-us/download

![](images/ss-2023-06-06-15-24-44.png)

![](images/ss-2023-06-06-15-25-21.png)

![](images/ss-2023-06-06-15-25-52.png)

![](images/ss-2023-06-06-15-26-09.png)

![](images/ss-2023-06-06-15-27-25.png)

## プロジェクトの作成

Visual Studio Codeを起動。
![](images/ss-2023-06-06-15-07-15.png)

ターミナルを起動
![](images/ss-2023-06-06-15-08-09.png)

Git Bashに切り替え
![](images/ss-2023-06-06-15-08-42.png)

以下のコマンドを全部コピーし、Git Bash内に貼り付け

```
cd ~/Documents
mkdir lab10
cd lab10
dotnet new worker
rm Worker.cs

dotnet add package Microsoft.Extensions.Configuration.UserSecrets
dotnet add package ConsoleAppFramework
dotnet add package Azure.AI.Language.Conversations --version 1.0.0

echo "root = true
[*.cs]
# supress 'Member ... does not access instance data and can be marked as static'
dotnet_diagnostic.CA1822.severity = none
" > .editorconfig
code -r .
```

![](images/ss-2023-06-06-15-10-47.png)

Visual Studio Codeで、プロジェクトのフォルダが開かれる。

## ユーザーシークレットの追加

Visual Studio Codeのターミナルを開く。

![](images/ss-2023-06-06-15-28-46.png)

Git Bashに切り替え

![](images/ss-2023-06-06-15-29-15.png)

以下のコマンドの、「キー」と「エンドポイント」の部分を、前のラボでコピーしておいた文字列に置換して、ターミナル内で実行。

```
dotnet user-secrets set 'CognitiveServices:SubscriptionKey' 'キー'
dotnet user-secrets set 'CognitiveServices:Endpoint' 'エンドポイント'
```

## `Properties/launchSettings.json`の変更

dotnetRunMessagesの値をfalseに変更し、保存。

```json
{
...
      "dotnetRunMessages": false,
...
}
```

プログラム実行時の「Building...」という出力が抑制される。

## `Program.cs`のコーディング

```cs
using Azure;
using Azure.AI.Language.Conversations;

ConsoleApp
.CreateBuilder(args)
.ConfigureServices((context, services) =>
{
    var endpoint = new Uri(context.Configuration["CognitiveServices:Endpoint"] ?? "");
    var credential = new AzureKeyCredential(context.Configuration["CognitiveServices:SubscriptionKey"] ?? "");
    var client = new ConversationAnalysisClient(endpoint, credential);
    services.AddSingleton(client);
})
.Build()
.AddCommands<Commands>()
.Run();
```

## `Commands.cs`のコーディング

`Commands.cs`を新規作成。

```cs
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
```

解説: 前のラボで作成した「会話言語理解(CLU)」プロジェクトのモデルを使用して、ユーザーの「発話」（input）から意図（intent）を決定し、それに応じた処理を行う。

## OSのタイムゾーンの調整

![](images/ss-2023-06-07-02-57-07.png)

![](images/ss-2023-06-07-02-57-37.png)

## CLUのトレーニングの状況を確認

トレーニングがまだ完了していなければ、ここで待ちます。

トレーニングが完了したら、次に進みます。

## モデルのデプロイ

画面左「モデルのデプロイ」をクリック

「デプロイの追加」をクリック

「新しいデプロイ名を作成する」、デプロイ名「Clock」

モデル: 「Clock」

「デプロイ」

数秒ほどでデプロイが完了する。

## 実行

Visual Studio Code ターミナルで、以下を実行。

CLUによって、`--input` で指定したテキストから「意図」が認識され、「意図」に対応した操作（日付または時刻の表示）が行われる。

`--input` 以下に指定しているテキストは、トレーニングで指定したものに近い形式のものであればよく、トレーニングで指定していない形式でも、多くの場合は正しい「意図」が認識される。

```
dotnet run clock --input "今日は何日？"
dotnet run clock --input "何日ですか？"
dotnet run clock --input "何日？"
dotnet run clock --input "今日は何日か教えてください"

dotnet run clock --input "現在の時間は？"
dotnet run clock --input "今何時ですか？"
dotnet run clock --input "何時？"
dotnet run clock --input "今何時でしょうか・・・？"
dotnet run clock --input "汝、今何時"
```

実行例
![](images/ss-2023-04-06-01-12-42.png)

なお、`--input`のテキストによっては、モデルが意図を誤って認識することもありうる。

より多くのトレーニングを行うことで、モデルが意図を正確に認識できる確率が高くなる。

## 以上

おつかれさまでした！


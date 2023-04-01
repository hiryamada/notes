# ラボ13 ボット(TimeBot)の作成

このラボでは、現在の時刻を答えるボット(TimeBot)を開発します。

このボットの開発には、[.NET SDK](https://learn.microsoft.com/ja-jp/dotnet/core/sdk)と、[Bot Framework Emulator](https://learn.microsoft.com/ja-jp/azure/bot-service/bot-service-debug-emulator?view=azure-bot-service-4.0&tabs=csharp)を使用します。

.NET SDKは、.NETを使用して様々なアプリケーション（ボットなど）を開発するためのSDK（ソフトウェア開発キット）です。C#などのプログラミング言語を使用してアプリを開発します。

Bot Framework Emulator は、開発したボットを実行する際に使用します。

## Bot Framework Emulatorのインストール

Bot Framework Emulatorは以下のGitHubリポジトリで開発されている。

https://github.com/Microsoft/BotFramework-Emulator/

このリポジトリのREADMEファイルを参考に、リリースのページからBot Framework Emulatorのインストーラーをダウンロードする。

https://github.com/microsoft/BotFramework-Emulator/releases/latest

具体的には `BotFramework-Emulator-4.14.1-windows-setup.exe` （バージョン番号は変わる可能性がある）をダウンロード。

ダウンロードしたインストーラーを実行する。

## Botのプロジェクトを作成

```
cd ~/Documents
dotnet new -i Microsoft.Bot.Framework.CSharp.EchoBot
dotnet new echobot -n TimeBot
cd TimeBot
code .
```

## コードを変更する

`Bots/EchoBot.cs`を開く。

`OnMessageActivityAsync`メソッドと`OnMembersAddedAsync`メソッドがある。

`OnMessageActivityAsync`メソッドを以下に書き換える

```c#
protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
{
    // var replyText = $"Echo: {turnContext.Activity.Text}";
    // await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);

    string inputMessage = turnContext.Activity.Text;
    string responseMessage = "Ask me what the time is.";
    if (inputMessage.ToLower().StartsWith("what") && inputMessage.ToLower().Contains("time"))
    {
        var now = DateTime.Now;
        responseMessage = "The time is " + now.Hour.ToString() + ":" + now.Minute.ToString("D2");
    }
    await turnContext.SendActivityAsync(MessageFactory.Text(responseMessage, responseMessage), cancellationToken);
}
```

## コードを起動する

Visual Studio Codeで統合ターミナルを開く。

メニュー ＞ Terminal ＞ New Terminal

ターミナル内で以下を実行。

```
dotnet run
```

以下のようなログが表示される。

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:3978
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\azureuser\Documents\AI-102-AIEngineer\13-bot-framework\C-Sharp\TimeBot
```

`http://localhost:3978`でボットが動いていることがわかる。

Webブラウザーで`http://localhost:3978`にアクセスすると、このボットにアクセスするための詳細が表示される。

## Bot Framework Emulatorで、ボットの動きを確認する

- Bot Framework Emulatorを起動する。
- Open Botをクリック
- Bot URLに`http://localhost:3978/api/messages`を入力し`Connect`
- 画面下部の`Type your message`というテキストボックスに`what time`と入力すると、ボットが現在時刻を表示する。


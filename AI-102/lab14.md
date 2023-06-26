# ラボ14 チャットボット(WeatherBot)の作成

■概要

Bot Framework Composerを使用して、指定された都市(「東京都」や「大阪府」など)の現在の天気と気温を調べるチャットボット「WeatherBot」を開発します。

![](images/ss-2023-04-06-21-00-16.png)

天気の情報を取得するために、[OpenWeather](https://openweathermap.org/)というサービスを使用します。

Bot Framework Composer は、コードを記述せず、高度な会話型ボットをすばやく簡単に構築できる、グラフィカル デザイナーです。

開発したボットをAzure Bot ServiceにデプロイしてAzure上でも動作を確認します。

■ラボの起動

- ラボ環境にアクセス https://esi.learnondemand.net/
- Microsoftアカウントでサインイン
- ラボ 12 を起動
- 手順書（カスタマイズ）に従って作業を進めます。

■ヒント

- **ラボ14番では必要なAzureリソースが作成できないため、ここではワークアラウンドとしてラボ12番を起動します。**

■YouTube動画

AI-102 ラボ14 Bot Framework Composer を使用したボットの作成
https://youtu.be/U4CPu0DGMzg


■手順書（カスタマイズ）


## OpenWeather APIキーの準備

キーの取得方法

- https://openweathermap.org/price にアクセス
- 「Free」の「Get API key」をクリック
- ユーザー名、Eメール、パスワードなどの必要な情報を入力し、「Create Account」をクリック
- 入力したEメールアドレス宛てに、APIキーが送信されてくる。

## ラボの起動

ラボ12番を起動します。

- WebブラウザーでAzure portal にサインイン
- 日本語化

## リソースプロバイダーを登録

Azure App Service / Azure Bot Service リソースを作成できるように、サブスクリプションにリソースプロバイダーを登録します。

- サブスクリプションを表示
- リソースプロバイダーを表示
- Microsoft.Web を検索、登録
- Microsoft.BotService を検索、登録

<!--
## Bot Framework Emulator のインストール

Bot Framework Composerで開発したボットを実行するには、[Bot Framework Emulator](https://learn.microsoft.com/ja-jp/azure/bot-service/bot-service-debug-emulator?view=azure-bot-service-4.0&tabs=csharp)が必要。

Bot Framework Emulator（の最新版）は 以下のページからインストーラー（BotFramework-Emulator-VERSION-windows-setup.exe）をダウンロードしてインストールする。

https://github.com/Microsoft/BotFramework-Emulator/releases/latest


## Node.jsのインストール

Bot Framework Composerでボットを作成するために必要。

Windows PowerShellを起動し、以下を実行。※以下同様

```
choco install -y nodejs
```

## .NET Core 3.1 SDKのインストール

Bot Framework ComposerからBot Framework Emulatorを起動するために必要。

```
choco install -y dotnetcore-3.1-sdk
```

## Bot Framework Composerのインストール

```
choco install -y bot-framework-composer
```
-->

## Bot Framework Composerを起動

スタートメニュー、またはデスクトップ上のアイコンから、Bot Framework Composerを起動を起動する。

## Bot Framework Composerの日本語化

![](images/ss-2023-04-06-21-07-26.png)

## Bot Framework Composer のエラーについて

![](images/ss-2023-04-06-22-01-36.png)

Bot Framework Composerで作業中に、このようなエラーが出る場合がある。これはOKを押して閉じるしかない。

## ボット(WeatherBot)の作成

![](images/ss-2023-04-06-21-08-47.png)

![](images/ss-2023-04-06-21-09-15.png)

![](images/ss-2023-04-06-21-11-52.png)

![](images/ss-2023-04-06-21-13-18.png)

## 言語理解（レコグナイザー）の変更

「正規表現」タイプに変更。

![](images/ss-2023-04-06-21-14-47.png)

## デフォルトのメッセージの変更

```
こんにちは！私に、天気について聞いてください
```

![](images/ss-2023-04-06-21-17-07.png)

```
すみません、よくわかりません。私に、天気について聞いてください
```

![](images/ss-2023-04-06-21-19-19.png)


## 天気を取得する「ダイアログ」（対話）の追加

![](images/ss-2023-04-06-21-21-07.png)

![](images/ss-2023-04-06-21-21-31.png)

![](images/ss-2023-04-06-21-22-31.png)

![](images/ss-2023-04-06-21-23-00.png)

```
都市（東京都、大阪府、北海道、沖縄県など）を入力してください
```

![](images/ss-2023-04-06-21-24-39.png)

Property:
```
dialog.city
```

Output format:
```
=trim(this.value)
```

![](images/ss-2023-04-06-21-25-35.png)

## APIの呼び出し

![](images/ss-2023-04-06-21-26-32.png)

Uri: ※YOURAPPIDの部分は、取得したOpenWeather APIのAPIキーに置換。
```
http://api.openweathermap.org/data/2.5/weather?units=metric&q=${dialog.city}&lang=ja&units=metric&appid=YOURAPPID
```

Result property:
```
dialog.api_response
```
![](images/ss-2023-04-06-21-30-04.png)

## 条件分岐の作成

![](images/ss-2023-04-06-21-31-02.png)

![](images/ss-2023-04-06-21-31-58.png)


```
=dialog.api_response.statusCode == 200
```

![](images/ss-2023-04-06-21-33-21.png)

## APIからのプロパティの取得とメッセージの表示

![](images/ss-2023-04-06-21-37-35.png)

![](images/ss-2023-04-06-21-38-03.png)

| 項目     | 値 |
| -------- | ----------------------------------------------------- |
| Property | `dialog.weather`                                      |
| Value    | `=dialog.api_response.content.weather[0].description` |

![](images/ss-2023-04-06-21-38-38.png)

![](images/ss-2023-04-06-21-40-44.png)

※上記と同様に、「プロパティの管理＞プロパティの設定」を追加

| 項目     | 値 |
| -------- | ----------------------------------------------------- |
| Property | `dialog.temp`                                      |
| Value    | `=round(dialog.api_response.content.main.temp)` |

※このように「Set a property」が2つ連続する形になる。
![](images/ss-2023-04-06-22-39-48.png)

![](images/ss-2023-04-06-21-43-30.png)

```
${dialog.city} の天気は ${dialog.weather} で、温度は ${dialog.temp}&deg; です。
```
![](images/ss-2023-04-06-21-44-44.png)

![](images/ss-2023-04-06-21-45-26.png)


```
エラー: ${dialog.api_response.content.message}
```
![](images/ss-2023-04-06-21-46-14.png)


## 天気のダイアログを起動するトリガーを追加

![](images/ss-2023-04-06-21-48-11.png)


```
トリガー名: WeatherRequested
正規表現パターン: 天気
```

![](images/ss-2023-04-06-21-49-09.png)


![](images/ss-2023-04-06-21-49-49.png)


![](images/ss-2023-04-06-21-50-19.png)


## 動作確認

![](images/ss-2023-04-06-21-53-57.png)

![](images/ss-2023-04-06-21-54-33.png)

![](images/ss-2023-04-06-21-54-52.png)

画面下部の Type your message というテキストボックスに「天気を教えて」などと入力する。「天気」というキーワードに反応して、GetWeatherダイアログが起動される。続いて「東京都」といった都市名を入力する。

```
天気を教えて
東京都
天気を調べてください
大阪府
```

![](images/ss-2023-04-06-21-53-22.png)

それ以外のキーワードの場合は以下のような応答を返す。

![](images/ss-2023-04-06-21-56-21.png)

![](images/ss-2023-04-06-21-57-49.png)

## サインイン

![](images/ss-2023-04-06-21-58-53.png)

※トレーニング初日に作成したMicrosoftアカウントでサインイン。

![](images/ss-2023-04-06-21-59-30.png)

※パスワードを入力するなどしてサインインを進めていく。

![](images/ss-2023-04-06-22-00-41.png)


## 発行プロファイルの作成

![](images/ss-2023-04-06-22-03-12.png)

![](images/ss-2023-04-06-22-03-49.png)

![](images/ss-2023-04-06-22-04-57.png)

※「Name」のところは、「weatherbot(乱数)」とする。「(乱数)」の部分は、適当に10桁ほど数字を打ち込む。

![](images/ss-2023-04-06-22-06-27.png)

※下にスクロールして、Optionalのチェックをすべて外す。

![](images/ss-2023-04-06-22-07-21.png)

![](images/ss-2023-04-06-22-08-05.png)

しばらく待つ。

![](images/ss-2023-04-06-22-08-25.png)

3分ほどでプロビジョニングが完了する。

![](images/ss-2023-04-06-22-10-19.png)

## 公開（パブリッシュ）

![](images/ss-2023-04-06-22-11-18.png)

![](images/ss-2023-04-06-22-11-39.png)

![](images/ss-2023-04-06-22-11-58.png)

しばらく待つ。

## Azureでの動作確認

![](images/ss-2023-04-06-22-21-26.png)

![](images/ss-2023-04-06-22-21-48.png)

![](images/ss-2023-04-06-22-22-05.png)

「Your bot is ready!」と表示されればOK。

![](images/ss-2023-04-06-22-22-24.png)

![](images/ss-2023-04-06-22-23-03.png)

![](images/ss-2023-04-06-22-23-22.png)

```
天気を教えてください
北海道
```

![](images/ss-2023-04-06-22-24-47.png)

以上です。おつかれさまでした！

■手順書（公式、参考）

日本語:
https://microsoftlearning.github.io/AI-102-AIEngineer.ja-jp/Instructions/14-bot-composer.html

英語:
https://microsoftlearning.github.io/AI-102-AIEngineer/Instructions/14-bot-composer.html

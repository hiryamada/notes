# ラボ10 「会話言語理解(CLU)」を使用するアプリの作成

前のラボ([ラボ9](lab09.md))で作成したリソースを使用して、自然言語による命令を理解するアプリを作成します。

## ClockプロジェクトのPrediction URL のコピー

Deploying a model ＞ Deployments ＞ Get prediction URL で、Prediction URLをコピー。

コピーされる文字列の例:
```
https://clu999998273492734.cognitiveservices.azure.com/language/:analyze-conversations?api-version=2022-10-01-preview
```

この文字列から末尾の部分を削除し、`.cognitiveservices.azure.com/`で終わるようにする。

```
https://clu999998273492734.cognitiveservices.azure.com/
```

この文字列をメモ帳などに控えておく。

## Languageリソースの「Primary Key」のコピー

Project settingsの「Primary key」をコピー。メモ帳などに控えておく。

## NuGetパッケージのコピー

<!--
https://www.nuget.org/packages/Azure.AI.Language.Conversations
-->

dotnet add package Azure.AI.Language.Conversations --version 1.0.0

## プロジェクトを開く

Visual Studio Codeのメニュー File＞Open Folder...で以下のフォルダーを開く

```
AI-102-AIEngineer/10b-clu-client-(preview)/C-Sharp/clock-client
```

## 設定ファイルの編集

`appsettings.json`を開き、以下のように編集して保存。

- LSPredictionEndpointの値: コピーしておいた「Prediction URL」
- LSPredictionKeyの値: コピーしておいた「Primary key」

## コーディング


`program.cs`を開く。

以下の2つの手順を参考に、コードの中に必要なコードを追記していく。

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/10b-language-understanding-client-(preview).md#language-service-sdk-%E3%82%92%E4%BD%BF%E7%94%A8%E3%81%99%E3%82%8B%E6%BA%96%E5%82%99%E3%82%92%E3%81%99%E3%82%8B

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/10b-language-understanding-client-(preview).md#%E4%BC%9A%E8%A9%B1%E8%A8%80%E8%AA%9E%E3%83%A2%E3%83%87%E3%83%AB%E3%81%8B%E3%82%89%E4%BA%88%E6%B8%AC%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B

## 実行

Visual Studio Codeのメニュー＞Terminal＞New Terminalで、ターミナルを開く。

`dotnet run`で、プロジェクトを実行する。

`Enter some text ('quit' to stop)`と表示されるので、`what the date today`、`what time is it now` などと入力して、結果を確認する。


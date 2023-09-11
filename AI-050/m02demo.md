# 講師デモ Azure OpenAI で作業を開始する

[手順書](https://microsoftlearning.github.io/mslearn-openai.ja-jp/Instructions/Labs/01-get-started-azure-openai.html)

■概要

- リソースを作成する
  - gpt-35-turbo (model version: 0301)をデプロイするため、「Japan East」などではなく「East US」に作る。
- モデルをデプロイする
- Azure OpenAI Studioの「プレイグラウンド」でAzure OpenAI Serviceの動作を確認する。
  - Completion
  - Chat
- プロンプトとパラメータを調節する
  - 温度
  - 最大長（トークン）
- コード生成

■モデル

- gpt-35-turbo (model version: 0301)をデプロイする。
- [gpt-35-turbo (model version: 0613)はChat Completions APIのみサポート。](https://learn.microsoft.com/en-us/answers/questions/1340679/azure-openai-getting-completions-call-failed-opera)
  - Completion APIで使用するとエラーとなる。

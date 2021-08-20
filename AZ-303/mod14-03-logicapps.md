# Azure Logic Apps

ビジネス プロセスの実行を自動化するクラウド サービス。

"Logic Apps デザイナー" と呼ばれるグラフィカル デザイン ツールを使ってアプリを作成。

[製品ページ](https://azure.microsoft.com/ja-jp/services/logic-apps/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-overview)

Microsoft Learn
[Azure Logic Apps の概要](https://docs.microsoft.com/ja-jp/learn/modules/intro-to-logic-apps/)


■リソースの作成方法

検索＞「ロジック アプリ」

タイプ：「消費」と「Standard」

■コネクタ

外部サービスへのインターフェイスを提供するコンポーネント。 

- Twitter コネクタ
  - ツイートを送信および取得
- Office 365 Outlook コネクタ
  - メール、予定表、連絡先を管理できる。 

アプリの作成に使用できる何百もの事前構築済みコネクタが提供されている。

コネクタには、トリガーとアクションが含まれる。

■ トリガー

特定の条件のセットが満たされたときに発生するイベントです。

例：Twitterで特定のキーワードを含むツイートがあった、メールを受信した、Slackにメッセージが投稿された、など。


[300種類を超えるコネクタ](https://docs.microsoft.com/ja-jp/connectors/connector-reference/)が利用可能。


[カスタム コネクタ](https://docs.microsoft.com/ja-jp/connectors/custom-connectors/)を開発することも可能。

■アクション

ビジネス プロセスのタスクを実行する操作です。

複数のアクションを組み合わせることができます。

例：メールを送る、Twitterにツイートを送信する、Slackにメッセージを投稿する、テキストの感情を分析する、など。

■ ワークフローを制御するアクション

https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#control-workflow-actions)

- [ForEach](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#foreach-action)
- [If (Condition)](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#if-action)
- [Scope](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-control-flow-run-steps-group-scopes)
- [Switch](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#switch-action)
- [Until](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#until-action)



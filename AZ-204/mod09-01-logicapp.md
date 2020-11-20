Azure Logic Apps

Azure Logic Apps は、ビジネス プロセスの実行を自動化するクラウド サービスです。

"Logic Apps デザイナー" と呼ばれるグラフィカル デザイン ツールを使ってアプリを作成します。



[製品ページ](https://azure.microsoft.com/ja-jp/services/logic-apps/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-overview)

Microsoft Learn
[Azure Logic Apps の概要](https://docs.microsoft.com/ja-jp/learn/modules/intro-to-logic-apps/)


# リソースの作成方法

検索＞「ロジック アプリ」

検索＞「ロジック アプリ（プレビュー）」

# コネクタ

"コネクタ" は、外部サービスへのインターフェイスを提供するコンポーネントです。 

たとえば、Twitter コネクタを使うとツイートを送信および取得でき、Office 365 Outlook コネクタを使うとメール、予定表、連絡先を管理できます。 

Logic Apps では、アプリの作成に使用できる何百もの事前構築済みコネクタが提供されています。

コネクタには、トリガーとアクションが含まれます。

# トリガー

"トリガー" は、特定の条件のセットが満たされたときに発生するイベントです。

例：Twitterで特定のキーワードを含むツイートがあった、メールを受信した、Slackにメッセージが投稿された、など。

# アクション

"アクション" は、ビジネス プロセスのタスクを実行する操作です。

複数のアクションを組み合わせることができます。

例：メールを送る、Twitterにツイートを送信する、Slackにメッセージを投稿する、テキストの感情を分析する、など。

# コントロールアクション

Condition：条件分岐
Switch
For each
Until
Branch

[Power Automate(旧称 Microsoft Flow)などの類似サービスとの比較](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-compare-logic-apps-ms-flow-webjobs)

Power Automateはビジネスユーザー向け。Logic Appsは開発者向け。

2020/9に「Logic App (Preview)」が登場しました。[ブログ](https://techcommunity.microsoft.com/t5/azure-developer-community-blog/new-logic-apps-runtime-performance-and-developer-improvements/ba-p/1645335)、[マニュアル](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code)。

- [ステートフルとステートレス](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code)のサポート。ステートフルは高信頼性、ステートレスは低遅延。
- [価格モデル](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code#pricing-model)
- [オンプレミス システム用のコネクタ](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code#whats-in-this-public-preview)
- [SAS接続文字列](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code#whats-in-this-public-preview)
- [Visual Studio Code 開発環境でローカルにロジック アプリを実行してデバッグ](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code#whats-in-this-public-preview)
- [Azure App Service や Docker コンテナーなどへのデプロイ](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-stateful-stateless-workflows-visual-studio-code#whats-in-this-public-preview)

# コネクタ

[コネクタ](https://docs.microsoft.com/ja-jp/connectors/)は、基盤になるサービスが Microsoft Power Automate、Microsoft Power Apps、Azure Logic Apps と通信できるようにする API のプロキシまたはラッパーです。 それにより、ユーザーがアカウントを接続し、事前に構築されたトリガーとアクションのセットを活用してアプリとワークフローを作成する方法が提供されます。

[300種類を超えるコネクタ](https://docs.microsoft.com/ja-jp/connectors/connector-reference/)が利用可能です。


[カスタム コネクタ](https://docs.microsoft.com/ja-jp/connectors/custom-connectors/)を開発することも可能です。

# オンプレミス データ ゲートウェイ

Azure Logic Apps から[オンプレミスのデータ ソースに接続](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-gateway-install#install-data-gateway)するには、ローカル コンピューターにオンプレミス データ ゲートウェイをダウンロードしてインストールします。

# VNet への接続

ロジック アプリがAzure 仮想ネットワークにアクセスする必要があるシナリオでは、" 統合サービス環境 " (ISE) を作成します。 ISE は、専用のストレージと、"グローバル" なマルチテナント Logic Apps サービスとは別に確保されている他のリソースを使用する専用環境です。


統合サービス環境は指定された VNet 内に作成されます。

ロジックアプリのリソースを作成する際に、統合サービス環境を指定します。

# Enterprise Integration Pack (EIP)

組織の間に企業間 (B2B) ソリューションとシームレスな通信を実現するために、Azure Logic Apps で Enterprise Integration Pack (EIP) を使用して、自動化されたスケーラブルなエンタープライズ統合ワークフローを構築することができます。 

組織どうしは、異なるプロトコルと形式を使用していても、メッセージを電子的に交換することができます。

異なる形式は、EIP によって、組織のシステムで処理できる、AS2、X12、EDIFACT などの業界標準プロトコルをサポートする形式に変換されます。 

[統合アカウントを作成](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-enterprise-integration-create-integration-account?tabs=azure-portal)し、アーティファクトを追加したら、Azure portal でロジック アプリを作成することにより、これらのアーティファクトを使用して B2B ワークフローの構築を開始できます。 




# 参考

> IFTTTと同様のサービスとして、Yahoo Japanの「myThings」やMicrosoftの「Microsoft Flow」、Zapierの「Zapier」、Integromatの「Integromat」などがある。
> 
https://www.atmarkit.co.jp/ait/articles/1711/22/news031.html


# 知識チェック


■知識チェックのポイント

「製品の注文」というイベント発生時に、在庫を更新する処理を行う、C#でコードを開発済み → Azure Functions

リレーショナルDBの運用、オンラインでのトランザクション処理（OLTP） → メモリを多く使用する → メモリ最適化

小規模な処理、イベント発生時の処理ではない、秒単位での処理（秒単位でのコスト支払い） → Azure Container Instance (ACI)

■知識チェック

https://docs.microsoft.com/ja-jp/learn/modules/design-compute-solution/10-knowledge-check

# ケーススタディ

https://github.com/MicrosoftLearning/AZ-305-DesigningMicrosoftAzureInfrastructureSolutions.ja-jp/blob/main/Instructions/CaseStudy/02-Compute.md

■タスク

あなたは、Tailwind Traders社の[クラウドアーキテクト](https://www.google.com/search?q=%E3%82%AF%E3%83%A9%E3%82%A6%E3%83%89%E3%82%A2%E3%83%BC%E3%82%AD%E3%83%86%E3%82%AF%E3%83%88)です。

- 上記の「ケーススタディ」ページの「要件」を読んでください。
- Tailwind Traders社の問題点を分析し、改善案をできるだけ多く提案してください。
- 「中間層」の解釈と解決が難しい（ヘルプデスク担当者の人手不足？）ので、今回は「フロントエンド層」と「バックエンド（データベース）層」だけ考えていただければOKです。
  - 例: スケーラビリティを改善するために～～を導入する
  - 例: 負荷分散のために～～を導入する
  - 例: サーバーの管理負担を減らすため～～を採用する
  - 例: コストを削減するため～～を導入する
  - 例: バックエンド層へのリクエストを削減するため～～を導入する
  - 例: 静的コンテンツは～～を使用して配信する
- 改善案は、Klaxoonに記入してください。
- 上記「ケーススタディ」ページ内の「タスク」はスキップしてください。
- このコースでここまでに学習した知識に限定する必要はありません。
- 「要件」に書かれていないことについて、講師に質問してはっきりさせる必要はなく、適当に仮定を置いて大丈夫です。その場合は改善案に仮定も添えてください。
  - 例: 「フロントエンド層のサーバーは高負荷時、CPU使用率が高いですが、メモリには充分な余裕があるとします」
- できればAzureを活用して問題を解決してください。
  - あまりよくない例: 「HTML/CSS/JavaScriptに[Minify](https://ssaits.jp/promapedia/technology/minify.html)を行います」
  - あまりよくない例: 「アプリケーションをRustで再実装します」
  - あまりよくない例: 「お客様にアクセスしやすい時間帯をご案内します」
  - あまりよくない例: 「[犬を表示します](https://www.google.com/search?q=amazon%E3%82%A8%E3%83%A9%E3%83%BC+%E7%8A%AC)」

■ヒント

- [VMSS](https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview)
- [App Service のスケールアウト](https://docs.microsoft.com/ja-jp/azure/app-service/manage-scale-up)
- [AKSの仮想ノード](https://docs.microsoft.com/ja-jp/azure/architecture/solution-ideas/articles/scale-using-aks-with-aci)
- [KubernetesのHPA](https://docs.microsoft.com/ja-jp/azure/aks/concepts-scale)
- [Azure FunctionのHTTPトリガー](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-http-webhook-trigger?tabs=in-process%2Cfunctionsv2&pivots=programming-language-csharp)
- [Azure Load Balancer](https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview)
- [Azure Application Gateway](https://docs.microsoft.com/ja-jp/azure/application-gateway/overview)
- [Azure Cache for Redis](https://docs.microsoft.com/ja-jp/azure/azure-cache-for-redis/cache-overview)
- [Azure Load Testing](https://azure.microsoft.com/ja-jp/services/load-testing/#overview)
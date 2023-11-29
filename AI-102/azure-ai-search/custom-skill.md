# カスタムスキル

ドキュメント
https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-custom-skill-interface

Microsoft Learnモジュール「Azure Cognitive Search のカスタム スキルを作成する」
https://learn.microsoft.com/ja-jp/training/modules/create-enrichment-pipeline-azure-cognitive-search/

Microsoft社員Nobusuke Hanagasakiさんが書いた解説記事「Azure Cognitive Search のカスタムスキルを作成しよう」
https://qiita.com/nohanaga/items/986887b82cf76dc7b0a9


■カスタムスキルとは

Azure AI Searchの機能。

インデクサーが検索したドキュメントの中身のデータを外部 Web API に飛ばして、さまざまなエンリッチメント処理を行う。

■Azure Functions

Azureのサーバーレスコンピューティングサービス。

イベント発生時（たとえばHTTPリクエストの受信時など）に、Pythonなどのコードを実行する。

カスタムスキルのコードはAzure Functions（など）でホスティングできる。


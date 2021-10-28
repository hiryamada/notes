# Azure Synapse Analytics

データ ウェアハウスやビッグ データ システム全体にわたって分析情報を取得する時間を早めるエンタープライズ分析サービス

2016/6/14 Azure SQL Data Warehouse 一般提供開始
https://azure.microsoft.com/en-us/updates/general-availability-azure-sql-data-warehouse/

2018/5/1 Azure SQL Data Warehouse Gen2 一般提供開始
https://azure.microsoft.com/ja-jp/updates/elevate-your-performance-with-azure-sql-data-warehouse-gen2/

2019/11/7 Azure SQL Data Warehouse が Azure Synapse Analytics に変わった
https://azure.microsoft.com/ja-jp/blog/azure-sql-data-warehouse-is-now-azure-synapse-analytics/

■Synapse ワークスペース

https://docs.microsoft.com/ja-jp/azure/synapse-analytics/get-started-create-workspace

Azure Synapse Analyticsのリソース。リージョン内に作成。

■Synapse Studio

https://docs.microsoft.com/ja-jp/azure/synapse-analytics/get-started-create-workspace#open-synapse-studio

ワークスペースの「概要」で「Synapse Studioの起動」をクリックして起動。

「開発」ハブで、SQLを実行することができる。

「管理」＞「Apache Sparkプール」で「Sparkプール」を作成し、「開発」ハブの「Notebook」から「Sparkプール」を選択して、Sparkを使用したデータ分析を行うことができる。

■SQLプール

https://docs.microsoft.com/ja-jp/azure/synapse-analytics/sql/overview-architecture

SQLを実行するための分散クエリシステム。

T-SQL を使用する。(Synapse SQL)


- 専用SQLプール
  - 以前の SQL DW。
  - プロビジョニングして使用する。
- サーバーレスSQLプール
  - 各ワークスペースは、組み込み と呼ばれる、事前構成されたサーバーレス SQL プールを備えている。
  - 容量を予約せずに SQL を使用できる。
  - 課金は、クエリの実行に使用されたノードの数ではなく、クエリを実行するために処理されたデータの量に基づく。

■Apache Spark プール

https://docs.microsoft.com/ja-jp/azure/synapse-analytics/spark/apache-spark-overview#spark-pool-architecture

クラスターの管理を気にすることなく Spark を操作できる。

■Synapse Link

https://docs.microsoft.com/ja-jp/azure/cosmos-db/synapse-link

- Synapse Link for Cosmos DB
  - Cosmos DBのデータに対し、Azure Synapse Analytics で、抽出、変換、読み込み (ETL) なしの分析を大規模に実行することができる
  - Synapse Spark と Synapse SQL のどちらも利用できる
  - Cosmos DB でのトランザクション ワークロードのパフォーマンスに影響を与えることがない。
- Synapse Link for Dataverse
  - [Microsoft Dataverse](https://docs.microsoft.com/ja-jp/powerapps/maker/data-platform/data-platform-intro) のデータを準リアルタイムで把握することができる
  - データ上で分析、ビジネス インテリジェンス、機械学習のシナリオを実行することができる

■Synapse パイプライン

https://docs.microsoft.com/ja-jp/azure/synapse-analytics/overview-terminology#pipelines

パイプラインを使用して、データの統合が可能。

サービス間でデータを移動したり、アクティビティを調整したりすることができる。

■参考

[Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/modules/introduction-azure-synapse-analytics/)
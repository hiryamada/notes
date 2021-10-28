
# データ プラットフォームの構築

https://docs.microsoft.com/ja-jp/azure/architecture/example-scenario/dataplate2e/data-platform-end-to-end

■データの取り込み（Ingest）

- [Azure Event Hubs](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-about)
  - ビッグデータのインジェスト（取り込み）サービス
- [Azure IoT Hub](https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-concepts-and-iot-hub)
  - IoTデバイスの接続とデータ取り込み
  - IoTアプリケーションの接続

■データのETL（抽出、変換、読み込み）

- [Azure Data Factory](https://docs.microsoft.com/ja-jp/azure/data-factory/introduction)
  - ETL（抽出、変換、読み込み）/ELT（抽出、読み込み、変換）サービス
  - 多数の「[コネクター](https://docs.microsoft.com/ja-jp/azure/data-factory/connector-overview)」を使用して、各種のデータ ストアからのデータを取り込み
  - 「[マッピング データ フロー](https://docs.microsoft.com/ja-jp/azure/data-factory/concepts-data-flow-overview)」による変換・処理


■データの蓄積

- [Azure Cosmos DB](https://docs.microsoft.com/ja-jp/azure/cosmos-db/introduction)
  - NoSQLデータベース
  - 低遅延（1桁ミリ秒）
  - グローバル分散
    - データを複数リージョンにレプリケーション可能
    - マルチマスターをサポート
  - データ容量は無制限（[サーバーレスモードの場合を除く](https://docs.microsoft.com/ja-jp/azure/cosmos-db/serverless)）
  - 1項目あたりの最大容量は2MB
- [Azure Data Lake Storage Gen2](https://docs.microsoft.com/ja-jp/azure/storage/blobs/data-lake-storage-introduction)
  - データレイク用のストレージ
  - [Azure Blob Storageと近い機能を持つ](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-feature-support-in-storage-accounts)
  - 低コスト

■データの分析（データサイエンティスト向け）

- [Azure HDInsight](https://docs.microsoft.com/ja-jp/azure/hdinsight/hdinsight-overview)
  - ビッグデータ分析サービス
  - Apache Hadoop, Apache Kafka, Apache Sparkなどのフレームワークを利用可能
  - [2006/4 Hadoop 0.1.0 リリース](https://en.wikipedia.org/wiki/Apache_Hadoop#History)
  - (2012年頃 [Apache HadoopがWindows(Azure)に移植される](https://gihyo.jp/dev/serial/01/hdinsight/0001))
  - [2012/10/3 Windows Azure HDInsights 登場](https://social.technet.microsoft.com/wiki/contents/articles/13820.introduction-to-azure-hdinsight.aspx)
  - [2015/9/28 HDInsight on Linux 一般提供開始](https://weblogs.asp.net/scottgu/announcing-general-availability-of-hdinsight-on-linux-new-data-lake-services-and-language)
- [Azure Databricks](https://docs.microsoft.com/ja-jp/azure/databricks/scenarios/what-is-azure-databricks)
  - Apache Sparkを使用したデータ分析プラットフォーム
  - Databricks Machine Learning: 組み込みの機械学習環境
  - [2013年 Databrics社設立](https://ja.wikipedia.org/wiki/%E3%83%87%E3%83%BC%E3%82%BF%E3%83%96%E3%83%AA%E3%83%83%E3%82%AF%E3%82%B9)
  - [2015/6/15 Databrics 一般提供開始](https://databricks.com/jp/blog/2015/06/15/databricks-is-now-generally-available.html)
  - [2018/3/22 Azure Databricks 一般提供開始](https://azure.microsoft.com/en-us/blog/azure-databricks-industry-leading-analytics-platform-powered-by-apache-spark/)
- [Azure Synapse Analytics](https://docs.microsoft.com/ja-jp/azure/synapse-analytics/overview-what-is)
  - データウェアハウス
  - T-SQLやApache Sparkによるビッグデータ分析
  - Azure Data Factory と同じデータ統合エンジンとエクスペリエンスが含まれている
  - [2016/6/14 Azure SQL Data Warehouse 一般提供開始](https://azure.microsoft.com/en-us/updates/general-availability-azure-sql-data-warehouse/)
  - [2019/11/7 Azure Synapse Analytics に名称変更](https://azure.microsoft.com/ja-jp/blog/azure-sql-data-warehouse-is-now-azure-synapse-analytics/)

■データの分析（エンドユーザー向け）

- [Power BI](https://docs.microsoft.com/ja-jp/power-bi/fundamentals/power-bi-overview)
  - [2015/7/24 一般提供開始](https://powerbi.microsoft.com/ja-jp/blog/power-bi-is-generally-available-today/)
  - BI(ビジネスインテリジェンス)ツール
  - データの対話的な分析と視覚化
  - [Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/modules/introduction-power-bi/?ns-enrollment-type=Collection&ns-enrollment-id=k8xidwwnzk1em)

■データの分類・機密データの検出

- [Azure Purview](https://docs.microsoft.com/ja-jp/azure/purview/overview)
  - データ資産の分類・カタログ化
  - SQL Serverなど多数のソースに接続可
  - Azure Synapse ワークスペースにリンクすることで、Azure Synapse Studio 内から Azure Purview の資産を検索および操作
  - [2021/9/28 一般提供開始](https://azure.microsoft.com/en-us/updates/azure-purview-is-now-generally-available/)
  - [Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/modules/intro-to-azure-purview/)

■他組織とのデータの共有

- [Azure Data Share](https://docs.microsoft.com/ja-jp/azure/data-share/overview)
  - [2019/11/4 一般提供開始](https://azure.microsoft.com/ja-jp/updates/now-available-azure-data-share/)
  - Azure に保存されているビッグ データを他の組織と簡単かつ安全に共有



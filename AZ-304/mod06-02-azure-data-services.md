# 適切なデータストアの選択

https://docs.microsoft.com/ja-jp/azure/architecture/guide/technology-choices/data-store-decision-tree

フローチャートを使用して、候補となるデータストア(Azureサービス)を選択することができる。

■SQL Server

- Azure SQL Database
- Azure SQL Managed Instance
- SQL Server on Azure VM

■オープンソースRDB

- Azure Database for PostgreSQL
- Azure Database for MySQL
- Azure Database for MariaDB

■NoSQLデータベース

- Azure Cosmos DB
  - SQL (Core) API
  - MongoDB API
  - Cassandra API
  - Gremlin API
  - Table API

■ストレージアカウント

- Azure Blob Storage
- Azure Files
- Azure Table Storage
- Azure Queue Storage

■データレイク

- Azure Data Lake Storage Gen2

■データの検索

- Azure Cognitive Search (旧称 Azure Search)
  - 組み込み AI 機能を備えたクラウド検索サービス
  - [製品ページ](https://azure.microsoft.com/ja-jp/services/search/#overview)
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/search/search-what-is-azure-search)

■IoTデータの取り込みと分析

- Azure Time Series Insights Gen2
  - オープンでスケーラブルなエンドツーエンドの IoT 分析サービス
  - [製品ページ](https://azure.microsoft.com/ja-jp/services/time-series-insights/#product-overview)
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/time-series-insights/overview-what-is-tsi)

■キャッシュ

- [Azure Cache for Redis](https://docs.microsoft.com/ja-jp/azure/azure-cache-for-redis/cache-overview)

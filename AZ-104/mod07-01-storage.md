# ストレージ系のサービス

## [ストレージ アカウント](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-account-create?tabs=azure-portal)内で利用できるサービス
- [Azure Blob Storage](https://azure.microsoft.com/ja-jp/services/storage/blobs/) - このモジュールで解説。
- [Azure Files](https://azure.microsoft.com/ja-jp/services/storage/files/) - このモジュールで解説。
- [Azure Queue Storage](https://azure.microsoft.com/ja-jp/services/storage/queues/) - [多数のメッセージを格納](https://docs.microsoft.com/ja-jp/azure/storage/queues/storage-queues-introduction)
- [Azure Table Storage](https://azure.microsoft.com/ja-jp/services/storage/tables/) - [NoSQLデータストア](https://docs.microsoft.com/ja-jp/azure/cosmos-db/table-storage-overview)

※上記4つに「[マネージド ディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview)」を含めて「[コア ストレージ サービス](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-introduction#core-storage-services)」とも呼ばれます。

## VM用のディスク
- [マネージド ディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview) - 複数の[ストレージ スケール ユニット](https://www.google.com/search?q=%E3%82%B9%E3%83%88%E3%83%AC%E3%83%BC%E3%82%B8%20%E3%82%B9%E3%82%B1%E3%83%BC%E3%83%AB%20%E3%83%A6%E3%83%8B%E3%83%83%E3%83%88)に自動的に配置、[99.999%の可用性で設計](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview)
- （マネージドではない）ディスク - [Azure Blob Storage](https://azure.microsoft.com/ja-jp/services/storage/blobs/)内の[VHD](https://docs.microsoft.com/ja-jp/previous-versions/windows/it-pro/windows-7/dd979539(v=ws.10)?redirectedfrom=msdn)（[ページBLOB](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-pageblob-overview)）
- [一時ディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview#temporary-disk) - 一時ディスクとは、**デプロイした VM に直接アタッチされているストレージ**のことです。一時ディスクのデータは、VM をシャットダウンすると消失します。ほとんどの VM で利用できます。アプリケーションやプロセスのために短期間の保存場所を提供するものであり、ページやスワップ ファイルなどのデータ格納のみを意図しています。メンテナンス イベント中、または VM の再デプロイ時に失われる可能性があります。

## [データ レイク](https://www.google.com/search?q=%E3%83%87%E3%83%BC%E3%82%BF+%E3%83%AC%E3%82%A4%E3%82%AF)
- [Azure Data Lake Storage Gen2](https://azure.microsoft.com/ja-jp/services/storage/data-lake-storage/) - [ストレージ アカウント](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-account-create?tabs=azure-portal)作成時に「[階層構造の名前空間](https://docs.microsoft.com/ja-jp/azure/storage/blobs/data-lake-storage-namespace)」を「有効」にして作成すると、そのストレージ アカウント内で利用できます。

# データベース系のサービス

## NoSQLデータベース
- [Cosmos DB](https://azure.microsoft.com/ja-jp/services/cosmos-db/)

※ [ストレージ アカウント](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-account-create?tabs=azure-portal)内の[Azure Table Storage](https://azure.microsoft.com/ja-jp/services/storage/tables/)は、「NoSQLデータストア」と呼ばれます（データベースとは呼ばれません）。

## SQL Serverのサービス
  - [Azure SQL Database](https://azure.microsoft.com/ja-jp/services/sql-database/)
  - [SQL Server on Virtual Machines](https://azure.microsoft.com/ja-jp/services/virtual-machines/sql-server/)

## Oracle

- Azure上で[Oracle DatabaseなどのOracle製品](https://azure.microsoft.com/ja-jp/solutions/oracle/)を稼働させることができます。
- [「Oracle Cloud」 東京リージョンとMicrosoft Azure東日本リージョン間において低遅延な相互接続を開始](https://www.oracle.com/jp/corporate/pressrelease/jp20200508.html)

## オープンソースのデータベースのサービス
  - [Azure Database for PostgreSQL](https://azure.microsoft.com/ja-jp/services/postgresql/)
  - [Azure Database for MySQL](https://azure.microsoft.com/ja-jp/services/mysql/)
  - [Azure Database for MariaDB](https://azure.microsoft.com/ja-jp/services/mariadb/)

# データレイク/データ分析

- [Azure Synapse Analytics](https://azure.microsoft.com/ja-jp/services/synapse-analytics/) - データ統合、データ ウェアハウス、ビッグ データ分析

# キャッシュ系のサービス

- [Azure Cache for Redis](https://azure.microsoft.com/ja-jp/services/cache/)
- [Azure HPC Cache](https://azure.microsoft.com/ja-jp/services/hpc-cache/)
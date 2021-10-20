# Azure Data Migration Service

運用データベースの移行とデータ ウェアハウスの移行の両方に対応するよう設計されたフル マネージド サービス

製品ページ
https://azure.microsoft.com/ja-jp/services/database-migration/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/dms/

価格
https://azure.microsoft.com/ja-jp/pricing/details/database-migration/


■DMSでサポートされるシナリオ

https://docs.microsoft.com/ja-jp/azure/dms/resource-scenario-status

- オフライン (1 回限りの移行) 
  - アプリケーションのダウンタイムあり
- オンライン (継続的同期) 
  - アプリケーションのダウンタイムなし

移行元の例
- SQL Server
- Oracle Database
- MySQL
- PostgreSQL
- MongoDB

移行先の例
- Azure SQL
  - Azure SQL Database
  - Azure SQL Managed Instance (MI)
  - SQL server on Virtual Machines
- Azure DB
  - Azure Database for PostgreSQL
  - Azure Database for MySQL

可能な組み合わせについては[ドキュメント](https://docs.microsoft.com/ja-jp/azure/dms/resource-scenario-status)や[移行ガイド](https://docs.microsoft.com/ja-jp/data-migration/)を参照。

■参考: データベースの移行ガイド

https://docs.microsoft.com/ja-jp/data-migration/

**DMS以外の方法** を含めて、さまざまなデータベース移行パターンがまとめられている。

例: [AccessからSQL Serverへの移行](https://docs.microsoft.com/ja-jp/sql/sql-server/migrate/guides/access-to-sql-server?view=sql-server-ver15)など。

■ツール

- [Data Migration Assistant](https://docs.microsoft.com/ja-jp/sql/dma/dma-overview)
  - SQL Server を評価するためのスタンドアロン ツール
- [Azure Database Migration Service](https://azure.microsoft.com/ja-jp/services/database-migration/#overview)
  - オンプレミスのデータベースを移行
  - 移行先: SQL Server on Azure VM / Azure SQL Database / SQL Managed Instance

■DMSのインスタンス

https://docs.microsoft.com/ja-jp/azure/dms/quickstart-create-data-migration-service-portal

- 最適な移行エクスペリエンスのために、ターゲット データベースと同じ Azure リージョンに Azure Database Migration Service のインスタンスを作成することが推奨されている。
- リージョンや地域をまたいでデータを移動する場合、移行プロセスが遅くなり、エラーが発生する可能性がある。

■価格

- Standard 価格レベル
  - オフライン移行 ("1 回限り" の移行とも呼ばれる) をサポート
  - 仮想コアが 1 個、2 個、4 個のオプション
  - 無料
- Premium 価格レベル
  - ダウンタイムを最小限に抑えなければならないビジネス クリティカルなワークロードのオフライン移行とオンライン移行 ("継続的な移行" とも呼ばれる) に対応
  - 仮想コア 4 個
  - 有料（1時間あたりの料金）

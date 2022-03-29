# モジュール2 知識チェック

■復習: Azure SQL Database

- Azure SQL
  - Azure SQL Database
    - サービスレベル に [Hyperscale](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tier-hyperscale) を含む
  - Azure SQL Database Managed Instance (MI)
  - SQL Server on Azure VM

■ポイント解説:

クラウド前提でアプリケーションを新規開発 → Azure SQL Database

オンプレミスのデータベースの移行（オンプレミスのSQL Serverとの互換性を重視） → SQL Server Managed Instance

Windows認証を必要とする（オンプレミスのSQL Serverとの互換性を重視＋Windows固有の機能） → SQL Server on Azure VM（Azure仮想マシン内でSQL Serverを運用する）

大容量（数十TB～100TB）のデータ → サービスレベル Hyperscale

■知識チェック

https://docs.microsoft.com/ja-jp/learn/modules/design-data-storage-solution-for-relational-data/10-knowledge-check


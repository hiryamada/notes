# Azure Migrate

製品ページ
https://azure.microsoft.com/ja-jp/services/azure-migrate/

価格
https://azure.microsoft.com/ja-jp/pricing/details/azure-migrate/

- Azure Migrate および Azure Migrate のツールは、追加料金なしで利用できる。
- ただし、サードパーティ製の ISV ツールに対する料金が発生する場合がある。

ドキュメント
https://docs.microsoft.com/ja-jp/azure/migrate/

わかりやすい解説（山市良氏の記事）
https://www.atmarkit.co.jp/ait/articles/1908/22/news011.html

AZ-304のラボ「Azure Migrate を使用して Hyper-V VM を Azure に移行する」
https://microsoftlearning.github.io/AZ-304JA-Microsoft-Azure-Architect-Design/Instructions/Labs/Module_3_Lab.html

Microsoft Learn: ASP.NET アプリを Azure に移行する
https://docs.microsoft.com/ja-jp/learn/paths/migrate-dotnet-apps-azure/

■ISVとは？

Indipendent Software Vendor（独立系ソフトウェアベンダー）。サードパーティ。
https://ja.wikipedia.org/wiki/ISV

Azure Migrate は、いくつかの ISV オファリング（ISVが提供する、サーバーの評価・移行ソリューション）と統合されている。
https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview#isv-integration

■Azure Migrateの「ハブ」とは？

Azure Migrate では、オンプレミスのサーバー、インフラストラクチャ、アプリケーション、データを評価し、Azure への移行を行うための一元化された「ハブ」が提供される。
https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview

Azure Migrate は、インフラストラクチャからアプリケーションやデータに至るまで、すべての移行ニーズとツールの中央「ハブ」として機能する。
https://azure.microsoft.com/ja-jp/blog/introducing-the-new-azure-migrate-a-hub-for-your-migration-needs/

> オンプレミスのVMware仮想マシンの移行を支援するサービスとしてスタートした「Azure Migrate」が、2019年7月に新バージョンに刷新。Hyper-V仮想マシン、SQL Serverデータベース、ISV（独立系ソフトウェアベンダー）のソリューションを含む、Azureへの移行プロジェクトの“中央ハブ”として生まれ変わった。
https://www.atmarkit.co.jp/ait/articles/1908/22/news011.html

なお「Azure Migrate ハブ」といったリソースがあるわけではない。

Azure Migrateは、さまざまな移行プロジェクトの中心となる場所（ハブ）という **位置づけ** のサービスである。

たとえば、Azure Data Boxを使用した、オンプレからAzureへのデータの移行作業を、Azure Data Boxの画面からも開始できるが、Azure Migrateの画面からも開始できる。

■オンプレミスのHyper-Vクラスター上のVMをAzureに移行する手順

Azure Migrate:Server Migration ツールを使用して、オンプレミスの Hyper-V VM を Azure に移行する

- Hyper-Vレプリケーションプロバイダーをクラスターにインストールする
- 各VMをAzureにレプリケーションする
- テスト移行を実行する
  - 移行が想定どおりに動作することが確認される
  - テスト移行後、クリーンアップを実行
- VMを移行する
- 移行を完了する
  - VMを右クリックして「移行を停止する」を選ぶ

https://docs.microsoft.com/ja-jp/azure/migrate/tutorial-migrate-hyper-v


Hyper-V の移行に Azure Migrate アプライアンスは使用されない


■VMware 環境でサーバーのアプライアンスを設定する

https://docs.microsoft.com/ja-jp/azure/migrate/how-to-set-up-appliance-vmware


■プロジェクト

Azure Migrateの画面で「プロジェクト」を作成する。

プロジェクトには、オンプレミスのサーバーから収集されたメタデータが格納される。

https://docs.microsoft.com/ja-jp/azure/migrate/create-manage-projects

■Azure Migrate アプライアンス

- VMware 環境で実行されているサーバーの検出と評価
- VMware 環境で実行されているサーバーのエージェントレス移行
- Hyper-V 環境で実行されているサーバーの検出と評価
- オンプレミスの物理または仮想化されたサーバーの検出と評価

※Hyper-V の移行に Azure Migrate アプライアンスは使用されない

アプライアンスをデプロイし、マシンとパフォーマンスのメタデータを継続的に検出する。

アプライアンスから、Windows Serverに接続（WinRM, ポート5985）やLinux（ポート22）に接続する。

https://docs.microsoft.com/ja-jp/azure/migrate/migrate-appliance

■評価ツール

プロジェクトに、評価ツールを追加する。

- 物理または仮想サーバーの評価
- SQL Serverの評価
- Webアプリの評価
- VDI（仮想デスクトップインフラストラクチャ）の評価

https://docs.microsoft.com/ja-jp/azure/migrate/how-to-assess

■ツール

Azure Migrate で利用できるツール

- Azure Migrate: Discovery and Assessment
  - 検出と評価
- Azure Migrate: Server Migration
  - 移行
- Data Migration Assistant
  - SQL Server を評価するためのスタンドアロン ツール
- Azure Database Migration Service
  - オンプレミスのデータベースを移行
  - 移行先: SQL Server on Azure VM / Azure SQL Database / SQL Managed Instance
- Movere
  - サーバーの評価
- Web App Migration Assistant
  - オンプレミスのWebアプリを評価・移行
- Azure Data Box
  - オフラインデータの移行
- その他: ISVのツール

■評価・移行できるワークロード

- Windows 
- Linux
- SQL Server
- Webアプリケーション
- 仮想デスクトップ（VDI）
- 大量のデータ
  - Azure Data Box製品を使って移行

- オンプレミス

■Azure App Service Migration Assistant （オンラインスキャン）

https://azure.microsoft.com/ja-jp/services/app-service/migration-assistant/

- Web アプリのパブリック URL に対してスキャンを実行
- 使用されているテクノロジと、それらが App Service により全面的にサポートされているかどうかを確認
- 互換性がある場合は、移行を簡略化するために Migration Assistant （下記） をダウンロードするようガイドされる。

■Azure App Service Migration Assistant （ツール）

オンプレミスの .NET、Java、Linux Web アプリを評価し、Azure App Service に移行することができるツール。

以下からダウンロードできる。
https://azure.microsoft.com/ja-jp/services/app-service/migration-assistant/

- App Service Migration Assistant
  - ASP.NET アプリケーション
- App Service migration assistant — for Java on Apache Tomcat (Linux)
  - Apache Tomcat で実行されている Java Web アプリ
  - Linux で実行されているオンプレミスの Docker コンテナー
- App Service migration assistant—for Java on Apache Tomcat (Windows)
  - Windows server上のApache Tomcatで実行されている Java Web アプリ

登場時のブログ（使い方の説明あり）
https://azure.microsoft.com/ja-jp/blog/introducing-the-app-service-migration-assistant-for-asp-net-applications/


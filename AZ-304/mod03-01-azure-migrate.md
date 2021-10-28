# Azure Migrate

https://docs.microsoft.com/ja-jp/azure/migrate/

■歴史

2017/9/25 Azure Migrate の提供を「アナウンス」
https://azure.microsoft.com/ja-jp/blog/announcing-azure-migrate/

- オンプレミス仮想マシンの検出と評価
- 多層アプリケーションの信頼性の高い検出のための組み込みの依存関係マッピング
- Azure仮想マシンへのインテリジェントな適正化(rightsizing)
- 互換性レポート（潜在的な問題を修正するためのガイドラインを含む）
- データベースの検出と移行のための[Azure Database Migration Service](https://azure.microsoft.com/ja-jp/services/database-migration/)との統合 

2018/2/28 Azure Migrate 一般提供開始
https://azure.microsoft.com/en-us/blog/confidently-plan-your-cloud-migration-azure-migrate-is-now-generally-available/

2019/7/11 Azure Migrate の機能強化
https://azure.microsoft.com/ja-jp/updates/azure-migrate-enhancements/

- Microsoft および人気のある ISV の評価と移行のツールから選択できる拡張可能なアプローチ
- サーバーとデータベースを検出、評価、移行し、エンドツーエンドで進行状況を追跡する統合されたエクスペリエンス
- VMware、Hyper-V、物理サーバーの大規模な移行のためのサーバー評価およびサーバー移行
- Azure SQL Database や Managed Instance を含むさまざまなデータベース ターゲットのデータベース評価およびデータベース移行

■Azure Migrateの位置づけ

Azure Migrateは、さまざまな移行プロジェクトの **「ハブ」**（中心となる場所）となるサービスである。

※注意: 「Azure Migrate ハブ」といったリソースがあるわけではない。「ハブ」という言葉は、Azure Migrate というサービスの、移行作業における **位置づけ** を表している。

Azure Migrate では、オンプレミスのサーバー、インフラストラクチャ、アプリケーション、データを評価し、Azure への移行を行うための一元化された **「ハブ」** が提供される。
https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview

Azure Migrate は、インフラストラクチャからアプリケーションやデータに至るまで、すべての移行ニーズとツールの **「ハブ」** として機能する。
https://azure.microsoft.com/ja-jp/blog/introducing-the-new-azure-migrate-a-hub-for-your-migration-needs/

> オンプレミスのVMware仮想マシンの移行を支援するサービスとしてスタートした「Azure Migrate」が、2019年7月に新バージョンに刷新。Hyper-V仮想マシン、SQL Serverデータベース、ISV（独立系ソフトウェアベンダー）のソリューションを含む、Azureへの移行プロジェクトの“中央ハブ”として生まれ変わった。
https://www.atmarkit.co.jp/ait/articles/1908/22/news011.html

たとえば、Azure Data Boxを使用した、オンプレからAzureへのデータの移行作業は、Azure Data Boxの画面から開始することができるが、Azure Migrateの画面から開始することもできる。

■評価・移行できるワークロードの例

- Windows 物理/仮想マシン
- Linux 物理/仮想マシン
- SQL Server
- ASP.NET Webアプリケーション
- 仮想デスクトップ（VDI）
- SAP
- 大量のデータ
  - Azure Data Box製品を使って移行


■ISVとの統合

Azure Migrate は、いくつかの ISV オファリング（ISVが提供する、サーバーの評価・移行ソリューション）と統合されている。
https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview#isv-integration

■参考: ISVとは？

Indipendent Software Vendor。独立系ソフトウェアベンダー。いわゆるサードパーティ。マイクロソフト製品とともに使用することができる製品を開発する、マイクロソフト外の企業。

- https://e-words.jp/w/ISV.html
- https://ja.wikipedia.org/wiki/ISV

■価格
https://azure.microsoft.com/ja-jp/pricing/details/azure-migrate/

- Azure Migrate および Azure Migrate のツールは、追加料金なしで利用できる。
- ただし、サードパーティ製の ISV ツールに対する料金が発生する場合がある。

■Azure Migrateの基本的な用語・概念

(1)検出（discover / discovery）

オンプレミスや、他のクラウド（AWS、GCP等）で稼働している、VMware, Hyper-V, 物理サーバーなどを発見すること。

例: 「[Azure Migrateアプライアンス](https://docs.microsoft.com/ja-jp/azure/migrate/migrate-appliance)」をオンプレミスにデプロイすることで、Hyper-V, VMwareの仮想マシン、物理サーバーを検出することができる。

(2)評価（assess / assessment）

検出されたサーバーの移行の対応性を測定すること。移行先のAzure VMのサイズが推奨される。

評価方法:
- CPU,メモリ,ディスク等の使用率に基づく評価（パフォーマンスベース評価）
- オンプレミスのサーバーのサイズに基づく評価
- CSV形式でサーバーメタデータをインポート

例: Azure Migrate: Discovery and Assessment（Azure Migrate: 検出および評価ツール）を使用して、[VMware仮想マシン、Hyper-V仮想マシン](https://docs.microsoft.com/ja-jp/azure/migrate/concepts-assessment-calculation)、[SQL Serverインスタンス](https://docs.microsoft.com/ja-jp/azure/migrate/concepts-azure-sql-assessment-calculation)、[ASP.NET Web アプリ](https://docs.microsoft.com/ja-jp/azure/migrate/concepts-azure-webapps-assessment-calculation)などを評価することができる。

(3)移行（migrate / migration）

検出・評価されたサーバーをAzureへ移行すること。

例: [Azure Migrate: Server Migration ツール](https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview#azure-migrate-server-migration-tool)を使用して、オンプレミスのVMware VM、オンプレミスのHyper-V VM、オンプレミスの物理サーバーなどを移行する。

■Azure Migrate アプライアンス

https://docs.microsoft.com/ja-jp/azure/migrate/migrate-appliance

Azure Migrate アプライアンスをオンプレミスにデプロイすることで、マシンとパフォーマンスのメタデータを継続的に検出することができる。

- VMware 環境で実行されているサーバーの検出と評価
- Hyper-V 環境で実行されているサーバーの検出と評価
- オンプレミスの物理または仮想化されたサーバーの検出と評価

■移行方式: エージェント/エージェントレス

https://docs.microsoft.com/ja-jp/azure/migrate/server-migrate-overview

https://docs.microsoft.com/ja-jp/azure/migrate/common-questions-server-migration#what-are-the-migration-options-in-azure-migrate-server-migration

エージェント: 検出されたサーバーに追加されるソフトウェア。

検出・評価・移行の際に、エージェントを使用する場合（エージェントベース）と、エージェントを使用しない場合（エージェントレス）がある。

エージェントレスの移行は、エージェントベースのレプリケーション オプションよりも利便性とシンプルさに優れているが、いくつか制約事項もある（iSCSIターゲットがサポートされない等）

例:
- オンプレミスのVMware仮想マシン
  - [エージェントレスでの移行](https://docs.microsoft.com/ja-jp/azure/migrate/tutorial-migrate-vmware-powershell)
  - [エージェントベースでの移行](https://docs.microsoft.com/ja-jp/azure/migrate/tutorial-migrate-vmware-agent)
- オンプレミスのHyper-V仮想マシン
  - [エージェントレスでの移行](https://docs.microsoft.com/ja-jp/azure/migrate/hyper-v-migration-architecture)
- オンプレミスの物理サーバー
  - [エージェント ベースでの移行](https://docs.microsoft.com/ja-jp/azure/migrate/migrate-support-matrix-physical-migration)

■ツール

Azure Migrate で利用できるツール

- [Azure Migrate: Discovery and Assessment](https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview#azure-migrate-discovery-and-assessment-tool)
  - 検出と評価
- [Azure Migrate: Server Migration](https://docs.microsoft.com/ja-jp/azure/migrate/migrate-services-overview#azure-migrate-server-migration-tool)
  - 移行
- [Data Migration Assistant](https://docs.microsoft.com/ja-jp/sql/dma/dma-overview)
  - SQL Server を評価するためのスタンドアロン ツール
- [Azure Database Migration Service](https://azure.microsoft.com/ja-jp/services/database-migration/#overview)
  - オンプレミスのデータベースを移行
  - 移行先: SQL Server on Azure VM / Azure SQL Database / SQL Managed Instance
- [Web App Migration Assistant](https://azure.microsoft.com/ja-jp/services/app-service/migration-assistant/)
  - オンプレミスのWebアプリを評価・移行
- [Azure Data Box](https://azure.microsoft.com/ja-jp/services/databox/)
  - オフラインデータの移行
- ISVのツール(現在9種類)
  - [Movere](https://docs.microsoft.com/ja-jp/movere/overview)
    - ※[モヴェーレ: ラテン語で「動かす」](https://ja.wiktionary.org/wiki/movere)
    - 組織内のITデータの検出・評価
    - ボットを使用して、IT 環境全体の包括的なインベントリを迅速にスキャンして収集
    - [オンプレミス環境と、AWS や GCP などの他のパブリック クラウド内のデバイスをスキャンできる](https://docs.microsoft.com/ja-jp/movere/about-scanning)
    - 2019/9にMicrosoftがMovere社を買収し、Microsoftが提供するSaaS製品の一つとなった
    - [利用にはライセンスが必要](https://azure.microsoft.com/ja-jp/pricing/details/azure-migrate/)

■Azure Migrateの画面

Azure portal画面上部の検索で「Azure Migrate」を検索。

ここから移行の「プロジェクト」を開始することができる。


例:
- オンプレミスのWindows物理マシンを、Azure 仮想マシンへ移行するプロジェクト
- オンプレミスのSQL Serverを、Azure SQL Databaseへ移行するプロジェクト
- オンプレミスの大量のデータを、Azure Data Boxを使用して、Azure Blob Storageへインポートするプロジェクト

■Azure Migrateのプロジェクト

Azure Migrateの画面で「プロジェクト」というリソースを作成する。

```
リソースグループ
└プロジェクト
 ├名前
 └地域（メタデータを格納する場所。「日本」「米国」等）
```

「プロジェクト」には、オンプレミスのサーバーから収集されたメタデータが格納される。

https://docs.microsoft.com/ja-jp/azure/migrate/create-manage-projects

「プロジェクト」を作成すると、プロジェクトに「評価ツール」と「移行ツール」が追加される。

例1:
```
project1(サーバーの移行プロジェクト)
├評価ツール Azure Migrate: Discovery and assessment
└移行ツール Azure Migrate: Server Migration
```

例2:
```
project1(サーバーの移行プロジェクト)
├評価ツール Azure Migrate: Database Assessment
└移行ツール Azure Migrate: Database Migration
```

手動で、プロジェクトに評価ツールや移行ツールを追加することもできる。

プロジェクトはARMテンプレートを使用して作成することもできる。
https://docs.microsoft.com/ja-jp/azure/migrate/quickstart-create-migrate-project

■オンプレミスのHyper-Vクラスター上のVMをAzureに移行する手順

https://docs.microsoft.com/ja-jp/azure/migrate/tutorial-migrate-hyper-v

Azure Migrate:Server Migration ツールを使用して、オンプレミスの Hyper-V VM を Azure に移行する

- Hyper-Vレプリケーションプロバイダーをクラスターにインストールする
- 各VMをAzureにレプリケーションする
- テスト移行を実行する
  - 移行が想定どおりに動作することが確認される
  - テスト移行後、クリーンアップを実行
- VMを移行する
- 移行を完了する
  - VMを右クリックして「移行を停止する」を選ぶ


■Webアプリの移行 

(1)Azure App Service Migration Assistantの「オンラインスキャン」

https://azure.microsoft.com/ja-jp/services/app-service/migration-assistant/

- Web アプリのパブリック URL に対してスキャンを実行
- 使用されているテクノロジと、それらが App Service により全面的にサポートされているかどうかを確認
- 互換性がある場合は、移行を簡略化するために Migration Assistant （下記） をダウンロードするようガイドされる。

(2)Azure App Service Migration Assistant の「移行ツール」

.NET、Java、Linux Web アプリを評価し、Azure App Service に移行することができるツール。

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


■参考資料/学習ソース

わかりやすい解説（山市良氏の記事）
https://www.atmarkit.co.jp/ait/articles/1908/22/news011.html

AZ-304のラボ「Azure Migrate を使用して Hyper-V VM を Azure に移行する」
https://microsoftlearning.github.io/AZ-304JA-Microsoft-Azure-Architect-Design/Instructions/Labs/Module_3_Lab.html

Microsoft Learn: ASP.NET アプリを Azure に移行する
https://docs.microsoft.com/ja-jp/learn/paths/migrate-dotnet-apps-azure/

■参考: Azureへの移行とモダナイゼーション（現代化、近代化、最新化）

「移行およびモダナイゼーション」センター（Azureの情報ページ）
https://azure.microsoft.com/ja-jp/migration

このページでは、Azureへ移行することができるリソース例、移行のメリット、移行に使用することができるAzureのサービス（Azure Migrationを含む）、実際のお客様の移行事例などについての情報を得ることができる。

- 仮想デスクトップ
- サーバー
- データベース
- Webアプリ
- メインフレーム
- SAP
- 開発・テスト環境

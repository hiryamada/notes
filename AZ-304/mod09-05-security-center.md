# Azure Security Center

https://docs.microsoft.com/ja-jp/azure/security-center/security-center-introduction

統合インフラストラクチャ セキュリティ管理システム

クラウド セキュリティ態勢管理 (CSPM: Cloud Security Posture Management クラウド セキュリティ ポスチュア マネジメント)

2016/7/28 Azure Security Center 一般提供開始
https://azure.microsoft.com/ja-jp/updates/generally-available-azure-security-center/

[PDFまとめ](../AZ-500/pdf/mod4/Azure%20Security%20Center%20まとめ.pdf)


■ハンズオン: Azure Security Centerの使用を開始する
- Azure Security Centerを表示する
- 画面下部の「スキップ」をクリックする
- 「セキュア スコア」「規制コンプライアンス」「分析情報」などに「表示するデータはありません」と表示される
- 「Azure Defender」には「Azure Defender による保護なし」と表示される。

# Azure Defender

2020/9/22～ Azure Security CenterのStandard editionからAzure Defenderへ名称変更。

https://azure.microsoft.com/ja-jp/services/azure-defender/#overview

クラウド ワークロード保護 (CWP: Cloud Workload Protection)

Azure Security Centerと統合されている。

セキュリティセンターを使い始める際に、Azure Defenderを有効にする（「アップグレード」）または、無効にする（「スキップ」）することができる。

- Azure Defender for servers
  - Microsoft Defender for Endpoint を含む。
- Azure Defender for App Service
- Azure Defender for SQL
- Azure Defender for PostgreSQL/MySQL/MariaDB (open-source rdbs)
- Azure Defender for Storage
- Azure Defender for Kubernetes
- Azure Defender for container registries
- Azure Defender for Key Vault
- Azure Defender for Resource Manager
- Azure Defender for DNS

■歴史

2020/9/22 「Azure Standard Center Standard edition」が、「Azure Defender」にリブランド（ブランド再構築）された。[Azure Standard Centerのプランは「Free」と「Azure Defender」となった](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-pricing#what-are-the-plans-offered-by-security-center)。
https://azure.microsoft.com/en-us/blog/protect-multicloud-workloads-with-new-azure-security-innovations/?WT.mc_id=AZ-MVP-5004198

2020/12/2 Azure Defender for SQL Server 一般提供開始
https://techcommunity.microsoft.com/t5/azure-security-center/azure-defender-for-sql-server-is-now-generally-available/m-p/1950132

2020/1/23 Microsoft Defender ATP for Linux 一般提供開始
https://techcommunity.microsoft.com/t5/microsoft-defender-for-endpoint/microsoft-defender-atp-for-linux-is-now-generally-available/ba-p/1482344

2021/1/27 Azure Defender for IoT 一般提供開始
https://www.microsoft.com/security/blog/2021/01/27/announcing-the-general-availability-of-azure-defender-for-iot/

2021/5 Azure Defender for DNS, Azure Defender for Resource Manager,オープンソースのリレーショナル データベース向け Azure Defender を一般提供開始
https://docs.microsoft.com/ja-jp/azure/security-center/release-notes#azure-defender-for-dns-and-azure-defender-for-resource-manager-released-for-general-availability-ga

2021/6/9 Azure Defender for Azure Database for MySQL – Single Server  一般提供開始
https://azure.microsoft.com/en-us/updates/azure-defender-for-azure-database-for-mysql-single-server-now-generally-available/

■Microsoft 365 Defenderとの関係

https://www.microsoft.com/ja-jp/security/business/threat-protection?rtc=1

Azure Defenderは、Microsoft 365 Defenderとは別の製品。

```
Microsoft Defender
├Microsoft 365 Defender: エンドユーザーの保護
└Azure Defender: インフラ(Azureリソース)の保護
```

■価格

30 日間の無料試用版が利用可能。

無料試用期間終了後はリソースの種類ごとに料金が発生。

例: Azure Defender for Servers $0.02/サーバー/時間

■エージェント

https://docs.microsoft.com/ja-jp/azure/security-center/security-center-enable-data-collection

■ハンズオン: Azure Defenderの使用を開始する

- Azure Security Centerを表示する
- 画面左の「はじめに」をクリック
- 画面下部の「アップグレード」をクリックする。
- 「エージェントのインストール」をクリックする（Log Analyticsエージェントが、選択されたサブスクリプションのすべてのVMにインストールされる）

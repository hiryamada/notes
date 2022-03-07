# Microsoft Defender for Cloud

https://docs.microsoft.com/ja-jp/azure/security-center/security-center-introduction

- 統合インフラストラクチャ セキュリティ管理システム
- Azure 内かどうかにかかわらずクラウド内とオンプレミス上のハイブリッド ワークロード全体を保護
- クラウド セキュリティ態勢管理 (CSPM: Cloud Security Posture Management クラウド セキュリティ ポスチュア マネジメント)


[PDFまとめ](../AZ-500/pdf/mod4/Microsoft%20Defender%20for%20Cloud%20まとめ.pdf)


■歴史

2016/7/28 Azure Security Center 一般提供開始
https://azure.microsoft.com/ja-jp/updates/generally-available-azure-security-center/

2020/9/22 「Azure Security Center Standard edition」が、「Azure Defender」にリブランド（ブランド再構築）された。[Azure Standard Centerのプランは「Free」と「Azure Defender」となった](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-pricing#what-are-the-plans-offered-by-security-center)。
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

Microsoft Defenderは、Microsoft 365 Defenderとは別の製品。

```
Microsoft Defender
├Microsoft 365 Defender: エンドユーザーの保護
└Microsoft Defender: インフラ(Azureリソース)の保護
```

■価格

30 日間の無料試用版が利用可能。

無料試用期間終了後はリソースの種類ごとに料金が発生。

例: Azure Defender for Servers $0.02/サーバー/時間

■エージェント

https://docs.microsoft.com/ja-jp/azure/defender-for-cloud/enable-data-collection
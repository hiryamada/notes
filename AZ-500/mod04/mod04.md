モジュール4 セキュリティオペレーション

# Azure Monitor

Azureリソースの監視機能。

- [メトリックとログの例](../../AZ-303/pdf/mod15/メトリックとログの例.pdf)
- [Azure Monitor まとめ資料](../../AZ-104/pdf/mod11/Azure%20Monitor.pdf)

# Log Analytics

- Log Analytics: ログ分析のためのツール。KQLを使用して、ログのクエリ（検索）を行う。
- Log Analyticsワークスペース: ログを格納するリソース
- 診断設定: ログの発生源（サブスクリプションのアクティビティログ等）から、Log Analyticsワークスペース等に、ログを送信する設定。

[Log Analyticsまとめ資料](../../AZ-104/pdf/mod11/Log%20Analytics.pdf)

# Microsoft Defender for Cloud

[まとめ資料](../pdf/mod4/Microsoft%20Defender%20for%20Cloud%20まとめ.pdf)

各「Defenderプラン」の解説:
https://learn.microsoft.com/ja-jp/training/modules/understand-azure-defender-cloud-workload-protection/

- [Microsoft Defender for Servers](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-servers-introduction)
  - Azure、AWS、GCP リソースへの Defender for Endpoint の自動プロビジョニングなど
- [Microsoft Defender for App Service](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-app-service-introduction)
  - App Service で実行されるアプリケーションをターゲットとした攻撃を検出
- [Microsoft Defender for Storage](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-storage-introduction)
  - ストレージ アカウントに対する、通常とは異なるアクセスの試行・悪用を検出
- [Microsoft Defender for Database](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/quickstart-enable-database-protections)
  - 攻撃の検出と脅威対応によってデータベース資産全体を保護
  - Azure SQL Database, SQL Server on VM, Azure Database for PostgreSQL/MySQL/MariaDB, Azure Cosmos DB
- [Microsoft Defender for Key Vault](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-key-vault-introduction)
  - Key Vault アカウントに対するアクセスまたは悪用の試みを検出
- [Microsoft Defender for Resource Manager](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-resource-manager-introduction)
  - 悪意のある IP アドレスからの操作、マルウェア対策ソフトの無効化、VM 拡張機能で実行される不審なスクリプト利用などを検出
  - 悪用ツールキット: [Microburst](https://github.com/NetSPI/MicroBurst), [PowerZure](https://dev.to/cheahengsoon/gathering-subscription-access-information-with-powerzure-2poc) などの利用の検出
- [Microsoft Defender for DNS](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-dns-introduction)
  - Azure DNSに対する攻撃を検出
- [Microsoft Defender for Containers](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-containers-introduction)
  - Azure/AWS/GCP/オンプレミスの Kubernetes クラスターの継続的な監視
  - データ プレーンのセキュリティ強化: Kubernetes API サーバーに対するすべての要求を、事前定義された一連のベスト プラクティスを基準にして監視
- [Microsoft Defender for DevOps](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-devops-introduction)
  - GitHub や Azure DevOpsでコード脆弱性を発見, 安全なコード開発を支援
- [Microsoft Defender CSPM](https://www.microsoft.com/en-us/security/business/cloud-security/microsoft-defender-cloud-security-posture-management?rtc=1)
  - ハイブリッドおよびマルチクラウド環境を包括的にカバーするCSPM（クラウドセキュリティ態勢管理、誤設定を発見）

※2022/10/12 Microsoft Ignite (毎年行われるテクニカルカンファレンス)
Microsoft Defender for DevOps / Microsoft Defender CSPM 発表
https://www.microsoft.com/security/blog/2022/10/12/introducing-new-microsoft-defender-for-cloud-innovations-to-strengthen-cloud-native-protections/

# Microsoft Sentinel

[まとめ資料](../pdf/mod4/Microsoft%20Sentinel%20まとめ.pdf)
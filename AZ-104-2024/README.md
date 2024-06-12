# AZ-104

https://learn.microsoft.com/ja-jp/training/courses/az-104t00

Azure サブスクリプションの管理、ID の保護、インフラストラクチャの管理、仮想ネットワークの構成、Azure とオンプレミスサイトの接続、ネットワーク トラフィックの管理、ストレージ ソリューションの実装、仮想マシンの作成と拡張、Web アプリケーションとコンテナの実装、データのバックアップと共有、ソリューションの監視などの方法について解説します。

4日間

## 日程

1日目:
- オープニング（開始時のご案内、講師自己紹介等）
- 講義: Entra ID
- 講義: ガバナンスとコンプライアンス
- 講義: Azure管理者
- [ラボの実施方法のご案内](../AZ-104-2023/lab.md)
- ラボ（講師デモ）
  - [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AZ-104%20Exam%20Guide%20-%20Microsoft%20Azure%20Administrator)
    - 1 Manage Azure Active Directory identities
    - 2 Manage subscriptions and RBAC
    - 3 Manage governance via Azure Policy
    - 4 Manage Azure resources by using the Azure portal
    - 5 Manage Azure resources by using Azure Resource Manager Templates
    - 6 Manage Azure resources by using Azure PowerShell
    - 7 Manage Azure resources by using Azure CLI
  - [ラボ環境](https://esi.learnondemand.net/)
    - 1 Manage Microsoft Entra ID Identities (JA) /Microsoft Entra ID を管理する
      - テナントの作成、ユーザーの作成、グループの作成、グループへのユーザーの追加
    - 2 Manage Subscriptions and RBAC (JA) / サブスクリプションと RBAC を管理する
      - 管理グループの作成、ロールの割り当て、カスタムロールの作成、アクティビティログの確認
    - 3 Manage Governance via Azure Policy (JA) / Azure Policy を介してガバナンスを管理する
      - リソースグループの作成、タグの設定、ポリシーの割り当て、ストレージアカウントの作成
        - ポリシー(1) Require a tag and its value on resources
        - ポリシー(2) Inherit a tag from the resource group if missing
      - リソースグループでの削除ロックの作成
    - 4 Manage Azure resources by Using the Azure Portal (JA)
      - ディスクの作成(Azure portal,ARM, Azure PowerShell, Azure CLI, Bicep)

2日目:
- 講義: 仮想ネットワーク
- 講義: サイト間接続
- 講義: ネットワークトラフィック管理
- ラボ（講師デモ）
  - [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AZ-104%20Exam%20Guide%20-%20Microsoft%20Azure%20Administrator)
    - 8 Implement virtual networking
    - 9 Implement inter-site connectivity
    - 10 Implement traffic management
  - [ラボ環境](https://esi.learnondemand.net/)
    - 5 Implement Virtual Networking (JA) / 仮想ネットワークを実装する
      - 仮想ネットワークの作成、アプリケーションセキュリティグループの作成
      - ネットワークセキュリティグループの作成、受信/送信セキュリティ規則の作成
      - Azure DNSパブリックDNSゾーン/プライベートDNSゾーンの作成
    - 6 Implement Intersite Connectivity (JA) / サイト間の接続性を実装する
      - 仮想マシンの作成（2つの仮想ネットワークに2つの仮想マシン）
      - Network Watcherでの疎通確認
      - 仮想ネットワークピアリングの作成
      - ルートテーブルの作成
    - 7 Implement Traffic Management (JA) / トラフィック管理を実装する
      - Webサーバーの作成（ARMテンプレートを利用）
      - Azure Load Balancerの作成、Azure Application Gatewayの作成

3日目:
- 講義: Azure Storage
- 講義: Azure Virtual Machine
- 講義: App Service
- ラボ（講師デモ）
  - [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AZ-104%20Exam%20Guide%20-%20Microsoft%20Azure%20Administrator)
    - 11 Manage Azure Storage
    - 12 Manage virtual machines
    - 13 Implement Azure Web Apps
  - [ラボ環境](https://esi.learnondemand.net/)
    - 8 Manage Azure Storage (JA) / Azure Storageを管理する
      - ストレージアカウントの作成、ネットワーク設定
        - Blobの利用
          - ライフサイクル管理の設定
          - 時間ベースのアイテム保持ポリシーの設定
          - Blobのアップロード
          - SASの生成
        - ファイル共有の利用
          - ファイル共有の作成、フォルダの作成、ファイルのアップロード
      - ネットワークの設定（仮想ネットワークからのアクセスに制限）
    - 9 Manage Virtual Machines (JA) / 仮想マシンを管理する
      - 仮想マシンの作成
        - サイズの変更、ディスクの追加
      - 仮想マシンスケールセットの作成、スケーリングの設定
      - Azure PowerShell / Azure CLI を使用した仮想マシンの作成（オプション）
    - 10 Implement Web Apps (JA) / Web Apps を実装する
      - App Service Webアプリの作成
      - デプロイスロット（ステージングスロット）の作成、スワップ
      - 自動スケーリングの設定

4日目:
- 講義: コンテナーまたはACA
- 講義: データ保護
- 講義: 監視
- ラボ（講師デモ）
  - [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AZ-104%20Exam%20Guide%20-%20Microsoft%20Azure%20Administrator)
    - 14 Implement Azure Container Instances
    - 15 Implement Azure Kubernetes Service
    - 16 Back up virtual machines
    - 17 Implement monitoring
  - [ラボ環境](https://esi.learnondemand.net/)
    - 11 Implement Azure Container Instances (JA) / Azure Container Instances を実装する
      - Azure Container Instanceの作成（hello worldを表示するコンテナーの実行）
    - 12 Implement Azure Container Apps (JA) / Azure Container Apps を実装する
      - Azure Container Appと環境の作成（hello worldを表示するコンテナーの実行）
      - ※環境は、名前 `my-containers` 、種類 `従量課金のみ` で新規作成してください
    - 13 Backup virtual machines (JA) / データ保護を実装する
      - 仮想マシンの作成（ARMテンプレートを使用）、Recovery Servicesコンテナーの作成
      - 仮想マシンのバックアップ
        - 仮想マシンのバックアップの設定、ストレージアカウントの作成
        - Recovery Servicesコンテナーのログとメトリックをストレージアカウントに出力する診断設定の作成
      - 仮想マシンのレプリケーション
        - 仮想マシンのレプリケーションの設定
    - 14 Implement Monitoring (JA) / 監視を実装する
      - 仮想マシンの作成（ARMテンプレートを使用）
      - VM insights を有効にする
      - アラートの作成、通知の設定
      - アラートをトリガーし、メールで通知を受け取る
      - 通知を抑制する設定を行う
      - ログのクエリ（KQL）を実行する
- クロージング（終了時のご案内、アンケート）

<!--
## 認定試験

https://learn.microsoft.com/ja-jp/credentials/certifications/azure-administrator/
-->

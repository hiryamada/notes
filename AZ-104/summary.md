# AZ-104 まとめ

## 前提知識

■ 管理ツール
  - Azure portal
  - Azure Cloud Shell
  - Azure CLI
  - Azure PowerShell
■ Azure Resource Manager
  - ARMテンプレート

## IDとガバナンス

■ Azure Active Directory
  - シングル サインオン
  - エディション
  - Active Directory Domain Service (ADDS) との比較
  - デバイスの参加と登録
  - セルフサービス パスワード リセット (SSPR)
  - ユーザー
  - グループ
  - ロール
  - 管理単位

■ Azure サブスクリプション
  - 管理グループ
  - サブスクリプション
  - リソースグループ
  - ロール
  - ポリシー
    - イニシアチブ
  - タグ
  - ロック
  - コスト管理 (Cost Management and Billing)

## ストレージ

■ ストレージアカウント

- ストレージアカウント
  - レプリケーション
- Blob Storage
- Azure Files
  - Azure File Sync

■委任アクセス

- Shared Access Signature (SAS)

■暗号化

- 暗号化
- カスタマー マネージド キー

■ ツール
  - Azure Storage Explorer
  - Azure Import / Export サービス
  - AzCopy

## コンピューティング

- Azure 仮想マシン
  - Virtual Machine Scale Sets (VMSS)
  - 仮想マシン拡張機能
- Azure App Service
- Azure Container Instance
- Azure Kubernetes Service
- Azure Automation State Configuration / DSC

■可用性を向上させる仕組み

- 可用性セット
- 可用性ゾーン

## 仮想ネットワーク

■仮想ネットワークの基本

- 仮想ネットワーク
- サブネット
- パブリックIPアドレス
- プライベートIPアドレス

■アクセス制限

- ネットワーク セキュリティ グループ
- アプリケーション セキュリティ グループ

■ファイアウォール

- [Azure Firewall](https://learn.microsoft.com/ja-jp/azure/firewall/overview)

■ピアリング
- VNet ピアリング
- ゲートウェイ転送

■ルーティング

- ルートテーブル
- ユーザー定義ルート
- システムルート

■Azureのサービスへの接続
- サービス エンドポイント
- プライベート エンドポイント

■DNS (名前解決)
- Azure DNS
  - プライベートDNSゾーン
  - パブリックDNSゾーン
  - レコードセット

■オンプレミスとの接続

- Azure VPN Gateway
- Azure ExpressRoute
- Azure Virtual WAN

★ロードバランサー
- Azure Load Balancer
- Azure Application Gateway

## 監視とバックアップ

■監視
- Azure Monitor
  - メトリック
  - ログ
  - アラート
- Log Analytics
- Network Watcher
- [VM Insights](https://learn.microsoft.com/ja-jp/azure/azure-monitor/vm/vminsights-overview)

■バックアップ
- Azure Backup
- 仮想マシンのバックアップ

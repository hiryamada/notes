
# サービス タグ

https://docs.microsoft.com/ja-jp/azure/virtual-network/service-tags-overview

- AzureサービスのIPアドレス プレフィックスのグループ
- NSG, Azure Firewall, ユーザー定義ルートで使用できる
- 例
  - AppService (WebアプリとFunctions)
  - AzureCosmosDB
  - AzureBackup
  - Storage - Azure Storage （特定のストレージアカウントは表さない）
  - Sql - SQL Database等（特定のインスタンスは表さない）
  - AzureCloud - すべてのデータセンター パブリック IP アドレス
  - Internet
  - VirtualNetwork

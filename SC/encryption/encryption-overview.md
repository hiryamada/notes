# 暗号化

■ストレージアカウントの暗号化

- [Azure Storage 暗号化 (SSE: サーバー側暗号化)](azure-storage-encryption.md)

■VMのディスクの暗号化

https://docs.microsoft.com/ja-jp/azure/virtual-machines/disk-encryption-overview

- [Server Side Encryption (SSE)](azure-disk-storage-sse.md)
  - 「保存時の暗号化」または 「Azure Storage 暗号化」とも呼ばれる
  - PMK（プラットフォームマネージドキー） / CMK（カスタマーマネージドキー）を使用
- [Azure Disk Encryption (ADE)](azure-disk-encryption.md)
  - BitLocker / DM-Cryptによる暗号化
  - Key Vaultに格納されるキーを使用
- [ホストベース暗号化](host-based-encryption.md)
  - VMが格納するデータを、VM をホストしているサーバーによって暗号化

■歴史

2015/6/24 Azure Key Vault 一般提供開始。
https://azure.microsoft.com/en-us/updates/general-availability-azure-key-vault/

2018/3/7 BlobとFilesでの、カスタマーマネージドキー(CMK)を使ったサーバー側暗号化(SSE) 一般提供開始。暗号化キーとシークレットはAzure Key Vaultに格納される。これまではマイクロソフト管理のキーによる暗号化が提供されていた。
https://azure.microsoft.com/en-us/blog/announcing-storage-service-encryption-with-customer-managed-keys-ga/

2016/9/29 Azure Disk Encryption 一般提供開始。Windows VM / Linux VM のOS・データディスクをBitLocker / DM-Cryptで暗号化。暗号化キーとシークレットはAzure Key Vaultに格納される。
https://azure.microsoft.com/ja-jp/updates/generally-available-azure-disk-encryption-for-windows-and-linux-for-standard-and-premium-iaas-virtual-machines/

2017/2/11 マネージドディスク 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-managed-disks-ga/

2017/2/8 マネージドディスクと同時期に、スナップショットとイメージもサポートされた。
https://azure.microsoft.com/en-us/blog/announcing-general-availability-of-managed-disks-and-larger-scale-sets/

2019/10/28 マネージドディスクでの、カスタマーマネージドキー(CMK)を使ったサーバー側暗号化(SSE) プレビュー。
https://azure.microsoft.com/ja-jp/blog/preview-server-side-encryption-with-customer-managed-keys-for-azure-managed-disks/

2020/4/2 マネージドディスクでの、カスタマーマネージドキー(CMK)を使ったサーバー側暗号化(SSE) 一般提供開始。これまでは「プラットフォームマネージドキー」による暗号化が提供されていた。
https://azure.microsoft.com/en-us/blog/announcing-serverside-encryption-with-customermanaged-keys-for-azure-managed-disks/

2020/5/19 Azure Cosmos DB でのカスタマーマネージド キーを使用した暗号化 一般提供開始。既定の暗号化の上での追加の暗号化層を利用できる。
https://azure.microsoft.com/ja-jp/updates/encryption-at-rest-with-customermanaged-keys-on-azure-cosmos-db-now-generally-available/

2021/7/10 ホストベース暗号化のドキュメントが作成される（正式リリースはまだ？） https://github.com/MicrosoftDocs/azure-docs/commits/master/articles/virtual-machines/windows/disks-enable-host-based-encryption-powershell.md


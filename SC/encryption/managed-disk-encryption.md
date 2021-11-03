# マネージド ディスク暗号化オプションの概要

https://docs.microsoft.com/ja-jp/azure/virtual-machines/disk-encryption-overview

マネージド ディスクに使用できる暗号化には、Azure Disk Encryption (ADE)、Server-Side Encryption (SSE)、ホストでの暗号化など、**いくつかの種類がある**。

- (1)Server-Side Encryption (SSE)
  - 「保存時の暗号化」または 「Azure Storage 暗号化」とも呼ばれる
- (2)Azure Disk Encryption (ADE)
  - BitLocker / DM-Cryptによる暗号化
- (3)ホストでの暗号化
  - VM ホスト上の格納データは保存時に、VM をホストしているサーバーによって暗号化され、ストレージ サービスに送られる
    - VM の CPU は使用されないため、VM のパフォーマンスには影響しない
  - エンドツーエンドの暗号化である
  - (3)ホストでの暗号化 が有効なディスクは (1)SSE では暗号化されない
  - (2)ADE が有効な場合は (3)を有効にできない


2020/4/2 マネージドディスクのCMKによるSSE 一般提供開始
https://azure.microsoft.com/ja-jp/blog/announcing-serverside-encryption-with-customermanaged-keys-for-azure-managed-disks/

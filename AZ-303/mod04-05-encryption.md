# Storage Service Encryption (SSE)

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption

- Azure Storage(ストレージ アカウント) では、サーバーサイド暗号化 (Storage Service Encryption, SSE) を使用して、データがクラウドに保存されるときに自動的に暗号化を行う。
- すべてのストレージ アカウントで有効, 無効化できない
- 透過的: ユーザーが特に暗号化や複合を行う必要はない。
- 追加コストはない。

■保存時
- ストレージに書き込まれるデータはすべてデフォルトで暗号化される(SSE)
- 256 ビット AES

■保存時の暗号化に使用するキー
- Microsoftマネージド キー
  - ストレージアカウントのすべてのサービスで利用可能
- [カスタマーマネージドキー](https://docs.microsoft.com/ja-jp/azure/storage/common/customer-managed-keys-overview)（Azure Key Vault内に保存）
  - Blob, Filesでのみ利用可能
- [カスタマー指定(Customer-provided)のキー](https://docs.microsoft.com/ja-jp/azure/storage/blobs/encryption-customer-provided-keys)
  - お客様独自のキー ストアに格納したキーを使用
  - Blobのみ

# Azure Disk Encryption (ADE)

- VM の OSディスクとデータ ディスクに対し、ボリューム暗号化を行う機能
  - [一時ディスクの暗号化も可能](https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/disk-encryption-faq#windows-vm----azure-disk-encryption--------)
- デフォルトでは有効化されない。VM作成後に明示的に有効化する。
- Windows VM とLinux VMで使用することができる
  - Windows: BitLocker(Windows 用の、ディスク暗号化機能)を使用
  - Linux: DM-Crypt(Linux ベースの透過的なディスク暗号化サブシステム)を使用
- 暗号化キーはAzure Key Vaultで管理される「カスタマーマネージドキー」である。
- 追加コストはない。（Azure Key Vaultのコストは発生）
- [無効化](https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/disk-encryption-windows#disable-encryption)も可能

■WindowsのADE

https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/disk-encryption-overview

■LinuxのADE

https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/disk-encryption-overview


■操作

Windowsでの例:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/disk-encryption-portal-quickstart

- VMを起動
- ディスク＞追加設定＞暗号化の設定
- 暗号化するディスクの種類を選択
  - なし
  - OSディスク
  - データディスク
  - 両方
- Key Vaultを作成
  - アクセスポリシーで、「Azure Disk Encryption」に対してアクセスを有効化する
- 保存

■注意事項

- Basic、A シリーズ VM、またはメモリが 2 GB 未満の仮想マシンでは利用できない。
- OS ディスクを暗号化しなければ、データディスクは暗号化できない
- 暗号化されたVMは、Azure Backupでバックアップできるが、復元は同一リージョンに限られる。別リージョンに復元することはできない。
- その他「サポートされていないシナリオ」を確認。
  - https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/disk-encryption-windows#unsupported-scenarios

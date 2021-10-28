# 暗号化

■暗号化モデル

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/encryption-models

■保存時の暗号化

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/data-encryption-best-practices#protect-data-at-rest

■転送時の暗号化

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/data-encryption-best-practices#protect-data-in-transit


■ストレージアカウントの暗号化

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption

■仮想マシンのディスクの暗号化

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/azure-disk-encryption-vms-vmss

Windows
https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/disk-encryption-overview

Linux
https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/disk-encryption-overview

■データベースの暗号化

Transparent Data Encryption(TDE):
https://docs.microsoft.com/ja-jp/sql/relational-databases/security/encryption/transparent-data-encryption?view=sql-server-ver15

SQL Server、Azure SQL データベース、および Azure Synapse Analytics のデータ ファイルを暗号化。暗号化は、ページ レベルで行われる。ページは、ディスクに書き込まれる前に暗号化され、メモリに読み込まれるときに復号される。有効化に際して、アプリケーション側に変更を加える必要がない。

Always Encrypted:
https://docs.microsoft.com/ja-jp/sql/relational-databases/security/encryption/always-encrypted-database-engine?view=sql-server-ver15

クライアント コンピューターにインストールされている、Always Encrypted が有効のドライバーは、クライアント アプリケーション内の機微なデータを自動的に暗号化および暗号化解除する。有効化に際して、アプリケーション側に変更を加える必要がない。アプリケーションに対して暗号化を透過的に実行。データベースに格納されるクレジット カード番号や社会保障番号などの[機微なデータ(sensitive data, 個人情報)](https://www.lrm.jp/security_magazine/sensitive-pii/)を保護するために設計された機能。データベースの管理者などであっても、暗号化されたデータを参照することはできない。

■シークレットの暗号化

Azure Key Vault
https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview

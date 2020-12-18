# ストレージアカウントのデータ保護

- Azure Blob Storage
  - [バージョン管理](https://docs.microsoft.com/ja-jp/azure/storage/blobs/versioning-overview)
  - 論理削除 - [BLOB](https://docs.microsoft.com/ja-jp/azure/storage/blobs/soft-delete-blob-overview)、[コンテナー](https://docs.microsoft.com/ja-jp/azure/storage/blobs/soft-delete-container-overview?tabs=powershell)
  - [スナップショット](https://docs.microsoft.com/ja-jp/azure/storage/blobs/snapshots-overview)
  - [変更フィード](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-change-feed?tabs=azure-portal) - 変更のトランザクションログ
  - [ポイントインタイム リストア](https://docs.microsoft.com/ja-jp/azure/storage/blobs/point-in-time-restore-overview)
  - [オブジェクト レプリケーション](https://docs.microsoft.com/ja-jp/azure/storage/blobs/object-replication-overview) - ソース ストレージ アカウントと宛先アカウントの間でブロック BLOB を非同期にコピー
- Azure Files
  - バックアップ - Azure Backupを使用
  - スナップショット
- Azure Table Storage - [Azure Data Factoryを使用してコピー](https://docs.microsoft.com/ja-jp/azure/data-factory/connector-azure-table-storage)
- Azure Queue Storage - ???

※[ストレージアカウントの冗長化](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-redundancy) - LRS, ZRS, GRS, GZRS, RA-GRS, RA-GZRS

※[ストレージアカウントをまるごとバックアップする手段はない](https://www.it-swarm-ja.tech/ja/azure/azure%E3%83%86%E3%83%BC%E3%83%96%E3%83%AB%E3%81%A8blob%E3%82%92%E3%83%90%E3%83%83%E3%82%AF%E3%82%A2%E3%83%83%E3%83%97%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95/823562837/)。

# Azure Backup

Azure Backup サービスは、データをバックアップ・回復するための、シンプルで安全かつコスト効率の高いソリューションを提供します。

[製品ページ](https://azure.microsoft.com/ja-jp/services/backup/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/backup/backup-overview)


Azure BackupのバックアップデータはRecovery Servicesコンテナーに格納される。

※Azure Backupは、Azureの各リソースに組み込まれたバックアップ機能全般を指している。Azure Backupそのもののリソースというものは特にない。


バックアップできるもの:

- Azure上
  - Azure VM
    - [VM全体のバックアップ](https://docs.microsoft.com/ja-jp/azure/backup/quick-backup-vm-portal) - バックアップ拡張機能([Windows](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/vmsnapshot-windows)/[Linux](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/vmsnapshot-linux))を使用。アプリ整合性([Windows](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-vms-introduction#backup-process)/[Linux](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-linux-app-consistent))
    - ファイル・フォルダ - [MARSエージェント](https://docs.microsoft.com/ja-jp/azure/backup/backup-architecture#architecture-direct-backup-of-on-premises-windows-server-machines-or-azure-vm-files-or-folders)を使用。Windowsのみ
  - [Azure Files共有](https://docs.microsoft.com/ja-jp/azure/backup/azure-file-share-backup-overview)
  - [Azure VM内のSQL Server](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-sql-database)
  - [Azure VM内のSAP HANAデータベース](https://docs.microsoft.com/ja-jp/azure/backup/sap-hana-db-about)
  - [Azure Database for PostgreSQLサーバー](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-database-postgresql)
- オンプレミス
  - ファイル・フォルダ - [MARSエージェント](https://docs.microsoft.com/ja-jp/azure/backup/backup-architecture#architecture-direct-backup-of-on-premises-windows-server-machines-or-azure-vm-files-or-folders)を使用。Windowsのみ
  - [VM、ワークロード（SQL Server、Exchange、SharePoint）](https://docs.microsoft.com/ja-jp/azure/backup/backup-mabs-protection-matrix) - [Azure Backup Server(MABS)](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-microsoft-azure-backup)または[DPM](https://docs.microsoft.com/ja-jp/system-center/dpm/dpm-overview?view=sc-dpm-2019)を使用してバックアップし、それを[MARSエージェント](https://docs.microsoft.com/ja-jp/azure/backup/)でRecovery Servicesコンテナーに転送。

※MARS = Microsoft Azure Recovery Service、MABS = Microsoft Azure Backup Server

# Azure Site Recovery

VMを継続的に別リージョンにレプリケーション。フェイルオーバーやフェイルバックを実行可能。

Disaster Recovery as a Service (DRaaS)

[製品ページ](https://azure.microsoft.com/ja-jp/services/site-recovery/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-overview)


# Recovery Servicesコンテナー

Recovery Services コンテナーは、データを格納する Azure のストレージ エンティティです。

（製品ページなし）

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-recovery-services-vault-overview)

表記ゆれの注意：ドキュメント上「資格情報コンテナー」と記載される場合がある。英語では「Recovery Services vault」。

機能:

- 冗長構成 - 「ローカル冗長」と「geo冗長」から選択。[「ゾーン冗長」がプレビュー中。](https://azure.microsoft.com/ja-jp/updates/preview-of-zonal-redundant-storage-for-backup-data-from-azure-backup/)
- [論理削除](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-security-feature-cloud) - 削除されたデータを14日間保持。コストは発生しない。
- [暗号化](https://docs.microsoft.com/ja-jp/azure/backup/backup-encryption)

[Recovery Servicesコンテナーそのものを削除の際の注意](https://docs.microsoft.com/ja-jp/azure/backup/backup-vault-overview#before-you-start):

- 保護されたデータ ソース (PostgreSQL サーバーの Azure データベースなど) が格納されているコンテナーは削除できません。
- バックアップ データが含まれるコンテナーを削除することはできません。
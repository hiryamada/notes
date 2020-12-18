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


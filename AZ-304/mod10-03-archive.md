# Azure StorSimple (注: 2022/12 提供終了予定)

オンプレミスのデバイスと Azure クラウド ストレージの間のストレージ タスクを管理する統合ストレージ ソリューション

製品ページ
https://azure.microsoft.com/ja-jp/services/storsimple/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/storsimple/

■歴史

2012/10/16 MicrosoftがStorSimple社を買収
https://news.microsoft.com/2012/10/16/microsoft-reaches-agreement-to-acquire-storsimple/

2016/3/2 Microsoft Azure StorSimple Virtual Array (仮想アレイ) 一般提供開始. Hyper-V または VMware ハイパーバイザーで実行でき、ネットワーク接続ストレージ (NAS) またはストレージ エリア ネットワーク (SAN) 構成のいずれかをサポートする VM を使用してハイブリッド クラウド ストレージを提供
https://docs.microsoft.com/en-us/archive/blogs/cis/microsoft-announces-general-availability-for-the-microsoft-azure-storsimple-virtual-array

2016/6/2 StorSimpleがBlob Storageをサポート
https://azure.microsoft.com/en-us/blog/storsimple-supports-cool-blob-storage/


2019/7/9 StorSimple 5000/7000シリーズ 提供終了

2022/12 StorSimple 1200/8000シリーズ / StorSimple Virtual Array /StorSimple Data Manager 提供終了。Azure File SyncまたはAzure Data Boxへの移行が推奨されている。

■わかりやすいスライド
https://www.slideshare.net/MicrosoftAzure_Japan/s11-stor-simple


# Azure Blob Storage

「クール」または「アーカイブ」アクセス層を使用して、頻繁にアクセスされない、大量のファイルを、低コストで保存することができる。

# Azure Backup


2015/3/26 Azure Backup 一般提供開始 https://azure.microsoft.com/en-us/updates/general-availability-azure-backup/

2021/3/2 バックアップセンター 一般提供開始 https://azure.microsoft.com/en-us/updates/backup-center-is-now-generally-available/


■バックアップのためのサービス

|名称|概要|
|-|-|
|Azure Backup|Azureやオンプレミスのデータをバックアップおよび復元するための機能を提供。|
|バックアップ センター|バックアップを大規模に管理、監視、操作、分析するための機能を提供。|

Azure Backupを利用する前に、「コンテナー」を作成する。

■バックアップの「コンテナー」

Azure Backupによって作成されたバックアップデータ（バックアップの種類によっては、バックアップデータのメタデータ）は、「コンテナー」に格納される。

コンテナーは、Azureのリソースとして作成する。


|コンテナーの種類|概要|サポートされるデータソース|
|-|-|-|
|Recovery Servicesコンテナー（Recovery Services vault）|バックアップ データを格納する ストレージ エンティティ|Azure VM、Azure VM の SQL、Azure Files、Azure VM の SAP HANA、Azure Backup Server、Azure Backup エージェント、DPM|
|バックアップ コンテナー（Backup vault）|いくつかの新しいデータソースをサポートする ストレージ エンティティ|Azure Database for PostgreSQL サーバー、Azure Blob Storage、Azure ディスク|

■バックアップアイテムと復旧ポイント

あるリソースのバックアップが設定されると、コンテナー内に「バックアップアイテム」が作成される。

リソースのバックアップが実行されると、「復旧ポイント」が作成される。

たとえば、1日1回バックアップを実行するように設定すると、「復旧ポイント」が毎日作られていく。

```
vm1                      vm2
↓                        ↓
Recovery Servicesコンテナー
└vm1バックアップアイテム   └vm2バックアップアイテム
  ├復旧ポイント            ├復旧ポイント
  ├復旧ポイント            ├復旧ポイント
  └復旧ポイント            └復旧ポイント
```

■バックアップ ポリシー

各リソースのバックアップに関する設定は「バックアップポリシー」で定義される。

VMのバックアップポリシーの例:

- デフォルトで「DefaultPolicy」というバックアップ ポリシーが作成される
  - スケジュール: 毎日、午後10時（世界共通時）にバックアップを実行
  - 復旧ポイントの保有期限: 30日

■実際の例

[まとめPDF](../AZ-104/pdf/mod10/データ保護とバックアップ.pdf)



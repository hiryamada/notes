# [Azure File Sync](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-sync-files-planning)

Azure File Sync は、オンプレミスの Windows Server またはクラウド VM に多数の Azure ファイル共有をキャッシュできるサービスです。

Azure ファイル共有が Azure File Sync で使用されている場合は、主に Windows Server キャッシュを介してファイルにアクセスすることをお勧めします。これは、現在 Azure Files には Windows Server のような効率的な変更検出メカニズムがないため、Azure ファイル共有に直接加えた変更がサーバー エンドポイントに反映されるまでに時間がかかるためです。

- Azure ファイル共有

- サーバー エンドポイント - Windows Server上のパス

- 同期グループ:クラウド エンドポイント - Azure ファイル共有と、サーバーエンドポイント間の同期関係を定する。

[方法](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-sync-files-deployment-guide?tabs=azure-portal)
- ストレージ アカウント内にファイル共有を作成する
- 「+リソースの作成」から、Azure File Sync をデプロイする
  - 作成後、リソースには「ストレージ同期サービス」からアクセスできる
- 同期グループを作成する。
- クラウド エンドポイントを作り、ファイル共有を指定する。
- Windows Server に Azure File Sync エージェントをインストールする
- 「サーバー登録UI」で、Azureにサインインし、ストレージ同期サービスを選択する
- 同期グループで、サーバーエンドポイントを選択する。サーバーと、サーバー上のパスを指定する。
- サーバーのパス上にファイルを配置すると、ファイルがファイル共有に同期される。



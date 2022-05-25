知識チェック

# ラーニングパス 3: [AZ-104:Azure でのストレージの実装と管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-storage/)
## モジュール 1: [ストレージ アカウントの構成](https://docs.microsoft.com/ja-jp/learn/modules/configure-storage-accounts/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-storage-accounts/8-knowledge-check)
  - 問題1 GRS/RA-GRS（読み取りアクセスGeo冗長ストレージ、正解）では、プライマリリージョンに3箇所、セカンダリリージョンに3箇所、計6箇所にデータをレプリケーションする。
  - 問題2 ストレージアカウントの名前はグローバルで一意である必要がある（エンドポイントのFQDNの先頭部分になるため）。
  - 問題3 最も低コストなのはLRS（ローカル冗長ストレージ）。
## モジュール 2: [BLOB ストレージを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-blob-storage/)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-blob-storage/9-knowledge-check)
  - 問題1/問題2 「ホット」「クール」「アーカイブ」のアクセス層はいつでも変更できる。（アーカイブから他の層への変更には時間がかかる）
  - 問題3 [Blobのスナップショット](https://docs.microsoft.com/ja-jp/azure/storage/blobs/snapshots-overview)は、[レプリケーションされない](https://docs.microsoft.com/ja-jp/azure/storage/blobs/object-replication-overview#snapshots)。
## モジュール 3: [ストレージ セキュリティを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-storage-security/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-storage-security/8-knowledge-check)
  - 問題1 アクセスポリシーを作り、有効期限を指定する。そのアクセスポリシーを使用するSASを作成し、必要なユーザーに配布する。アクセスポリシーの期限は後から変更することができ、変更はSASに反映される。
  - 問題2 デフォルトでは、ストレージアカウントに、どのネットワークからでも接続できる。（実際にストレージにアクセスするためにはネットワーク要件に加えて適切な認証・認可も必要）
  - 問題3 ストレージアカウントのアクセスキーを持っていれば、そのストレージアカウントのすべてのデータにフルアクセスできる。
## モジュール 4: [Azure Files と Azure File Sync を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-files-file-sync/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-files-file-sync/8-knowledge-check)
  - 問題1 Azure File Syncの「[クラウドを使った階層化](https://docs.microsoft.com/ja-jp/azure/storage/file-sync/file-sync-cloud-tiering-overview)」により、アクセス頻度の高いファイルはローカルに、アクセス頻度の低いファイルはAzure Filesに格納することができる。
  - 問題2 Azure File Sync により、低帯域幅のネットワークでも、効率的にファイルの更新と同期が処理される。[使用するネットワーク帯域幅の上限値を設定できる](https://docs.microsoft.com/ja-jp/azure/storage/file-sync/file-sync-server-registration#set-azure-file-sync-network-limits)。
  - 問題3 ローカルのWindows Serverに、[Azure File Sync エージェント](https://docs.microsoft.com/ja-jp/azure/storage/file-sync/file-sync-release-notes)をインストールする。Azure File Sync エージェントが、ローカルとAzure Files間のレプリケーションを実行する。
## モジュール 5: [ツールを使用したストレージの構成](https://docs.microsoft.com/ja-jp/learn/modules/configure-storage-tools/)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-storage-tools/5-knowledge-check)
  - 問題1 Azureストレージエクスプローラーは、GUI（グラフィカルユーザーインターフェース）のツールであり、ファイルのアップロードやダウンロードなどのストレージアカウントの操作が可能。
  - 問題2/問題3 ストレージアカウント間の大量のデータの移動では、GUIのツールではなく、CUI（キャラクターユーザーインターフェース）の[AzCopy](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-v10)コマンドを使用するのが適切。
## モジュール 6: [Azure Storage アカウントの作成](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-storage-account/)
- ユニット 6: [知識チェック - ストレージ アカウントを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-storage-account/6-knowledge-check)
  - 問題1 2つのストレージアカウント（GRSとLRS）を使用する。「ビジネスに不可欠なビデオ」はGRS（Geo冗長ストレージ）に格納する。「その他の重要ではないビデオ」はLRS（ローカル冗長ストレージ）に格納する。
  - 問題2 ストレージアカウントの名前はグローバルで一意である必要がある（エンドポイントのFQDNの先頭部分になるため）。
  - 問題3 ストレージアカウントはプロジェクトの初期段階で作り、そのままそのプロジェクトで使用する。
## モジュール 7: [Shared Access Signature を使用して Azure Storage へのアクセスを制御する](https://docs.microsoft.com/ja-jp/learn/modules/control-access-to-azure-storage-with-sas/)
- ユニット 2: [Azure Storage の承認オプション](https://docs.microsoft.com/ja-jp/learn/modules/control-access-to-azure-storage-with-sas/2-authorization-options-azure-storage)
  - ※ページ下部に知識チェックあり
  - 問題1 ※この問題は「Azure Active Directory を使用する。 Azure AD を使用すると、サービス プリンシパルを作成してアプリを認証できます。」が正解となっているが、サービスプリンシパルを作る必要はないと思われる。「認証にはAzure AD認証を使用し、承認にはRBACロールを使用する。」が適切な文章と思われる。
  - 問題2 BlobコンテナーをPublicアクセス可能に設定する。
## モジュール 8: [Azure Storage Explorer を使用してデータをアップロード、ダウンロード、管理する](https://docs.microsoft.com/ja-jp/learn/modules/upload-download-and-manage-data-with-azure-storage-explorer/)
- ※知識チェックなし


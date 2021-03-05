# [Azure Blob Storage](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction)

クラウド用オブジェクト ストレージ ソリューションです。

テキスト データやバイナリ データなどの大量の非構造化データを格納するために最適化されています。

非構造化データとは、特定のデータ モデルや定義に従っていないデータであり、テキスト データやバイナリ データなどがあります。

Azure Filesの中に「コンテナー」を作り、「Blob」をアップロードします。

※Blobは[バイナリ・ラージ・オブジェクト](https://ja.wikipedia.org/wiki/%E3%83%90%E3%82%A4%E3%83%8A%E3%83%AA%E3%83%BB%E3%83%A9%E3%83%BC%E3%82%B8%E3%83%BB%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88)の略です。

※ [日本語版のドキュメント](https://docs.microsoft.com/ja-jp/rest/api/storageservices/understanding-block-blobs--append-blobs--and-page-blobs)では「BLOB」と「Blob」が混在しているようです。[英語版のドキュメント](https://docs.microsoft.com/en-us/rest/api/storageservices/understanding-block-blobs--append-blobs--and-page-blobs)では、文中では小文字で「blob」、製品名の一部や記事のタイトルとしては「Blob」と表記されるようです。

# Microsoft Learn

[リージョン間でストレージ データをレプリケートし、セカンダリ ロケーションにフェールオーバーすることで、ディザスター リカバリーを実現する](https://docs.microsoft.com/ja-jp/learn/modules/provide-disaster-recovery-replicate-storage-data/)

# オブジェクトレプリケーション

https://docs.microsoft.com/ja-jp/azure/storage/blobs/object-replication-overview

オブジェクト レプリケーションを使用すると、ソース ストレージ アカウントと宛先アカウントの間でブロック BLOB を非同期にコピーできます。

# Blobの種類

- ブロックBlob(Block blobs) - テキストとバイナリ。Blob1個あたりの最大サイズは4.75TiB（最大サイズ200TBが[プレビュー](https://azure.microsoft.com/ja-jp/blog/run-high-scale-workloads-on-blob-storage-with-new-200-tb-object-sizes/)）。
- 追加Blob(Append blobs) - ログ記録などの追加操作に最適化されている。
- ページBlob(Page blobs) - VHDファイルの格納用。（マネージドではない）ディスクとして利用。


# ストレージアカウントあたりの最大容量

[5 PiB](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-files-scale-targets)

# [リース](https://docs.microsoft.com/ja-jp/azure/storage/blobs/concurrency-manage?tabs=dotnet#pessimistic-concurrency-for-blobs)

BLOB をロックして排他的に使用する場合は、リースを取得します。 リースを取得するときは、リース期間を指定します。 有限リースは、15 - 60 秒の範囲で有効な場合があります。 リース期間は無限の場合もあり、その場合は排他ロックになります。 リース期間が有限の場合、延長することができます。また、完了したリースは解放できます。 期限が切れた有限のリースは、Azure Storage によって自動的に解放されます。

コンテナーのリースでは、排他的書き込みと共有読み取り、排他的書き込みと排他的読み取り、共有書き込みと排他的読み取りなど、BLOB でサポートされるのと同じ同期戦略がサポートされます。 ただし、コンテナーの場合、排他的ロックは削除操作にのみ適用されます。 アクティブなリースを使用してコンテナーを削除するには、クライアントが削除要求に有効なリース ID を含める必要があります。 他のコンテナー操作については、リース ID なしでも、リースされたコンテナーで成功します。

[Blob](https://azure.microsoft.com/en-us/updates/support-for-blob-storage-lease-management-from-azure-portal/)

[コンテナー](https://docs.microsoft.com/ja-jp/rest/api/storageservices/lease-container)

https://qiita.com/dz_/items/54476d1d39966bd5556d

# REST APIにおけるパラメータ



restype - account / service / container 等

comp - properties / list / [tier](https://docs.microsoft.com/ja-jp/rest/api/storageservices/set-blob-tier) / [batch](https://docs.microsoft.com/ja-jp/rest/api/storageservices/blob-batch) / stats / metadata / query 等

# ホット層 - 可用性 99.99%

ホット アクセス層は、クール層とアーカイブ層に比べてストレージ コストが高くなるものの、アクセス コストが最も低くなります。 

# クール層 - 可用性 99.9%

クール アクセス層は、ホット ストレージに比べてストレージ コストが低くなり、アクセス コストが高くなります。 

この層は、少なくとも 30 日以上保持されるデータを対象としています。

バックアップデータ等

# アーカイブ層 - 可用性なし（オフライン）

アーカイブ アクセス層では、ストレージ コストは最も低くなります。 しかし、ホット層やクール層と比べて、データ取得コストは高くなります。 

データは、少なくとも 180 日間保持される必要があります。

[製品ページ](https://azure.microsoft.com/ja-jp/services/storage/archive/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-storage-tiers?tabs=azure-portal#archive-access-tier)


BLOB がアーカイブ ストレージ内にある間、BLOB データはオフラインであり、読み取り、上書き、または変更を行うことはできません。

アーカイブ内の BLOB を読み取るかダウンロードするには、最初にそれをオンライン層にリハイドレートする必要があります。

アーカイブ アクセス層のデータの取得には、リハイドレートの優先度によっては、数時間かかることがあります。

アーカイブ ストレージ内の BLOB のスナップショットを作成することはできません。 

BLOB メタデータはオンラインのままで使用でき、BLOB、そのプロパティ、メタデータ、および BLOB インデックス タグを一覧表示できます。 

アーカイブ中の BLOB メタデータの設定または変更は許可されていません。ただし、BLOB インデックス タグは設定および変更できます。

アーカイブ層は、ZRS、GZRS、RA-GZRS アカウントでは現在サポートされていません。

# [Blobインデックスタグ](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-index-how-to?tabs=azure-portal)


キーと値のタグ属性を使用して、BLOB インデックス タグによってストレージ アカウント内のデータが分類されます。 これらのタグには自動的にインデックスが付けられ、検索可能な多次元インデックスとして公開されるため、データを簡単に見つけることができます。

# Geo冗長ストレージ


**読み取り要求**は、プライマリ ストレージに問題がある場合にセカンダリ ストレージにリダイレクトすることができます。

LocationMode を PrimaryThenSecondary に設定した場合、再試行可能なエラーによってプライマリ エンドポイントへの最初の**読み取り要求**が失敗すると、クライアントが自動的にセカンダリ エンドポイントへの読み取り要求を行います。 

https://docs.microsoft.com/ja-jp/azure/storage/common/geo-redundant-design#read-requests

Blob

https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.blob.blobrequestoptions.locationmode?view=azure-dotnet-legacy

# GPv1とGPv2の違い

GPv1: ホット・クール・アーカイブ利用不可、LRS/GRS/RA-GRSのみ（ゾーン非対応）、リソースマネージャに加えてクラシックデプロイに対応。


# 汎用と、FileStorage / BlockBlobStorageの選択

汎用 v2 および汎用 V1 アカウント用の Premium パフォーマンスは、ディスクとページ BLOB でのみ使用できます。

ブロックまたは BLOB の追加用の Premium パフォーマンスは、BlockBlobStorage アカウントでのみ使用できます。

ファイル用の Premium パフォーマンスは、FileStorage アカウントでのみ使用できます。


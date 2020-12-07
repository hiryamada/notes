# [Azure Blob Storage](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction)

クラウド用オブジェクト ストレージ ソリューションです。

テキスト データやバイナリ データなどの大量の非構造化データを格納するために最適化されています。

非構造化データとは、特定のデータ モデルや定義に従っていないデータであり、テキスト データやバイナリ データなどがあります。

Azure Filesの中に「コンテナー」を作り、「Blob」をアップロードします。

※Blobは[バイナリ・ラージ・オブジェクト](https://ja.wikipedia.org/wiki/%E3%83%90%E3%82%A4%E3%83%8A%E3%83%AA%E3%83%BB%E3%83%A9%E3%83%BC%E3%82%B8%E3%83%BB%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88)の略です。

※ [日本語版のドキュメント](https://docs.microsoft.com/ja-jp/rest/api/storageservices/understanding-block-blobs--append-blobs--and-page-blobs)では「BLOB」と「Blob」が混在しているようです。[英語版のドキュメント](https://docs.microsoft.com/en-us/rest/api/storageservices/understanding-block-blobs--append-blobs--and-page-blobs)では、文中では小文字で「blob」、製品名の一部や記事のタイトルとしては「Blob」と表記されるようです。



# Blobの種類

- ブロックBlob(Block blobs) - テキストとバイナリ。Blob1個あたりの最大サイズは4.75TiB（最大サイズ200TBが[プレビュー](https://azure.microsoft.com/ja-jp/blog/run-high-scale-workloads-on-blob-storage-with-new-200-tb-object-sizes/)）。
- 追加Blob(Append blobs) - ログ記録などの追加操作に最適化されている。
- ページBlob(Page blobs) - VHDファイルの格納用。（マネージドではない）ディスクとして利用。


# ストレージアカウントあたりの最大容量

[5 PiB](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-files-scale-targets)
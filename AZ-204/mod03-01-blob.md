# Azure Blob Storage

https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction


- オブジェクトストレージ
- 「非構造化データ」の格納に最適化
  - テキスト、バイナリ、画像、動画など、どのような形式でもOK。
  - ※非構造化＝特定のデータ モデルや定義に従っていないデータ
  - ※構造化＝リレーショナルDBのような表形式データ
  - ※半構造化＝JSONやXMLのようなデータ
- HTTPSでデータを読み書きする（REST API）

■構造

```
ストレージアカウント
 └Blobコンテナー
  └ Blob
```

■Blobの種類

https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-pageblob-overview?tabs=dotnet

- ブロックBlob
  - ブロックで構成
  - テキストまたはバイナリ ファイルの格納に最適
  - 大きいファイルの効率的なアップロードに最適
- 追加Blob
  - ブロックで構成
  - 追加操作用に最適化されている
  - ログ記録のシナリオに最適
- ページBlob
  - 512 バイトの「ページ」で構成
  - 頻繁なランダムの読み取り/書き込み操作のために設計
  - ホット アクセス層のみ

■冗長性

[まとめPDF](../AZ-104/pdf/mod07/ストレージ冗長化.pdf)

■アクセス層

ホット、クール、アーカイブ

[まとめPDF](../AZ-104/pdf/mod07/アクセス層.pdf)

■ライフサイクル

[まとめPDF](../AZ-104/pdf/mod07/ライフサイクルルール.pdf)

■Azure SDKについて

https://azure.microsoft.com/ja-jp/downloads/

各種のプログラミング言語・プラットフォームから、Azureのリソースを操作したり、データを操作したりすることができるライブラリ。

SDK＝Software Development Kit

- 言語
  - .NET
  - Java
  - JavaScript/TypeScript
  - Python
  - Go
  - C++
  - C
  - PHP
  - Ruby
- モバイルプラットフォーム
  - iOS
  - Android

最新のリリース状況等
https://azure.github.io/azure-sdk/releases/latest/index.html

ページ内で「blob」等で検索すると、BlobのNuGetパッケージの配布場所や、ドキュメントにジャンプすることができる。

GitHubのAzure ADKのリポジトリ
https://github.com/azure/azure-sdk


■Azureドキュメント

Azureドキュメント内に、SDKを使用した基本的なプログラミングの解説がある。

- 「クイックスタート」
  - SDKを使用した基本的な操作についてのドキュメント。
  - まずはこちらで入門。
  - [.NET SDKの「クイックスタート」](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-dotnet)
- 「サンプル」
  - 追加のサンプルコード
  - [.NET SDKの「サンプル」](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-dotnet)


■Blob Storage SDKの「クライアント」クラス

3種類の「クライアント」クラスがある。基本的にはこれらを使用する。

```
ストレージアカウント ... BlobServiceClient
└コンテナー ........... BlobContainerClient
  └Blob .............. BlobClient
```

※参考: BlobClientによる操作では、ブロックBlobが作成される。より細かいコントロールを行うための[BlockBlobClient](https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.blockblobclient?view=azure-dotnet), [AppendBlobClient](https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.appendblobclient?view=azure-dotnet), [PageBlobClient](https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.specialized.pageblobclient?view=azure-dotnet) なども用意されている。

各クラスのオブジェクトを作り、そのメソッドを呼び出すことで、コンテナーの作成やBlobのアップロードなどの操作を行うことができる。


例: コンテナーの作成: BlobContainerClientクラスのCreateIfNotExistsメソッド

```
var bcc = new BlobContainerClient("(接続文字列)", "(コンテナー名)");
bcc.CreateIfNotExists();
```

各クラスのリファレンスマニュアル

- [BlobServiceClient](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.blobs.blobserviceclient?view=azure-dotnet)
- [BlobContainerClient](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.blobs.blobcontainerclient?view=azure-dotnet)
- [BlobClient](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.blobs.blobclient?view=azure-dotnet)

■山田サンプルコード

- コンテナーの作成・削除・一覧表示
- Blobのアップロード・ダウンロード・一覧表示

[サンプル](../AZ-204/sample/blob/Program.cs)

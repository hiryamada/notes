# Azure Blob Storage

https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction

[★ストレージアカウント解説PDF](../AZ-104-2023/pdf/ストレージアカウント.pdf)

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
  - 内部的には1つ～複数の「ブロック」（データの塊）で構成される
  - 1つのBlobには最大50,000ブロックを含めることができる。
  - 1ブロックのサイズは 最大で4,000 MB。
  - 1つのブロック BLOB の最大サイズは約 190.73 TiB (4,000 MB X 50,000 ブロック)
  - テキストまたはバイナリ ファイルの格納に最適
  - 大きいファイルの効率的なアップロードに最適
- 追加Blob
  - ブロックで構成
  - 追加操作用に最適化されている（既存Blobの末尾に新しいBlockを高速に追加できる）
  - ログ記録のシナリオに最適
  - [登場時のブログに詳しい解説がある](https://satonaoki.wordpress.com/2015/04/15/azure-storage-append-blob/)
- ページBlob
  - 512 バイトの「ページ」で構成
  - 頻繁なランダムの読み取り/書き込み操作のために設計
  - ホット アクセス層のみ
  - VMの仮想ディスク(VHD形式)、SQLデータベース、ビデオ編集アプリなどで使用される
  - [詳しい解説](https://learn.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-pageblob-overview)

※通常、プログラムからストレージアカウントのBlobのアップロード・ダウンロード・削除等の操作を行う場合 `BlobClient`を使用する。`BlobClient`を使用してBlobを作成した場合は「ブロックBlob」となる。

```
BlobBaseClient ... 親クラス。共通メソッドを実装。
├BlobClient ... Blob単位での操作が可能。通常はこれを利用
├BlockBlobClient ... Block単位の操作が可能
├AppendBlobClient ... Blockの追加などの操作が可能
└PageBlobClient ... Page単位の操作が可能
```

■冗長性

<!--
[まとめPDF](../AZ-104/pdf/mod07/ストレージ冗長化.pdf)
-->
[まとめPDF(ストレージアカウント)](../AZ-104-2023/pdf/%E3%82%B9%E3%83%88%E3%83%AC%E3%83%BC%E3%82%B8%E3%82%A2%E3%82%AB%E3%82%A6%E3%83%B3%E3%83%88.pdf)

■アクセス層

Blobそれぞれに「アクセス層」を設定可。Blobアップロード時に特に層を指定しない場合は、ストレージアカウントに設定されたデフォルトの層の設定（ホットまたはクール）が使用される。

ホット、クール、コールド、アーカイブの4種類がある。

ストレージ料金は、ホット＞クール＞コールド＞アーカイブ となる。大量のデータを格納する際、コスト削減が必要であれば、ホット層以外の層の利用を検討する。

ただし、読み取りコストは、ホット（コストなし）＜クール＜コールドとなる。大量に読み取りを行う際はホットの利用を検討する。

アーカイブ層のBlobを読み取る際は、事前にホット・クール・コールドへの層変更（リハイドレーション）が必要。

<!--
[まとめPDF](../AZ-104/pdf/mod07/アクセス層.pdf)
-->

[まとめPDF(Blobのアクセス層と料金)](../AZ-104-2023/pdf/Azure%20Blob%20Storage%E3%81%AE%E6%96%99%E9%87%91.pdf)

■ライフサイクル

Blobのアクセス層を自動的に変更する機能。

たとえば保存されてから30日経過したホット層のBlobを自動的にクール層に変更する、といった設定ができる。

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
  - PHP (2021年 [リタイア](https://github.com/Azure/azure-sdk-for-php))
  - Ruby (2021年 [リタイア](https://github.com/Azure/azure-sdk-for-ruby/blob/master/docs/README.md))
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

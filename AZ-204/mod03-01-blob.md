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

■Blobの操作（SDK）

各種言語用の「クライアントSDK」を使用して、プログラムから読み書きが可能

[サンプル](../AZ-204/sample/blob/Program.cs)

■ラボ3


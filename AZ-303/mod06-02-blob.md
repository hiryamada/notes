# Azure Blob Storage

https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction


- オブジェクトストレージ
- 「非構造化データ」の格納に最適化
  - テキスト、バイナリ、画像、動画など、どのような形式でもOK。
  - ※非構造化＝特定のデータ モデルや定義に従っていないデータ
  - ※構造化＝リレーショナルDBのような表形式データ
  - ※半構造化＝JSONやXMLのようなデータ
- HTTPSでデータを読み書きする（REST API）
- 各種言語用の「クライアントSDK」を使用して、プログラムから読み書きが可能
  - [サンプル](../AZ-204/sample/blob/Program.cs)

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

■静的Webサイトのホスティング

■ログの記録

(1)Azure Storage Analytics ログ

- Blob, Table, Queueのログを取る
- [記録される操作やステータスメッセージの一覧](https://docs.microsoft.com/ja-jp/rest/api/storageservices/storage-analytics-logged-operations-and-status-messages)
  - 例: BlobのPUT（アップロード）、GET（ダウンロード）など。
- $logs という名前の BLOB コンテナーに保存される

(2)Azure Monitor の Azure Storage ログ

https://docs.microsoft.com/ja-jp/azure/storage/blobs/monitor-blob-storage

2020/9 パブリック プレビュー https://azure.microsoft.com/ja-jp/updates/azure-resource-logs-for-azure-storage-is-now-in-public-preview/

- Blob, Files, Table, Queueのログを取る
- ストレージアカウントに対するリクエストの成功・失敗といった詳細なログを記録することができる
- 「診断設定」で設定した場所にログが送信される
  - Log Analyticsワークスペース
  - Blob Storage
  - Event Grid
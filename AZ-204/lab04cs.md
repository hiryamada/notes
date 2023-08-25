# ラボ 04: Cosmos DB ストレージを使用するソリューションの開発


## ラボ環境の利用方法

→ [ラボ環境の利用方法](lab00cs.md)

## 動画

ラボの実施手順を記録した動画です。音声はありません。

AZ-204 ラボ04 Cosmos DB ストレージを使用するソリューションの開発
https://youtu.be/PcN5ewcMLJE

## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-204-DevelopingSolutionsforMicrosoftAzure.ja-jp/Instructions/Labs/AZ-204_lab_04.html

英語版:
https://microsoftlearning.github.io/AZ-204-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_04.html

## 解説


■用語

- モデル: Cosmos DBの項目（1件1件のModel/Product）を表すC#クラス
- コンテキスト: Cosmos DBへの接続と操作を表すC#インターフェース / C#クラス

■リソース

- Cosmos DB
- ストレージアカウント

■データのモデル

```
Model
└Products
```

例

```
ツーリングバイク
└バイク（青）

タイヤチューブ
└マウンテンタイヤ
```

■4つのプロジェクト

- Upload: Cosmos DBに項目を書き込む
- Models: モデル
- Context: コンテキスト
- Web: エンドユーザー向けWebアプリ

■4つのプロジェクトの依存関係

```
Upload
```

```
Models
↑  ↑
↑  Web
↑  ↓
Context
```

■演習1 リソースの準備

- タスク1 EdgeでAzure portalを開く
- タスク2 
  - Cosmos DBアカウントを作成
  - polycosmos123456 / サーバーレス
  - URI、プライマリキー、プライマリ接続文字列をコピー
- タスク3 
  - ストレージアカウントを作成 polystor

■演習2 Cosmos DBにデータを入れる

- タスク1
  - ストレージアカウントにBlobコンテナーを作成 images
  - 42個のJPEG画像ファイル(自転車用品)をアップロード
- タスク2
  - models.json(画像のカテゴリー、説明文などが記載されている)を確認
- タスク3
  - AdventureWorks.Uploadプロジェクトを実行
  - models.jsonのデータを読み取る
  - Cosmos DBのRetailデータベースのOnlineコンテナー
  - CreateItemでアイテム作成
- タスク4
  - Cosmos DBのデータエクスプローラーでデータを確認
  - SELECT * FROM models

■演習3 Webアプリを作成

- タスク1
  - appsettings.json 設定ファイルに以下を設定
    - Cosmos DBの接続文字列
    - BlobコンテナーのURL
- タスク2
  - AdventureWorks.Context プロジェクト
    - AdventureWorksCosmosContext.cs を作成
    - Task<Model> FindModelAsync(Guid id)
    - Task<List<Model>> GetModelsAsync()
    - Task<Product> FindProductAsync(Guid id)
- タスク3
  - AdventureWorks.Web プロジェクト
    - コンテキストをDIコンテナーに追加
  - Webアプリを実行して動作確認

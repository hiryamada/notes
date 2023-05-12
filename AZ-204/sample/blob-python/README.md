# 画像アップローダー サンプル

- Python
- [Flask](https://msiz07-flask-docs-ja.readthedocs.io/ja/latest/)
- Azure Blob Storage
- Azure Virtual Machine (Windows Server)

開発ツールとしてPyCharmを使用

■リソース

```
ストレージアカウント
└Blobコンテナー images
 └Blob（画像ファイル）

VM (マネージドID)
└Pythonアプリ
```

- VMのマネージドIDに「ストレージBlob共同作成者」を割り当てる
  - Blobの一覧の取得、Blobのアップロードに必要
- Blobコンテナーのアクセス権を「Blob」に設定
  - Webブラウザーが匿名でBlob（画像ファイル）を直接アクセスし表示できる

■ライブラリ

- azure-identity
- azure-storage-blobs
- Flask

■アプリのファイル構成

- main.py
- templates/
  - index.html
  - upload.html

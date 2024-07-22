# Azure AI Search


## 参考サイト

https://www.slideshare.net/slideshow/azure-search-114345418/114345418

https://qiita.com/nohanaga


## 構成要素

- データソース
  - データ ソース コネクタ
    - Azure AI Searchのコネクタ
    - サード パーティーのコネクタ
- インデクサー indexer
  - スキルセット
  - スキル
- 検索インデックス search index
  - インデックススキーマ index schema
    - フィールド fields
    - データタイプ data type
    - フィールド属性 field attributes
- 検索エンジン search engine
- クエリ queries
- フィルター
- セマンティックランキング
- ベクトル検索

## パイプライン（インデックス化のプロセス）

Azure AI Searchにおけるパイプラインは、データの取り込み、変換、インデックス化のプロセスを指す。

具体的には、データソースからデータを抽出し、それを検索可能な形式に変換し、最終的に検索インデックスに格納する一連のステップを包む。

このプロセスは以下のようなステージに分けられる。

- データソースの接続:
  - データソースと接続し、インデックス化するデータを取得する。
  - データソースの例：Azure Blob Storage、Azure SQL Database、Azure Cosmos DBなど
- ドキュメントクラッキング:
  - データソースから取得したデータを解析し、テキストやメタデータを抽出する。
  - ファイルの場合、PDFや画像ファイルからテキストや画像を抽出することも含む。
- フィールドマッピング:
  - データソースのフィールド（列や属性）を検索インデックスのフィールドにマッピングする。
  - これにより、データが正しいフィールドに格納される。
- スキルセットの実行（オプション）:
  - AIエンリッチメントを行う。
  - 例えば、テキストの翻訳、キーフレーズの抽出、画像認識などを行う。
- 出力フィールドマッピング:
  - スキルセットの出力を検索インデックスのフィールドにマッピングする。
  - これは、変換されたデータや追加されたメタデータが正しくインデックスに格納されるようにするために必要。
- インデックスへの格納:
  - 最終的に、変換されたデータを検索インデックスに格納します。

この一連のプロセスをパイプラインと呼ぶ。

パイプラインは、インデックスの作成とデータの更新を効率的に行うための自動化されたフレームワーク。

スケジュール設定を行うことで、定期的なデータ更新を自動化することができる。

Azure AI Searchのパイプラインを利用することで、データの取り込みから検索可能な形式への変換、そしてインデックスへの格納までを一貫して行うことができ、検索機能の精度と効率を大幅に向上させることが可能となる。



## Microsoft Learnの Azure AI Search関連ラーニングパス
Microsoft Azure AI Fundamentals: Document Intelligence and Knowledge Mining

https://learn.microsoft.com/en-us/training/paths/document-intelligence-knowledge-mining/


Implement knowledge mining with Azure AI Search

https://learn.microsoft.com/en-us/training/paths/implement-knowledge-mining-azure-cognitive-search/

参考: Microsoft Search fundamentals

https://learn.microsoft.com/en-us/training/paths/microsoft-search-fundamentals/

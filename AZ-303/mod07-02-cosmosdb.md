# Azure Cosmos DB

- フルマネージドのNoSQLデータベース
- 1桁ミリ秒の応答時間
- グローバル分散
- 5種類の整合性
- 5種類のAPI
- [組み込みのバックアップ機能](https://docs.microsoft.com/ja-jp/azure/cosmos-db/online-backup-and-restore)
- [デフォルトで暗号化](https://docs.microsoft.com/ja-jp/azure/cosmos-db/database-encryption-at-rest)
- パブリックエンドポイントとプライベートエンドポイントが利用できる

■Cosmos DBアカウント

- Cosmos DBを使用する際は「Cosmos DBアカウント」を作成する
- APIを指定する
- 容量モード
  - プロビジョニングされたスループット
    - データベースやコンテナーにRU（後述）を指定
    - リージョンを追加できる
    - [Synapse Link](https://docs.microsoft.com/ja-jp/azure/cosmos-db/synapse-link)(データ分析機能)を有効化できる
    - ストレージ容量に制限がない
    - 1桁ミリ秒のレイテンシ
  - Serverless
    - RUの指定が不要
    - 1リージョンでのみ実行可能（リージョン追加不可）
    - [Synapse Link](https://docs.microsoft.com/ja-jp/azure/cosmos-db/synapse-link)を有効化できない
    - 最大50GBのデータを格納
    - ポイント読み取り 10 ミリ秒以下、書き込み 30 ミリ秒以下
- Freeレベル割引の適用
  - サブスクリプションで1つまで
  - 最初の1000 RU/s、25 GB ストレージが無料

■リクエストユニット（RU）

https://docs.microsoft.com/ja-jp/azure/cosmos-db/request-units

- Cosmos DBにおける操作のコストを表す
- 1 KB の項目をポイント読み取りする（IDとパーティションキーを指定して1項目を読み取る）コストは1RU
- その他の操作も同様にRUを使ってコストが割り当てされる
- 操作によって消費されたRUは、各操作のレスポンスで確認できる

■グローバル分散

https://docs.microsoft.com/ja-jp/azure/cosmos-db/distribute-data-globally

- Cosmos DBアカウントに関連付けられている全リージョンに対し、透過的にデータをレプリケート
- リージョンはいつでも追加できる
- 複数リージョンへの書き込みもサポート（マルチマスター）

■整合性

https://docs.microsoft.com/ja-jp/azure/cosmos-db/consistency-levels

整合性(強い順に):

- 厳密/強固 (Strong)
- 有界整合性制約 (Bounded staleness)
- セッション (Session): デフォルト
- 整合性/一貫性のあるプレフィックス (Consistent prefix)
- 最終的 (Eventual)

パフォーマンスへの影響:
- 強い整合性ほど、パフォーマンスは出にくくなる。
- 弱い整合性ほど、パフォーマンスが出る。

■5つのAPI

Cosmos DBアカウントを作成する際に指定する

- [Core (SQL) API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/choose-api#coresql-api)
  - デフォルト(ネイティブ)のAPI
  - ドキュメント（JSON）を操作
  - SQLに似た言語を使用してクエリを実行できる
- [Cassandra API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/cassandra/cassandra-introduction)
  - [Apache Cassandra](https://cassandra.apache.org/_/index.html)の[Cassandra Query Language(CQL)](https://cassandra.apache.org/doc/latest/cassandra/cql/index.html)をサポート
  - Cassandraを使用する既存のアプリケーションの移行に利用できる
- [MongoDB API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/mongodb/mongodb-introduction)
  - [MongoDBワイヤプロトコル](https://docs.mongodb.com/manual/reference/mongodb-wire-protocol/)をサポート
  - MongoDBを使用する既存のアプリケーションの移行に利用できる
- [Gremlin API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/graph/graph-introduction)
  - [Apache TinkerPop](https://tinkerpop.apache.org/)のGremlin言語をサポート
  - グラフ データベース
- Table API
  - Azure Table StorageのAPIと互換性がある

■高可用性

- [最大で 99.999% SLA の可用性を提供](https://azure.microsoft.com/ja-jp/support/legal/sla/cosmos-db/v1_4/)

■構造（SQL API）

[まとめPDF](../AZ-204/pdf/mod04/Cosmos%20DBの構造.pdf)

```
Cosmos DBアカウント
└データベース
  └コンテナー
   └項目
```

アイテム（項目）の構造:
```
アイテム
├id
├パーティションキー
└その他のプロパティ
```

※コンテナーの作成時にパーティションキーのパスを指定する

■例

- データ エクスプローラーを選択
- データベース、コンテナーを作成
- 項目を4つ追加（下記の`{`～`}`をコピーして貼り付け）

```
Cosmos DBアカウント 
└データベース musicdb
  └コンテナー music (パーティションキー: /artist )
    ├項目 { "artist": "YOASOBI", "id": "夜に駆ける", "lyrics": "沈むように..." }
    ├項目 { "artist": "YOASOBI", "id": "ハルジオン", "lyrics": "過ぎてゆく..." }
    ├項目 { "artist": "LISA", "id": "炎", "lyrics": "「さよなら」..."}
    └項目 { "artist": "LISA", "id": "紅蓮華", "lyrics": "強くなれる..."}
```

■パーティション分割

https://docs.microsoft.com/ja-jp/azure/cosmos-db/partitioning-overview

- 論理パーティション
  - 項目は、いずれかの論理パーティションに属する
  - パーティションキーの値に基づいて形成される
  - 1つの物理パーティションに格納される
    - 項目のパーティション キーの値をハッシュ化
    - ハッシュの結果で、物理パーティションが決定
- 物理パーティション
  - 複数の論理パーティションで構成される
  - 一連の「レプリカ」（「レプリカ セット」とも）で構成される
  - 少なくとも4つのレプリカが保持される

https://docs.microsoft.com/ja-jp/azure/cosmos-db/global-dist-under-the-hood

- 各コンピューターは、数百のレプリカをホストする
- レプリカは多数のコンピューターに動的に配置され、負荷分散される
- レプリカは、10～20の障害ドメインに分散される


■Azure Cosmos DB Capacity Calculator

※旧: Azure Cosmos DB Capacity Planner

https://cosmos.azure.com/capacitycalculator/

SQL API の使用時における、ワークロードに必要な RU/秒とコストの見積もりを取得するツール。

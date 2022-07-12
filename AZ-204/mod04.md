# Azure Cosmos DB

製品ページ
https://azure.microsoft.com/ja-jp/services/cosmos-db/

価格
https://azure.microsoft.com/ja-jp/pricing/details/cosmos-db/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/cosmos-db/

特設ページ
https://gotcosmos.com/

■歴史

2015/4/8 Azure DocumentDB 一般提供開始 https://azure.microsoft.com/ja-jp/blog/nosql-database-service-azure-documentdb-now-generally-available/

完全マネージドのNoSQL データベース サービス、JSONを読み書き、SQLでクエリ可能。

JSONデータの例:
```
[
  {
    id: 1,
    name: "taro"
  },
  {
    id: 2,
    name: "jiro",
    age: 20
  },
]
```


2017/5/10 Azure Cosmos DB 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-cosmos-db-microsofts-globally-distributed-multi-model-database-service/

2018/3/12 データエクスプローラー 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-cosmos-db-data-explorer-ga-2/

2018/9/24 Cassandra APIサポート 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-cosmos-db-cassandra-api-now-generally-available/

2020/3/6 Freeレベル(Free Tier) 提供開始 https://devblogs.microsoft.com/cosmosdb/build-apps-for-free-with-azure-cosmos-db-free-tier/

2020/8/12 [ChaosDB脆弱性 発見と修正](chaosdb.md)

2021/5/25 Cosmos DB serverless 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-cosmos-db-serverless-now-in-general-availability/


■Cosmos DBとは？

NoSQLデータベース。

1桁ミリ秒の読み書き性能。

データをグローバルに分散（レプリケーション）可能。マルチマスターの読み書きも可能。

5種類のAPIをサポート。Cosmos DBアカウントを作成する際に選択する。

- SQL (Core) API - ネイティブのAPI. SELECT文でクエリを実行できる。
- Table API - ストレージアカウントのTable APIと互換
- MongoDB API - MongoDB互換
- Gremlin API - Apache Tinkerpop互換
- Cassandra API - Apache Cassandra互換

各種言語用のクライアントライブラリ（SDK）を使用して、プログラムからデータを読み書きする。

■料金

https://docs.microsoft.com/ja-jp/azure/cosmos-db/understand-your-bill

- プロビジョニング済みのRU（※）
- ストレージ(GB単位)

※サーバーレスのアカウントの場合は、実際に使用された「要求ユニット（RU）」

■Freeレベルについて

https://docs.microsoft.com/ja-jp/azure/cosmos-db/free-tier

- 開発・テスト用
- サブスクリプションにつき Free レベルの Azure Cosmos DB アカウントは 1 つまで
- アカウントでの最初の 1000 RU/秒と 25 GB のストレージが無料
  - それを超えると有料

■リソースの構造

```
Cosmos DBアカウント
└データベース
 └コンテナー(テーブルに相当)
  └項目(行に相当)
```

- データベースおよびコンテナー容量は無制限。
- 1項目は最大2MBまで（JSON表現のUTF-8の長さ）。
- 1論理パーティションあたり最大20GBまで。

参考:[Cosmos DBの制限](https://docs.microsoft.com/ja-jp/azure/cosmos-db/concepts-limits)

■Cosmos DBは「グローバル分散データベース」

- リージョンをいつでも追加・削除することができ、その間、可用性は低下しない
- データはリージョン間で透過的にレプリケート（複製）される
- マルチリージョン書き込み: 有効/無効
  - 無効: 1つのリージョンで読み書き可能、その他のリージョンで読み込み可能
  - 有効: すべてのリージョンで読み書き可能

複数書き込みリージョンの有効化の設定
https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-manage-database-account#configure-multiple-write-regions

新しいリージョンがアカウントに追加された場合、クライアント側では、アプリケーションの更新や再デプロイを行う必要はない。近接するリージョンが自動的に検出されるように設定することが可能。
https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-multi-master


■高可用性

最大で99.999% のSLAを提供。

SLA
https://azure.microsoft.com/ja-jp/support/legal/sla/cosmos-db/v1_4/

■Cosmos DBの「レイテンシ」(待機時間)

https://docs.microsoft.com/ja-jp/azure/cosmos-db/consistency-levels#consistency-levels-and-latency

すべての「整合性レベル」において、以下の性能が常に保証される。

- 書き込み/読み込み待機時間: 99 パーセンタイルで 10 ミリ秒未満

※マルチリージョンかつ厳密な整合性の場合を除く。

※99パーセンタイル: 100個の測定値を、短い順で並び替えた場合の、99番目の値。

例: 100回の書き込みを行い、待機時間の短い順に並べた場合

```
1: 1 ms
2: 1 ms
3: 2 ms
4: 2 ms
5: 2 ms
...
98: 9 ms
99: 9 ms    ← 99 パーセンタイルで10ミリ秒未満
100: 10 ms
```

■ハンズオン: Cosmos DBアカウントを作成しよう

- Azure portalで`Cosmos DB`と検索
- +作成
- コア(SQL)の作成
  - リソースグループ: 適当に指定
  - アカウント名: 適当に指定
  - 場所（リージョン）: 米国東部 (East US)
  - 容量モード: 「プロビジョニングされたスループット」
  - Freeレベル割引の適用：適用しない
  - このアカウントでプロビジョニングできるスループットの総量を制限する: チェックしない
  - その他はすべてデフォルト値
  - レビュー+作成、作成
- デプロイに5分ほどかかります
- たまに、デプロイに失敗してしまう場合があります。
  - エラーメッセージを確認し、それに従って、作成をやりなおしてください。
  - デプロイに失敗してもアカウントができてしまう場合もあるので、それは削除してください
  - リージョンを変更すると成功する場合があります

■整合性レベル（とりあえずここまで覚えればOK）

Cosmos DBでは、5種類の「整合性レベル」を指定できる。

- 整合性レベルが「強い」場合、最新のデータを読み取ることができるが、よりコストもかかり、パフォーマンスは落ちる。
- 整合性レベルが「弱い」場合、最新のデータを読み取ることができない可能性があるが、よりコストが抑えられ、パフォーマンスは上がる。

強い方から順に、

- 厳密
- 有界整合性
- セッション
- 一貫性のあるプレフィックス
- 最終的

読み取り整合性は、論理パーティション内をスコープとする 1 つの読み取り操作に適用される。

※論理パーティション＝パーティションキーの値が同じである項目の集まり。

Cosmos DBアカウントに対し、デフォルトで適用される整合性は「セッション」。

「セッション」整合性は、多くの現実のシナリオに最適。Cosmos DBで推奨されるオプション。

Cosmos DBに対する各リクエストでも、整合性レベルを指定できる。アカウントレベルのデフォルト値から「弱い」整合性レベルへとオーバーライドできる。

[より詳しい解説](cosmos-db-consistency.md)

■ハンズオン: 規定の整合性を確認しよう

- 作成したCosmos DBアカウントをクリック
- 左側メニューで「規定の整合性」（「設定」セクション内）をクリック
- 5種類の整合性を選択して、画面に表示される音符のイメージを確認
- （保存はしない）

■要求ユニット（Request Unit, RU）

Cosmos DBに対する操作コストを表す。
1KBのアイテムを1つ読み取るコストが1RU。

たとえば、Cosmos DBから1秒間に1KBのアイテムを10個読み取るには、10RU/秒の割り当てが必要。

その他の操作でもそれぞれRUが消費される。

消費したRUは、Cosmos DBから返されるレスポンスのヘッダで確認できる。

データベース、または、コンテナーのレベルで、RUの割り当てができる。

[参考資料](pdf/mod04/RU.pdf)

(単一リージョン書き込みアカウント, 米国東部)100 RU/秒: 654.08円/月


■モード

|-|プロビジョニング スループット|サーバーレス|
|-|-|-|
|コンテナーあたりの最大 RU/秒|1,000,000※|5,000|
|コンテナーあたりの最大ストレージ|無制限|50 GB|
|リージョンの最大数|制限なし|1|

※専用スループット プロビジョニング モードにおけるの既定値。サポートに申請してさらに上げることができます。


■料金の例

米国東部リージョンのみを使用し、プロビジョニングスループットモードで、コンテナーで設定可能な最小のRU（手動の場合400RU、自動の場合400RU～4000RU）を設定した場合。また、サーバーレスモードで400RU/秒を継続的に使用した場合。

- プロビジョニングスループットモード（手動）: 約 $23/月 (400RU * $0.008 * 730時間)
- プロビジョニングスループットモード（自動）: 約 $35～$350/月 (400RU * 1.5 * $0.008 * 730時間)
- サーバーレスモード: 約 $262/月 （400RU * 730時間 * 60分 * 60秒 / 1,000,000 * $0.25）

■Cosmos DBのストレージ

1GBあたり 28円/月

データベースやコンテナーの容量は無制限。論理パーティションあたりの最大容量は20GB。

■リソース/データ構造

[参考資料](pdf/mod04/Cosmos%20DBの構造.pdf)

```
Cosmos DBアカウント
└ データベース
  └ コンテナー ... 表に相当
    └ 項目 ... 行に相当
      └ プロパティ ... 列に相当
```


■ハンズオン: コンテナーと項目を作ってみよう

- データ エクスプローラーを選択
- データベース、コンテナーを作成
- 項目を4つ追加（下記の`{`～`}`をコピーして貼り付け）

```
Cosmos DBアカウント 
└データベース musicdb
  └コンテナー music (パーティションキー: /artist )
    ├項目 { "artist": "YOASOBI", "id": "夜に駆ける", "lyrics": "沈むように..." }
    ├項目 { "artist": "YOASOBI", "id": "ハルジオン", "lyrics": "過ぎてゆく..." }
    ├項目 { "artist": "LiSA", "id": "炎", "lyrics": "「さよなら」..."}
    └項目 { "artist": "LiSA", "id": "紅蓮華", "lyrics": "強くなれる..."}
```

上記の例の場合、2つの論理パーティション(YOASOBIとLiSA)が作られることになる。

■パーティションキー

コンテナーを作成する際に指定する必要がある。

パーティションキーの値によって論理パーティションが形成される。

たとえば以下のような項目が記録されるとする。

```
{
	"id": "111",
	"name": "Taro Yamada",
	"age": "33",
	"address": {
		"prefecture": "Tokyo",
		"city": "Shinagawa"
	}
}
```

この場合、パーティションキー（のパス）として以下のようなものを指定できる。

- /id
- /name
- /age
- /address/prefecture
- /address/city

パーティションキーの選択は、アプリケーションのパフォーマンスに影響する。

■項目ID

論理パーティションの中で項目を区別する値。

1つの論理パーティションの中で一意でなければならない。

■パーティションの分割

※P=パーティション

論理P: 同じパーティションキーを持つ項目の集まり。1つの論理Pは1つの物理Pに対応。

物理P: 論理Pを格納する物理的な領域。複数の論理Pを格納。

https://docs.microsoft.com/ja-jp/azure/cosmos-db/partitioning-overview

■パーティションキーの選択

パーティションキーの選択が良くないと、特定の物理Pにアクセスが集中してしまう。

データと、アクセスパターンが、多数の論理Pに均等に分散されるようなパーティションキーを選択する。

■合成パーティション

[参考資料](pdf/mod04/パーティションキーの作成.pdf)

■学習に役立つリソース

Microsoft Learn: サーバーレス アプリケーションの作成
https://docs.microsoft.com/ja-jp/learn/paths/work-with-nosql-data-in-azure-cosmos-db/

Azure Cosmos DB Workshop
https://azurecosmosdb.github.io/labs/

■ラボ4: Cosmos DBをC#コードから操作してみよう

[ラボ4のご案内](lab/lab04.md)


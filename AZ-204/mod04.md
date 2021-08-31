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

2017/5/10 Azure Cosmos DB 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-cosmos-db-microsofts-globally-distributed-multi-model-database-service/

2018/3/12 データエクスプローラー 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-cosmos-db-data-explorer-ga-2/

2018/9/24 Cassandra APIサポート 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-cosmos-db-cassandra-api-now-generally-available/

2020/3/6 Freeレベル(Free Tier) 提供開始 https://devblogs.microsoft.com/cosmosdb/build-apps-for-free-with-azure-cosmos-db-free-tier/


2021/5/25 Cosmos DB serverless 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-cosmos-db-serverless-now-in-general-availability/

■ChaosDB脆弱性(2020/8/12)

概要:

- Cosmos DBに統合されている「Jupyter Notebook」を悪用して、別の顧客が所有するCosmos DBアカウントのプライマリーキーを取得できるという脆弱性(ChaosDB)が発見された。
- プライマリキーにより、Cosmos DBアカウントに対する完全なアクセス権が得られる。
- この脆弱性は[Wiz](https://www.wiz.io)の研究者が発見し、8月9日に脆弱性の影響を確認し、8月12日にマイクロソフトに報告した。
- マイクロソフトでは、報告を受けてから48時間以内に、脆弱性を修正した。
- 影響を受ける顧客にはマイクロソフトから対策方法を連絡済み。
- 技術的な詳細については今後発表予定。

ソース:

- https://www.wiz.io/blog/protecting-your-environment-from-chaosdb
- https://msrc-blog.microsoft.com/2021/08/27/update-on-vulnerability-in-the-azure-cosmos-db-jupyter-notebook-feature/

■Cosmos DBとは？

NoSQLデータベース。

1桁ミリ秒の読み書き性能。

データをグローバルに分散（レプリケーション）可能。マルチマスターの読み書きも可能。

5種類のAPIをサポート。Cosmos DBアカウントを作成する際に選択する。

- SQL API - ネイティブのAPI. SELECT文でクエリを実行できる。
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

すべての「整合性レベル」において、以下の性能が常に保証される。

- 書き込み/読み込み待機時間: 99 パーセンタイルで 10 ミリ秒未満

※マルチリージョンかつ厳密な整合性の場合を除く。

※99パーセンタイル: 100個の測定値を、短い順で並び替えた場合の、99番目の値。

■ハンズオン: Cosmos DBアカウントを作成しよう

- Azure portalで`Cosmos DB`と検索
- +作成
- コア(SQL)の作成
  - リソースグループ: 適当に指定
  - アカウント名: 適当に指定
  - 場所（リージョン）: 米国東部 (East US)
  - 容量モード: 「プロビジョニングされたスループット」
  - Freeレベル割引の適用：適用しない
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

「セッション」整合性は、多くの現実のシナリオに最適であり、Cosmos DBで推奨されるオプションでもある。

Cosmos DBに対する各リクエストでも、整合性レベルを指定できる。アカウントレベルのデフォルト値から「弱い」整合性レベルへとオーバーライドできる。

■整合性レベル（もう少し詳しく. より正確な情報はドキュメントを参照のこと）

- 厳密(Strong, 強固、強力): 常に最新のデータが読み込まれる。最も「強い」整合性。
- 有界整合性(Bounded Staleness): K個前、または、T秒前の、古いバージョンのデータが読み込まれる可能性がある
  - ※単一リージョンの場合 K, T の最小値 = 10回, 5秒。 
  - ※複数リージョンの場合 K, T の最小値 = 100,000回, 300秒。
- セッション整合性(Session): 
  - 単一のクライアント セッション内の読み取りでは以下が保証される。
    - 整合性のあるプレフィックス(consistent-prefix): 読み取りの際、書き込みを順序どおりに参照することを保証。（書き込んだ順に読み込まれる）
    - 単調読み取り(monotonic reads): あるプロセスが、データ項目xの値を連続して読み取る場合、常に、同じ値か、より新しい値を返す。（読み込みが先祖返りしない）
    - 単調書き込み(monotonic writes): あるプロセスによる、データ項目Xに対する書き込み操作は、そのプロセスによる、データ項目Xに対する後続の書き込み操作の前に完了する。（書き込みは発生順に行われる）
    - 自己書き込みの読み取り(read-your-writes): あるプロセスによる、データ項目Xに対して書き込まれた値は、そのプロセスによる後続の読み取り操作で常に使用可能。（自分の書いた値を読み取れる）
    - 読み取り後の書き込み(Writes-follows-reads): 更新は、それ以前の読み込みの実行の後に行われる。
  - セッション外のクライアント:
    - 複数の書き込みリージョンを持つアカウントに対して、複数のリージョンに書き込みを行うクライアントの整合性: 最終的
    - その他: 整合性のあるプレフィックス
- 整合性(一貫性)のあるプレフィックス(Consistent Prefix): 読み取りの際、書き込みを順序どおりに参照することが保証される。
- 最終的(Eventual): 読み取り順序の保証はない。最も「弱い」整合性。

例: 2つのリージョンからなる、マルチリージョン書き込みが無効のCosmos DBアカウントにおいて、あるクライアントが x=1;x=2;x=3;x=4;x=5;x=6;x=7; といったように書き込みした場合、別のクライアントがxの値を読み取ると:

- 厳密: どのリージョンでも最新の値を読み取る
- 有界整合性: 同じリージョンでは最新の値を読み取る。別のリージョンでは、xの読み込みを繰り返すと、 1, 2, 3, 4, 5のような書き込み順で読み込まれる。その際の遅延は一定範囲内となる。
- セッション: 書き込みクライアントと同じ「セッショントークン」を持つクライアントは最新の値を読み取る。セッションの外のクライアントは、xの読み込みを繰り返すと、 1, 2, 3, 4, 5のような書き込み順で読み込まれる。
- 一貫性のあるプレフィックス: どのリージョンでも、xの読み込みを繰り返すと、 1, 2, 3, 4, 5のような書き込み順で読み込まれる。
- 最終的: どのリージョンでも、xの値の読み込みを繰り返すと, 1, 3, 2, 5, 4 のように、読み込まれる値が書き込み順にならない場合がある。時間が経つと、収束して、最新の値を読み取ることができるようになる。

整合性:
https://docs.microsoft.com/ja-jp/azure/cosmos-db/consistency-levels#consistency-levels-and-latency

セッショントークンは、CreateDocumentなどのオペレーションによって生成され、レスポンスヘッダーで返される。
https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-manage-consistency#utilize-session-tokens

セッショントークンはクライアント側で生成することはできない。
https://stackoverflow.com/questions/64084499/can-i-use-a-client-constructed-session-token-for-cosmosdb

整合性の用語などの参考:
- https://www.youtube.com/watch?v=t1--kZjrG-o
- https://parveensingh.com/cosmosdb-consistency-levels/#session
- https://en.wikipedia.org/wiki/Consistency_model

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

1つのサブスクリプションには1つまで「Freeレベル」のCosmos DBアカウントを作成できる。

Freeレベル
https://docs.microsoft.com/ja-jp/azure/cosmos-db/free-tier


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
    ├項目 { "artist": "LISA", "id": "炎", "lyrics": "「さよなら」..."}
    └項目 { "artist": "LISA", "id": "紅蓮華", "lyrics": "強くなれる..."}
```

上記の例の場合、artistをパーティションキーとしているため、2つの論理パーティションが作られることになる。

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
- /a
- /b
- /c/d
- /c/e

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


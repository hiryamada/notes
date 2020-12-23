Azure Cosmos DB


[製品ページ](https://azure.microsoft.com/ja-jp/services/cosmos-db/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/cosmos-db/introduction)

[登場時のブログ](https://azure.microsoft.com/ja-jp/blog/azure-cosmos-db-microsofts-globally-distributed-multi-model-database-service/)


[NoSQL（Wikipedia）](https://ja.wikipedia.org/wiki/NoSQL)

[Cosmos DB (Wikipedia, 英語)](https://en.wikipedia.org/wiki/Cosmos_DB)

[Cosmos DBのSLA](https://azure.microsoft.com/ja-jp/support/legal/sla/cosmos-db/v1_3/)

[Cosmos DBを無料で試す](https://azure.microsoft.com/ja-jp/try/cosmosdb/)

[Azure Cosmos DB自習書](http://download.microsoft.com/download/6/1/6/6166D6C1-0AC3-4869-840D-53BCC85319DB/self-study_Azure_Cosmos_DB_introduction.pdf)

Microsoft Learn
- [Azure Cosmos DB の NoSQL データを扱う](https://docs.microsoft.com/ja-jp/learn/paths/work-with-nosql-data-in-azure-cosmos-db/)
- [Azure でのデータ プラットフォームの設計](https://docs.microsoft.com/ja-jp/learn/paths/architect-data-platform/)
- [地理的に分散したアプリケーションを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-a-geographically-distributed-application/)
- [Cassandra と MongoDB のワークロードを Cosmos DB に移行する](https://docs.microsoft.com/ja-jp/learn/paths/migrate-cassandra-mongo-db-workloads-to-cosmos-db/)
- [Visual Studio Code で Azure Cosmos DB 用の Node.js アプリを構築する](https://docs.microsoft.com/ja-jp/learn/modules/build-node-cosmos-app-vscode/)
- [Azure Cosmos DB 用の Java アプリをビルドする](https://docs.microsoft.com/ja-jp/learn/modules/build-cosmos-db-java-app/)
- [Azure のデータベースおよび分析サービスについて調べる](https://docs.microsoft.com/ja-jp/learn/modules/azure-database-fundamentals/)
- [IoT ソリューション用のラムダ アーキテクチャの実装の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-lambda-architecture-iot-solutions/)
- [Azure データの基礎:Azure でのリレーショナル以外のデータの検証](https://docs.microsoft.com/ja-jp/learn/paths/azure-data-fundamentals-explore-non-relational-data/)
- [Azure Functions を使用してサーバーレス API をビルドする](https://docs.microsoft.com/ja-jp/learn/modules/build-api-azure-functions/)
- [Azure Storage Explorer を使用してデータをアップロード、ダウンロード、管理する](https://docs.microsoft.com/ja-jp/learn/modules/upload-download-and-manage-data-with-azure-storage-explorer/)
- [入力バインディングと出力バインディングを使用して Azure Functions を連結する](https://docs.microsoft.com/ja-jp/learn/modules/chain-azure-functions-data-using-bindings/)

[試験 70-777: Implementing Microsoft Azure Cosmos DB Solutions](https://docs.microsoft.com/ja-jp/learn/certifications/exams/70-777)



[NoSQLの「Azure Cosmos DB」は惑星規模のアプリでも使えるデータベース （CodeZine）](https://codezine.jp/article/detail/10719?p=2)

[［速報］マイクロソフトがグローバル規模の分散NoSQLデータベース「Azure Cosmos DB」発表。数ミリ秒のレイテンシ保証、一貫性の強さを選択。Build 2017 (Publickey)](https://www.publickey1.jp/blog/17/nosqlazure_cosmos_dbbuild_2017.html)


[Cosmos DBエミュレータ](https://docs.microsoft.com/ja-jp/azure/cosmos-db/local-emulator?tabs=cli%2Cssl-netstd21)

https://cosmos.azure.com/

[無料で試す](https://azure.microsoft.com/ja-jp/try/cosmosdb/)

# 歴史

[2015 年 4 月より、Azure DocumentDB の一般提供を開始](https://xtech.nikkei.com/it/atclncf/service/00019/051500002/)。DocumentDBの紹介ビデオ[1](https://azure.microsoft.com/ja-jp/resources/videos/documentdb-general-availability-and-whats-new/), [2](https://azure.microsoft.com/ja-jp/resources/videos/introduction-to-azure-documentdb/)。

2017 年 5 月に開催された Build 2017 にて「Azure Cosmos DB」 発表。Azure DocumentDB がサポートしている JSON ドキュメント データベースに、キー/バリュー ストアとグラフ データベースを追加。

[これまで、分散NoSQLデータベースサービス「DocumentDB」として提供されていたものは、Cosmos DB分散データベース基盤上で構築され、今後DocumentDBはCosmos DBに統合され、選択肢の1つとして提供されます。](https://ascii.jp/elem/000/001/486/1486643/)

# [データのグローバル分散](https://docs.microsoft.com/ja-jp/azure/cosmos-db/distribute-data-globally)

グローバル分散型のアプリケーションでは、グローバルに分散されたデータベースが必要です。

Cosmos DB では、Cosmos アカウントに関連付けられている全リージョンに対して透過的にデータがレプリケートされます。 

いつでも、数回のクリックまたはプログラムの 1 回の API 呼び出しで、Cosmos データベースに関連付けられた地理的リージョンを追加または削除できます。（ターンキー マルチマスター データ分散）

データベース用に選択したすべてのリージョンに対し、アプリケーションでほぼリアルタイムの読み取りと書き込みを実行できます。

アプリケーションからは、読み取りと書き込みをローカルに実行することができます。


複数リージョンのデータベースを対象にした読み取りと書き込みに関して、Azure Cosmos DB は 99.999% の可用性を備えています。

# 構造

Cosmos DB アカウント＞データベース＞コンテナー＞項目(アイテム)

コンテナーには、ストアド プロシージャ、トリガー、ユーザー定義関数 (UDF)、マージ プロシージャを登録できます。

|-|コンテナー|項目（アイテム）|
|-|-|-|
|SQL API|コンテナー|項目（アイテム）|
|Cassandra API|テーブル|行|
|MongoDB API|コレクション|ドキュメント|
|Gremlin API|グラフ|ノード または エッジ|
|テーブルAPI|テーブル|項目（アイテム）|

# データベースの作成

アカウント＞データ エクスプローラー＞New Database

データベースIDを指定

データベースに対してRUを指定する（400～100,000、入力必須）

# コンテナーの作成

アカウント＞データ エクスプローラー＞New Container

コンテナーIDを指定

インデックスを作成するかどうかを指定。「クエリ」を行なわず、常にキー・バリュー操作を行うなら「OFF」

パーティションキーを指定（入力必須）。/address/ZipCodeなど。「type」などと入力しても先頭に「/」が補われて「/type」となる。

パーティションキーが100byteを超える場合はチェック。[2019/5/3以前のコンテナーではパーティションキーの最初の100byteでハッシュ値を計算していた。現在は最大約2KBのパーティションキーがサポートされる。](https://docs.microsoft.com/ja-jp/azure/cosmos-db/large-partition-keys?tabs=dotnetv3)

コンテナーに専用のプロビジョニングスループットを指定するなら、チェックを入れて数値を入力（400～100,000、チェックした場合は入力必須）

ユニークキー: 「/a,/b」のように入力。

# [コンテナーに対する操作](https://docs.microsoft.com/ja-jp/azure/cosmos-db/account-databases-containers-items#operations-on-an-azure-cosmos-container)

Azure CLI、SQL API、Cassandra API、MongoDB用Azure Cosmos DB APIでは、データベース内のコンテナーの列挙、コンテナーの読み取り、新しいコンテナーの作成、コンテナーの更新、コンテナーの削除ができます。

Gremlin API、テーブルAPIでは、これらの操作は行えません。

# [項目に対する操作](https://docs.microsoft.com/ja-jp/azure/cosmos-db/account-databases-containers-items#operations-on-items)

全てのAPIで、項目の挿入、置換、削除、アップサート、読み取りがサポートされます。

# [パーティショニング](https://docs.microsoft.com/ja-jp/azure/cosmos-db/partitioning-overview)

例: 各項目の UserID プロパティには一意の値があります。 UserID がそのコンテナー内の項目のパーティション キーであり、1,000 個の一意の UserID 値がある場合、1,000 個の論理パーティションがそのコンテナー内に作成されます。

項目の論理パーティションを決めるパーティション キーに加えて、コンテナー内の各項目には " 項目 ID " (論理パーティション内で一意) があります。

パーティション キーと 項目 ID を組み合わせて、項目の インデックス が作成されます。

インデックスによって、項目が一意に識別されます。 

パーティション キーを選択することは、アプリケーションのパフォーマンスに影響する重要な決定事項です。


# パーティションキー
パーティション キーには、 パーティション キーのパス と パーティション キーの値 の 2 つのコンポーネントがあります。 

- キーのパスの例: /userId
- キーの値の例: Andrew

キーのパスは入れ子になったオブジェクトを使用することができます。

キーの値には文字列型または数値型を使用できます。

キーを選択すると、変更することはできません。

キーの値を変更することはできません。



# パーティション

論理パーティション: 
- 同じパーティション キーを持つ一連のアイテムで構成されます。 
- 各論理パーティションには、最大 20 GB のデータを格納できます。

物理パーティション: 
- 1 つまたは複数の論理パーティションが単一の物理パーティションにマップされます。
- 物理パーティションはシステムの内部実装であり、完全に Azure Cosmos DB によって管理されます。
- Azure portal の [メトリック] ブレード の [ストレージ] セクションで確認できます。

1 つの論理パーティション内のすべての項目で、パーティション キーの値は同じです。

# Cosmos DBアカウント

[クイックスタート](https://docs.microsoft.com/ja-jp/azure/cosmos-db/create-cosmosdb-resources-portal)

Azure サブスクリプションで最大 50 の Azure Cosmos アカウントを作成できます (これはサポート リクエストを通じて増加できるソフト制限です)。

1 つの Azure Cosmos アカウントで、事実上無制限のデータ量とプロビジョニング スループットを管理できます。

# Azure Cosmos データベース

アカウントの下に、1 つまたは複数の Azure Cosmos データベースを作成できます。


# API

- コア（SQL）
- [MongoDB API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/mongodb-introduction)
- [Cassandra (CQLv4)](https://docs.microsoft.com/ja-jp/azure/cosmos-db/cassandra-introduction)
- Azureテーブル（Table Storage互換）
- [Gremlin（グラフ）](https://docs.microsoft.com/ja-jp/azure/cosmos-db/graph-introduction)

API ごとに別のアカウントを作成する必要があります。


Azure Cosmos DB の Gremlin API は、[Apache TinkerPop](https://tinkerpop.apache.org/) というグラフ コンピューティング フレームワークに基づいて構築されています。 Azure Cosmos DB の Gremlin API では、Gremlin クエリ言語を使用します。

※参考
- [Apache Cassandra](https://cassandra.apache.org/) ([Wikipedia](https://ja.wikipedia.org/wiki/Apache_Cassandra))
- [MongoDB](https://www.mongodb.com/) ([Wikipedia](https://ja.wikipedia.org/wiki/MongoDB))
- [Apache TinkerPop](https://tinkerpop.apache.org/)

# データモデル

APIによってデータモデルが決まります。

コア（SQL） / MongoDB - ドキュメント

Gremlin - グラフ

Azure Table

Cassandra - キー/値

# [整合性レベル](https://docs.microsoft.com/ja-jp/azure/cosmos-db/consistency-levels)

最強から最弱の順に、次のレベルがあります。

- 厳密/強固 (Strong)
- 有界整合性制約 (Bounded staleness)
- セッション (Session)
- 整合性/一貫性のあるプレフィックス (Consistent prefix)
- 最終的 (Eventual)



5種類の整合性モデルから選択可能

書き込まれたすぐにデータを読み取れるかどうか。

待機時間をSLAで保証

強い整合性ほど、パフォーマンスは出にくくなる。弱い整合性ほど、パフォーマンスが出る。トレードオフ。


99パーセンタイル（値を小さい順に並べて99%の範囲）で、10MS以下の読み込み、15MS以下の書き込みが可能。

# Cosmos DBアカウントの作成

アカウントを作成する時点でAPI（SQL、MongoDBなど5種類）から指定。この時点で内部のデータモデルも決定される。

アカウントの作成には10分程度かかる。

# Freeレベル

https://docs.microsoft.com/ja-jp/azure/cosmos-db/optimize-dev-test#azure-cosmos-db-free-tier

Azure Cosmos DB の Free レベルを使用すると、アプリケーションの利用開始、開発、およびテストを簡単に行えるようになります。また、小規模な実稼働ワークロードを無料で実行することもできます。 

Azure サブスクリプションごとに所有できる Free レベル アカウントは 1 つまでです。また、アカウントの作成時に選択する必要があります。


アカウント上で Free レベルを有効にすると、そのアカウントでの最初の 400 RU/秒と 5 GB のストレージが無料で利用できるようになります。 

また、データベース レベルで 400 RU/秒を共有する 25 個のコンテナーを備えた 1 つの共有スループット データベースを作成し、すべて Free レベルで対応することもできます (Free レベルのアカウントでは、5 つの共有スループット データベースが上限になります)。

# 組み込みのJupyter Notebook

Notebooks・・・Jupyter Notebookをポータルから使用できる機能。
https://docs.microsoft.com/ja-jp/azure/cosmos-db/cosmosdb-jupyter-notebooks
データのビジュアライズがかんたんに実行できるようになる。

# リージョン

場所（リージョン）：プライマリーのリージョンを指定。あとから、レプリケーションするリージョンを追加できる。


# [容量モード](https://docs.microsoft.com/ja-jp/azure/cosmos-db/set-throughput)

- [プロビジョニングされたスループット](https://docs.microsoft.com/ja-jp/azure/cosmos-db/set-throughput)
  - データベースでスループットをプロビジョニング - スループットはデータベースのすべてのコンテナー (共有データベース コンテナーと呼ばれます) で共有されます。個々のコンテナーのスループットに対する SLA はありません。
  - コンテナーに対してスループットをプロビジョニング - スループットはそのコンテナー専用に予約されます。 コンテナーは、常にプロビジョニング済みスループットを受け取ります。SLA によって裏付けられます。
  - 2 つのモデルを組み合わせることができます。
- [サーバーレス（プレビュー）](https://docs.microsoft.com/ja-jp/azure/cosmos-db/serverless)
  - 消費される要求ユニットと、データによって消費されるストレージに対してのみ課金
- 自動スケーリング モード
  - このモードでは、ワークロードの可用性、待機時間、スループット、またはパフォーマンスに影響を与えずに、使用量に基づいてデータベースまたはコンテナーのスループット (RU/秒) が自動的かつ瞬時にスケーリングされます。 


# ネットワーク

選択されたネットワークのみ、プライベートエンドポイントなどを指定できる

# バックアップ
バックアップポリシーを指定して、定期的にバックアップを取得することができる。

# 暗号化
デフォルトですべて暗号化される。

暗号化に使用するキーをKey Vaultで管理することもできる。

# データベースを追加

1つのDBの中で複数のコンテナーを使用できます

アカウント＞データベース＞コンテナー＞アイテム

コンテナーは、コレクション、グラフ、テーブルなどとも呼ばれる（APIによる）

DB単位でRUを設定し、コンテナーで共有することができる。コンテナー単位で設定することもできる。

# [Request Units (RU)](https://docs.microsoft.com/ja-jp/azure/cosmos-db/request-units)

データベースに対して[RU（要求ユニット）](https://docs.microsoft.com/ja-jp/azure/cosmos-db/request-units)を指定。400～100000の値を指定可能。コストが変わってくる。

1 KB の項目をポイント読み取りする (つまり、ID とパーティション キーの値で 1 つの項目をフェッチする) コストは、1 要求ユニット (または 1 RU) です。

Azure Cosmos コンテナーの操作にどの API 使用するかに関係なく、コストは RU によって測定されます。 データベース操作が書き込み、ポイント読み取り、またはクエリのいずれの場合でも、コストは常に RU で測定されます。

Cosmos コンテナー (またはデータベース) に 'R' 個の RU をプロビジョニングする場合、Cosmos DB により、Cosmos アカウントに関連付けられている それぞれ のリージョンで 'R' 個の RU が利用可能であることが確保されます。

選択した整合性モデルもスループットに影響します。 整合性レベルが比較的緩やかな場合 (セッション、一貫性のあるプレフィックス、最終的 など)、比較的強固な場合 (有界整合性制約 や 厳密 など) と比べ、ほぼ 2 倍の読み取りスループットを得ることができます。

[Azure portal、SDKの戻り値で、使用されたRUを確認できます](https://docs.microsoft.com/ja-jp/azure/cosmos-db/find-request-unit-charge?tabs=dotnetv2)。

[Capacity Calculator](https://cosmos.azure.com/capacitycalculator/)で見積もりを行うことができます。

# コンテナーを作成

コンテナーを作成するときにパーティションキーを指定

同じパーティションキーを持つ項目が同じ「論理パーティション」に入る。

論理パーティションは物理パーティションにマッピングされる。

プロビジョニングしたRUは各物理パーティションに均等に配分される。


1つのパーティションにアクセスが集中する（ホットパーティション）にならないようにする。


サーバーレスの場合はMax 5000RUとなる。






# データエクスプローラー

データの操作ができる。

# レプリケーション

データのコピーを世界中に作れる。

？レプリケーションするメリットは？

？コストは？

# [マルチリージョン書き込み](https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-multi-master?tabs=api-async)

「有効」にすると、すべてのリージョンで書き込みも行えるようになる。

？マルチリージョン書き込みのメリットは？

# 整合性レベル

## 強固（厳密）：Strong
書き込んだデータがすぐに他のリージョンでもすぐに読み込める

※マルチリージョン書き込みでは使用できない。

## 有界整合性制約

他のリージョンでは遅れて読み取られる。順番は守られる。

遅延に関する保証値がある。

何分・何回分まで遅れてよいかを指定できる。

## セッション

デフォルト。

同じセッション内（単一クライアント内）では、最新のデータが読み取れる。

ただし別のセッションでは、最新のデータは読み取れない。

？セッションとは？

## 整合性のあるプレフィックス

順序だけは守るが、遅延の設定はない。

遅れるが、順序は守られる。

## Eventual（最終的）

遅延もするし、順序も守られない。ある程度時間が経つと、書き込まれたデータが読み取れるようになる。


？パーティションキーは複数の項目で重複していても良い？だめ？
→パーティションキーと「項目ID」で一意。同じパーティションキーのものは同じ「論理パーティション」に格納される。



# 関数 (SQL APIのみ)

- [システム関数](https://docs.microsoft.com/ja-jp/azure/cosmos-db/sql-query-system-functions)
- [集計関数](https://docs.microsoft.com/ja-jp/azure/cosmos-db/sql-query-aggregate-functions)
- [ユーザー定義関数](https://docs.microsoft.com/ja-jp/azure/cosmos-db/sql-query-udfs)

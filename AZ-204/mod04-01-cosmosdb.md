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

様々なAPIをサポート
SQL
MongoDB
Table API（Table Storage互換）
Casandra
Gremlin（グラフ）

複数のデータモデルに対応
キー・バリュー
列ファミリ
グラフ
ドキュメント（JSON）

グローバル配布
東日本で保存したデータを北米、アジア、ヨーロッパで読み込むなど。

複数リージョンにデータをレプリケーション

5種類の整合性モデルから選択可能

書き込まれたすぐにデータを読み取れるかどうか。

待機時間をSLAで保証

強い整合性ほど、パフォーマンスは出にくくなる。弱い整合性ほど、パフォーマンスが出る。トレードオフ。


99パーセンタイル（値を小さい順に並べて99%の範囲）で、10MS以下の読み込み、15MS以下の書き込みが可能。

# Cosmos DBアカウントの作成

アカウントを作成する時点でAPI（SQL、MongoDBなど5種類）から指定。この時点で内部のデータモデルも決定される。

Notebooks・・・Jupyter Notebookをポータルから使用できる機能。
https://docs.microsoft.com/ja-jp/azure/cosmos-db/cosmosdb-jupyter-notebooks
データのビジュアライズがかんたんに実行できるようになる。

場所（リージョン）：プライマリーのリージョンを指定。あとから、レプリケーションするリージョンを追加できる。


容量モード

- プロビジョニングされたスループット
  - 固定のスループットを指定。
- サーバーレス（プレビュー）
  - プロビジョニングなしで、使った分だけ課金

Freeレベル：400 RU/s と 5 GB のストレージを無料で利用することができる。サブスクリプションごとに 1 つまでのアカウントで Free レベルを有効にすることができます。

ネットワーク

選択されたネットワークのみ、プライベートエンドポイントなどを指定できる

バックアップ
バックアップポリシーを指定して、定期的にバックアップを取得することができる。

暗号化
デフォルトですべて暗号化される。

暗号化に使用するキーをKey Vaultで管理することもできる。




# データベースを追加

1つのDBの中で複数のコンテナーを使用できます

アカウント＞データベース＞コンテナー＞アイテム

コンテナーは、コレクション、グラフ、テーブルなどとも呼ばれる（APIによる）

DB単位でRUを設定し、コンテナーで共有することができる。コンテナー単位で設定することもできる。

データベースに対して[RU（要求ユニット）](https://docs.microsoft.com/ja-jp/azure/cosmos-db/request-units)を指定。400～100000の値を指定可能。コストが変わってくる。

1KBの項目を1つフェッチするコスト＝1RU



強力な有界整合性制約の整合性レベルでは、他の緩和された整合性レベルの場合と比べて、読み取り操作の実行中に約 2 倍の RU が消費されます。

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

# マルチリージョン書き込み

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



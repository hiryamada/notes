
■Azure AI Searchとは？

 (名称変更 Azure Search → Azure Cognitive Search → Azure AI Search)

さまざまな種類のデータ ソースに対するリッチな検索機能を組み込むためのインフラストラクチャ、API、およびツールを開発者に提供する、クラウド検索サービス。

ドキュメントにインデックスを付け、高度な検索を実現。

■価格レベル

- F(Free) 50 MB、最大 1 個のレプリカ、最大 1 個のパーティション、最大 1 個の検索ユニット。サブスクリプションで1つだけ利用可
- B(Basic): 2 GB、最大 3 個のレプリカ、最大 1 個のパーティション、最大 3 個の検索ユニット
- S(Standard): 25 GB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- S2(Standard 2): 100 GB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- S3(Standard 3): 200 GB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- S3HD(Standard High Density): 200 GB/パーティション*、最大 12 個のレプリカ、最大 3 個のパーティション、最大 36 個の検索ユニット
- L1(ストレージ最適化): 1 TB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- L2(ストレージ最適化): 2 TB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット


■検索インデックス search index

https://learn.microsoft.com/ja-jp/azure/search/search-what-is-an-index

大量のドキュメントに対する高速な検索ができるように、検索に必要な情報を抽出したもの。

Azure AI Searchは、検索インデックスに対して検索処理を実行する（元のデータに対する検索は行わない）。データに対してインデックスを事前に作っておく必要がある。

```
ユーザー
↓キーワード検索
Azure AI Search
└検索インデックス search index
    ↑ インデックス作成 ↓ 検索結果から移動(キー: Blobのパスなど)
   データソース: Azure Blob Storageに配置された大量のPDFなど
```

インデックスのサイズが小さいほうが、検索パフォーマンスが良くなる。


■データソース

https://learn.microsoft.com/ja-jp/azure/search/search-data-sources-gallery

- ストレージアカウント
  - Azure Blob Storage
  - Azure Table Storage
  - Azure Files (プレビュー)
- Azure Data Lake Storage Gen2
- データベース
  - Azure SQL Database
  - Azure Database for MySQL (プレビュー)
  - Azure Cosmos DB
    - Azure Cosmos DB for NoSQL
    - Azure Cosmos DB for Apache Gremlin (プレビュー)
    - Azure Cosmos DB for MongoDB (プレビュー)
- 同じテナント内にある SharePoint サイト (プレビュー)

サードパーティの Microsoft パートナーから提供される「データコネクター」を使用することで、さらに多くのデータソースに対応できる。

https://learn.microsoft.com/ja-jp/azure/search/search-data-sources-gallery#data-sources-from-our-partners

以下、対応データソースの例（一部）:

- Amazon S3
- Amazon RDS
- ファイルシステム（Windows, Linux, Mac）
- Googleドライブ
- OneDrive
- MySQL
- Oracle
- PostgreSQL
- Salesforce
- SAP ERP
- SAP HANA
- ServiceNow
- Twitter
- Slack

■フルテキスト検索（全文検索）

https://www.sophia-it.com/content/%E5%85%A8%E6%96%87%E6%A4%9C%E7%B4%A2

＞全文検索は、文書を総なめにして検索語がないかを探し出す。仮に検索語と一致する文字列を含んだ文書が見つかれば、その文字列がいかなる個所に書かれたものであっても検索結果として持ってくる。全文検索は、検索方法としては最も網羅的な手法である。ただし他の方式に較べると検索の時間がかかるという難点がある。

＞GoogleやYST（Yahoo! Search Technology）のような、インターネットで提供されている検索エンジンの多くは、Webページを全文検索するサービスを提供している

https://learn.microsoft.com/ja-jp/azure/search/search-lucene-query-architecture

Azure Cognitive Search では、フルテキスト検索に、オープンソースの検索エンジン「Apache Lucene」（アパッチ ルシーン）の機能の一部を使用している。


https://lucene.apache.org/

Apache Luceneの「Simple Query Parser」による検索と、「Lucene Query Parser」による高度なクエリをサポートしている。

https://learn.microsoft.com/ja-jp/azure/search/query-simple-syntax

https://learn.microsoft.com/ja-jp/azure/search/query-lucene-syntax

■フィルタリング（$filter クエリ）

フィルタリングを使用すると、検索結果から、条件に一致しないものを除外できる。

Azure AI Search では、「OData言語」を使ったフィルタリングをサポートしている。

https://learn.microsoft.com/ja-jp/azure/search/search-query-odata-filter#examples

比較演算子 (eq, ne, gt, lt, ge, le), 論理演算子(and, or, not)などを組み合わせたフィルタリングが可能。

|比較演算子|意味|
|-|-|
|eq|等しい equal|
|ne|等しくない not equal|
|gt|より大きい greater than|
|lt|より小さい less than|
|ge|以上 greater than or equal|
|le|以下 less than or equal|

フィルタリングの例

基本料金が $200 未満の部屋が少なくとも 1 つある 4 つ星以上のホテルをすべて探す。

```
$filter=Rooms/any(room: room/BaseRate lt 200.0) and Rating ge 4
```

その他の例:
https://learn.microsoft.com/ja-jp/azure/search/search-query-odata-filter#examples


■ファセット ナビゲーション

https://learn.microsoft.com/ja-jp/azure/search/search-faceted-navigation

Azure AI Searchは「ファセットナビゲーション」をサポートしている。

![Alt text](image-4.png)

例: 価格.com の パソコンの検索 https://kakaku.com/pc/

- ノートパソコン
- CPU: Ryzen 7
- 画面サイズ: 14.5型(インチ)～17型(インチ)未満
- など

https://accessible-usable.net/2020/07/entry_200727.html

＞たとえばオンラインショッピングの商品検索で、膨大な検索結果をさまざまな側面 (価格帯、メーカー名やブランド名、商品種別、などの切り口) から絞り込むことができる機能です。

＞ファセット (facet) とはもともと宝石のカット面という意味ですが、そこから派生して、物事の側面や切り口を意味するようにもなっています。なお英語圏では、faceted navigation と同義で guided navigation と呼ばれることもあります。

■フィールド属性

https://learn.microsoft.com/ja-jp/azure/search/search-what-is-an-index#field-attributes

検索で各フィールドをどのように扱う必要があるのかを指定する。

- searchable
  - フルテキスト検索可能
- filterable
  - $filter クエリでフィルタリングが可能
- sortable
  - 並べ替えが可能
- facetable
  - [「ファセット ナビゲーション」を提供](https://learn.microsoft.com/ja-jp/azure/search/search-faceted-navigation) 例: kakaku.com
- retrievable
  - 検索結果でこのフィールドを返すことができる

**不要なフィールド属性を追加する（有効化する）と、インデックスのサイズが増え、検索パフォーマンスが落ちる。**



■フィールド属性の設定例

※賃貸物件のデータベースの「物件テーブル」を想定

要件:
- 物件名・所在地・設備リスト・担当者コメントのフルテキスト検索ができること。
  - 賃料と築年数は（数値なので）フルテキスト検索は不要
- 賃料と築年数でフィルタリングができること。
  - 例: 賃料10万以上15万以下 など
- 検索結果を、賃料 または 築年数 の昇順・降順でソートできること
- 設備リストで検索結果の絞り込みを行っていけること。
  - 例: ある条件での検索結果 120件中、WiFiあり物件が100件、宅配ボックスあり物件が50件、などと表示し、クリックするとドリルダウン（絞り込み）されていくこと
- 物件名・所在地・設備・賃料・築年数が、検索結果一覧に表示されること
  - 設備と担当者コメントは検索結果一覧には表示されないが、検索結果一覧のある物件をクリックすると、その物件の詳細ページには、設備と担当者コメントが表示されればよい

| フィールド     | searchable | filterable | sortable | facetable | retrievable |
| -------------- | ---------- | ---------- | -------- | --------- | ----------- |
| 物件名         | ✔         |            |          |           | ✔          |
| 所在地         | ✔         |            |          |           | ✔          |
| 賃料           |            | ✔         | ✔       |           | ✔          |
| 築年数         |            | ✔         | ✔       |           | ✔          |
| 設備           | ✔         |            |          | ✔        |             |
| 担当者コメント | ✔         |            |          |           |             |


■AIエンリッチメントとは？

https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-concept-intro

そのままの形式ではフルテキスト検索できないコンテンツに対して、機械学習モデルを適用することで、コンテンツを検索可能にすること。

たとえばPDFや画像などに対して「AIエンリッチメント」を行うことで、画像に対するキーワード検索などを実行できるようになる。

```
画像やPDF
↓AIエンリッチメント
画像の説明文など
↓
検索インデックス
```


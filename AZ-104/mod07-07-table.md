# Azure Table Storage


[製品ページ](https://azure.microsoft.com/ja-jp/services/storage/tables/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-overview)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/storage/tables/)

[REST APIドキュメント](https://docs.microsoft.com/ja-jp/rest/api/storageservices/table-service-rest-api)

[Table Storage設計ガイド](https://docs.microsoft.com/ja-jp/azure/cosmos-db/table-storage-design-guide) - この記事の内容は、従来の Azure Table Storage を対象としています。

[テーブルの設計パターン](https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-patterns)

[Table Storage のパフォーマンスとスケーラビリティのチェックリスト](https://docs.microsoft.com/ja-jp/azure/storage/tables/storage-performance-checklist)

# 概要

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-overview#what-is-table-storage


- 非リレーショナル構造化データ (構造化された NoSQL データとも呼ばれます) をクラウド内に格納するサービス
- スキーマレスのデザインによるキーおよび属性ストアを実現します。
- スキーマがないため、アプリケーションの進化のニーズに合わせてデータを容易に修正できます。
- Table Storage のデータ アクセスは、多くの種類のアプリケーションにとって高速でコスト効率に優れ、また一般に、従来の SQL と比較して、同様の容量のデータを低コストで保存することができます。
- ストレージ アカウントの容量の上限を超えない限り、テーブルには任意の数のエンティティを保存でき、ストレージ アカウントには任意の数のテーブルを含めることができます。
- Web スケール アプリケーションにサービスを提供できる数テラバイトの構造化データを格納する
- クラスター化インデックスを使用して高速なデータのクエリを実行する
- OData プロトコルおよび LINQ クエリを WCF Data Service .NET ライブラリと共に使用してデータにアクセスする
- Azure Table Storage は、非リレーショナル構造化データ (構造化された NoSQL データとも呼ばれます) をクラウド内に格納するサービスであり、スキーマレスのデザインによるキーおよび属性ストアを実現します。
- Web アプリケーションのユーザー データ、アドレス帳、デバイス情報、サービスに必要なその他の種類のメタデータなど、柔軟なデータセットを格納できます。


※[クラスター化インデックス](https://docs.microsoft.com/ja-jp/sql/relational-databases/indexes/clustered-and-nonclustered-indexes-described?view=sql-server-ver15)は、テーブルまたはビュー内のデータ行をそのキー値に基づいて並べ替え、格納します。

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design

- リレーショナル データベースとは違って、Table service にはスキーマがないため、エンティティごとにプロパティのデータ型は同じである必要はありません。
-  1 つのプロパティに複雑なデータ型を格納するには、JSON や XML などのシリアル化された形式を使う必要があります。
-  PartitionKey と RowKey の値には、高速検索を可能にするクラスター化インデックスを作成するためのインデックスが作成されています
-  PartitionKey と RowKey のみがインデックス付きプロパティになります。

# ストレージアカウント

汎用 v1 / 汎用 v2 で、Table Storageをサポート。汎用v2が推奨される。

> ほとんどのシナリオで汎用 v2 ストレージ アカウントを使用することをお勧めしています。 汎用 v1 または BLOB ストレージ アカウントは汎用 v2 アカウントに簡単にアップグレードできます。

なお、汎用 v1 / 汎用 v2 のストレージアカウントではパフォーマンスレベルが「Standard」と「Premium」が選択できるが、Table StorageはPremium パフォーマンスには対応していない。

> 「汎用 v2 および汎用 v1 アカウント用の Premium パフォーマンスは、ディスクとページ BLOB のみで利用できます。」


# コスト

https://azure.microsoft.com/ja-jp/pricing/details/storage/tables/

保存した容量と、トランザクション（読み取り・書き込み・削除などすべての操作）の回数に比例したコストがかかります。

# 可用性

ストレージアカウントのSLAが適用される。

- 読み込み
  - 99.99% (RA-GRS)
  - 99.9% (RA-GRS/RA-GZRSのクールアクセスレベル/LRS/ZRS/GRS)
- 書き込み
  - 99.9% (LRS/ZRS/GRS/RA-GRS)
  - 99% (クールアクセスレベル)

https://azure.microsoft.com/ja-jp/support/legal/sla/storage/v1_5/

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-redundancy#durability-and-availability-parameters

# データの持続性

- LRS - 年間 99.999999999% (イレブン ナイン) 以上
- ZRS - 年間 99.9999999999% (トゥエルブ ナイン) 以上
- GRS/RA-GRS - 年間 99.99999999999999% (シックスティーン ナイン) 以上
- GZRS/RA-GZRS - 年間 99.99999999999999% (シックスティーン ナイン) 以上

# 可用性ゾーン

ストレージアカウントで以下を選択することで、プライマリリージョンでのゾーン冗長化が行われる（データがプライマリリージョンの3つの可用性ゾーンでレプリケーションされる）。

- ZRS
- GZRS
- RA-GZRS

# Geo冗長（複数のリージョンを使用した冗長構成）

ストレージアカウントで以下を選択することで、セカンダリリージョンを使用した冗長化が行われる（データがセカンダリリージョンに非同期でレプリケーションされる）。

- GRS/GZRS
  - セカンダリリージョンにデータをレプリケーションできる。
- RA-GRS/RA-GZRS
  - セカンダリリージョンにデータをレプリケーションでき、セカンダリリージョンからデータを読み取りできる。

# マルチリージョン書き込み（マルチマスター）

Table Storageでは非対応。ストレージアカウント作成時に選択したリージョン（プライマリリージョン）のエンドポイントからのみ、書き込みが可能。

# バックアップ

2021/4現在、Table Storage用のバックアップ機能は存在しない。

[AzCopy](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-v10)や[Azure Data Factory](https://docs.microsoft.com/ja-jp/azure/data-factory/connector-azure-table-storage)を使用してTable Stroageデータを他の場所にコピーすることで対応。

AzCopy参考: https://stackoverflow.com/questions/35724147/copy-table-from-azure-to-local-storage-using-azcopy

# サーバーサイド プログラミング

Table Storageでは、ストアドプロシージャなどを使用することはできない。

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-overview#what-is-table-storage

> Table Storage の一般的な用途には、次のようなものがあります。
> 
> 複雑な結合、外部キー、またはストアド プロシージャを必要とせず、高速アクセスのために非正規化できるデータセットを格納する

※ Cosmos DBのSQL API を使用するとき、ストアド プロシージャ、トリガー、および ユーザー定義関数 (UDF) を JavaScript 言語で記述できます。

# 整合性/一貫性

https://docs.microsoft.com/ja-jp/azure/cosmos-db/table-support

> プライマリ リージョン内では厳密な整合性。 セカンダリ リージョン内では最終的な整合性。

# 性能

- ストレージ アカウントあたりの最大要求レート
  - 毎秒 20,000 トランザクション (エンティティ サイズは 1 KiB を想定)
- 1 つのテーブル パーティションのターゲット スループット (1 KiB のエンティティ)
  - 毎秒最大 2,000 エンティティ


# 構造

    ストレージアカウント (汎用v1/汎用v2)
        └テーブル
            └エンティティ
                └プロパティ

- ストレージ アカウントの容量の上限を超えない限り、ストレージ アカウントには任意の数のテーブルを含めることができます。テーブルには任意の数のエンティティを保存できます。

# テーブル

https://docs.microsoft.com/ja-jp/rest/api/storageservices/understanding-the-table-service-data-model#tables-entities-and-properties

- エンティティのコレクション
- テーブル名
  - アカウント内で一意
  - 英数字のみ
  - 数字から開始できない
  - 大文字・小文字は区別されない
    - テーブル名の作成時に指定された大文字と小文字の違いは維持されますが、使用時には大文字と小文字は区別されません。
  - 長さは3～63文字
  - 「Tables」など一部のテーブル名は予約されている

# エンティティ

https://docs.microsoft.com/ja-jp/rest/api/storageservices/understanding-the-table-service-data-model

- エンティティは、プロパティのセットで、データベースの行に似ています。
- エンティティのプロパティ内のすべてのデータの合計サイズが 1 MiB を超えることはできません。
- 最大 255 個のプロパティ(3つの「システムプロパティ」を含む)
- テーブルではエンティティにスキーマを設定しないため、1 つのテーブルに異なるプロパティのセットを持つエンティティが含まれている場合があります。

# プロパティ

- システムプロパティ - 3個
  - パーティションキー(PartitionKey)
  - 行キー(RowKey)
  - タイムスタンプ(Timestamp)
- その他のプロパティ - 最大252個

- プロパティ名
  - 大文字と小文字が区別される
  - 255 文字を超えることはできません。
  - C# 識別子の名前付け規則に従っている必要があります。

# システムプロパティ

- パーティションキー(PartitionKey)
  - 特定のテーブル内のパーティションの一意の識別子
  - 最大 1 KiB の文字列
  - 挿入、更新、削除操作時、必須
- 行キー(RowKey)
  - 特定のパーティション内のエンティティを示す一意の識別子
  - 最大 1 KiB の文字列
  - 挿入、更新、削除操作時、必須
- Timestamp プロパティ
  - エンティティの最終変更時刻を記録するためにサーバー側に保持される DateTime 値
  - タイムスタンプは自動的に適用されます。タイムスタンプを手動で任意の値に上書きすることはできません。
  - テーブル サービスは、Timestamp プロパティを内部的に使用してオプティミスティック コンカレンシー制御を提供
  - このプロパティは、挿入操作または更新操作には設定しないでください (値は無視されます)。

PartitionKeyとRowKeyの値には、、`/`, `\`, `#`, `?`, U+0000～U+001F, U+007F～U+009Fの文字を使用できない。

# (システムプロパティ以外の)プロパティ

- byte[] - 最大64KiB
- bool
- DateTime
- double
- Guid
- Int32 (int)
- Int64 (long)
- String - 最大64KiB(文字数は約32K以下)

> プロパティ名は大文字と小文字が区別され、255 文字を超えることはできません。

> プロパティ名は、 C# 識別子の名前付け規則に従っている必要があります。

null 値は保持されない（ただし、クエリの$selectで、エンティティに存在しないプロパティを指定した場合は、そのプロパティの値としてnullが返される）

# ツール

- Azure portal
  - ストレージアカウント＞Table Service
    - テーブルの作成・削除
    - テーブルのアクセスポリシーの作成・編集・削除
  - ストレージアカウント＞Storage Explorer
  - 検索＞Storage Explorer
- Microsoft Azure Storage Explorer （GUIアプリ）
- [AzCopy バージョン 7.3](https://aka.ms/downloadazcopynet)
  - `C:\Program Files (x86)\Microsoft SDKs\Azure\AzCopy`
  - 7.3より新しいバージョンではtableがサポートされない
  - [インポート](https://docs.microsoft.com/ja-jp/previous-versions/azure/storage/storage-use-azcopy#import-data-into-table-storage) - JSONのみ
  - [エクスポート](https://docs.microsoft.com/ja-jp/previous-versions/azure/storage/storage-use-azcopy#export-data-from-table-storage) - JSONまたはCSV形式

# SAS

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview

[ストレージアカウントでは3種類のSASを作成できる](https://docs.microsoft.com/ja-jp/rest/api/storageservices/delegate-access-with-shared-access-signature)

- アカウントレベルSAS
  - ストレージアカウント キーで保護
  - アカウント SAS は、1 つ以上のストレージ サービスのリソースへのアクセスを委任
  - サービスまたはユーザー委任 SAS を介して実行できるすべての操作は、アカウント SAS を介しても実行できます。
- サービスレベルSAS
  - ストレージ アカウント キーで保護
- ユーザー委任SAS (user delegation SAS)
  - ユーザー委任 SAS は、BLOB ストレージにのみ適用されます。
  - Azure AD資格情報と、SAS に指定されたアクセス許可によって保護

サービスレベルSASでは、「[格納されたアクセスポリシー](https://docs.microsoft.com/ja-jp/rest/api/storageservices/define-stored-access-policy)」を参照できる。現在、アカウント SAS またはユーザー委任 SAS では、保存されたアクセス ポリシーはサポートされていません。

- [AccountSasBuilder](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.sas.accountsasbuilder?view=azure-dotnet)
- [BlobSasBuilder](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.sas.blobsasbuilder?view=azure-dotnet)
- [QueueSasBuilder](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.sas.queuesasbuilder?view=azure-dotnet)
- [ShareSasBuilder](https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.sas.sharesasbuilder?view=azure-dotnet)
- [TableSasBuilder](https://docs.microsoft.com/en-us/dotnet/api/azure.data.tables.sas.tablesasbuilder?view=azure-dotnet-preview) 

アクセスポリシーを使わないSASはアドホックSASと呼ばれる。ユーザー委任 SAS またはアカウント SAS はアドホック SAS である必要があります。 

まとめ

- Table StorageではアカウントレベルSASまたはサービスレベルSASを使用できる
- サービスレベルSASではアクセスポリシーを参照できる
- [SDK](https://docs.microsoft.com/en-us/dotnet/api/azure.data.tables.sas.tablesasbuilder?view=azure-dotnet-preview)または [C#のコード](https://stackoverflow.com/questions/42985347/how-to-generate-the-azure-table-service-sas-token-from-c-sharp-code
) などを使用してSASを生成することができる

# SDK / ライブラリ

https://docs.microsoft.com/ja-jp/azure/cosmos-db/table-support?toc=https%3A%2F%2Fdocs.microsoft.com%2Fja-jp%2Fazure%2Fstorage%2Ftables%2Ftoc.json&bc=https%3A%2F%2Fdocs.microsoft.com%2Fja-jp%2Fazure%2Fbread%2Ftoc.json#developing-with-the-azure-cosmos-db-table-api


- .NET
  - [Azure Tables client library for .NET - Version 12.0.0-beta.7](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/data.tables-readme-pre)
    - `dotnet add package Azure.Data.Tables --version 12.0.0-beta.7`
  - [Microsoft.Azure.Cosmos.Table 1.0.8](https://www.nuget.org/packages/Microsoft.Azure.Cosmos.Table)
    - `dotnet add package Microsoft.Azure.Cosmos.Table --version 1.0.8`
  - [Microsoft.Azure.Cosmos.Table 2.0.0-preview](https://www.nuget.org/packages/Microsoft.Azure.Cosmos.Table/2.0.0-preview)
    - `https://www.nuget.org/packages/Microsoft.Azure.Cosmos.Table/2.0.0-preview`
- Python
- Java
- Node.js
- C++
- PHP
- Python
- Ruby
- PowerShell

※Cosmos DB [.NET SDK for Azure Cosmos DB for the core SQL API](https://github.com/Azure/azure-cosmos-dotnet-v3) 

# ローカル開発のためのエミュレータ

- [Microsoft Azure ストレージ エミュレーター](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-emulator?toc=https%3A%2F%2Fdocs.microsoft.com%2Fja-jp%2Fazure%2Fstorage%2Ftables%2Ftoc.json&bc=https%3A%2F%2Fdocs.microsoft.com%2Fja-jp%2Fazure%2Fbread%2Ftoc.json)
- [Azurite](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azurite)


# パーティション

https://docs.microsoft.com/ja-jp/rest/api/storageservices/understanding-the-table-service-data-model

> テーブルは、パーティションに分割することでストレージ ノード間の負荷分散をサポートします。 テーブルのエンティティはパーティションごとに整理されます。 パーティションは、同じパーティション キー値を処理する連続した範囲のエンティティです。

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design

Table service では、個々のノードが 1 つ以上の完全なパーティションを提供し、サービスのスケーリングはノード間でパーティションの負荷を動的に分散させることで行われます。 ノードに負荷がかかる場合は、テーブル サービスのパーティション範囲を 別のノードと 分割 し、トラフィックが少ないときにサービスを マージ して、パーティション範囲を複数のトラフィックの少ないノードから 1 つのノードに戻すことができます。

# 操作

https://docs.microsoft.com/ja-jp/rest/api/storageservices/operations-on-entities

- Insert
  - PartitionKey と RowKey の組み合わせから形成された一意の主キーを持つ新しいエンティティを挿入
- Update
  - 既存のエンティティを更新（エンティティ全体を置換）
- Merge
  - エンティティのプロパティを更新することで既存のエンティティを更新
- Delete
  - エンティティを削除
- Insert or Replace
  - 既存のエンティティを置換し、テーブルにエンティティがない場合は新しいエンティティを挿入
- Insert or Merge
  - 既存のエンティティを更新し、テーブルにエンティティがない場合は新しいエンティティを挿入
- Query
  - テーブル内のエンティティをクエリ
  - $filter
  - $select
  - $top

# トランザクション

https://docs.microsoft.com/ja-jp/rest/api/storageservices/performing-entity-group-transactions

同じテーブルに存在し、かつ同じパーティション グループに属しているエンティティについて、Table service はバッチ トランザクションをサポートします。 複数のInsert entity、 Update Entity、 Merge entity、 Delete entity、 Insert または Replace entity、およびinsert または Mergeエンティティの各操作は、1つのトランザクション内でサポートされています。

# クエリの詳細

https://docs.microsoft.com/ja-jp/rest/api/storageservices/querying-tables-and-entities

クエリ結果は PartitionKey 順、RowKey 順に並べ替えられます。 結果のその他の並べ替え方法は現在サポートされていません。

Table service は、 OData プロトコル仕様に準拠した次のクエリオプションをサポートしています。

- $filter
  - 指定したフィルターを満たしたテーブルまたはエンティティのみを返します。
  - 許可される比較は 15 件までです。
- $select
  - 結果セットからエンティティの目的のプロパティを返します。 
- $top
  - 結果セットから最初の n 個のテーブルまたはエンティティのみを返します。

- 結果は、パーティション キー/行キーの順序で返される

https://docs.microsoft.com/ja-jp/rest/api/storageservices/query-entities

クエリの時間と最大エンティティ

> テーブル サービスに対するクエリは最長 5 秒間実行され、一度に最大 1,000 個のエンティティが返されます。 返されるエンティティ数が 1,000 個を超える場合、クエリが 5 秒以内に終了しない場合、またはクエリがパーティション境界を超える場合は、継続トークンのセットを含むカスタム ヘッダーが応答に含まれます。 

nullが返される場合がある

> 射影されたすべてのプロパティは、返されるエンティティに含まれていない場合であっても、応答本文に含まれます。 たとえば、射影されたエンティティに含まれないプロパティが要求に含まれている場合、欠落しているプロパティは null 属性としてマークされます。


# クエリの種類

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-for-query

- ポイント クエリ
  - PartitionKey と RowKey 値の両方を eq 指定
- 範囲クエリ
  - PartitionKey を eq 指定
  - RowKey を ge / lt 等で指定
- パーティション スキャン
  - PartitionKey を eq 指定
  - RowKeyの条件を指定しない
- テーブル スキャン
  - PartitionKeyの条件を指定しない
  - RowKeyの条件は指定してもしなくてもテーブル スキャンとなる


クエリは複数のエンティティを PartitionKey と RowKey の順序で並べ替えて返します。

# LINQ

LINQを使ってクエリを記述することができます。

https://docs.microsoft.com/ja-jp/rest/api/storageservices/query-operators-supported-for-the-table-service

https://docs.microsoft.com/ja-jp/rest/api/storageservices/writing-linq-queries-against-the-table-service

From, Where, Take, First, FirstOrDefault, Selectをサポート。

GroupBy, OrderBy, Average, Min, Max, Sum, Join, Unionなどはサポートされていない。

# [Entity Framework Core](https://docs.microsoft.com/ja-jp/ef/core/)

EF Coreは、ORM。[プロバイダー](https://docs.microsoft.com/ja-jp/ef/core/providers/?tabs=dotnet-core-cli)を使用して、さまざまなデータベースにアクセスできる。

現状、[Table Storage / Table APIはサポートされていない](https://stackoverflow.com/questions/60027663/error-while-using-cosmosdb-provider-for-entity-framework-core-with-azure-tables)。Cosmos DBのSQL APIはサポート。


# SAS


Cosmos DBではSASは一部サポート。https://docs.microsoft.com/ja-jp/azure/cosmos-db/table-api-faq


# インデックス

https://docs.microsoft.com/ja-jp/azure/cosmos-db/table-support

> PartitionKey と RowKey のプライマリ インデックスのみ。 セカンダリ インデックスなし。

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-patterns

Table service は PartitionKey と RowKey 値を使用して自動的にインデックスを作成します。
そのため、クライアント アプリケーションでは、これらの値を使用してエンティティを効率的に取得できます。 

# セカンダリインデックス

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-patterns

Table サービスではセカンダリ インデックスが提供されない。

セカンダリ インデックスの不足を回避するには、異なる RowKey 値を使用して各コピーの複数コピーを格納します。

例

- 従業員の情報ををテーブルに格納する。
- PartitionKeyに部署名、RowKeyに従業員IDを使う
  - 「部署名・従業員ID」では、効率的に検索できる（ポイントクエリが行われる）
  - 「部署名・従業員eメールアドレス」では、効率的に検索できない（パーティションスキャンが行われる）

この場合の解決策として、一人の従業員に対し、以下の2つのエンティティを格納する。
- 「PartitionKeyに部署名、RowKeyに"empid_" + 従業員ID」のエンティティと
- 「PartitionKeyに部署名、RowKeyに"email_" + 従業員eメールアドレス」のエンティティ

テーブル ストレージは比較的低コストで利用できるため、重複するデータを格納してもコストは大きな問題になりません。

# Azure Functionsのバインド

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-table

Azure Table Storageでは、入力バインド・出力バインドは利用できるが、**トリガーは利用できない**。


[Cosmos DBの場合はトリガーも使える](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-cosmosdb-v2)。

# 変更フィード

https://docs.microsoft.com/ja-jp/azure/cosmos-db/change-feed

- 変更フィードは、コンテナーに対して行われた変更が発生した順番で記録されている永続的な記録です。
- 現在、変更フィードにはすべての挿入と更新が表示されています。
- 現在、変更フィードでは削除は記録されません。

https://docs.microsoft.com/ja-jp/azure/cosmos-db/change-feed-functions

Azure Functions には、変更フィードに接続する最も簡単な方法が用意されています。 Azure Cosmos コンテナーの変更フィード内の新しい各イベントに基づいて自動的にトリガーされる小規模な対応型 Azure 関数を作成できます。



Table StorageおよびTable APIでは、変更フィードはサポートされていない。

変更フィードは、すべての Azure Cosmos アカウントで既定で有効になっています。


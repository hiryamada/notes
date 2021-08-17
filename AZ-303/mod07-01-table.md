# Azure Table Storage

ストレージアカウント内で利用することができるNoSQLデータストア

https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-overview

Table Storageは、Web アプリケーションのユーザー データ、アドレス帳、デバイス情報、サービスに必要なその他の種類のメタデータなどの格納のためによく利用される。

Table Storageには、大量の「構造化データ」を格納することができる。

■エンティティ

Table Storageのデータは「エンティティ」と「プロパティ」という構造を持っている。

テーブルに「エンティティ」を格納。

テーブルやエンティティの数に制限は特になく、ストレージアカウントの容量の上限までデータを保存することができる。

■エンティティの例

```
TableA
 ├ エンティティ{PartitionKey=1,RowKey=2,a=3,b=4,c=5}
 └ エンティティ{PartitionKey=6,RowKey=7,a=8,b=9,c=10}

TableB
 ├ エンティティ{PartitionKey=1,RowKey=2,a=3,b=4}
 └ エンティティ{PartitionKey=6,RowKey=7,c=8,d=9}
```

プロパティは入れ子にすることはできません。つまり `{a={b=1,c=2}}` といった構造は記録できない。

■特徴

- 可用性: 最大で99.99% SLAの可用性を提供します。|
- リージョンによる冗長化
  - ストレージアカウントでGRSなどを選択することで、プライマリリージョンとセカンダリリージョンを使用した冗長構成を取ることができる
- 可用性ゾーンによる冗長化
  - ストレージアカウントでZRSなどを選択することで、プライマリリージョン内の複数の可用性ゾーンを使用した冗長構成を取ることができる
- 整合性
  - プライマリ リージョン内では厳密な整合性、セカンダリ リージョン内では最終的な整合性が提供される

■構造

```
ストレージアカウント
└テーブル
  └エンティティ
    ├システムプロパティ(3個)
    └カスタムプロパティ(最大252個)
```

プロパティの合計は最大で255個。

■システムプロパティ

- パーティションキー(PartitionKey)
  - 最大1 KiB の文字列を格納できる。
  - 空の文字列も許可。null 値は許可されない
- 行キー(RowKey)
  - 最大1 KiB の文字列を格納
  - 空の文字列も許可。null 値は許可されない。
- タイムスタンプ(Timestamp)
  - エンティティの最終更新日時をトラッキングするために使用されるプロパティ
  
パーティションキーと行キーの値は利用者が指定。

タイムスタンプは自動的に追加・更新。

■カスタムプロパティ

カスタムプロパティは、プロパティの名前と値で構成。

カスタムプロパティは、テーブルにエンティティを追加する際に、そのエンティティに含める形で、利用者が指定。

データ型:

- String（文字列）
- Boolean（true/false）
- Binary（64KiBまでのバイトの配列）
- DateTime（日付と時刻）
- Double（浮動小数点数）
- Guid（グローバル一意識別子）Int32/Int64（整数）

■テーブルの設計パターン

- テーブルの設計パターン: https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-patterns
- クエリに対応した設計: https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-for-query
- データの変更に対応した設計: https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-design-for-modification


■トランザクション

1つのトランザクション内で、複数のInsert、 Update、 Merge、 Delete、 Insert or Merge、Insert or Replaceを実行することができる。

同じテーブルに存在し、同じパーティションに属しているエンティティについて、トランザクションを実行することができる。

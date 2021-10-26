# データストアの主な種類

■リレーショナル データベース

データを表形式で格納。

対応するAzureサービスの例:

- Azure SQL Database
- Azure Database for PostgreSQL
- Azure Database for MySQL
- Azure Database for MariaDB

■キーバリュー

データを、一意なキーに関連付けて保存。

```
キー1 → データ1
キー2 → データ2
キー3 → データ3
```

対応するAzureサービスの例:

- Cosmos DB
  - [Table API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/table/introduction)
- [Azure Table Storage](https://docs.microsoft.com/ja-jp/azure/storage/tables/table-storage-overview)
- Azure Cache for Redis

■ドキュメント データベース

データをXML、JSON、YAMLなどの方式で格納。データの一部を読み書きすることもできる

```
キー1 → {id: 1, name: "taro"}
キー2 → {id: 2, name: "taro"}
キー3 → {id: 3, name: "taro"}
```

対応するAzureサービスの例:

- Cosmos DB
  - [MongoDB API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/mongodb/mongodb-introduction)

■グラフデータベース

- データは「ノード（頂点）」、「エッジ（リレーションシップ）」で構成される
- リレーションシップが増えても、クエリのパフォーマンスが一定に保たれる

```
顧客   ... ノード
| 注文 ... リレーションシップ
製品   ... ノード
| 販売 ... リレーションシップ
販売元 ... ノード
```


参考: [Microsoft Learn: グラフデータベースとは](https://docs.microsoft.com/ja-jp/learn/modules/store-access-data-cosmos-graph-api/2-determine-graph-database-fits-data-needs-of-your-application)

対応するAzureサービスの例:

- Cosmos DB
  - [Gremlin API](https://docs.microsoft.com/ja-jp/azure/cosmos-db/graph/graph-introduction)

## インデクサー

インデクサーはデータソース内のデータをJSON化する（JSONシリアライゼーション）

シリアライズされたJSONは、search indexの作成に使用される。


## インデクサーのスケジュール設定

インデクサーの動作はオプションでスケジュール設定できる。

1度・毎時間・毎日・カスタム

## フィールド属性

フィールド属性により、実行できるアクション（filtering / sorting など）が決まる

## データ型

EDM: Entity Data Model https://learn.microsoft.com/ja-jp/dotnet/framework/data/adonet/entity-data-model

## インデックスのサイズに影響を与えるもの

https://learn.microsoft.com/ja-jp/azure/search/search-what-is-an-index#physical-structure-and-size

- ドキュメントの数量と構成
- 個々のフィールドの属性
- インデックスの構成 (具体的には、suggester を含めるかどうか)

https://learn.microsoft.com/ja-jp/azure/search/search-what-is-an-index#example-demonstrating-the-storage-implications-of-attributes-and-suggesters

- "取得可能" は、インデックスのサイズに影響しません。
- "フィルター可能"、"並べ替え可能"、"ファセット可能" は、より多くのストレージを消費します。
- suggester では、インデックス サイズが大きくなる可能性が大いにあります

## インデックスのスキーマの例

```
{  
  "name": "books",  
  "fields": [  
    { "name": "id", "type": "Edm.String", "key": true, "filterable": true, "sortable": true },  
    { "name": "title", "type": "Edm.String", "searchable": true, "filterable": true, "sortable": true },  
    { "name": "author", "type": "Edm.String", "searchable": true, "filterable": true, "sortable": true },  
    { "name": "publicationDate", "type": "Edm.DateTimeOffset", "filterable": true, "sortable": true },  
    { "name": "isbn", "type": "Edm.String", "searchable": true, "filterable": true, "sortable": true },  
    { "name": "categories", "type": "Collection(Edm.String)", "searchable": true, "filterable": true, "facetable": true },  
    { "name": "description", "type": "Edm.String", "searchable": true },  
    { "name": "publisher", "type": "Edm.ComplexType", "fields": [  
      { "name": "name", "type": "Edm.String", "searchable": true },  
      { "name": "location", "type": "Edm.String", "searchable": true }  
    ]}  
  ]  
}  

```
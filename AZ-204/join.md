RDBのようなテーブル結合機能がありますでしょうか、結合が必要な場合どうしたら良いのでしょうか？
→テーブル結合機能はない。結合を使わずに目的の情報が取得できるようにデータ構造を設計する。JOIN句はあり、一つの項目内での「自己結合」は可能。

RDB（リレーショナルDB）では、情報の重複や矛盾などを避けるため、通常「正規化」によって、データ構造を複数のテーブルに分解する。
そして必要に応じて結合（JOIN）を使用して必要なデータを取り出す。

しかしNoSQLでは、結合を使わなくても目的の情報をすばやく取得できるよう、通常「正規化」をあえて実施せず、「非正規形」で、項目を記録する。
参考:
https://learn.microsoft.com/ja-jp/azure/cosmos-db/nosql/modeling-data

「非正規形」のデータの例については、こちらのページの解説がわかりやすい。
https://zenn.dev/peishim/articles/4ef7f45074b505#%E3%83%A6%E3%83%BC%E3%82%B9%E3%82%B1%E3%83%BC%E3%82%B9%E3%82%92%E8%80%83%E3%81%88%E3%82%88%E3%81%86%E3%80%9Cnosql%E3%81%AEdb%E8%A8%AD%E8%A8%88%E3%80%9C

Cosmos DBでは、コンテナー（テーブル）の結合や、複数の項目の結合はできないが、一つの項目内での「自己結合」は可能。
参考:
https://learn.microsoft.com/ja-jp/azure/cosmos-db/nosql/query/join

具体的な例:

「Products」コンテナーに以下の項目があるとする。

```
[
  {
    "id": "1234",
    "name": "LAVIE N16 N1670/HA 2024年春モデル",
    "tags": [
      {
        "tagname": "maker",
        "value": "NEC"
      },
      {
        "tagname": "cpu",
        "value": "Core i7"
      },
      {
        "tagname": "memory",
        "value": "16GB"
      },
      {
        "tagname": "os",
        "value": "Windows 11 Home 64bit"
      }	  
    ]
  }
]
```

ここから、製品名（LAVIE N16）と、搭載メモリ量（16GB）を取り出したいとする。
結果例: {name: "LAVIE N16 N1670/HA 2024年春モデル", memory: "16GB"}


まず、製品名と、その製品に含まれるすべてのタグを取得するために、以下のように「自己結合」を利用する。

SELECT
  p.name,
  t.tagname
  t.value
FROM
  products p
JOIN
  t IN p.tags
  
以下が得られる。

[
  {name: "LAVIE N16 N1670/HA 2024年春モデル", tagname: "maker",  value: "NEC"},
  {name: "LAVIE N16 N1670/HA 2024年春モデル", tagname: "cpu",    value: "Core i7"},
  {name: "LAVIE N16 N1670/HA 2024年春モデル", tagname: "memory", value: "16GB"},
  {name: "LAVIE N16 N1670/HA 2024年春モデル", tagname: "os",     value: "Windows 11 Home 64bit"}
]

次に、ここからメモリの情報だけを抽出する。

SELECT
  p.name,
  t.value
FROM
  products p
JOIN
  t IN p.tags
WHERE
  STARTSWITH(t.tagname, "memory")

以下が得られる。
 
[
  {name: "LAVIE N16 N1670/HA 2024年春モデル", value: "16GB"}
]

最後に "as" キーワードを使用してプロパティ名を変更する。

SELECT
  p.name,
  t.value as memory
FROM
  products p
JOIN
  t IN p.tags
WHERE
  STARTSWITH(t.tagname, "memory")

以下が得られる。
 
[
  {name: "LAVIE N16 N1670/HA 2024年春モデル", memory: "16GB"}
]

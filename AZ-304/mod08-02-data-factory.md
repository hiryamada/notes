# Azure Data Factory (ADF)

https://docs.microsoft.com/ja-jp/azure/data-factory/

ETL 、ELT 、データ統合という複雑なハイブリッド プロジェクト用に構築された、マネージドなクラウド サービス。

※ETLとELT

- ETL
  - Extract - Translate - Load
  - 抽出 - 変換 - 読み込み。
- ELT
  - Extract - Translate - Load, 抽出 - 読み込み - 変換。
  - 2020/12、John Lafleur氏が提唱。
    - https://www.kdnuggets.com/2020/12/future-etl-is-elt.html
  - データを変換せずDWHに読み込む。
  - データの利用者が必要に応じて変換作業を実施。
  - 変換のやり直しがきく。

2018/6/27 ADF 一般提供開始
https://azure.microsoft.com/ja-jp/blog/azure-data-factory-new-capabilities-are-now-generally-available/

2019/10/7 ADF「マッピングデータフロー」一般提供開始
https://azure.microsoft.com/ja-jp/blog/azure-data-factory-mapping-data-flows-are-now-generally-available/

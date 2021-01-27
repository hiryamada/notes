ラボ4は、
[Visual Studio Code で Azure Cosmos DB 向けの .NET Core アプリを構築する](https://docs.microsoft.com/ja-jp/learn/modules/build-cosmos-db-app-with-vscode/)
を実施してください。


以下、本家のラボ4のかんたんな説明

```
フォルダ Starter
  AdventureWorks.bacpac --- SQL DBのバックアップデータ

プロジェクト AdventureWorks.Models
  Model.cs --- 「モデル」のクラス。名称、カテゴリ、説明文など
  Product.cs --- 「製品」のクラス。名称、番号、色、サイズ、重量、価格など

プロジェクト AdventureWorks.Context
  Interfaces
    IAdventureWorksProductContext.cs --- ModelとProductを取得するためのインターフェース
  AdventureWorksCosmosContext.cs --- 上記インターフェースのCosmos実装
  AdventureWorksSqlContext.cs --- 上記インターフェースのSQL DB実装

プロジェクト AdventureWorks.Web
  Pages
    Index.cshtml.cs --- モデル一覧画面
    Details.cshtml.cs --- 製品一覧画面
  Startup.cs --- 使用するContext(SQL DB実装 / Cosmos DB実装)を指定

プロジェクト AdventureWorks.Migrate
  Programs.cs --- 移行(SQL DBの全データを読み取り、Cosmos DBへUpsert)

```
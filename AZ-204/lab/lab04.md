# ラボ4

- [山田サンプルコード](../sample/cosmosdb/)を実行してみましょう。
  - Cosmos DBのアカウントを新しく作成します
    - API: SQL(Core)
    - リージョン: 米国東部(East US)
    - その他: デフォルト値
    - 接続文字列をコピーしておきます
  - コードを確認します
  - Program.cs冒頭のコメントに沿って、.NET のプロジェクトを作ります
  - プロジェクト内にProgram.csとMusic.csの2ファイルを作ります
  - `dotnet run` で、プロジェクトを実行します
  - `SetConnectionString` で、Cosmos DBの接続文字列をセットします
  - `CreateDatabase` で、データベースを作成します
    - musicdb
  - `CreateContainer` で、コンテナーを作成します
    - music
  - `CreateItem` で、項目を作成します
  - `ListItems` で、すべての項目を取得します

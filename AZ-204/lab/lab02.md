# ラボ2 Azure Function

- ラボ全般の説明は[こちら](lab00.md)をご参照ください。
- リージョンは「(US) 米国東部」（East US, eastus）を選択してください。
- リソースグループは「Serverless」を使用します。
- 関数アプリのためのストレージアカウントを事前に作成します。
- 3つの関数を作成します。`func new`
  - Echo: HTTPリクエストで起動し、メッセージを表示するだけの単純な関数。
  - Recurring: タイマーで繰り返し実行される関数。
  - GetSettingInfo: HTTPリクエストで起動し、Blobのファイルを読み取って内容を表示する関数。

- 手順書中「yourname」となっているところは「yamada」のようなご自身のお名前を入れてください。たとえば `funcstor[yourname]` と書いてある場合、`[` と `]` は除き、`funcstoryamada` のようにしてください。名前が重複してしまう場合は、`funcstoryamada1234` のように末尾に適当な数字などを付与してください。
- タスク4 では、「Azure Storage BLOB 拡張機能」というパッケージを登録しています（`func extensions install --package Microsoft.Azure.WebJobs.Extensions.Storage`）。関数アプリで、Blob Storageのトリガーとバインドを使用するためには、このパッケージの登録が必要です。[参考](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-blob)
  - WebJobsは、Functionの登場以前から使われている、[App Serviceの機能の一つ](https://docs.microsoft.com/ja-jp/azure/app-service/webjobs-create)です。[参考1](https://news.mynavi.jp/article/zeroazure-9/), [参考2](https://qiita.com/yuhattor/items/f7b2aec5211951dd7622)

# 演習1

## タスク1
## タスク2
## タスク3

> リージョン: 米国東部

East USを選択します。

> 計画: 消費

「プランの種類」で、「消費量（サーバーレス）」を選びます。

# 演習2


## タスク1


> 3. 次の設定を使用して、新しい関数を作成します:

「＋追加」をクリックして、関数を作成します。「＋追加」がクリックできるようになるまで少し時間がかかる場合があります。

> テンプレート: HTTP トリガー

「テンプレート」から「HTTP trigger」を選択します。

> 名前: Echo

「新しい関数」に「Echo」と入力します。

> 権限レベル: 匿名

「Authorization level」で「Anonymous」を選びます。

## タスク2
## タスク3

> 2. 「入力」 タブで、次の JSON 要求本文を入力します。

「ボディ」のテキストボックスの中身をすべて削除し、手順書で指示された内容を貼り付けます。

> 4. テストの実行結果を確認します。結果は、元の要求本文を正確にエコーする必要があります。

「ボディ」に入力したものと全く同じものが「HTTP応答のコンテンツ」に出力されることを確認します。

また、次のようなログが出力されていることも確認します。

```
2020-11-15T17:27:17.381 [Information] Executing 'Functions.Echo' (Reason='This function was programmatically called via the host APIs.', Id=e467d1b8-1733-4376-9f50-d3779fc72677)
2020-11-15T17:27:17.382 [Information] Received a request
2020-11-15T17:27:17.382 [Information] Executed 'Functions.Echo' (Succeeded, Id=e467d1b8-1733-4376-9f50-d3779fc72677, Duration=1ms)
```

## タスク4
## タスク5

> 2. httprepl ツールを起動し、...

`httprepl : 用語 'httprepl' は、コマンドレット、関数、スクリプト ファイル、または操作可能なプログラムの名前として認識されません。名前が正しく記述されていることを確認し、パスが含まれている場合はそのパスが正しいことを確認してから、再試行し
てください。` といったエラーが表示される場合は、https://docs.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-5.0&tabs=windows#installation の手順に従って、httpreplをインストールしてください。

httpreplをインストールしても、コマンドが見つからなくてエラーになってしまう場合は、`~/.dotnet/tools/httprepl` で起動できます。

# 演習3（エクササイズ3）


## タスク1

> 2. 次の設定を使用して、新しい関数を作成します:

「＋追加」をクリックして、関数を作成します。「＋追加」がクリックできるようになるまで少し時間がかかる場合があります。

> 名前: 定期

名前は「Recurring」とします。

> スケジュール: `0 */2 * * * *`

ここでは[NCRONTAB式](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-timer?tabs=csharp#ncrontab-expressions)というものを使用しています。「`0 */2 * * * *`」は、2分間隔で関数を繰り返し実行することを意味します。


## タスク2

> 1. 関数エディターに移動し、「ログ」 を選択

「関数とコード」をクリックして、エディターを起動します。画面下部の「ログ」をクリックします。

## タスク3

> 1. 「関数」 ブレードで、「開発者」 セクションから 「インテグレーション」 オプションを選択します。

Recurring 関数を表示し、「統合」をクリックします。

> 3. 「スケジュール」 テキスト ボックスの値を `*/30 * * * * *` に変更します。

「`*/30 * * * * *`」は、30秒間隔で関数を繰り返し実行することを意味します。


## タスク4

# 演習4

## タスク1
## タスク2
## タスク3
## タスク4
## タスク5

# 演習5（エクササイズ5）

## タスク1
## タスク2
## タスク3

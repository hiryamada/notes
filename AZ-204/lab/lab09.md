# ラボ9 Event Grid

■概要

```
.NETアプリ + Event Grid のクライアントライブラリ
↓ イベント
Event Gridトピック
 └ Event Gridサブスクリプション
     ↓ webhook(HTTP POST)
     Event Gridビューア（Webアプリ）
```

■Webhookとは

https://ja.wikipedia.org/wiki/Webhook

あるサービスから別のサービスへ、HTTP POSTで情報を伝達するしくみ。

```
サービスA
↓ HTTP POST (JSON等を送信)
サービスB
```

サービスB側はHTTP(S)のエンドポイントを持つ。

サービスAはそのエンドポイントにHTTPでリクエストを送ることで、何らかの情報を伝達する。

■Event Grid Viewer

Event Gridの動作確認のためのWebアプリケーション。

- [解説](https://docs.microsoft.com/en-us/samples/azure-samples/azure-event-grid-viewer/azure-event-grid-viewer/)
- [GitHubリポジトリ](https://github.com/azure-samples/azure-event-grid-viewer/tree/main/)
- [開発秘話](https://madeofstrings.com/2018/03/14/azure-event-grid-viewer-with-asp-net-core-and-signalr/)

■ラボの重要ポイント

- 演習1
  - Cloud Shellを使用して、サブスクリプションに「Microsoft.EventGrid」リソースプロバイダーが含まれていることを確認。
  - 実行例: 
    ```
    $ az provider list --query "[].namespace" |grep -i eventgrid
       "Microsoft.EventGrid",
    $ az provider show -n Microsoft.EventGrid |grep -i registrationstate
       "registrationState": "Registered",
    ```
  - もし登録されていない場合は以下のコマンドで登録
    ```
    $ az provider register --namespace 'Microsoft.EventGrid'
    ```
  - Event Grid トピックを作成
  - Event Grid Viewer（Webアプリ）をデプロイ
- 演習2
  - Event Grid Viewer（Webアプリ）をWebブラウザの別ウィンドウで開いておく
  - Event Grid トピックに、サブスクリプションを作成する
    - エンドポイント種類を「Webhook」とする
    - エンドポイントとして、Event Grid Viewer（Webアプリ）のURLに `/api/updates` を追加したURLを指定する
    - エンドポイントを作成すると、Event Grid Viewer（Webアプリ）に `Microsoft.EventGrid.SubscriptionValidationEvent` と表示されて、サブスクリプションとして接続ができたことが確認できる。
  - Event Grid トピックの「トピックエンドポイント」と「アクセスキー」をコピーする。
- 演習3
  - .NETプロジェクトを作成する
  - Event Gridのクライアントライブラリを追加する
    - `dotnet add Azure.Messaging.EventGrid`
  - Event Gridトピックにイベントを送信するコードを記述する。
  - ここではコード内に「トピックエンドポイント」と「アクセスキー」を直接書き込んでいるが、「アクセスキー」は機密情報であるため、本来はAzure Key Vaultに配置することが望ましい。
  - アプリケーションを実行する
- 演習4
  - Event Grid Viewer（Webアプリ）に `Employees.Registration.New` と表示されて、トピックにイベントが送信されたことが確認できる。

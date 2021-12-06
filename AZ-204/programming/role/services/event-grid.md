■概要

```
イベント発行クライアント
↓イベントを発行 (3)
Azure Event Gridトピック ← (1)トピックを管理
↓イベントを配信 (4)
サブスクライバー ←(2)サブスクリプションを作成
```

※サブスクライバー: ハンドラー、宛先とも。Event Hubs/Service Bus/ストレージQueue/Relayハイブリッド接続/Azure Functions/Storage Blob/Webhook等

(1)トピックを管理（作成）するための権限

- [Event Grid の共同作成者ロール](https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization#built-in-roles)

(2)サブスクリプションを作成するための権限

- [Event Grid サブスクリプション閲覧者ロール](https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization#built-in-roles)
- [Event Grid サブスクリプションの共同作成者ロール](https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization#built-in-roles)

(3)イベント発行クライアントが、イベントを発行（送信）するための権限

- [アクセスキー](https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-access-keys-shared-access-signatures)
- [SAS](https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-access-keys-shared-access-signatures)
- [Event Grid データ送信者ロール](https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-active-directory)

(4)トピックが、サブスクライバーにイベントを送信するための権限

- アクセスキー
- [トピックに割り当てたマネージドID＋そのIDに対するRBACロール割り当て](https://docs.microsoft.com/ja-jp/azure/event-grid/managed-service-identity)
- [Webhook ハンドシェイク](https://docs.microsoft.com/ja-jp/azure/event-grid/webhook-event-delivery)
- [クエリパラメータでクライアントシークレットを使用する](https://docs.microsoft.com/ja-jp/azure/event-grid/security-authentication#using-client-secret-as-a-query-parameter)
  - Webhook の送信先 URL にクエリ パラメーターを追加する
- [CloudEvents v1.0 を使用したエンドポイントの検証](https://docs.microsoft.com/ja-jp/azure/event-grid/security-authentication#endpoint-validation-with-cloudevents-v10)

■コントロールプレーンの組み込みロール

https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization#built-in-roles

- Event Grid サブスクリプション閲覧者
- Event Grid サブスクリプションの共同作成者
- Event Grid の共同作成者
- Event Grid データ送信者


■データプレーンの組み込みロール

~~https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization~~
~~Event Grid トピックまたはドメインへのイベントの発行については、Event Grid は Azure RBAC をサポートしません。~~

Azure Active Directory を使用した認証と承認 (プレビュー)
https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-active-directory

- Event Grid データ送信者

■アクセスキー/SAS

アクセス キーを使用して認証する
https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-access-keys-shared-access-signatures#authenticate-using-access-key


アクセスキーは、HTTPヘッダー「aeg-sas-key: ...」またはクエリパラメータ「aeg-sas-key=...」で渡される。

SASトークンは、HTTPヘッダー「aeg-sas-token: ...」または「Authorization: SharedAccessSignature ...」で渡される。

アクセス キーまたは Shared Access Signature を使用して Azure Event Grid 発行クライアントを認証する
https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-access-keys-shared-access-signatures

アクセス キーを使用して Azure Event Grid カスタム トピックにイベントを公開する
https://docs.microsoft.com/ja-jp/azure/event-grid/post-to-custom-topic

キーと Shared Access Signature 認証の無効化
https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-active-directory#disable-key-and-shared-access-signature-authentication


■カスタムロールの作成例

https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization#custom-roles

■操作の種類

https://docs.microsoft.com/ja-jp/azure/event-grid/security-authorization#operation-types

Azure Event Grid でサポートされている操作の一覧を表示するには、次の Azure CLI コマンドを実行します。

```
az provider operation show --namespace Microsoft.EventGrid
```

■マネージドIDの割り当て


https://docs.microsoft.com/ja-jp/azure/event-grid/managed-service-identity


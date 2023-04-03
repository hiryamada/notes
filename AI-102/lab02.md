# ラボ02 Azure Key Vault

Cognitive Servicesに接続するための情報（特に「キー」などの機密情報）を格納するには、Key Vaultを使用する。

■サービスプリンシパルを作成する

```
az ad sp create-for-rbac --name sp1
```

生成されるサービスプリンシパルの情報の例:

```
{
  "appId": "7b4b4ec0-e211-49fc-b2ea-21dd5fb879db",
  "displayName": "sp1",
  "password": "vzd23792734924vjafa9sf7as97dfasdfas",
  "tenant": "f64d5a5d-e5ca-494a-81c4-079d331ac585"
}
```

Windowsの環境変数（ユーザー環境変数）として、上記の値をセットする。

| 環境変数の名前      | 環境変数の値             |
| ------------------- | ------------------------ |
| AZURE_TENANT_ID     | 上記出力の tenant の値   |
| AZURE_CLIENT_ID     | 上記出力の appId の値    |
| AZURE_CLIENT_SECRET | 上記出力の password の値 |

■Azure Key Vaultを作成する

- 「キーコンテナー」リソースを作成する
- サービスプリンシパルに、Azure Key Vaultのシークレットを読み取るアクセス許可を与える
- 開発者に、Azure Key Vaultのシークレットを読み取るアクセス許可を与える

■Cognitive Servicesアカウントを作成する

※ここでは、前のラボで作成した「Cognitive Servicesマルチサービスアカウント」をそのまま利用する。

■Cognitive Servicesアカウントの情報をKey Vaultのシークレットとして書き込む

| シークレットの名前                   | 値                               |
| ------------------------------------ | -------------------------------- |
| CognitiveServices:SubscriptionKey    | キー                             |
| CognitiveServices:Name               | Cognitive Servicesリソースの名前 |
| CognitiveServices:Endpoint           | エンドポイント                   |
| CognitiveServices:SubscriptionRegion | リージョン（場所/地域）          |

■コードを開発する

基本的に ラボ01 のコードとほぼ同様。

https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets/


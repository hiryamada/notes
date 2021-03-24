# ラボ10 Key Vault / VM の Managed ID


## タスク1 キーコンテナーの作成

Azure portalの画面上部の検索で「キー コンテナー」（または「key」）と入力し、「キー コンテナー」を選択します。

「＋新規」をクリックします。

以下を指定します。「999999」の部分は、キーボードから数値を適当に打ち込み、重複しない名前を作ります。Key Vault 名はコピーし、メモ帳などに貼り付けて記録しておきます。

- リソースグループ: 新規作成, LAB10RG
- Key Vault 名: mykeyvault999999
- 地域: 米国東部

「次へ: アクセスポリシー」をクリックします。

「ユーザー」に、自分のユーザー名が表示され、キー/シークレット/証明書に対するアクセスが与えられていることを確認します。（プルダウンをクリックすると、各操作にチェックボックスが付いています）

「確認及び作成」、「作成」をクリックします。

デプロイが完了したら「リソースに移動」をクリックします。

## タスク2 シークレットの登録

ここでは、キーコンテナーに新しいシークレット（名前と値）を登録します。

設定セクションの「シークレット」をクリックします。

「＋生成/インポート」をクリックします。

以下を指定します。値は「●●●●●」のようにマスクされて表示されます。

- 名前: key1
- 値: hello

「作成」をクリックします。

## タスク3 Cloud Shell から、シークレットを読み込む

Cloud Shell を開きます。Bash に切り替えます。

Key Vaultの名前を変数に格納します。以下のコマンドを打ち込みます。以下の「mykeyvault999999」の部分は、先ほど記録したキーコンテナーの名前とします。

```
VAULT_NAME='mykeyvault999999'
```

シークレットの値を読み取ります。

```
az keyvault secret show \
    --vault-name $VAULT_NAME \
    --name key1
```

すると以下のようなJSONが表示されます。

```
{
  "attributes": {
    "created": "2021-03-24T14:05:21+00:00",
    "enabled": true,
    "expires": null,
    "notBefore": null,
    "recoveryLevel": "Recoverable+Purgeable",
    "updated": "2021-03-24T14:05:21+00:00"
  },
  "contentType": null,
  "id": "https://mykeyvault812341432.vault.azure.net/secrets/key1/6cf57a9b9c6041dea0934fbcc0126b9a",
  "kid": null,
  "managed": null,
  "name": "key1",
  "tags": null,
  "value": "hello"
}
```

この出力中に「"value":"hello"」という、シークレットの名前と値が含まれていることを確認します。

## タスク4 VM を起動し、SSHで接続する

azコマンドを使用して、Linux VM (OS: Debian Linux)を起動します。

名前は「vm1」となります。

```
az vm create \
    -n vm1 \
    -g LAB10RG \
    -l eastus \
    --image debian \
    --generate-ssh-key \
    --assign-identity
```

「--assign-identity」オプションは、このVMに「マネージドID」を割り当てます。

「--generate-ssh-key」オプションは、SSH接続のためのキーペアを生成します。秘密鍵は `~/.ssh/` 以下に自動的に追加されます。

VMの起動まで、1分ほどかかります。表示されたIPアドレス(publicIpAddress)をコピーしておきます。

VMにSSH接続します。以下の「1.2.3.4」の部分は、コピーしたIPアドレスとします。

```
ssh 1.2.3.4
```

すると以下の様な表示が出ます。「yes」と入力します。
```
The authenticity of host '20.185.147.121 (20.185.147.121)' can't be established.
ECDSA key fingerprint is SHA256:WfhATSZtAgLyJIDWaZkc0cKNJPk/2NKCqrZ0tQxbG7o.
Are you sure you want to continue connecting (yes/no)?
```

SSH接続が完了すると以下のような表示（一部）と、「ユーザー名@vm1:~$」というプロンプトが表示されます。

**このプロンプトが出ている間、コマンドはvm1上で実行されます。**

```
Debian GNU/Linux comes with ABSOLUTELY NO WARRANTY, to the extent
permitted by applicable law.
user@vm1:~$
```

## タスク5 Azure CLIをインストール

起動したDebian Linuxには、デフォルトではAzure CLIがインストールされていません。

Azure CLIをインストールして、az コマンドを使えるようにします。[参考](https://docs.microsoft.com/ja-jp/cli/azure/install-azure-cli-linux?pivots=apt)

```
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
```

インストールされたかどうか確認します。
```
az version
```

正しくインストールされた場合、以下のような出力が得られます。
```
{
  "azure-cli": "2.21.0",
  "azure-cli-core": "2.21.0",
  "azure-cli-telemetry": "1.0.6",
  "extensions": {}
}
```
## タスク6 AZ CLI と Managed ID を使ってサインイン（ログイン）する

azコマンドを使用する場合は、事前にサインイン（ログイン）が必要です。

（Azure portalの中のCloud Shellの場合は、Cloud Shellを起動した際に、現在のユーザーでサインインが自動的に行われる仕組みになっていますので、サインインは不要でした）

まずは以下のコマンドを打ち込みます。
```
az login --help
```

ヘルプが表示されます。以下の部分の記述から、`--identity`オプションで、VMに割り当てられたID（マネージドID）でサインインできることがわかります。
```
    Log in using a VM's system assigned identity
        az login --identity
```

では、以下のコマンドを打ち込みます。
```
az login --identity
```

しかし、以下のようなエラーが表示されます。
```
No access was configured for the VM, hence no subscriptions were found. If this is expected, use '--allow-no-subscriptions' to have tenant level access.
```

サブスクリプション（のなかのいずれかのリソース）に対するアクセス権がない場合、このようなエラーが表示されます。

## タスク7 VMのマネージドIDに、キーコンテナーの読み取り権限を与える

ここでは、VM1が、サブスクリプション（の中のキーコンテナー）に対する読み取りができるように、Azure RBACロールを割り当てます。

Azure portalのキーコンテナーの画面で、左側のナビゲーションの「アクセス制御（IAM）」をクリックします。

「＋追加」、「ロールの割り当ての追加」とクリックします。

「役割」プルダウンで「キー コンテナー閲覧者」を選択します（プルダウンをクリックして表示される検索ボックスに「キー」と入力して絞り込むと選択しやすくなります）。

「選択」テキストボックスに「vm1」と入力し、その下に表示された「vm1」をクリックします。「vm1」が「選択したメンバー」に表示されます。

「保存」をクリックします。

再度、Cloud Shellで以下のコマンドを打ち込みます。
```
az login --identity
```

すると、今度は無事にサインイン（ログイン）が完了し、以下のような出力が得られます。

```
[
  {
    "environmentName": "AzureCloud",
    "homeTenantId": "bc33670f-3e01-425a-bba8-5dee00a7b758",
    "id": "348b33ca-5dd6-445f-9bee-acf711010c23",
    "isDefault": true,
    "managedByTenants": [],
    "name": "Azure Pass - スポンサー プラン",
    "state": "Enabled",
    "tenantId": "bc33670f-3e01-425a-bba8-5dee00a7b758",
    "user": {
      "assignedIdentityInfo": "MSI",
      "name": "systemAssignedIdentity",
      "type": "servicePrincipal"
    }
  }
]
```
これは、コマンドの操作対象のサブスクリプションを表しています。

続いて、キーコンテナーの一覧を取得します。

```
az keyvault list
```

すると以下のような出力が得られます。
```
[
  {
    "id": "/subscriptions/348b33ca-5dd6-445f-9bee-acf711010c23/resourceGroups/LAB10RG/providers/Microsoft.KeyVault/vaults/mykeyvault812341432",
    "location": "westus2",
    "name": "mykeyvault812341432",
    "resourceGroup": "LAB10RG",
    "tags": {},
    "type": "Microsoft.KeyVault/vaults"
  }
]
```
作成済みのキーコンテナーの情報が取得できました。

## タスク8 Key Vault からのシークレットの読み込み(1回目)

続いて、キーコンテナーからシークレットを読み込みます。

まず、Key Vaultの名前を変数に格納します。以下のコマンドを打ち込みます。以下の「mykeyvault999999」の部分は、先ほど記録したキーコンテナーの名前とします。

```
VAULT_NAME='mykeyvault999999'
```

続いて、以下のコマンドを使って、シークレット「key1」を読み取ります。
```
az keyvault secret show \
    --vault-name $VAULT_NAME \
    --name key1
```

しかし、以下のようなエラーとなります。
```
The user, group or application 'appid=9e2606b1-79bc-4688-8ff6-dbaa031a0194;oid=39f325c3-83cf-419b-9cf1-0164ac42fe52;iss=https://sts.windows.net/bc33670f-3e01-425a-bba8-5dee00a7b758/' does not have secrets get permission on key vault 'mykeyvault812341432;location=westus2'. For help resolving this issue, please see https://go.microsoft.com/fwlink/?linkid=2125287
```

このメッセージから、「secret」の「get」の権限がない、ということがわかります。

この権限は、キーコンテナー内の「アクセスポリシー」から追加する必要があります。

## タスク9 アクセスポリシーを追加する

vm1が、シークレットの取得ができるように、アクセスポリシーを追加します。

Azure portalのキーコンテナーの画面で、左側のナビゲーションの「アクセス ポリシー」をクリックします。

「+ アクセス ポリシーの追加」をクリックします。

以下のように入力します。

- シークレットのアクセス許可: 「取得」にチェックします
- プリンシパルの選択: 「選択されていません」をクリックし、検索ボックスに「vm1」と入力してvm1をクリックします。「選択したアイテム」にvm1が表示されます。「選択」をクリックします。

「追加」をクリックします。

**最後に、画面の上の方にある「保存」をクリックします。**

## タスク10 Key Vault からのシークレットの読み込み(2回目)

再度、キーコンテナーからシークレットを読み込みます。

以下のコマンドを使って、シークレット「key1」を読み取ります。
```
az keyvault secret show \
    --vault-name $VAULT_NAME \
    --name key1
```

今度は、
```
{
  "attributes": {
    "created": "2021-03-24T14:05:21+00:00",
    "enabled": true,
    "expires": null,
    "notBefore": null,
    "recoveryLevel": "Recoverable+Purgeable",
    "updated": "2021-03-24T14:05:21+00:00"
  },
  "contentType": null,
  "id": "https://mykeyvault812341432.vault.azure.net/secrets/key1/6cf57a9b9c6041dea0934fbcc0126b9a",
  "kid": null,
  "managed": null,
  "name": "key1",
  "tags": null,
  "value": "hello"
}
```

プロンプトが「ユーザー名@vm1:~$」になっているので、このコマンドはCloud Shellではなく、vm1上で実行されました。
つまり、**vm1上で、シークレットを読み取ることができました。**

## タスク11 クリーンアップ

現在、SSHでvm1に接続しています。SSH接続を切ります。
```
exit
```

以下のような出力により、SSH接続が切断され、Cloud Shellの操作に戻ったことが確認できます。（ `@Azure` に着目）
```
logout
Connection to 20.185.147.121 closed.
user@Azure:~$
```

以下のコマンドで、LAB10RGリソースグループとその内部のリソースをすべて削除します。

```
az group delete -n LAB10RG -y
```

Cloud Shellを閉じます。

このラボは以上です。お疲れさまでした！



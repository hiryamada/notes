# マネージドID

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview

参考: マネージドIDをサポートするAzureサービス
https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/managed-identities-status


マネージドIDは、Azure VM（仮想マシン）、Azure App Service、Azure FunctionsなどのAzureリソースに対して割り当てが可能なID。

マネージドIDは、簡単に作成・割り当てができる。サービスプリンシパルとは違い、IDやパスワードなどの文字列を設定するといった運用が不要。

基本的に、Azure上で稼働するアプリでは、サービスプリンシパルではなくマネージドIDを使う。

たとえば、Azure VM内で稼働するアプリが、ストレージアカウントに接続してファイル（Blob）を読み書きする場合、Azure VMにマネージドIDを割り当てる。そして、そのマネージドIDに対し、ファイル（Blob）を読み書きできる権限（ロール）を割り当てる。これによって、Azure VM（の中で動くアプリ）は、マネージドIDを使用して認証を行い、割り当てられたロールの権限で、ファイル（Blob）の読み書きが可能となる。

```
ストレージアカウント(app1＝ストレージBlobデータ共同作成者)
↑
Azure VM ← マネージドID(app1)
└アプリ
```


■ マネージドIDの種類

- システム割り当てマネージドID: 対応するリソースで「有効化」する
- ユーザー割り当てマネージドID: 単体で作成し、リソースに「関連付け」する

「システム割り当てマネージドID」は、App Service、Azure Functions、VMなどのリソースの作成時または作成後に、そのリソースで「システム割り当てマネージドIDを有効化」することで付与される、リソース固有のIDです。リソースを削除すれば、そのリソースのシステム割り当てマネージドIDも同時に削除される。


```
App Service アプリ1 (app1)
└システム割り当てマネージドID (app1)
App Service アプリ2 (app2)
└システム割り当てマネージドID (app2)
```

この2つが、あるストレージアカウントにアクセスする場合、それぞれのIDに対し、ロールを割り当てる。

```
ストレージアカウント
├app1: ストレージBlobデータ共同作成者
└app2: ストレージBlobデータ共同作成者
```

一方「ユーザー割り当てマネージドID」は、Azureリソースの一種であり、単体で作成できる。

```
App Service アプリ1 (id1)
├ユーザー割り当てマネージドID1 (id1)
App Service アプリ2 (id1)
```

これらの2つのアプリがあるストレージアカウントにアクセスする場合、それらが使用しているユーザー割り当てマネージドID`id1`に対し、ロールを割り当てる。

```
ストレージアカウント
└id1: ストレージBlobデータ共同作成者
```

また、1つのアプリに複数のユーザー割り当てマネージドIDを関連付けることも可能。以下の図で、アプリ1は id1, id2 という2つのIDを持つ。

```
App Service アプリ1 (id1,id2)
├ユーザー割り当てマネージドID1 (id1)
└ユーザー割り当てマネージドID2 (id2)
```

■参考: Azure Arc（Azure外で稼働するサーバーにマネージドIDの割り当てが可能）
https://docs.microsoft.com/ja-jp/azure/azure-arc/servers/managed-identity-authentication

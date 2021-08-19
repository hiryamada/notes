# マネージドID

アプリケーションは、マネージド ID を使用して Azure AD トークンを取得し、Key Vaultなどにアクセスすることができる。

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview

2017/9/14 プレビュー（当初「Managed Service Identity」、MSIと呼ばれていた）https://azure.microsoft.com/ja-jp/blog/keep-credentials-out-of-code-introducing-azure-ad-managed-service-identity/

[マネージドID は、以前の「Managed Service Identity」 (MSI) の新しい名前。](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview)

[わかりやすい解説](https://blog.azure.moe/2017/09/21/managed-service-identity-preview/)



■概要

マネージドID によって、VMなどのリソースに、IDを割り当てることができる。

Azure RBACロールを使用して、IDに、必要な権限を付与できる。

VM内で稼働するプログラムでは、ロールで付与された権限を使用して、Azure Key Vaultなどのサービスにアクセスすることができる。

```
VM1のマネージドID ← 「Key Vault Secrets User」ロール
↓
VM + C#等のプログラム
       ↓
    Key Vault
```

マネージドIDは、「セキュリティ プリンシパル」の一種であり、また、「サービス プリンシパル」の一種でもある。

```
セキュリティ プリンシパル
├ユーザー
├グループ
└サービス プリンシパル
  └マネージドID
```

サービスプリンシパルとマネージドIDの共通点:

- セキュリティプリンシパルの一種である
  - ロールの割り当てができる
  - Azure AD認証をサポートする任意のリソースにアクセスできる
    - ストレージアカウントのBlob、Queue、Table
    - Azure Key Vault
    - など
- コストはかからない

サービスプリンシパルとマネージドIDの異なる点:

- サービスプリンシパル
  - 認証情報(クライアントID/シークレット)を管理する必要がある
  - 資格情報をローテーション（更新）する必要がある
  - Azure外でも利用できる
- マネージドID
  - 認証情報を管理する必要がない
  - 資格情報は自動でローテーションされる
  - Azure上の、マネージドIDに対応するリソース(VM等)でのみ利用できる

マネージドIDが使える状況では常にマネージドIDを使うべき。


■マネージドIDが使えるAzureのサービス

[Azure リソースのマネージド ID をサポートするサービス](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities)

主なもの:

- VM
- VMSS
- API Management
- App Service
- ACI
- ACRタスク
- Functions
- AKS
- Logic Apps

■マネージドIDの種類

- システム割り当てマネージドID
  - 特定のリソースに固有のID
  - 複数のリソースに割り当てることはできない
  - リソースを削除するとIDも一緒に削除される
- ユーザー割り当てマネージドID
  - リソースとは独立したID
  - 複数のリソースに割り当てることができる
  - リソースを削除してもIDは削除されない

■「システム割り当てマネージドID」の利用例

利用例(1):

```
App Serviceアプリ1 の システム割り当てマネージドID ← ロール
↓
App Serviceアプリ1
```

利用例(2):

```
関数アプリ1 の システム割り当てマネージドID ← ロール
↓
関数アプリ1
```

利用例(3):
```
VM1 の システム割り当てマネージドID ← ロール
↓
VM1

VM2 の システム割り当てマネージドID ← ロール
↓
VM2
```

※VM1,2それぞれで「システム割り当てマネージドID」を作る必要がある。また、それぞれの「システム割り当てマネージドID」にロールを割り当てる必要がある。

■「ユーザー割り当てマネージドID」の利用例

```
ユーザー割り当てマネージドID ← ロール
↓        ↓
VM1      VM2
```

※複数のVM等に同じロールを割り当てする場合は「ユーザー割り当てマネージドID」のほうが便利。


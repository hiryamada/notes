
# ユーザー

- クラウドID
- ディレクトリ同期ID
- ゲストユーザー

# グループ

- セキュリティグループ
- Office 365グループ


■グループへのメンバーの追加

- 割り当て済み
- 動的ユーザー
- 動的デバイス

# サービス プリンシパル

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/app-objects-and-service-principals#service-principal-object

アプリやサービスを表すID。

```
Azure ADの「プリンシパル」
├ ユーザー
├ グループ
└ サービス プリンシパル
  └ マネージドID
```

サービス プリンシパルは、テナント内のリソースへのアクセスを許可するために利用される。

■サービス プリンシパルの作成: Azure portalから

Azure ADで「アプリの登録」を行うと「サービス プリンシパル」が作成される。

■サービス プリンシパルの作成: Azure CLIから

https://docs.microsoft.com/ja-jp/cli/azure/ad/sp

- az ad sp create: サービスプリンシパルを作成する
- az ad sp create-for-rbac: サービスプリンシパルを作成し、RBACロールを割り当てる

■サービス プリンシパルの作成: Azure PowerShellから

https://docs.microsoft.com/ja-jp/powershell/azure/create-azure-service-principal-azureps

- New-AzADServicePrincipal: サービスプリンシパルを作成する
- New-AzRoleAssignment: RBACロールを割り当てる

# Azure AD B2B (Business-to-Business)

他の組織のユーザーをゲストとして招待する機能。

他の組織のユーザーに、自分の組織で管理しているアプリケーションへのアクセスを許可することができる。

# Azure AD B2C (Business-to-Consumer)

アプリケーションに、顧客（一般ユーザー）のサインイン機能を追加するためのしくみ。

顧客（一般ユーザー）は、以下のアカウントを使用して、アプリケーションにサインインすることができる。

- ソーシャル アカウント(Google, Twitter, Facebook等)
- エンタープライズ(Azure AD等)
- ローカル アカウント ID(メールアドレス/電話番号/任意のID ＋ パスワード) 

[別ページで解説](mod01-aad-b2c.md)


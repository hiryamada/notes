
# ユーザー

テナントの中に作成されるユーザーの種類

- クラウドID
  - Azure ADテナントに直接[登録](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-users-azure-active-directory?context=/azure/active-directory/enterprise-users/context/ugr-context)されたユーザー
- ディレクトリ同期ID
  - オンプレミスのAD DSに登録され、Azure AD Connectで同期されたユーザー
- ゲストユーザー
  - テナント外で管理され、テナントに[招待](https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/b2b-quickstart-add-guest-users-portal)されたユーザー。


# グループ

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-groups-create-azure-portal?context=/azure/active-directory/enterprise-users/context/ugr-context#group-types

テナントの中に作成されるグループの種類。

- セキュリティグループ
- [Office 365グループ](https://docs.microsoft.com/ja-jp/microsoft-365/admin/create-groups/office-365-groups?view=o365-worldwide)


■グループへのメンバーの追加

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-groups-create-azure-portal?context=/azure/active-directory/enterprise-users/context/ugr-context#membership-types

- 割り当て済み
  - グループに直接割り当てされたユーザー
- 動的ユーザー
  - 「[動的メンバーシップ ルール](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-create-rule)」を使用してグループに自動的に追加されたユーザー。
  - セキュリティ グループまたは Microsoft 365 グループに対して、動的メンバーシップがサポートされる
- 動的デバイス
  - 「動的なグループ ルール」を使用して、グループに自動的に登録されたデバイス。

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



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

サービス プリンシパルは、オンプレミス（Azureの外側）で動作するプログラムやサービスに割り当てるためのID。テナント内のリソースへのアクセスを許可するために利用される。

■サービス プリンシパルの作成: Azure portalから

Azure ADで「アプリの登録」を行うと「サービス プリンシパル」が作成される。

■サービス プリンシパルの作成: Azure CLIから

https://docs.microsoft.com/ja-jp/cli/azure/ad/sp

- az ad sp create: サービスプリンシパルを作成する
- az ad sp create-for-rbac: サービスプリンシパルを作成し、RBACロールを割り当てる

■ハンズオン: サービスプリンシパルの作成と削除

- Azure portalのトップ画面の画面下部の「サブスクリプション」をクリック
- Azure Passサブスクリプションの「サブスクリプションID」をコピーしておく
- 画面上部の検索ボックスの右側のアイコン（Cloud Shell）をクリック
- 画面下部に「Azure Cloud Shell へようこそ」が出てきた場合は、「Bash」、「ストレージの作成」をクリック
- 「Azure Cloud Shell へようこそ」が出ない場合は、画面下部の黒い部分の左上のプルダウンで「Bash」を選択
- `az ad sp create-for-rbac --scope /subscriptions/（サブスクリプションのID） --role 'Storage Blob Data Reader'` を実行する。
- 画面に、appId, displayName, password, tenantが表示されることを確認。
  - オンプレミスで動作するプログラムに対して、この認証情報を設定ファイルのような形で割り当てる（今回は省略）。
    - この認証情報を使用して、Azure ADで認証を行う。
    - IDに割り当てられたロールにより、ストレージアカウントのBlobデータの読み取りができる。
- `az ad sp delete --id (表示されたappId)` で、作成したサービスプリンシパルを削除。

■サービス プリンシパルの作成: Azure PowerShellから

https://docs.microsoft.com/ja-jp/powershell/azure/create-azure-service-principal-azureps

- New-AzADServicePrincipal: サービスプリンシパルを作成する
- New-AzRoleAssignment: RBACロールを割り当てる

# Azure AD B2B (Business-to-Business)

他の組織のユーザーをゲストとして招待する機能。

他の組織のユーザーに、自分の組織で管理しているアプリケーションへのアクセスを許可することができる。

参考:
- ゲストユーザー追加
  - Azure portalから: https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/b2b-quickstart-add-guest-users-portal
  - PowerShellから: https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/b2b-quickstart-invite-powershell
    - CSVを使用して、一括で多数のユーザーを招待する: https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/bulk-invite-powershell
- セルフサービスサインアップについて
  - https://cloudsteady.jp/post/3912/
  - https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/directory-self-service-signup
  - https://azure.microsoft.com/ja-jp/updates/unmanaged-accounts-b2b-update/
- アンマネージドテナントかどうかの確認
  - https://docs.microsoft.com/ja-jp/power-automate/gdpr-dsr-delete#delete-the-user-from-unmanaged-tenant
- Azure における ゲスト ユーザー招待 (B2B) のよくある質問(by Azure Identity サポート チーム)
  - https://jpazureid.github.io/blog/azure-active-directory/b2bfaq/
- B2Bのトラブルシューティング
  - https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/troubleshoot

# Azure AD B2C (Business-to-Consumer)

アプリケーションに、顧客（一般ユーザー）のサインイン機能を追加するためのしくみ。

顧客（一般ユーザー）は、以下のアカウントを使用して、アプリケーションにサインインすることができる。

- ソーシャル アカウント(Google, Twitter, Facebook等)
- エンタープライズ(Azure AD等)
- ローカル アカウント ID(メールアドレス/電話番号/任意のID ＋ パスワード) 

[別ページで解説](mod01-08-aad-b2c.md)


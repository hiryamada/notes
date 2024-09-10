# ラボ1 補足

  - 「GitHubからファイルをダウンロード」はスキップ。このラボではファイルは使用しません
  - 演習1 Azure portalによるユーザー作成、グループ作成、グループへのユーザー追加
    - タスク1（ユーザー Joseph の作成）はスキップ。
    - ※このラボ環境では、ユーザーの新規作成はできません。
    - Joseph-xxxxxx@LODSPRODMCA.onmicrosoft.com といったユーザーが作成されていますのでそれを使用します。画面右上「リソース」タブで確認できます。
  - 演習2 Azure PowerShellによるユーザー作成、グループ作成、グループへのユーザー追加
    - タスク1の5: `Connect-MgGraph -Scopes "User.ReadWrite.All"`
    - To sign in, use a web browser to open the page https://microsoft.com/devicelogin and enter the code NNNNNNNN to authenticate といったメッセージが表示されますので、それに従ってWebブラウザーで上記ページにアクセスし、コードを入力します。
    - タスク1の7を実行する前に、`Install-Module Microsoft.Graph -Scope CurrentUser` を実行して、New-MgUser や Get-MgUser コマンドが実行できるようにします。
    - タスク1の7（ユーザー Isabel の作成）も同様にスキップ。
  - 演習3 Azure CLIによるユーザー作成、グループ作成、グループへのユーザー追加
    - タスク1（ユーザー Dylan の作成）も同様にスキップ。
  - 演習4 リソースグループの作成、Entra IDグループへのロールの割り当て
  - 「リソースのクリーンアップ」はスキップします。


## （講師デモ）ユーザー作成の例

Azure Cloud Shellで、Azure PowerShell（Microsoft Graph PowerShell）を使用して、ユーザーを作成する例。

ユーザー名を生成

```pwsh
$userName = "taro$(Get-Random -Minimum 9999)"
$domain = (Get-AzTenant).Domains
$upn = "$userName@$domain"
echo $upn
```

パスワードを生成

```pwsh
$PasswordProfile = @{ Password = "UserPassword#%&$(Get-Random -Minimum 9999)" }
echo $PasswordProfile
```

必要なモジュール（Microsoft.Graph）を追加

```pwsh
Install-Module Microsoft.Graph -Scope CurrentUser -Repository PSGallery -Force
```

Microsoft Graphのユーザー操作に必要なトークンを取得

```pwsh
Connect-MgGraph -Scopes "User.ReadWrite.All"
```

ユーザーを作成

```pwsh
New-MgUser `
-DisplayName $userName `
-MailNickName $userName `
-PasswordProfile $PasswordProfile `
-UserPrincipalName $upn `
-AccountEnabled:$false
```

## （講師デモ）グループ作成の例

Azure Cloud Shellで、Azure PowerShell（Microsoft Graph PowerShell）を使用して、グループを作成する例。


グループ名を生成

```pwsh
$groupName = "group$(Get-Random -Minimum 9999)"
echo $groupName
```

Microsoft Graphのグループ操作に必要なトークンを取得

```pwsh
Connect-MgGraph -Scopes "Group.ReadWrite.All"
```

グループを作成

```pwsh
New-MgGroup `
-DisplayName $groupName `
-MailNickName $groupName `
-SecurityEnabled `
-MailEnabled:$false
```

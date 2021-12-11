# 認証と認可


## 開発者がAzure DevOps/GitHubにサインインのためのアカウント

- Azure DevOps Services
  - Microsoft アカウント、GitHub アカウント、または Azure Active Directory (AAD) のいずれかを使用
- GitHub
  - GitHubアカウントを使用

## 外部のサービスやツールがAzure DevOpsやGitHubにアクセスするための認証

- Azure DevOps
  - [SSH認証](https://docs.microsoft.com/ja-jp/azure/devops/repos/git/use-ssh-keys-to-authenticate)
  - [Git Credential Manager コア](https://docs.microsoft.com/ja-jp/azure/devops/repos/git/set-up-credential-managers)
  - 個人用アクセストークン（PAT: Personal Access Token）
    - 外部ツールからAzure DevOpsに接続する場合に利用することがある。
    - 例：[GitHub Desktop](https://desktop.github.com/) から、[Azure DevOpsに接続](https://blog.beachside.dev/entry/2021/05/17/083000)
- GitHub
  - 個人用アクセストークン（PAT: Personal Access Token）
    - GitHub API またはコマンドラインを使用するときに GitHub への認証でパスワードの代わりに使用
    - https://docs.github.com/ja/github/authenticating-to-github/keeping-your-account-and-data-secure/creating-a-personal-access-token


## Azure DevOpsのセキュリティグループ

ユーザーがAzure DevOps内で実行可能な操作は、[セキュリティグループ](https://docs.microsoft.com/ja-jp/azure/devops/organizations/security/change-individual-permissions)で設定できる。デフォルトのセキュリティグループが定義されている。カスタムのセキュリティグループも定義可能。

たとえば「共同作成者」セキュリティグループのメンバーであるユーザーは、プロジェクトの Wiki ページを追加または編集することができる。

- 組織レベルの設定
  - Azure DevOps / Project Settings / Neneral - Permissions / Groups
- プロジェクトレベルの設定
  - Azure DevOps / Organization Settings / Security - Permissions / Groups

## 多要素認証

※Azure DevOpsの機能ではなく、Azure ADの機能。

Azure ADのユーザーは、Azure ADを使用してサインインを完了し、Azure DevOpsにアクセスする。

ユーザーがAzure ADにサインインする際に[Azure AD の MFA](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/howto-mfa-getstarted)を利用することを強制することができる。

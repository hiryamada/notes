# Azure DevOps

https://azure.microsoft.com/ja-jp/services/devops/

## Azure DevOpsの概要

- [→Azure DevOpsの概要](pdf/Azure%20DevOpsの概要.pdf)
- [→Azure DevOpsの機能の連携](pdf/Azure%20DevOps機能の連携.pdf)

```
Azure DevOpsの画面 (dev.azure.com)
└Azure DevOps組織 ←ユーザー
 └プロジェクト - 概要, wiki, dashboard
  ├Azure Boards - 「エピック」,「作業項目」,「タスク」
  ├Azure Repos リポジトリ
  ├Azure Pipelines パイプライン
  └Azure Artifacts フィード
※ユーザー：Azure ADユーザー, Microsoftアカウント, GitHubアカウント
```

## ユーザーの追加(招待)

Azure DevOpsでは、以下の種類のユーザーを追加(招待)することができる。

- 「Azure DevOps組織」がAzure ADに接続されている場合:
  - Azure ADユーザー(組織のユーザー)のメールアドレス
- 「Azure DevOps組織」がAzure ADに接続されていない場合:
  - 個人のMicrosoftアカウントのメールアドレス
  - GitHubユーザー名

```
Azure Active Directory (Azure AD)を使用してユーザーを認証し、組織のアクセスを制御する予定がない場合は、GitHub アカウントの個人用 Microsoft アカウントと id の電子メールアドレスを追加します。 ユーザーが Microsoft または GitHub のアカウントを持っていない場合は、 Microsoft アカウント または github アカウントにサインアップするようにユーザーに依頼します。
```

■具体的な追加の流れ
- [→メンバーの追加（招待）](pdf/メンバーの追加（招待）.pdf)
  - 組織にメンバーを追加する方法

参考
- [チームメンバーの招待](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops#invite-team-members)
- [Azure DevOpsにおけるユーザーの管理](https://docs.microsoft.com/ja-jp/azure/devops/organizations/accounts/add-organization-users?view=azure-devops&tabs=preview-page)

## Azure DevOps が利用できる地域

「組織」を作成するときに、そのデータを保存する「地域」を指定する。

Azure DevOps は次の「地域」で利用できる。


- Australia
  - Australia East
- Brazil
  - Brazil South
- Canada
  - Canada Central
- Asia Pacific
  - East Asia(香港)
  - Southeast Asia(シンガポール)
- Europe
  - West Europe
- India
  - South India
- United Kingdom
  - UK South
- United States
  - Central US

※2021/12現在、Japan（日本）は選択肢にない。データを国内に置く必要がある場合は[→Azure DevOps Server](mod01-03-devops-server.md)を使用。


■地域の指定

組織の作成時に、地域を指定する。

地域の変更は画面上からはできないが、以下の画面から問い合わせを行って変更することができる。

https://azure.microsoft.com/ja-jp/support/devops/


## ラボ（ハンズオン演習）

- [Azure DevOpsの使用を開始する](pdf/Azure%20DevOpsの使用を開始する.pdf)
  - 組織とプロジェクトを作成する


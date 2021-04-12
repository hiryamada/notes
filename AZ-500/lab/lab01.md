# ラボ1 ユーザー/ロール

想定時間: 20min

Azure ADでのユーザー管理について学びます。

基本的に[ラボの手順書](https://microsoftlearning.github.io/AZ-500JA-AzureSecurityTechnologies/)を見ながら進めます。手順書はブックマークしておいてください。手順書の注意点や修正については下記「補足事項」を事前によくお読みください。


事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-500JA-AzureSecurityTechnologies/archive/master.zip)をダウンロードして展開しておきましょう。

## ラボの重要ポイント

- 演習1 Azure Portalを使用してユーザーを作成します。
- 演習2 PowerShellを使用してユーザーを作成します。
- 演習3 AZ CLIを使用してユーザーを作成します。
- 演習4 グループにロールを割り当てます。グループに属するユーザーにロールが割り当てされることを確認します。

## 補足事項

### 演習1

タスク1-6


`「`, `」` を `[`, `]` としてください。（下記のコマンドを実行してください）
```
$domainName = ((Get-AzureAdTenantDetail).VerifiedDomains)[0].Name
```

### 演習3

タスク2-4

`「`, `」` を `[`, `]` としてください。（下記のコマンドを実行してください）

```
OBJECTID=$(echo $USER | jq '.[].objectId' | tr -d '"')
```

### 演習4

タスク1-2 

場所: East US → 「(US)米国東部」

タスク2-4

選択 サービスデスク → Service Desk

タスク2-8

検索結果の一覧で、Dylan Williams のユーザー アカウントを選択し、「Dylan Williams の割り当て - AZ500Lab01」 ブレードで、新しく作成された割り当てを表示します。→ Dylanは「Service Desk」に所属しており、「Service Desk」には「仮想マシンの共同作成者」ロールを割り当てたので、Dylanもそのロールを使用できます（アクセス権を持ちます）。

タスク2-10

最後の 2 つの同じ手順を繰り返して、Joseph Price のアクセス権を確認します。  → Josephは「Service Desk」に所属していないので、「仮想マシンの共同作成者」ロールは使用できません（アクセス権を持ちません）。

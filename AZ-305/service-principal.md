# サービスプリンシパル

「サービスプリンシパル」は、（ユーザーがサインインに使用するIDではなく）アプリ、サービス、Azureのリソースなどに割り当てるID。

■サービスプリンシパルの利用例

たとえば、GitHub Actionsを使用して、GitHubのソースコードをAzure App Serviceにデプロイしたい場合は、サービスプリンシパルを作り、それに必要な権限（ロール）を割り当てた上で、GitHubリポジトリに「シークレット」として設定する。

```
サブスクリプション(sp1=共同作成者)
└リソースグループ
  └Azure App Service
   ↑ App Serviceにコードをデプロイ
GitHub Actions ← サービスプリンシパル(sp1)
↑ アクションを実行
GitHubリポジトリ
↑ コードをプッシュ
開発者
```

■サービスプリンシパルの作成

サービスプリンシパルは、`az ad sp create-for-rbac` といったコマンドで作成できる。

```
az ad sp create-for-rbac --name サービスプリンシパル名 --role Contributor --scope /subscripions/サブスクリプションID
```

ただし、それにともなって生成されるIDやパスワードなどの文字列を適切な場所（アプリを運用する環境の環境変数など）に設定して運用しなければならないため、運用には若干手間がかかる → Azure環境では、「サービスプリンシパル」の代わりに「マネージドID」を使用すると便利。



# 設定値や機密情報の扱い方

- アプリケーションにおける設定値や機密情報の適切な扱い方とは。
- サービスプリンシパルとは。
- マネージドIDとは。
- Azure Key Vaultとは。
- Azure App Configurationとは。

## アプリケーション構成データの再考

### アプリケーション構成データの再考

機密情報はファイルに書き込まないようにしましょう。

### 懸念事項の分離

アプリケーションにおける設定値や機密情報の適切な扱い方とは。

「設定値や機密情報を設定する管理者」と「設定値や機密情報の利用者」に分けて運用することで、セキュリティを高めることができる。
- 管理者は、設定値や機密情報を一元的に管理する。
- 利用者は、設定値や機密情報を直接取り扱う必要がなくなる。

※この資料における「構成」とはConfiguration（設定）のこと。

例として、以下のような「構成」が考えられる。
- 開発環境では「DBServer=dev.consoto.com」
- 本番環境では「DBServer=prod.consoto.com」

※この資料における「ストア（Store）」とは、構成情報や機密情報を一元的に格納するサービスを表す。具体的には以下のようなサービス。

- [Azure App Configuration](https://azure.microsoft.com/ja-jp/services/app-configuration/) - アプリケーション構成情報を管理する「構成ストア」
- [Azure Key Vault](https://azure.microsoft.com/ja-jp/services/key-vault/) - 機密情報を管理する「シークレットストア」

- 構成管理者
  - 構成の生成・維持を担当する人。
  - 構成ストア・シークレットストアの管理
  - 構成、シークレットの管理
- 構成コンシューマ
  - 構成を読み取って利用するプログラム。
- 構成ストア
  - 構成情報を一元管理するサービス。App Configurationなど
- シークレットストア
  - アクセスキーなどの機密情報を一元管理するサービス。Key Vaultなど。

### 外部構成ストア パターン

[Microsoft Azure Well-Architected Frameworkの「外部構成ストア」パターン](https://docs.microsoft.com/ja-jp/azure/architecture/patterns/external-configuration-store)


> アプリケーション展開パッケージから、一元管理される場所に構成情報を移動します。 こうすることで、構成データの管理と制御が簡単になり、構成データをアプリケーションとアプリケーション インスタンス全体で共有できるようになります。


つまり、アプリケーションの設定を「設定ファイル」のような形でアプリケーション自身にもたせるのをやめて、外部の「構成ストア」から適宜設定値を読み込んで利用するようにする。読み込んだ設定値はアプリケーション側でキャッシュする。

この考え方は、[Twelve-Factor App](https://12factor.net/ja/)の「[III. 設定](https://12factor.net/ja/config)」でも触れられている。

※Twelve-Factor Appは、モダンなWebアプリケーションのためのベストプラクティス。

### Azure Key Vault と Azure Pipeline の統合

※Azure Key Vaultについては後述

機密情報はAzure PipelinesのYAMLの中に書いたり、リポジトリにプッシュしたりしないようにしましょう。

- Azure Key Vaultに機密情報（アクセスキーなど）を格納することができる
- Azure Pipelinesのパイプライン内で、Azure Key Vaultの機密情報を取り出して変数に入れることができる
  - [Azure Key Vaultタスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-key-vault?view=azure-devops)を使用する
- 変数の機密情報を、後続のタスクで利用できる。

## 秘密、トークン、および証明書を管理する

### シークレット、トークン、および証明書の管理

Azure Key Vaultとは。

[Key Vaultの講義ノート](../AZ-204/mod07-01-keyvault.md)を参照。

- 機密情報（キー、シークレット、証明書）の管理に特化。
- [FIPS 140-2](https://ja.wikipedia.org/wiki/FIPS_140)に対応した[HSM（ハードウェアセキュリティモジュール）](https://www.google.com/search?q=luna+sa+hsm&tbm=isch)を利用できる。

Key Vault周辺サービスとの比較については[まとめPDF](../AZ-204/pdf/mod07/キー管理サービス.pdf)を参照。

### DevOps の内側と外側のループ

（再掲）
「設定値や機密情報を設定する管理者」と「設定値や機密情報の利用者」に分けて運用することで、セキュリティを高めることができる。
- 管理者は、設定値や機密情報を一元的に管理する。
- 利用者は、設定値や機密情報を直接取り扱う必要がなくなる。

参考：[KubernetesとAzure key Vaultの利用](https://docs.microsoft.com/ja-jp/azure/key-vault/general/key-vault-integrate-kubernetes)


## ID 管理システムとの統合

AzureやGitHubにおけるID（認証）の管理方法

### サービス プリンシパル

サービスプリンシパルとは。

■サービスプリンシパルとは

サービス プリンシパルは、リソース/サービス レベルの**無人操作を実行する**目的でテナント内で作成する Azure Active Directory アプリケーション リソースです。

リソースへのアクセスや変更を行う必要があるアプリケーション、ホステッド サービス、または自動化されたツールがある場合は、アプリの ID を作成できます。この ID は、サービス プリンシパルと呼ばれます。

セキュリティ上の理由から、自動化ツールにはユーザー ID でのログインを許可するのではなく、常にサービス プリンシパルを使用することを推奨します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal)

■なぜここでサービスプリンシパル（やマネージドID）を学習するのか？

- Azure DevOpsのパイプライン内で、Azure key Vaultからパスワードを取得し、後続のタスクで使用する、といったシナリオで必要になるため。
- Azureのタスクをスクリプト等を使用して自動化・無人化する際に必要になるため。

■サービスプリンシパルの作成方法

- [Azure portal](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal)
- [Azure PowerShell](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell)
- [Azure CLI](https://docs.microsoft.com/ja-jp/cli/azure/create-an-azure-service-principal-azure-cli)

■サービスプリンシパルの利用

- [Azure PowerShell](https://docs.microsoft.com/ja-jp/powershell/azure/authenticate-azureps?view=azps-2.8.0#sign-in-with-a-service-principal)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/authenticate-azure-cli#sign-in-with-a-service-principal)
- .NET (Azure.Identityパッケージ)
  - [ClientCertificateCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.clientcertificatecredential?view=azure-dotnet)
  - [ClientSecretCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.clientsecretcredential?view=azure-dotnet)
- [Java](https://docs.microsoft.com/ja-jp/azure/developer/java/sdk/identity-service-principal-auth)
- [Python](https://docs.microsoft.com/ja-jp/azure/developer/python/azure-sdk-authenticate#using-serviceprincipalcredentials-azurecommon)

■サービスプリンシパルへのAzure RBACロールの割り当て

「サービスプリンシパル」に対して、RBACロールを設定して、Blobデータの読み書き、Key Vaultからのシークレットの利用などの権限を設定することができる。

## サービスコネクション（サービス接続）

「[サービスコネクション](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/library/service-endpoints?view=azure-devops&tabs=yaml)」: Azure Pipelinesから、外部サービスに接続するための設定。

たとえば、Azureのリソース（App Service等）を操作するための「サービスコネクション」を作ることができる。

```
Azure DevOps
├Azure Pipeline
│  ↓
└サービスコネクション (sc1)
Azure ADテナント  ↓
│└サービスプリンシパル (sp1)
│  └マネージドID (app1)
└サブスクリプション (sp1: 共同作成者）
  ├App Service アプリ (app1)
  ├Key Vault (app1: シークレットユーザー）
  │  └シークレット
  │     └ストレージアカウントの接続文字列
  │        ↓
  └ストレージアカウント
    └Blob
```


### 管理サービス ID → 「マネージドID」

※現在は管理サービス ID（MSI）は「マネージドID」と呼ばれている。

マネージドIDとは。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview)

「マネージドID」を使用することで、Azure仮想マシン（VM）などのリソースにIDを割り当てることができる。

「マネージドID」に対して、RBACロールを設定して、Blobデータの読み書き、Key Vaultからのシークレットの利用などの権限を設定することができる。

■マネージドIDとサービスプリンシパルの共通点

- 人ではなく、**VMなどのリソースで動くプログラム**や、**オンプレミスで動くスクリプト**等で使用するIDである。
- **プログラムが**Azureのリソースにアクセスする際に必要。
  - 単にプログラムをAzureにデプロイして動かすだけなら不要。
- どちらもAzure ADのID（プリンシパル）である。
- Azure RBACロールを割り当てできる。

■マネージドIDとサービスプリンシパルの違い

- マネージド ID は、Azure リソースでのみ使用できる特殊なタイプのサービス プリンシパルです
- マネージド ID が削除されると、対応するサービス プリンシパルが自動的に削除されます。
- マネージドIDのほうがかんたんに扱える。
  - 作成・削除がかんたんにできる。
  - プログラムからの利用もかんたんにできる。

マネージドIDが使える状況ではマネージドIDを使うべき。

※Azureのリソース（VMなど）の上で動くプログラムの場合、そのリソースにマネージドIDを使用する。Azureのリソースではない場所（オンプレミスのサーバー等）で動くプログラムでは、マネージドIDが使用できないので、サービスプリンシパルを使用する。

※マネージドIDは、サービスプリンシパルの一種だが、サービスプリンシパルを直接作成・削除する必要がないという点が便利。

■マネージドIDの種類

- システム割り当てマネージドID
  - リソースに対して直接関連付けられるID。
- ユーザー割り当てマネージドID
  - 複数のAzureリソース（VM）に関連付けて利用できるID。
  - スタンドアロンのリソース。

■マネージドIDをサポートするサービス

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities)

- Azure VM
- Azure VMSS
- Azure App Service
- Azure Functions
- ACI
- AKS
- Logic Apps
- Azure Event Grid トピック
  - トピックがService Bus, Blob, Queue, Event Hubsなどにデータを送信する際に利用
- など

## アプリケーション構成の実装

Azure App Configurationについて学ぶ。

### Azure App Configuration の概要

■Azure App Configurationとは。

[App Configurationの講義ノート](../AZ-204/mod07-03-app-configuration.md)を参照。

キーと値の形でアプリケーションの設定を管理するサービス。アプリケーションを再起動・再デプロイしなくても、アプリケーションの設定を動的に変更することができる。

- [アプリケーションを再起動させることなく必要に応じて構成を更新できる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/enable-dynamic-configuration-dotnet-core)。
- [「機能フラグ」を利用して、特定のユーザーやグループに対して機能を有効化することができる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)。
- 各言語・プラットフォーム用のクライアントライブラリが用意されている。

■Azure Key Vaultとの関係

- Azure Key Vault: 
  - 機密情報（キー、シークレット、証明書）の管理に特化。
  - [FIPS 140-2](https://ja.wikipedia.org/wiki/FIPS_140)に対応したHSM（ハードウェアセキュリティモジュール）を利用できる。
- Azure App Configuration
  - アプリケーションの設定情報の管理に特化。
  - [アプリケーションを再起動させることなく必要に応じて構成を更新できる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/enable-dynamic-configuration-dotnet-core)。
  - [「機能フラグ」を利用して、特定のユーザーやグループに対して機能を有効化することができる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)。

Azure App ConfigurationとAzure Key Vaultは補完関係にあるサービスである（得意分野が違うので、必要に応じて組み合わせて使用する）。Azure App Configurationに、[Azure key Vaultの「参照」を追加する](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=cmd%2Ccore2x)ことができる。つまり、アプリケーションで、Key Vaultのどのシークレットを読み込むかを、App Configuration側でコントロールすることができる。

### キーと値のペア

- キーと値を使って設定を記録する。
- キーは「:」などを使って階層構造で記録することもできる。
- キーと値に「ラベル」をつけることができる。
  - 「開発環境」「テスト環境」「本番環境」などの設定値を区別するために使用できる。

### App Configuration 機能の管理

[「機能フラグ」を利用して、特定のユーザーやグループに対して機能を有効化することができる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)。

通常の「キーと値」の設定との違い
- 有効期限（開始・終了）を設定できる
- 特定のユーザー・グループがアプリを利用する際にのみ、特定の機能を有効化することができる。
- コード内でif-elseを使用した分岐ができる
- ASP.NET Coreと連携することができる。
  - [アクションの有効化/無効化](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x#controller-actions)
  - [MVCビュー内の特定の区画を描画する/しない](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x#mvc-views)
  - [MVCフィルターの有効化/無効化](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x#mvc-filters)


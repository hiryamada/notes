■サービス プリンシパルとは

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell

リソースへのアクセスを必要とするアプリやスクリプトが使用するID。

https://docs.microsoft.com/ja-jp/cli/azure/create-an-azure-service-principal-azure-cli

Azure リソースにアクセスするアプリケーション、ホステッド サービス、および自動化ツールで使用するために作成されるID。

https://docs.microsoft.com/ja-jp/azure/analysis-services/analysis-services-service-principal

- リソース/サービス レベルの無人操作を実行する目的でテナント内で作成する Azure AD アプリケーション リソース。
- アプリケーション ID とパスワードまたは証明書が与えられる。

■サービス プリンシパル と セキュリティ プリンシパル の関係

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/app-objects-and-service-principals#service-principal-object

サービスプリンシパルは、セキュリティ プリンシパルの一種。

※セキュリティ プリンシパル: 
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview#security-principal

- Azure リソースへのアクセスを要求するユーザー、グループ、サービス プリンシパル、またはマネージド ID を表すオブジェクト。
- ロールを割り当てることができる。

```
セキュリティ プリンシパル
├ユーザー
├グループ
└サービス プリンシパル
  └マネージド ID
```

■マネージド IDとは

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/how-managed-identities-work-vm

- Azure Active Directory で自動的に管理される ID を Azure サービスに提供
- コードに資格情報が含まれていなくても、Azure AD の認証をサポートする任意のサービスに認証することができる。
- 内部的には、マネージド ID は特別な種類のサービス プリンシパルであり、Azure リソースとだけ使用できる。

```
サービス プリンシパル
 └マネージド ID
```

■マネージドIDをサポートするAzureサービス

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities#azure-services-that-support-managed-identities-for-azure-resources

- Azure App Service
- Azure Container Instances
- Azure Functions
- Azure Kubernetes Service (AKS)
- Azure Logic Apps
- Azure 仮想マシン スケール セット
- Azure Virtual Machines
- その他多数

■Azure AD認証をサポートするAzureサービス

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities#azure-services-that-support-azure-ad-authentication

- Azure Resource Manager
- [Azure Key Vault](https://docs.microsoft.com/ja-jp/azure/key-vault/general/authentication)
- Azure Data Lake
- [Azure Cosmos DB](https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-rbac)
- Azure SQL
- Azure Data Explorer
- Azure Event Hubs
- Azure Service Bus
- Azure Storage の BLOB, [キュー](https://docs.microsoft.com/ja-jp/azure/storage/queues/authorize-access-azure-active-directory), [テーブル](https://docs.microsoft.com/ja-jp/azure/storage/tables/authorize-access-azure-active-directory)
- Azure Analysis Services
- Azure Communication Services
- [Azure Event Grid](https://docs.microsoft.com/ja-jp/azure/event-grid/authenticate-with-active-directory)

■サービス プリンシパルの代わりにマネージド IDを使用したほうがよい状況

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell

以下のようなコードの場合。

- マネージド ID をサポートするサービス上で実行される
- Azure AD認証をサポートするリソースにアクセスする

■Azure PowerShellからサービスプリンシパルを作成する

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell

`New-AzADServicePrincipal` コマンド

■Azure CLIからのサービスプリンシパル操作

```
name=testsp

# サービスプリンシパルを作成する
az ad sp create-for-rbac --name $name

# 認証情報（パスワード）をリセットする
az ad sp credential reset --name $name

# 名前(のプレフィックス)を指定してサービスプリンシパルを検索する
# 指定した名前で始まるサービスプリンシパルが複数あると複数件ヒットするので注意
az ad sp list --display-name $name

# フィルターを指定してサービスプリンシパルを検索する
filter=$(printf "displayname eq '%s'" $name)
az ad sp list --filter "$filter"

# サービスプリンシパルのIDを取得する
id=$(az ad sp list --display-name $name --query '[].appId' --output tsv)

# サービスプリンシパルを削除する
az ad sp delete --id $id

# サービスプリンシパルを作成し、appIdとpasswordを変数に格納
read appId password < <(az ad sp create-for-rbac --name $name --role Contributor --query '{appId:appId,password:password}' --output tsv)

# サービスプリンシパルを表示
az ad sp show --id $appId

# サービスプリンシパルを作成し、パスワードではなく証明書(～.pem)を作成する。
az ad sp create-for-rbac --create-cert

# 証明書をKey Vaultに格納する
az ad sp create-for-rbac --keyvault MyVault --cert CertName --create-cert

# Key Vaultに作成・格納済みの証明書を使用する
az ad sp create-for-rbac --keyvault MyVault --cert CertName

# SDKで使用できるファイル（ファイルベース認証）を生成
az ad sp create-for-rbac --sdk-auth > azure.auth

az ad sp create-for-rbac --name $name --years 7000

```

デフォルトではContributorロールを、サブスクリプションで割り当てる。
```
--skip-assignment # ロール割り当てをスキップ
--role # ロールを指定
--scopes # スコープを指定
```


■Azure portalからのサービスプリンシパル作成

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal#app-registration-app-objects-and-service-principals

Azure portalでは、サービスプリンシパルだけを作成することはできない。

アプリの登録を行うと、ホームテナントに、アプリケーションオブジェクトと、対応するサービスプリンシパルが作成される。

■Azure portalでのサービス プリンシパルの確認

(1)Azure AD ＞エンタープライズ アプリケーション
アプリケーションの種類：すべて

(2)サブスクリプション＞アクセス制御（IAM）＞ロールの割り当て

■Azure portalでのアプリケーション オブジェクトの確認

Azure AD＞アプリの登録
「すべてのアプリケーション」を選択

「証明書とシークレット」の「証明書」で、アプリケーションに割り当てられた証明書（IDとフィンガープリント）を確認できる。

「証明書とシークレット」の「クライアント シークレット」で、アプリケーションに割り当てられたパスワードを確認できる。



■サービス プリンシパルを使用したサインイン

https://docs.microsoft.com/ja-jp/cli/azure/create-an-azure-service-principal-azure-cli#sign-in-using-a-service-principal

サービス プリンシパルでサインインするには、appId、tenant、および資格情報が必要

パスワード:
```
az login \
--service-principal \
--username APP_ID \
--password PASSWORD \
--tenant TENANT_ID
```

証明書:
```
az login \
--service-principal \
--username APP_ID \
--password /path/to/cert \
--tenant TENANT_ID 
```

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell#provide-certificate-through-automated-powershell-script

サービス プリンシパルとしてサインインするときは常に、テナント ID を指定する。

```
Connect-AzAccount -ServicePrincipal `
  -CertificateThumbprint $Thumbprint `
  -ApplicationId $ApplicationId `
  -TenantId $TenantId
```
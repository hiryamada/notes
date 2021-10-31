# マネージドIDの割り当てができるAzureサービス

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities#azure-services-that-support-managed-identities-for-azure-resources

■Azure VM(仮想マシン)

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token

https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/qs-configure-portal-windows-vm

- マネージドIDの設定
  - Azure portalから設定
  - Azure CLIで設定
    - az vm create --assign-identity
    - az vm identity assign
  - Azure PowerShellで設定
  - ARMテンプレートで設定
- アクセストークンの取得
  - REST `http://169.254.169.254/metadata/identity/oauth2/token`

■App ServiceとAzure Functions

https://docs.microsoft.com/ja-jp/azure/app-service/overview-managed-identity

2018/6/26 一般提供開始
https://azure.microsoft.com/ja-jp/updates/announcing-general-availability-and-sovereign-cloud-support-of-managed-service-identity-for-app-service-and-azure-functions/


- マネージドIDの設定
  - Azure portalから設定
  - Azure CLIで設定
    - az webapp identity assign
  - Azure PowerShellで設定
    - Set-AzWebApp -AssignIdentity
  - ARMテンプレートで設定
- アクセストークンの取得
  - REST プロトコル - GET /MSI/token
  - Microsoft.Azure.Services.AppAuthentication パッケージ（旧）
  - Azure.Identity パッケージ（新）

■Azure Container Instances

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-managed-identity

2018/10/23 プレビュー
https://azure.microsoft.com/ja-jp/updates/aci-msi-preview/

※2021/10/31現在もプレビュー。現時点では、Azure Container Instances のマネージド ID は Linux コンテナーでのみサポートされており、Windows コンテナーではまだサポートされていない。

- マネージドIDの設定
  - コンテナーグループ作成時に[ContainerGroupIdentityプロパティ](https://docs.microsoft.com/ja-jp/rest/api/container-instances/container-groups/create-or-update#containergroupidentity)で設定
  - az container create --assign-identity
  - コンテナーグループ作成後にマネージドIDを有効化または更新できる
  - Azure CLI、Resource Manager テンプレート、YAML ファイル、または別の Azure ツールを使用
- アクセストークンの取得
  - REST `http://169.254.169.254/metadata/identity/oauth2/token`
- 制限
  - 仮想ネットワークにデプロイされたコンテナー グループ内でマネージド ID を使用することはできない
  - マネージド ID を使用して、コンテナー グループの作成時に Azure Container Registry からイメージをプルすることはできない。ID は、実行中のコンテナー内でのみ使用できる。

■AKS

https://docs.microsoft.com/ja-jp/azure/aks/use-managed-identity

Azure 内にロード バランサーやマネージド ディスクなどの追加リソースを作成するには、ID が必要

2019/10/2 AKSのマネージドID統合 プレビュー
https://azure.microsoft.com/ja-jp/updates/managed-identities-integration-in-azure-kubernetes-service-aks-is-now-in-preview/

2020/4/28 AKSのマネージドID統合 一般提供開始
https://azure.microsoft.com/en-us/updates/managed-identity-support-in-aks-is-now-available/


- マネージドIDの設定
  - Azure portal
  - Azure CLI
    - `az aks create --enable-managed-identity`


■AKS - Pod Identity （Azure Active Directory ポッドマネージド ID）

2020/12/9 AKS Pod Identity パブリックプレビュー
https://azure.microsoft.com/ja-jp/updates/public-preview-aks-pod-identity/

※2021/10/31 現在もプレビュー中

AKSのベストプラクティス: ポッドマネージドIDを使用する
https://docs.microsoft.com/ja-jp/azure/aks/operator-best-practices-identity#use-pod-managed-identities

わかりやすい解説
https://jpaztech.github.io/blog/containers/aks-aad-pod-identity/


- 制限
  - Windows コンテナーに対するポッドマネージド ID のサポートは近日対応予定
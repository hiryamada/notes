# プロビジョニング

# カスタムスクリプト拡張機能


Windows:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/custom-script-windows

Linux:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/custom-script-linux

Azure 仮想マシンでスクリプトをダウンロードし、実行。

スクリプトはBlob StorageやGitHubに配置。

# Desired State Configuration拡張機能

Windows:
https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/getting-started/wingettingstarted

Linux:
https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/getting-started/lnxgettingstarted

システムの構成、展開、および管理に使用する宣言型プラットフォーム。

■DSCの「構成」の例

```
# 構成
configuration LabConfig
{
    # 構成が適用さえるターゲットの指定
    Node WebServer
    {
        # IIS（Webサーバー）という「役割」をインストール
        WindowsFeature IIS
        {
            # 追加または削除されることを保証する役割の名前
            # Get-WindowsFeature コマンドレットからの Name プロパティと同じもの
            Name = 'Web-Server'
            # Present（機能を追加する） または Absent（機能を削除する）
            Ensure = 'Present'
            # すべての「子」の「役割」を含める
            IncludeAllSubFeature = $true
        }
    }
}
```

# Azure Automation State Configuration

https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-overview

Azure Automation内の1機能。

任意のクラウドまたはオンプレミスのデータセンターのノードについて PowerShell Desired State Configuration (DSC) の構成を記述、管理、およびコンパイルできる Azure 構成管理サービス。

■（ターゲット）ノード

Azure Automation State Configuration によって管理されるマシン。

- Azure 仮想マシン
- Azure 仮想マシン (クラシック)
- オンプレミス、Azure、または Azure 以外のクラウド内の物理/仮想 Windows マシン
- オンプレミス、Azure、または Azure 以外のクラウド内の物理/仮想 Linux マシン

■（組み込みの）プル サーバー

Azure Automation State Configuration では、Windows 機能 DSC サービスに似た DSC プル サーバーが提供されます。

■ターゲットノード

「ターゲット ノード」では、「プル サーバー」から「構成」を受信し、目的の状態に適合させ、コンプライアンスについて報告することができます。

[構成方法](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-onboarding#enable-physicalvirtual-windows-machines)

- Azure VM: 拡張機能を入れる
- オンプレ等のマシン: 
  - Windows: PowerShell DSC [メタ構成](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-onboarding#generate-dsc-metaconfigurations)を適用する。
  - Linux: PowerShell DSC for Linuxをインストール

# Chef

Chef社（元 Opscode社, 2013年頃に社名を変更）が開発する構成管理ツール。

オンプレミスのコンピュータや、Azure VMの構成を行うことができる。構成は「レシピ」と呼ばれる。VMの作成を行うこともできる。

[chef](https://ejje.weblio.jp/content/chef): 料理人、コック、コック長

■ドキュメント

- Microsoft Docsのドキュメント:
  - [Azure 上の Chef](https://docs.microsoft.com/ja-jp/azure/developer/chef/)
  - 現在はすべてのコンテンツは削除されている。
  - 代わりに [Chefのサイトのドキュメント](https://docs.chef.io/azure_portal)を見るように案内がある

[公式サイト](https://www.chef.io/)

■特徴

- Ruby / Erlangで実装。
- レシピ（Ruby DSL）を使用して構成を定義。
- クライアント・サーバー型
  - Chefサーバー
  - ノード（Chefクライアント）：管理対象のVM
  - ワークステーション：管理者用
- Chef Solo: スタンドアロン版のChef。
  - 後続の Chef Zero もある。
- knifeコマンド
  - Chefインフラを操作するためのコマンド。
- [Azure VMの拡張機能](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/chef)が利用可能
  - Azure VMに対してChefを簡単に有効化できる

■製品群

- Chef
  - インフラ（データセンター）の自動化
- Chef Habitat
  - [2016年6月に発表](https://www.publickey1.jp/blog/16/chefhabitatdocker.html)
  - アプリケーションの自動化
- [InSpec](https://community.chef.io/tools/chef-inspec)
  - アプリとインフラの状態をテスト・監査するためのフレームワーク
  - Compliance as Code
  - [Serverspec](https://serverspec.org/)を拡張したもの
- Chef Automate
  - [2016年7月に発表](https://www.publickey1.jp/blog/16/chefchef_automate.html)
  - Chef、Habitatなどを統合管理、可視化


# Terraform


[公式サイト](https://www.terraform.io/)

[HashiCorp社](https://www.hashicorp.com/)が開発する構成管理ツール。

[テラフォーミング](https://ja.wikipedia.org/wiki/%E3%83%86%E3%83%A9%E3%83%95%E3%82%A9%E3%83%BC%E3%83%9F%E3%83%B3%E3%82%B0)

■特徴

- [Goで実装](https://github.com/hashicorp/terraform)。
- 「プロバイダー」を使用して機能を拡張できる。
  - [Azureプロバイダー](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs)
- 冪等性をツール側で保証。
- HCL(HashiCorp Configuration Language)を使用して構成を定義。
  - ～.tf という名前で保存
- コマンド（terraform）がCloud Shellにインストール済みで、すぐに利用できる

■製品群

- [Terraform CLI](https://www.terraform.io/docs/cli/index.html)
- [Terraform Cloud](https://www.terraform.io/cloud)
  - Cloud infrastructure automation as a Service（サービスとしてのクラウド自動化）
  - 複数のクラウドプロバイダー（Azure, AWS, GCP等）を一箇所からコントロール
  - チームや組織でTerraformを利用する場合におすすめ
- [Terraform Enterprise](https://www.terraform.io/docs/enterprise/index.html)
  - セルフホストのTerraform Cloud

■構成ファイルの例
```
provider azurerm {
  features {}
}

resource "azurerm_resource_group" "test" {
 name     = "terraformTestResourceGroup"
 location = "East US"
}
```

■使用手順（Azure Cloud Shell）

- 構成ファイル(～.tf)を作成
- `terraform init`
- `terraform plan`
- `terraform apply -auto-approve`
- コマンドの実行が完了してから、Azure portal側の一覧に反映されるまで、1分ほどかかる。


# ARMテンプレート

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview

■ARMテンプレートとは

ARMテンプレートは、Azureにデプロイ（作成）する一連のリソースを定義したJSONファイル。

「Azure Resource Manager（ARM）」とは、Azure のリソースのデプロイと管理を担当する、Azureの内部のレイヤー（層）。ARMは、Azure portal、コマンドなどから、リソースに対するリクエスト（要求）を受け付けて、リソースを一元的にコントロールする。


■テンプレートの形式

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/syntax

テンプレートには、いくつかの要素が記述される。

代表的な要素として、$schema、contentVersion、parameters、variables、functions、resources、outputsなどがある。

- $schema: 必須
  - このテンプレートが使用するスキーマのバージョンを指定する。

- contentVersion: 必須
  - このテンプレートに含まれるリソース定義のバージョンを表す。

- parameters
  - パラメータの定義を行う。
  - パラメータを使用すると、テンプレートをデプロイする際に、ストレージアカウントの名前や、仮想マシンのサイズなどの値をカスタマイズすることができる。

- functions
  - テンプレートの中で使用することができる、ユーザー定義の関数を定義する。
  - たとえば、ストレージアカウントの一意の名前を生成する、といったユーザー定義関数をここで定義し、テンプレート内で利用することができる。

- resources: 必須
  - テンプレートでデプロイするリソースの詳細や、デプロイにおけるリソースの依存関係を記述する。

- outputs
  - テンプレートのデプロイからの出力を定義する。
  - たとえば、仮想マシンをデプロイした場合に、その仮想マシンのIPアドレスの値を出力するといったことができる。


■テンプレートの例

以下のリソースをデプロイするテンプレートの例。

- App Service プラン（[Microsoft.Web/serverfarms](https://docs.microsoft.com/ja-jp/azure/templates/microsoft.web/serverfarms?tabs=json)）
- App Service アプリ（[Microsoft.Web/sites](https://docs.microsoft.com/ja-jp/azure/templates/microsoft.web/sites?tabs=json)）

```
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "resources": [
        /* App Service プラン */
        {
            "name": "appServicePlan1",
            "type": "Microsoft.Web/serverfarms",
            "apiVersion": "2018-02-01",
            "location": "[resourceGroup().location]",
            "sku": {
                "name": "F1"
            },
            "properties": {
            }
        },
        /* App Service アプリ */
        {
            "name": "app12321",
            "type": "Microsoft.Web/sites",
            "apiVersion": "2018-11-01",
            "location": "[resourceGroup().location]",
            "dependsOn": [
                "[resourceId('Microsoft.Web/serverfarms', 'appServicePlan1')]"
            ],
            "properties": {
                "serverFarmId": "[resourceId('Microsoft.Web/serverfarms', 'appServicePlan1')]"
            }
        }
   ]
}
```

テンプレートファイルの名前は任意だが、「azuredeploy.json」という名前がよく使用される。


※[JSON自体の仕様としてはコメントは許容されない](https://www.google.com/search?q=JSON+%E3%82%B3%E3%83%A1%E3%83%B3%E3%83%88+%E4%BB%95%E6%A7%98)が、[ARMテンプレート内にはコメントを含めることができる](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/syntax#comments-and-metadata)。

※App Serviceアプリよりもプランを先にデプロイする必要がある（アプリはプランに依存する）。このような依存関係は [dependsOn](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/resource-dependency) で指定する。

■リソース

```
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "resources": [
    {
      "type": "Microsoft.Storage/storageAccounts",
      "apiVersion": "2021-04-01",
      "name": "mystorage1234",
      "location": "eastus",
      "sku": {
        "name": "Standard_LRS"
      },
      "kind": "StorageV2",
      "properties": {
        "supportsHttpsTrafficOnly": true
      }
    }
  ]
}
```

■パラメーター

テンプレート内で、パラメーター「storageName」を宣言する例。

```
  "parameters": {
    "storageName": {
      "type": "string",
      "minLength": 3,
      "maxLength": 24
    }
  }
```

パラメーターの値を参照する例。[parameters関数](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/template-functions-deployment#parameters)を利用する。

```
  "resources": [
    {
      "type": "Microsoft.Storage/storageAccounts",
      "apiVersion": "2021-04-01",
      "name": "[parameters('storageName')]",
      "location": "eastus",
      "sku": {
        "name": "Standard_LRS"
      },
      "kind": "StorageV2",
      "properties": {
        "supportsHttpsTrafficOnly": true
      }
    }
  ]
}
```

■パラメーターをコマンドから指定

テンプレートをデプロイする際に、コマンドから、パラメーターの値を指定することができる。

```
New-AzResourceGroupDeployment `
  -Name deploy1 `
  -ResourceGroupName myResourceGroup `
  -TemplateFile $templateFile `
  -storageName "mystorage4567"
```

■パラメーターをファイルから指定

```
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
  "contentVersion": "1.0.0.0",
  "parameters": {
    "storageName": {
      "value": "mystorage1234"
    }
  }
}
```

パラメータファイルの名前は任意だが、「azuredeploy.parameters.json」という名前がよく使用される。

```
New-AzResourceGroupDeployment `
  -Name deploy2 `
  -ResourceGroupName myResourceGroup `
  -TemplateFile azuredeploy.json `
  -TemplateParameterFile azuredeploy.parameters.json
```


環境ごとに異なる値を指定するために、複数のパラメーターファイルを作ることもできる。

- azuredeploy.parameters.dev.json
- azuredeploy.parameters.prod.json


■パラメーターのデフォルト値

defaultValue で、パラメーターのデフォルト値を指定することができる。この場合、コマンド等でパラメーターの値が指定されなかった場合は、デフォルト値が利用される。

```
    "storageSKU": {
      "type": "string",
      "defaultValue": "Standard_LRS",
      "allowedValues": [
        "Standard_LRS",
        "Standard_GRS",
        "Standard_RAGRS",
        "Standard_ZRS",
        "Premium_LRS",
        "Premium_ZRS",
        "Standard_GZRS",
        "Standard_RAGZRS"
      ]
    }
  }
```


■参考: Bicep

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/bicep/overview

※Bicep（バイセップ）：上腕二頭筋、力こぶ、💪

Bicep は、宣言型の構文を使用して Azure リソースをデプロイすることができるドメイン固有言語 (DSL) 。

JSONよりも簡潔な構文を使用して、リソースを宣言することができる。

Bicepテンプレートの例
```
param location string = resourceGroup().location
param namePrefix string = 'storage'

var storageAccountName = '${namePrefix}${uniqueString(resourceGroup().id)}'
var storageAccountSku = 'Standard_RAGRS'

resource storageAccount 'Microsoft.Storage/storageAccounts@2019-06-01' = {
  name: storageAccountName
  location: location
  kind: 'StorageV2'
  sku: {
    name: storageAccountSku
  }
  properties: {
    accessTier: 'Hot'
    supportsHttpsTrafficOnly: true
  }
}

output storageAccountId string = storageAccount.id
```

デプロイの例
```
az group create \
 --name exampleRG \
 --location eastus

az deployment group create \
 --resource-group exampleRG \
 --template-file main.bicep
```

Microsoft Learn: Bicep を使用して Azure でリソースをデプロイして管理する
https://docs.microsoft.com/ja-jp/learn/paths/bicep-deploy/

■参考: テンプレート スペック

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/template-specs?tabs=azure-powershell

- 「テンプレート スペック」リソース内にテンプレートを保存できる
- テンプレートを組織内で共有することができる
- ユーザーは、テンプレートスペックを使用してデプロイを行うことができる
- テンプレート スペックのバージョン管理を行うことができる

Microsoft Learn: 再利用可能なインフラストラクチャ コードのライブラリをテンプレート スペックを使用して発行する
https://docs.microsoft.com/ja-jp/learn/modules/arm-template-specs/


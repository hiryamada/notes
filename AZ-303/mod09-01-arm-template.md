# ARMテンプレート

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview

■歴史

2014/4/2-4 Microsoft Build 2014 にて、Azure Resource Managerプレビューなどが公開。JSONテンプレートによるリソースのデプロイに対応。
https://gihyo.jp/admin/clip/01/azurenews2014/201404/07

2020/5/13 「Project Bicep」のGitHubリポジトリが作られる
https://github.com/Azure/bicep/tree/dd5ad4e6a1b9855b8faf2905d5be63833dcd2c6c

2021/5/31 ARMテンプレートスペック 一般提供開始
https://techcommunity.microsoft.com/t5/azure-governance-and-management/arm-template-specs-now-ga/ba-p/2402618

■ARMテンプレートとは

ARMテンプレートは、Azureにデプロイ（作成）する一連のリソースを定義したJSONファイル。

「Azure Resource Manager（ARM）」とは、Azure のリソースのデプロイと管理を担当する、Azureの内部のレイヤー（層）。ARMは、Azure portal、コマンドなどから、リソースに対するリクエスト（要求）を受け付けて、リソースを一元的にコントロールする。

■Infrastructure as Code（IaC）

テンプレートを使用することで、インフラストラクチャ（デプロイするリソース）をコードとして記述することができる。

この考え方は「Infrastructure as Code（IaC）」と呼ばれる。

IaCには多数のメリットがある。

- Git等を使用してバージョン管理を行うことができる。
  - いつ、だれが、どのリソースに、どのような理由で、どのような変更をしたか、といった履歴を、コードとともに残すことができる
  - 必要に応じて前のバージョンに戻すことができる。
- コードを繰り返し利用することができる
  - 人手でリソースを繰り返しデプロイすることによる操作ミスを避けることができる。
- オンデマンドでのインフラストラクチャの活用が容易になる。
  - 必要な際にコードからデプロイしてインフラストラクチャを使用し、インフラストラクチャが不要になったら即座に削除してコストを節約することができる


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



■関数

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/template-functions

テンプレート内では、（Azureテンプレートにあらかじめ組み込まれている）関数と、ユーザー定義関数を使用することができる。

■テンプレートの作成方法

- [Azure portalを使用して生成](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/quickstart-create-templates-use-the-portal#generate-a-template-using-the-portal)
  - Azure portalの各種リソースの作成画面にて、リソースの作成に必要な情報を入力する。
  - 最後のステップ（「確認および作成」）で、「Automationのテンプレートをダウンロードする」をクリックすると、入力した情報に対応したテンプレートが生成される。このテンプレートをダウンロードすることができる。
- [Visual Studio Code](https://azure.microsoft.com/ja-jp/products/visual-studio-code/) を使用して記述
  - 「[Azure Resource Manager (ARM) Tools 拡張機能](https://marketplace.visualstudio.com/items?itemName=msazurermtools.azurerm-vscode-tools)」をインストールすることで、テンプレートを記述するのに便利な機能を使用することができる。
  - たとえば「スニペット」を使用して、テンプレートの基本形を挿入したり、「コード補完」を使用して、テンプレート内の語句をすばやく正確に入力したりすることができる。


■テンプレートのエクスポート

すでにAzureにリソースがデプロイされている場合は、いくつかの方法で、それらをテンプレートとして「エクスポート」（出力）することも可能。

- リソースグループ全体
  - リソースグループにデプロイされたリソース全体を、一つのテンプレートとしてエクスポート。
- リソースグループ内の個々の「デプロイ」
  - リソースグループに段階的にデプロイ（リソースの追加）を行った場合、それぞれのデプロイの履歴がリソースグループに残る。
  - これらのデプロイから一つを選択して、それをテンプレートとしてエクスポートすることができる
- リソース
  - 選択した一つのリソースをテンプレートとしてエクスポートできる。

■テンプレートからのデプロイ方法

作成した（生成された）テンプレートで定義されたリソースをデプロイする主な方法。

- [Azure portal](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-cli)
  - Azure portalの画面上部の検索ボックスから「カスタム テンプレートのデプロイ」を呼び出して、テンプレートをアップロードし、デプロイ。
- コマンド(Azure PowerShellまたはAzure CLI)
  - [PowerShell](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-powershell)
  - [Azure CLI](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-cli)

Azure PowerShellコマンドの使用例:

```powershell
# testrg1 リソースグループに azuredeploy.json テンプレートで定義されたリソースをデプロイする
New-AzResourceGroupDeployment `
-ResourceGroupName testrg1 `
-TemplateFile azuredeploy.json
```

Azure CLIコマンドの使用例:

```bash
# testrg1 リソースグループに azuredeploy.json テンプレートで定義されたリソースをデプロイする
az deployment group create \
--resource-group testrg1 \
--template-file azuredeploy.json
```

■デプロイ先のスコープ

- [リソースグループ](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-to-resource-group?tabs=azure-cli)
- [サブスクリプション](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-to-subscription?tabs=azure-cli)
- [管理グループ](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-to-management-group?tabs=azure-cli)

■クイックスタートテンプレート

https://azure.microsoft.com/en-us/resources/templates/

すぐにデプロイに利用することができる、1000以上のテンプレートのコレクションを利用することができる。

■Deploy to Azureボタン

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deploy-to-azure-button

GitHubのリポジトリに、テンプレートと「Deploy to Azure」ボタンを配置し、ワンクリックでテンプレートをデプロイできるようにすることができる。

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

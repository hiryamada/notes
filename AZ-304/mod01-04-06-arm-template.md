

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


■参考: テンプレート スペック

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/template-specs?tabs=azure-powershell

- 「テンプレート スペック」リソース内にテンプレートを保存できる
- テンプレートを組織内で共有することができる
- ユーザーは、テンプレートスペックを使用してデプロイを行うことができる
- テンプレート スペックのバージョン管理を行うことができる

Microsoft Learn: 再利用可能なインフラストラクチャ コードのライブラリをテンプレート スペックを使用して発行する
https://docs.microsoft.com/ja-jp/learn/modules/arm-template-specs/


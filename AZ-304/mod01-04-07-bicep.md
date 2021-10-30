

# Bicep

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

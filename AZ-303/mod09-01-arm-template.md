# ARMテンプレート

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview

■ARMテンプレートとは

ARMテンプレートは、Azureにデプロイ（作成）する一連のリソースを定義したJSONファイル。

「Azure Resource Manager（ARM）」とは、Azure のリソースのデプロイと管理を担当する、Azureの内部のレイヤー（層）。ARMは、Azure portal、コマンドなどから、リソースに対するリクエスト（要求）を受け付けて、リソースを一元的にコントロールする。

■Infrastructure as Code（IaC）

テンプレートを使用することで、インフラストラクチャ（デプロイするリソース）をコードとして記述することができる。

この考え方は「Infrastructure as Code（IaC）」と呼ばれる。


メリット:
- コード（で記述されたインフラストラクチャ）は、Git等を使用してバージョン管理を行うことができます。いつ、だれが、どのリソースに、どのような理由で、どのような変更をしたか、といった履歴を、コードとともに残すことができ、必要に応じて前のバージョンに戻すこともできる。
- コードは繰り返し利用することができ、人手でデプロイすることによる操作ミスを避けることができる。
- 必要な際にコードからデプロイしてインフラストラクチャを使用し、インフラストラクチャが不要になったら即座に削除してコストを節約するという、オンデマンドでのインフラストラクチャの活用が可能になる。

■テンプレートの内容

テンプレートには、いくつかの要素が記述される。

代表的な要素として、$schema、contentVersion、parameters、variables、functions、resources、outputsなどがある。

$schemaは、このテンプレートが使用するスキーマのバージョンを指定する。contentVersionは、このテンプレートに含まれるリソース定義のバージョンを表す。

parametersは、パラメータの定義を行う。パラメータを使用すると、テンプレートをデプロイする際に、仮想マシンのサイズなどの値をカスタマイズすることができる。

functionsは、テンプレートの中で使用することができる、ユーザー定義の関数を定義する。たとえば、ストレージアカウントの一意の名前を生成する、といったユーザー定義関数をここで定義し、テンプレート内で利用することができる。

resourcesは、このテンプレートでデプロイするリソースの詳細や、デプロイにおけるリソースの依存関係を記述する。

outputsは、テンプレートのデプロイからの出力を定義する。たとえば、仮想マシンをデプロイした場合に、その仮想マシンのIPアドレスの値を出力するといったことができる。


■テンプレートの例
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

■テンプレートの作成方法

- Azure portal
  - Azure portalの各種リソースの作成画面にて、リソースの作成に必要な情報を入力する。
  - 最後のステップ（「確認および作成」）で、「Automationのテンプレートをダウンロードする」をクリックすると、入力した情報に対応したテンプレートが生成される。このテンプレートをダウンロードすることができる。
- Visual Studio Code
  - Visual Studio Codeに「Azure Resource Manager (ARM) Tools 拡張機能」をインストールすることで、テンプレートを記述するのに便利な機能を使用することができる。
  - たとえば「スニペット」を使用して、テンプレートの基本形を挿入したり、「コード補完」を使用して、テンプレート内の語句をすばやく正確に入力したりすることができる。


■テンプレートのエクスポート
また、すでにAzureにリソースがデプロイされている場合は、いくつかの方法で、それらをテンプレートとして「エクスポート」（出力）することも可能。

- リソースグループ全体
  - リソースグループにデプロイされたリソース全体を、一つのテンプレートとしてエクスポート。
- リソースグループ内の個々の「デプロイ」
  - リソースグループに段階的にデプロイ（リソースの追加）を行った場合、それぞれのデプロイの履歴がリソースグループに残る。
  - これらのデプロイから一つを選択して、それをテンプレートとしてエクスポートすることができる
- リソース
  - 選択した一つのリソースをテンプレートとしてエクスポートできる。

■テンプレートからのデプロイ方法

作成した（生成された）テンプレートで定義されたリソースをデプロイする主な方法。

- Azure portal
  - Azure portalの画面上部の検索ボックスから「カスタム テンプレートのデプロイ」を呼び出して、テンプレートをアップロードし、デプロイ。
- コマンド
  - Azure PowerShellまたはAzure CLIからテンプレートをデプロイすることができる。

Azure PowerShellコマンドの使用例:

```powershell
# testrg1 リソースグループに azuredeploy.json テンプレートで定義されたリソースをデプロイする
New-AzResourceGroupDeployment -ResourceGroupName testrg1 -TemplateFile azuredeploy.json
```

Azure CLIコマンドの使用例:

```bash
# testrg1 リソースグループに azuredeploy.json テンプレートで定義されたリソースをデプロイする
az deployment group create --resource-group testrg1 --template-file azuredeploy.json
```

# ハンズオン（後編） ACI

■ハンズオンの概要

- Azure Reposに、開発したコード一式を格納
- Azure Pipelinesで、次のパイプラインを作成
  - Azure Container Registryでイメージをビルド
  - イメージをAzure Container Instanceにデプロイ
- Azure Container InstancesでWebアプリの動作を確認

■（前編）の概要

- 作業用の「labvm」にリモートデスクトップ接続（またはBastionで接続）した状態です。
- 新しいVisual Studio Codeウィンドウ（左下には「SSH: dockervm」と表示）を操作しています。

■Gitリポジトリの初期化

- メニュー＞Terminal＞New Terminal を開く
- 以下のコマンドを投入
  ```
  dotnet new gitignore
  git init
  git add -A
  git config --global user.name 'test'
  git config --global user.email 'test@example.com'
  git commit -m 'initial commit'
  git branch --move master main
  ```

■新しいプロジェクトを作成

- Webブラウザを開く
- Azure DevOpsの画面に移動 https://dev.azure.com
- `+ New Project`
- Project name: `dockerwebapp1`
- Visibility: `Private`
- Create

■Git用のPersonal Access Tokenの取得

- 画面右上の、右から2番めのアイコンをクリック
- Personal access tokens
- `+ New Token`
- Name: gitpassword2 （など、適当に）
- Codeの`Full`にチェック
- Create
- 表示されたTokenをコピーしておく。後で使うのでメモ帳等にコピー
- Close

■Azure ReposにコードをPushする

- プロジェクトのReposに移動
- 「Push an existing repository from command line」の下のテキストボックス内のコマンドをコピー
- Visual Studio Codeに切り替える
- Terminalに、コピーしたコマンドを投入
- パスワードの入力が求められるので、先程コピーしたTokenを貼り付ける
- ReposのFilesをクリック
- Files（ファイル一覧）に、`Program.cs`等のファイルが入ってきたことを確認

■Azure Pipelines

Azure Resource Managerのサービス接続「sc」を作成しておきます。

■Azure Pipelines

以下のYAMLを使用してパイプラインを作成します。`variables`の`value`の`99999999`部分は各自で別の適当な番号に変更してください。

```yaml
# Starter pipeline
# Start with a minimal pipeline that you can customize to build and deploy your code.
# Add steps that build, run tests, deploy, and more:
# https://aka.ms/yaml

trigger:
- main

pool:
  vmImage: ubuntu-latest

variables:
- name: rgname
  value: testrg1
- name: location
  value: japaneast
- name: acrname
  value: acr99999999
- name: aciname
  value: aci99999999
- name: imagetag
  value: 'hello:v1'
steps:

- task: AzureCLI@2
  inputs:
    azureSubscription: 'sc'
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az account show'

- task: AzureCLI@2
  inputs:
    azureSubscription: 'sc'
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az group create -n $(rgname) -l $(location)'
- task: AzureCLI@2
  inputs:
    azureSubscription: 'sc'
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az acr create -n $(acrname) -l $(location) -g $(rgname) --sku Basic'

- task: AzureCLI@2
  inputs:
    azureSubscription: 'sc'
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az acr update -n $(acrname) --admin-enabled true'

- task: AzureCLI@2
  inputs:
    azureSubscription: 'sc'
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az acr list -o table'

- task: AzureCLI@2
  inputs:
    azureSubscription: sc
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az acr build -r $(acrname) -t $(imagetag) .'

- task: AzureCLI@2
  inputs:
    azureSubscription: sc
    scriptType: 'bash'
    scriptLocation: 'inlineScript'
    inlineScript: 'az container create -n $(aciname) -g $(rgname) --image $(acrname).azurecr.io/$(imagetag) --ip-address public --ports 8080 --registry-login-server $(acrname).azurecr.io --registry-username $(acrname) --registry-password `az acr credential show -n $(acrname) --query "passwords[0].value" -otsv`'
```

■Azure Container Instance での動作確認



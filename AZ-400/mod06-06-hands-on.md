# module 6 ハンズオン

## ハンズオン1

複数のジョブを生成する例

  - Azure DevOpsの「Organization Settings」に移動
    - PipelinesのParallel Jobsを選択
    - Private projectsのMicrosoft-hostedのChangeをクリック
    - Pipelines for private projectsのMS Hosted CI/CDのPaid parallel jobsを1に変更して、画面下部のSaveをクリック
  - パイプラインの設定と実行
    - プロジェクトのAzure Pipelines をクリック
    - Create Pipelineをクリック
    - Azure Repos Gitをクリック
    - Gitリポジトリ（プロジェクト名と同じ名前がついている）をクリック
    - Python packageをクリック
    - Save and runをクリック
    - 画面右下のSave and runをクリック
    - しばらく待つ。
    - パイプライン内で4つのJobが生成され、実行される。
    - 2～3分ですべてのJobが完了し、それぞれのStatusはSuccessとなる。

## ハンズオン2

Azure Web Apps のWebアプリへのデプロイ

- 基本的な手順
  - App Service の Webアプリを作成する
    - ランタイムスタック: .NET Core 3.1
    - オペーレーティングシステム: Windows
  - 組織に新しいプロジェクトを作る（＋New Project）
    - プロジェクト名は任意のものでOK
  - ソースコードの準備
    - プロジェクトのAzure Repos をクリック
    - Importをクリック 
    - Clone URLに`https://github.com/MicrosoftDocs/pipelines-dotnet-core` を入力し、Importをクリック
    - インポートが完了するまでしばらく待つ
  - パイプラインの準備
    - プロジェクトのAzure Pipelines をクリック
    - パイプラインを新規作成
    - Azure Repos Git
    - プロジェクトのリポジトリを選択
    - ASP.NET Core を選択 ※ ASP.NET Core (.NET Framework) **ではない**
    - 生成された azure-pipeline.yml を削除し、以下を貼り付ける。**以下の書き換えを行う**
      - azureSubscription 内のIDは、ご自身のサブスクリプションのIDに書き換え
      - WebAppName は、前の手順で作成したWebアプリの名前を指定

```
trigger:
- master

pool:
  vmImage: ubuntu-latest

variables:
  buildConfiguration: 'Release'

steps:
- script: dotnet build --configuration $(buildConfiguration)
  displayName: 'dotnet build $(buildConfiguration)'

- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    publishWebProjects: true
    arguments: '--configuration $(BuildConfiguration) --output $(Build.ArtifactStagingDirectory)'
    zipAfterPublish: true

- task: PublishPipelineArtifact@1
  inputs:
    targetPath: '$(Build.ArtifactStagingDirectory)'
    artifact: 'web'
    publishLocation: 'pipeline'

- task: DownloadPipelineArtifact@2
  inputs:
    source: 'current'
    artifact: 'web'
    path: '$(Build.ArtifactStagingDirectory)'

- task: AzureRmWebAppDeployment@4
  inputs:
    ConnectionType: 'AzureRM'
    azureSubscription: 'Azure Pass - スポンサー プラン (612db016-a3a6-4b6f-b048-9371ae292dda)'
    appType: 'webApp'
    WebAppName: 'win9813483'
    packageForLinux: '$(Build.ArtifactStagingDirectory)/**/*.zip'
```

参考:
- [最初のパイプラインの作成(.NET)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=tfs-2018-2%2Cbrowser%2Cnet#create-your-first-pipeline-1)
- [.NET Core アプリをビルド、テスト、デプロイする](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=dotnetfive)
- [Azure App Service Web アプリをデプロイする](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/targets/webapp?view=azure-devops&tabs=yaml%2Cwindows)


## ハンズオン3（オプション）

※時間があまったら実施。

- [Enabling Continuous Integration with Azure Pipelines](https://azuredevopslabs.com//labs/azuredevops/continuousintegration/)
- [Integrate Your GitHub Projects With Azure Pipelines](https://azuredevopslabs.com/labs/azuredevops/github-integration/)

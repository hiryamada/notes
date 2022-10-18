
# ハンズオン: Azure Web Apps のWebアプリへのデプロイ


- Azure portal (portal.azure.com)での作業
  - App Service の Webアプリを作成する
    - リソースグループ: 新規作成、名前は適当に指定 rg1 など
    - 名前: 適当に指定 webapp123456 など 123456部分は適当な乱数を指定
    - ランタイムスタック: .NET 6
    - オペーレーティングシステム: Windows
    - 地域: Japan East
  - 「参照」をクリック。
  ![](images/ss-2021-12-15-09-27-49.png)
  - 別タブで、Webアプリにアクセスが行われる。「Hey, App Service Developers!」といったメッセージが出る。
  ![](images/ss-2021-12-15-09-27-29.png)
- Azure DevOps側での作業
  - サービスコネクションの作成
    - Project Settings > Pipelines > Service Connections
    - New Service connection
    - Azure Resource Managerをクリックして画面下Next
    - Service Principal(automatic)をクリックしてNext
    - ポップアップでサインイン画面が出るので、トレーニング用に作成したMicrosoftアカウントでサインイン
    - ※Resource groupは選択しない
    - Grant access permission to all pipelinesにチェック
    - service connection name に「sc1」と入力してSave
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
    - 生成された azure-pipeline.yml を削除し、以下の「YAMLパイプライン」を貼り付ける。
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
          azureSubscription: sc1
          appType: 'webApp'
          WebAppName: 'YOURWEBAPPNAME'
          packageForLinux: '$(Build.ArtifactStagingDirectory)/**/*.zip'
      ```
    - 書き換えを行う
      - WebAppName は、前の手順で作成したWebアプリの名前を指定。URLではなく～～.azurewebsites.netの～～の部分
    - Save and run
    - 再度Save and run
    - 「There was a resource authorization issue: "The pipeline is not valid. Job Job: Step AzureRmWebAppDeployment input ConnectedServiceName references service connection Azure Pass - スポンサー プラン (ZZZZ) which could not be found」 というエラーが出たら、その右側の「Authorize resources」をクリックして右上の「Run new」をクリック、「Run」をクリック
    - 「This pipeline needs permission to access a resource before this run can continue」というエラーが出たら、「View」をクリックし、「Permit」をクリック。再度「Permit」をクリック。
- Azure portal (portal.azure.com)での作業
  - App Service の Webアプリに「参照」でアクセスする。pipelines_dotnet_coreという、先程とは別のWebサイトが表示されている。
  ![](images/ss-2021-12-15-09-30-09.png)



参考:
- [最初のパイプラインの作成(.NET)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=tfs-2018-2%2Cbrowser%2Cnet#create-your-first-pipeline-1)
- [.NET Core アプリをビルド、テスト、デプロイする](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=dotnetfive)
- [Azure App Service Web アプリをデプロイする](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/targets/webapp?view=azure-devops&tabs=yaml%2Cwindows)



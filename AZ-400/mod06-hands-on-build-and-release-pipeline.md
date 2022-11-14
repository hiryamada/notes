
# ハンズオン ラボ: Azure Pipelines ビルドパイプラインとリリースパイプライン

■Azure App Service Webアプリの作成

- Azure portalに移動。https://portal.azure.com
- 画面上部の検索で「App Service」を検索し「App Service」を選択
- リソースグループ: 新規作成, rg1, OK
- 名前: `hello12345678`
  - ※数値部分は乱数を適当に打ち込む
  - ※この名前は、あとで使うのでコピーしておく。
- ランタイムスタック: `.NET 6 (LTS)`
- オペレーティングシステム: Windows
- ※その他はすべてデフォルト値
- 確認及び作成
- 作成
- ※デプロイが完了するまで待つ
- リソースに移動
- 参照
- 「Microsoft Azure」「Your web app is running and waiting for your connect」が表示されることを確認

■新しいASP.NET Core Webアプリ(C#)を作成

- Cloud Shell (bash) を起動
- 以下を実行

```
dotnet new web -n hello
cd hello
dotnet new gitignore
git init
git add -A
git config --global user.name 'test'
git config --global user.email 'test@example.com'
git commit -m 'initial commit'
```
※Cloud Shellはあとでまた使うのでこのままにしておく

■新しいプロジェクトを作成

- Webブラウザの別タブを開く
- Azure DevOpsの画面に移動 https://dev.azure.com
- `+ New Project`
- Project name: `hello`
- Visibility: `Private`
- Create

■Git用のPersonal Access Tokenの取得

- 画面右上の、右から2番めのアイコンをクリック
- Personal Access Tokens
- `+ New Token`
- Name: gitpassword
- Codeの`Full`にチェック
- Create
- 表示されたTokenをコピーしておく。後で使うのでメモ帳等にコピー

■ReposにコードをPushする

- プロジェクトのReposに移動
- 「Push an existing repository from command line」の下のテキストボックスに書かれた文字列をコピー。
- コピーしたコマンドを、さきほど使用したCloud Shellに貼り付けて実行
- パスワードの入力が求められるので、先程コピーしたTokenを貼り付ける
- ReposのFilesをクリック
- Files（ファイル一覧）に、`Program.cs`等のファイルが入ってきたことを確認

■Service Connectionの作成

- Azure DevOpsの画面に移動 dev.azure.com
- hello プロジェクトをクリック
- Project Settings
- PipelinesのService connections
- Create Service Connection
- Azure Resource Manager
- 画面下までスクロールして「Next」
- Service principal (automatic)を選択して「Next」
- 別のブラウザウィンドウがポップアップで開き、Azureのサインイン画面が表示される。今回のトレーニング用に作成したMicrosoftアカウントでサインイン。
- Resource groupは選択せず、空白のままとする
- Service connection name: sc2
- Save

■ビルドパイプラインの作成

- Pipelinesに移動
- Create Pipeline
- Azure Repos Git
- hello リポジトリ
- Starter pipeline

中身を以下に書き換える

```
trigger:
- main

pool:
  vmImage: ubuntu-latest

variables:
  buildConfiguration: 'Release'

steps:
- script: dotnet build --configuration $(buildConfiguration)
  displayName: 'dotnet build $(buildConfiguration)'

- task: DotNetCoreCLI@2
  inputs:
    command: publish
    publishWebProjects: True
    arguments: '--configuration $(BuildConfiguration) --output $(Build.ArtifactStagingDirectory)'
    zipAfterPublish: True

# this code takes all the files in $(Build.ArtifactStagingDirectory) and uploads them as an artifact of your build.
- task: PublishPipelineArtifact@1
  inputs:
    targetPath: '$(Build.ArtifactStagingDirectory)' 
    artifactName: 'myWebsiteName'

```

- Save and run
- Save and run
- Jobに「青の丸に時計」のアイコンが表示される
- しばらく待つ。数十秒で、Jobのアイコンが回転し始める
- Jobに「緑の丸にチェック」のアイコンが表示され、Statusが「Success」となったことを確認。

■リリースパイプラインの作成

- 画面左メニューのPipelinesの下の「Releases」をクリック
- New Pipeline
- Azure App Service deployment
- Apply
- 「+ Add an artifact」をクリック
- Source type: Build
- Source (build pipeline): hello
- Add
- 「Stage 1」の下の「1 job, 1 task」をクリック
- Deploy Azure App Service
- Parametersの「Azure subscription」の下のプルダウンで sc2 を選択
- 「App service name」: hello12345678 ※前のステップで作成したApp Serviceの名前
- Save
- OK
- 画面左メニューのPipelinesの下の「Releases」をクリック
- Create a release
- Create
- しばらく待つ。数十秒で、「Stage 1」のボタン内のアイコンが回転し始める
- さらに待つと、「Stage 1」のボタン内のアイコンが「緑の丸にチェック」になる

■Azure App Service Webアプリのデプロイ結果の確認

- Azure portalに移動。 https://portal.azure.com
- 画面上部の検索で「App Service」を検索し「App Service」を選択
- 一覧で、作成済みのWebアプリをクリック
- 参照
- Hello world! と表示されることを確認。

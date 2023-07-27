<!--
- (2023/4/27)現在、Azure PipelinesでKubernetesの設定が失敗します。
- [ワークアラウンド](https://developercommunity.visualstudio.com/t/New-Kubernetes-service-connection-causes/10138123)があるのですが、こちらを実施しても正しく動作させることはできませんでした。
- AKSでKubernetes最新バージョンを使用しても改善しませんでした。
- 代わりに、[「訂正版」](mod16-handson-aci.md)を実施ください。Kubernetesの代わりにACIを使用します。
-->

# ハンズオン Azure DevOps + Azure Kubernetes Service

■ハンズオンの概要

- Azure Reposに、開発したコード一式を格納します
- Azure Container RegistryとAzure Kubernetes Serviceを準備します
- Azure Pipelinesで、次のパイプラインを作成します
  - Dockerイメージをビルド
  - Azure Container Registryにイメージをプッシュ
  - イメージをAzure Kubernetes Serviceにデプロイ
- Azure Kubernetes ServicesでWebアプリの動作を確認します

<!--
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
-->

■Azure Container Registry (ACR) と Azure Kubernetes Service (AKS) の準備

- Azure portalへ移動 https://portal.azure.com
- Cloud Shellで、Bashを起動（または選択）
- 以下のコマンドを投入。
  ```
  az provider register --namespace Microsoft.ContainerRegistry # acr
  az provider register --namespace Microsoft.ContainerService # aks
  az provider register --namespace Microsoft.OperationalInsights # monitoring
  az provider register --namespace Microsoft.OperationsManagement # monitoring
  az group create --name hello_rg --location japaneast
  name=hello$(date|md5sum|head -c8)
  az acr create \
    --name $name \
    --resource-group hello_rg \
    --sku Basic
  #az aks create \
  #  --resource-group hello_rg \
  #  --name $name \
  #  --node-count 1 \
  #  --enable-addons monitoring \
  #  --generate-ssh-keys \
  #  --node-vm-size Standard_D2as_v4 \
  #  --kubernetes-version 1.27.1
  ```

■AKSクラスターを作成

- 「AKS」で検索、「Kubernetesサービス」へ移動
- 作成＞Kubernetesクラスターの作成
- リソースグループ hello_rg を選択
- クラスター名 (mycluster1 など、適当に指定)
- Kubernetesバージョン 1.27.1
- 確認および作成、作成

■新しいプロジェクトを作成

- Azure DevOpsの画面に移動 https://dev.azure.com
- `+ New Project`
- Project name: `dockerwebapp1`
- Visibility: `Private`
- Create

<!--
■Git用のPersonal Access Tokenの取得

- 画面右上の、右から2番めのアイコンをクリック
- Personal access tokens
- `+ New Token`
- Name: gitpassword2 （など、適当に）
- Codeの`Full`にチェック
- Create
- 表示されたTokenをコピーしておく。後で使うのでメモ帳等にコピー
- Close

-->

■Azure ReposにコードをImportする

<!--
- プロジェクトのReposに移動
- 「Push an existing repository from command line」の下のテキストボックス内のコマンドをコピー
- Visual Studio Codeに切り替える
- Terminalに、コピーしたコマンドを投入
- パスワードの入力が求められるので、先程コピーしたTokenを貼り付ける
- ReposのFilesをクリック
- Files（ファイル一覧）に、`Program.cs`等のファイルが入ってきたことを確認
-->

- プロジェクトのAzure Repos をクリック
- 下にスクロール
- Importをクリック
- Clone URLに `https://github.com/hiryamada/dockerwebapp` を入力し、Importをクリック
- インポートが完了するまでしばらく待つ

■Azure Pipelinesの準備

- Pipelinesをクリック
- Create Pipeline
- Where is your code? → Azure Repos Git
- Select a repository →  `dockerwebapp1`
- Configure your pipeline: Deploy to Azure Kubernetes Service
  - ※「Deploy to Kubernetes - Review app with Azure DevSpaces」という似たようなものがあるので注意
- サブスクリプションの選択: Azure Pass - スポンサー プラン
- Continue
- 別ウィンドウで認証が求められた場合は、トレーニング開始時に作成したMicrosoftアカウントでサインイン
- Cluster: 選択肢から選択できるクラスター(myapp～～)
- Namespace: New, `hello`
- Container Registry: 選択肢から選択できるレジストリ(myapp～～)
- Image Name: hello
- Service Port: 80
- Validate and configure
- (パイプラインのYAMLが生成される)
- Save and run
- 再度 Save and run
  - ここで、3つのファイルがリポジトリに追加される
- BuildとDeployのステージが表示され、ジョブ実行が進行する。
  - `No hosted parallelism has been purchased ...`と表示された場合
    - Project Settings＞Pipelines＞Parallel Jobs、Microsoft-hostedの「0」の脇の「Change」をクリック。Set Up Billingをクリック。「Azure Pass - スポンサー プラン」を選択し、「Save」。「MS Hosted CI/CD」に「1」をセットし、画面下「Save」。
    - Pipelinesの画面に戻り、赤い✕が付いたパイプラインをクリック。
    - Runsのテーブルの行「Set up CI with Azure Pipelines」をクリック
    - Rerun failed jobsをクリック。
    - Yes
  - `This pipeline needs permissin to access a resource ...` と表示された場合は、View, Permit, Permit とクリック。
- Deployステージが正常に完了（緑の丸にチェック）したらOK


■Webアプリへのアクセス

- 画面左Pipelines以下のEnvironments をクリック
- helloをクリック
- Resourcesで、「hello」（青いKubernetesアイコン）をクリック
- Servicesをクリック
- External IP をコピー
- 新しいWebブラウザタブを開き、アドレス欄に、コピーしたExternal IPを貼り付け、アクセス
- `Welcome to Azure training!` と表示されればOK

<!--
■ハンズオンの確認

- 開発環境として labvm (Windows VM) を準備しました
- Docker実行のため、dockervm（Linux VM）を準備しました
- .NET で、Webアプリを作成しました
- WebアプリをDockerコンテナー化しました
- Azure Reposに、開発したコード一式を格納しました
- Azure Container RegistryとAzure Kubernetes Serviceを準備しました
- Azure Pipelinesで、次のパイプラインを作成しました
  - Dockerイメージをビルド
  - Azure Container Registryにイメージをプッシュ
  - イメージをAzure Kubernetes Serviceにデプロイ
- Azure Kubernetes ServicesでWebアプリの動作を確認しました
-->

■クリーンナップ（不要なリソースの削除）

- Azure portalに移動
- リソースグループ一覧
- 作成されたリソースグループを削除

以上です。おつかれさまでした！

# ハンズオン: SonarCloudによるコード解析

- メモ帳の準備
  - 以下の内容をコピーし、メモ帳に貼り付けておく。
  - 以降の作業で使用する情報の記録に利用する.
    ```
    (1)PAT: 
    (2)token: 
    (3)organization: 
    (4)Project Key: 
    (5)Project Name: 
    ```
- Azure DevOps組織の設定
  - Azure DevOps の Organization Settings に移動
  - Security の Policies
  - Allow public projectsを On にし、Save
- Azure DevOpsでプロジェクトを準備
  - Azure DevOps で新しいプロジェクトを作成
  - Project name: SonarCloudLab
  - Visibility: Public
  - Create
  - Reposに移動
  - Import
  - Clone URL: https://github.com/SonarSource/sonar-scanning-examples.git
  - Import
- MarketplaceでSonarCloud拡張機能を追加
  - Marketplace に移動 https://marketplace.visualstudio.com/azuredevops
  - SonarCloud で検索
  - SonarCloud (SonarSource, オレンジと白のアイコン) をクリック
  - Get it free
  - Select an Azure DevOps organization: デフォルトでDevOps組織が選択されている。Install
  - Proceed to organization
  - Azure DevOpsのトップ画面に移動  https://dev.azure.com/
  - 画面右上の右から4つ目のアイコン（カバン）をクリック
  - Manage extensions
  - Installed に SonarCloud by SonarSource が表示されていればOK。
- Azure DevOps の PAT(パーソナルアクセストークン)を生成
  - Azure DevOpsのトップ画面に移動  https://dev.azure.com/
  - 画面右上の右から2つ目のアイコン（User settings）をクリック
  - Personal Access Tokens
  - New Token
  - Name: SonarCloud
  - Codeの Read & write にチェック
  - Createをクリック
  - 生成されたPATをメモ帳(1)PAT: に貼り付けて記録しておく
- SonarCloudアカウントの準備
  - https://sonarcloud.io/account
  - With Azure DevOps
  - 「このアプリがあなたの情報にアクセスすることを許可しますか?」と表示された場合は「はい」
  - 画面左上の「sonarcloud」をクリック
  - Import an organization from Azure
  - Azure DevOps organization name: 組織名をペースト
  - Personal Access Token: Tokenをペースト
  - Continue
  - (Import organization details が表示される。ここのKeyは保存不要) 
  - Continue
  - Free planが選択されている。
  - Create Organization
  - SonarCloudLabにチェック
  - Set Up
  - With Azure DevOps Pipelines
  - Continue
  - 画面に表示される token をコピー
  - tokenをメモ帳(2)token: に貼り付けて記録しておく
  - .NETをクリック
  - SonarCloud organization, Project Key, Project Name をコピーし、メモ帳(3)(4)(5)に貼り付けて記録しておく
- SonarCloudの「サービス接続」の作成
  - Azure DevOpsのプロジェクト SonarCloudLab を選択
  - Project Settings
  - Pipelines の Service connections
  - Create service connection
  - SonarCloud を選択して Next
  - SonarCloud Token に、記録しておいた(2) token を入力して Verify
  - Verification Succeeded と表示される
  - Service connection name: SonarCloudConnection
  - Veryfy and save
- Azure Pipelinesでパイプラインを準備
  - プロジェクトのPipelineに移動
  - Create Pipeline
  - Azure Repos Git
  - SonarCloudLab
  - .NET Desktop
- パイプラインにSonarCloudのタスクを追加-1(SonarCloudPrepare)
  - `task: VSBuild@1` の上に表示されているSettingsの上の空行をクリック
  - Show assistant
  - sonar で検索, Prepare Analysis Configuration を選択
  - SonarCloud Service Endpoint: SonarCloudConnection
  - Organization: プルダウンをクリックしてメモ帳(3)の組織を選択
  - Choose the way to run the analysis: Integrate with MSBuild
  - Project Key: メモ帳(4)Project Key の値を貼り付け
  - Project Name: メモ帳(5)Project Name の値を貼り付け
  - Add
  - `task: NugetToolInstaller@1` と `task: VSBuild@1` の間に `task: SonarCloudPrepare@1` が挿入される。
- パイプラインにSonarCloudのタスクを追加-2(Run Code Analysis)
  - YAMLファイルの末尾の行をクリック
  - Tasksで、sonar で検索, Run Code Analysis をクリック
  - 以下のように、VSBuildとVSTestを、SonarCloudPrepareとSonarCloudAnalyzeで囲むようにタスクが配置されていることを確認。![](images/ss-2021-12-17-09-19-10.png)
- パイプラインを実行
  - Save and run
  - 再度Save and run
  - Job が Queued となる。Jobをクリック
  - This pipeline needs permission to access a resource before this run can continue と表示される。View をクリック
  - Permit, 再度 Permit
  - しばらく待つ。
  - Jobが実行される。
    - すべてのジョブがエラー（赤い丸）が出ることなく実行されると、Jobが成功（緑の丸）となる。
- SonarCloudの分析結果を確認
  - SonarCloud に移動 https://sonarcloud.io/projects
  - プロジェクト SonarCloudLab をクリック
  - 画面左 Main Branch
  - 1 Bugs の 1 をクリック
  - 赤くなっている Change this condition so ... という部分をクリック。コードの問題点が表示される。
    - Why is this an issue? をクリック。なぜそれが問題なのかという理由が表示される。
  - ←をクリック
  - Code Smell をクリック
  - 赤くなっている Add a `protected` constructor ... をクリック。コードの問題点が表示される。
    - Why is this an issue? をクリック。なぜそれが問題なのかという理由が表示される。
  - ←をクリック
  - 赤くなっている Remove this method and ... をクリック。コードの問題点が表示される。
    - Why is this an issue? をクリック。なぜそれが問題なのかという理由が表示される。
- SonarCloudで報告されたバグ/コードスメル（コードの臭い）を修正する
  - Azure DevOpsのプロジェクトのReposに移動
  - Filesで以下のようにフォルダ/ファイルを開く
  - sonarqube-scanner-msbuild
  - CSharpProject
  - SomeConsoleApplication
  - Program.cs を以下のように修正する（Editをクリックし、ファイルの中身を削除し、以下のコードに置き換え、Commit）
    ```
    using System;
    namespace SomeConsoleApplication
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                var iAmTrue = AlwaysReturnsTrue();
                if (iAmTrue)
                {
                    Console.WriteLine("true");
                }

                Console.ReadKey();
            }

            public static bool AlwaysReturnsTrue()
            {
                return Flag;
            }

            public const bool Flag = true;

            public static object Passthrough(object obj)
            {
                return obj;
            }
        }
    }
    ```
  - Azure Pipelinesに移動し、パイプラインのRun（Updated Program.cs）の実行が終わるのを待つ
- SonarCloudの分析結果を確認
  - SonarCloud に移動 https://sonarcloud.io/projects
  - プロジェクト SonarCloudLab をクリック
  - バグ/コードスメルが0になったことが確認できる。
![](images/ss-2021-12-17-09-17-57.png)
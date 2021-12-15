# GitHub

https://github.com/

■Microsoftによる買収

[2018年6月、MicrosoftがGitHub買収を発表](https://japan.cnet.com/article/35120250/)、[同年10月に買収を完了](https://japan.zdnet.com/article/35127696/)し、現在はMicrosoftの傘下となっている。[買収額は75億ドル（約8200億円）。](https://www.businessinsider.jp/post-168744)

Microsoftが以前運用していた[CodePlex](https://ja.wikipedia.org/wiki/CodePlex)（オープンソースプロジェクトのための無料ホスティングサービス）は[2018年1月30日にサービス終了。GitHubへの移行が推奨されている。](https://www.infoq.com/jp/news/2017/04/codeplex-github/)

[2019年5月、GitHubアカウントでAzureへのサインインが可能となった。](https://www.publickey1.jp/blog/19/githubazuregithubazure_active_directorymicrosoft_build_2019.html)

■GitHubとAzure DevOpsは今後どうなるか。

- GitHubもAzure DevOpsも存続される
  - GitHubがなくなってAzure DevOpsに統一されたり、逆にAzure DevOpsがなくなってGitHubに統一されたりすることはない。引き続きどちらも利用できる。
  - GitHubは今までと同じように利用できる
    - Microsoftは[GitHubの独立性の維持を約束している](https://www.sbbit.jp/article/cont1/35103)
    - [オープンソースの文化に配慮し、「何も変えない」と宣言している](https://www.itmedia.co.jp/pcuser/articles/1807/01/news011.html)
- 連携の強化
  - [Azure DevOpsとGitHubは同じチームが開発している](https://codezine.jp/article/detail/12089)
  - 機能の連携については、[今後、さらに統合を加速させていく](https://codezine.jp/article/detail/12089)とされている。
- 内部的にGitHubとAzure DevOpsで同じコンポーネントを使用している箇所がある
  - [GitHub Actionsのランナー（Azure Pipelinesの「エージェント」に相当）](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners#about-virtual-environments):
    - Azure Pipelinesのエージェントのフォーク。
    - AzureのVM (Standard_DS2_v2) でホスティングされている。

■参考: Azure DevOps と GitHub の機能の関連

https://www.linkedin.com/pulse/azure-devops-future-after-github-acquisition-microsoft-antonio-alvino/

■Azure DevOpsとの機能の比較

|機能|Azure DevOps|GitHub
|-|-|-|
|タスク管理|Azure Boards|[Issue](https://docs.github.com/ja/issues)|
|リポジトリ|Azure Repos|[リポジトリ](https://docs.github.com/ja/github/getting-started-with-github/quickstart/create-a-repo)|
|CI/CD|Azure Pipelines|[GitHub Actions](https://docs.github.com/ja/actions)|
|パッケージ管理|Azure Artifacts|[GitHub Packages](https://docs.github.com/ja/packages/learn-github-packages/introduction-to-github-packages)|
|テスト管理|Azure DevTest Labs|[サードパーティテストツールとの統合](https://github.com/marketplace/category/testing)|
|Wiki|[Wiki](https://docs.microsoft.com/ja-jp/azure/devops/project/wiki/wiki-create-repo?view=azure-devops&tabs=browser)|[ウィキ](https://docs.github.com/ja/communities/documenting-your-project-with-wikis/about-wikis)|
|組織での利用|[Azure AD](https://docs.microsoft.com/ja-jp/azure/devops/organizations/accounts/access-with-azure-ad?view=azure-devops)|[Organization](https://docs.github.com/ja/organizations/collaborating-with-groups-in-organizations/about-organizations)|
|オンライン開発環境|[Visual Studio Code for the Web](https://vscode.dev/)|[GitHub Codespaces](https://github.co.jp/features/codespaces)|
|AIペアプログラミング||[GitHub Copilot](https://copilot.github.com/)|
|コード分析||[CodeQL](https://codeql.github.com/docs/)|
|Webサイトホスティング||[GitHub Pages](https://docs.github.com/ja/pages)|
|マーケットプレース(拡張機能)|[Visual tudio Marketplace](https://marketplace.visualstudio.com/azuredevops)|[Marketplace](https://github.com/marketplace)|

## GitHubのフォーク

[→GitHubのフォーク・クローン・インポート](pdf/GitHubのフォーク.pdf)

## ラボ（ハンズオン）

- GitHubアカウントの作成
  - [作成手順](github-account.md)

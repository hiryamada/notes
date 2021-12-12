# モジュール6 Azure Pipelinesを使用した継続的な統合の実装

- 継続的インテグレーションとは。
- 継続的インテグレーションの4つの構成要素とは。
- 継続的インテグレーションのメリットとは。
- ビルド番号とは。バージョンとの違いは。
- ジョブアクセストークンとは。
- ジョブアクセストークンの承認スコープとは。
- バッジとは。
- エージェント要求とは。
- YAMLパイプラインの定義方法。
  - ステージ、ジョブ、ステップ、タスク
- 環境とは。リソースとは。
- マルチ エージェント ビルドとは。
- 複数のリポジトリからソースコードを取り出してビルドするには。
- Azure Pipelinesは、どのソースコード管理システムと連携できるか。

## 継続的な統合の概要

※パイプラインの基本については[モジュール5](mod05.md)で学習済み。

- パイプラインを使用してプロジェクトの作業を自動化することができる
- Azure Pipelineを使用してパイプラインを構築することができる
- Azure Reposなどからのソースコードの取得、ビルド、デプロイなどのタスクを実行できる

このモジュールでは一歩踏み込んで、CI（継続的インテグレーション）の詳細と、Azure Pipelinesでの実装について学ぶ。

※CD（継続的デリバリー）についてはモジュール8～12で解説。

### 継続的な統合の概要

継続的インテグレーションとは。

[継続的インテグレーション(CI)](https://docs.microsoft.com/ja-jp/devops/develop/what-is-continuous-integration) とは、チーム メンバーがバージョン管理 に変更をコミットするたび、コードのビルドとテストを自動的に行うプロセス。

- コードをコミットする
- 自動化されたビルド システムが起動
- 共有リポジトリから最新のコードを取得
- ビルド、テスト、および検証

### 継続的な統合の 4 つの柱

継続的インテグレーションの4つの構成要素とは。

- バージョン管理システム
  - Git など
- パッケージ管理システム
  - NuGet、NPM など
- 継続的インテグレーションシステム
  - Azure DevOps（Azure Pipelines）、Jenkins、TeamCity、Circle CIなど。
- 自動ビルド プロセス
  - Ant、Gradleなど

どのプラットフォームとツールを使用するかは、プロジェクトチームで選択する。

[Azure Pipelinesと連携して使えるかどうかを確認](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/ecosystems/ecosystems?view=azure-devops)するとよい。

### 継続的な統合の利点

継続的インテグレーションのメリットとは。

- 迅速なフィードバックに基づいてコード品質を向上させる
  - フィードバック: ビルドやテストが失敗する場合、そのことをすばやく発見できる
- あらゆるコード変更の自動テストをトリガーする
  - パイプラインの中で自動テストを実行できる。
- 迅速なフィードバックと問題の早期発見 (リスク低減) のためにビルド時間を短縮する
  - ビルドが人手ではなく、自動で実行される。
- 技術的負債の管理とコード分析の実施を改善する
  - [モジュール3](mod03.md)で学習済み。
- 長く、難しく、バグを誘発するマージを減らす
  - かつて、CIを使わないマージには人手と時間が必要だった。
  - マージを専門に行う[「マージ担当者」や「マージ部署」があった](https://www.ishikihikui-kei.com/entry/version-manage)。
  - [マージ（Wikipedia）](https://ja.wikipedia.org/wiki/%E3%83%9E%E3%83%BC%E3%82%B8_(%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%B3%E7%AE%A1%E7%90%86%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0))
  - マージ職人、ビルド職人、リリース職人などの「職人」に頼るしかなかった
- 運用環境のデプロイのかなり前から、コードベースの健全性に対する信頼を高める


### ディスカッション - CI 実装の課題

講師（山田）は昔、開発案件で、[Jenkins](https://cloudbees.techmatrix.jp/jenkins/), [AWS CodePipeline](https://aws.amazon.com/jp/codepipeline/) などを使用したことがあります。課題としては、昔はJenkinsのサーバー自体をセットアップするのが大変だったという記憶があります（その点、AWS CodePipelineはすぐに使えて便利でした）。かなり昔の開発現場では、CIという仕組みを使っておらず、プログラマがそれぞれ自分の端末で開発したコードをSubversionにコミットし、その後共用のビルド&テストのサーバーでそれぞれ勝手にビルドして動作確認する、といったことをしていました（そのサーバーは1台しかないので順番待ちになりがちでした）。みなさんはいかがですか？

なにか思い出や教訓などがございましたら、ぜひチャットに書き込んでください。

### ビルドの番号の書式とステータス

ビルド番号とは。

パイプラインの実行(run)には、「ビルド番号」が付与される。

簡単に言えば、ビルドのたびに番号が付与され、その番号は1ずつ増やされる。

[参考1](https://www.atmarkit.co.jp/icd/root/69/65528369.html)

> プログラムの開発工程において、コンパイルやアセンブル、リンクなどの作業を経て最終的な実行プログラムを生成することをビルドするというが、ビルドされた実行プログラムを識別するために付けられたユニークな番号のことをビルド番号という。通常は、1回ビルドするたびにビルド番号を1つずつ増加させ、どのビルド（によって生成されたプログラム）であるかを識別するために使われる。
> 
> ビルド番号はバージョン番号と似ているが、その意味は異なっている。バージョン番号は、プログラムの機能や開発時期、リンクするライブラリ・モジュールのバージョンの違いなどに応じて異なる番号が与えられるが、ビルド番号は単にビルドした回数を反映した、最終生成物の識別用の番号に過ぎない。
> 
> ...
> 
> ビルドをテストしたり、ユーザーに配布したりするためには、バージョン番号ではなく、どのビルドであるかを簡単に特定できることが望ましい。このために利用されるのがビルド番号である。例えばテストの結果、以前のビルド100にあった不具合が本日のビルド101では修正されている、というふうに利用できる。
> 
> ビルド番号は、基本的には開発者が使う内部的な識別番号であるが、場合によっては積極的に公開している場合もある。例えばマイクロソフト社が開発しているWindows XP ProfessionalというOSには「Microsoft Windows XP [Version 5.1.2600]」という番号が付いている。「5.1」はOSのメジャーとマイナー・バージョン番号であり、「2600」はビルド番号2600を表している。これは、最初のWindows NTから数えて、2600回目のビルドであるということを表している。

[参考2](https://e-words.jp/w/%E3%83%93%E3%83%AB%E3%83%89%E7%95%AA%E5%8F%B7.html)

> オペレーティングシステム（OS）のような大規模なソフトウェアでは、あるバージョンの開発を始めてから発売までに数千回のビルドとテストを繰り返す場合もある。発売・公開後もビルドの更新が継続されることも多く、自動アップデートなどを通して利用者に新しいビルドが送り届けられる。


ビルド「番号」とはいっても数値とは限らず、プロジェクト名、ブランチ名、日付、時刻などを組合わせることができる。

ビルド番号により、各ビルド（パイプラインの実行による成果物）に、チームにとって意味のある、より便利な名前（情報）を付け加えることができる。たとえば「ビルド 2935」よりも「ビルド Fabrikam_CIBuild_master_20190505.2」のほうが情報量が多いため、ある特定のビルドをより的確に表すことができる。

ビルド番号はカスタマイズすることができる。[実行番号またはビルド番号を構成する](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/run-number?view=azure-devops&tabs=yaml)

YAMLファイル内にて以下のようにして`name`で定義し、`$(Build.BuildNumber)`で参照する。

```
name: $(TeamProject)_$(Build.DefinitionName)_$(SourceBranchName)_$(Date:yyyyMMdd)$(Rev:.r)

steps:
  - script: echo '$(Build.BuildNumber)' # ビルド番号を参照（出力）
```

`name:` の右側の`$(Rev:.r)` のような部分をトークンと呼ぶ。トークンは実行時に日付、時刻、プロジェクト名、リビジョン（ビルドの回数をカウントする整数）などに置換される。

最大文字数は255文字。

指定しない場合、一意の整数が指定される。


■バージョン番号との違いは？

バージョン番号は、ビルド番号とは違い、開発者が割り当てる。最近は「セマンティックバージョニング」に従ってバージョン番号を付与する場合が多い。

バージョン番号は、[Gitのタグで記録する](https://www.google.com/search?q=%E3%82%BB%E3%83%9E%E3%83%B3%E3%83%86%E3%82%A3%E3%83%83%E3%82%AF%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%8B%E3%83%B3%E3%82%B0+git+tag)。

成果物をパッケージとしてリリースする際は、ビルド番号ではなく、[Gitタグに基づくバージョン番号を付与する](https://docs.github.com/ja/github/administering-a-repository/releasing-projects-on-github/about-releases)。

各バージョンで何が変更されたのかという情報については、モジュール4で解説した「変更ログ」（Changelog）に記載される。

バージョン番号は、基本的には開発者が手動で番号を割り当てていく（上げていく）ものなので、[間違いがあったり、具体的にどの部分が変更されたのかがバージョン番号からはわからないといった問題がある](https://sdl.ist.osaka-u.ac.jp/pman/pman3.cgi?DOWNLOAD=412)。

■セマンティックバージョニングとは？

参考: [セマンティックバージョニング](https://ja.wikipedia.org/wiki/%E3%82%BB%E3%83%9E%E3%83%B3%E3%83%86%E3%82%A3%E3%83%83%E3%82%AF%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%8B%E3%83%B3%E3%82%B0)


> セマンティック・バージョニング（英語：Semantic Versioning）とは、ソフトウェアのバージョニング方法の一つ。
> 「1.23.45」といったように"."で区切った3つの数字で表される。
> 
> 前から順にメジャーバージョン、マイナーバージョン、パッチバージョンと呼ぶ。
> 
> APIの変更に互換性のない場合はメジャーバージョンを、後方互換性があり機能性を追加した場合はマイナーバージョンを、後方互換性を伴うバグ修正をした場合はパッチバージョンを上げる。


[.NET Coreのバージョン番号規則もセマンティックバージョニングに従っている](https://docs.microsoft.com/ja-jp/dotnet/core/versions/)。

[semantic-release](https://github.com/semantic-release/semantic-release)というパッケージを使うことで、コミットのメッセージに従って、適切なセマンティックバージョニングを行うことができる（コミットメッセージを正しく書いていることが前提）。

### ビルド承認のタイムアウトとバッジ

- ジョブアクセストークンとは？
- タイムアウトとは？
- バッジとは？

#### ビルドジョブの承認スコープ (Build job authorization scope)

ドキュメント: [参照先の Azure DevOps リポジトリにジョブ承認スコープを制限する](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/access-tokens)

■「ジョブアクセストークン」とは？

実行時に、パイプライン内の各ジョブが Azure DevOps 内の他のリソースにアクセスすることがあります。

Azure Pipelines は、「ジョブアクセストークン」を使用してこれらのタスクを実行します。 「ジョブアクセストークン」 は、実行時に各ジョブの Azure Pipelines によって動的に生成されるセキュリティトークンです。

ジョブが実行されているエージェントは、Azure DevOps 内のこれらのリソースにアクセスするために、「ジョブアクセストークン」を使用します。

■「ジョブアクセストークン」の「スコープ」（承認スコープ）とは？

「ジョブアクセストークン」のスコープは「コレクション」または「プロジェクト」に設定できます。

スコープが組織レベルまたはプロジェクトレベルで制限されていない場合、YAML パイプライン内のすべてのジョブは、「コレクションスコープ」の「ジョブアクセストークン」を取得します。 言い換えると、**パイプラインは組織の任意のプロジェクト内の任意のリポジトリにアクセスできます**。

パイプラインが パブリックプロジェクト 内にある場合、どの設定で構成したかに関係なく、ジョブの承認スコープは自動的に プロジェクト に制限されます。 パブリックプロジェクト内のジョブは、プロジェクト内でのみビルド成果物やテスト結果などのリソースにアクセスでき、組織の他のプロジェクトからはアクセスできません。

■デフォルトの設定は？

新しい組織とプロジェクトが2020年5月以降に作成された場合、既定では、参照先の Azure DevOps リポジトリに対するジョブ承認スコープ が有効になります。

■「スコープ」を設定できる場所は？

「組織」または「プロジェクト」レベルで設定できる。

- Azure DevOps 組織で設定
- 特定のプロジェクトで設定

#### ビルドジョブのタイムアウト (Build job timeout in minutes)

[タイムアウト](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#timeouts): ジョブが応答していない場合や待機時間が長すぎる場合にリソースが使用されないようにするには、ジョブの実行を許可する期間の制限を設定することをお勧めします。 Job timeout 設定を使用して、ジョブを実行するための制限を分単位で指定します。 値を 0 に設定すると、ジョブを時間制限なく実行できることを意味します。

#### バッジ

ビルドの状態を「バッジ」（ステータスバッジ）として、GitHubのトップページ（README）に表示することができる。[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=java%2Ctfs-2018-2%2Cbrowser#add-a-status-badge-to-your-repository)

参考:
- https://maku.blog/p/teq2cmv/
- https://tech-blog.cloud-config.jp/2020-12-21-status-badge-of-azure-devops/

## ビルド戦略の実装

### エージェント要求の構成

すべてのセルフホステッド エージェントには、何が可能かを示す一連の「機能（Capabilities）」があります。

「機能（Capabilities）」の種類
- システム機能: マシン名やオペレーティング システムの種類など。自動的に検出される。
- ユーザー機能: ユーザーが定義するもの
  - マシンにインストールされている特定のソフトウェアのバージョンなど

パイプライン側で、「要求（demands）」を使用して、パイプラインが必要とする「機能（Capabilities）」が、それを実行するエージェント上に存在することを確認します。[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/demands?view=azure-devops&tabs=yaml)

### マルチ エージェント ビルドの実装

並列ビルドとは。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#multi-job-configuration)

1つのジョブで、複数のエージェントを使用して、複数のビルドやリリースを並列で行うことができます。

並列化することで、それぞれの作業を順番に実行する場合にくらべて、より早く作業を完了させることができます。

例:
- x86版(32 bit)とx64版(64 bit)を同時にビルドする
- ビルドした成果物を複数のリージョンに同時にデプロイする

### ディスカッション - ビルド関連のツール

講師（山田）は昔、Javaの開発案件で、[Maven](https://maven.apache.org/), [Gradle](https://gradle.org/) などのビルドツールを使用したことがあります。また、（ビルドツールと呼んでよいのかわかりませんが）Ruby on Railsで開発する際に、「[rails db:migurate](https://railsguides.jp/active_record_migrations.html#%E3%83%9E%E3%82%A4%E3%82%B0%E3%83%AC%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E5%AE%9F%E8%A1%8C%E3%81%99%E3%82%8B)」を使用してデータベースのスキーマ変更を行ったり、「[rails assets:precompile](https://railsguides.jp/command_line.html#rails-assets)」を使用して、JavaScriptやCSSをプリコンパイルする、といったことをやっていました。最近は、仕事柄、.NET(C#)のサンプルコードを記述する事が多く、[dotnet build](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-build) というコマンドを使用することがありますが、Visual Studio や Visual Studio Code を使用する場合は、F5を押してプロジェクトを実行する際に自動的にビルドが裏側で走るので、あまりビルドという作業自体を意識しないことも多いです。ただ、CI/CDを構成する場合は、明示的にビルドを実行するコマンドを指定しなければならない場面がありますね。

なにか思い出や教訓などがございましたら、ぜひチャットに書き込んでください。

## Azure Pipelinesとの統合

YAMLパイプラインの定義方法。

ここではAzure PipelinesのYAMLパイプラインについて解説します。

詳細についてはドキュメントを参照してください。

### パイプラインの構造

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml)

[リファレンス](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema)

#### name


パイプラインの実行の番号付け方法をカスタマイズできます。
パイプラインのルート レベルで指定します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/run-number?view=azure-devops&tabs=yaml)

```
name: $(TeamProject)_$(Build.DefinitionName)_$(SourceBranchName)_$(Date:yyyyMMdd)$(Rev:.r)

steps:
  - script: echo '$(Build.BuildNumber)' # outputs customized build number like project_def_master_20200828.1
```

#### trigger

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#triggers)

トリガーにはいくつかの種類がありますが、ここではプッシュトリガーについて説明します。

プッシュトリガー: 継続的インテグレーション ビルドを実行するブランチを指定します。
```
trigger:
- main
```

#### variables

変数を初期化します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#variables)

```
variables:
  VAR1: 'value1'
  VAR2: 'value2'
```

#### pool

ジョブで使用するプールを指定します。

パイプライン、ステージ、またはジョブ レベルでプールを指定できます。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#pool)


プールを使用するには、プールの名前を指定します。

```
pool: MyPool
```
Microsoft がホストするプールを使用するには、名前を省略し、[使用可能なホストされている イメージ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml#use-a-microsoft-hosted-agent)の1つを指定します。

```
pool:
  vmImage: ubuntu-16.04
```

#### steps

各ステップは、[スクリプト](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#script)や[タスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/?view=azure-devops)です。

以下は、スクリプトの利用例です。

```
steps:
- script: echo hello
- script: echo world
```

以下は、[「.NET Core CLI」タスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/dotnet-core-cli?view=azure-devops)の利用例です。`dotnet build`を実行します。

```
steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
```

#### jobs と job

ジョブ（エージェントで実行するステップの集まり）を指定します。

複数のステップを、ジョブにまとめて実行します。

ジョブの実行条件を指定したり、複数のジョブの依存関係を指定したりすることができます。（ジョブAとジョブBがどちらも終わったらジョブCを実行、など）

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#job)


`job:` の後ろに、ジョブの名前を指定します。

`steps:` で、ジョブのステップを指定します。

```
jobs:
- job: Job1
  steps:
  - script: echo Job1
- job: Job2
  steps:
  - script: echo Job2
```

#### stages と stage

ステージ（ジョブのあつまり）を指定します。

[承認](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/approvals?view=azure-devops&tabs=check-pass)を使用して、ステージを実行するかどうかを人が制御できます。

Microsoft Teamsで、承認の通知を送ることができます。[事例](https://qiita.com/okazuki/items/4e303ecdc099925084a1)

承認は、YAMLには記入せず、Azure Pipelinesの画面から設定します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#stage)


以下の例では、BuildとDeployという2つのステージを指定しています。Deployに対して承認を設定することで、担当者によって承認されたらデプロイを行うようにすることができます。

```
stages:
- stage: Build
  jobs:
    steps:
    - script: echo build
- stage: Deploy
  jobs:
    steps:
    - script: echo deploy
```


### Pipeline Structure

（パイプライン、ステージ、ジョブ、ステップ、タスクについてのサンプル。上記で説明済み）

### テンプレート

1 つのファイルに一連のステージを定義し、それを他のファイルで複数回使用することができます。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/templates?view=azure-devops)

例：build1.ymlでステージを定義し、azure-pipelines.ymlでステージを利用。

build1.yml
```
stages:
  stage: Build
  jobs:
    steps:
    - script echo build
```

azure-pipelines.yml
```
stages:
- template: build1.yml
```

### YAML リソース

環境とは。リソースとは。

「環境」とは、パイプラインからのデプロイの対象となる、Kubernetes クラスターや virtual machines などの「リソース」の集まり。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/environments-virtual-machines?view=azure-devops)

使用例:

- デプロイ先となるVMを作成する。
- Azure Pipelinesの「Environments」メニューから、新しい「Environment」（環境）を作る。環境の名前を指定し、種類として「Kubernetes」や「Virtual machines」を選択する。
- 続いて表示されるPowerShellスクリプト（Windows VMの場合）をコピーし、VM内で実行する。環境にそのVMがリソースとして登録される。
- YAMLパイプラインの中に、デプロイを行うステージを定義する。ステージの中で「deployment」ジョブを使用して、そこで、上記で作成した「環境」を指定する。
    ```
    jobs:
    - deployment: 
        environment: 
        name: WebServers
        resourceType: VirtualMachine
    ```

### パイプラインで複数のリポジトリを使用

複数のリポジトリからソースコードを取り出してビルドするには。

自分自身のリポジトリ（azure-pipelines.ymlが置かれているリポジトリ）以外のリポジトリを利用することができる。

[ドキュメント1](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/repos/multi-repo-checkout?view=azure-devops),
[ドキュメント2](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#repository-resource)

以下の例では、「repo1」として、このプロジェクトの中の「repo1」というAzure Reposリポジトリを参照し、「repo2」として、GitHubの「githubuser」ユーザーの「repo2」リポジトリを参照している。
```
resources:
  repositories:
  - repository: repo1
    type: git
    name: repo1
  - repository: repo2
    type: github
    name: githubuser/repo2    
```

そして、ステップの中で以下のようにして、自分自身のリポジトリ（self）と、repo1, repo2をチェックアウトしている。

```
steps:
- checkout: self
- checkout: repo1
- checkout: repo2
```

## 外部ソース管理をAzure Pipelinesと統合する

Azure Pipelines でサポートされているソース コントロールの種類

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/repos/?view=azure-devops)

Azure Pipelines （YAMLパイプライン）では、以下のリポジトリをサポートしている。

- Azure Repos Git
- GitHub
- GitHub Enterprise Server
- Bitbucket Cloud

Azure Pipelines (クラシック) では、上記に加えて、以下のリポジトリをサポートしている。

- Azure Repos TFVC
- Bitbucket Server
- Subversion

## セルフホステッド エージェントの設定



### Azure Pipelines との通信

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#communication)

エージェント（Azure Pipelinesのエージェントソフトウェアが登録されたマシン）とAzure Pipelineの通信は、エージェントから開始される。

エージェントがオンプレミスにある場合、オンプレミスからインターネットへのHTTPS（TCP ポート443番）が許可されていればよい。

エージェントは、Azure Pipelinesに定期的にアクセスし、実行すべきジョブがあれば、ジョブを実行する。

### ターゲットサーバーに展開する通信

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#communication-to-deploy-to-target-servers)

「ターゲットサーバー」とは、デプロイ先のサーバーを表す。ターゲットサーバーは、Azure VMの場合もあれば、オンプレミスのサーバーの場合もある。

Azure pipelineから、オンプレミスのサーバーにデプロイを行いたい場合、オンプレミスの「セルフホステッド エージェント」からデプロイを行う必要がある。

なお、Skillpipeドキュメントに「LOS」「見通し線」「視界」などと書かれているもの「Line of sight」（見通し、直接通信ができること）の略およびその日本語訳だが、デプロイやファイアウォールの分野における一般的な表現（IT用語）ではないと思われる。
- 無線通信の[LOS](https://www.sophia-it.com/content/LOS) - 無線通信における送信機（トランスミッタ）と受信機（レシーバ）の間を結ぶ直線距離
- 軍事（火気、射撃）用語の「[照準線(line of sight)](https://www.mod.go.jp/atla/nds/Y/Y0005B.pdf)」 - 照準具又は照準装置と目標を結ぶ線

オンプレミスのKubernetesクラスターをコントロールすることもできる。[事例](https://yomon.hatenablog.com/entry/2020/04/pipeline_private)

### その他の考慮事項

- 認証
  - エージェントを登録するには「エージェントプールの管理者」である必要がある
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/pools-queues?view=azure-devops&tabs=yaml%2Cbrowser#security)
- 個人用アクセストークン（PAT）
  - エージェントの登録時、PATは登録にのみ使用され、その後は使用されない。
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#personal-access-token-pat)
- 対話型とサービス
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#interactive-or-service)
- エージェントのバージョンとアップグレード
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#agent-version-and-upgrades)
- セルフホステッドエージェントのメリット
  - Microsoftホステッドはジョブ実行のたびにVMが破棄さえる
  - セルフホステッドエージェントは破棄されない
  - そのためキャッシュが効く、エージェントがすぐに稼働できる、といったメリットがある
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#private-agent-performance-advantages)
- 同じマシンへの複数のセルフホステッドエージェントのインストール
  - 可能
  - エージェントであまり多くの作業を行わない場合など

## ラボ

参考:
- [最初のパイプラインの作成(.NET)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=tfs-2018-2%2Cbrowser%2Cnet#create-your-first-pipeline-1)
- [.NET Core アプリをビルド、テスト、デプロイする](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=dotnetfive)
- [Azure App Service Web アプリをデプロイする](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/targets/webapp?view=azure-devops&tabs=yaml%2Cwindows)

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

応用:
[Integrate Your GitHub Projects With Azure Pipelines](https://azuredevopslabs.com/labs/azuredevops/github-integration/)

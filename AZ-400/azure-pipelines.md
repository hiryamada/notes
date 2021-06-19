# Azure Pipelines

[製品ページ](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/?view=azure-devops)

[料金（Azure DevOps）](https://azure.microsoft.com/ja-jp/pricing/details/devops/azure-devops-services/)

- Microsoft ホステッド ジョブ
  - 最初の1ジョブ 無料 (1800分/月)
  - 追加1ジョブごとに 4480円/月 （時間制限なし）
- セルフ ホステッド ジョブ
  - 追加1ジョブごとに 1680円/月（時間制限なし）

## 概要

Azure Pipelineとは。

- [継続的インテグレーション (CI)](https://docs.microsoft.com/ja-jp/devops/develop/what-is-continuous-integration)/[継続的デリバリー (CD)](https://docs.microsoft.com/ja-jp/devops/deliver/what-is-continuous-delivery) のサービス
- コードを自動的にビルド・テスト・デプロイ。その他、多数の[タスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/?view=azure-devops)も組み込み可能
  - ビルド
    - iOS: [Xcode](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/xcode?view=azure-devops)
    - [Android](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/android-build?view=azure-devops)
    - Xamarin: [Android](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/xamarin-android?view=azure-devops), [iOS](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/xamarin-ios?view=azure-devops)
    - [.NET](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/dotnet-core-cli?view=azure-devops)
    - Java: [Maven](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/maven?view=azure-devops), [Gradle](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/gradle?view=azure-devops), [Ant](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/ant?view=azure-devops)
    - JavaScript: [Grunt](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/grunt?view=azure-devops), [gulp](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/gulp?view=azure-devops)
    - [Go](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/go?view=azure-devops)
    - [Docker](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/docker?view=azure-devops)
  - テスト
    - [WebアプリのUIテスト（Selenium等）](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/test/ui-testing-considerations?view=azure-devops&tabs=mstest)
    - [テスト結果の発行](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/publish-test-results?view=azure-devops&tabs=trx%2Cyaml)
      - [.Net Core](https://docs.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=dotnetfive#run-your-tests), JUnit, NUnit, Ant, Maven, Gulp, Grunt, Xcodeなど
      - タスク内で実行されたテスト結果をパイプラインに発行して利用。[事例](https://aonasuzutsuki.hatenablog.jp/entry/2020/12/03/140531#NUnit%E3%81%AB%E3%82%88%E3%82%8B%E8%87%AA%E5%8B%95%E3%83%86%E3%82%B9%E3%83%88)
    - [Visual Studio テストランナー](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/vstest?view=azure-devops)
    - 負荷テスト: [Apache JMeter](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/run-jmeter-load-test?view=azure-devops)
    - モバイルアプリのテスト: [App Center](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/app-center-test?view=azure-devops)
  - デプロイ
    - Azureのサービス系
      - [Azure App Service](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-rm-web-app-deployment?view=azure-devops)
      - [Azure Function](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-function-app?view=azure-devops)
      - VM上の[IIS](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/iis-web-app-deployment-on-machine-group?view=azure-devops)
      - Blob Storageに[AzCopy](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-file-copy?view=azure-devops)を使って静的サイト等をデプロイ
    - パッケージ系
      - [Azure Artifacts / pypi(パイピーアイ)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/pypi?view=azure-devops&tabs=yaml)
      - [Azure Artifacts / npm(registry.npmjs.org)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/npm?view=azure-devops&tabs=yaml)
      - [Azure Artifacts / Nuget](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/nuget?view=azure-devops&tabs=yaml)
    - ストア系
      - [Windows Store](https://marketplace.visualstudio.com/items?itemName=MS-RDX-MRO.windows-store-publish)
      - [Google Play](https://marketplace.visualstudio.com/items?itemName=ms-vsclient.google-play)
      - [App storeへのリリース](https://marketplace.visualstudio.com/items?itemName=ms-vsclient.app-store)
    - その他
      - [GCP](https://marketplace.visualstudio.com/items?itemName=nexso.azure-devops-google-cloud-tools)
      - [AWS](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.aws-vsts-tools): S3, Beanstalk, Lambda, ECRなどと連携
- 様々なプログラミング言語
  - Java、JavaScript、Node.js、Python、.NET、C++、Go、PHP、XCode など
- 様々なアプリケーションプロジェクトで利用できる
  - .Net、Java、Node、Android、Xcode


### Azure Pipelines の主要な用語

- パイプラインとは

[パイプライン](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops)を使用して、CI/CDを自動化することができる。

パイプライン: ビルド・テスト・デプロイ（リリース）の手順を定義したもの。YAMLファイルで定義できる。

```
パイプライン: トリガーによって実行
└ステージ: ジョブを整理。「QA（品質管理）」、「運用」など。
 └ジョブ: 1つのエージェントで実行される、ステップの集まり。
  └ステップ: パイプラインの最小の構成単位。タスクまたはスクリプト。
   ├タスク: 事前に構成されたスクリプト
   └スクリプト: コマンドライン、PowerShell, Bashなど。
```


ステージ: ジョブのあつまり。

- オプションなので、不要であれば使用しなくてもよい。
- 複数のステージがある場合、デフォルトでは、定義された順に実行されていく
- 依存関係(dependsOn)を設定することができる
  - 特定の順序で実行させる
  - `dependsOn: []` （依存関係なし）と定義することで、並列で実行する
  - ファンアウト・ファンイン（ステージAが終わったらステージB・Cを起動し、B・Cが両方とも終わったらDを起動、など）

パイプラインの定義（YAML）については[モジュール6](mod06.md)で詳しく説明する。

## ホスト型エージェントと自己ホストエージェント

エージェントは、一度に1つのジョブを実行する、エージェントソフトウェアを使用するコンピューティングインフラストラクチャ。要するにWindows/Linux/Macなどのマシン。VMでもよいし、Mac Miniなどの、オンプレミスのコンピュータでもよい。

Windows/Linuxの場合は、更にそのマシン（エージェント）上でDockerコンテナーを起動し、そこでジョブを実行することもできる。

ジョブを実行するためには[エージェント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser)が必要。

いわゆる「ワーカー」のマシン。[Jenkinsでいう、ジョブを実行する「ノード」](https://knowledge.sakura.ad.jp/5433/)に相当。

### Microsoft ホステッドとセルフホステッド エージェント

エージェントの種類は2種類。
- Microsoft によってホストされるエージェント(Microsoft-hosted agents)
- セルフホステッド エージェント(Self-hosted agents)

2種類のエージェントの違い。

- Microsoft によってホストされるエージェント(Microsoft-hosted agents)
  - メンテナンスとアップグレードが自動的に行われます。
  - パイプラインを実行するたびに、パイプライン内の各ジョブに対して新しい仮想マシンが作成されます。
  - 仮想マシンは、1つのジョブの後に**破棄されます**。
    - これはメリットでもありデメリットでもある。
      - メリット: 環境が毎回リセットされるので、以前のビルドの影響がなく、トラブルが起きにくい。ステートレス。
      - デメリット: 同じビルドを実行する際に以前のビルドで利用した環境などのキャッシュを利用できない。
  - ジョブを実行する最も簡単な方法
  - ジョブの時間制限あり
- セルフホステッド エージェント(Self-hosted agents)
  - ジョブを実行するために独自に設定および管理するエージェント
  - Linux、macOS、Windows マシンに、エージェントのソフトウェアをインストールする
  - Dockerエージェントも利用できる（コンテナーをエージェント化できる）
  - ビルドとデプロイに必要な依存ソフトウェアをインストールするためのより詳細な制御が可能になる
  - マシン レベルのキャッシュと構成は実行から実行まで保持され、速度が向上する可能性がある
  - 1つのマシンに複数のエージェントをインストールすることもできる（推奨されない）
  - ジョブの時間制限なし

価格（再掲）
- Microsoft ホステッド ジョブ
  - 最初の1ジョブ 無料 (1800分/月)
  - 追加1ジョブごとに 4480円/月 （時間制限なし）
- セルフ ホステッド ジョブ
  - 追加1ジョブごとに 1680円/月（時間制限なし）

### ジョブの種類

ジョブがどこで実行されるか。

- エージェントプールジョブ
  - 最も一般的な種類のジョブ
  - [エージェントプール](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/pools-queues?view=azure-devops&tabs=yaml%2Cbrowser)内のエージェントで実行される
- [コンテナージョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops)
  - エージェント プール内のエージェント上のDocker/Windowsコンテナーでジョブを実行
  - 複数のコンテナーに対してそれぞれジョブを実行することもできる
    - [複数のジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops#multiple-jobs)
    - [方法（戦略）](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#strategies)
- [デプロイグループジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-group-phases?view=azure-devops&tabs=yaml)
  - 「クラシック」のみ
  - [デプロイグループ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/deployment-groups/?view=azure-devops)（デプロイ先となるAzure VMのグループ）のVM上で実行されるジョブ
- [エージェントレスジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#agentless-tasks)
  - エージェントが不要なジョブ
    - [遅延](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/utility/delay?view=azure-devops)、[REST API呼び出し](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/utility/http-rest-api?view=azure-devops)など

## エージェントプール

エージェントプールとは。

- エージェントプール
  - 定義
    - エージェントの集まり
    - 組織で共有される
  - 使用方法
    - パイプラインを作成するときに、パイプラインで使用するプールを指定
    - [要求](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/demands)を満たすエージェントでタスクが実行される
  - エージェントプールの応用
    - [複数のチームでAzure Pipelinesを運用する場合、プールを使って、エージェントをグループ化して整理することができる](https://qiita.com/uhooi/items/66a669290226138639b0)
    - [エージェントプールの中のエージェントはランダムで選択されるので、特定のエージェントを使いたい場合には、そのエージェントが含まれるプールを作って、プールを指定する](https://qiita.com/uhooi/items/66a669290226138639b0)
  - デフォルトのエージェントプール
    - 「Azure Pipelines」という名前の事前定義されたエージェントプールがある
    - 「[Microsoft によってホストされるエージェント(Microsoft-hosted agents)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml)」が用意されていて、すぐに利用できる
      - windows-2019
      - ubuntu-20.04
      - ubuntu-18.04
      - macOS-10.14
      - など
  - 作成方法
    - 組織の設定で、エージェントプールを作成
  - エージェントのアップデート
    - エージェントプールのエージェントをすべて（あるいは選択したものを）アップデートできる

## パイプラインとコンカレンシー（ジョブの同時実行）

複数のジョブを並列で実行するには。

プロジェクトで多数のジョブを実行する場合、基本的にはジョブはキュー（待ち行列）に入り、順番に実行されていく。

ただし、ジョブが「承認を待つ」状態になった場合は、別のジョブが起動される。承認が完了したらまたそのジョブはキューに入る。

[並列ジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted#what-is-a-parallel-job)を使用することで、複数のジョブを並列で実行することができる。

この仕組みを使うには追加の料金を支払う必要がある。（Azure Pipelines以外のCI/CDサービスでもだいたいそのような課金体系となっている）

価格（再掲）
- Microsoft ホステッド ジョブ
  - 最初の1ジョブ 無料 (1800分/月)
  - 追加1ジョブごとに 4480円/月 （時間制限なし）
- セルフ ホステッド ジョブ
  - 追加1ジョブごとに 1680円/月（時間制限なし）

## Azure DevOpsとオープンソースプロジェクト

Azure DevOpsのプロジェクトの設定で、プライベートとパブリックを選択できる。デフォルトはプライベートである。

オープンソースプロジェクトにおいて、Azure Pipelinesを無償で利用することができる。
- [公式ブログ](https://azure.microsoft.com/en-us/blog/announcing-azure-pipelines-with-unlimited-ci-cd-minutes-for-open-source/)
- [報道](https://www.infoq.com/jp/news/2018/11/microsoft-azure-pipelines/)。
- その後、悪用に対処するために[ルールの変更が行われた](https://docs.microsoft.com/ja-jp/azure/devops/release-notes/2021/sprint-184-update#changes-to-azure-pipelines-free-grants)

Azure DevOpsによるパブリックプロジェクトの運用については[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/organizations/public/about-public-projects?toc=%2Fazure%2Fdevops%2Fproject%2Ftoc.json&bc=%2Fazure%2Fdevops%2Fproject%2Fbreadcrumb%2Ftoc.json&view=azure-devops)の解説がある。[価格の説明ページ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted#how-much-do-parallel-jobs-cost)にも、パブリックプロジェクトの制限事項が記載されている。

## Azure Pipelines YAMLとVisual Designer

ドキュメント上「YAML」と「クラシック」と呼ばれる。

[2019年9月10日より、YAMLパイプラインが利用可能になり](https://docs.microsoft.com/ja-jp/azure/devops/release-notes/2018/sep-10-azure-devops-launch#configure-builds-using-yaml)、それまでのGUIで設定するパイプラインは「クラシック」と呼ばれるようになった。

- [クラシックインターフェース](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-the-classic-interface)
  - ビジュアルデザイナー（GUI）で編集できる
  - 「クラシック」と呼ばれる
  - ビルドパイプライン
  - リリースパイプライン
- [YAML構文](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax)(azure-pipelines.yml)
  - YAMLファイルを使用してパイプラインを定義
  - YAMLファイルは、コードと一緒に、リポジトリに格納できる


[YAMLとクラシックで利用できる機能](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#feature-availability)

たとえば「[コンテナージョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops)
」や「[テンプレート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/templates?view=azure-devops)」はYAMLでしか利用できない。

クラシックのパイプラインは[YAMLに移行](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/migrate/from-classic-pipelines?view=azure-devops)することができる。


## その他

- [配信機能](https://docs.microsoft.com/ja-jp/azure/devops/release-notes/2020/sprint-178-update#delivery-plans-preview)


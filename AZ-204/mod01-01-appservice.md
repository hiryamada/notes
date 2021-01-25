
# App Service 概要

Azure App Service を使用すると、インフラストラクチャを管理することなく、任意のプログラミング言語で Web アプリケーション、モバイル バックエンド、および RESTful API を構築し、ホストできます。 

Azure Web Apps では、自動スケールと高可用性が実現されるほか、Windows と Linux の両方がサポートされています。

GitHub、Azure DevOps、または任意の Git リポジトリからの自動デプロイが可能になります。 

# リンク

- [Web Apps](https://azure.microsoft.com/ja-jp/services/app-service/web/)
- [Web App for Containers](https://azure.microsoft.com/ja-jp/services/app-service/containers/)
- [API Apps](https://azure.microsoft.com/ja-jp/services/app-service/api/)
- [Mobile Apps](https://azure.microsoft.com/ja-jp/services/app-service/mobile/) - クロスプラットフォーム アプリや iOS、Android、Windows または Mac 用のネイティブ アプリを素早く簡単に構築。[ドキュメント](https://docs.microsoft.com/ja-jp/previous-versions/azure/app-service-mobile/app-service-mobile-value-prop)
- [Static Web Apps](https://azure.microsoft.com/ja-jp/services/app-service/static/)
- [Logic Apps](https://azure.microsoft.com/ja-jp/services/logic-apps/)


[Azure App Service Team Blog](https://azure.github.io/AppService/)

[Japan Azure PaaS Support Blog](https://docs.microsoft.com/ja-jp/archive/blogs/jpcie/?p=1165)

[Japan Azure PaaS Support Team (Forum)](https://social.msdn.microsoft.com/Forums/ja-JP/home?forum=Jpcie)

[Japan PaaS Support Team Blog](https://jpazpaas.github.io/blog/)


# App Serviceに含まれるもの

[2015年発表時](https://weblogs.asp.net/scottgu/announcing-the-new-azure-app-service)

以前に「Azure Websites」「Azure Mobile Services」と呼ばれていたものを統合。

- Web Apps
- Mobile Apps
- Logic Apps
- API Apps

[2017/9](https://satonaoki.wordpress.com/2017/09/09/webapp-for-containers-overview/)

- App Service on Linux - 組み込みのイメージによる ASP.NET Core, Node.js, PHP and Rubyのサポート
- Web App for Containers - カスタムのコンテナのサポート

[2018/8](https://www.atmarkit.co.jp/ait/articles/1904/15/news009.html)

- Web App for Containers が、Windowsコンテナをサポート

[2020/5](https://techcommunity.microsoft.com/t5/apps-on-azure/introducing-app-service-static-web-apps/ba-p/1394451)

- App Service Static Web Apps


# App Service プラン

App Service では、アプリは常に App Service プラン で実行されます。

[App Service プラン](https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/) - Free(F1), Shared(D1), Basic(B1,B2,B3), Standard(S1,S2,S3), Premium(P1v2,P2v2,P3v2,P1v3,P2v3,P3v3), Isolated(I1,I2,I3), Isolated v2(I1v2,I2v2,I3v2)

Azure Functions には、 App Service プラン で実行するオプションもあります。

[Azure Functions](https://azure.microsoft.com/ja-jp/services/functions/) - [3種類の価格プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview#how-much-does-functions-cost)。[従量課金プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#consumption-plan)、[Premium プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#premium-plan)、[App Serviceプラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#app-service-plan)


# 使用できる言語

.NET、.NET Core、Java、Ruby、Node.js、PHP、Pythonをサポート。

[Webジョブ](https://docs.microsoft.com/ja-jp/azure/app-service/webjobs-create#supported-file-types-for-scripts-or-programs)では、cmd, bat, exe, ps1, sh, php, py, js, jarをサポート。

※[Web App for Containersにより、Azureで定義されていないアプリケーションスタックも利用可能](https://news.mynavi.jp/article/azure-27/)

[ランタイムのバージョンの確認方法](https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime#how-can-i-query-os-and-runtime-update-status-on-my-instances)



`az webapp list-runtimes`を使用して確認できる。

```sh
# Windows
$ az webapp list-runtimes
[
  "aspnet|V4.8",
  "aspnet|V3.5",
  "DOTNETCORE|2.1",
  "DOTNETCORE|3.1",
  "DOTNET|5.0",
  "node|10.6",
  "node|10.10",
  "node|10.14",
  "node|12-lts",
  "php|7.2",
  "php|7.3",
  "php|7.4",
  "python|3.6",
  "java|1.8|Tomcat|7.0",
  "java|1.8|Tomcat|8.0",
  "java|1.8|Tomcat|8.5",
  "java|1.8|Tomcat|9.0",
  "java|1.8|Java SE|8",
  "java|11|Tomcat|7.0",
  "java|11|Tomcat|8.0",
  "java|11|Tomcat|8.5",
  "java|11|Tomcat|9.0",
  "java|11|Java SE|8"
]
# Linux
$ az webapp list-runtimes --linux
[
  "DOTNETCORE|2.1",
  "DOTNETCORE|3.1",
  "DOTNET|5.0",
  "NODE|14-lts",
  "NODE|12-lts",
  "NODE|10-lts",
  "NODE|10.1",
  "NODE|10.6",
  "NODE|10.14",
  "JAVA|8-jre8",
  "JAVA|11-java11",
  "TOMCAT|8.5-jre8",
  "TOMCAT|9.0-jre8",
  "TOMCAT|8.5-java11",
  "TOMCAT|9.0-java11",
  "JBOSSEAP|7.2-java8",
  "PHP|7.2",
  "PHP|7.3",
  "PHP|7.4",
  "PYTHON|3.8",
  "PYTHON|3.7",
  "PYTHON|3.6",
  "RUBY|2.5",
  "RUBY|2.6"
]

```

ランタイムごとに適当に集計した表が以下。


ASP.NET

| Runtime             | Linux | Windows | 
|---------------------|-------|---------| 
|   "aspnet, V3.5"    |       | o       | 
|   "aspnet, V4.8"    |       | o       | 

コメント：Windowsのみ。

.NET

| Runtime             | Linux | Windows | 
|---------------------|-------|---------| 
|   "DOTNETCORE, 2.1" | o     | o       | 
|   "DOTNETCORE, 3.1" | o     | o       | 
|   "DOTNET, 5.0"     | o     | o       | 

コメント：両OS対応。

PHP

| Runtime      | Linux | Windows | 
|--------------|-------|---------| 
|   "php, 7.2" | o     | o       | 
|   "php, 7.3" | o     | o       | 
|   "php, 7.4" | o     | o       | 

コメント：両OS対応。

Node.js

| Runtime          | Linux | Windows | 
|------------------|-------|---------| 
|   "NODE, 10.1"   | o     |         | 
|   "node, 10.6"   | o     | o       | 
|   "node, 10.10"  |       | o       | 
|   "node, 10.14"  | o     | o       | 
|   "NODE, 10-lts" | o     |         | 
|   "node, 12-lts" | o     | o       | 
|   "NODE, 14-lts" | o     |         | 

コメント：バージョンによってさまざま。

Python

| Runtime         | Linux | Windows | 
|-----------------|-------|---------| 
|   "python, 3.6" | o     | o       | 
|   "PYTHON, 3.7" | o     |         | 
|   "PYTHON, 3.8" | o     |         | 

コメント：新し目のPythonはLinuxでのみ対応。3.6ならWindowsも対応。

Ruby
| Runtime       | Linux | Windows | 
|---------------|-------|---------| 
|   "RUBY, 2.5" | o     |         | 
|   "RUBY, 2.6" | o     |         | 

Java 

※注意：コマンドが返す文字列がばらばらでうまく集計できないので、Azure portalのApp Service作成画面などを参考にして適当に表にしている。

| Runtime                    | Linux | Windows | 
|----------------------------|-------|---------| 
|   "java, 1.8, Java SE, 8"  | o     | o       | 
|   "java, 1.8, Tomcat, 7.0" |       | o       | 
|   "java, 1.8, Tomcat, 8.0" |       | o       | 
|   "java, 1.8, Tomcat, 8.5" | o     | o       | 
|   "java, 1.8, Tomcat, 9.0" | o     | o       | 
|   "Java 8, JBOSSEAP, 7.2"  | o     |         | 
|   "java, 11, Java SE, 8"   |       | o       | 
|   "java, 11, Tomcat, 7.0"  |       | o       | 
|   "java, 11, Tomcat, 8.0"  |       | o       | 
|   "java, 11, Tomcat, 8.5"  | o     | o       | 
|   "java, 11, Tomcat, 9.0"  | o     | o       | 
|   "JAVA, 11-java11"        | o     | o       | 

コメント：新し目のバージョンの組み合わせは両OS対応。JBOSSはLinuxのみ。



# 使用できるOS（「環境」）

- Windows ベース ([Windows Server 2016](https://github.com/Azure/app-service-announcements/issues/63))
- Linux ベース ([Debian](https://dev.to/tidjani/what-linux-distribution-is-powering-azure-app-service-iei))

[Free/Sharedは32ビット、Basic以上は32/64ビット](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#app-service-limits)。

# [デプロイ スロット(ステージング スロット)](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-best-practices#use-deployment-slots)

Standard以上で利用可能。

ステージング スロットと運用スロットをスワップできます。

スワップ操作によって、必要なワーカー インスタンスが運用規模に合わせてウォームアップされるため、ダウンタイムがなくなります。

ステージング スロットは（プランではなく）アプリ内に作成します。

[アプリごとのステージングスロット数](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#app-service-limits)

- Free / Shared / Basic: 使用できない
- Standard: 5
- Premium: 20
- Isolated: 20

# [アプリケーション設定](https://docs.microsoft.com/ja-jp/azure/static-web-apps/application-settings)

アプリケーションに対して名前と値からなる設定を追加することができる。

アプリケーション設定には、データベース接続文字列など、変更される可能性のある値の構成設定が保持されます。 アプリケーション設定を追加すると、アプリケーション コードを変更せずに、アプリへの構成入力を変更できます。アプリケーション設定は、環境変数と呼ばれることもあります。

- 名前
- 値
- 「デプロイスロットの設定」チェックボックス

「デプロイスロットの設定」にチェックを入れた場合、この設定は、スワップしてもスロットに残る。チェックを入れていない設定は、スワップによってアプリとともにスワップ先のスロットへ移動する。

# [CI/CDのサポート](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-best-practices)

Git, Docker, Azure DevOps（デプロイセンター）, GitHub Actions, Circle Ci, Travis CIなどに対応。

アプリの「デプロイセンター」から設定。

自動デプロイ（[継続的デプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-continuous-deployment)）
- GitHub - デプロイメントセンターでGitHubを選し、Authorizeをクリック。GitHubの画面で承認を行う。
- BitBucket - GitHubと同様
- Azure Repos - デプロイメントセンターでAzure Reposを選択。ビルドプロバイダーでAzure Pipelinesを選択。組織、リポジトリ、ブランチを選択。

※継続的なデプロイを無効化(Disconnect)できる

手動デプロイ 
- [ローカルGit](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-local-git) 
  - ローカルコンピュータのGitリポジトリからデプロイ。
    - デプロイユーザーを構成。
    - デプロイURL（https://～@～.scm.azurewebsites.net/～.git）を取得。
    - git remote add azure URL
    - git push azure master
- [ZIPパッケージ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-run-package) - デプロイしたZIPパッケージを直接実行。
- [ZIP/WAR](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip)
- [FTP(FTPS)](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-ftp)
- [Dropbox/Onedriveからの同期](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-content-sync)
- [Visual Studioの「発行」](https://docs.microsoft.com/ja-jp/visualstudio/deployment/quickstart-deploy-to-azure?view=vs-2019)
- [Azure CLI](https://docs.microsoft.com/ja-jp/azure/app-service/samples-cli)
- [Azure PowerShell](https://docs.microsoft.com/ja-jp/azure/app-service/samples-powershell)


# Bitbucket

[Bitbucket](https://www.atlassian.com/ja/software/bitbucket)は、アトラシアン社が提供する、Gitリポジトリのサービスです。

# Kuduについて

組み込みの Kudu App Service ビルド サーバーを使用して、Bitbucket（、GitHub、または Azure Repos）から[継続的にデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-continuous-deployment)できます。

[KuduのWiki](https://github.com/projectkudu/kudu)。[Kuduの解説（@IT）](https://www.atmarkit.co.jp/ait/articles/1707/27/news024_3.html)。[ZIPデプロイ](https://github.com/projectkudu/kudu/wiki/Deploying-from-a-zip-file-or-url)にも対応しています。

[ZIPデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip#create-a-project-zip-file)

# スケールアップ/ダウン

注意：アプリの中に「スケールアップ」「スケールアウト」メニューがあるが、実際にはアプリが稼働しているプランに対する操作となる。プランを変更すると、その上のアプリが全て影響を受ける。

[App Serviceプランの価格レベルを変更する](https://docs.microsoft.com/ja-jp/azure/app-service/manage-scale-up)事によって行う。手動。

- Free - F1
- Shared - D1
- Basic - B1/B2/B3
- Standard - S1/S2/S3
- Premium v2 - P1v2/P2v2/P3v2
- Premium v3 - P1v3/P2v3/P3v3
- Isolated - I1, I2, I3
- Isolated v2 - I1v2, I2v2, I3v3

B1, B2, B3はCPUコア数が1, 2, 4コア。Standard/Premium v2/Isolatedも同様。

Premium v3, Isolated v2は2, 4, 8コア。

ただしどの価格プランにでも自由に変更できるわけではなく、Isolatedから非Isolated,非IsolatedからIsolatedの変更はできない。

[P1v3/P2v3/P3v3への変更ができない場合](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-configure-premium-tier#scale-up-from-an-unsupported-resource-group-and-region-combination)、アプリを再デプロイする必要がある。

[Azure コンピューティング ユニット (ACU)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/acu): Azure SKU 間で計算 (CPU) パフォーマンスを比較する手段を提供します。これは、パフォーマンス ニーズを満たす可能性が最も高い SKU を簡単に見つけるのに役立ちます。 現在、ACU は小さい (Standard_A1) VM を 100 として標準化されており、他のすべての SKU についてはその SKU が標準ベンチマークをそれよりどれくらい速く実行できるかが表されます。

※Starndard_A1は「旧世代の仮想マシン」に分類される、コア1、メモリ1.75GiBのVMサイズ。現在はAv2シリーズが推奨されている。

ACUは性能の指標であり、「ACU 100 ≒ Standard_A1相当の性能」であり、ACU100の場合に内部でStandard_A1を使っているわけではない。

[ACUのスライド](https://www.slideshare.net/ryukiyoshimatsu/azure-windows-vm-azure-windows-vm-performance-monitoringtuning-deep-dive/24)


# スケールアウト/イン

注意：アプリの中に「スケールアップ」「スケールアウト」メニューがあるが、実際にはアプリが稼働しているプランに対する操作となる。プランを変更すると、その上のアプリが全て影響を受ける。

アプリを実行するVMインスタンス数を増やすことで行う。

自動または手動。Basicは「手動スケール」で、最大3インスタンスに対応。

自動の場合、メトリック（CPU使用率、メモリ使用率、ディスク使用率など）によるスケール、スケジュールに基づくスケールが可能。


- Basic - B1/B2/B3, 最大3インスタンス, 手動スケーリング
- Standard - S1/S2/S3, 最大10インスタンス, 自動スケーリング対応
- Premium v2 - P1v2/P2v2/P3v2, 最大20インスタンス, 自動スケーリング対応
- Premium v3 - P1v3/P2v3/P3v3, 最大30インスタンス, 自動スケーリング対応
- Isolated - I1/I2/I3, 最大100インスタンス, 自動スケーリング対応
- Isolated v2 - I1v2/I2v2/I3v3, 最大100インスタンス, 自動スケーリング対応

# [正常性チェック](https://docs.microsoft.com/ja-jp/azure/azure-monitor/platform/autoscale-get-started#route-traffic-to-healthy-instances-app-service)

複数のインスタンスにスケールアウトする場合、正常性チェックが実行される。

アプリケーションは、特定のパス (/health等)に対する正常性チェックに、1分以内に、200-299のステータスコードでレスポンスを返さなければならない。チェックに失敗したインスタンスは削除される。

パスの設定で空文字を設定するとこの機能を無効にできる。

# ロードバランサー/VMSSを内部で使っているか？

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/architecture/guide/technology-choices/compute-decision-tree#scalability)によると、App Serviceの自動スケールは「組み込みのサービス」、ロードバランサーは「統合」とされており、VMSSやAzure Load Balancerを使用しているとは書かれていない。

# プランやアプリはいくつまで作れるのか？

[制限](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#app-service-limits)

Free: リージョンあたり10プラン。プランあたり10アプリ。

Shared: リソースグループあたり10プラン、プランあたり100アプリ。

Basic以上: リソースグループあたり100プラン、プランあたりアプリ数は無制限。

# 複数のアプリのデプロイ

プランに負荷を処理するための十分なリソースがある限り、既存のプランにアプリを追加し続けることができます。

App Service でアプリを作成すると、App Service プランに入れられます。 

アプリを実行すると、App Service プランで構成されているすべての VM インスタンスで実行されます。 

複数のアプリが同じ App Service プランにある場合、これらはすべて同じ VM インスタンスを共有します。 

アプリのデプロイ スロットが複数ある場合は、すべてのデプロイ スロットも同じ VM インスタンスで実行されます。

このように、App Service プランは App Service アプリのスケール ユニットです。 

プランが 5 つの VM インスタンスを実行するように構成されている場合、プラン内のすべてのアプリが 5 つすべてのインスタンスで実行されます。

プランが自動スケール用に構成されている場合は、プラン内のすべてのアプリが自動スケール設定に基づいて一緒にスケールアウトされます。

# [コスト](https://docs.microsoft.com/ja-jp/azure/app-service/overview-hosting-plans#how-much-does-my-app-service-plan-cost)

Free: 無料

Shared: 使用したCPUクォータに対して課金。

Basic以上：プランの各VMインスタンスに対して課金。

※料金表の下部に書かれている価格は1インスタンスの場合。インスタンスを増やすと、インスタンス数に比例したコストがかかる。[料金計算ツール](https://azure.microsoft.com/ja-jp/pricing/calculator/)で、インスタンス数に対応するコストを計算できる。

# App ServiceはVNet内にデプロイされる？

ASEの場合、はい。それ以外の場合、いいえ。

App Serviceには[2種類のデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/networking-features)がある - マルチテナントとシングルテナント。シングルテナントであるASEは、VNetでホストされる。

- マルチテナント - Free/Shared/Basic/Standard/Premium/Premium V2/Premium V3
- シングルテナント - [App Service Environment (ASE)](https://docs.microsoft.com/ja-jp/azure/app-service/environment/intro), VNetでホストされる

サポートしたいネットワークのシナリオに応じて[機能を使い分ける](https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#use-cases-and-features)。

# [ASE](https://docs.microsoft.com/ja-jp/azure/app-service/environment/intro)

App Service Environment は、Azure App Service のプレミアム サービスであり、Azure App Service アプリを高スケールで安全に実行するための完全に分離された専用環境を提供します。

App Service Environment は、Azure Virtual Network に Azure App Service をデプロイしたものです。これにより、アプリはサイト対サイト接続または ExpressRoute 接続を介して会社のリソースに直接アクセスできます。

ASE でアプリを作成する方法は通常のアプリの作成方法とほとんど同じですが、アプリのデプロイ先の場所として地理的な場所ではなく ASE を選択します。



外部ASEと内部ASE - パブリックIPアドレスでアクセスすることも、ILB（内部ロードバランサー）で内部接続することもできる。ASEリソース作成時に指定。

Windows/Linuxアプリをサポート。

v1, v2, v3のASEがある。

NSGで保護できる。

VNet内のリソースにアクセスできる。

VPNやExpressRouteを経由してオンプレミスのリソースにアクセスできる。

# ASEの料金

**ASE で作成する App Service プランはすべて、Isolated の価格レベルでのみ使用できます。**

Isolated レベルでは、App Service Environment によって、アプリを実行する分離された worker の数が定義されるので、各 worker に対して課金されます。 さらに、App Service Environment 自体の実行に対して、定額のスタンプ料金があります。

# VNet統合

2017/10に発表された機能。（「新しいバージョンの 」とあるので、以前からも類似機能があったらしい）

※ASEを使用する場合は、VNet統合を使用する必要がない。

https://docs.microsoft.com/ja-jp/azure/app-service/web-sites-integrate-with-vnet

VNet 統合機能を使用すると、アプリは **VNet 内のリソースにアクセス**するか、**VNet を通じてリソースにアクセス**できます。

- 例1: App ServiceアプリからVNet内のVMにアクセスする
- 例2: App ServiceアプリからVNetを経由してオンプレのサーバーにアクセスする

https://azure.microsoft.com/ja-jp/updates/new-app-service-vnet-integration-feature/

https://tech-lab.sios.jp/archives/22563

# [ハイブリッド接続（Azure Relay）](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections)

ハイブリッド接続を利用して、オンプレミスのデータにアクセスできます。

ハイブリッド接続は、Azure のサービスであり、Azure App Service の機能でもあります。 サービスとして使用した場合、その用途と機能は、Azure App Service の用途と機能を上回ります。

App Service ハイブリッド接続は、Basic、Standard、Premium、および Isolated の価格 SKU でのみ利用できます。 料金プランに関連付けられている制限があります。

[リレーのドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-relay/relay-what-is-it)

# [Key Vaultのシークレットを参照する](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-key-vault-references)

- Key Vaultを作成する
- システム割り当てマネージドIDをアプリに割り当てる。※ユーザー割り当てマネージドIDは今の所使用できない
- IDに対して、Key Vaultでアクセスポリシーを作成し、「Getシークレットアクセス」を許可する。

# [アプリの移動](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-plan-manage)

- 別のApp Serviceプランに移動
- 別のリージョンに移動（複製）


アプリは別リージョンのプランに移動（複製）できる。プランは別リージョンに移動できない。

リソースグループ間での移動も可能だが[いろいろ大変](https://www.misuzilla.org/Blog/2017/08/06/MovingAppServicePlanAndAppService)。

# 認証と承認

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/app-service/overview-authentication-authorization)

[対応している認証プロバイダ](https://docs.microsoft.com/ja-jp/azure/app-service/configure-authentication-provider-aad)

- Azure AD
- Facebook
- Google
- Microsoftアカウント
- Twitter
- OpenID Connect
- Apple

[複数のサインイン プロバイダーを使用することが可能](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-authentication-how-to#use-multiple-sign-in-providers)。


**サインインエンドポイント** (Twitter認証での例) 

アプリは、`<a href="/.auth/login/twitter">Log in with Twitter</a>` のようなコードを使用して、ユーザーをサインイン画面へと誘導することができる。

また `<a href="/.auth/login/twitter?post_login_redirect_url=/Home/Index">Log in</a>`
 のようなコードを使用して、サインイン後のリダイレクトURLを指定することもできる。

「アプリのURL」 `https://contoso.azurewebsites.net/`

「サインインエンドポイントのURL（Twitter認証の場合） `https://contoso.azurewebsites.net/.auth/login/twitter/callback`

Twitterで「アプリ」を作成し、「Website URL」に「アプリのURL」、「Callback URLs」に「サインインエンドポイントのURL」を指定する。

Twitterのアプリの「APIキー」と「APIシークレットキー」を取得し、Twitter認証のオプション画面で、「APIキー」と「APIシークレット」にそれらを設定する。

**トークンストア**: いずれかのプロバイダーで認証を有効にすると、アプリでトークンストアを利用できるようになる。

アプリは、トークンストアに格納されたトークンを取得して、認証プロバイダーのデータにアクセスすることができる。（Twitter認証のトークンを使用して、Twitterに投稿する、など）

[認証フロー](https://docs.microsoft.com/ja-jp/azure/app-service/overview-authentication-authorization#authentication-flow)(Authentication flow):

プロバイダーのSDKを使う場合と使わない場合がある。

# IPアドレス

マルチテナントとシングルテナント(ASE)でIPアドレスの扱い方が異なる。

マルチテナント: 送信、受信IPアドレスが変化することがある（[送信の変更](https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#when-outbound-ips-change)、[受信の変更](https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#when-inbound-ip-changes)）。カスタムドメインをセキュリティで保護（SSLを追加）すると、静的な受信IPをもたせる事ができる。送信IPは固定できないが、使用する可能性のあるIPアドレスをコマンドなどで取得することができる。

シングルテナント: 送信・受信とも専用の静的なIPアドレスを使用する。

現在使用している[受信IPを調べる](https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#find-the-inbound-ip)には、DNSを使用する。`nslookup contoso.azurewebsites.net` 

現在使用している[送信IPを調べる](https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#find-outbound-ips)には、Azure CLI / Azure PowerShellを使うか、ポータルを使用する。


# [Azure Application Gateway](https://docs.microsoft.com/ja-jp/azure/application-gateway/overview)と組み合わせできるか？

[Yes](https://docs.microsoft.com/ja-jp/azure/application-gateway/configure-web-app-portal)

バックエンドプールのターゲットの種類でApp Serviceを選択できる。

※ Azure Application Gatewayは、Web アプリケーションに対するトラフィックを管理できる Web トラフィック ロード バランサー。L7の負荷分散に対応。

# [Azure Traffic Manager](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview)と組み合わせできるか？

[Yes](https://docs.microsoft.com/ja-jp/azure/app-service/web-sites-traffic-manager)

※Azure Traffic Managerは、DNS ベースのトラフィック ロード バランサー。優先順位/重み付け/パフォーマンス/地理的/複数値/サブネットのルーティング方法を使用できる。

Azure Traffic Manager は App Service アプリの状態 (実行中、停止、または削除済み) を追跡して、エンドポイントを決定します。


# [Azure Front Door](https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-overview)と組み合わせできる？

[Yes](https://docs.microsoft.com/ja-jp/azure/architecture/reference-architectures/app-service-web-app/multi-region)

※Azure Front Doorは、[グローバルなウェブアプリケーションを高速に配信するためのセキュアでスケーラブルなエントリポイントを提供するサービス](https://ascii.jp/elem/000/004/017/4017782/)。待機時間/優先順位/重み付け/セッションアフィニティのルーティング方法を使用できる。L7で動作。

# App Service on Linux


[2017/9/6 正式リリース](https://www.atmarkit.co.jp/ait/articles/1709/08/news065.html)


[ドキュメント](https://docs.microsoft.com/ja-jp/azure/app-service/overview#app-service-on-linux)

[FAQ](https://docs.microsoft.com/ja-jp/azure/app-service/faq-app-service-linux)

- サポートされているアプリケーション スタック向けに Web アプリを Linux 上でネイティブにホスト
- カスタム Linux コンテナー (Web App for Containers とも呼ばれます) を実行することもできます
- 共有(Shared)価格レベルではサポートされていません。
- Windows と Linux のアプリを同じ App Service プランに混在させることはできません。


[独自のランタイムスタックを作成して使用することができる](https://blog.shibayan.jp/entry/20170116/1484498895)。

# [バックアップ](https://docs.microsoft.com/ja-jp/azure/app-service/manage-backup)

バックアップと復元の機能には、Standard レベル、Premium レベル、または Isolated レベルの App Service プランが必要です。Standardでは毎日10回、Premium/Isolatedでは毎日50回のバックアップが可能です。（回数は、マニュアルバックアップとスケジュールバックアップの1日の合計回数）

手動と自動のバックアップが利用できます。手動バックアップは無期限に保存されます。自動バックアップでは、バックアップの取得間隔（～日、～時間）や、バックアップのretension日数を指定できます。

バックアップするアプリと同じサブスクリプション内に Azure ストレージ アカウントとコンテナーが必要です。ストレージ アカウント と コンテナー を選択して、バックアップ先を選択します。

最大 10 GB のアプリとデータベースのコンテンツをバックアップできます。 バックアップのサイズがこの制限を超えた場合、エラーが発生します。

次の情報をバックアップできます。
- アプリの構成
- ファイルのコンテンツ
- アプリに接続されているデータベース

各バックアップは、バックアップ データを含む .zip ファイルと、.zip ファイルの内容のマニフェストを含む .xml ファイルで構成されます。アプリのデータベースのバックアップは、.zip ファイルのルートに保存されます。

[バックアップからファイルやフォルダーを除外する](https://docs.microsoft.com/ja-jp/azure/app-service/manage-backup#exclude-files-from-your-backup)には、アプリの `D:\\home\\site\\wwwroot`フォルダー内に `_backup.filter` ファイルを作成します。

バックアップからの復元では、既存のアプリへの上書き、または新しいアプリへの復元が可能です。


# Azure Marketplaceからのデプロイ


アプリケーション テンプレート - WordPress、Joomla、Drupal など、Azure Marketplace にある詳細な一覧からアプリケーション テンプレートを選択します。

例：Marketplaceで「WordPress on Linux」を選択する。

[Azure Web App で WordPress を手っ取り早く用意する](https://tech-lab.sios.jp/archives/11190)

[Azure Web App で WordPress 環境構築 (できる限りリーズナブルな方法で) ～ 2019年7月版](http://ayomori.com/2019/07/31/budget-wordpress-site-using-azure-web-app/)


# [CORSサポート](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-web-tutorial-rest-api)

App Service には、RESTful API 用のクロスオリジン リソース共有 (CORS) の組み込みサポートがあります。

Cloud Shell で az webapp cors add コマンドを使用して、クライアントの URL に対して CORS を有効にします。

# ARRアフィニティ

[ARRアフィニティの解説](https://techinfoofmicrosofttech.osscons.jp/index.php?Application%20Request%20Routing%20%28ARR%29)


有効にすると、HTTPクッキーを使用して、ユーザーを同じインスタンスに誘導します。複数のインスタンスがあり、ステートフルアプリケーションを利用している場合に利用するオプションです。

ステートレスアプリケーションの場合はこのオプションをOFFにします。


# Application Insights

[Mod12を参照](mod12-02-appinsights.md)

# Azure App Service での OS とランタイムのパッチ適用

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime)

> App Service はサービスとしてのプラットフォームです。これは、OS およびアプリケーション スタックが Azure によって自動的に管理されることを意味します。
> 
> Azure では、2 つのレベルで OS のパッチ適用が管理されます。1 つが物理サーバーで、もう 1 つが App Service リソースを実行するゲスト仮想マシン (VM) です。 
> 
> どちらも、月例パッチ火曜日スケジュールに従って毎月更新されます。 これらの更新プログラムは、Azure サービスの高可用性 SLA を保証する方法で、自動的に適用されます。


[Azure App ServiceのOSアップデートの背後にある魔法の神秘性を取り除く (Demystifying the magic behind App Service OS updates) – S/N Ratio (wordpress.com)](https://satonaoki.wordpress.com/2018/01/25/demystifying-the-magic-behind-app-service-os-updates/)

> 特定のリージョンでアップデートを行う際、我々は、アプリが動作していない利用可能なインスタンスをアップデートし、それから、アップデート済みのインスタンスにアプリを移動し、それから、アプリがなくなったインスタンスをアップデートします。
> 
> この移動はコールド スタートを引き起こし、これに関連してパフォーマンスが低下がする場合があります。
> 
> アプリケーションのバイナリが新しい仮想マシンにロードされ、ライブラリがディスクからロードされます。
> 
> 外部ユーザーに対して、アプリへのリクエストに対するレスポンスで1度限りの遅延が発生し、その後、サイトは正常に動作します。


[Webアプリが動いているマシンが再起動したらどうなるの？](https://qiita.com/superriver/items/df5790f9a25292cbcc03#web%E3%82%A2%E3%83%97%E3%83%AA%E3%81%8C%E5%8B%95%E3%81%84%E3%81%A6%E3%81%84%E3%82%8B%E3%83%9E%E3%82%B7%E3%83%B3%E3%81%8C%E5%86%8D%E8%B5%B7%E5%8B%95%E3%81%97%E3%81%9F%E3%82%89%E3%81%A9%E3%81%86%E3%81%AA%E3%82%8B%E3%81%AE)

> さて、ワーカー自身は様々な理由から再起動されます。OSの更新とプラットフォームコードの更新が理由であることが多いです。
> 
> あるワーカー上でWebアプリが実行中に再起動が要求されると、それ以降フロントエンドはHTTPリクエストをそのワーカーには送らなくなります。
> 
> ただしすでに処理中のリクエストの処理は続行します(いわゆるGraceful shutdownです)。

 （中略）

> というわけなので、マシンがいつ再起動しようと、理想的にはダウンタイムは発生しません。
> 
> 特にアプリが十分速く起動するように書かれている場合はコールドスタートの時間も短くなります。

# コールドスタートを回避するには常時接続を有効化

[クラウドで正常なアプリを実行するための究極のガイド](https://satonaoki.wordpress.com/2020/06/07/robust-apps-for-the-cloud/)

> 常時接続 (Always On) は、過去20分間にリクエストを受信していない時でも、VMインスタンスを起動させたままにします。
> 
> 既定では、常時接続は無効化されています。常時接続を有効化すると、アプリケーションのコールド スタートが起こらなくなります。


# [常時接続](https://docs.microsoft.com/ja-jp/azure/app-service/faq-availability-performance-application-issues#how-do-i-decrease-the-response-time-for-the-first-request-after-idle-time)

既定では、設定された期間だけアイドル状態が続くと Web アプリはアンロードされます。 このようにして、システムはリソースを節約できます。 欠点は、Web アプリが読み込まれて応答の処理を開始できるようにするために、Web アプリがアンロードされた後の最初の要求への応答が長くなることです。 

BasicおよびStandardサービス プランでは、アプリを常に読み込まれた状態にするために、 [常時接続] 設定をオンにすることができます。 これにより、アプリがアイドル状態になった後の読み込み時間が長くなることはなくなります。 [常時接続] 設定を変更するには:
Azure Portal で、Web アプリに移動します。
[構成] を選択します。
[全般設定] を選択します。
[常時接続] の [On] (オン) を選択します。

[この機能自体にはコストはかかりません](https://stackoverflow.com/questions/28619006/does-the-azure-websites-always-on-option-have-any-implication-on-price)が、メモリを基準としたオートスケールを設定した場合などに、オートスケールに影響がでる場合があります。（＝コストに影響する可能性があります）

# サポートされる言語ランタイムの更新、追加、非推奨の時期

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime#when-are-supported-language-runtimes-updated-added-or-deprecated)

ランタイムの更新と廃止は以下で発表されます。

- https://azure.microsoft.com/updates/?product=app-service
- https://github.com/Azure/app-service-announcements/issues

GitHubの通知（Watch）を有効にすることで、通知を受信することができます。

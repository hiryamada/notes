# Application Insights

Application Insights は Azure Monitor の機能であり、開発者や DevOps プロフェッショナル向けの拡張可能なアプリケーション パフォーマンス管理 (APM) サービスです。 このサービスを使用して、実行中のアプリケーションを監視することができます。

[概要](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview)

[価格（Azure Monitor内）](https://azure.microsoft.com/ja-jp/pricing/details/monitor/)



Microsoft Learn:
- [Application Insights により Azure Web アプリでのページの読み込み時間をキャプチャして表示する](https://docs.microsoft.com/ja-jp/learn/modules/capture-page-load-times-application-insights/)
- [サーバー側の Web アプリケーション コードに Application Insights を追加する](https://docs.microsoft.com/ja-jp/learn/modules/instrument-web-app-code-with-application-insights/)


[Azure Application Insights 基礎と実践](https://eventmarketing.blob.core.windows.net/decode2019-after/decode19_PDF_DT05.pdf)


# 歴史

2015/4/29 Application Insights Public Preview

https://azure.microsoft.com/ja-jp/blog/announcing-application-insights-public-preview-2/

2016/11/16 Application Insights GA

https://azure.microsoft.com/ja-jp/blog/general-availability-of-azure-application-insights/

2019/2/21 Application Insightsが東日本リージョンで利用できるようになりました。

https://azure.microsoft.com/ja-jp/updates/application-insights-available-in-australia-east-and-japan-east/

(2021/1/29現在、[西日本はプレビュー](https://azure.microsoft.com/ja-jp/global-infrastructure/services/?products=monitor&regions=japan-west,japan-east))

# Application Insightsとは

Application Insights は アプリケーション パフォーマンス管理 (APM) サービスです。

実行中のアプリケーションを監視することができます。

# 「インサイト」とは

https://www.itmedia.co.jp/news/articles/2002/26/news061.html

insightの日本語訳を英和辞典で調べると、ほとんどが「洞察」「洞察力」などの単語しか出てこない。

・・・

Insightとは、データと情報を分析して、特定の状況または現象について何が起きているかを理解することによって得られるもの。

・・・

要するにinsightは、**データを分析したり詳しく調べたりした結果、その分析で引き出された情報や、明らかになった事象**を指す時に使われる。一言では言い表しにくいけれど、日本語では「知見」という言葉を当てはめることが多いようだ。

# 「テレメトリ」とは

https://ja.wikipedia.org/wiki/%E9%81%A0%E9%9A%94%E6%B8%AC%E5%AE%9A%E6%B3%95

遠隔測定法（えんかくそくていほう）は、観測対象から離れた地点から様々な観測を行い、そのデータを取得する技術である。観測地点に常駐することが物理的・経済的あるいは安全上困難な場合や、観測対象が移動する場合に使用される。**テレメトリー (telemetry)** あるいはテレメタリング (telemetering) ということもある。 装置そのものは、テレメータ (telemeter) と呼ばれる。


https://blog.newrelic.co.jp/new-relic-one/introducing-telemetry-data-platform/

**テレメトリ**データプラットフォームは一か所で提供します。あらゆる**テレメトリ**ソースからのメトリクス、イベント、ログ、トレースを収集し、分析し、可視化し、アラートを発報します。

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/asp-net-core

- テレメトリを有効にする
- テレメトリを送る
- テレメトリを収集する

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/java-get-started?tabs=maven#send-your-own-telemetry

SDK をインストールすると、API を使用して**独自のテレメトリを送信**できるようになります。

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/codeless-overview

Application Insights は、さまざまなリソース プロバイダーと統合されており、さまざまな環境で動作します。 基本的には、**エージェント**を有効にし、場合によっては構成するだけで済みます、これにより、すぐに使用できる**テレメトリ**が収集されます。 すぐに、Application Insights リソースにメトリック、データ、依存関係が表示されます。


https://github.com/Microsoft/ApplicationInsights-Ruby

```Ruby
tc = ApplicationInsights::TelemetryClient.new '<YOUR INSTRUMENTATION KEY GOES HERE>'

# 「イベントテレメトリアイテムの送信
tc.track_event 'My event'

# 「メトリック」テレメトリアイテムの送信
tc.track_metric 'My metric', 42

# 「例外」テレメトリの送信
tc.track_exception e

```

# 「インストゥルメンテーション」とは

※プログラム本来の動作に影響を与えることなく、モニタリングを可能にする技術/作業。万歩計を装備して、運動量を把握できるようにするようなこと。Application Insightsにおいては、SDKと「インストゥルメンテーションキー」を使用して、Application Insightsにデータを送信する。

https://docs.microsoft.com/ja-jp/archive/msdn-magazine/2014/november/application-instrumentation-application-analysis-with-pin

インストルメンテーションとは、コードを追加または変更 (あるいはその両方) することによってプログラムを分析するプロセスです。

https://www.weblio.jp/content/%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%AB%E3%83%A1%E3%83%B3%E3%83%86%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3

システム ハードウェアおよびシステム ソフトウェアの状態に関するデータを報告するために使用される機構。


https://docs.microsoft.com/ja-jp/dotnet/framework/debug-trace-profile/tracing-and-instrumenting-applications

インストルメンテーション という用語は、製品のパフォーマンスのレベルを監視または測定し、エラーを診断する具体的な機能を意味しています。

https://docs.microsoft.com/ja-jp/dotnet/framework/debug-trace-profile/tracing-and-instrumenting-applications#phases-of-code-tracing

インストルメンテーション - トレース コードをアプリケーションに追加します。

https://docs.oracle.com/javase/jp/6/api/java/lang/instrument/Instrumentation.html

インストゥルメンテーションとは、ツールで使用するデータを収集することを目的としてメソッドにバイトコードを追加することです。変更は単に追加されるため、これらのツールはアプリケーションの状態や動作を変更しません。状態や動作に影響を及ぼさないこの種のツールには、監視エージェント、プロファイラ、カバレージアナライザ、およびイベントロガーなどがあります。


https://docs.microsoft.com/ja-jp/azure/azure-monitor/faq#whats-the-difference-between-opentelemetry-sdk-and-auto-instrumentation

自動インストルメンテーション (バイトコード インジェクション、コード不要、またはエージェントベースと呼ばれることもあります) の概念は、コードを変更せずにアプリケーションをインストルメント化する機能を指します。

# App Service における「エージェント」

エージェントベースのインストルメンテーション
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/platforms

App Servicesの「エージェント」ベースのアプリケーション監視（ApplicationInsightsAgent）
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/azure-web-apps?tabs=net#enable-application-insights

Azure Monitor for VMsにおける2つのエージェント「Log Analytics エージェント」「Dependency Agent」。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/insights/vminsights-enable-overview#agents

コンテナーに対する Azure Monitor では、コンテナー化されたバージョンの 「Linux 用 Log Analytics エージェント」 が使用されます。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/insights/container-insights-manage-agent


# App Service Web - アプリでの利用

お客様はアプリのコードを変更することなく、多数の Azure App Service Web アプリに対してこれを有効にすることができます。

# App Service Web - アプリ以外での利用

オンプレミス、ハイブリッド、またはパブリック クラウドでホストされているアプリに対しても機能します。

# 対応言語

サポートされている言語
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/platforms

- [C#, VB (.NET)](https://github.com/microsoft/ApplicationInsights-dotnet)
- [Java](https://github.com/microsoft/ApplicationInsights-Java)
- [JavaScript](https://github.com/microsoft/ApplicationInsights-JS)
- [Node.js](https://github.com/microsoft/ApplicationInsights-node.js)
- [Python](https://github.com/microsoft/ApplicationInsights-Python)

※Pythonのリポジトリには、[Python Open Census SDK](https://github.com/census-instrumentation/opencensus-python)をチェックするようにという記載がある。

上記リストにないがMicrosoftで開発されているものもある。

Kubernetes
https://github.com/microsoft/ApplicationInsights-Kubernetes

Service Fabric
https://github.com/microsoft/ApplicationInsights-ServiceFabric

コミュニティで開発されているSDKもある。

Rust
https://github.com/dmolokanov/appinsights-rs

Elixir
https://hexdocs.pm/ex_insights/readme.html


かつてMicrosoftで開発されていたが、現在はメンテナンス・サポートされていないSDKもある。

Ruby
https://github.com/Microsoft/ApplicationInsights-Ruby

Go
https://github.com/microsoft/ApplicationInsights-Go

PHP
https://github.com/microsoft/ApplicationInsights-PHP

iOS
https://github.com/microsoft/ApplicationInsights-iOS

Android
https://github.com/microsoft/ApplicationInsights-Android

WordPress Plugin
https://github.com/microsoft/ApplicationInsights-WordPress

# OpenCensus

https://opencensus.io/

OpenCensus is a set of libraries for various languages that allow you to collect application metrics and distributed traces, then transfer the data to a backend of your choice in real time. This data can be analyzed by developers and admins to understand the health of the application and debug problems.

MicrosoftはOpenCensusのPartners & Contributorsに含まれている。

https://opencensus.io/exporters/supported-exporters/go/applicationinsights/

Azure Monitor は、OpenCensus との統合により、Python アプリケーションの分散トレース、メトリック収集、およびログ記録をサポートします。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/opencensus-python


# OpenTelemetry

https://docs.microsoft.com/ja-jp/azure/azure-monitor/faq#opentelemetry

OpenTelemetry とは
監視のための新しいオープンソース標準です。 詳細については、https://opentelemetry.io/ をご覧ください。


[OpenCensus と OpenTelemetry の違いは何ですか?](https://docs.microsoft.com/ja-jp/azure/azure-monitor/faq#whats-the-difference-between-opencensus-and-opentelemetry)

OpenCensus は OpenTelemetry の前段階です。 Microsoft は、OpenTracing と OpenCensus を統合して、世界の単一の監視標準である OpenTelemetry の作成を支援しました。 Azure Monitor の現在の運用環境で推奨されている Python SDK は OpenCensus に基づいていますが、最終的には、すべての Azure Monitor の SDK が OpenTelemetry に基づくようになります。

# 分散トレース

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/distributed-tracing

Azure Monitor では、**分散トレース** データを使用するために 2 つのエクスペリエンスを提供します。 1 つ目は**トランザクション診断ビュー**で、時間ディメンションが追加された呼び出し履歴に似ています。 **トランザクション診断ビュー**では、1 つのトランザクション/要求に表示が提供され、要求ごとに基づいて信頼性の問題とパフォーマンスのボトルネックの根本原因を見つけるのに役立ちます。Azure Monitor では、**アプリケーション マップ ビュー**も提供されており、システムでどのようにやりとりするかのトポロジ ビュー、および平均パフォーマンスとエラー率の内容を示すために、多くのトランザクションを集計します。

.NET、.NET Core、Java、Node.js、JavaScript 用の Application Insights エージェントや SDK はすべて、分散トレースをネイティブにサポートしています。

適切な Application Insights SDK がインストールおよび構成されると、トレース情報は、SDK 依存関係の自動コレクターによって一般的なフレームワーク、ライブラリ、テクノロジが自動収集されます。 

Application Insights SDK に加えて、Application Insights では OpenCensus からの分散トレースもサポートされます。 OpenCensus はオープン ソースで、ベンダーに捕らわれない単一の配布のライブラリであり、サービスにメトリック コレクションと分散トレースを提供します。 また、オープン ソース コミュニティを有効にして、Redis、Memcached、または MongoDB などの一般的なテクノロジで分散トレースを有効にすることもできます。

# 分散トレーシング技術について

https://www.slideshare.net/td-nttcom/open-tracingjaeger

現代のサービスは複雑化され、そのシステムは大規模に分散することが多い。 特にサービスの機能ごとに分けて作り、それらを疎結合させるMicroservicesアーキテク チャの流行もあり、機能ごとに開発チームが異なることや、開発言語が違うことが増え、 サービス内部はより分散し複雑化している。 

分散し複雑化したサービスにおいて機能ごとの関係性を把握することは難しく、エラーや 性能問題などが起きた際にその原因特定が非常に難しくなる。 

こうした問題に取り組むべく、分散されたサービス内のリクエストをトレース可能な、**分散トレーシング技術**が現在注目を浴びている。

# Visual Studio App Center との統合


Visual Studio App Center と統合することで、モバイル アプリからテレメトリを監視および分析できます。

Visual Studio App Center
https://visualstudio.microsoft.com/ja/app-center/

# Application Insights SDK

Application Insights SDK を使用すれば、カスタム イベント コレクションが必要な場合、またはコードなしアタッチがまだサポートされていない場合に、アプリをインストルメント化することができます。

# カスタムのイベントとメトリック

アプリケーションに数行のコードを挿入して、ユーザーの行動を調べたり、問題の診断に役立つ情報を取得したりすることができます。 デバイスとデスクトップ アプリケーション、Web クライアント、Web サーバーからテレメトリを送信できます。 Azure Application Insights コア テレメトリ API を使用すると、カスタムのイベントやメトリック、独自バージョンの標準テレメトリを送信できます。 
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/api-custom-events-metrics#api-summary

# 有効化

アプリケーションに小規模なインストルメンテーション パッケージ (SDK) をインストールするか、サポートされている場合は Application Insights エージェントを使用して Application Insights を有効にします。 

# インストルメンテーション

インストルメンテーションによってアプリが監視され、インストルメンテーション キーと呼ばれる一意の GUID を使用して、テレメトリ データが Azure Application Insights リソースに転送されます。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview#how-does-application-insights-work


# サポートされているプラットフォームとフレームワーク

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/platforms#supported-platforms-and-frameworks

# VM/VMSSのサポート

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/azure-vm-vmss-apps

Azure 仮想マシンと Azure 仮想マシン スケール セット上で実行されている .NET ベースの Web アプリケーションに対する監視を有効にすることが、従来より簡単になりました。 

コードを変更することなく、Application Insights を使用する利点のすべてが得られます。

- コード不要（Codeless） - Application Insights エージェントを使用
- コードベース（Code-based） - SDK を使用

# App Serviceのサポート

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/azure-web-apps?tabs=net

Azure App Services 上で実行されているご利用の ASP.NET および ASP.NET Core ベースの Web アプリケーションで、これまでよりも簡単に監視を有効にすることができるようになりました。 以前は手動でサイト拡張機能をインストールする必要がありましたが、最新の拡張機能/エージェントが既定でアプリ サービス イメージに組み込まれました。 

- エージェントベースのアプリケーション監視 (ApplicationInsightsAgent)。
- Application Insights SDK をインストールし、コードを介して 手動でアプリケーションをインストルメント化する


# Azure Functionsのサポート

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-monitoring

Application Insights インストルメンテーションは Azure Functions に組み込まれているため、関数アプリを Application Insights リソースに接続するためには、有効なインストルメンテーション キーが必要です。 インストルメンテーション キーは、Azure 内に関数アプリのリソースを作成するときに、アプリケーション設定に追加されます。

Azure Functions との Application Insights の統合は、無料で試すことができます。これは、1 日に無料で処理されるデータ量に制限があることが特徴となっています。

一般に、関数アプリを作成するときに Application Insights インスタンスを作成します。 この場合、統合に必要なインストルメンテーション キーは、 APPINSIGHTS_INSTRUMENTATIONKEY という名前のアプリケーション設定として既に設定されています。


# Application Insights エージェント - ASP.NET

 (旧称 Status Monitor V2) 

オンプレミス サーバー用に Azure Monitor Application Insights エージェントをデプロイする
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/status-monitor-v2-overview

Application Insights エージェント (旧称 Status Monitor V2) は、PowerShell ギャラリーに公開されている PowerShell モジュールです。 これは Status Monitor を置き換えるものです。 テレメトリが Azure portal に送信され、そこでアプリを監視できます。



オンプレミス サーバー向け Azure Monitor Application Insights Agent の概要
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/status-monitor-v2-get-started

# Application Insights エージェント - Java

オンレミスでの Java コード不要のアプリケーション監視 - Azure Monitor Application Insights
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/java-on-premises


# トレースログの探索

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/java-trace-logs

トレース用に Logback または Log4J (v1.2 または v2.0) を使用している場合は、トレース ログを自動的に Application Insights に送信して、Application Insights でトレース ログを探索および検索できます。

既定では、Application Insights Java エージェントは、WARN レベル以上で実行されたログを自動的にキャプチャします。

ロガー経由で送信された例外は、例外のテレメトリとしてポータルに表示されます。

# スマート検出

https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/proactive-diagnostics

スマート検出により、Web アプリケーションの潜在的なパフォーマンスの問題と失敗の異常について警告を自動的に受け取ることができます。 

スマート検出では、アプリから Application Insights に送信されるテレメトリがプロアクティブに分析されます。 

障害発生率が急激に上昇したり、クライアントまたはサーバーのパフォーマンスに異常なパターンが発生したりした場合に、アラートが表示されます。 

**この機能には構成は不要です。** アプリケーションから適切なテレメトリが送信されていれば動作します。

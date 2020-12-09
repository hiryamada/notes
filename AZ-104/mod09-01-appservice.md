[AZ-204のノート](../AZ-204/mod01-01-appservice.md)

# App Service 概要

Azure App Service を使用すると、インフラストラクチャを管理することなく、任意のプログラミング言語で Web アプリケーション、モバイル バックエンド、および RESTful API を構築し、ホストできます。 

Azure Web Apps では、自動スケールと高可用性が実現されるほか、Windows と Linux の両方がサポートされています。

GitHub、Azure DevOps、または任意の Git リポジトリからの自動デプロイが可能になります。 


# App Serviceに含まれるもの

[2015年発表時](https://blog.azure.moe/2015/03/25/build-web-and-mobile-apps-faster/)

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


# リンク

- [Web Apps](https://azure.microsoft.com/ja-jp/services/app-service/web/)
- [Web App for Containers](https://azure.microsoft.com/ja-jp/services/app-service/containers/)
- [API Apps](https://azure.microsoft.com/ja-jp/services/app-service/api/)
- [Mobile Apps](https://azure.microsoft.com/ja-jp/services/app-service/mobile/) - クロスプラットフォーム アプリや iOS、Android、Windows または Mac 用のネイティブ アプリを素早く簡単に構築。[ドキュメント](https://docs.microsoft.com/ja-jp/previous-versions/azure/app-service-mobile/app-service-mobile-value-prop)
- [Static Web Apps](https://azure.microsoft.com/ja-jp/services/app-service/static/)

# App Service プラン

App Service では、アプリは常に App Service プラン で実行されます。

[App Service プラン](https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/) - Free, Shared, Basic, Standard, Premium, Isolated

Azure Functions には、 App Service プラン で実行するオプションもあります。

[Azure Functions](https://azure.microsoft.com/ja-jp/services/functions/) - [3種類の価格プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview#how-much-does-functions-cost)。[従量課金プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#consumption-plan)、[Premium プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#premium-plan)、[App Serviceプラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#app-service-plan)

# App Serviceで、Azure Traffic Managerを使用する

[Azure Traffic Manager](https://azure.microsoft.com/ja-jp/services/traffic-manager/)は、DNSベースの負荷分散サービスです。

クライアントからの要求を Azure App Service のアプリに振り分ける方法を、[Azure Traffic Managerで制御](https://docs.microsoft.com/ja-jp/azure/app-service/web-sites-traffic-manager)することができます。

App Service のエンドポイントを Azure Traffic Manager のプロファイルに追加します。

Azure Traffic Manager は App Service アプリの状態 (実行中、停止、または削除済み) を追跡して、エンドポイントを決定します。

# Bitbucketとの連携

[Bitbucket](https://www.atlassian.com/ja/software/bitbucket)は、アトラシアン社が提供する、Gitリポジトリのサービスです。


組み込みの Kudu App Service ビルド サーバーを使用して、Bitbucket（、GitHub、または Azure Repos）から[継続的にデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-continuous-deployment)できます。


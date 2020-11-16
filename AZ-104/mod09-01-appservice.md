


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


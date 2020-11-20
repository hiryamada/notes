App Configuration

# 概要

アプリケーション設定と機能フラグを一元的に管理するためのサービスを提供します。

[製品ページ](https://azure.microsoft.com/ja-jp/services/app-configuration/)


[概要](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/overview)


※[AWS AppConfig](https://docs.aws.amazon.com/ja_jp/appconfig/latest/userguide/what-is-appconfig.html)


# App Configurationのシナリオ


App Configuration を使用すると、以下のシナリオを簡単に実装できます。

- さまざまな環境や地域に対応した階層型構成データの管理と配布を一元化する
- アプリケーションを再デプロイまたは再起動することなく、アプリケーション設定を動的に変更する
- 機能の可用性をリアルタイムで制御する

# App ConfigurationとKey Vault

App Configuration は、アプリケーションのシークレットを格納するために使用される Azure Key Vault を補完します。 

App Configuration と Key Vault は補完的なサービスであり、ほとんどのアプリケーションのデプロイで併用されます。

これらをまとめて使用できるように、App Configuration では、Key Vault に格納されている値を参照するキーを作成できます。 

App Configuration でこのようなキーを作成すると、App Configuration には、その値そのものではなく、Key Vault の値の URI が格納されます。

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=cmd%2Ccore2x


# リソースの作成

検索＞「App Configuration」


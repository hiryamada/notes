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
- [機能の可用性をリアルタイムで制御する - 機能フラグ](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core)

# App ConfigurationとKey Vault

App Configuration は、アプリケーションのシークレットを格納するために使用される Azure Key Vault を補完します。 

App Configuration と Key Vault は補完的なサービスであり、ほとんどのアプリケーションのデプロイで併用されます。

これらをまとめて使用できるように、App Configuration では、Key Vault に格納されている値を参照するキーを作成できます。 

App Configuration でこのようなキーを作成すると、App Configuration には、その値そのものではなく、Key Vault の値の URI が格納されます。

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=cmd%2Ccore2x


# リソースの作成

検索＞「App Configuration」

# ラベル

[値を設定するときに「ラベル」を追加する。](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-labels-aspnet-core#specify-a-label-when-adding-a-configuration-value)

# [ラベル付きの値のコードからの読み込み](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-labels-aspnet-core#load-configuration-values-with-a-specified-label)

Select()を2回実行する。1回めはラベルなしの構成値を読み取る。2回めは現在の環境（Prodなど）に対応するラベルが付いた構成値を読み取る。1回目の構成値は、2回めに読み込んだ構成値によって上書きされる。


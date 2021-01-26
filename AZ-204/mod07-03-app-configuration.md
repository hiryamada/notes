App Configuration

# 概要

アプリケーション設定と機能フラグを一元的に管理するためのサービスを提供します。

[製品ページ](https://azure.microsoft.com/ja-jp/services/app-configuration/)


[概要](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/overview)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/app-configuration/)

Free と Standard。Freeは 1000回/日、Standardは 20,000回/時 の要求クォータがある。Standardは一日 1.2ドル～

※[AWS AppConfig](https://docs.aws.amazon.com/ja_jp/appconfig/latest/userguide/what-is-appconfig.html)

# 登場時のブログより


https://azure.microsoft.com/ja-jp/updates/azure-app-configuration-is-now-generally-available/

従来、ソフトウェア アプリケーションの構成設定は、アプリケーション コード自体の内部、または外部構成ファイル内に格納されていました。

このアプローチは、最新のクラウドベース アプリでは適切に機能しません。 

これらのアプリは、**テスト、ステージング、運用**など、さまざまな構成を持つ複数の環境にまたがる DevOps パイプライン間を移動する必要があるからです。

運用環境にデプロイした後は、軽微な文字列の変更から機能全体の無効化にいたるまで、**アプリの再デプロイや再起動をすることなく**構成の更新プログラムを受け取る必要があります。  

複数の分散コンポーネントで構成されるアプリに対応する場合、これらの問題はさらに難しくなります。 

これらのコンポーネント全体に構成設定を配布すると、不整合が発生する可能性があり、デプロイ中またはデプロイ後にエラーをトラブルシューティングすることが困難になります。

Azure App Configuration を使用すれば、お客様のアプリケーションの構成設定を 1 か所に格納し、セキュリティで保護することができます。

**App Configuration で設定を更新すると、変更がすぐに反映されることが確認できます**。

**アプリケーションを再デプロイまたは再起動する必要はありません。**

機能フラグの内側に新しい機能を安全にデプロイすることで、**小さなサブセットのユーザーにロールアウト**したり、必要に応じて完全に無効にしたりすることができます。

構成の変更履歴をすばやく表示し、**構成を以前の状態にロールバックできます**。

**App Services 構成設定または外部ファイルから構成をインポート**できます。

Azure DevOps パイプラインまたは GitHub リポジトリと統合できます。 

# App Configurationのシナリオ


App Configuration を使用すると、以下のシナリオを簡単に実装できます。

- さまざまな環境や地域に対応した階層型構成データの管理と配布を一元化する
- アプリケーションを再デプロイまたは再起動することなく、アプリケーション設定を動的に変更する
- [機能の可用性をリアルタイムで制御する - 機能フラグ](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core)

# App Configuration と Key Vault の関係

App Configuration は、アプリケーションのシークレットを格納するために使用される Azure Key Vault を補完します。 

App Configuration と Key Vault は補完的なサービスであり、ほとんどのアプリケーションのデプロイで併用されます。

これらをまとめて使用できるように、**App Configuration では、Key Vault に格納されている値を参照するキーを作成できます**。 

App Configuration でこのようなキーを作成すると、App Configuration には、その値そのものではなく、Key Vault の値の URI が格納されます。

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=cmd%2Ccore2x


# リソースの作成

検索＞「App Configuration」

# ラベル

Azure App Configuration では、"ラベル" を使用することで、同じキーに対して異なる値を定義できます。 

たとえば、開発環境用と運用環境用で異なる値を持つ 1 つのキーを定義できます。 App Configuration に接続するときに読み込むラベルを指定できます。

[値を設定するときに「ラベル」を追加する。](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-labels-aspnet-core#specify-a-label-when-adding-a-configuration-value)

[ラベル付きの値のコードからの読み込み](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-labels-aspnet-core#load-configuration-values-with-a-specified-label)

Select()を2回実行する。1回めはラベルなしの構成値を読み取る。2回めは現在の環境（Prodなど）に対応するラベルが付いた構成値を読み取る。1回目の構成値は、2回めに読み込んだ構成値によって上書きされる。


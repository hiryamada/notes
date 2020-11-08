# Azure グローバルインフラストラクチャ

[グローバルインフラストラクチャとは](https://azure.microsoft.com/ja-jp/global-infrastructure/)

- 160 か所を超える物理データセンター
- グローバルな Azure ネットワーク

データは信頼された Microsoft ネットワーク内に完全に保持され、IP トラフィックがパブリック インターネットに入ることはありません。[仮想ネットワークから Azure サービスへのトラフィックは常に、Microsoft Azure のバックボーン ネットワーク上に残ります](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/network-best-practices?bc=%2fazure%2farchitecture%2fbread%2ftoc.json&toc=%2fazure%2farchitecture%2ftoc.json#secure-your-critical-azure-service-resources-to-only-your-virtual-networks)。

# Azure のインフラストラクチャの包含関係

地域(geography) ＞ リージョン ペア ＞ リージョン ＞（可用性ゾーン）＞ データセンター

# リージョン

Azureでは、60を超える、他のどのクラウド プロバイダーよりも多いリージョンを利用できます。

1つのリージョンは、1つ以上のデータセンターで構成されます。

リソースをデプロイするときに、リージョンを選択します。ただし、Azure ADなど、一部のサービスについては、グローバルサービスであるため、リージョンの選択が必要ありません。

すべてのリージョンですべてのサービスがサポートされているわけではありません。[リージョン別の利用可能なサービス](https://azure.microsoft.com/ja-jp/global-infrastructure/services/)を確認してください。

# Azureの「地域」(geography)

それぞれの[Azure 地域](https://azure.microsoft.com/ja-jp/global-infrastructure/geographies/)には、1 つ以上のリージョンが含まれています。

例：米国は8リージョン、日本は2リージョンが存在します。

コンプライアンス要件に応じて、適切な地域を選択します。

# リージョン ペア

[リージョン ペア](https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions)は、同じ地域内の 2 つのリージョンで構成されます。

例：「日本」地域には、東日本リージョンと西日本リージョンがあります。

Azure プラットフォームの更新 (計画メンテナンス) が行なわれる場合、一度に更新されるリージョンが各ペアのうち 1 つのみになるようにしています。

災害などにより、複数のリージョンに影響がある場合、各ペアの少なくとも 1 つのリージョンが優先的に復旧されます。

# 可用性ゾーン

リージョンによっては、[可用性ゾーン](https://docs.microsoft.com/ja-jp/azure/availability-zones/az-overview#availability-zones)に対応しています。

例：東日本リージョンは可用性ゾーンに対応しています。西日本リージョンは可用性ゾーンに対応していません。

可用性ゾーンに対応しているリージョンには、少なくとも3つの可用性ゾーンがあります。

可用性ゾーンは、1 つ以上のデータセンターで構成されており、独立した電源、ネットワーク、冷却装置を備えています。

ユーザーは、リソースを複数の可用性ゾーンに配置することで、リソースの可用性を高めることができます。たとえば、[複数の可用性ゾーンにまたがる仮想マシンスケールセット](https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-use-availability-zones)を作成することができます。


# Azure サブスクリプション

[Azure サービスを作成して使用するには、Azure サブスクリプションが必要です。](https://docs.microsoft.com/ja-jp/learn/modules/create-an-azure-account/1-introduction)

- Azure サブスクリプションは、Azure でリソースをプロビジョニングするために使用される論理コンテナーです。 
- 仮想マシン (VM) やデータベースなどのすべてのリソースの詳細が保持されます。
- [サブスクリプションは、1つのディレクトリを信頼します（サブスクリプションは、1つのディレクトリに関連付けられます）。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-how-subscriptions-associated-directory)

※ トレーニングでは、無料の[Azure Pass サブスクリプション](https://docs.microsoft.com/ja-jp/learn/certifications/mocazurepass)を利用することができます。


# サブスクリプションの取得

テナントに、新しいサブスクリプションを[追加することができます。](https://docs.microsoft.com/ja-jp/learn/modules/create-an-azure-account/4-multiple-subscriptions)

マイクロソフト エンタープライズ契約 (EA)、Microsoft 顧客契約、Microsoft Partner Agreement の各課金アカウントには、[Azure portal から追加でサブスクリプションを作成できます。](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/manage/create-subscription)

# サブスクリプションの使い方

サブスクリプションを使い分ける目的としては、以下のものがあります。

- 環境の分離: 開発とテスト、セキュリティ、またはコンプライアンス上の理由でデータを分離することができます。 リソース アクセス制御はサブスクリプション レベルで設定できます。
- 課金の管理: コストは最初にサブスクリプション レベルで集約されます。サブスクリプションを作成して、必要に応じてコストを管理および追跡しやすくなります。 たとえば、本番用のサブスクリプションと、開発用の別のサブスクリプションを作成することができます。
- 組織構造を反映: たとえば、チームごとにサブスクリプションを作ることができます。
- 制限の回避: サブスクリプションにはいくつかのハード制限があります。 たとえば、サブスクリプションごとの [ExpressRoute 回線](https://azure.microsoft.com/ja-jp/services/expressroute/)の最大数は 10 です。制限を超える必要がある場合は、追加のサブスクリプションが必要になることがあります。


# Cost Management


# リソースタグ
# コスト削減


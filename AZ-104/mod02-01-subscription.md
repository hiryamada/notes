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

# サブスクリプションの取得方法


[無料と有料の両方のサブスクリプション オプションが提供されています。](https://docs.microsoft.com/ja-jp/learn/modules/plan-manage-azure-costs/4-purchase-azure-services)

無料試用版 - 無料試用版サブスクリプションでは、人気のあるサービスの 12 か月間の無料使用、Azure サービスを調べるための 30 日間のクレジット、常に 25 個を超える無料のサービスが提供されます。 試用期間が終了するか、有料製品のクレジット期間が切れると、有料サブスクリプションにアップグレードしない限り、Azure サービスは無効になります。

従量課金制 - 従量課金制サブスクリプションでは、クレジット カードまたはデビット カードをアカウントに関連付けることによって、使用した分の料金を支払うことができます。組織では、ボリューム割引および前払い請求を適用できます。

メンバー プラン - マイクロソフトの特定の製品やサービスに対する既存のメンバーシップによって、Azure アカウントのクレジットが提供され、Azure サービスの料金が削減される場合があります。 たとえば、Visual Studio サブスクライバー、Microsoft Partner Network メンバー、Microsoft for Startups メンバー、Microsoft Imagine メンバーで、メンバー プランを使用できます。


[Azure でサービスを購入するには、主に 3 つの方法があります。](https://docs.microsoft.com/ja-jp/learn/modules/plan-manage-azure-costs/4-purchase-azure-services)

マイクロソフトエンタープライズ契約の利用 - 大規模なお客様は、エンタープライズ カスタマーと呼ばれ、Microsoft と Enterprise Agreement を結ぶことができます。 この契約では、3 年間の Azure サービスに対して所定の金額を支払うことが決められています。 通常、サービス料金は年額払いです。 Enterprise Agreement のお客様は、使用する予定のサービスの種類と量に基づいて、カスタマイズされた最適な価格を利用することができます。

Web から直接 - この場合、Azure portal Web サイトから直接 Azure サービスを購入し、標準料金を支払います。 クレジット カードの支払いまたは請求書によって、毎月請求されます。 この購入方法は、Web ダイレクトと呼ばれています。

クラウド ソリューション プロバイダーの利用 - クラウド ソリューション プロバイダー (CSP) は、Azure 上でのソリューション構築を支援する Microsoft パートナーです。 CSP が決定した価格で、お客様に Azure の使用量に対する請求が行われます。 また、サポートに関する質問に回答し、必要に応じて Microsoft にエスカレーションします。

参考:

[早わかりガイド](https://download.microsoft.com/download/A/2/8/A28985D6-78DE-41A4-B5EA-6FA0270D824B/LicenseQuickStartGuide.pdf)

[マイクロソフトライセンス契約の比較（一般企業および公共機関向け）](http://download.microsoft.com/download/4/8/E/48EBFD21-76FC-44A5-9A2C-5B384214AA48/Transactional_Licensing_Comparison_Chart_JP.pdf)

[くらう道の解説](https://www.cloudou.net/azure/azure002/)

[SB C&S様による解説](https://licensecounter.jp/azure/faq/license/purchase.html)


# [Azure サブスクリプションの課金所有権を別のアカウントに譲渡する](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/manage/billing-subscription-transfer)

(Transfer billing ownership of an Azure subscription to another account)

譲渡: Transfer

課金所有権: Billing ownership

**アカウントの課金管理者のみ**がサブスクリプションの所有権を譲渡できます。


手順:

- サブスクリプションを選択
- 「課金所有権の譲渡」をクリック
- サブスクリプションの新しい所有者となる、アカウントの課金管理者であるユーザーのメール アドレスを入力
- 別の Azure AD テナントのアカウントにサブスクリプションを譲渡する場合は、[サブスクリプションを新しいアカウントのテナントに移行する](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/manage/billing-subscription-transfer#transfer-a-subscription-to-another-azure-ad-tenant-account)かどうかを選択
  - 別のテナントに移行すると、ロールの割り当てが風んに削除される。


# Azure Cost Management

Azure Cost Managementを使用して、クラウド全体のリソース使用量を追跡し、コストを管理することができます。

注意：トレーニングで使用する「Azure Pass - スポンサープラン」では、Azure Cost Managementがサポートされていません。

:bulb: Azure Cost Management には、「コストの請求と管理」や、「サブスクリプション」＞「コスト分析」からアクセスできます。

[製品ページ](https://azure.microsoft.com/ja-jp/services/cost-management/)

[Cost Managementの画面と使い方](https://docs.microsoft.com/ja-jp/learn/modules/analyze-costs-create-budgets-azure-cost-management/3-evaluate-costs-using-cost-analysis)

[予算とアラート](https://docs.microsoft.com/ja-jp/learn/modules/analyze-costs-create-budgets-azure-cost-management/5-build-budgets-alerts)

Microsoft Learn

- [Azure Cost Management + Billing を使用して Azure の支出を制御し、請求を管理する](https://docs.microsoft.com/ja-jp/learn/paths/control-spending-manage-bills/)
  - [Azure Cost Management を使用したコストの分析と予算の作成](https://docs.microsoft.com/ja-jp/learn/modules/analyze-costs-create-budgets-azure-cost-management/)
- パートナー様向け: [Azure Cost Management を使用した Microsoft パートナーとしてのコストの構成と管理](https://docs.microsoft.com/ja-jp/learn/modules/manage-costs-partner-cost-management/)


# リソースタグ

- 1 つのリソースには最大 50 個のタグを設定することができます。
- ストレージ アカウントを除く、あらゆる種類のリソースで名前は 512 文字に制限されています。
  - ストレージ アカウントの場合、128 文字という制限があります。
- タグの値は、リソースの種類を問わず、256 文字に制限されています。
- タグが親リソースから継承されることはありません。リソースグループにタグを付けても、リソースグループ内のリソースにはそのタグは付きません。
- リソースの種類によっては、タグをサポートされていません。

タグの活用方法

- 課金データをグループ化できます。
- タグを使ってリソースを検索し、操作を行います。たとえば、VMに「shutdown:6PM」 と 「startup:7AM」 といったタグを付け、タグに従って自動的にVMを開始・停止するように、運用を自動化することができます。

Microsoft Learn

[タグ付けを使用してリソースを整理する](https://docs.microsoft.com/ja-jp/learn/modules/control-and-organize-with-azure-resource-manager/3-use-tagging-to-organize-resources)


# コスト削減

※以下、価格例は2020/11現在の料金です。

Azure では、[多数のサービスにおいて、予約を行う](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations#charges-covered-by-reservation)ことで、コストを大幅に節約することができます。

例：D2 v3, 従量課金制、ライセンス込み、東日本リージョンの場合

|支払い方法|価格|
|-|-|
|従量課金制|$161.33|
|1年予約|$126.57|
|3年予約|$107.63|

[Azure ハイブリッド特典](https://azure.microsoft.com/ja-jp/pricing/hybrid-benefit/)では、オンプレミスの Windows Server と SQL Server のライセンスを Azure で利用することができます。クラウドでワークロードを実行するコストを大幅に削減（最大で85%）することができます。

例：D2 v3, 従量課金制、ライセンス込み、東日本リージョン、従量課金制の場合

|支払い方法|価格|
|-|-|
|ライセンス込み|$161.33|
|Azure ハイブリッド特典|$67.16|

[Azure Pricing Calculator（料金計算ツール）](https://azure.microsoft.com/ja-jp/pricing/calculator/)で、料金のシミュレーションを行うことができます。


Azure のリージョンによって、サービスの価格が異なります。

例：D2 v3, 従量課金制、ライセンス込みの場合

|リージョン|1ヶ月あたりの価格|
|-|-|
|East US| $137.24|
|North Central US|$140.16|
|Australia Central|$158.41|
|Japan East| $161.33|
|Japan West| $161.33|
|Brazil South|$183.23|
|France South|$193.45|
|Switzerland West|$203.67|

Japan EastのVMをEast USに移動すると85%安くなります。



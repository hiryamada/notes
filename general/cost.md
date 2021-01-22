# コストについて

[Azure Well-Architected Frameworkのコスト最適化の原則](https://docs.microsoft.com/ja-jp/azure/architecture/framework/cost/overview)

[コスト管理(Azure Cost Management and Billing)](https://azure.microsoft.com/ja-jp/services/cost-management/)

# Azure ハイブリッド特典

https://azure.microsoft.com/ja-jp/pricing/hybrid-benefit/

https://azure.microsoft.com/ja-jp/pricing/license-mobility/

https://www.microsoft.com/ja-jp/licensing/licensing-programs/software-assurance-license-mobility

https://www.microsoft.com/cms/api/am/binary/RE4uew0

マイクロソフト ボリューム ライセンスのお客様は、ソフトウェア アシュアランスにより、新しいライセンスを購入する必要がなくなり、Azure クラウド プラットフォームに既存のライセンスを簡単にデプロイできます。

Windows Server と SQL Server の両方のワークロードに Azure ハイブリッド特典を使用することで、節約を最大限にすることができます。

既存のオンプレミスの Red Hat または SUSE ソフトウェア サブスクリプションを Azure で使用できます。

https://azure.microsoft.com/ja-jp/overview/azure-vs-aws/

Windows Server と SQL Server 向けでは、AWS は Azure と比べて [5 倍のコスト](https://azure.microsoft.com/ja-jp/overview/azure-vs-aws/cost-savings/)がかかります。


# 予約

https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations


Azure の予約には、複数の製品に対する計画を 1 年分または 3 年分コミットすることで、コストを削減する効果があります。

予約の対象となる主なサービス（[完全なリストはこちら](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations#charges-covered-by-reservation)）:

- VM
- Storage
- Cosmos DB
- App Serviceのスタンプ料金
- P30サイズ以上のPremium SSD
- Red Hatプラン
- SUSE Linux

# VM

https://azure.microsoft.com/ja-jp/pricing/details/virtual-machines/windows/

ページの頭に「秒単位」と書いてあるが、実際には（[それよりも優れた](https://satonaoki.wordpress.com/2017/10/11/azure-vm-per-second-billing/)）分単位で計算される。同ページの「よくある質問」より:

> 仮想マシンの実行時間が 6 分 45 秒だった場合、いくら課金されますか?

> 仮想マシンの実行時間に対して分単位で料金が発生するため、超過した秒数に対して課金されることはありません。この例の場合、課金の対象となるのは 6 分です。

VMの状態が「開始中」「割り当て解除中」「割り当て解除済み」の場合は課金されない。

割り当て解除: VM が停止され、ホストから削除された状態。

https://docs.microsoft.com/ja-jp/azure/virtual-machines/states-lifecycle

# スポットVM

https://azure.microsoft.com/ja-jp/pricing/spot/

Azure Spot Virtual Machines (スポット VM) を使用すると、従量課金制の価格と比較して、未使用の Azure コンピューティング容量を最大で 90% の割引価格でご利用いただけます。

Azure VM または VM スケール セット (VMSS) でスポット VM の価格を利用できます。

# VMに付随する料金

VMには、IPアドレス、NIC、ディスクなどのリソースが付随する。VMを停止（割り当て解除）しても、付随するリソースについては料金がかかる場合がある。

[パブリックIPアドレス](https://azure.microsoft.com/ja-jp/pricing/details/ip-addresses/): 関連付けられた仮想マシンが "停止済みかつ割り当て解除済み" の場合に、"動的" パブリック IP アドレスには課金されません。

ディスク: 例として、[StandardのSSDマネージドディスクの場合](https://azure.microsoft.com/ja-jp/pricing/details/managed-disks/)、Standard SSD マネージド ディスク ストレージの総コストは、ディスクのサイズと数、トランザクションの回数、および送信データ転送の回数に応じて発生する。

[ディスク上のデータサイズではなく、プロビジョニングした容量に対して課金される。ディスクのサイズは縮小することはできない。](https://docs.microsoft.com/ja-jp/azure/virtual-machines/faq-for-disks)

https://www.publickey1.jp/blog/21/red_hat_enterprise_linux16okred_hat.html

# Azure AutomationによるVM運用例

https://internet.watch.impress.co.jp/docs/column/shimizu/1199751.html


# 管理ディスクの課金

https://jpasms.z11.web.core.windows.net/%E7%AE%A1%E7%90%86%E3%83%87%E3%82%A3%E3%82%B9%E3%82%AF%E3%81%AE%E8%AA%B2%E9%87%91%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6.html


# App Service

料金は停止状態のアプリにも適用されます。課金が発生しないようにするには、使用していない アプリを削除するか、レベルを Free に更新してください。

https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/

# Azure 料金計算ツール

https://azure.microsoft.com/ja-jp/pricing/calculator/

# Azure 総保有コスト（TCO）計算ツール

https://azure.microsoft.com/ja-jp/pricing/tco/calculator/

# Azure [開発/テスト価格](https://azure.microsoft.com/ja-jp/pricing/dev-test/)

- [Visual Studio サブスクライバー向け](https://azure.microsoft.com/ja-jp/pricing/member-offers/credit-for-visual-studio-subscribers/)
- [エンタープライズ 開発/テスト](https://azure.microsoft.com/ja-jp/offers/ms-azr-0148p/)
- [従量課金制 開発/テスト](https://azure.microsoft.com/ja-jp/offers/ms-azr-0023p/)

# 無料アカウント

Azure の無料アカウントでは、無料サービス (数に制限あり) を 12 か月間ご利用いただけます。

たとえば、Azure の無料アカウントでは、B1S Windows 仮想マシンを毎月 750 時間、無料で使用できます。 

Azure 無料アカウントにサインアップすると、お客様は使用制限として機能する $200 クレジットを受け取ります。つまり、最初の 30 日間は、無料製品の上限を超えて使用したリソースの分が $200 クレジットから差し引かれます。

https://azure.microsoft.com/ja-jp/free/


https://docs.microsoft.com/ja-jp/azure/cost-management-billing/manage/create-free-services

https://azure.microsoft.com/ja-jp/free/free-account-faq/

# Cosmos DB

「[Azure Cosmos DB を無料で試す](https://azure.microsoft.com/ja-jp/try/cosmosdb/)」では、Azure アカウントにサインアップしたりクレジット カードを使用したりせずに、クラウドでの Azure Cosmos DB を無料のエクスペリエンスとして試すことができます。 Azure Cosmos DB 試用アカウントでは、利用期間が限られています (現在は 30 日)。 

# App Service

https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/

Free (F1) プランは無料で使えます。

# Azure AD

https://azure.microsoft.com/ja-jp/pricing/details/active-directory/

Free エディションは、Azure、Dynamics 365、Intune、Power Platform などの商用のオンライン サービスのサブスクリプションに含まれています。


# ホット、クール、アーカイブ層

ストレージコスト：ホット＞クール＞アーカイブ


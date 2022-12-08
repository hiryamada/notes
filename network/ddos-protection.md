# Azure DDoS Protection

マイクロソフトのエンタープライズ サービスとコンシューマー サービスを大規模な攻撃から保護してきた実績に基づき、Azureのネットワーク全体を保護。

公式サイト
https://azure.microsoft.com/ja-jp/services/ddos-protection/

ドキュメント(Azure DDoS Protection Standard)
https://docs.microsoft.com/ja-jp/azure/ddos-protection/ddos-protection-overview

料金
https://azure.microsoft.com/ja-jp/pricing/details/ddos-protection/

2018/4/18 Azure DDoS Protection Standard 一般提供開始
https://docs.microsoft.com/ja-jp/archive/blogs/jpitpro/azure-ddos-protection-for-virtual-networks-generally-available

2022/10/12 IP Protection SKU for Azure DDoS Protection
https://azure.microsoft.com/en-us/updates/public-preview-ip-protection-sku-for-azure-ddos-protection/

■実績

https://pc.watch.impress.co.jp/docs/news/1358517.html

> Microsoft Azure、2.4Tbpsもの大規模DDoS攻撃をさばき切る(2021/10/14)

> Microsoftは11日(現地時間)、同社の提供するクラウドコンピューティングサービスAzureにて、2.4Tbpsもの大規模なDDoS攻撃をさばいたと報告した

> Azureでは、DDoS Protectionプラットフォームを活用し、この攻撃を検知して吸収した。発生源となった国や地域で攻撃の緩和を実行し、標的となったユーザーや地域に届く前に押さえ込んだ

■Azure DDoS Protection Basic

- 無料
- すべての Azure サービスが保護される。
- Azure プラットフォームに統合されており、デフォルトで有効
- アプリケーションの変更は不要
- トラフィックの常時監視
  - DDoS 攻撃の兆候を検出するために、アプリケーションのトラフィック パターンが 24 時間 365 日監視される
  - 攻撃が検出されると、攻撃を即座に自動的に軽減
- リアルタイムの軽減策を実施
- 一般的な防御機能を提供
  - 例:
    - レイヤー 7 への DNS クエリ フラッド攻撃を防御
    - Azure DNS ゾーンを標的とする Volumetric DDoS 攻撃を防御

■Azure DDoS Protection Standard

- 有料
  - ネットワーク保護レベル
    - 月額料金 (100 個のパブリック IP リソースの保護を含む)	$2,944/月
    - 超過料金 (パブリック IP リソースが 100 を超えた場合)	$29.5/リソース/月
  - IP保護レベル
    - 保護されているパブリック IP リソースあたりの月額料金	$199/月
- 仮想ネットワーク上のリソース（パブリック IP アドレスが付与されたリソース）の保護
  - 新規または既存の仮想ネットワーク上で「DDoS保護を有効化」する
- 1つのテナントで、複数のサブスクリプションに対して 1 つの DDoS 保護プランを使用できる
  - 複数の DDoS 保護プランを作成する必要はない
- リソースがネットワーク保護で保護されている場合は、DDoS 攻撃中のスケール アウト コストがすべてカバーされ、顧客はこれらのスケール アウトされたリソースに対するコストのクレジットを受け取る

■Azure DDoS Protection Standardの「レベル」 ※SKUとも

- IP保護レベル (2022/10/12 プレビュー開始)
  - 15 個未満のパブリック IP リソースを保護する必要がある場合
- ネットワーク保護レベル
  - 保護するパブリック IP リソースが 15 個を超える場合

■Azure DDoS シミュレーション

https://learn.microsoft.com/ja-jp/azure/ddos-protection/test-through-simulations#azure-ddos-simulation-testing-policy

攻撃のシミュレーションには、Microsoft が承認したテスト パートナーが提供するシミュレーション環境を使用する必要がある。

■参考: Azureで利用できる、A10ネットワークスのDDoS緩和ソリューション

A10 Thunder TPS VA for DDoS Protection

TPS: Threat Protection System, VA: Virtual Appliance

https://www.a10networks.co.jp/news/blog/azurel3l7_ddos.html

> Azure DDoS Protection Standardと併用することで、L3からL7までの攻撃に対する包括的な防御を実現

Azure Marketplace からデプロイする。

https://azuremarketplace.microsoft.com/en-us/marketplace/apps/a10networks.a10-vthunder-tps-2

■参考: A10ネットワークス

https://finance.yahoo.co.jp/quote/ATEN

> A10ネットワークスは、高度なアプリケーションネットワーキング技術のプロバイダー。顧客である企業、サービスプロバイダー、ウェブや政府機関のアプリケーションを高速化、最適化するとともに、そのセキュリティーの確保も支援することができる高性能な製品群を開発する。本社はカリフォルニア州サンノゼ。

日本法人: A10ネットワークス株式会社 東京都港区六本木
https://www.a10networks.co.jp/

■参考: A10 Thunder TPS （DDoS対策製品）

https://www.a10networks.co.jp/products/thunder-tps/

> DDoS攻撃の緩和を行いサービス停止を阻止するアプライアンス製品です。専用ハードウェアと仮想アプライアンスにより、1Gbps～500Gbpsの防御パフォーマンスを実現します。

https://jpn.nec.com/datanet/a10_ax/thundertps.html

> ThunderTPS（Threat Protection System）シリーズは、ハイパフォーマンスな防御機能によってネットワーク全体をDDoS攻撃から防御し、ボリューム攻撃や、プロトコル攻撃、リソース攻撃やその他の高度なアプリケーション攻撃などに対してサービスの可用性を確保します。

Thunder TPSのラインナップ
https://active.nikkeibp.co.jp/atclact/active/14/415101/102700543/


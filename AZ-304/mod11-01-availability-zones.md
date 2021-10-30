# 可用性ゾーンを使用した構成

2017/9/21
可用性ゾーン プレビュー
https://azure.microsoft.com/en-us/blog/introducing-azure-availability-zones-for-resiliency-and-high-availability/

2017/10/14 可用性ゾーン 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-availability-zones/

※可用性ゾーンが利用可能になった

2019/4/19 東日本リージョンが可用性ゾーンに対応
https://azure.microsoft.com/ja-jp/updates/general-availability-azure-availability-zones-in-japan-east/


■可用性ゾーンとは

https://docs.microsoft.com/ja-jp/azure/availability-zones/az-overview#availability-zones

https://docs.microsoft.com/ja-jp/azure/architecture/high-availability/building-solutions-for-high-availability

- Azure リージョン内の物理的な場所
  - ゾーン1, ゾーン2, ゾーン3など
- 各ゾーンは、独立した電源、冷却手段、ネットワークを備えた 1 つ以上のデータセンターで構成
- リージョン内で物理的に分離
- ゾーンの障害や災害（洪水、台風など）によるアプリケーションとデータへの影響を抑えることができる

おおざっぱに言えば、ゾーン＝データセンター。1つのアプリケーションを複数のゾーンにデプロイしておけば、1つのゾーンが停止しても、べつのゾーンでアプリケーションの運用を継続することができる。

各リージョンのゾーン対応状況については、「Azure の地域」を参照。
https://azure.microsoft.com/ja-jp/global-infrastructure/geographies/#overview

各リージョンの「Availability Zones のプレゼンス」で確認できる。

■「ゾーンアーキテクチャ」と「ゾーン冗長アーキテクチャ」

https://docs.microsoft.com/ja-jp/azure/architecture/high-availability/building-solutions-for-high-availability#zonal-vs-zone-redundant-architecture

Availability Zones をサポートする Azure サービスは、「ゾーン(zonal, Z)」と「ゾーン冗長(zone-redundant, ZR)」の 2 つのカテゴリに分類される。

- 「ゾーン(zonal, Z)」
  - 例: VM(仮想マシン)は、ゾーン1, ゾーン2, ゾーン3などのゾーンを指定してリソースをデプロイできる。
  - 例: Azure Load Balancerも、ゾーンを指定してリソースをデプロイできる。
- 「ゾーン冗長(zone-redundant, ZR)」
  - 例: Azure Load Balancerは、「ゾーン冗長」でデプロイすることができる。1つのリソースが、ゾーン間にレプリケーションされる。1つのゾーンに障害が発生しても、負荷分散機能が利用できる。

ドキュメントに、ゾーン/ゾーン冗長に対応するAzureサービスの一覧がある。
https://docs.microsoft.com/ja-jp/azure/architecture/high-availability/building-solutions-for-high-availability#zonal-vs-zone-redundant-architecture

※Azure Load BalancerはZもZRの2つのカテゴリに含まれる（両方のデプロイをサポート）。

※ZやZRのカテゴリに含まれているサービスは、**ゾーンを指定せずにデプロイ**することもできる。


■VMの可用性

■構成例



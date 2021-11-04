# 可用性ゾーンを使用した構成の例

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
  - 自分で選んだ特定の Availability Zones にリソースをデプロイできる
    - 例: VM(仮想マシン)は、ゾーン1, ゾーン2, ゾーン3などのゾーンを指定してリソースをデプロイできる。
    - 例: Azure Load Balancerも、ゾーンを指定してリソースをデプロイできる。
- 「ゾーン冗長(zone-redundant, ZR)」
  - Azure プラットフォームによって、リソースとデータがゾーン間で自動的にレプリケートされる
  - 例: Azure Load Balancerは、「ゾーン冗長」でデプロイすることができる。1つのゾーンに障害が発生しても、負荷分散機能が利用できる。

ドキュメントに、ゾーン/ゾーン冗長に対応するAzureサービスの一覧がある。
https://docs.microsoft.com/ja-jp/azure/architecture/high-availability/building-solutions-for-high-availability#zonal-vs-zone-redundant-architecture

※Azure Load Balancerはゾーン(Z)、ゾーン冗長(ZR)の2つのカテゴリに含まれる（両方のデプロイをサポート）。

※ZやZRのカテゴリに含まれているサービスは、**ゾーンを指定せずにデプロイ**することもできる。


■構成例(ロードバランサーとVM)

Azure Load Balancer: [Standard SKUで可用性ゾーンをサポート。](https://docs.microsoft.com/ja-jp/azure/load-balancer/skus#sku-comparison)

```
Standard の IPアドレス
↓
Azure Load Balancer[ゾーン冗長] ... 3つのゾーンにまたがる。
↓             ↓             ↓       
VM1           VM2           VM3
[ゾーン1]      [ゾーン2]     [ゾーン3]
```

Application Gateway: Standard V2/WAF V2 SKUで、ゾーン冗長に対応。[インスタンスは複数のゾーンに分散される。](https://docs.microsoft.com/ja-jp/azure/application-gateway/application-gateway-faq#application-gateway-----------------------------)


```
Standard の IPアドレス
↓
Azure Application Gateway[ゾーン冗長]

[ゾーン1]      [ゾーン2]     [ゾーン3]
インスタンス1 インスタンス2 インスタンス3 .. AppGWのインスタンス
↓             ↓             ↓  
VM1           VM2           VM3
```

■構成例（Azure SQL Database）

Azure SQL Database のゾーン冗長

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: 
    サービスレベル 
      Basic
      Standard
      Premium ★構成可★
  仮想コア購入モデル: 
    サービスレベル 
      General Purpose (プロビジョニング/サーバーレス) ★構成可★
      Business Critical ★構成可★
      Hyperscale
Azure SQL Database Managed Instance
  仮想コア購入モデル: サービスレベル General Purpose, Business Critical
```

- [「仮想コア購入モデル, General Purposeサービスレベル」の ゾーン冗長(プレビュー)](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/high-availability-sla#premium-and-business-critical-service-tier-zone-redundant-availability)
  - ステートフル データ レイヤー
    - データは物理的に分離された 3 つの Azure 可用性ゾーン間で同期的にコピーされる（ZRS）
  - ステートレス コンピューティング レイヤー
    - 「ステートレスノード」(stateless node)
    - 「予備キャパシティノード」(nodes with spare capacity)
      - フェールオーバー時に利用される
      - 他の可用性ゾーンですぐに使用できる
  - 制限
    - Gen5 コンピューティング ハードウェアが選択されている場合のみ利用できる
    - SQL Managed Instance では使用できない

```
Azure SQL Database サーバー
└データベース[ゾーン冗長]

[ゾーン1]    [ゾーン2]    [ゾーン3]
ステートレス ステートレス ステートレス  ... ステートレス
ノード1      ノード2     ノード3          コンピューティングレイヤー
↑           ※予備キャパ ※予備キャパ
|       
|データ       データ      データ   ... ステートフルデータレイヤー
|                                   .mdf/.ldfをZRSでレプリケーション
|       
アプリ
```

- 「DTU購入モデル, Premiumサービスレベル」の ゾーン冗長 および
- 「仮想コア購入モデル, Business Criticalサービスレベル」の ゾーン冗長
  - 1つの「プライマリレプリカ」と最大3つの「セカンダリレプリカ」で構成
  - レプリカはノードとも呼ばれる。
    - 1つのノードで、コンピュート(sqlservr.exe)とSSDストレージを統合
  - レプリカは3つのゾーンに分散して配置される
  - プライマリレプリカはアプリケーションからの接続に利用される
  - プライマリにトランザクションがコミットされると、セカンダリレプリカの少なくとも1つに変更をプッシュする
  - プライマリがクラッシュすると、セカンダリレプリカの1つが新しいプライマリノードになり、もう1つのセカンダリが作成される
  - Business Critical レベルを使用している場合、ゾーン冗長構成は Gen5 コンピューティング ハードウェアが選択されている場合のみ利用可能
  - SQL Managed Instance では使用できない

```
Azure SQL Database サーバー
└データベース[ゾーン冗長]

[ゾーン1]           [ゾーン2]           [ゾーン3]
プライマリレプリカ   セカンダリレプリカ1  セカンダリレプリカ2
↑セカンダリレプリカ3
|
|
アプリ
```

■構成例（SQL Server on VM）

[可用性ゾーン利用可能。詳細はドキュメントを参照](https://docs.microsoft.com/ja-jp/azure/azure-sql/virtual-machines/windows/availability-group-overview)

■構成例（Oracle DB）

[可用性ゾーン利用可能。詳細はドキュメントを参照](https://docs.microsoft.com/ja-jp/azure/virtual-machines/workloads/oracle/oracle-reference-architecture)


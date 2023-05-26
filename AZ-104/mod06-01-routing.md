# ルーティング

■ルートテーブル
https://learn.microsoft.com/ja-jp/azure/virtual-network/manage-route-table

各サブネットには、0 個または 1 個のルート テーブルを関連付けることができます。

```
VNet
└サブネット
 └ルートテーブル
```

■UDR (User Defined Route)

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-udr-overview#user-defined

ルートテーブルの中に、「ユーザー定義ルート」(UDR)を作成して、ルーティングをカスタマイズできます。

- UDR
  - アドレスプレフィックス `0.0.0.0/0`等
  - ネクストホップの種類(「仮想ネットワーク ゲートウェイ」「仮想アプライアンス」等)

■ルートテーブル / UDRの使用例

例1: サブネットからのトラフィックをすべてVPN経由でオンプレミスに転送する

```
VNet
├GatewaySubnet
│└仮想ネットワークゲートウェイ(type: VPN) - オンプレミス
└Subnet1
 ├VM
 └ルートテーブル (0.0.0.0/0 -> 仮想ネットワークゲートウェイ)
```

例2: サブネットからのトラフィックをすべて「ネットワーク仮想アプライアンス」(NVA)経由でインターネットに送信する

※[NVA](https://azure.microsoft.com/ja-jp/solutions/network-appliances/): VMの形でデプロイされるファイアウォール、ルーター、ロードバランサー等

```
VNet
├Subnet1
│└仮想アプライアンス(NVA) - インターネット
└Subnet1
 ├VM
 └ルートテーブル (0.0.0.0/0 -> 仮想アプライアンス(NVA))
```

例3: サブネットからのトラフィックをすべて「Azure Firewall」経由でインターネットに送信する

[※Azure Firewallの場合もネクストホップはVirtualApplianceとする](https://learn.microsoft.com/ja-jp/azure/firewall/tutorial-firewall-deploy-portal#create-a-default-route)

```
VNet
AzureFirewallSubnet
│└Azure Firewall - インターネット
└Subnet1
 ├VM
 └ルートテーブル (0.0.0.0/0 -> 仮想アプライアンス(Azure Firewall))
```

<!--
■ハブ&スポーク型のVNetピアリング接続で、スポーク間で通信したい場合

```
VNet1（スポーク）10.0.0.0/16
│└サブネット - ルートテーブル (10.1.0.0/16 -> NVA)
│   └vm1
│ピアリング
VNet（ハブ）
│└サブネット
│  └NVA（ルーターとしてセットアップされたVM）
│ピアリング
VNet2（スポーク）10.1.0.0/16
 └サブネット - ルートテーブル (10.0.0.0/16 -> NVA)
    └VM2
```

※NVA: [ネットワーク仮想アプライアンス](https://azure.microsoft.com/ja-jp/solutions/network-appliances/)

■Azure Firewallを経由してインターネットに接続したい場合

```
VNet
├AzureFirewallSubnet
│ └Azure Firewall
└サブネット - ルートテーブル (0.0.0.0/0 -> Azure Firewall ※)
  └VM1
```

※実際にはルートテーブルのルートで「ネクストホップの種類」として「仮想アプライアンス」を指定し、「ネクストホップアドレス」にAzure FirewallのIPアドレスを指定。

■オンプレミスのファイアウォールを経由してインターネットに接続したい場合

※「[強制トンネリング](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm)」とも

```
オンプレミス
      ├ファイアウォール → インターネット
      │         ↑
      └VPNルーター等
VNet            ↑
├GatewaySubnet  ↑VPN
│ └仮想ネットワークゲートウェイ(type:VPN / ExpressRoute)
└サブネット - ルートテーブル (0.0.0.0/0 -> 仮想ネットワークゲートウェイ)
  └VM1
```

[Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/modules/control-network-traffic-flow-with-routes/2-azure-virtual-network-route)を参照。


[Azure VM の外部接続 (SNAT) オプション まとめ - Azure Networking テクニカル サポート](https://jpaztech.github.io/blog/network/snat-options-for-azure-vm/)


# システム ルート

Azure のサブネット、仮想ネットワーク、およびオンプレミスのネットワークの間を自動的にルーティングされます。 

このルーティングは、仮想ネットワーク内の各サブネットに既定で割り当てられる、システム ルートによって制御されます。 

システム ルートを作成したり、削除したりすることはできません。 

# システム ルートの確認方法

VMのネットワーク インターフェースを表示し、「サポート＋トラブルシューティング」の「有効なルート」で表示できます。

# [仮想アプライアンス(NVA)](https://azure.microsoft.com/ja-jp/solutions/network-appliances/)

[AZ-500のノート](../AZ-500/mod02-02-08-nva.md)

# カスタム ルート

カスタム ルートを追加して次ホップへのトラフィック フローを制御することで、システム ルートをオーバーライドすることができます。

# カスタム ルートの作成

画面上部の検索で「ルート テーブル」を検索

ルート テーブルを作成

作成後、「設定＞ルート」で「＋追加」を押して、カスタムのルートを追加します。

# カスタム ルートをサブネットに割り当てる

「設定＞サブネット」で、「＋関連付け」をクリックし、関連付けを行うサブネットを選択します。

# [サービスエンドポイント](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-service-endpoints-overview)

サービス エンドポイントでは、Azure のバックボーン ネットワーク上で最適化されたルートを介して、Azure サービスに安全に直接接続できます。 

サービス エンドポイントを使用すると、VNet 内のプライベート IP アドレスは、VNet 上のパブリック IP アドレスを必要とせずに、Azure サービスのエンドポイントに接続できます。


[サービス エンドポイントを追加しても、パブリック エンドポイントは削除されません。 トラフィックがリダイレクトされるようになるだけです](https://docs.microsoft.com/ja-jp/learn/modules/secure-and-isolate-with-nsg-and-service-endpoints/4-vnet-service-endpoints)。

ストレージ アカウントでは、[ストレージアカウントのファイアウォール規則](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-network-security)を作成することで、指定したVNetのサブネット、指定したパブリックIPアドレス範囲からのみ、アクセスを許可することができます。

※ [サービスエンドポイントとAzure Private Linkとの使い分け](https://qiita.com/nakazax/items/937a512c0b69abdbd6cf#%E4%BD%BF%E3%81%84%E5%88%86%E3%81%91--%E4%BD%B5%E7%94%A8%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%87%E3%82%A3%E3%82%A2)

-->

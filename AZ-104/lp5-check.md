知識チェック

# ラーニングパス 5: [AZ-104:Azure 管理者向けの仮想ネットワークの構成と管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-virtual-networks/)
## モジュール 1: [仮想ネットワークを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-networks/)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-networks/9-knowledge-check)
  - 問題1 各サブネットのアドレス範囲のうち、[先頭4つと最後の1つは使用できない。](https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/private-ip-addresses#allocation-method)
  - 問題2 IPアドレスが変動しないように「静的」割り当てを使用する。
  - 問題3 仮想マシンにはパブリックIPアドレスを割り当てることができる。[AzureのリソースすべてにパブリックIPアドレスを割り当てできるわけではない。](https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/public-ip-addresses)
## モジュール 2: [ネットワーク セキュリティ グループを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-network-security-groups/)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-network-security-groups/7-knowledge-check)
  - 問題1 優先度の数値が小さいものが優先度が高い。
  - 問題2 仮想ネットワーク内からのトラフィック受信がデフォルトで許可されている。[（受信のAllowVNetInBound）](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview#inbound)
  - 問題3 NSGのIPアドレスの指定部分で、Azureのサービスを表す「[サービスタグ](https://docs.microsoft.com/ja-jp/azure/virtual-network/service-tags-overview)」を使用できる。これを使用することで、Azureのサービスへの送信、Azureのサービスからの受信を許可・拒否することができる。VirtualNetwork、AzureLoadBalancer、Storageなど。
## モジュール 3: [Azure Firewall を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-firewall/)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-firewall/5-knowledge-check)
  - 問題1 Azure SQL Databaseでは[「サーバー」を作成する](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/single-database-create-quickstart?view=azuresql&tabs=azure-portal#create-a-single-database)際に「server1」といったサーバー名を指定する。これにより「server1.database.windows.net」といったFQDNが割り当てられる。Azure Firewallの「[アプリケーション規則](https://docs.microsoft.com/ja-jp/azure/firewall/features#application-fqdn-filtering-rules)（選択肢のApplication）」を使用すると、FQDNを使用した規則を設定できる。
  - 問題2 Azure外部から、Azure Filewallを経由して、トラフィックを受信する場合は、DNATを使用する。
  - 問題3 Azure Firewallには[Standard SKUのパブリックIPアドレスを1つ以上割り当てる](https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/configure-public-ip-firewall)。Standard SKUのIPアドレスの場合、[割り当て方法は「静的」のみ。](https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/public-ip-addresses#sku)
## モジュール 4: [Azure DNS を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-dns/)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-dns/9-knowledge-check)
  - 問題1 Azure DNSでは、ドメイン（ゾーン）とレコードを管理する。
  - 問題2 ドメイン名とIPアドレスをマッピングするにはAレコードまたはAAAAレコードを使用する。
  - 問題3 （自分でDNSサーバーをセットアップして運用したりするといった）カスタムのDNSソリューションを導入せずに使用できるのがAzure DSNのメリットである。
## モジュール 5: [仮想ネットワーク ピアリングを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-vnet-peering/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-vnet-peering/6-knowledge-check)
  - 問題1 1つのピアリングは2つの「ピアリングリンク」で構成されている。vnet1とvnet2を接続する場合、vnet1→vnet2のピアリングリンク、vnet2→vnet1のピアリングリンクが両方とも Connected にならないと接続されない。[参考](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-manage-peering)
  - 問題2 ピアリングの設定の「ゲートウェイ転送」（ゲートウェイトランジット）を使用することで、たとえばスポークのvnetから、ハブのvnetのVPNゲートウェイ・ExpressRouteゲートウェイを使用して、オンプレミスに接続することができる。
  - 問題3 ピアリングのトラフィックはAzure内部（バックボーンネットワーク）を流れる。
## モジュール 6: [VPN Gateway を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-vpn-gateway/)
- ユニット 12: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-vpn-gateway/12-knowledge-check)
  - 問題1 ExpressRouteを使用する場合、オンプレ側としてはルートベースのVPNを使用する。
  - 問題2 VPNゲートウェイには多数のSKUが用意されている。選択したSKUにより帯域幅や同時接続数が決まる。
  - 問題3 VPNの接続を行う際、PSK（PreSharedKey）を両方のVPNデバイスに正しく設定する必要がある。
## モジュール 7: [ExpressRoute と Virtual WAN を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-expressroute-virtual-wan/)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-expressroute-virtual-wan/7-knowledge-check)
  - 問題1/3 ExpressRouteは、専用線（Azureへの直接接続）を提供するサービス。エンタープライズ向け。
  - 問題2 Virtual WANを使用すると、ハブ&スポーク型のネットワークを構成し、大規模なネットワークの構成を簡素化できる。
## モジュール 8: [ネットワーク ルーティングとエンドポイントを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-network-routing-endpoints/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-network-routing-endpoints/8-knowledge-check)
  - 問題1/2 [ルートテーブル（カスタムルート）で指定できる「ネクストホップ」の種類](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-udr-overview#user-defined): 仮想アプライアンス/仮想ネットワーク ゲートウェイ/なし/仮想ネットワーク/インターネット。「なし」の場合、トラフィックは転送されず破棄される.
  - 問題3 プライベートアドレス空間（＝VNet）から、ストレージアカウントなどのサービスに直結するには、仮想ネットワークエンドポイント（サービスエンドポイントまたはプライベートエンドポイント）を使用する。
## モジュール 9: [Azure Load Balancer を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-load-balancer/)
- ユニット 10: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-load-balancer/10-knowledge-check)
  - 問題1/3 仮想ネットワーク「内」で、VMからVMへと負荷分散を行うには、Azure Load Balancerの内部ロードバランサーを使用する。その場合の送信元・送信先VMは同じ仮想ネットワークに所属している必要がある。
  - 問題2 Azure Load Balancerのデフォルトの[分散アルゴリズム](https://docs.microsoft.com/ja-jp/azure/load-balancer/distribution-mode-concepts)は「5タプルハッシュ」である。
## モジュール 10: [Azure Application Gateway を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-application-gateway/)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-application-gateway/5-knowledge-check)
  - 問題1 Application Gateway のルーティングでは、ホスト名を使用したり（[複数サイトのホスティング](https://docs.microsoft.com/ja-jp/azure/application-gateway/multiple-site-overview)）、URLを使用したり（[URL パス ベースのルーティング](https://docs.microsoft.com/ja-jp/azure/application-gateway/url-route-overview)）することができる。
  - 問題2 バックエンドプール内のバックエンド（VM）は[ラウンドロビンで選択される。](https://docs.microsoft.com/ja-jp/azure/application-gateway/how-application-gateway-works)
  - 問題3 Application Gatewayの「WAF」「[WAF V2](https://docs.microsoft.com/ja-jp/azure/application-gateway/overview-v2)」を使用すると、WAF（Web Application Firewall）を同時にデプロイできる。
## モジュール 11: [Azure デプロイの IP アドレス指定スキーマを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-ip-addressing-for-azure/)
- ユニット 2: [ネットワーク IP アドレス指定と統合](https://docs.microsoft.com/ja-jp/learn/modules/design-ip-addressing-for-azure/2-network-ip-addressing-integration)
  - ※ページ下部に知識チェックあり
  - 問題1 ネットワーク設計では、VNet, サブネット、ファイアウォール、ロードバランサーなどを計画する。
  - 問題2 [RFC 1918](https://www.nic.ad.jp/ja/translation/rfc/1918.html)で定められているプライベートアドレス: 10.0.0.0/8, 172.16.0.0/12, 192.168.0.0/16。それ以外が正解となる。
## モジュール 12: [Azure 仮想ネットワーク全体にサービスを分散させ、仮想ネットワーク ピアリングを使用して統合する](https://docs.microsoft.com/ja-jp/learn/modules/integrate-vnets-with-vnet-peering/)
- ※知識チェックなし
## モジュール 13: [Azure DNS でドメインをホストする](https://docs.microsoft.com/ja-jp/learn/modules/host-domain-azure-dns/)
- ユニット 2: [Azure DNS とは](https://docs.microsoft.com/ja-jp/learn/modules/host-domain-azure-dns/2-what-is-azure-dns)
  - ※ページ下部に知識チェックあり
  - 問題1 Azure DNSでは、登録済み（取得済み）のドメインのレコードを管理する。ドメインレジストラではないため、新しいドメインの登録はできない。
  - 問題2 Azure DNSのセキュリティ: 固有のセキュリティ機能は特にない。Azureリソース共通の仕組み（ロールベースアクセス制御、アクティビティログ、リソースロック）が該当する。
  - 問題3 ドメイン名に対して1つまたは複数のIPアドレスを対応付けるには[Aレコード](https://e-words.jp/w/A%E3%83%AC%E3%82%B3%E3%83%BC%E3%83%89.html)または[AAAAレコード](https://e-words.jp/w/AAAA%E3%83%AC%E3%82%B3%E3%83%BC%E3%83%89.html)を使用する。
## モジュール 14: [ルートを使用して Azure デプロイでのトラフィック フローを管理および制御する](https://docs.microsoft.com/ja-jp/learn/modules/control-network-traffic-flow-with-routes/)
- ユニット 2: [Azure 仮想ネットワークのルーティング機能を特定する](https://docs.microsoft.com/ja-jp/learn/modules/control-network-traffic-flow-with-routes/2-azure-virtual-network-route)
  - ※ページ下部に知識チェックあり
  - 問題1 カスタムルート（ルートテーブル）をサブネットに関連付けることで、フロー（トラフィックのルーティング）をカスタマイズできる。
  - 問題2 仮想ネットワークピアリングにより、同じリージョンまたは異なるリージョンの2つのVNetを接続できる。
## モジュール 15: [Azure Load Balancer を使用してアプリケーションのスケーラビリティと回復性を向上させる](https://docs.microsoft.com/ja-jp/learn/modules/improve-app-scalability-resiliency-with-load-balancer/)
- ユニット 2: [Azure Load Balancer の特徴と機能](https://docs.microsoft.com/ja-jp/learn/modules/improve-app-scalability-resiliency-with-load-balancer/2-load-balancer-features)
  - ※ページ下部に知識チェックあり
  - 問題1 Azure Load Balancerのデフォルトの[分散アルゴリズム](https://docs.microsoft.com/ja-jp/azure/load-balancer/distribution-mode-concepts)は「5タプルハッシュ」である。
  - 問題2 可用性セットを使用することで、VMが「障害ドメイン」と「更新ドメイン」という論理的なグループに分離される。複数の「障害ドメイン」（＝ラック）を使用することで、ラック（物理サーバー）での電源・NW障害が発生しても、別の障害ドメインでVMを稼働させ続けることができ、全体として可用性が向上する。

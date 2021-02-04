# Azure Load Balancer

[サービスのトップページ](https://azure.microsoft.com/ja-jp/services/load-balancer/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview)


[Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/)

- [Azure の基礎](https://docs.microsoft.com/ja-jp/learn/paths/azure-fundamentals/)
  - [コア Cloud Services - Azure ネットワーク オプション](https://docs.microsoft.com/ja-jp/learn/modules/intro-to-azure-networking/)
- [AZ-104:Azure 管理者向けの仮想ネットワークの構成と管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-virtual-networks/)
  - [Azure Load Balancer を使用してアプリケーションのスケーラビリティと回復性を向上させる](https://docs.microsoft.com/ja-jp/learn/modules/improve-app-scalability-resiliency-with-load-balancer/)
  - [Azure Load Balancer の受信ネットワーク接続のトラブルシューティング](https://docs.microsoft.com/ja-jp/learn/modules/troubleshoot-inbound-connectivity-azure-load-balancer/)


[Load BalancerとApplication Gatewayの違い（Azureサポートチーム）](https://jpaztech1.z11.web.core.windows.net/LoadBalancer%E3%81%A8ApplicationGateway%E3%81%AE%E9%80%9A%E4%BF%A1%E3%81%AE%E9%81%95%E3%81%84.html)

[リージョン間ロード バランサー (プレビュー)](https://docs.microsoft.com/ja-jp/azure/load-balancer/cross-region-overview)

# Azure Load Balancerとは

トランスポート層(TCP/UDP)のロード バランサー サービス

インターネット トラフィックと内部トラフィックに対応


# 機能

- 受信と送信のどちらのシナリオもサポート
- TCP/UDPに対応
- 数百万ものフローにスケールアップ
- 特定のトラフィック用のポート転送
- 仮想ネットワーク内の VM 用の送信接続
- 可用性セットと可用性ゾーンに対応（標準LB）
- 内部ロード バランサー - 内部の Azure リソースから他の Azure リソースへ負荷分散
- パブリック ロード バランサー - インターネットからのトラフィックを負荷分散
- 正常性プローブ - バックエンドプール内の正常なVMにのみ要求を転送
- 透過的なエンドツーエンド接続 - 要求が VM に到着したとき、元のクライアントのアドレスを保持
- 選択された VM に送信されるように、メッセージの宛先のアドレスが再設定されます。
- いつでも新しい VM インスタンスを開始し、その IP アドレスをバックエンド プールに追加することができます。 
- 複数のパブリック フロントエンド IP アドレスを公開し、複数のバックエンド プールを持つことができます。 
- リソース正常性レポート
- [ソフトウェア実装](https://www.syuheiuda.com/?p=4884)。ロードバランサー自体のキャパシティや可用性についてユーザー側が心配する必要がない。Pre-warmingも不要。
- アウトバウンド規則

# 製品

- BasicとStandard
- 変更できません
- Basicは無料、Standardは課金

基本ロード バランサー
- ポート フォワーディング
- 自動再構成
- 正常性プローブ
- 送信元ネットワーク アドレス変換 (SNAT) による送信接続
- 公開ロード バランサーでの Azure Log Analytics による診断
- 可用性セットでのみ使用

標準ロード バランサー
- HTTPS 正常性プローブ
- 可用性ゾーン
- 多次元メトリックに関する Azure Monitor による診断
- 高可用性 (HA) ポート
- アウトバウンド規則
- 保証された SLA (2 台以上の仮想マシンの場合は 99.99%)

# コンポーネント

[Microsoft Learnの図](https://docs.microsoft.com/ja-jp/learn/modules/troubleshoot-inbound-connectivity-azure-load-balancer/2-troubleshoot-azure-load-balancer)

- ロード バランサー
- フロントエンドIPアドレス
- ルーティング規則
- 正常性プローブ
- バックエンドプール

# 分散アルゴリズム（分散モード）

「セッション永続化」の「なし」「クライアントIP」「クライアントIPとプロトコル」で選択。

- 5 タプル ハッシュ - デフォルト
- 接続元 IP アフィニティ

# 5 タプル ハッシュ

ハッシュベースの分散アルゴリズム - 5 タプル ハッシュ。ハッシュは、次の要素から作成されます。

- 接続元 IP : 要求元クライアントの IP アドレス。
- 接続元ポート : 要求元クライアントのポート。
- 接続先 IP : 要求の宛先 IP。
- 接続先ポート : 要求の宛先ポート。
- プロトコルの種類 :指定されたプロトコルの種類 (TCP または UDP)。

# 接続元IPアフィニティ


- 2 タプル ハッシュ (接続元 IP アドレスと接続先 IP アドレス) または 3 タプル ハッシュ (接続元 IP アドレス、接続先 IP アドレス、プロトコルの種類) が使用されます。 
- ハッシュによって、特定のクライアントからの要求が、ロード バランサーの背後にある同じ仮想マシンに、常に確実に送信されます

# 正常性プローブの動作

- バックエンド プール内の VM に対して指定されているポートに、定期的に ping メッセージが送信されます。
- ping メッセージに HTTP 200 (OK) メッセージで応答するサービスを VM 上で提供します。
- 指定された試行回数の後に VM が応答に失敗した場合、Load Balancer はそれが正常ではないと想定し、ユーザーの要求を受け入れることができる VM の一覧から削除します。 
- その後、ワークロードは残りの正常な VM 間に分散されます。 Load Balancer では、応答しない VM に対しても引き続き ping が送信されます。
- 応答を開始した VM は、正常な VM の一覧に再び追加され、ユーザー要求の受信を開始します。
- 正常性プローブを使用しないと、Load Balancer では VM が正常かどうかを判断できません。 代わりに、すべての VM が応答するものと想定します。

# VNetとの関係

LB自体はVNetに結びつかない。

バックエンドプールを作る際に、VNetを指定する。

# バックエンドプール



# [アプリケーションの独立と透過性](https://docs.microsoft.com/ja-jp/azure/load-balancer/concepts#floating-ip)

Load Balancer は、TCP、UDP、またはアプリケーション レイヤーと直接やり取りしません。

Load Balancer がフローを終了または開始したり、フローのペイロードと対話したりすることはなく、 アプリケーション レイヤーのゲートウェイ機能を提供することもありません。 

プロトコル ハンドシェイクは、常にクライアントとバックエンド プール インスタンスの間で直接発生します。 

受信フローへの応答は常に、仮想マシンからの応答です。

 仮想マシンにフローが到着するときは、元のソース IP アドレスも保持されます。

すべてのエンドポイントは、VM によって応答されます。 

# リージョン間ロードバランサー(プレビュー 2020/9/22～)

クロスリージョンの負荷分散を行うLB。

サービスが複数の Azure リージョンにわたってグローバルに利用可能になります。 

1 つのリージョンで障害が発生した場合、トラフィックは次の最も近い正常なリージョンのロード バランサーにルーティングされます。

リージョン間LB → 各リージョンの（複数の）LB → バックエンドVM

マニュアル：https://docs.microsoft.com/ja-jp/azure/load-balancer/cross-region-overview#home-regions

登場時のブログ：https://azure.microsoft.com/ja-jp/updates/preview-azure-load-balancer-now-supports-crossregion-load-balancing/

チュートリアル：https://docs.microsoft.com/ja-jp/azure/load-balancer/tutorial-cross-region-portal


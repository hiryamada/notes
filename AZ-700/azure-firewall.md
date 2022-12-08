
https://docs.microsoft.com/ja-jp/azure/firewall/policy-rule-sets

https://docs.microsoft.com/ja-jp/azure/firewall/rule-processing


■脅威インテリジェンス

脅威インテリジェンス ベースのフィルタリングを有効にして、悪意のある既知の IP アドレスおよびドメインとの間のトラフィックをファイアウォールによって警告およびブロックできます。IP アドレスとドメインの情報は Microsoft 脅威インテリジェンス フィードから取得されます。

https://docs.microsoft.com/ja-jp/azure/firewall/rule-processing#threat-intelligence

脅威インテリジェンスを利用したフィルターを有効にすると、それらのルールは優先度が最高になり、常に最初に (ネットワークルール および アプリケーションルールより先に) 処理されます。

構成したルールが処理される前に、脅威インテリジェンス フィルターによってトラフィックが拒否されることがあります

https://docs.microsoft.com/ja-jp/azure/firewall/threat-intel

ルールがトリガーされるときのアラートのみを記録するかどうかと、アラートおよび拒否モードを選択できます。既定では、脅威インテリジェンスベースのフィルター処理は、アラート モードで有効

Firewall Manager＞ファイアウォールポリシー＞脅威インテリジェンス モード: 「無効」「警告のみ」「警告して拒否」


■送信接続

https://docs.microsoft.com/ja-jp/azure/firewall/rule-processing#outbound-connectivity


優先度:

- 脅威インテリジェンス フィルター
- ネットワーク ルール
- アプリケーション ルール

ネットワーク ルールへの一致が見つかった場合は、他のルールの処理を行わない。

ネットワーク ルールへの一致がなく、プロトコルに HTTP、HTTPS または MSSQL を使用している場合は、その後で、アプリケーション ルールにより、優先度順で、パケットを評価

アプリケーション ルールで一致が見つからない場合は、パケットをインフラストラクチャ ルール コレクション と照合.

インフラストラクチャ FQDN 用の組み込みのルール コレクション: 
https://docs.microsoft.com/ja-jp/azure/firewall/infrastructure-fqdns

それでも一致するものがない場合、パケットは既定で拒否される。

■受信接続

https://docs.microsoft.com/ja-jp/azure/firewall/rule-processing#inbound-connectivity

優先度:

- 脅威インテリジェンス フィルター
- DNAT ルール
- ネットワーク ルール

DNAT ルールは、ネットワーク ルールよりも優先的に適用される。

一致が見つかると、変換されたトラフィックを許可する暗黙的な対応するネットワーク ルールが追加される。

※アプリケーションルールは、受信接続には適用できない。受信トラフィックをフィルタリングする場合は、Azure WAFを利用する。https://docs.microsoft.com/ja-jp/azure/web-application-firewall/overview

■ファイアウォール ポリシー

- リソースグループ
- 場所（リージョン）
- ポリシー名
- ポリシーレベル (Premium / )
- TLS検査 - 無効
- IDPSモード - Off

■ロール

ファイアウォール ポリシーのスコープでロールを割り当てることができる。

※Azure Firwallに特化したRBACの組み込みロールは存在しないもよう。カスタムロールを定義して対応する。https://techcommunity.microsoft.com/t5/azure-network-security-blog/role-based-access-control-for-azure-firewall/ba-p/2245598


■親ポリシー

ポリシーでは、選択した親ポリシーからルールとその他の設定を継承します。

継承されたルールは、子ポリシー内で定義されているのと同じ種類のルールより先に評価されます。

```
親ポリシー - ルール1
└子ポリシー - ルール2 (ルール1を先に評価)
```

■ルールコレクショングループ

ルールコレクション グループには、さまざまな種類のルールコレクションを含めることができます。

- 名前
- 優先度 (100-65000)

■デフォルトのルールコレクショングループ

デフォルトのルールコレクショングループが3つ存在する。

- DefaultDnatRuleCollectionGroup - 優先度 100
- DefaultNetworkRuleCollectionGroup - 優先度 200
- DefaultApplicationRuleCollectionGroup - 優先度 300

※DNAT = 宛先ネットワークアドレス変換

既定のルール コレクション グループを削除したり、優先度の値を変更したりすることはできない。

■ルールコレクション

※「ルール コレクション」とも

ルールコレクションは、種類、DNAT、ネットワーク、アプリケーションルールが同じであるルールのセットです。


ルールコレクショングループ
└ルールコレクション
  └ルール

- 名前
- ルールコレクションの種類 (ネットワーク、アプリケーション、DNAT）
- ルールコレクションアクション（許可、拒否）
- ルールコレクショングループ

※「ルールコレクションの種類」を選ぶと、対応する「デフォルトのルールコレクショングループ」が選択される。

※ルールがないルールコレクションを作ることもできる。


■ルール

- DNATルール
- ネットワークルール
- アプリケーションルール


■DNATルール

https://docs.microsoft.com/ja-jp/azure/firewall/tutorial-firewall-dnat

ファイアウォールのパブリック IP アドレスおよびポートをプライベート IP アドレスおよびポートに変換

■ネットワークルール

■アプリケーションルール

- 名前
- ソースタイプ - IPアドレス / IPグループ
- ソースIPアドレス
- 宛先IPアドレス
- 宛先タイプ - FQDN / FQDNタグ / Webカテゴリ / URL
- ターゲットFQDN
- TLS検査
- プロトコル

※IPグループ: Azure Firewall ルールの IP アドレスをグループ化して管理

https://docs.microsoft.com/ja-jp/azure/firewall/ip-groups


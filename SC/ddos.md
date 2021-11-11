# DDoS


■DDoS攻撃の種類

[分散型サービス拒否攻撃](https://docs.microsoft.com/ja-jp/learn/modules/describe-basic-security-capabilities-azure/3-describe-azure-ddos-protection)

- プロトコル攻撃 protocol attack
  - レイヤー 3 (ネットワーク) およびレイヤー 4 (トランスポート) プロトコルの弱点を悪用する
  - ターゲットサーバーを圧倒する（overwhelm、「[抵抗すら出来ないような力や数で対象を飲み込み何も出来なくさせてしまう](https://osanpo-english.com/illust/w_overwhelm.html)」）
  - 偽のプロトコル要求でサーバーのリソースが消耗され、ターゲットがアクセス不可能な状態になる
  - 通常、1 秒あたりのパケット数で測定される
- 帯域幅消費型攻撃 volumetric attack
  - ネットワークを「一見正当な」（seemingly legitimate）トラフィックであふれさせる
  - 使用可能な帯域幅を過剰に消費するボリューム ベースの攻撃
  - 正当なトラフィックが通過できなくなる
  - 通常、1 秒あたりのビット数で測定される
- リソース (アプリケーション) レイヤー攻撃 resource (application) layer attack
  - Web アプリケーションをターゲットにする。


■Azure DDoS Protection Basic/Standard

- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/ddos-protection/ddos-protection-overview)
- Microsoft Learn: [Azure DDoS Protection の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-azure-ddos-protection/)

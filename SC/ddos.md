# DDoS


■DDoS攻撃の種類

[分散型サービス拒否攻撃](https://docs.microsoft.com/ja-jp/learn/modules/describe-basic-security-capabilities-azure/3-describe-azure-ddos-protection)

- 帯域幅消費型攻撃 volumetric attack
  - ネットワークを一見正当なトラフィックであふれさせる
  - 使用可能な帯域幅を過剰に消費するボリューム ベースの攻撃
  - 正当なトラフィックが通過できなくなる
  - 通常、1 秒あたりのビット数で測定される
- プロトコル攻撃 protocol attack
  - レイヤー 3 (ネットワーク) およびレイヤー 4 (トランスポート) プロトコルの弱点を悪用する
  - 偽のプロトコル要求でサーバーのリソースが消耗され、ターゲットがアクセス不可能な状態になる
  - 通常、1 秒あたりのパケット数で測定される
- リソース (アプリケーション) レイヤー攻撃 resource (application) layer attack
  - Web アプリケーション パケットをターゲットにする。


■Microsoft Learn

[Azure DDoS Protection の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-azure-ddos-protection/)

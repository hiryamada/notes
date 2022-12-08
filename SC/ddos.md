# DDoS攻撃

■DoS攻撃とは？

https://ja.wikipedia.org/wiki/DoS%E6%94%BB%E6%92%83
サービスを稼働しているサーバに、意図的に過剰な負荷をかけたり、脆弱性をついたりする事で、サービスを妨害する攻撃。

■DDoS攻撃（Distributed Denial-of-service attack）とは？

https://ja.wikipedia.org/wiki/DoS%E6%94%BB%E6%92%83#DDoS%E6%94%BB%E6%92%83

> 分散DoS攻撃。1つのサービスに、大量のマシンから、一斉にDoS攻撃を仕掛ける。

https://web-material3.yokogawa.com/19/13304/tabs/rd-tr-r04504-003.jp.pdf

> 攻撃者は，まずセキュリティの弱いサイトを見付け（踏み台），これらに不正侵入して攻撃ソフトを潜ませておく。

> 攻撃者からの合図で，それらのサイトは一斉にターゲットサイトに対して大量の要求を送り攻撃を実行する

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


■Azure で、DDoS攻撃を軽減するには

https://docs.microsoft.com/ja-jp/azure/architecture/framework/security/design-network-endpoints#mitigate-ddos-attacks

- インフラレベルの保護
  - Azureインフラストラクチャに組み込み済み
- ネットワークレイヤーでの保護
  - [仮想ネットワークで、DDoS保護を有効にする](https://learn.microsoft.com/ja-jp/azure/ddos-protection/manage-ddos-protection#enable-ddos-protection-for-an-existing-virtual-network)
- キャッシュによる DDoS 保護
  - Azure CDNを使用（独自の DDoS 軽減プラットフォームで保護されている）
- 高度な DDoS 保護
  - Azure DDoS Protectionを利用
    - DDoS 攻撃を可視化
    - DDoS 攻撃によって発生したリソース コストに対するサービス クレジットを受け取る

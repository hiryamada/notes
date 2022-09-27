# DDoS（Denial-of-service attack）保護

■DoS攻撃とは？

https://ja.wikipedia.org/wiki/DoS%E6%94%BB%E6%92%83
サービスを稼働しているサーバに、意図的に過剰な負荷をかけたり、脆弱性をついたりする事で、サービスを妨害する攻撃。

■DDoS攻撃（Distributed Denial-of-service attack）とは？

https://ja.wikipedia.org/wiki/DoS%E6%94%BB%E6%92%83#DDoS%E6%94%BB%E6%92%83
分散DoS攻撃。1つのサービスに、大量のマシンから、一斉にDoS攻撃を仕掛ける。

■Azure で、DDoS攻撃を軽減するには
https://docs.microsoft.com/ja-jp/azure/architecture/framework/security/design-network-endpoints#mitigate-ddos-attacks

■DDoS対策のためのサービス

Azure DDoS Protection
https://azure.microsoft.com/ja-jp/services/ddos-protection/

ドキュメント(Azure DDoS Protection Standard)
https://docs.microsoft.com/ja-jp/azure/ddos-protection/ddos-protection-overview

登場時のブログ
https://docs.microsoft.com/ja-jp/archive/blogs/jpitpro/azure-ddos-protection-for-virtual-networks-generally-available

サービスのレベル: BasicとStandard

- いずれもネットワーク攻撃 (レイヤー 3、4) からの保護機能が提供される
- Basic
  - すべての Azure サービスが保護される。
  - デフォルトで有効
  - 追加コストなし
- Standard
  - オプション
  - 仮想ネットワーク上のリソース（パブリック IP アドレスが付与されたリソース）の保護
  - 1 か月あたり $2,944 の固定月額料金
  - リソースごとに1 か月あたり $30 の追加料金
  - 最大 100 のパブリック IP アドレスに対応
  - 1つのテナントで、複数のサブスクリプションに対して 1 つの DDoS 保護プランを使用できるため、複数の DDoS 保護プランを作成する必要はありません。

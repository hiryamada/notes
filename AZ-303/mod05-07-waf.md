# Web アプリケーション ファイアウォール (WAF)

一般的な悪用や脆弱性から Web アプリケーションを一元的に保護

https://docs.microsoft.com/ja-jp/azure/web-application-firewall/overview


■WAFと統合されたサービス

以下のサービスと組み合わせて使用することができる。
- [Azure Application Gateway](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/ag-overview)
- [Azure Front Door](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/afds/afds-overview)
- [Azure Content Delivery Network (CDN)](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/cdn/cdn-overview)

■WAFによる保護(Application Gateway)

https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/ag-overview

- SQLインジェクション攻撃
- クロスサイトスクリプティング攻撃
- コマンドインジェクション
- HTTP 要求スマグリング
- HTTP レスポンス スプリッティング
- リモート ファイル インクルード
- など

OWASP (Open Web Application Security Project) の[コア ルール セット (CRS)](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/application-gateway-crs-rulegroups-rules?tabs=owasp31#core-rule-sets)に準拠。

※OWASP

https://owasp.org/www-chapter-japan/

> OWASP - Open Web Application Security Project とは、Webをはじめとするソフトウェアのセキュリティ環境の現状、またセキュアなソフトウェア開発を促進する技術・プロセスに関する情報共有と普及啓発を目的としたプロフェッショナルの集まる、オープンソース・ソフトウェアコミュニティです。The OWASP Foundationは、NPO団体として全世界のOWASPの活動を支えています。


■WAFの有効化手順(Application Gatewayでの例)

https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/application-gateway-web-application-firewall-portal

- Application Gatewayを作成
  - SKU: WAF v2
  - [「WAFポリシー」を作成](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/application-gateway-web-application-firewall-portal#create-and-link-a-web-application-firewall-policy)
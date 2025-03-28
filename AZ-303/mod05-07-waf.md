# Web アプリケーション ファイアウォール (WAF)

一般的な悪用や脆弱性から Web アプリケーションを一元的に保護

製品ページ https://azure.microsoft.com/ja-jp/products/web-application-firewall/

ドキュメント https://learn.microsoft.com/ja-jp/azure/web-application-firewall/overview

価格 https://azure.microsoft.com/ja-jp/pricing/details/web-application-firewall/

価格は利用するサービスの種類とデータを処理する量などによって変動。


■WAFと統合されたサービス

以下のサービスと組み合わせて使用することができる。
- [Azure Application Gateway](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/ag-overview)
- [Azure Front Door](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/afds/afds-overview)
- [Azure Content Delivery Network (CDN)](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/cdn/cdn-overview)

※[Azure の負荷分散サービスの解説PDF](../AZ-104-2023/pdf/Azureの負荷分散サービスまとめ.pdf)

※[Azure CDNの解説PDF](../AZ-204/pdf/mod13/Azure%20CDNまとめ.pdf)

■WAFによる保護(Application Gateway)

https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/ag-overview

- [SQLインジェクション攻撃](https://www.kagoya.jp/howto/network/sql-injection/)
  - [XKCD](http://www.aoky.net/articles/randall_munroe/exploits_of_a_mom.htm)
- [クロスサイトスクリプティング攻撃](https://www.kagoya.jp/howto/network/xss/)
- [コマンドインジェクション](https://www.shadan-kun.com/blog/measure/2873/)
- [HTTP 要求スマグリング(Smuggling)](https://yamory.io/blog/about-http-request-smuggling/)
- [HTTP レスポンス スプリッティング](https://www.techmatrix.co.jp/product/jtest/security/httpresponsesplitting.html)
- [リモート ファイル インクルード](https://www.shadan-kun.com/blog/measure/2582/)
- など

OWASP (Open Web Application Security Project) の[コア ルール セット (CRS)](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/application-gateway-crs-rulegroups-rules?tabs=owasp31#core-rule-sets)に基づいて定義されている規則が使用される。

※OWASP

https://owasp.org/www-chapter-japan/

> OWASP - Open Web Application Security Project とは、Webをはじめとするソフトウェアのセキュリティ環境の現状、またセキュアなソフトウェア開発を促進する技術・プロセスに関する情報共有と普及啓発を目的としたプロフェッショナルの集まる、オープンソース・ソフトウェアコミュニティです。The OWASP Foundationは、NPO団体として全世界のOWASPの活動を支えています。


■WAFの有効化手順(Application Gatewayでの例)

https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/application-gateway-web-application-firewall-portal

- Application Gatewayを作成
  - SKU: WAF v2
  - [「WAFポリシー」を作成](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/ag/application-gateway-web-application-firewall-portal#create-and-link-a-web-application-firewall-policy)
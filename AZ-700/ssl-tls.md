# SSL/TLS

■SSL(Secure Socket Layer)とは？

- https://www.soumu.go.jp/main_sosiki/joho_tsusin/security/basic/structure/03.html
  - SSL（Secure Socket Layer）とは、インターネット上でデータを暗号化して送受信する仕組みのひとつです。
  - クレジットカード番号や、一般に秘匿すべきとされる個人に関する情報を取り扱うWebサイトで、これらの情報が盗み取られるのを防止するため、広く利用されています。
  - SSLは暗号化に加え、電子証明書により通信相手の本人性を証明し、なりすましを防止するなど、今日のインターネットの安心・安全を支えています。
  - SSLは、WebサーバとWebブラウザとの通信においてやりとりされるデータの暗号化を実現する技術です。たとえば、インターネットバンキングで利用者登録する場合などは、このSSLを使ったホームページが使われます。ここで入力された情報は暗号化され、金融機関のWebサーバに送られるのです。これにより、通信の途中で情報が盗み見られることを防いでいます。
  - Webブラウザにより、SSLを使ったサイトに接続するには、`http://･･･` で始まるアドレスではなく、`https://･･･` で始まるアドレスのサイトに接続します。SSLを利用したサイトに接続すると、アドレスバーの色が緑色に変わったり錠のマークが表示されたりします。これらにより、SSL通信を使っているサイトかどうかを確認することができます。

■SSLサーバ証明書とは？

- https://www.infraexpert.com/study/sslserver1.html
  - SSLサーバ証明書とは「SSLによる暗号化通信」と「Webサイトの運営者の身元証明」の2つの機能をあわせ持つ電子証明書のこと
  - 発行された電子証明書はWebサーバにインストールして利用する
- https://www.infraexpert.com/study/sslserver2.html
  - SSLサーバ証明書はロードバランサにインストールして、ロードバランサがSSLサーバとしてSSL通信を終端させることも可能

■TLS(Transport Layer Security)とは？

- https://www.idcf.jp/rentalserver/aossl/basic/ssl-tls/
  - (SSLについて)最初は「SSL 1.0」という形で開発され、さらに改良後「SSL 2.0」として登場しました。その後、重大な脆弱性が見つかり、バージョンアップされていき現在に至ります(SSL 3.0)
  - このバージョンアップの過程の中で、SSLは根本から設計を見直す必要がありました。
  - 現在、通称としてSSLと呼ばれているものは、SSLに変わる新しい仕組みの『TLS（Transport Layer Security）』というものになっています。
  - 『TLS』はSSLの次世代規格です。
- https://ja.wikipedia.org/wiki/Transport_Layer_Security
  - 2015年6月、RFC 7568によってSSL 3.0の使用は禁止された。
  - SSLについては、使うべきではない。
  - 2022年現在の最新版はTLS 1.3である
  - 特にHTTPでの利用を意識して設計されているが、アプリケーション層の特定のプロトコルには依存せず、様々なアプリケーションにおいて使われている。
  - TLS通信は、平文での通信に比べて（主に暗号化・復号時）余分な計算機能力を使用する

■Azureの負荷分散サービスでのTLS対応

- https://learn.microsoft.com/ja-jp/azure/application-gateway/ssl-overview
  - Application Gateway では、TLS 終端とエンド ツー エンド TLS 暗号化の両方がサポートされています。
- https://learn.microsoft.com/ja-jp/azure/frontdoor/end-to-end-tls
  - Azure Front Door (AFD) では、エンド ツー エンド TLS 暗号化がサポートされています。
  - エッジ(クライアントに最も近いエッジ ロケーション)で TLS セッションをオフロードし、クライアント要求を復号化します。 次に、構成済みのルーティング規則を適用して、バックエンド プール内の適切なバックエンドに要求をルーティングします。 その後、バックエンドへの新しい TLS 接続が開始され、バックエンドに要求を送信する前に、バックエンドの証明書を使用してすべてのデータが再暗号化されます。

■エッジロケーションとは？

https://learn.microsoft.com/ja-jp/azure/frontdoor/edge-locations-by-region

現在 Azure Front Door では、100 の主要都市に 118 のエッジ ロケーションを設けています。

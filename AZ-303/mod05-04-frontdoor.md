# Azure Front Door

https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-overview

レイヤー 7 (HTTP/HTTPS 層) で動作する、スケーラブルなグローバル エントリ ポイント。Webアプリケーションへのグローバル接続の性能を向上させることができる。動的 Web アプリと静的コンテンツを構築、運用、スケールアウト。

※「Front Door フロント ドア」: 正面玄関

```
エンドユーザー（Webブラウザ等）
↓ 
Azure Front Door（世界中のエッジロケーション）example.azurefd.net
↓ 
バックエンド（Webサーバー等、静的/動的コンテンツをホスト）
```

■参考: Azure Front Doorが性能を向上させる仕組み

Front Door は、**スプリット TCP** と、 Microsoft のグローバル ネットワークで**エニーキャスト プロトコル**を使用してグローバル接続を向上させる。

■参考: スプリットTCP

- ラウンドトリップの遅延が大きいTCPの問題を解決するしくみ
  - 特に、通信衛星を経由したTCP通信など
- エンドツーエンド接続を複数の小さい接続に分割する
- 分割はPEP(Performance Enhancing Proxy)が行う
  - エンド→PEP1→通信衛星→PEP2→エンド
  - PEP1とPEP2の間は独自のプロトコルを使うこともできる
- エンドシステムは、PEPがあることを意識する必要はない

参考
- Wikipedia https://en.wikipedia.org/wiki/Performance-enhancing_proxy
- RFC 3135 https://datatracker.ietf.org/doc/html/rfc3135#section-2.4
- Google画像検索(sattelite PEP) https://www.google.com/search?q=satellite+pep

Front DoorにおけるスプリットTCP では、TCP通信を2つの接続（「短い接続」と「長い接続」）に分割する。

https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-routing-architecture#splittcp

```
エンドユーザー
↓↑ ... 「短い接続」
Front Door環境
↓↑ ... 「長い接続」: 事前に確立し、他のエンドユーザーの要求間で再利用
アプリケーション バックエンド
```

■参考: エニーキャスト プロトコル

https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-routing-architecture#anycast

- エンド ユーザーのリクエストを、最も少ないネットワーク ホップで、最も近いAzure Front Door 環境（エッジロケーション）に誘導。
- Azure Front Door 環境にルーティングされるトラフィックでは、DNSトラフィックでも HTTPトラフィックでもエニーキャストが使用される

参考:
- https://ja.wikipedia.org/wiki/%E3%82%A8%E3%83%8B%E3%83%BC%E3%82%AD%E3%83%A3%E3%82%B9%E3%83%88




■2種類のAzure Front Door

(現行の)Azure Front Door
- ドキュメント: 
  - https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-overview
- プレビュー: 2018/9
  - https://azure.microsoft.com/ja-jp/blog/announcing-public-preview-of-azure-front-door-service/
  - https://azure.microsoft.com/ja-jp/updates/azure-front-door-service-in-public-preview/
- 一般提供開始: 2019/4
  - https://azure.microsoft.com/en-us/blog/azure-front-door-service-is-now-generally-available/

Azure Front Door Standard / Premium (プレビュー)
- ドキュメント:
  - https://docs.microsoft.com/ja-jp/azure/frontdoor/standard-premium/overview
- プレビュー: 2021/2 
  - https://azure.microsoft.com/en-us/updates/azure-front-door-standard-and-premium-now-in-public-preview/

**本コースでは「(現行の)Azure Front Door」について解説。**

■特徴

- レイヤー 7 (HTTP/HTTPS 層) で動作
- 動的 Web アプリと静的コンテンツを構築、運用、スケールアウトできる
  - 「スプリット TCP」: 
    - TCPのラウンドトリップの遅延を改善
  - 「エニーキャスト プロトコル」
    - リクエストを、最も少ないネットワーク ホップで、最も近いFront Door環境へ誘導
- 4種類のルーティング方法をサポート（全部組み合わせて使用）
  - 優先順位, 待機時間(最低遅延), 重み付け(荷重), セッション アフィニティ
- バックエンドは、Azure の内部または外部でホストされている、インターネットに公開されたサービス
- バックエンドの正常性監視が可能（正常性プローブ）
- URLパスベースルーティング: リクエストのパスにより、複数のバックエンドプールのうち1つを選択。
- カスタム ドメイン
- セッション アフィニティ
- SSLオフロード
- WAF(Webアプリケーションファイアウォール)
- URLリダイレクト
- URL書き換え

■シナリオ

Azure Front Doorのドメイン名（example.azurefd.net）を使用して、バックエンド www.example.com に接続する場合

(DNS)
- Webブラウザー: もしもし、example.azurefd.net に接続したいのですが
- Azure Front DoorのDNSサーバー: はい、example.azurefd.net の IPアドレス はこちらです

(HTTP)
- Webブラウザー: （そのIPアドレスに接続）
- （リクエストはエッジロケーションに送信される）
- Webブラウザー: もしもし、example.azurefd.net さんでしょうか？ トップページを送信してください (GET / HTTP/1.1 Host: example.azurefd.net)

(HTTP)
- エッジロケーションのサーバー: もしもし、www.example.com さんでしょうか？ トップページを送信してください(GET / HTTP/1.1 Host: www.example.com)
- Webサーバー: はい、そうです。トップページはこちらです(200 OK)
- （エッジロケーションのサーバーは、そのレスポンスを受信し、Webブラウザーに返す）

■Azure Front Doorの作成

Azure portalで「フロント ドア」で検索

- フロントエンド ホスト
  - ホスト名を指定する 例: example
    - example.azurefd.net
- バックエンド プール: バックエンドの集まり
  - 名前
  - バックエンド
    - 種類
      - App Service
      - Storage
      - Application Gateway
      - API Management
      - パブリックIPアドレス
      - Traffic Manager
      - カスタム ホスト(IPアドレスまたはFQDN)
  - 正常性プローブ
    - パス
    - プロトコル: HTTP/HTTPS
    - プローブメソッド: GET/HEAD
    - 間隔: 30秒 など
    - 待機時間感度: 0-1000ミリ秒で指定。デフォルト: 0
- ルーティング規則
  - 名前
  - 受け入れるプロトコル: HTTP/HTTPS/両方
  - パスのパターン: /* や /users/* など
  - フロントエンド
  - バックエンド プール
  - 転送プロトコル: HTTP/HTTPS/一致要求
  - 静的なコンテンツのキャッシュ: 有効/無効 デフォルトは無効

※Front Doorリソース作成後は、「Front Doorデザイナー」で確認・編集ができる

※Front Doorのトップページ（概要）の、Front Doorのフロントエンドホストのリンクは、上記の設定にかかわらず「https://～～.azurefd.net」になっているので注意！ （必要に応じて https を http にする）

```
Webブラウザ等
↓ HTTP/HTTPS
フロントエンド(example.azurefd.net)
↓ ルーティング規則(プロトコルとパス等でバックエンドプールを選択)
バックエンドプール(複数のバックエンドが含まれる)
↓ バックエンドの選択手順（後述）に従いバックエンドを選択
バックエンド(App Service等)
```

■ルーティング方法

https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-routing-methods

バックエンドの選択手順: 
Front Doorでは、以下のようにしてバックエンドが選択される。

1. 正常性プローブに成功したバックエンドを選択
2. 優先度の高いバックエンドを選択
3. 待機時間が、指定された「待機時間感度」よりも短いバックエンドを選択
4. 重みの比率に従ってラウンドロビンで分散

ルーティングの設定:

- 優先順位
  - 各バックエンドに「優先度」（1～5）を設定
  - 値が小さいほど優先度が高い
  - 複数のバックエンドに同じ優先度を設定することもできる
- 待機時間(最低遅延)
  - ネットワーク待機が最も短い（最も近い）バックエンドのセットに誘導
  - 正常性プローブの結果が使われる
- 重み付け(荷重)
  - 各バックエンドに「重み」（1～1000）を設定
  - 重みの比率で、ラウンドロビンで分散。
  - 例: バックエンド1が重み1、バックエンド2が重み2と設定した場合
    - 1,2,2,1,2,2, ... のようになる
- セッション アフィニティ
  - 無効: 同じクライアントからのリクエストを異なるバックエンドに転送することがある
  - 有効: 同じクライアントからのリクエストは、最初にリクエストを処理したバックエンドに転送しつづける。Cookieを使用。


■正常性プローブ

Front Door は、構成された各バックエンドに定期的な HTTP/HTTPS プローブ要求を送信して各バックエンドの近接性と正常性を判断する。

バックエンドプールに対して設定。

- 状態: 無効/有効
- パス: / など
- プロトコル: HTTP / HTTPS
- プローブメソッド: GET / HEAD
- 間隔: 5 秒 など


■キャッシュの消去

- Front Doorにキャッシュされたコンテンツを削除（グローバルレベル）
- 削除方法
  - パスを指定して、パスに該当するコンテンツのみ削除
  - すべて

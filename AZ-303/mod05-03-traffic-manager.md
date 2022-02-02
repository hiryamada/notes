# Azure Traffic Manager

https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview

- DNS ベースのロード バランサー
- パブリックに公開されているアプリケーションへのトラフィックをルーティングする

■Traffic Manager概要

- DNS 応答を送信して、クライアント(Webブラウザ等)を適切なサービス エンドポイント(Webサーバー等)に転送
- クライアント(Webブラウザ等)はサービス エンドポイント(Webサーバー等)に、Traffic Manager 経由ではなく、直接接続する
- Traffic Manager 自身のIP アドレスは提供されない
- Traffic Manager は、クライアントとサーバーの間の HTTP トラフィックを認識しない

例:

- クライアント: example.trafficmanager.net の名前解決を行う
- Traffic Manager: example.trafficmanager.net に対応するIPアドレスを返す
- クライアント: IPアドレスにリクエストを送信する

■シナリオ(1): クライアントが example.trafficmanager.net に接続する場合

(DNS)
- クライアント: もしもし、example.trafficmanager.net に接続したいのですが
- Traffic Manager: はい、example.trafficmanager.net のIPアドレスはこちらです

(HTTP)
- クライアント: （そのIPアドレスに接続）
- クライアント: もしもし、example.trafficmanager.net さんでしょうか？ トップページを送信してください (GET / HTTP/1.1 Host: example.trafficmanager.net)
- Webサーバー: はい、トップページはこちらです(200 OK)

※この場合、Webサーバーが、example.trafficmanager.net に対して応答するように設定する必要がある。

- https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-endpoint-types#web-apps-as-endpoints
- https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-faqs#why-am-i-seeing-an-http-error-when-using-traffic-manager

> 使用しているドメイン名の正しいホスト ヘッダーを受け入れるようにアプリケーションが構成されていることを確認します

■Traffic Managerに別のドメインを割り当てるには

https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-point-internet-domain

たとえば www.example.com で Traffic Managerのプロファイル example.trafficmanager.net に接続できるようにしたい場合は、www.example.com のDNSサーバー側で、Traffic Manager プロファイルへのCNAMEレコードを作成する。

```
www.example.com ドメイン
↓ CNAMEレコードに解決
example.trafficmanager.net
↓ Traffic ManagerがIPアドレスを返す
サービス エンドポイント(Webサーバー等)
```

■シナリオ(2): クライアントが www.example.com 経由で example.trafficmanager.net に接続する場合

(DNS)
- クライアント: もしもし、www.example.com に接続したいのですが 
- DNSサーバー: はい、www.example.com の CNAME は example.trafficmanager.net です

(DNS)
- クライアント: もしもし、example.trafficmanager.net に接続したいのですが 
- Traffic Manager: はい、example.trafficmanager.net の IPアドレス はこちらです

(HTTP)
- クライアント: （そのIPアドレスに接続）
- クライアント: もしもし、www.example.com さんでしょうか？ トップページを送信してください (GET / HTTP/1.1 Host: www.example.com)
- Webサーバー: はい、そうです。トップページはこちらです(200 OK)


■DNSのサービス（Azure DNS等）とは何が違うのか？

DNSのサービス:
- 任意のドメイン名をホストできる
- （基本的には）問い合わせに対して固定のIPアドレスを返す

Traffic Manager:
- カスタムのドメイン名はホストできない(～.trafficmanager.net だけをホストできる)
- 問い合わせに対してさまざまなIPアドレスを返すことができる（ルーティング）

■Traffic Managerプロファイル

Traffic Managerのリソース。

- 名前 
  - たとえば example と入力すると example.trafficmanager.net というDNS名がプロファイルに割り当てられる
- ルーティング方法（後述）
  - パフォーマンス
  - 重み付け
  - 優先度
  - 地域
  - 複数値
  - サブネット
- サブスクリプション
- リソース グループ

※「Traffic Manager プロファイル」はグローバルなリソースであり、リージョンに依存しない（特定のリージョンの障害の影響を受けない）。

■ルーティング

https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-routing-methods

構成＞ルーティング方法 で設定

- パフォーマンス
  - クライアントからネットワーク的に最も近いエンドポイントへ誘導
- 重み付け(荷重)
  - 各エンドポイントに「重み」（Weight）を設定（1～1000の整数）
  - 重みに基づいてエンドポイントをランダムに選択
- 優先度
  - 各エンドポイントに「優先度」を設定（1～1000の整数）
  - 数値が小さい方が優先度が高い
  - より優先度の高いエンドポイントへ誘導
  - エンドポイントのプローブ（ヘルスチェック）が失敗したら、次の優先度のエンドポイントへと誘導
- 地域（地理的）
  - 各エンドポイントに「geoマッピング」（複数可）を指定する
    - 例: リージョン「アジア」、国/地域「日本」
  - DNS クエリの発信元の地理的な場所に基づいてルーティングされる
- 複数値
  - DNS クエリに対し、複数のエンドポイントのIPアドレスを返す
    - 最大で10個まで、IPアドレスを返すことができる
  - すべてのエンドポイントが「外部」タイプで、IPアドレスである必要がある
  - どのIPアドレスを利用するかはクライアントが決定できる
- サブネット
  - 各エンドポイントに、DNS 要求 IP アドレスの送信元 IPの範囲を指定する
    - 範囲の指定の仕方
      - CIDR: 1.2.3.0/24
      - 開始～終了のIPアドレス: 1.2.3.4-5.6.7.8

■プローブ

- プロトコル: HTTP、HTTPS、TCPから選択可能
- デフォルト値
  - プロトコル: HTTP
  - パス: /
  - プローブ間隔: デフォルト 30秒
  - 障害の許容数: 3
  - プローブ タイムアウト: 10

■エンドポイントの種類

https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-endpoint-types

- [Azure エンドポイント](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-endpoint-types#azure-endpoints) : Azure でホストされるサービス
- [外部エンドポイント](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-endpoint-types#external-endpoints): Azure の外部でホストされるサービスの、IPv4/IPv6 アドレス や FQDN
- [入れ子になったエンドポイント](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-endpoint-types#nested-endpoints): Traffic Manager プロファイル

例1 Azureエンドポイント

```
example.trafficmanager.net
↓ 
Azure エンドポイント（App Service の Web App、Azure Load Balancer等）
```

例2 外部エンドポイント

```
example.trafficmanager.net
↓ 
Azure外でホストされているWebサーバー等
```

例3 入れ子になったエンドポイント

```
example1.trafficmanager.net
↓ 
example2.trafficmanager.net
↓ 
Azure エンドポイント / 外部エンドポイント
```

入れ子になったエンドポイントの説明と例:
https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-nested-profiles

■ハンズオン

以下の手順で、App Serviceを使用して、Webアプリを作成します。Traffic Managerのバックエンドとして使用します。

```
appname="app$RANDOM"
az appservice plan create -g rg1 -n plan1 --sku S1
az webapp create -g rg1 -p plan1 -n app$RANDOM --runtime 'DOTNET|6.0'
az webapp list --query '[].hostNames' --output tsv
```
表示されるホスト名にアクセスして、Webアプリが動作することを確認します。
（グラフィックとともに Hey, App Service developers! と表示されます）

以下の手順で、Traffic Managerを設定します。

```
画面上部の検索で「ロード」検索、ロードバランサーの画面へ移動します。

Traffic Managerをクリックします。

＋作成

名前: example(乱数) ※乱数はキーボードから数字を10桁ほど適当に打ち込んで生成
リソースグループ: rg1
作成

デプロイが完了するのを待ち、「リソースへ移動」をクリック
（または、一覧画面で「更新」をクリックして、作成されたプロファイルをクリック）

画面左「エンドポイント」をクリック
＋追加
種類: Azureエンドポイント
名前: webapp1
ターゲットリソースの種類: App Service
ターゲットリソース: (作成済みのApp Service Webアプリ名を選択)
追加

画面左「概要」をクリック
画面上部の「最新の情報を更新」をクリックして画面を更新。
画面下の「webapp1」の「モニターの状態」が、「エンドポイントを確認しています」から「オンライン」に変わるまで何度か更新する。(数分かかります)
「DNS名」をコピー

Webブラウザの新しいタブにてその「DNS名」にアクセスします。グラフィックとともに Hey, App Service developers! と表示されます。

```

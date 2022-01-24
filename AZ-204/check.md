知識チェックの解説

# App Service セクション1-モジュール1

https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-azure-app-service/8-knowledge-check

## 1. 次の App Service プランのうち、関数アプリのみをサポートしているのはどれですか?

App Service の「Webアプリ」や、Azure Functionの「関数アプリ」は、「プラン」の上で動きます。ただし、「プラン」にもいろいろな種類があり、組み合わせて使うことができるものとそうでないものがあります。

```
App Service(Webアプリ)用のプラン:
├Free, Shared: 「共有コンピューティング」とも。
├Basic, Standard, Premium: 「専用コンピューティング」とも。
└Isolated: 「分離」とも。
```
詳細: https://docs.microsoft.com/ja-jp/azure/app-service/overview-hosting-plans

```
Azure Functions(関数アプリ)用のプラン:
├従量課金プラン: 「使用量」や「消費」とも。関数が実行された分だけお支払い。
├Premium プラン: App ServiceのPremiumプランとは別もの。
└App Service プラン: 上記のApp Serviceプラン(Basic以上)の上で、関数アプリを実行
```
詳細: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale


したがって、選択肢の中で「関数アプリのみサポートしているもの」は、「従量課金プラン」となります。

## 2. 次の App Service のネットワーク機能のうち、送信 ネットワーク トラフィックを制御するために使用できるのはどれですか?

- アプリに割り当てられたIPアドレス
- ハイブリッド接続
- サービス エンドポイント

```
受信に使える機能（一部）
├アプリに割り当てられたIPアドレス: 「IPベースSSL」を有効化すると、アプリ用の新規IPアドレスが割り当てられる。
└サービスエンドポイント: Webアプリへのアクセスを、明示的な許可したVNet/サブネットからのアクセスに制限する。
```

```
送信に使える機能（一部）
└ハイブリッド接続: Webアプリから、オンプレミスのサーバー等に、VPNや専用線なしで、接続するための機能。
```

```
App Service Webアプリ
↓ハイブリッド接続
オンプレミス（のサーバ）
```

詳細: App Serviceのネットワーク機能
https://docs.microsoft.com/ja-jp/azure/app-service/networking-features

詳細: サービスエンドポイント
https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#access-restriction-rules-based-on-service-endpoints

詳細: アプリに割り当てられたIPアドレス（IPベースSSL）
- https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#app-assigned-address
- https://docs.microsoft.com/ja-jp/azure/app-service/configure-ssl-bindings#remap-records-for-ip-ssl
- https://tech-lab.sios.jp/archives/23123

詳細: ハイブリッド接続
https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#hybrid-connections

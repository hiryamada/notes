# モジュール12 適切なデプロイパターンの実装

- マイクロサービスとは。
- なぜマイクロサービス化するのか。
- 機能フラグ（フィーチャーフラグ）とは。
- ブルー・グリーン デプロイとは。
- カナリアリリース とは。
- ダーク ローンチ とは。
- A/Bテスト とは。
- プログレッシブ エクスポージャーデプロイ とは
- デプロイスロットとは
- Azure Traffic Manager
- Azure App Configuration
- Azure App Service


## デプロイ パターンの概要

### 継続的デリバリーと継続的デプロイの紹介

CI/CD、テスト、コードの品質管理などについてはここまでで解説済み。


■アーキテクチャ

機能単位でのCDを考えた場合:

- モノリス（多数の機能を含む、一枚岩の巨大な）アプリケーションでCDを実践するのは難しい。
- マイクロサービス化が望ましい。

### マイクロサービス アーキテクチャ

■マイクロサービスとは

自律的で、独立した、デプロイ可能で、スケーラブルなソフトウェアコンポーネント。

サービスそれぞれで、開発・テスト・デプロイができ、スケーリングもしやすい。

サービス同士はインターフェース（API）を介して接続し、非同期のメカニズム（キューやイベント）で通信を行う。

参考: [マイクロサービス アーキテクチャ スタイル](https://docs.microsoft.com/ja-jp/azure/architecture/guide/architecture-styles/microservices)

### 従来のデプロイパターン

開発、ステージング、本番環境など。

### モダンデプロイパターン

ブルー・グリーン、カナリアリリース、ダークローンチ、A/Bテスト、プログレッシブ エクスポージャーデプロイ、機能フラグ（フィーチャーフラグ）など。後半で詳しく解説。

## Blue Green デプロイの実装

### ブルーグリーン デプロイ

ブルー環境（運用）とグリーン環境（デプロイ用）を準備

グリーンにデプロイし、テスト

テストが完了したら、トラフィックをブルー環境からグリーン環境に切り替える。

ダウンタイムなしで切り替えを行うことができる。

問題が発生した場合は「切り戻し」も簡単にできる。

### デプロイ スロット


## 機能の切り替え

### フィーチャー トグルの概要 （機能フラグ）

※以下、コード例は[Razor構文](https://docs.microsoft.com/ja-jp/aspnet/core/mvc/views/razor?view=aspnetcore-5.0)による。「...」より上はコントローラのアクション内の処理、下はビュー。featureEnabled(), doSomething()は架空のメソッド。

```
result = doSomething();

...

<div>
  @result
</div>
```

↓ 機能フラグの導入

```
if (featureEnabled("x")) {
    result = doSomething();
}

... 

@if (featureEnabled("x"))
{
  <div>
    @result
  </div>
}

```


[Azure App Configuration](https://azure.microsoft.com/ja-jp/services/app-configuration/)は[2020/2/19に一般提供が開始](https://azure.microsoft.com/ja-jp/updates/azure-app-configuration-is-now-generally-available/)された。

[フィーチャートグル](https://ja.wikipedia.org/wiki/%E3%83%95%E3%82%A3%E3%83%BC%E3%83%81%E3%83%A3%E3%83%BC%E3%83%88%E3%82%B0%E3%83%AB)

- SaaSプラットフォームのためのフィーチャートグルとしては、[LaunchDarkly](https://launchdarkly.com/) が最も広く使われている。([Wikipedia](https://ja.wikipedia.org/wiki/%E3%83%95%E3%82%A3%E3%83%BC%E3%83%81%E3%83%A3%E3%83%BC%E3%83%88%E3%82%B0%E3%83%AB))

## 機能の切り替えメンテナンス

機能フラグの導入は、技術的負債につながる。

```
result = doSomething();

...

<div>
  @result
</div>
```

↓(1)機能フラグの導入 ↑(2)機能フラグの削除

```
if (featureEnabled("x")) {
    result = doSomething();
}

... 

@if (featureEnabled("x")) 
{
  <div>
    @result
  </div>
}
```

機能フラグの導入する際に、いつその機能フラグを削除するかを計画する。


## カナリア リリース

### カナリア リリース

[モジュール1](mod01.md)で解説済み。カナリア＝新機能にとても積極的なユーザー（または、開発者が選択した任意のユーザーグループ）。

カナリアに対して新機能をリリースして様子を見る。

カナリアリリースは、以下のものを使用して実装できる。

- 機能フラグ
  - App Configuration の [条件付き機能フラグ](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-feature-filters-aspnet-core)を利用して
  - 特定のグループ（＝カナリア）に対して新機能を ON にする
- トラフィックルーティング
  - [トラフィックマネージャー](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview) （DNSレベルのルーティング）を使用
  - 全トラフィックの N% を、新機能をデプロイしたサーバーに流し込む
    - 複数のエンドポイントに対し[重み付け](https://docs.microsoft.com/ja-jp/azure/traffic-manager/tutorial-traffic-manager-weighted-endpoint-routing)を行うことで実装
- デプロイスロット
  - App Serviceのデプロイスロットと、[トラフィックルーティング](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-staging-slots#route-traffic)を使用
  - 全トラフィックの N% を、新機能をデプロイした「デプロイスロット」に流し込む。

### Traffic Manager

[Azure Traffic Manager](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview)

DNSベースのグローバルロードバランサー。
[複数のルーティング方法](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-routing-methods)を提供。
- 優先順位
- 重み付け
- パフォーマンス
- 地理的
- 複数値
- サブネット - エンドユーザーのIPアドレスの範囲（CIDR等で指定）を、プロファイル内の特定のエンドポイントにマップ

## ダーク ローンチ

### ダーク ローンチ

- 新機能は新しいサーバーにローンチされる。
- ユーザーからのトラフィックをコピーして新機能のサーバー **にも** 送信し、処理させる。
- 新機能のサーバーからのレスポンスは **ユーザーに返さない** 。新機能の改善に役立てる。

クラウドサポートエンジニアの新人トレーニングがまさにこれ。

- 新人は新しいチームに配置される。
- お客様からのお問い合わせをコピーして新人 **にも** 送信し、回答させる。
- 新人からの回答は **お客様には返さない** 。チームの先輩がチェックして回答の品質の向上に役立てる。

参考
- Googleの[ドキュメント](https://cloud.google.com/blog/ja/products/gcp/cre-life-lessons-what-is-a-dark-launch-and-what-does-it-do-for-me)
- Martin Fowler氏の[ブログ](https://martinfowler.com/bliki/DarkLaunching.html)

※「ダークローンチ ＝ 機能フラグの利用」と解説するサイトも多いようだ

## A/B テスト

※デプロイパターンではない。

Webサイト等で、オリジナルバージョン（A）と、一部を変更したバージョン（B）を用意し、ユーザーをA/Bにランダムに誘導し、どちらがコンバージョン（商品の注文などの成果）が高いかを測定する。

## プログレッシブ エクスポージャーデプロイ

### デプロイ リング付きの CI/CD

カナリアリリースの発展版。

カナリア（内側のリング、少数）、アーリーアダプター、一般ユーザー（外側のリング、多数）、といった順で「リング」を設定。内側から外側のリングへと、新機能のデプロイを広げていくという考え方。

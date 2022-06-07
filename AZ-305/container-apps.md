# Azure Container Apps

「コンテナー化されたアプリ」を実行する、マネージドなサーバーレスコンテナーサービス

公式サイト
https://azure.microsoft.com/ja-jp/services/container-apps/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/container-apps/overview

価格
https://azure.microsoft.com/ja-jp/pricing/details/container-apps/

公式による解説
https://techcommunity.microsoft.com/t5/apps-on-azure-blog/introducing-azure-container-apps-a-serverless-container-service/ba-p/2867265?ocid=AID3042118

# 歴史

2021/11/2 パブリックプレビュー
https://azure.microsoft.com/ja-jp/updates/public-preview-azure-container-apps/

2022/5/24 一般提供開始
https://azure.microsoft.com/ja-jp/updates/generally-available-azure-container-apps/

# 報道記事

Microsoft、フルマネージドサーバレスコンテナ「Azure Container Apps」を一般提供
https://codezine.jp/article/detail/15991


# 特徴

■「コンテナー化されたアプリ」を実行するサービス

任意の言語を使用してアプリを開発できる。

■マネージド型

オーケストレーター（Kubernetes）、VMなどのインフラを管理する必要がない。

■Kubernetes

Azure Container Appsは、内部的には Kubernetes（Azure Kubernetes Service）上で動作する。

ただし、Kubernetesを管理する必要はない。（Kubernetesやコントロールプレーンに直接アクセスすることはできない。）

■オープンソースのテクノロジ

内部では、Dapr（マイクロサービス間通信）、KEDA（スケーラー）、Envoy（プロキシ）などのテクノロジが内部で利用されている。

→ [Daprの解説](container-apps-dapr.md)

→ [KEDAの解説](container-apps-keda.md)

→ [Envoyの解説](container-apps-envoy.md)

■Log Analytics ワークスペース

コンテナー アプリから収集されたデータ、標準出力 (stdout) または標準エラー (stderr)への出力は、Log Analytics ワークスペースへと書き込まれる。

https://docs.microsoft.com/ja-jp/azure/container-apps/monitor


# 用途

マイクロサービスの運用

[Azure Container Apps を使用したマイクロサービスのデプロイ](https://docs.microsoft.com/ja-jp/azure/architecture/example-scenario/serverless/microservices-with-container-apps)

# リソースの構成

```
Container Apps 環境 -> Log Analyticsワークスペース
└コンテナー アプリ
```

※Azure portalでは「コンテナー アプリ」を作成すると一緒に「Container Apps 環境」「Log Analyticsワークスペース」が作成される。

1つの「Container Apps 環境」で複数の「コンテナー アプリ」を動かすことができる。

```
Container Apps 環境 -> Log Analyticsワークスペース
├コンテナー アプリ1
└コンテナー アプリ2
```

# Container Apps 環境

https://docs.microsoft.com/ja-jp/azure/container-apps/environment

同じ環境内のコンテナー アプリは、同じ仮想ネットワークにデプロイされ、同じ Log Analytics ワークスペースにログを書き込む。

# HTTPSイングレス

https://docs.microsoft.com/ja-jp/azure/container-apps/ingress

イングレスを有効にすることで、コンテナー アプリにHTTPSでアクセスできる。アプリケーションには完全修飾ドメイン名 (FQDN) が割り当てられる。

※https://my-container-apps.ambitioussky-73f3e33c.japaneast.azurecontainerapps.io」のような形式になる。

# スケーリング

https://docs.microsoft.com/ja-jp/azure/container-apps/scale-app

Container Appsではスケーリング（インスタンスの増減）が行われる。インスタンスは「レプリカ」と呼ばれる。

[レプリカは、アプリのコンテナー（＋オプションのサイドカーのコンテナー）で構成される。](https://docs.microsoft.com/ja-jp/azure/architecture/example-scenario/serverless/microservices-with-container-apps)

※以下の図の「リビジョン」については後述。

```
Container Apps 環境
└コンテナーアプリ (名前: example)
  └リビジョン
    └レプリカ1
      └コンテナー

↓スケールアウト ↑スケールイン

Container Apps 環境
└コンテナーアプリ (名前: example)
  └リビジョン
    ├レプリカ1
    │└コンテナー
    └レプリカ2
      └コンテナー
```

レプリカの数は最小値と最大値を指定できる。デフォルトは「最小0～最大10」。

以下に基づくスケーリングが可能

- HTTPトラフィック
- イベント ドリブン
- CPU または メモリ

# 課金（料金）

https://docs.microsoft.com/ja-jp/azure/container-apps/environment#billing

課金は、個々のコンテナー アプリとそのリソース使用量にのみ関連する。

Container Apps 環境に関連付けられている基本料金はない。

# リビジョン

https://docs.microsoft.com/ja-jp/azure/container-apps/revisions

コンテナーアプリを作成すると最初の「リビジョン」が作成される。

```
Container Apps 環境
└コンテナーアプリ (名前: example)
  └リビジョン1 (コンテナイメージ: container1)
```

↓たとえば、コンテナーイメージの変更を行うと、新しい「リビジョン」が作られる。

```
Container Apps 環境
└コンテナーアプリ (名前: example)
  ├リビジョン1 (コンテナイメージ: container1)
  └リビジョン2 (コンテナイメージ: container2)
```

リビジョンの利用方法

- リビジョンの切り替え（切り戻し）ができる
- 「ブルーグリーンデプロイ」ができる
  - リビジョン2の準備ができたらトラフィックをリビジョン2に切り替える
- 「A/Bテスト」ができる
  - リビジョン1に90%, リビジョン2に10%のトラフィックを流す、など
  - この場合は複数のリビジョンを「アクティブ化」する

リビジョンは一度作られると変更できない。

リビジョンには「サフィックス」（接尾辞）を付けて区別できる。

```
Container Apps 環境
└コンテナーアプリ (名前: example)
  ├リビジョン1 (サフィックス:ver1)
  └リビジョン2 (サフィックス:ver2)
```

各リビジョンは「example--ver1」「example--ver2」といった「リビジョン名」となる。リビジョン名は「コンテナーアプリ名--サフィックス」となる。

# IDプロバイダーによる認証

Microsoft、Apple、Facebook、GitHub、Google、Twitter、OpenID Connectを使用したサインイン機能を追加できる。

Microsoftでサインインした場合はMicrosoft API呼び出し、Appleでサインインした場合はApple APIの呼び出し、・・・（以下同様 Facebook, Google, Twitter API）が可能となる。

# マネージドID

https://docs.microsoft.com/ja-jp/azure/container-apps/managed-identity

システム割り当て / ユーザー割り当て マネージドIDに対応。コンテナーアプリがその他のAzureサービスにアクセスする際に使用される。

# シークレット

https://docs.microsoft.com/ja-jp/azure/container-apps/manage-secrets

コンテナーアプリ独自のしくみ「シークレット」（キー・値）管理が利用できる。

# カスタム ドメイン

https://docs.microsoft.com/ja-jp/azure/container-apps/custom-domains-certificates

オプションで、アプリにカスタムドメインを割り当て可能。


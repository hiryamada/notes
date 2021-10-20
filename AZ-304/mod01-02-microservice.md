# マイクロサービス用の Azure コンピューティング オプションの選択


■マイクロサービスとは

https://docs.microsoft.com/ja-jp/azure/architecture/guide/architecture-styles/microservices

https://ja.wikipedia.org/wiki/%E3%83%9E%E3%82%A4%E3%82%AF%E3%83%AD%E3%82%B5%E3%83%BC%E3%83%93%E3%82%B9

- 小さなサービスのコレクション
- 各サービスは小規模な開発チームで作成、管理される
- 各サービスは1 つのビジネス機能を実装
- 各サービスは自律、自己完結型
- サービスは疎結合
  - 明確に定義された API を使用して、互いに通信
- ポリグロット
  - [意味: 多言語に通じた; 多言語を使う; 多言語を話す](https://ejje.weblio.jp/content/polyglot)
  - [ポリグロット プログラミング](https://www.google.com/search?q=Polyglot+Programming)
    - 各マイクロサービスは、異なる言語やフレームワークを使って実装すること **も** できる
    - https://en.wikipedia.org/wiki/Polyglot_(computing)
  - [ポリグロット パーシステンス](https://www.google.com/search?q=polyglot+persistence)
    - データの特性ごとに、適材適所で、データベースを使い分けること **も** できる
    - https://en.wikipedia.org/wiki/Polyglot_persistence

■Microsoft Learn 

マイクロサービスに関する学習モジュールが利用できる。

モノリシック アプリケーションをマイクロサービス アーキテクチャに分解する
https://docs.microsoft.com/ja-jp/learn/modules/microservices-architecture/

■マイクロサービスのための Azure コンピューティング オプション

```
Microsoft Docs
└Azureアーキテクチャ センター
 └アプリケーション アーキテクチャ ガイド
  └テクノロジの選択
   └マイクロサービス用の Azure コンピューティング オプションの選択
```

https://docs.microsoft.com/ja-jp/azure/architecture/microservices/design/compute-options

マイクロサービスを実装するためのAzureサービス。

マイクロサービスを実装するために、必ずしもコンテナーやKubernetesを使うとは限らない。サーバーレスのサービスを使用することもできる。

- サービス オーケストレーター
  - [AKS](https://docs.microsoft.com/ja-jp/azure/aks/intro-kubernetes)
  - [Service Fabric](https://docs.microsoft.com/ja-jp/azure/service-fabric/service-fabric-overview)
- コンテナー
  - [ACI](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview)
- サーバーレス、Function as a Service（FaaS）
  - [Azure Functions](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview)

■サービス オーケストレーターとは

https://docs.microsoft.com/ja-jp/azure/architecture/microservices/design/compute-options#service-orchestrators

- 一連のサービスのデプロイと管理に関連するタスクを処理するしくみ
  - ノードへのサービスの配置
  - サービスの正常性の監視
  - サービス インスタンス間へのネットワーク トラフィックの負荷分散
  - サービスの検出
  - サービスのインスタンスの数のスケーリング
  - 構成の更新の適用
  - など
- 一般的によく使われるサービス オーケストレーター
  - Kubernetes
  - Service Fabric
  - DC/OS
  - Docker Swarm
  - など

■サーバーレスとは

https://docs.microsoft.com/ja-jp/azure/architecture/microservices/design/compute-options#serverless-functions-as-a-service

サーバーレス アーキテクチャでは、ユーザーは VM や仮想ネットワーク インフラストラクチャを管理しない。

コンピュートリソース（サーバー）は、事前にプロビジョニングする必要はなく、オンデマンドで提供される。

Azureでは、多数のサーバーレスのサービスが提供されている。
https://azure.microsoft.com/ja-jp/solutions/serverless/

■オーケストレーター vs サーバーレス

https://docs.microsoft.com/ja-jp/azure/architecture/microservices/design/compute-options#orchestrator-or-serverless

サーバーレスのサービスは、詳細が抽象化されている。ユーザーがインフラを制御する必要はない（インフラを詳細に制御することはできない）。

オーケストレーターのサービスは、サービスおよびクラスターの構成と管理の広い範囲をユーザーが制御できる（制御する必要がある範囲が大きい）。

- 管理の容易さ: オーケストレーター ＜ サーバーレス
- 柔軟性（ユーザーによる制御が可能な範囲）: オーケストレーター ＞ サーバーレス 


■参考: マイクロサービスを構築するためのフレームワーク

https://medium.com/microservices-architecture/top-10-microservices-framework-for-2020-eefb5e66d1a2

https://dzone.com/articles/top-microservices-frameworks

■参考: Steeltoe framework

スチールトゥ フレームワーク

.NET を使用してクラウドネイティブなマイクロサービスアプリケーションを構築するためのオープンソースフレームワーク。

https://steeltoe.io/

https://github.com/SteeltoeOSS/Steeltoe

https://aadojo.alterbooth.com/entry/2020/12/15/080000

https://www.youtube.com/watch?v=QLRi6iPapVg

https://www.youtube.com/watch?v=Lg1VieZk-5c

https://www.youtube.com/watch?v=3meYereHHtM

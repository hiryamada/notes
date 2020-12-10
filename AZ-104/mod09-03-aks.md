Azure Kubernetes Service (AKS)

高可用性で安全なフル マネージド Kubernetes サービスです。

[製品ページ](https://azure.microsoft.com/ja-jp/services/kubernetes-service/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/kubernetes-service/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/aks/intro-kubernetes)

おすすめ書籍: 

[しくみがわかるKubernetes Azureで動かしながら学ぶコンセプトと実践知識](https://www.shoeisha.co.jp/book/detail/9784798157849)

おすすめ資料

[de:code 2019 の資料](https://eventmarketing.blob.core.windows.net/decode2019-after/decode19_PDF_CD06.pdf)

[Kubernetesとは何か？](https://kubernetes.io/ja/docs/concepts/overview/what-is-kubernetes/)

# Kubernetes

Kubernetesは、宣言的な構成管理と自動化を促進し、コンテナ化されたワークロードやサービスを管理するための、ポータブルで拡張性のあるオープンソースのプラットフォームです。

Kubernetes は、コンテナー ベース アプリケーションとそれに関連するネットワークおよびストレージ コンポーネント

デプロイに対して宣言型のアプローチを提供しています。

# Kubernetes 基本用語

- [Kubernetesクラスター](https://kubernetes.io/ja/docs/reference/glossary/?all=true#term-cluster) - コンテナ化されたアプリケーションを実行するマシンの集合。「コントロールプレーン」と「ノード」で構成。
- [kubectl](https://kubernetes.io/ja/docs/reference/glossary/?all=true#term-kubectl) - コマンドラインツール

- [Pod](https://kubernetes.io/ja/docs/concepts/workloads/pods/pod-overview/) - Kubernetesアプリケーションの基本的な実行単位、デプロイ単位
- [Service](https://kubernetes.io/ja/docs/concepts/services-networking/service/) - Podの集まり。外部からは、個々のPodを意識せず、サービスに対してアクセスすることができる。例:「サムネイル作成サービス」＝「サムネイル作成を行うPodの集まり」

# Kubernetesクラスター

以下のものが含まれます。

- コントロールプレーン - 全体をスケジューリング
- ノード - ワークロード（Pod）を実行

# [コントロールプレーン](https://kubernetes.io/ja/docs/concepts/overview/components/#%E3%82%B3%E3%83%B3%E3%83%88%E3%83%AD%E3%83%BC%E3%83%AB%E3%83%97%E3%83%AC%E3%83%BC%E3%83%B3%E3%82%B3%E3%83%B3%E3%83%9D%E3%83%BC%E3%83%8D%E3%83%B3%E3%83%88)

以下のものが含まれます。

- kube-apiserver - APIサーバー
- etcd - キーバリューストア
- kube-scheduler - Podのノードを選択
- kube-control-manager - ノード等のコントロール

# [ノード](https://kubernetes.io/ja/docs/concepts/overview/components/#node-components)

以下のものが含まれます。

- kubelet - エージェント
- kube-proxy - ネットワーク
- コンテナランタイム - Docker等

# AKS


Azure Kubernetes Service (AKS) は、アップグレードの調整など、デプロイ タスクと主要な管理タスクの複雑さを軽減する、マネージド Kubernetes サービスを提供します。 

コントロール プレーンは Azure プラットフォームによって管理されます。

お使いのアプリケーションを実行するノードに対してのみ課金されます。

[クラスターのアップグレード](https://docs.microsoft.com/ja-jp/azure/aks/upgrade-cluster)機能を提供します。

クラスターの[ノード数をスケーリング](https://docs.microsoft.com/ja-jp/azure/aks/scale-cluster)する機能を提供します。

# [仮想ノード](https://docs.microsoft.com/ja-jp/azure/aks/virtual-nodes)

AKS クラスターでアプリケーション ワークロードをすばやくスケーリングするには、仮想ノードを使用します。 

仮想ノードを使用すると、ポッドを短時間でプロビジョニングできるため、ポッドの実行時間に対して秒単位の支払いだけで済みます。

https://www.slideshare.net/HideakiAoyagi/aks-aci

# Serviceの公開（ServiceTypes）

アプリケーション ワークロードのネットワーク構成を簡素化するため、Kubernetes では、"サービス" を使用して、**一連のポッドを論理的にグループ化して**ネットワーク接続を行います。 次の種類のサービスを使用できます。

ClusterIP: クラスター内部のIPでServiceを公開する。このタイプではServiceはクラスター内部からのみ疎通性があります。デフォルトのServiceTypeです。

NodePort: 各NodeのIPにて、静的なポート(NodePort)上でServiceを公開します。そのNodePortのServiceが転送する先のClusterIP Serviceが自動的に作成されます。<NodeIP>:<NodePort>にアクセスすることによってNodePort Serviceにアクセスできるようになります。

LoadBalancer: クラウドプロバイダーのロードバランサーを使用して、Serviceを外部に公開します。クラスター外部にあるロードバランサーが転送する先のNodePortとClusterIP Serviceは自動的に作成されます。
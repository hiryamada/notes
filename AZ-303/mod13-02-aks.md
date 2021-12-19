# Azure Kubernetes Service (AKS)


■Kubernetes

[読み方](https://www.google.com/search?q=kubernetes+%E8%AA%AD%E3%81%BF%E6%96%B9)：クバネティス/クバネテス/クーべネティス

- コンテナー化されたアプリケーションの展開、スケーリング、また管理を自動化するためのオープンソースコンテナープラットフォーム。
- Googleは2014年にKubernetesプロジェクトをオープンソース化した。
- 現在は[CNCF（Cloud Native Computing Foundation）](https://www.cncf.io/)によってホストされている。

- [公式サイト](https://kubernetes.io/ja/)
- [ドキュメント](https://kubernetes.io/ja/docs/home/)
- [AzureのKubernetesのページ](https://azure.microsoft.com/ja-jp/topic/what-is-kubernetes/)

■Kubernetesの名前の由来

Kubernetesの名称は、ギリシャ語に由来し、操舵手やパイロットを意味する。

略して k8s (ケーエイツ) とも。（K ubernete s と、KとSの間の8文字を略した書き方。[i18n](https://www.google.com/search?q=i18n) のようなもの）

■Kubernetesのメリット

[Kubernetesが必要な理由と提供する機能](https://kubernetes.io/ja/docs/concepts/overview/what-is-kubernetes/#why-you-need-kubernetes-and-what-can-it-do)

- スケーリング
  - Podを簡単に増減させることができる
  - 水平ポッドオートスケーラーで、Podを動かすノードを増減させることもできる
- デプロイのパターンを提供
  - [カナリアデプロイ](https://kubernetes.io/ja/docs/concepts/workloads/controllers/deployment/#%E3%82%AB%E3%83%8A%E3%83%AA%E3%82%A2%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3%E3%81%AB%E3%82%88%E3%82%8B%E3%83%87%E3%83%97%E3%83%AD%E3%82%A4)など
- [サービスディスカバリー](https://kubernetes.io/ja/docs/concepts/services-networking/service/#%E3%82%AF%E3%83%A9%E3%82%A6%E3%83%89%E3%83%8D%E3%82%A4%E3%83%86%E3%82%A3%E3%83%96%E3%81%AE%E3%82%B5%E3%83%BC%E3%83%93%E3%82%B9%E3%83%87%E3%82%A3%E3%82%B9%E3%82%AB%E3%83%90%E3%83%AA%E3%83%BC)と負荷分散
- ストレージ オーケストレーション
  - ローカルストレージやパブリッククラウドプロバイダーなど、選択したストレージシステムを自動でマウント
  - [AKSにおけるストレージ](https://docs.microsoft.com/ja-jp/azure/aks/concepts-storage)
- 自己修復/フェイルオーバー: [Liveness Probe](https://kubernetes.io/ja/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/)等
  - 処理が失敗したコンテナを再起動
  - 定義したヘルスチェックに応答しないコンテナを強制終了
- 機密情報の管理
  - パスワードなどの機密の情報を保持し、管理
  - [Secret](https://kubernetes.io/ja/docs/concepts/configuration/secret/)
  - [AKS の Secrets Store CSI driver 経由で Key Vault を使う](https://zenn.dev/08thse/articles/31-aks-csi-keyvault)

■Kubernetes以外のクラスター オーケストレーション テクノロジ

- [Mesosphere DC/OS](https://dcos.io/)（メソスフィア ディーシーオーエス）
  - DC/OS (the Distributed Cloud Operating System)
  - [Apache Mesos](http://mesos.apache.org/)に基づく
- [Docker Swarm](https://docs.docker.jp/swarm/overview.html)

■Azure Kubernetes Service (AKS)

マネージドKubernetesクラスターをAzureに簡単にデプロイすることができるサービス。

- [製品ページ](https://azure.microsoft.com/ja-jp/services/kubernetes-service/)
- [価格](https://azure.microsoft.com/ja-jp/pricing/details/kubernetes-service/)
- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/aks/)

■特徴

- Kubernetes のバージョン アップグレードやパッチ適用、正常性の監視やメンテナンスなどのクリティカルなタスクを管理（後述）
- クラスター スケーリングをかんたんに実行
- Microsoft が「コントロールプレーン」を完全に管理
- ユーザーは、ノードの管理とメンテナンスだけを実行。
- 「コントロールプレーン」は無料
- 「ノード」は有料(VMの料金)

■正常性の監視・修復

https://docs.microsoft.com/ja-jp/azure/aks/node-auto-repair

ワーカー ノードの正常性状態が継続的に監視され、正常ではなくなった場合、ノードの自動修復が実行される.

■AKS アーキテクチャ コンポーネント

```
Kubernetes クラスター
  ├ コントロールプレーン: AKSでは無料
  │  ├ kube-apiserver: APIサーバー
  │  ├ etcd: クラスターと構成の状態を維持するキーバリューストア
  │  ├ kube-scheduler: ノードの選択
  │  └ kube-controller-manager: 「コントローラー」を監視
  └ ノードプール: VMの集まり
    └ ノード: VM
      ├ kubelet: エージェント
      ├ Container runtime: containerd
      ├ Container: アプリケーションなど
      └ kube-proxy: 仮想ネットワークを処理
```

※コントロールプレーンは「クラスターマスター」と呼ばれる場合もある。

■ノードとは

Podを動かすVM。ノードプールに入る。

■ノードプールとは

同じ構成のノードの集まり。

- システム ノード プール
- ユーザー ノード プール: 追加のノードプール。
 
たとえば、GPUを搭載したノードでユーザーノードプールを作り、機械学習の計算の高速化などに使用することができる。

■Podとは。

- 最小のデプロイ単位
- コンテナの管理やネットワーキングの目的でまとめられた、1つ以上のコンテナのグループ。
- クラスター上で実行中のプロセスを表す。
- 構成、ストレージ リソース、およびネットワーキング サポートで構成
- 各Podは固有のIPアドレスを割り当てられます。単一のPod内の各コンテナは、IPアドレスやネットワークポートを含む、そのネットワークの名前空間を共有します。
- 単一のPodは共有されたストレージボリュームのセットを指定できます。Pod内の全てのコンテナは、その共有されたボリュームにアクセスでき、コンテナ間でデータを共有することを可能にします。
- ポッドで、リソース（CPU、メモリ）を要求できる。またリソースの上限を指定できる。
- Kubernetesスケジューラは、要求を満たすノードを探してPodを配置（スケジュール）する。

[ドキュメント](https://kubernetes.io/ja/docs/concepts/workloads/pods/pod-overview/)

■Podの例

```
apiVersion: v1
kind: Pod
metadata:
  name: myapp-pod # Podに名前をつける
  labels:
    app: myapp # ラベルを付けて、Serviceから選択できるようにする
spec:
  containers:
  - name: myapp-container # Pod内のコンテナーに名前をつける
    image: busybox
    command: ['sh', '-c', 'echo Hello Kubernetes! && sleep 3600']
```

■Podの一覧を取得する
```
kubectl get pods
```

■Deployment

通常、Podを直接デプロイする代わりに、Deploymentを使う場合が多い。

Deploymentでは、複数のPodを一度にデプロイしたり、Podを増やしてスケールアウトしたりすることができる。

Podを複数作っておくと、負荷分散や、ローリングアップデートが可能となる。

```
apiVersion: apps/v1
kind: Deployment
metadata:
  name: nginx-deployment
  labels:
    app: nginx
spec:
  replicas: 3
  selector:
    matchLabels:
      app: nginx
  strategy:
    rollingUpdate:
      maxSurge: 1 # ローリングアップデート時に追加されるPodの数
  template:
    metadata:
      labels:
        app: nginx
    spec:
      containers:
      - name: nginx
        image: nginx:1.14.2
        ports:
        - containerPort: 80
```

■kubectl

Kubernetesクラスターを管理するコマンド。「キューブシーティーエル」

https://kubernetes.io/ja/docs/reference/kubectl/overview/

```
kubectl apply -f sample1.yml

kubectl get node
kubectl get pods
kubectl get deployments
kubectl get services

kubectl describe pods pod1
kubectl describe deployments deployment1
kubectl describe services service1

kubectl delete pod pod1
kubectl delete services service1
kubectl delete deployment deployment1
```

■Helm

https://helm.sh/ja/

Kubernetesクラスターにアプリケーションなどをデプロイする際に、複雑な～.ymlファイルを自分で定義しなくても、「Helmチャート」の名前を指定するだけでよい。

たとえば `helm install stable/wordpress` と打つだけで、wordpressの最新版のコンテナー（と、その動作に必要なMySQLデータベースのコンテナー）がKubernetesにデプロイされる。

- helmコマンド: Helmを操作するコマンド
- チャート: Helmのパッケージ。Kubernetesクラスターでアプリケーション、ツール、サービスを動かすための必要なリソース定義が含まれる。
- リポジトリ: チャートを収集して共有できる場所。
- リリース: Kubernetesクラスターで実行されているチャートのインスタンス。

https://knowledge.sakura.ad.jp/23603/

■Draft

https://draft.sh/

開発者向けのツール。

マイクロソフトがOSSプロジェクトとして立ち上げた。

Kubernetes上で動作するアプリケーションを簡単に構築することができるように、「足場」（スキャフォールド）を作る。また、簡単なコマンドで、アプリケーションをKubernetesで動作させることができる。


アプリケーションはPython, Node.js, Java, Ruby, PHP, Goなどで開発することができる。

`draft create`コマンド: アプリケーションをコンテナ化するためのDockerfileと、KubernetesクラスターにアプリケーションをデプロイするためのHelmチャートを作成する。

`draft up`コマンド: アプリケーションをKubernetesクラスターにデプロイして起動する。

`draft connect`コマンド: デプロイしたアプリケーションに接続する。

以降、アプリケーションのコードを更新したら`draft up`コマンドを実行する。

`draft delete`コマンド: アプリケーションをKubernetesクラスターから削除する。


ドキュメント: https://github.com/Azure/draft/tree/master/docs

わかりやすい解説: https://www.creationline.com/lab/36378

■Brigade

[ブリゲード: 旅団](https://ejje.weblio.jp/content/brigade)

マイクロソフトがOSSプロジェクトとして立ち上げた。

Event-based Scripting for Kubernetes

JavaScriptを使用。イベントを処理する自動化タスクを記述し、Kubernetesのコンテナー上で実行することができる。

https://github.com/brigadecore/brigade

ドキュメント - Overview
https://docs.brigade.sh/intro/overview/

わかりやすい解説
https://news.mynavi.jp/article/20190401-800253/

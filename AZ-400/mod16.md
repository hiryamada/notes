# モジュール16 Kubernetes

- Kubernetesとは。
- Azure Kubernetes Serviceとは。
- クラスターとは。
  - コントロールプレーンとは。
  - ノードとは。
- CI/CDからどうやってアプリケーションをデプロイするのか。
- Helmとは。

## Azure Kubernetes Service (AKS) の概要

### Kubernetes の概要

■Kubernetes

- コンテナー化されたアプリケーションの展開、スケーリング、また管理を自動化するためのオープンソースコンテナープラットフォーム。
- Googleは2014年にKubernetesプロジェクトをオープンソース化した。
- 現在は[CNCF（Cloud Native Computing Foundation）](https://www.cncf.io/)によってホストされている。

- [公式サイト](https://kubernetes.io/ja/)
- [ドキュメント](https://kubernetes.io/ja/docs/home/)
- [AzureのKubernetesのページ](https://azure.microsoft.com/ja-jp/topic/what-is-kubernetes/)

[読み方](https://www.google.com/search?q=kubernetes+%E8%AA%AD%E3%81%BF%E6%96%B9)：クバネティス/クバネテス/クーべネティス

■Kubernetesの由来

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
  - PodのエンドポイントをAPI Serverに問い合わせることができる
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

### Azure Kubernetes Service (AKS)

マネージドKubernetesクラスターをAzureに簡単にデプロイすることができるサービス。

- [製品ページ](https://azure.microsoft.com/ja-jp/services/kubernetes-service/)
- [価格](https://azure.microsoft.com/ja-jp/pricing/details/kubernetes-service/)
- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/aks/)

PDF資料: [AKSクラスターの作成](https://github.com/hiryamada/notes/blob/main/AZ-303/pdf/mod13/AKS%E3%82%AF%E3%83%A9%E3%82%B9%E3%82%BF%E3%83%BC%E3%81%AE%E4%BD%9C%E6%88%90.pdf)

■特徴

- Kubernetes のバージョン アップグレードやパッチ適用、正常性の監視やメンテナンスなどの運用が簡単にできる
- クラスター スケーリングをかんたんに実行
- Microsoft が「コントロールプレーン」を完全に管理
- ユーザーは、ノードの管理とメンテナンスだけを実行。
- 「コントロールプレーン」は無料
- 「ノード」は有料(VMの料金)

[PDF: AKSの更新について](pdf/AKSの「更新」.pdf)

■正常性の監視・修復

ワーカー ノードの正常性状態が継続的に監視され、正常ではなくなった場合、ノードの自動修復が実行されます.

https://docs.microsoft.com/ja-jp/azure/aks/node-auto-repair

■Kubernetesのバージョン

- おおよそ3ヶ月おきにマイナーバージョンがリリースされる
  - 新機能と機能強化
- パッチ リリース
  - セキュリティの脆弱性や重大なバグの修正
  - できるだけ早くアップグレード（バージョンアップ）する必要がある
- リリースは[GitHubで公開](https://github.com/Azure/AKS/releases)される
- サポートされているバージョンを利用し続けるには、9 か月ごとにアップグレードする必要がある。

バージョンについての説明
https://docs.microsoft.com/ja-jp/azure/aks/supported-kubernetes-versions

アップグレード方法
https://docs.microsoft.com/ja-jp/azure/aks/operator-best-practices-cluster-security#regularly-update-to-the-latest-version-of-kubernetes

自動アップグレード
https://docs.microsoft.com/ja-jp/azure/aks/upgrade-cluster

■バージョンアップの方法

- サブスクリプション管理者宛にバージョンの削除予定日が記載されたメールが送信される。
- バージョンアップは手動で実行する。
  - [事例](https://qiita.com/shingo_kawahara/items/73c80bb72ffa73577b29)

<!--
■バージョンアップ（アップグレード）の動作

アップグレード プロセスにより、次のことが安全に行われます。

- ノードの遮断とドレインを一度に 1 つずつ行います。
- 残りのノード上のポッドをスケジュールします。
- 最新の OS および Kubernetes バージョンを実行している新しいノードをデプロイします。

■サージ

クラスターのアップグレード時は、新しいノードを作成し、Podを移動し、古いノードを削除する、という動作が繰り返される。アップグレードの作業中に、最大でいくつ新しいノードを作るかという数値を「最大サージ」という値で設定できる。デフォルト値は「1」であり、アップグレード中、追加のノードは1つだけ作られる。

最大サージの値は、整数（＝ノード数）またはパーセント値（＝ノードプールのノードに対する割合）で指定する。たとえば3と指定すれば最大3つのノードが追加で作られる。ノードプールに10個のノードがある場合、20% と指定すれば、最大2個のノードが追加で作られる。

最大サージ値を大きくすることでアップグレード プロセスはより速く完了する。

ただし、最大サージに大きな値を設定すると、アップグレード プロセス中、Kubernetesで稼働しているアプリケーションの中断が発生する可能性がある。

例：最大サージ値が 100% の場合、(ノード数が 2 倍になり) 可能な限り最速のアップグレード プロセスが提供されますが、ノード プール内のすべてのノードが同時にドレイン（新規リクエストの受付の停止と、処理中のリクエストの完了のための時間が取られること）される。

テスト環境では、このようなより大きな値を使用することをお勧めします。 運用ノード プールの場合は、max_surge 設定を 33% にすることをお勧めします。

```
# 最大サージを 33% に設定する例
az aks nodepool add -n mynodepool -g MyResourceGroup --cluster-name MyManagedCluster --max-surge 33%
```

https://docs.microsoft.com/ja-jp/azure/aks/upgrade-cluster#customize-node-surge-upgrade

■ノードイメージのアップグレード

https://docs.microsoft.com/ja-jp/azure/aks/node-image-upgrade

https://azure.microsoft.com/en-us/updates/azure-kubernetes-service-aks-now-supports-node-image-autoupgrade-in-public-preview/

-->

### AKS アーキテクチャ コンポーネント

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

「キューブシーティーエル」

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

<!-- 
### Kubernetes ネットワーク

■Serviceとは

一連のPodをグループ化し、ネットワーク接続を提供するしくみ。

PodやDeploymentに対してServiceを作ることで、クラスター内部やクラスター外部からのPodへの接続が可能となる。

■Serviceの種類

- ClusterIP: デフォルト。クラスター内部からのみ接続可能な「仮想IPアドレス」を割り当て。
- NodePort: ノードのIPアドレスと、静的なポート番号で、クラスター外部からPodに接続できる。
- LoadBalancer: Azure Load Balancerを作成し、そのIPアドレスで、クラスター外部からPodに接続できる。PodはAzure Load Balancerのバックエンドプールに接続される。

■type: ClusterIP

クラスター内部のIPでServiceを公開する。このタイプではServiceはクラスター内部からのみ接続できる。

Serviceのデフォルト。

```
apiVersion: v1
kind: Service
metadata:
  name: sample-clusterip
spec:
  type: ClusterIP
  ports:
    - name: "http-port"
      protocol: "TCP"
      port: 8080
      targetPort: 80
  selector:
    app: sample-app
```

■type: NodePort

各NodeのIPにて、静的なポート(NodePort)上でServiceを公開。

そのNodePort のServiceが転送する先のClusterIP Serviceが自動的に作成される。

<NodeIP>:<NodePort>にアクセスすることによってNodePort Serviceにアクセスできる。

```
apiVersion: v1
kind: Service
metadata:
  name: my-service
spec:
  type: NodePort
  selector:
    app: MyApp
  ports:
      # デフォルトでは利便性のため、 `targetPort` は `port` と同じ値にセットされます。
    - port: 80
      targetPort: 80
      # 省略可能なフィールド
      # デフォルトでは利便性のため、Kubernetesコントロールプレーンはある範囲から1つポートを割り当てます(デフォルト値の範囲:30000-32767)
      nodePort: 30007
```

https://kubernetes.io/ja/docs/concepts/services-networking/service/#nodeport

■type: LoadBalancer

Azure Load Balancerがプロビジョニングされる。

```
apiVersion: v1
kind: Service
metadata:
  name: azure-vote-front
spec:
  type: LoadBalancer
  ports:
  - port: 80
  selector:
    app: azure-vote-front
```

https://kubernetes.io/ja/docs/concepts/services-networking/service/#loadbalancer

### イングレス コントローラー

L7のロードバランサー（Application Gatewayなど）を作成する機能。

AGIC（Application Gateway Ingress Controller）とも。

Ingressはクラスター外からクラスター内ServiceへのHTTPとHTTPSのルートを公開します。トラフィックのルーティングはIngressリソース上で定義されるルールによって制御されます。

```
apiVersion: extensions/v1beta1
kind: Ingress
metadata:
  name: aspnetapp
  annotations:
    kubernetes.io/ingress.class: azure/application-gateway
spec:
  rules:
  - http:
      paths:
      - path: /
        backend:
          serviceName: aspnetapp
          servicePort: 80
```

https://docs.microsoft.com/ja-jp/azure/application-gateway/ingress-controller-expose-service-over-http-https

https://kubernetes.io/ja/docs/concepts/services-networking/ingress/#ingress%E3%81%A8%E3%81%AF%E4%BD%95%E3%81%8B

https://kubernetes.io/ja/docs/concepts/services-networking/ingress-controllers/

-->

### デプロイ単位

■Pod

1つ以上のコンテナーのあつまり。

■CI/CDパイプラインからKubernetesへのデプロイ

- ビルドエージェントでkubectl「キューブシーティーエル」を使用する
- KubernetesManifestタスクを使用する

■タスクの例

```
- task: KubernetesManifest@0
  displayName: Deploy to Kubernetes cluster
  inputs:
    action: deploy
    namespace: $(k8sNamespace)
    manifests: |
    $(System.ArtifactsDirectory)/manifests/deployment.yml
    $(System.ArtifactsDirectory)/manifests/service.yml
    imagePullSecrets: |
    $(imagePullSecret)
    containers: |
    $(containerRegistry)/$(imageRepository):$(tag)
```

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/ecosystems/kubernetes/aks-template?view=azure-devops

<!-- 
### 継続的デプロイ

Kubernetesでは（Deploymentを使用することで）ローリングアップデートを使用してサービスを更新することができる。

https://kubernetes.io/ja/docs/tutorials/kubernetes-basics/update/update-intro/


### イメージの更新

Dockerfileに指定するベースイメージ（FROM）のバージョン（タグ）の指定を上げることで、イメージを更新する。

タグは、明示的に「1.2.3」などのように具体的な値を（開発者が手動で）指定すべき。（せめて、メジャーバージョンは指定したほうがよい。）

「latest」などを指定した場合、ベースイメージが変わってしまう可能性があり、各回のビルドで同じベースイメージを使っているという保証がなくなってしまう。

（たとえば2021年6月のビルドでは latest でベースイメージ 1.2.3 プルされ、2021年7月のビルドでは latest でベースイメージ 2.0.0 がプルされる可能性がある。）

-->

## Kubernetesツール

### kubectl

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

### Helm

https://helm.sh/ja/

Kubernetesクラスターにアプリケーションなどをデプロイする際に、複雑な～.ymlファイルを自分で定義しなくても、「Helmチャート」の名前を指定するだけでよい。

たとえば `helm install stable/wordpress` と打つだけで、wordpressの最新版のコンテナー（と、その動作に必要なMySQLデータベースのコンテナー）がKubernetesにデプロイされる。

- helmコマンド: Helmを操作するコマンド
- チャート: Helmのパッケージ。Kubernetesクラスターでアプリケーション、ツール、サービスを動かすための必要なリソース定義が含まれる。
- リポジトリ: チャートを収集して共有できる場所。
- リリース: Kubernetesクラスターで実行されているチャートのインスタンス。

https://knowledge.sakura.ad.jp/23603/


### Visual Studio Code用のKubernetes機能拡張

https://code.visualstudio.com/docs/azure/kubernetes

Visual Studio Code上から以下の操作を行うことができる。
- Kubernetesクラスター（AKS）の作成
- Kubernetesマニフェストファイルの作成、補完、コードスニペット挿入、検証、クラスターへのデプロイ
- PodやServiceの情報を取得する
- Kubernetes上で動作しているWebアプリケーションのIPアドレスをブラウザで開く

■Minikube

- 軽量なKubernetes実装。
- Kubernetesを試したり日々の開発への使用を検討するユーザー向け。
- ローカルマシンに、シングルノードのクラスターを作成することができる。
- Linux、macOS、Windowsで動作する。

- [公式サイト](https://minikube.sigs.k8s.io/docs/)
- 参考ドキュメント
[1](https://kubernetes.io/docs/tutorials/kubernetes-basics/create-cluster/cluster-intro/),
[2](https://kubernetes.io/ja/docs/setup/learning-environment/minikube/)


## AKSとパイプラインの統合

パイプラインからコンテナーをデプロイするには、AKSクラスターとACR（コンテナーレジストリ）を作成する必要がある。

<!-- 
### KubernetesとKey Vault

Kubernetesで、Azure Key Valutから機密情報（データベースに接続するためのパスワードなど）を読み込み、Podで使用することができる。

■ConfigMap

[ConfigMap](https://kubernetes.io/ja/docs/concepts/configuration/configmap/)

- 機密性のないデータをキーと値のペアで保存するために使用されるAPIオブジェクト。
- Podからは、環境変数、コマンドライン引数、ボリューム内の設定ファイルとして、設定値を読み取ることができる。

■Secret

[Secret](https://kubernetes.io/ja/docs/concepts/configuration/secret/)

- パスワード、OAuthトークン、SSHキーのような機密情報を保存し、管理できるようにする。
- Podからは環境変数を使用してシークレットの値を読み取ることができる。

■シークレット ストア Container Storage Interface (CSI) ドライバー

- Azure Key Vaultにアクセスしてシークレットを取得する。
- そのシークレットをボリュームとして Kubernetes ポッドにマウントする。
- ドライバーは、Helmを使用してインストールする。

https://docs.microsoft.com/ja-jp/azure/key-vault/general/key-vault-integrate-kubernetes

https://qiita.com/ysakashita/items/4b56c2577f67f1b141e5#csi%E3%81%AE%E6%A6%82%E8%A6%81

https://torumakabe.github.io/post/aks_how_to_keep_secret/

### Liveness Probe、Readiness ProbeおよびStartup Probe

ヘルスチェックの機能。

kubeletは、Liveness Probeを使用して、コンテナをいつ再起動するかを認識します。 例えば、アプリケーション自体は起動しているが、処理を継続することができないデッドロック状態を検知することができます。 このような状態のコンテナを再起動することで、バグがある場合でもアプリケーションの可用性を高めることができます。

※コンテナが動いていなければ再起動を行う仕組み。

kubeletは、Readiness Probeを使用して、**コンテナがトラフィックを受け入れられる状態であるかを認識**します。 Podが準備ができていると見なされるのは、Pod内の全てのコンテナの準備が整ったときです。 一例として、このシグナルはServiceのバックエンドとして使用されるPodを制御するときに使用されます。 Podの準備ができていない場合、そのPodはServiceのロードバランシングから切り離されます。

※あるコンテナーXの代わりとして新しいコンテナーYが起動する際に、Yがリクエストが受付けできる状態になるまで、Xのシャットダウンを行わず待機する仕組み。

kubeletは、Startup Probeを使用して、コンテナアプリケーションの起動が完了したかを認識します。 Startup Probeを使用している場合、Startup Probeが成功するまでは、Liveness Probeと Readiness Probeによるチェックを無効にし、これらがアプリケーションの起動に干渉しないようにします。 例えば、これを起動が遅いコンテナの起動チェックとして使用することで、起動する前にkubeletによって 強制終了されることを防ぐことができます。

※チェック方法はLiveness/Readinessと同じだが、コンテナーの起動時に特別な猶予をもたせる仕組み。起動が完了するまではStartup Probeで（Liveness/Readinessによるものよりも長い）猶予（＝failureThreshold * periodSeconds）を設定する。コンテナー起動後はLiveness/Readinessによるヘルスチェックを行う。

https://kubernetes.io/ja/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/


## ラボ

(1) クイックスタート: [Azure portal を使用して Azure Kubernetes Service (AKS) クラスターをデプロイする](https://docs.microsoft.com/ja-jp/azure/aks/kubernetes-walkthrough-portal)を実施します。

(2) クイックスタート: [Helmを使用してAzure Kubernetes Serviceで開発する](https://docs.microsoft.com/ja-jp/azure/aks/quickstart-helm)を実施します。

(3) AZ-400 ラボ: [Azure Kubernetes Services へのマルチコンテナー アプリケーションのデプロイ](https://microsoftlearning.github.io/AZ-400JA-Designing-and-Implementing-Microsoft-DevOps-solutions/Instructions/Labs/AZ400_M16_Deploying_multi-container_application_to_Azure_Kubernetes_Services.html): Azure DevOps を使用して、コンテナー化されたアプリケーションとデータベースのデプロイを構成する, Azure DevOps パイプラインを使用して、コンテナー化されたアプリケーションを自動的にデプロイするようビルドする

-->


■Azure 仮想マシン(Virtual Machine, VM)

https://docs.microsoft.com/ja-jp/azure/virtual-machines/

■VMでサポートされるOS

Linuxディストリビューション:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/overview#distributions

Windows:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/tutorial-manage-vm#understand-marketplace-images

```
Get-AzVMImageSku `
   -Location "EastUS" `
   -PublisherName "MicrosoftWindowsServer" `
   -Offer "WindowsServer"
```

- Windows Server 2008 R2, 2012, 2016, 2019, 2022 Datacenter
- Windows 10 Pro

■VMのサイズ

https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes

VMのサイズにより、性能（vCPU数、周波数、最大ディスク数、ネットワーク帯域等）が決定される。

サイズはVM作成後も変更できる。（サイズ変更時には再起動が発生）

主なタイプとシリーズ:

- 汎用 タイプ
  - [Aシリーズ(Av2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/av2-series)
  - [Bシリーズ(B)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-b-series-burstable)
  - [Dシリーズ(Dv4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/dv4-dsv4-series)
- コンピューティング最適化 タイプ
  - [Fシリーズ(Fsv2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/fsv2-series)
- メモリの最適化 タイプ
  - [Eシリーズ(Ev4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/ev4-esv4-series)
  - [Mシリーズ(M)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/m-series)
- ストレージの最適化 タイプ
  - [Lシリーズ(Lsv2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/lsv2-series)
- GPU タイプ
  - [NCシリーズ(NCv3)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/ncv3-series)
  - [NVシリーズ(NVv4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/nvv4-series)
- FPGA最適化済み タイプ
  - [NPシリーズ(NP)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/np-series)
- ハイ パフォーマンス コンピューティング タイプ
  - [Hシリーズ(H)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/h-series)

■VMのディスク

https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview

- [OSディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview#os-disk)
  - OSがプリインストールされたディスク
  - 必須
- [データディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview#data-disk)
  - ユーザーやアプリケーションのデータを保存するディスク
  - オプション
- [一時ディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview#temporary-disk)
  - ページファイル・スワップファイルを格納するディスク
  - 通常の再起動では、内容は残る
  - メンテナンスイベントやVM再デプロイで、内容が失われる可能性がある
  - ユーザーやアプリケーションのデータを保存するのには適さない。
  - VMサイズを選択した段階で使用の可否・容量が決まる
  - ほとんどのVMサイズで利用可能だが、[一時ディスクが使えないVMサイズ](https://docs.microsoft.com/ja-jp/azure/virtual-machines/azure-vms-no-temp-disk)も存在

■VMの可用性を高める仕組み

https://azure.microsoft.com/ja-jp/support/legal/sla/virtual-machines/v1_9/

https://azure.microsoft.com/mediahandler/files/resourcefiles/azure-resiliency-infographic/Azure_resiliency_infographic.pdf

- 単一のVMでプレミアムストレージを利用: 99.9% SLA
- 可用性セット: 99.95% SLA
- 可用性ゾーン: 99.99% SLA
- 複数のリージョン (リージョンレベルの障害や自然災害に対応。SLA定義はない)

■仮想マシンスケールセット（Virtual Machine Scale Set: VMSS）

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview

- 負荷分散が行われる VM のグループ
  - ロードバランサー（Azure Load Balancer, Azure Application Gateway）と接続することができる
- VMSSの中の個々のVMは「インスタンス」と呼ばれる
- インスタンスを増減させることがかんたんにできる。
  - 手動スケーリング
  - 自動スケーリング
- すべてのインスタンスが、同一のOSイメージと構成から作成される

[複数の可用性ゾーンにまたがる仮想マシンスケールセット](https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-use-availability-zones)を作成することができる。

■Azure Monitor

[PDFまとめ](../AZ-104/pdf/mod11/Azure%20Monitor.pdf)

■Azure App Service


AzureのPaaSサービスの一つ。

Azure上で、HTTPベースのアプリケーション（WebアプリやWeb API）を稼働させることができる。

Visual Studio、Visual Studio Code、Eclipse、PyCharmなどを使用して、ローカルの開発環境でWebアプリ等を開発する。

その後、開発したコードをApp Service上にデプロイして、Azure上で稼働させる。

主な特徴:

- VM（仮想マシン）の管理や、OSの管理（アップデート）、.NETやJavaなどの言語ランタイムの管理（インストールやアップデート）が不要。
- VMスケールセットのような、負荷状況に合わせてインスタンス（VM）を増減させることができる機能も利用できる。
- ロードバランサーの機能も組み込まれている。
- Dockerコンテナー（LinuxとWindows）もサポートされている。開発者は、開発したDockerコンテナーをApp Serviceにデプロイすることもできる。

デプロイスロット:

一つのアプリで複数の「デプロイスロット」を使用することができる。

初期状態:

```
App Service アプリ(example)
└運用スロット(example.azurewebsites.net)
```

「ステージング」(staging)という名前の「デプロイスロット」を追加した状態:

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net)
└ステージングスロット(example-staging.azurewebsites.net)
```

デプロイスロットは、それぞれ「～.azurewebsites.net」というFQDNを持つ。これらのFQDNを使用して、それぞれのデプロイスロットのアプリにアクセスできる。

デプロイスロットはそれぞれ独立して動作し、他のデプロイスロットの動作に影響を与えない。

たとえば、あるアプリで、「運用スロット」に、バージョン1(v1)のコードがデプロイされているとする。エンドユーザー（一般の利用者）は、「運用スロット」にアクセスして、このアプリを利用する。

```
App Service アプリ(example)
└運用スロット(example.azurewebsites.net): v1 ← エンドユーザー
```

開発者は、「ステージングスロット」を追加し、そこにバージョン2(v2)のコードをデプロイし、動作を確認することができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v1 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v2 ← 開発者
```

動作確認が終わったら、開発者は「スワップ」（入れ替え）操作を実行して、v1とv2を入れ替えることができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v2 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v1 ← 開発者
```

エンドユーザーは、今までと同じFQDN（example.azurewebsites.net）を使用してアプリにアクセスすることができる。

開発者は、ステージングスロットを使用して、引き続き次のバージョン（v3）のデプロイと動作確認を行うことができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v2 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v3 ← 開発者
```

※実際には、「スワップ」は、2つのスロットのルーティング規則を入れ替えることで行われる。（ドキュメントの[手順5番](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-staging-slots#swap-operation-steps)を参照）


■Azure Container Instances

Azure で最も高速かつ簡単にコンテナーを実行する方法を提供。

特徴:

- [ハイパーバイザーレベルの分離](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview#hypervisor-level-security)を提供。
  - ACI上で動作する各アプリケーションは、それぞれ別のVM内に配置されているかのように分離される。
  - アプリケーションから別のアプリケーションに干渉することはできない。
- Docker Hub, Azure Container Registry(ACR), Microsoft Container Registry(MCR) などからDockerイメージを読み込むことができる。
  - [Docker Hub](https://hub.docker.com/)
  - [Azure Container Registry(ACR)](https://docs.microsoft.com/ja-jp/azure/container-registry/)
    - プライベートなレジストリを運用するためのサービス。
  - [Microsoft Container Registry(MCR)](https://github.com/microsoft/containerregistry)
    - マイクロソフトが提供する公式イメージのプライマリレジストリ。
    - MCRで提供されるイメージは[Docker Hub](https://hub.docker.com/publishers/microsoftowner)で確認できる。
- [GPUリソースも利用できる](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-gpu)
- Linuxコンテナーに加え[Windowsコンテナー](https://docs.microsoft.com/ja-jp/dotnet/architecture/modernize-with-azure-containers/modernize-existing-apps-to-cloud-optimized/when-to-deploy-windows-containers-to-azure-container-instances-aci)にも対応。

■Azure Kubernetes Services

高可用性で安全なフル マネージド Kubernetes サービス。

特徴:

- Kubernetes のバージョン アップグレードやパッチ適用、正常性の監視やメンテナンスなどのクリティカルなタスクを管理
- クラスター スケーリングをかんたんに実行
- Microsoft が「コントロールプレーン」を完全に管理
- ユーザーは、ノードの管理とメンテナンスだけを実行すればよい
- 「コントロールプレーン」は無料
- 「ノード」は有料(VMの料金)

AKS アーキテクチャ コンポーネント:

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

ノード:

Podを動かすVM。ノードプールに入る。

ノードプール:

同じ構成のノードの集まり。

- システム ノード プール
- ユーザー ノード プール: 追加のノードプール。
 
たとえば、GPUを搭載したノードでユーザーノードプールを作り、機械学習の計算の高速化などに使用することができる。

Pod:

- 最小のデプロイ単位
- コンテナの管理やネットワーキングの目的でまとめられた、1つ以上のコンテナのグループ。
- クラスター上で実行中のプロセスを表す。
- 構成、ストレージ リソース、およびネットワーキング サポートで構成
- 各Podは固有のIPアドレスを割り当てられます。単一のPod内の各コンテナは、IPアドレスやネットワークポートを含む、そのネットワークの名前空間を共有します。
- 単一のPodは共有されたストレージボリュームのセットを指定できます。Pod内の全てのコンテナは、その共有されたボリュームにアクセスでき、コンテナ間でデータを共有することを可能にします。
- ポッドで、リソース（CPU、メモリ）を要求できる。またリソースの上限を指定できる。
- Kubernetesスケジューラは、要求を満たすノードを探してPodを配置（スケジュール）する。

[ドキュメント](https://kubernetes.io/ja/docs/concepts/workloads/pods/pod-overview/)

Podの例:

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

■ラボ8 仮想マシンの作成

[ラボ8の解説]https://github.com/hiryamada/notes/blob/main/AZ-104/lab/lab08.md

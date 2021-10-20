# 仮想マシン スケール セット(Virtual Machine Scale Set, VMSS)

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview

- 多数の VM の一元的な管理、構成、更新を可能にする
- VM インスタンスの数を手動または自動で増減させることができる
- 「均一（ユニフォーム）モード」: スケール セット内のすべての VM が、同一の OS イメージと構成から作成される
- 「フレキシブル オーケストレーション モード」: では複数の構成のVMの混在が可能になった
- 前面にロードバランサーを立てて負荷分散を行うことができる
  - Azure Load Balancer
  - Azure Application Gateway
- 可用性ゾーンと組み合わせることで、VMをリージョン内のゾーンに分散させることができる
  - 使用するゾーン（1,2,3）を明示的に選択。
- 1つのスケール セットに、最大1000個（カスタムVMイメージを使用する場合は600個）のVMを含めることができる
- 手動、自動、ローリングの3種類のアップグレード方法をサポート。
- VMの正常性を監視し、正常ではないインスタンスを置換することができる。
- 可用性セットに相当する「配置グループ」という仕組みを内部で使っており、VMは自動的に障害ドメインと更新ドメインに分散される。

■歴史

2015/11/11 仮想マシンスケールセット パブリックプレビュー。
https://azure.microsoft.com/en-us/blog/azure-vm-scale-sets-public-preview/

2016/4/6 仮想マシンスケールセット 一般提供開始。1つの「スケールセット」で、同じ構成のVMを、最大100個まで管理。ロードバランサーやApplication Gatewayとも統合されている。
https://azure.microsoft.com/ja-jp/blog/azure-virtual-machine-scale-sets-ga/

2017/2/8 マネージドディスクの一般提供開始。それに伴い、マネージドディスクを使用するVMSSで, 1000インスタンスをサポート（従来は100インスタンスまで）
https://azure.microsoft.com/en-us/blog/announcing-general-availability-of-managed-disks-and-larger-scale-sets/

2017/6/10 ネットワーク機能の強化。VMごとのパブリックIPv4アドレス、スケールセットのDNS構成、NICごとに複数のIPアドレス、VMごとに複数のNIC、スケールセットごとのネットワークセキュリティグループ、IPv6ロードバランサーのサポート、SR-IOVを使ったネットワークの高速化
https://azure.microsoft.com/de-de/blog/new-networking-features-in-azure-scale-sets/

2017/10/14 可用性ゾーン 一般提供開始。
https://azure.microsoft.com/ja-jp/updates/azure-availability-zones/

2018/6/13 Azure Kubernetes Service 一般提供開始。
https://azure.microsoft.com/ja-jp/blog/azure-kubernetes-service-aks-ga-new-regions-new-features-new-productivity/

※AKSクラスターのノードの管理には仮想マシンスケールセットが使われている。https://docs.microsoft.com/ja-jp/azure/aks/cluster-autoscaler#create-an-aks-cluster-and-enable-the-cluster-autoscaler

2018/9/26 OSイメージ自動アップグレード 一般提供開始
https://azure.microsoft.com/ja-jp/updates/vmss-auto-os-upgrades/

2019/8/1 専有ホスト（Dedicated Host）プレビュー開始。[仮想マシンスケールセットでも利用できる。](https://docs.microsoft.com/ja-jp/azure/virtual-machines/dedicated-hosts#virtual-machine-scale-set-support)
https://azure.microsoft.com/en-us/blog/introducing-azure-dedicated-host/


2020/4/14 仮想マシンスケールセットのカスタムイメージの自動イメージアップグレード
https://azure.microsoft.com/en-us/updates/automatic-image-upgrade-for-custom-images-now-in-preview-for-azure-vmss/

2020/4/17 自動インスタンス修復 一般提供開始
https://azure.microsoft.com/en-us/updates/automatic-instance-repairs-for-azure-vmss-now-generally-available/

2020/5/11 仮想マシンスケールセットのスケールインの機能強化。インスタンス保護（スケールイン時に削除しないインスタンスを指定）、カスタムスケールインポリシー、削除通知。
https://azure.microsoft.com/en-us/blog/azure-virtual-machine-scale-sets-now-provide-simpler-management-during-scalein/

2020/5/12 Spot VMの一般提供開始。VMまたはVMSSで、最大90%割引でVMを使用することができる。余剰キャパシティがなくなると、Spot VMは削除または停止される。
https://azure.microsoft.com/ja-jp/blog/announcing-the-general-availability-of-azure-spot-virtual-machines/

2021/9/7 「フレキシブル オーケストレーション モード」パブリックプレビュー。複数種類のVMインスタンスが混在可能に。大規模で弾力性が高いワークロードに対応しやすくなった。従来のモードは「均一（uniform)オーケストレーションモード」と呼ぶようになった。（「フレキシブルスケールセット」、「ユニフォームスケールセット」とも）
https://azure.microsoft.com/en-us/updates/automatic-scaling-for-vms-with-azure-virtual-machine-scale-sets-flexible-orchestration-mode/

■スケールセットの概要

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-autoscale-overview

- 「VMスケールセット」リソースを作成
- 「VMスケールセット」内に複数のインスタンス（VM）を含めることができる。
- インスタンス数を増減させることができる。
- VMSS全体を起動・停止・再起動・削除できる
- VMのサイズをあとから変更できる。
- VM拡張機能を使うことができる。例えば「カスタムスクリプト拡張機能」を使って、VMインスタンスにソフトウェアをインストールしたりすることができる。

■スケールセットの種類（オーケストレーション モード）

「均一（ユニフォーム）」と「フレキシブル」の2種類がある。

均一（ユニフォーム）スケールセット
https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview?context=/azure/virtual-machines/context/context

- 同一インスタンス(例: OSは1種類のみ）
- 個々の均一 VM インスタンスは、仮想マシン スケール セット VM API コマンドを介して公開

フレキシブル スケールセット
https://docs.microsoft.com/ja-jp/azure/virtual-machines/flexible-virtual-machine-scale-sets

- 同一または複数の仮想マシンの種類を使用(例: OSはWindows/Linux混在可）
- 標準 VM API を使用

■インスタンス

- VMSSに含まれる個々のVMを「インスタンス」と呼ぶ

■インスタンスID

VMSSに含まれる個々のインスタンスを区別する番号。

基本的に0, 1, 2, 3, ... と連番で振られていく。IDの振り直しはできない。

※[「オーバープロビジョニング」](https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-design-overview#overprovisioning)により、実際に要求された数よりも多くの VMインスタンス を起動し、要求された数の VMインスタンス が正常にプロビジョニングされた後で余分な VMインスタンス を削除することで、デプロイの成功率向上、デプロイ時間短縮を行う仕組みが備わっている（無効にすることもできる）。これにより、たとえば2つのVMインスタンスを要求した場合、一時的に 0, 1, 2, 3 が起動され、すぐに 1, 2 が削除され、結果的に 0, 3 という不連続なインスタンスIDがVMSSに残る場合があるので注意。オーバープロビジョニングによって追加の請求が発生することはなく、クォータ制限にカウントされることもない。

※注意: VMSSのオーバープロビジョニングは、[CPUのオーバープロビジョニング（オーバーコミット）](https://www.google.com/search?q=vCPU+%E3%82%AA%E3%83%BC%E3%83%90%E3%83%BC%E3%83%97%E3%83%AD%E3%83%93%E3%82%B8%E3%83%A7%E3%83%8B%E3%83%B3%E3%82%B0)（実際に搭載している物理的CPUよりも多くの仮想CPUをVMに割り当てる）、[SSDのオーバープロビジョニング](https://www.google.com/search?q=SSD+%E3%82%AA%E3%83%BC%E3%83%90%E3%83%BC%E3%83%97%E3%83%AD%E3%83%93%E3%82%B8%E3%83%A7%E3%83%8B%E3%83%B3%E3%82%B0)（SSDの耐久性やパフォーマンスを高める）などとは無関係。

■初期インスタンス数

VMSS作成時に指定する、スケールセットに含まれるインスタンスの数。

■手動スケーリング

VMSS作成後、「スケーリング」の「インスタンス数」でインスタンス数を手動で調節できる。

■自動スケーリング

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-autoscale-overview

インスタンスの数を自動的に増減させることができる。


■スケーリングに使用するメトリック

- ホスト メトリック
  - 追加のエージェント等を構成する必要がない
- パフォーマンス メトリック
  - VM インスタンスで Azure Diagnostics 拡張機能をインストールして構成する
  - または、App Insights を使用してアプリケーションを構成する


■スケールインポリシー

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-scale-in-policy

- Default
  - 可用性ゾーン間で仮想マシンを均衡させる
  - 障害ドメイン間で仮想マシンを均衡させる
  - インスタンス ID が最も大きい仮想マシンを削除
- NewestVM
  - 可用性ゾーン間で仮想マシンを均衡させる
  - 最も新しく作成された仮想マシンを削除
- OldestVM
  - 可用性ゾーン間で仮想マシンを均衡させる
  - 最も古く作成された仮想マシンを削除

```
# スケールインポリシーをOldestVMに設定する例
az vmss update \  
  --resource-group <myResourceGroup> \
  --name <myVMScaleSet> \
  --scale-in-policy OldestVM
```

■スケジュールに基づく自動スケール

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-autoscale-overview?context=/azure/virtual-machines/context/context#scheduled-autoscale

- 決まった時間に VM インスタンスの数を自動的にスケールできる。
- 月曜日の早朝にスケールアウトし、金曜日の深夜にスケールインする等の運用が可能


■アプリケーションの正常性拡張機能 ※均一（ユニフォーム）のみ

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-health-extension

- VMの拡張機能の一種。インスタンスに追加される。
- **VMの内部から** アプリケーションの正常性をチェックする。
- TCP, HTTP, HTTPSのいずれかを使用。
- 「ApplicationHealthWindows」と「ApplicationHealthLinux」

■自動インスタンス修復 ※均一（ユニフォーム）のみ

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-automatic-instance-repairs

正常ではないインスタンスを削除し、新しいインスタンスに置き換える機能。

- 「アプリケーションの正常性の監視」を有効化する。以下のいずれかを有効にする（1つだけ有効にできる）
  - アプリケーション正常性拡張機能
    - **VMの内部から** 接続して、正常性をチェック
  - [Load Balancerの正常性プローブ](https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-custom-probe-overview)
    - **ロードバランサー（168.63.129.16）から** 接続して、正常性をチェック
- アプリケーションのエンドポイントを構成する。エンドポイントにアクセスされた際に、200 OKを返す必要がある。


■配置グループ(Placement groups)

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-placement-groups

**配置グループは、可用性セットに似た構造で、独自の障害ドメインと更新ドメインが備わっている。**

VMSSは「1つの配置グループ」または「複数の配置グループ」で構成される。

- 1つの配置グループ
  - 0～100個のVM
  - デフォルト
  - singlePlacementGroup=true
- 複数の配置グループ
  - 0～1000個のVM
  - singlePlacementGroup=false

仮想マシン スケール セットで 100 個を超える VM にスケーリングできるようにするには、スケール セット モデルで singlePlacementGroup プロパティを false に変更する必要がある。

```
az vmss update -g rg -n vmss2 --set singlePlacementGroup=false
```

※[「スケールセットモデル」](https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#the-scale-set-model): スケールセットの設定（プロパティ）。

■状態（プロパティ）の更新

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#how-to-update-global-scale-set-properties

VMSSや、VMSS内の個々のインスタンスの設定を変更することができる。

```
# VMSSのプロパティの更新
az vmss update --set {propertyPath}={value}
az vmss update --add {propertyPath} {JSONObjectToAdd}
az vmss update --remove {propertyPath} {indexToRemove}

# VMSS内の個々のインスタンスのプロパティの更新
az vmss update --instance-id NNN --set {propertyPath}={value}
az vmss update --instance-id NNN --add {propertyPath} {JSONObjectToAdd}
az vmss update --instance-id NNN --remove {propertyPath} {indexToRemove}
```


■モデルビュー

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#the-scale-set-model

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#the-scale-set-vm-model-view

VMSSまたはVMSS内の個々のVMインスタンスの「望ましい状態（プロパティ）」。

```
# VMSSのモデルビューの取得
az vmss show

# VMSS内の個々のインスタンスのモデルビューの取得
az vmss show --instance-id NNN
```

■インスタンスビュー

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#the-scale-set-instance-view

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#the-scale-set-vm-instance-view

VMSSまたはVMSS内の個々のVMインスタンスの「現在の状態（プロパティ）」

```
# VMSSのインスタンスビューの取得
az vmss get-instance-view

# VMSS内の個々のインスタンスのインスタンスビューの取得
az vmss get-instance-view --instance-id NNN
```

■VMSS内の個々のインスタンスの「アップグレード ポリシー」

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-upgrade-scale-set#how-to-bring-vms-up-to-date-with-the-latest-scale-set-model

- 自動: 各VMはランダムなタイミングで自動的に更新される
- ローリング: バッチでロールアウト。
- 手動: 各VMは「az vmss update-instances --instance-ids NNN」等で個々にアップグレードする

```
# アップグレード ポリシーの変更例 (Automatic, Manual, Rollingのいずれかを指定)
az vmss update -g rg -n vmss2 --set upgradePolicy.mode=Automatic

# ローリングアップグレードの開始
az vmss rolling-upgrade start --resource-group myResourceGroup --name myScaleSet

# 指定したVMを手動でアップグレード
az vmss update-instances --resource-group myResourceGroup --name myScaleSet --instance-ids
```

■アプリのデプロイ例

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/tutorial-install-apps-cli#update-app-deployment

アップグレードポリシー「自動」の例。

「カスタム スクリプト拡張機能」を使い、VMSSのVMインスタンスに[最初のスクリプト](https://raw.githubusercontent.com/Azure-Samples/compute-automation-configurations/master/automate_nginx.sh)をデプロイ。その後、[次のスクリプト](https://raw.githubusercontent.com/Azure-Samples/compute-automation-configurations/master/automate_nginx_v2.sh)）をデプロイ。

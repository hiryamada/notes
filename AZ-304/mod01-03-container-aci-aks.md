# AKS vs ACI 

- [Azure Kubernetes Service (AKS)](https://docs.microsoft.com/ja-jp/azure/aks/intro-kubernetes)
- [Azure Container Instance (ACI)](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview)

- コンテナーのオーケストレーションが必要な場合は、AKSを使用する。
  - 複数のコンテナー間でのサービス検索（サービスディスカバリー）
  - 自動スケーリング
  - アプリケーションの調整されたアップグレード
  - など
- オーケストレーションが不要な場合は、ACIを使用する。

# App Service for Containers

https://docs.microsoft.com/ja-jp/dotnet/architecture/cloud-native/other-deployment-options

# AKSでの「仮想ノード」の利用

https://docs.microsoft.com/ja-jp/azure/aks/virtual-nodes

2018/12/4 パブリック プレビュー
https://azure.microsoft.com/ja-jp/blog/bringing-serverless-to-azure-kubernetes-service/

2019/5/6 一般提供
https://azure.microsoft.com/ja-jp/updates/azure-kubernetes-service-aks-virtual-node-is-now-available/

AKS クラスターでアプリケーション ワークロードをすばやくスケーリングするには、仮想ノードを使用する。

仮想ノードでは、追加のポッドをACI上に短時間でプロビジョニングできる。

VM ベースの追加ノードが起動するまで待つことなく、必要な数の追加コンテナーを厳密に割り当てることで、需要の急上昇に数秒で対応することができる。

ポッドの実行時間に対して秒単位の支払いだけで済む。

仮想ノードは、Linux のポッドとノードでのみサポート。

解説動画: Go serverless: Containers with Kubernetes and virtual nodes | Azure Friday （英語）
https://www.youtube.com/watch?v=jGMaI7dKUgo

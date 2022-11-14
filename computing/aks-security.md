# Azure Kubernetes Serviceのセキュリティ


https://learn.microsoft.com/ja-jp/azure/aks/concepts-security

■AKSクラスターのノード（OS）バージョンを最新化する（OSの更新プログラムを適用する）

https://learn.microsoft.com/ja-jp/azure/aks/node-updates-kured

クラスターを保護するために、AKS のノードにセキュリティ更新プログラムが自動的に適用される。

これらの更新プログラムの中には、プロセスを完了するためにノードの再起動が必要なものがある。 AKS は、更新プロセスを完了するためにこれらの Linux ノードを自動的に再起動しない。

■AKSクラスターのKubernetesバージョンを最新化する

Azure Kubernetes Service (AKS) クラスターの「アップグレード」により、新しいバージョンをインストールできる。
https://learn.microsoft.com/ja-jp/azure/aks/upgrade-cluster?tabs=azure-cli

■「Microsoft Defender for Cloud」の有料プラン「Microsoft Defender for Containers」を有効化する

https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-containers-introduction

- Azure/AWS/GCP/オンプレミスの Kubernetes クラスターの継続的な監視
- データ プレーンのセキュリティ強化: Kubernetes API サーバーに対するすべての要求を、事前定義された一連のベスト プラクティスを基準にして監視


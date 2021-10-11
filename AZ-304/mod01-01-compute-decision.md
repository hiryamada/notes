# コンピューティング サービスの選択

■Azureの主なコンピューティング サービス

- [Azure App Service](https://docs.microsoft.com/ja-jp/azure/app-service/overview)
- [Azure Spring Cloud](https://docs.microsoft.com/ja-jp/azure/spring-cloud/overview)
- [Azure Kubernetes Service (AKS)](https://docs.microsoft.com/ja-jp/azure/aks/intro-kubernetes)
- [Azure Batch](https://docs.microsoft.com/ja-jp/azure/batch/batch-technical-overview)
- [Azure Container Instance (ACI)](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview)
- [Azure Functions](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview)
- Azure Virtual Machines (Azure VM)
  - [Windows VM](https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/overview)
  - [Linux VM](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/overview)
- [Azure Service Fabric](https://docs.microsoft.com/ja-jp/azure/service-fabric/service-fabric-overview)

■コンピューティング サービスの選択

```
Microsoft Docs
└Azureアーキテクチャ センター
 └アプリケーション アーキテクチャ ガイド
  └テクノロジの選択
   └コンピューティング サービスの選択
```

コンピューティング サービスの選択
https://docs.microsoft.com/ja-jp/azure/architecture/guide/technology-choices/compute-decision-tree

フローチャートを使用して、候補となるコンピューティング サービスを選択することができる。

- オンプレで動いているアプリケーションをリフトアンドシフトする場合: 
  - App Service, VM, AKS などが検討対象となる
- クラウドで運用することを前提に、アプリケーションを新規開発する場合: 
  - 上記サービスに加え、Azure Batch, Azure Functions, ACI, Azure Service Fabric なども検討対象となる

※リフトアンドシフト: アプリケーションの再設計やコード変更なしで、ワークロードをクラウドに移行する戦略


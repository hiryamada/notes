# コンピューティング サービスの選択

■Azureの主なコンピューティング サービス

IaaS(仮想マシン):
- Azure Virtual Machines (Azure VM)
  - [Windows VM](https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/overview)
  - [Linux VM](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/overview)

PaaS:
- [Azure App Service](https://docs.microsoft.com/ja-jp/azure/app-service/overview)
  - Webアプリのホスティング
  - PaaSサービス - .NET、.NET Core、Java、Ruby、Node.js、PHP、Pythonをサポート
  - デプロイスロット
  - 手動/自動スケーリング（スケールアウト、スケールイン）
  - バックアップ
  - Dockerコンテナーのデプロイも可能。
- [Azure Spring Cloud](https://docs.microsoft.com/ja-jp/azure/spring-cloud/overview)
  - [Spring Cloud](https://spring.pleiades.io/projects/spring-cloud)のAzure版
  - Springアプリケーション開発者のためのPaaSサービス
  - Spring Bootアプリケーション(Java)をサポート
  - Steeltoe アプリケーション(.NET/C#)をサポート(パブリックプレビュー)
  - リアルタイムのログのストリーミング
  - ブルーグリーンデプロイをサポート

FaaS(Function as a Service):
- [Azure Functions](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview)
  - サーバーレス - コンピューティングリソースをオンデマンドで提供
  - イベントの処理 - 多数のAzureサービスと連携
  - C#、Java、JavaScript、PowerShell、Python、TypeScriptなどを利用できる

コンテナー型仮想化:
- [Azure Container Instance (ACI)](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview)
  - Azureですばやく簡単にコンテナーを稼働させることができるサービス
  - シンプルなタスクの実行向け
- [Azure Kubernetes Service (AKS)](https://docs.microsoft.com/ja-jp/azure/aks/intro-kubernetes)
  - AzureでKubernetesクラスターをホスティングするサービス
- [Azure Service Fabric](https://docs.microsoft.com/ja-jp/azure/service-fabric/service-fabric-overview)
  - マイクロサービス向けに開発された、Microsoftのコンテナーオーケストレーター
  - Microsoft サービスを大規模に実行することで学んだ教訓を活用できる
    - Intune、Skype for Business、Power BI、Azure Event Hubs等での利用実績
  - 開発からデプロイ、日常的な管理、保守、最終的な使用停止に至るまでの完全な CI/CD のサポート
  - Service Fabric のクラスターをオンプレミス、Azure、他のクラウドに作成可能
  - Linux/Windowsのコンテナーアプリケーションに対応

バッチ（大規模な並列処理、HPC）:
- [Azure Batch](https://docs.microsoft.com/ja-jp/azure/batch/batch-technical-overview)
  - 数十、数百、数千個のコンピューティング ノード (仮想マシン) からなるプールを作成・管理
  - 大規模な並列処理を実行
    - 多数の画像の処理、レンダリング
      - Autodesk Maya、3ds Max、Arnold、V-Ray などのレンダリング ツールでの大規模なレンダリング ワークロードをサポート
    - メディアの変換、エンコーディング
    - シミュレーション
    - 遺伝子解析
  - 2015/7/9 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-batch-generally-available/

VMware:
- [Azure VMware Solution](https://azure.microsoft.com/ja-jp/services/azure-vmware/)
  - オンプレミスの VMware 環境を Azure に移行
  - vSphere VM を作成して管理
  - 既にお使いの VMware ツール (vSphere クライアント、NSX-T、Power CLI等) を引き続き使用して、環境を管理

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


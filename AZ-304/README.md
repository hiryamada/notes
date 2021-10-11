# AZ-304: Microsoft Azure Architect **Design**

4日間

コース目標: ソリューションアーキテクトとして、多数のAzureテクノロジの中から、適切なテクノロジを「推奨」できること。適切なテクノロジを選択し、さまざまなソリューションを「設計」できること。（Recommend/Design a solution for compute / storage / network ...）

※対になるコース: AZ-304: Microsoft Azure Architect **Technologies**

コース情報: https://docs.microsoft.com/ja-jp/learn/certifications/courses/az-304t00

認定試験: https://docs.microsoft.com/ja-jp/learn/certifications/exams/az-304

■モジュール

全14モジュール。目安として、1日に約4モジュールのペースで解説。

- Module 1 コンピューティング ソリューションを設計する
  - [適切なCompute Service の選択](mod01-01-compute-decision.md)
  - [適切なコンピューティング テクノロジーの決定](mod01-02-microservice.md)
  - [コンテナーのソリューション(AKS vs ACI)](mod01-03-container-aci-aks.md)
  - [Compute Infrastructure のプロビジョニング](mod01-04-provisioning.md)
- Module 2 ネットワーク ソリューションを設計する
  - 仮想ネットワークの設計
  - ネットワーク アドレッシングと名前解決のソリューション
  - ネットワーク セキュリティのソリューション
  - ハイブリッド ネットワーク
- Module 3 移行を設計する
  - Azure Migrate
  - Azure Database Migration Service
  - AzCopy
  - ラボ 3 Azure Migrateを 使用した Hyper-V VM の Azure への移行
- Module 4 認証と承認を設計する
  - ID およびアクセス管理
  - 多要素認証のソリューション
  - ID インフラストラクチャをセキュリティ保護するステップ
  - シングル サインオン (SSO) のソリューション
  - ハイブリッド ID のソリューション
  - B2B 統合のためのソリューション
  - 管理グループ、サブスクリプション、リソース グループ
  - ラボ 4 Azure AD の認証と承認の管理
- Module 5 ガバナンスを設計する
  - ガバナンス
  - Azure Policy
  - Azure Blueprints
- Module 6 データベースのソリューションを設計する
  - 適切なデータ プラットフォームの選択
  - Azureのデータストレージ
  - Azure SQL Database
  - 保存、送信、使用中のデータを暗号化するためのソリューション
  - ラボ 6 Azure SQL Database ベースのアプリケーション を実装する
- Module 7 適切なストレージ アカウントを選択する
  - ストレージ層
  - ストレージ管理ツール
- Module 8 データ統合を設計する
  - Azure データ プラットフォーム
  - データ統合のためのソリューション
  - Data Warehouse とビッグ データ分析の統合のためのソリューション
- Module 9 ロギングと監視のソリューションを設計する
  - モニタリング
  - Azure Monitor
- Module 10 バックアップとリカバリのソリューションを設計する
  - 信頼性のためのアーキテクチャのベストプラクティス
  - Azure Site Recovery
  - データのアーカイブとリテンション
- Module 11 高可用性用の設計
  - 高可用性設計
  - ディザスター リカバリーを処理する HA アプリケーション
- Module 12 コスト最適化を設計する
  - コスト管理のソリューション
  - コストを最小限に抑えるための推奨事項
  - コスト最適化チェックリスト
- Module 13 アプリケーション アーキテクチャを設計する
  - Azure でのイベントベースのクラウド オートメーション
  - Azure Service Fabric でのマイクロサービス アーキテクチャ
  - マイクロサービス用の API の設計
  - ラボ 13 Azure Event Grid を使用して Azure Logic Apps の統合を実装する
- Module 14 アプリケーションのセキュリティを設計する
  - アプリケーションとサービスのセキュリティ
  - Azure Key Vault
  - マネージドID


■ハンズオン ラボ（演習）: Module 3, 4, 6, 13の4ラボのみ。

日本語
- 手順書: https://microsoftlearning.github.io/AZ-304JA-Microsoft-Azure-Architect-Design/
- ラボファイル: https://github.com/MicrosoftLearning/AZ-304JA-Microsoft-Azure-Architect-Design/archive/refs/heads/master.zip

英語
- 手順書: https://microsoftlearning.github.io/AZ-304-Microsoft-Azure-Architect-Design/
- ラボファイル: https://github.com/MicrosoftLearning/AZ-304-Microsoft-Azure-Architect-Design/archive/refs/heads/master.zip

■ Azureアーキテクチャ センター

確立されたパターンと手法を使用して Azure でソリューションを設計するためのドキュメント。多数の有用なガイド、ベストプラクティス、基本原則、パターン集などで構成される。

本コース（AZ-304）でもこのドキュメントを頻繁に参照する。

```
Microsoft Docs
└Azureアーキテクチャ センター
 └アプリケーション アーキテクチャ ガイド
```

Azureアーキテクチャ センター
https://docs.microsoft.com/ja-jp/azure/architecture/

アプリケーション アーキテクチャ ガイド
https://docs.microsoft.com/ja-jp/azure/architecture/guide/

クラウド アプリケーションのベスト プラクティス
https://docs.microsoft.com/ja-jp/azure/architecture/best-practices/index-best-practices

Microsoft Azure Well-Architected Framework
https://docs.microsoft.com/ja-jp/azure/architecture/framework/

クラウド設計パターン
https://docs.microsoft.com/ja-jp/azure/architecture/patterns/

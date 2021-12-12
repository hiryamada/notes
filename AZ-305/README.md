# AZ-305: Designing Microsoft Azure Infrastructure Solutions

4日間

コース目標: ソリューションアーキテクトとして、多数のAzureテクノロジの中から、適切なテクノロジを「推奨」できること。適切なテクノロジを選択し、さまざまなソリューションを「設計」できること。（Recommend/Design a solution for compute / storage / network ...）

コース情報: https://docs.microsoft.com/ja-jp/learn/certifications/courses/az-305t00

認定試験: https://docs.microsoft.com/en-us/learn/certifications/exams/az-305  2021/11/16～受験可能

[AZ-305のアナウンス(Microsoft Learn Blob)](https://techcommunity.microsoft.com/t5/microsoft-learn-blog/reimagining-the-azure-solutions-architect-expert-certification/ba-p/2813695)

■対応する資格

[Microsoft Certified: Azure Solutions Architect Expert](https://docs.microsoft.com/en-us/learn/certifications/azure-solutions-architect/)

認定条件: 以下のいずれか

- Microsoft Certified: Azure Administrator Associate(AZ-104) + AZ-305
- Exam AZ-303 (2022/3/31 廃止) と Exam AZ-304 (2022/3/31 廃止)
- AZ-303 (2022/3/31 廃止) と Exam AZ-305

[移行期間中の対応方法](https://techcommunity.microsoft.com/t5/microsoft-learn-blog/reimagining-the-azure-solutions-architect-expert-certification/ba-p/2813695):

- 試験 AZ-303 と 試験 AZ-304 の受験準備ができている場合
  - AZ-303/AZ-304を受験してください（2022/3/31まで）
- 試験 AZ-303 に合格済みの場合
  - AZ-305 を受験してください。または、
  - AZ-304を受験してください（2022/3/31まで）
- 試験 AZ-304 に合格済みの場合
  - AZ-303を受験してください（2022/3/31まで）
- 試験 AZ-303 または試験 AZ-304 の準備を始めたばかりの場合
  - Azure 管理者アソシエイト認定資格を取得し、 AZ-305 試験を受験してください。

■モジュール(AZ-305)

- Day 1: 
  - Module 1: ガバナンスとコンピューティング ソリューションを設計する
    - Lesson 1: ガバナンスを設計する
    - Lesson 2: コンピューティング ソリューションを設計する
- Day 2: 
  - Module 2: Design storage and data integration solutions 
    - Lesson 1: 非リレーショナルデータのストレージソリューションを設計する
    - Lesson 2: リレーショナルデータのストレージソリューションを設計する
    - Lesson 3: データの統合を設計する
- Day 3: 
  - Module 3: アプリケーションのアーキテクチャとモニタリングを設計する
    - Lesson 1: アプリケーションのアーキテクチャを設計する
    - Lesson 2: 認証と承認のソリューションを設計する
    - Lesson 3: Azureリソースのログとモニタリングのソリューションを設計する
- Day 4: 
  - Module 4: ネットワークと事業継続計画を設計する
    - Lesson 1: ネットワークソリューションを設計する
    - Lesson 2: バックアップとディザスタリカバリーを設計する
    - Lesson 3: 移行を設計する

■ラボ（ケーススタディ）

https://github.com/MicrosoftLearning/AZ-305-DesigningMicrosoftAzureInfrastructureSolutions/

■モジュール(AZ-304)

全14モジュール。目安として、1日に約4モジュールのペースで解説。

- 1日目
  - オープニング・環境準備
  - [モジュール 1 コンピューティング ソリューションを設計する](mod01.md)
  - [モジュール 2 ネットワーク ソリューションを設計する](mod02.md)
  - [モジュール 3 移行を設計する](mod03.md)
  - ラボ3
- 2日目
  - [モジュール 4 認証と承認を設計する](mod04.md)
  - [モジュール 5 ガバナンスを設計する](mod05.md)
  - [モジュール 6 データベースのソリューションを設計する](mod06.md)
  - [モジュール 7 適切なストレージ アカウントを選択する](mod07.md)
  - ラボ4
- 3日目
  - [モジュール 8 データ統合を設計する](mod08.md)
  - [モジュール 9 ロギングと監視のソリューションを設計する](mod09.md)
  - [モジュール 10 バックアップとリカバリのソリューションを設計する](mod10.md)
  - ラボ6
- 4日目
  - [モジュール 11 高可用性用の設計](mod11.md)
  - [モジュール 12 コスト最適化を設計する](mod12.md)
  - [モジュール 13 アプリケーション アーキテクチャを設計する](mod13.md)
  - [モジュール 14 アプリケーションのセキュリティを設計する](mod14.md)
  - ラボ13
  - クロージング

■ハンズオン ラボ（演習）(AZ-304)

モジュール 3, 4, 6, 13の4ラボのみ。

[lab.md](lab.md)

■Azureアーキテクチャ センター

確立されたパターンと手法を使用して Azure でソリューションを設計するためのドキュメント。ガイド、ベストプラクティス、基本原則、パターン集など。

```
Microsoft Docs
└Azureアーキテクチャ センター
 ├アプリケーション アーキテクチャ ガイド
 ├Microsoft Azure Well-Architected Framework
 ├クラウド設計パターン
 ├Azureを使用した業界ソリューション（小売、金融、医療・・・）
 ├Azureのカテゴリ(コンピュート、データベース・・・)
 └クラウド導入フレームワーク(CAF)
```

Azureアーキテクチャ センター(AAC)
https://docs.microsoft.com/ja-jp/azure/architecture/

アプリケーション アーキテクチャ ガイド
https://docs.microsoft.com/ja-jp/azure/architecture/guide/

クラウド アプリケーションのベスト プラクティス
https://docs.microsoft.com/ja-jp/azure/architecture/best-practices/index-best-practices

Microsoft Azure Well-Architected Framework（一連の基本原則。信頼性、セキュリティ、コスト最適化、オペレーショナル・エクセレンス、パフォーマンス効率の5つの柱からなる）
https://docs.microsoft.com/ja-jp/azure/architecture/framework/

クラウド設計パターン
https://docs.microsoft.com/ja-jp/azure/architecture/patterns/

■クラウド導入フレームワーク(CAF)

Cloud Adoption Framework (CAF)

https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/overview

クラウドのビジネス戦略とテクノロジ戦略を作成して実装するのに役立つガイダンス。

- [ベスト プラクティス](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/)、ドキュメント、ツールが含まれる
- [Azureセットアップガイド](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-setup-guide/)
- [Azure移行ガイド](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/migrate/azure-migration-guide/?tabs=MigrationTools)
- [ガバナンスガイド](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/)
- [管理ガイド](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/manage/)
- [セキュリティ](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/secure/)
- [ツールとテンプレート](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/resources/tools-templates)


■「基礎」(fundamentals)のドキュメント

Azureのセキュリティの基礎
https://docs.microsoft.com/ja-jp/azure/security/fundamentals/

Azureネットワークの基礎
https://docs.microsoft.com/ja-jp/azure/networking/fundamentals/

Azure Active Directoryの基礎
https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/

Azureデータの基礎(Microsoft Learn)
https://docs.microsoft.com/ja-jp/learn/paths/azure-data-fundamentals-explore-core-data-concepts/

■セキュリティのドキュメント

Microsoft セキュリティのベスト プラクティス ※旧称 「Azure セキュリティ コンパス」または 「Microsoft セキュリティ コンパス」
https://docs.microsoft.com/ja-jp/security/compass/compass

■Student Materials

https://aka.ms/AZ-305StudentMaterials

AZ-305関連のMicrosoft Learnコレクション。


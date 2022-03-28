# CAF 重要ポイントまとめ

★: 重要ポイント

- ★CAFのステージ（段階）
  - (1)CCoEの構成
  - (2)戦略定義 - Define Strategy
  - ★(3)計画 - Plan
  - ★(4)準備(導入準備) - Ready
  - ★(5)導入(採用) - Adopt (Migrate / Innovate)
  - (6)統制管理 - Govern
  - (7)管理 - Manage
- **★「(3)計画」「(4)準備」「(5)導入」は、CAFにおける主要ステージ（段階）である**
- [「(2)戦略定義」における「動機」](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/strategy/motivations)
  - クラウドに移行する動機（理由、トリガー）の種類
    - (1)移行
      - 例: オンプレミスのサーバーを廃止してコストを節約したい
    - ★(2)革新（イノベーション）
      - ★製品またはサービスの変革
        - 例: AIを活用したサービスを提供したい
- ★[(6)クラウドガバナンス (統制管理) で考慮すべきこと（クラウド ガバナンスの 5 つの規範）](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/methodology#envision-an-end-state)
  - ★[コスト管理](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/cost-management/)
  - ★[セキュリティ ベースライン](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/security-baseline/)
  - ★[リソースの整合性](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/resource-consistency/)
  - ★[ID ベースライン](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/identity-baseline/)
  - ★[デプロイの高速化](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/govern/deployment-acceleration/)
- ★[クラウドコンピューティングにおける「スケール」（スケーラビリティ）とは](https://azure.microsoft.com/ja-jp/overview/scaling-out-vs-scaling-up/#overview)
  - ★適切な量の IT リソースを提供する能力
    - 例: VMのサイズを変更（スケールアップ・スケールダウン）
    - 例: VMの数を増減（スケールアウト・スケールイン）
  - クラウドは、オンプレミスよりもスケーラビリティに優れている
- ★コスト管理に使用できるツール
    - [Azure総保有コスト（TCO）計算ツール](https://azure.microsoft.com/ja-jp/pricing/tco/calculator/) - オンプレからクラウドへ移行した場合の料金を試算
    - ★[Azure料金計算ツール](https://azure.microsoft.com/ja-jp/pricing/calculator/) - 毎月のサービス利用額の見積もり
    - [Azure Cost Management](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/understand/plan-manage-costs#costs) - 現在のコストおよび推定コストを管理（Azure portal内）

# CAF 知識チェック

[知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-cloud-adoption-framework-for-azure/8-knowledge-check)


# CAF その他の参考資料

CAF 戦略フェーズ オンデマンドセミナー (日本マイクロソフト廣瀬一海氏)
https://note.microsoft.com/JA-NOGEP-WBNR-FY21-01Jan-07-CAF202011-SRDEM56540_Registration.html

CAFに取り掛かる際にはじめに実施すること
https://cloudsteady.jp/post/31815/

CAFに基づいてクラウド移行を支援するのに十分な体制と技術力を備えているパートナー（AZPowerさん）
- https://special.nikkeibp.co.jp/atclh/NXT/20/microsoft1223/
- https://www.cloud-for-all.com/resource/utilization-caf-and-azure-migrate

スタートアップだからこそ知っておきたいCloud Adoption Framework
- 前編 https://www.wantedly.com/companies/alterbooth/post_articles/350103
- 後編 https://www.wantedly.com/companies/alterbooth/post_articles/350107

UnifyCloudを活用したAzureコンサルティングサービス（CAF準拠）（TIS株式会社さん）
https://azuremarketplace.microsoft.com/en-us/marketplace/consulting-services/tis1594774280104.sol-52874-ory?tab=Overview

実は壮大なる“しくじり大全”
MSのヒアリング結果をまとめたクラウド導入のためのフレームワーク「Cloud Adoption Framework」
https://logmi.jp/tech/articles/324462

3大パブリッククラウドのクラウド導入ベストプラクティスを読んでみた
https://dev.classmethod.jp/articles/cloud-adoption-framework-on-each-clouds/

あいまいなクラウド移行の道筋を具体的な戦略と方策に落とし込む。ベストプラクティスに基づいたガイダンス「Microsoft Cloud Adoption Framework for Azure」のポイント
https://zine.qiita.com/topics/202102-caf-waf-1/

Azure運用に便利な「Microsoft Cloud Adoption Framework for Azure」
https://www.pc-webzine.com/entry/2021/09/azuremicrosoft-cloud-adoption-framework-for-azure.html

Cloud Adoption Frameworkon Azure実践トレーニング（株式会社オルターブースさん）
https://www.alterbooth.com/products/training/lp/cafc01.html

Cloud Adoption Framework (CAF) チョークトーク
https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fwww.microsoftevents.com%2Fprofile%2F12333946&data=04%7C01%7Cv-yuluo%40microsoft.com%7C9e7e40f2a34a4e4762d108d955706a08%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C637634763766151673%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C1000&sdata=gStMP%2B3o8P8Ql0eKOWK05b1M8AoafxSv602hTL%2FIkng%3D&reserved=0

Cloud Adoption Framework 全体像と、6つのステージ解説 (2021年6月)
https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fnote.microsoft.com%2FCatalogueDisplayPage-SRDEM79545_CatalogDisplayPage.html&data=04%7C01%7Cv-yuluo%40microsoft.com%7C9e7e40f2a34a4e4762d108d955706a08%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C637634763766241622%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C1000&sdata=FwGn4oSRC8l8W2y4NnZnAIfEcRbT%2FiWPdzcjDTkseiU%3D&reserved=0

Cloud Adoption Framework（CAF）を活用したクラウド移行のポイント
https://www.cloud-for-all.com/blog/cloud-adoption-framework

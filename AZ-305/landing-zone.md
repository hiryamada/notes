# Azure ランディング ゾーン

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/landing-zone/

8つの「設計領域」(design areas)にわたる「設計原則」(key design principles)に準拠した「環境」。

端的に言えば、ランディングゾーンとは、Azureのベストプラクティスに従った、サブスクリプション（の設計と実装）である。https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/enterprise-scale/faq#what-does-a-landing-zone-map-to-in-azure-in-the-context-of-azure-landing-zone-architecture

## 利用例

https://cloudsteady.jp/2021/03/31/37251/


## CAFとの関係

Microsoft Azure Cloud Adoption Framework（Microsoft Azure クラウド導入フレームワーク）は、組織がクラウドを導入するためのベストプラクティス集。

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/overview

- Strategy
- Plan
- Ready（準備フェーズ）
- Adopt
- Govern
- Manage

の6段階で構成される。

「Azure ランディング ゾーン」はCAFの「Ready」（準備フェーズ）に含まれる。

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/

## 8つの「設計領域」

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/landing-zone/#azure-landing-zone-architecture

1. Azure 課金と Azure Active Directory テナント (A)
2. ID とアクセス管理 (B)
3. リソース組織 (C)
4. ネットワーク トポロジと接続 (E)
5. セキュリティ (F)
6. 管理 (D、G、H)
7. ガバナンス (C、D)
8. プラットフォーム自動化と DevOps (I) 

## 設計原則

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/landing-zone/design-principles

開発者がターゲット アーキテクチャの最適な設計を目指すのに役立つ、設計原則が説明されている。

この設計原則から逸脱する理由、逸脱した場合にどのような影響があるかも示されている。

## サブスクリプション

「Azure ランディング ゾーン」では、複数のサブスクリプションを使用する。

アプリケーションのリソース用のサブスクリプションと、プラットフォームのリソース用のサブスクリプションを使用して、リソースを分離して管理する。

アプリケーション リソースのサブスクリプションは「アプリケーション ランディング ゾーン」と呼ばれる。

プラットフォーム リソースのサブスクリプションは「プラットフォーム ランディング ゾーン」と呼ばれる。


## Azure ランディング ゾーン アクセラレータ

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/landing-zone/#azure-landing-zone-accelerators

「Azure ランディング ゾーン」を適切な方法でデプロイするのに役立つ、IaC（Blueprint, Bicep, Terraform等）による「実装」。

以下のページから参照できる。

https://learn.microsoft.com/ja-jp/azure/architecture/landing-zones/landing-zone-deploy#application

## 準備

https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/suggested-skills

組織がAzure ランディング ゾーンを使用するためにどのような準備（学習）が必要かが説明されている。

## 参考: その他のクラウドの「ランディングゾーン」

- AWS: https://docs.aws.amazon.com/ja_jp/prescriptive-guidance/latest/migration-aws-environment/understanding-landing-zones.html
- Google Cloud: https://cloud.google.com/architecture/landing-zones?hl=ja
- Alibaba Cloud: https://www.alibabacloud.com/ja/services/alibaba-cloud-landing-zone
- Oracle Cloud: https://docs.oracle.com/ja-jp/iaas/Content/cloud-adoption-framework/landing-zone.htm


## 参考: その他の「ランディングゾーン」

HDD(ハードディスクなどにおいて、電源オフ時にヘッドを待避させておく領域)
https://japan.zdnet.com/glossary/exp/%E3%83%A9%E3%83%B3%E3%83%87%E3%82%A3%E3%83%B3%E3%82%B0%E3%82%BE%E3%83%BC%E3%83%B3/?s=1

軍事(前線でヘリコプターやVTOL機・転換式航空機を着陸させるため、一時的に確保した場所)
https://www.weblio.jp/content/LZ

医療
https://www.ncvc.go.jp/hospital/section/cvs/vascular/pro01-3/

ゴルフ
https://www.jsgca.com/05_column/gm2004-10.html

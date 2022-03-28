
# クラウド導入フレームワーク for Azure

Cloud Adoption Framework for Azure

※以下、「CAF」と表記

- Microsoft が提供する実証済みのガイダンスであるドキュメント、実装ガイド、ベスト プラクティス、ツールのコレクション
- クラウド アーキテクト、IT プロフェッショナル、ビジネス上の意思決定者（デシジョンメーカー）が短期的および長期的な目標を達成するために必要なベスト プラクティス、ドキュメント、ツールを提供する
- CAFを活用することで、組織はビジネスおよび技術的な戦略を適切に調整して確実に成功を収めることができる
- ビジネス目標の実現、組織の準備、クラウド移行と最適化を支援する。

ドキュメント
https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/

概要
https://azure.microsoft.com/ja-jp/overview/cloud-enablement/cloud-adoption-framework/

CAFの目次 リンクまとめ
https://qiita.com/hoisjp/items/9e40eb5d1e500f6cf74d


## 参考: Cloud Adoption Framework の読み方

※以下の動画では「クラウドアダプションフレームワーク（for マイクロソフト）」と発音している。

- 参考1: Azureのクラウド導入フレームワークを使用してクラウドガバナンスを確立する| Azureフライデー https://www.youtube.com/watch?v=gPEcqX9No-M
- 参考2: Microsoft Cloud Adoption Framework for Azure, Part 1 https://www.youtube.com/watch?v=9VJYVITjckw
- 参考3: Microsoft Cloud Adoption Framework for Azure, Part 2 https://www.youtube.com/watch?v=8eqv_wXqflQ
- 参考4: Azureのクラウド導入フレームワークの概要 https://www.youtube.com/watch?v=j2Vk-YNdSdQ

## 「Well-Architected Framework」と「クラウド導入フレームワーク」は何が違うのか？

> W-AFをより良く活用するためには、その上位フレームワークである「Microsoft Cloud Adoption Framework for Azure」（以下、CAF）の理解が重要

https://jpn.nec.com/solution/mssolutions/eventreport/20200929_01.html

> CAF: クラウドを導入するにあたってビジネス戦略、テクノロジ戦略を支援する広範囲のガイダンス
>
> WAF: Azureでのアプリケーション設計に特化したフレームワーク

https://cloudsteady.jp/post/29330/

## 参考: さまざまなクラウドベンダーもCAFを提供

"どのクラウドを利用するにしても、組織において「クラウド導入」を計画する必要がある。それを支援するのがCAFである"

> 各クラウドベンダーはクラウド導入のベストプラクティスとして、独自のフレームワークを提供している。前述したマイクロソフトもAzure導入のフレームワークとして「Microsoft Cloud Adoption Framework for Azure」、通称「CAF」というものを用意している。

https://enterprisezine.jp/article/detail/13670

※AWSのCAF https://aws.amazon.com/jp/professional-services/CAF/

※GCPのCAF https://cloud.google.com/adoption-framework

※Oracle Cloud Infrastructure (OCI) のCAF https://www.oracle.com/cloud/cloud-adoption-framework/

## 参考: CAFの最新情報

Azure 向けの Microsoft クラウド導入フレームワークの最新情報
https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/get-started/whats-new

毎月のようにCAFに更新が加えられている。

## 参考: クラウド導入フレームワークとは？(NECさんの記事 / [日本マイクロソフト久保氏](https://jp.linkedin.com/in/tomonarikubo)による解説）

> CAFは、ビジネス戦略およびテクノロジー戦略の作成と実装の支援を目的に、「戦略定義」「計画」「導入準備」「採用」「統制管理」「管理」といったプロセスのガイダンスを提供する

> DXを推進して急成長を遂げている企業では、このCAFに合致するかたちで戦略を立案し、プランニングからキーテクノロジーを導入、然るべき運用と管理を通行ってきた経緯が少なからずある

https://jpn.nec.com/solution/mssolutions/eventreport/20200929_01.html

## 参考: CAFとは（EnterprizeZineの記事 / [日本マイクロソフト久保氏](https://jp.linkedin.com/in/tomonarikubo)による解説）

> 企業規模でクラウドネイティブ開発を実現するために、必要な役割や責任、行動に関する考え方が体系化されたナレッジフレームワーク

> 顧客の成功事例に基づいた、ビジネス戦略とテクノロジー戦略の作成と実装を支援することを目的とした、実証済みのガイダンス

> CAFでは「戦略定義→計画→導入準備→採用」というステージと、統制管理・運用定義といった内容で構成されており、従来マイクロソフトが行ってきたAzureへの施策を集約させたものになっている

https://enterprisezine.jp/article/detail/13670?p=2

## CAFとは？（Microsoft Learn）

Microsoft Learn [Azure 向けの Microsoft Cloud 導入フレームワーク](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-cloud-adoption-framework-for-azure/)

> クラウド導入フレームワークを使用し、ビジネス、人、テクノロジに対して正しい包括的導入戦略を構築することで、組織は Azure を最大限に活用して、デジタル変革目標を確実に達成できます。


## クラウド導入フレームワークには何が含まれるのか？

- ドキュメント
  - [ハイブリッドおよびマルチクラウド](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/scenarios/hybrid/scenario-overview)
  - [最新のアプリケーション プラットフォーム](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/scenarios/aks/)
    - Kubernetesを活用して、クラウドネイティブアプリを開発する
- 実装ガイド
  - [サブスクリプションの設計](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/decision-guides/subscriptions/)
  - [ユーザーIDの管理](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/decision-guides/identity/)
  - [ストレージオプション](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/considerations/storage-options)
- ベストプラクティス
  - [ネットワークセキュリティのベストプラクティス](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/network-best-practices?bc=/azure/cloud-adoption-framework/_bread/toc.json&toc=/azure/cloud-adoption-framework/toc.json)
- [ツールとテンプレート](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/resources/tools-templates)
  - [SMARTツール](https://docs.microsoft.com/ja-jp/assessments/?mode=pre-assessment&session=local)
    - 戦略的な移行評価および準備ツール(Strategic migration assessment and readiness tool)
  - [「Cloud Adoption Plan」テンプレート](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/plan/template)
    - Azure DevOps Demo Generator で、Azure DevOpsプロジェクトを生成する
    - このプロジェクトで、クラウド導入の取り組みを管理するためのバックログを管理できる
  - [Azure Blueprintsブループリント](https://github.com/Microsoft/CloudAdoptionFramework/tree/master/ready/migration-landing-zone-governance)
  - [Terraformモジュール](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/landing-zone/terraform-landing-zone)
  - [ネーミングツール](https://github.com/microsoft/CloudAdoptionFramework/tree/master/ready/AzNamingTool)

## クラウド導入フレームワークはどうやって実行するのか？

基本的には「クラウド導入フレームワーク」の利用はセルフサービス。

ただし、「多くのクラウド導入作業では、クラウド導入を促進するサービスを提供するシステム インテグレーター (SI) またはコンサルティング パートナーからのサポートが必要になる。」

https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/landing-zone/partner-landing-zone

> CAFのツールやテンプレートをユーザー企業さま自身で整理して進めることももちろん可能です。パートナーさまがユーザー企業さまのクラウドジャーニーを並走するようにCAFを活用することで、幅広いステージで長期的にユーザー企業さまを支えるケースもあります。
> 
> 当社(MS)でもコンサルティングサービスなどを提供しております。

https://www.pc-webzine.com/entry/2021/09/azuremicrosoft-cloud-adoption-framework-for-azure.html

## クラウド導入のアンチパターン

https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/antipatterns/antipatterns-to-avoid

ベストプラクティスの逆。「べからず」集。

ただし、必ずしもベストプラクティスが正解、アンチパターンが不正解であるとも言えない。一般的なベストプラクティスとアンチパターンを踏まえつつ、各アプリケーションやシステムの特性を踏まえて、適切な判断を下す必要がある。

# DevOps プロジェクトでのセキュリティの実装

- Rugged DevOps (DevSecOps) とは。
- ソフトウェア構成解析 (SCA)とは。
- CI/CDパイプラインのセキュリティ
- Secure DevOps Kit for Azure (AzSK)とは。
- Microsoft Defender for Cloudとは。
- Azure Blueprintsとは。

## パイプラインでのセキュリティ

### Rugged DevOps とは?

Rugged (ラゲッド): 頑丈な, ごつごつ(でこぼこ)した。

■Rugged DevOps とは？

DevSecOps とも。同じ概念。

Rugged DevOps / DevSecOpsは、[2016年頃から注目されるようになった](https://www.atmarkit.co.jp/ait/articles/1603/22/news035.html)キーワード。

- セキュリティ対策を最後の工程に後回しにせず、DevOpsに組み込んで実施していく
- セキュリティ脆弱性がプロジェクトに入り込まないようにする
- 継続的な開発サイクルの中にセキュリティに関するフィードバックを組み入れる。

■Rugged DevOps / DevSecOps で実現できること

以下の疑問に答える。

- パイプラインでサードパーティ製コンポーネントを使用しているか。
  - 使用している場合、セキュリティで保護されているか。
- 使用するサードパーティ製コンポーネントのいずれかに既知の脆弱性があるか。
- 脆弱性をどのくらい早く検出できるか。「検出時間」
- 特定された脆弱性をどのくらい迅速に修復できるか。「修復時間」

[Microsoftの開発者のブログ](https://devblogs.microsoft.com/devops/team-services-october-extensions-roundup-rugged-devops/)で、Rugged DevOpsで使用することができるツールがいくつか紹介されている。

- WhiteSource
- HPE Security Fortify
- Checkmarx

[社員のブログ](https://torumakabe.github.io/post/aqua_acr/)で Aqua MicroScannerが取り上げられている。

### Rugged DevOps パイプライン

■普通のDevOpsとRugged DevOpsは何が違うのか？

Rugged DevOpsで、パイプラインに追加されるもの。

- パッケージ管理
  - パッケージを追加する際に承認プロセスを挟む。
- ソーススキャナー
  - ソースコードをスキャンして、脆弱性を発見する


### ソフトウェア構成解析 (SCA)


■ソフトウェア構成解析 (SCA)とは？

Software Composition Analytics(SCA)

プロジェクトで、脆弱性が含まれているパッケージ（のバージョン）を使っているかどうかを検査する。

いくつかのツールが利用できる。

- [WhiteSource](https://www.ricksoft.jp/whitesource/)
- [Fortify SCA](https://www.veriserve.co.jp/service/detail/fortify-sca.html)
- [Synopsys](https://www.synopsys.com/ja-jp/glossary/what-is-software-composition-analysis.html)
- [Black Duck](https://www.synopsys.com/ja-jp/software-integrity/security-testing/software-composition-analysis.html)
- [Veracode](https://www.techmatrix.co.jp/product/veracode/sca.html)


■パッケージの管理

（Azure Artifactについては[モジュール9](mod09.md)で解説済み。）

Azure Artifactフィードを、プロジェクトにおける唯一の「信頼できるフィード」とする。

（プロジェクトメンバーが勝手に外部のパッケージリポジトリを使用しないようにする）

■OSSコンポーネント

多数の開発プロジェクトで、オープンソースソフトウェア（OSS）のコンポーネント（ソフトウェア部品）が利用される。

OSSコンポーネントを利用する際は以下の点に注意しなければならない。
- セキュリティ脆弱性
- ライセンス

※OSSコンポーネントに限定された話ではないと思われる

SCAツールを使用して、脆弱性、ライセンスの問題点を発見することができる。

<!--
### Azure DevOps パイプラインとの WhiteSource 統合

（ツールをPipelineに統合し、チェックを自動化できる。以下同）

### Micro Focus Fortify と Azure Pipelines の統合

（統合可能）

### Azure DevOps との Checkmarx 統合

（統合可能）

### Azure DevOps との Veracode 統合

（統合可能）

### ソフトウェア構成解析チェックをパイプラインに統合する方法

（ここまでで説明済みの話題なので省略）
-->

### パイプライン セキュリティの実装

CI/CDパイプライン自体のセキュリティ対策。

- パイプラインにアクセスするユーザーの、Azure AD MFAによる多要素認証。
- パイプラインをPowerShellで操作する場合の、[Just Enough Administration (JEA)](https://docs.microsoft.com/ja-jp/powershell/scripting/learn/remoting/jea/overview?view=powershell-7.1)の利用。
  - PowerShellにおけるセキュリティテクノロジ。
  - ユーザーが実行できる操作を制限する
  - ユーザーの操作をログ記録する
  - [JEAについての解説記事](https://www.atmarkit.co.jp/ait/articles/1607/28/news027.html)
- 機密情報をAzure Key Vaultを使用して扱う
  - パイプラインの定義やソースコード中に機密情報を格納しない
- ロールを適切にユーザーに割り当てる
  - 最小特権の原則
- 生産モニタリング（インシデントの発見）
  - Microsoft Defender for Cloudについては後述。

<!--
※以下は（CI/CDパイプラインのセキュリティ実装に含めて説明されているが）パイプラインセキュリティではなく、開発中のアプリケーションに対するセキュリティテストと思われる。

- ダイナミックスキャン
  - 実行中のアプリケーションに、既知の攻撃パターンでアクセスして検証する
  - OWASPについてはモジュール20で解説。
-->

### Azure 用 Secure DevOps キット (AzSK)

https://azsk.azurewebsites.net/

DevOpsチームのセキュリティのニーズに対応するスクリプト、ツール、拡張機能、自動化、ドキュメントなどのコレクション（ベストプラクティス）。

Microsoftの1部門であるCore Services Engineering & Operations (CSEO)と、コミュニティによって開発されている。

以下の6分野で構成される。

- サブスクリプションのセキュリティ対策
- 開発環境のセキュリティ対策
- CI/CDへのセキュリティ対策の統合
- 継続的保証（Continuous Assurance）
- アラートとモニタリング
- クラウドリスクガバナンス

※注意：2021年中に[廃止予定](https://azsk.azurewebsites.net/ReleaseNotes/AzSKSunsetNotice.html)となっている。AzSKの利用者に対して、後継である[AzTS](https://github.com/azsk/AzTS-docs)への移行が推奨されている。

## Microsoft Defender for Cloud

### Microsoft Defender for Cloud

PDFまとめ資料:
[Microsoft Defender for Cloud / Servers / Endpoint](../AZ-500/pdf/mod2/Microsoft%20Defender%20for%20Cloud%20概要.pdf)
[Microsoft Defender for Cloud](../AZ-500/pdf/mod4/Microsoft%20Defender%20for%20Cloud%20まとめ.pdf)

### Azure Policy

■ポリシー

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/governance/policy/overview)

■イニシアチブ

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/governance/policy/concepts/initiative-definition-structure)

### リソース ロック

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/lock-resources?tabs=json)

### Azure Blueprints

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/governance/blueprints/overview)

さまざまなリソース テンプレートやその他のアーティファクトのデプロイを宣言によって調整する手法。

環境は、組織のコンプライアンスに沿った形で（テンプレートがデプロイされ、ロール、ポリシーが設定された状態で）設定される。

開発チームは新しい環境を迅速に構築して使用することができる。

- ロールの割り当て
- ポリシーの割り当て
- Azure Resource Manager テンプレート (ARM テンプレート)
- リソース グループ


### Azure Advanced Threat Protection (ATP)

Azure Advanced Threat Protection、Azure ATPは、名前が変わり、現在Microsoft Defender for Identityとなっている。

[ドキュメント](https://docs.microsoft.com/ja-jp/defender-for-identity/what-is)

組織内のユーザーやコンピュータ、リソースなどの資格情報に対する不正なアクティビティや、悪意のある攻撃者による攻撃を検知、分析し、組織内の管理者が適切な対応を迅速にとることができるしくみ。

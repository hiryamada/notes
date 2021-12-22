# セキュリティソリューションのカテゴリー

CSPM, CWPP, SIEM, SOAR...

https://www.hitachi-solutions.co.jp/security/sp/solution/task/zerotrust.html

https://www.c3m.io/ja/%E7%90%86%E8%A7%A3-cspm-cwpp-casb-and-ciem/

https://docs.microsoft.com/ja-jp/learn/modules/describe-security-capabilities-of-azure-sentinel/2-define-concepts-of-siem-soar-xdr

# CSPM (Cloud Security Posture Management)

- クラウドセキュリティ動態管理
- クラウドセキュリティの状態管理
- クラウドセキュリティ態勢管理

[posture（ポスチャー）: 姿勢、身のこなし、態勢、心構え、態度、視点、戦力・軍事力、ポーズを取る](https://ejje.weblio.jp/content/posture)

対応製品: [Microsoft Defender for Cloud](https://docs.microsoft.com/en-us/azure/defender-for-cloud/defender-for-cloud-introduction)

https://atmarkit.itmedia.co.jp/ait/articles/2011/13/news002.html

> セキュアな状態になっているかどうかを継続的に分析する管理ツール

https://www.nri-secure.co.jp/blog/preventing-cloud-configuration-mistakes-with-cspm

> IaaS、PaaSの設定ミス防止を支援し、安全な利用をサポートするソリューション

https://www.fireeye.jp/products/cloudvisory/cloud-security-posture-management-and-workload-protection.html

> IaaSクラウドスタック全体に対するセキュリティアセスメント、コンプライアンス、モニタリングを集中管理するもの

> クラウド・サービス上で発生した攻撃のほぼすべては、顧客側の設定ミス、不適切な管理、人為的ミスが原因です。セキュリティおよびリスク管理の担当者は、CSPMのプロセスとツールを活用し、これらのリスクを事前に特定、修復する必要があります。

# Cloud Workload protection (CWP) / Cloud Workload Protection Platform (CWPP)

クラウドワークロード保護プラットフォーム

対応製品: [Microsoft Defender for Cloud](https://docs.microsoft.com/en-us/azure/defender-for-cloud/defender-for-cloud-introduction)

https://www.fireeye.jp/products/cloudvisory/cloud-security-posture-management-and-workload-protection.html

> クラウド・ワークロードの監視と保護のために設計されたソフトウェア・プラットフォーム
> 
> エージェントレスのアプローチとエージェントベースのアプローチの両方を提供し、従来のデータセンター、パブリック・クラウド環境、プライベート・クラウド環境におけるさまざまなタイプのワークロードを保護するものです。その対象として、ベアメタル・サーバー、オーケストレーション済みコンテナ、サーバーレス「機能」、仮想マシン（VM）が挙げられます。

# Security Information Event Management (SIEM)

セキュリティ情報イベント管理

対応製品: Azure Sentinel

# Security Orchestration Automated Response (SOAR)

セキュリティ オーケストレーション自動応答

対応製品: Azure Sentinel

# Cloud Access Security Broker（CASB）

クラウド アクセス セキュリティ ブローカー

読み方: [「キャズビー」あるいは「キャスビー」](https://www.nec-solutioninnovators.co.jp/ss/insider/security-words/14.html)

対応製品: Microsoft Cloud App Security (MCAS)


https://www.nri-secure.co.jp/glossary/casb

> 企業や組織が、従業員によるクラウドサービスの利用を可視化・制御して、一括管理する役割を果たすソリューションの総称
> 
> シャドーIT対策として有効


https://docs.microsoft.com/ja-jp/cloud-app-security/what-is-cloud-app-security#what-is-a-casb

> シャドウ IT の検出とアプリのガバナンスが主なユース ケースです


# Endpoint Detection and Response (EDR)

対応製品: [Microsoft Defender for Endpoint](https://www.microsoft.com/ja-jp/security/business/threat-protection/endpoint-defender)

https://www.ntt.com/bizon/glossary/e-e/edr.html

> ユーザーが利用するパソコンやサーバー（エンドポイント）における不審な挙動を検知し、迅速な対応を支援するソリューション

https://www.nec-solutioninnovators.co.jp/ss/insider/security-words/06.html

> EDRは「エンドポイントで脅威を検知（Detection）して、対応（Response）を支援する」ことを主眼としている。そのため、エンドポイントにおける脅威の動きを包括的に可視化し、ハッキング活動の検知・観察や記録、攻撃遮断などの応急措置といった機能を提供する。

https://docs.microsoft.com/ja-jp/microsoft-365/security/defender-endpoint/microsoft-defender-antivirus-windows

> Microsoft Defender ウイルス対策は、Windows 10 と Windows 11、および Windows Server のバージョンで利用できます。
> 
> Microsoft Defender ウイルス対策は、Microsoft Defender for Endpoint の次世代保護の主要コンポーネントです。
> 
> この保護は、機械学習、ビッグデータ分析、脅威耐性に関する詳細な調査、Microsoft のクラウド インフラストラクチャを組み合わせて、組織内のデバイス (または、エンドポイント) を保護します。
> 
> Windows Defender ウイルス対策は Windows に組み込まれており、Microsoft Defender for Endpoint と連携して、デバイスとクラウドを保護します。

# eXtended Detection and Response (XDR)

https://www.microsoft.com/security/blog/2020/09/22/microsoft-unified-siem-xdr-modernize-security-operations/

対応製品: Azure Defender
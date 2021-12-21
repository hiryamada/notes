# 共同責任モデル

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility

■概要

「お客様」が責任を持つべきセキュリティの範囲と、「Microsoft」が責任を持つべきセキュリティの範囲を定めたモデル。

サービスの種類により、「お客様」または「Microsoft」が責任を持つ範囲が異なる。

注意:「データ」「エンドポイント」「アカウント(ID)」「アクセス管理」については、常に「お客様」が責任を持つ範囲となる。

具体的には:

- 「データ」に適切なアクセス制限やバックアップを設定する
- 「エンドポイント」（エンドユーザーが使用しているデバイス）の保護を行う
- 「アカウント」（Azure ADのユーザー等）を適切に管理する
- 「アクセス管理」（ユーザーへロールの割り当て等）を適切に管理する

IaaSよりもPaaS、PaaSよりもSaaSのほうが、Microsoftの責任範囲が大きくなる（お客様の責任範囲が小さくなるため、セキュリティ対策の手間やコストが、より削減される）。

■オンプレミスとクラウドにおける責任範囲の比較

- オンプレミスのデータセンターでは、
  - お客様がスタック（物理インフラ、ソフトウェア、データ）全体を所有し、そのすべての責任を持つ
- クラウドに移行することで、
  - セキュリティ責任範囲の多くの部分を、クラウド プロバイダーにシフトできる
    - お客様は、リソースを、セキュリティ対策以外の面に活用できる
  - クラウドベースのセキュリティ機能を活用し、セキュリティ対策の有効性を高めることができる
- ただし、デプロイの種類に関係なく、次の責任はお客様が必ず負う。
  - データ
  - エンドポイント 
    - [注: ここでのエンドポイントとはユーザーが使用するデバイス（モバイル端末とPC）を指す。](https://docs.microsoft.com/en-us/learn/modules/describe-security-concepts-methodologies/3-describe-shared-responsibility-model)
    - [ゼロトラストにおけるエンドポイントセキュリティ保護](https://docs.microsoft.com/ja-jp/security/zero-trust/deploy/endpoints)
  - アカウント
  - アクセス管理

■[ドキュメントの図](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility#division-of-responsibility)

- オンプレミス
  - お客様の責任 
    - **Information and Data**
    - **Devices (Mobile and PCs) - エンドポイントとも**
    - **Accounts and identities**
    - Identity and directory Infrastructre
    - Applications
    - Network Controls
    - Operating System
    - Physical hosts
    - Physical network
    - Physical datacenter
  - マイクロソフトの責任
    - （なし）
- IaaS
  - お客様の責任 
    - **Information and Data**
    - **Devices (Mobile and PCs) - エンドポイントとも**
    - **Accounts and identities**
    - Identity and directory Infrastructre
    - Applications
    - Network Controls
    - Operating System
  - マイクロソフトの責任
    - Physical hosts
    - Physical network
    - Physical datacenter
- PaaS
  - お客様の責任 
    - **Information and Data**
    - **Devices (Mobile and PCs) - エンドポイントとも**
    - **Accounts and identities**
    - Identity and directory Infrastructre
  - お客様とマイクロソフトの共同責任 
    - Applications
    - Network Controls
    - Operating System
  - マイクロソフトの責任
    - Physical hosts
    - Physical network
    - Physical datacenter
- SaaS
  - お客様の責任 
    - **Information and Data**
    - **Devices (Mobile and PCs) - エンドポイントとも**
    - **Accounts and identities**
  - お客様とマイクロソフトの共同責任 
    - Identity and directory Infrastructre
  - マイクロソフトの責任
    - Applications
    - Network Controls
    - Operating System
    - Physical hosts
    - Physical network
    - Physical datacenter


■クラウドサービスの分類: IaaS, PaaS, SaaS

https://docs.microsoft.com/ja-jp/azure/architecture/guide/technology-choices/compute-decision-tree#understand-the-hosting-models

- IaaS
  - Azure VM
- PaaS
  - Azure App Service
- SaaS
  - [Office 365](https://www.microsoft.com/ja-jp/microsoft-365/enterprise/compare-office-365-plans) / [Microsoft 365](https://www.microsoft.com/ja-jp/microsoft-365/compare-microsoft-365-enterprise-plans)
- FaaS
  - Azure Functions
- IDaaS
  - Azure AD
- DRaaS
  - Azure Site Recovery
- Container as a Service
  - Azure Container Instances

■IaaS

https://azure.microsoft.com/ja-jp/overview/what-is-iaas/#overview

■PaaS

https://azure.microsoft.com/ja-jp/overview/what-is-paas/#overview

■SaaS

https://azure.microsoft.com/ja-jp/overview/what-is-saas/#overview

■Microsoft Learn

- [共同責任モデルについて説明する](https://docs.microsoft.com/ja-jp/learn/modules/describe-security-concepts-methodologies/3-describe-shared-responsibility-model)
- [共有責任モデルを説明する](https://docs.microsoft.com/ja-jp/learn/modules/compmgmt-learn-concepts/explain-model)
- [共有責任モデルを規制または標準に適用する](https://docs.microsoft.com/ja-jp/learn/modules/compmgmt-learn-concepts/apply-model)
# 共同責任モデル

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility

- オンプレミスのデータセンターでは、
  - お客様がスタック（物理インフラ、ソフトウェア、データ）全体を所有し、そのすべての責任を持つ
- クラウドに移行することで、
  - セキュリティ責任範囲の多くの部分を、クラウド プロバイダーにシフトできる
    - お客様は、リソースを、セキュリティ対策以外の面に活用できる
  - クラウドベースのセキュリティ機能を活用し、セキュリティ対策の有効性を高めることができる
- ただし、デプロイの種類に関係なく、次の責任はお客様が必ず負う。
  - データ
  - エンドポイント
  - アカウント
  - アクセス管理

■[ドキュメントの図](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility#division-of-responsibility)

- オンプレミス
  - お客様の責任 
    - Information and Data
    - Devices (Mobile and PCs)
    - Accounts and identities
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
    - Information and Data
    - Devices (Mobile and PCs)
    - Accounts and identities
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
    - Information and Data
    - Devices (Mobile and PCs)
    - Accounts and identities
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
    - Information and Data
    - Devices (Mobile and PCs)
    - Accounts and identities
  - お客様とマイクロソフトの共同責任 
    - Identity and directory Infrastructre
  - マイクロソフトの責任
    - Applications
    - Network Controls
    - Operating System
    - Physical hosts
    - Physical network
    - Physical datacenter


■クラウドサービスの分類: IaaS, PaaS, SaaS (FaaS)

https://docs.microsoft.com/ja-jp/azure/architecture/guide/technology-choices/compute-decision-tree#understand-the-hosting-models

- IaaS
  - Azure VM
- PaaS
  - Azure App Service
- FaaS
  - Azure Functions

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
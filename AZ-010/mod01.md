■Azure Active Directory

Azure Active Directory (Azure AD)とは？

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis

- クラウドベースの「ID およびアクセス管理」サービス
  - 従来オンプレミスで使われてきた「[Active Directory Domain Services(AD DS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-ds/get-started/virtual-dc/active-directory-domain-services-overview)」とは別のもの。
  - Azure AD: クラウドベース、インストール作業は不要
  - AD DS: オンプレミスのWindows Serverへのインストール作業が必要
  - オンプレミスAD DSからAzure ADへのIDの「同期」を行うことは可能。
    - Azure AD Connectを使用（後述）
    - AD DS上に登録されたユーザーIDをAzure AD側に転送
    - この場合、ユーザーID管理は引き続きオンプレミス側のAD DSで実施
    - ユーザーは、同じID・パスワードで、オンプレミスAD DSとAzure AD両方でサインインできる（ハイブリッドID）
- Microsoft Azure、Microsoft 365、Microsoft Dynamics 365などのID管理に利用される
  - これらのサービスを使用する場合、必然的に「Azure AD」を使うことになる
  - 基本的に1つの組織（会社）で1つの「Azure ADテナント」を作る
  - Azure, M365, D365のサブスクリプションと関連付けて利用する
  - ```
    Azure ADテナント ... 組織（会社）のユーザーID（社員）を管理
    ├ Azure サブスクリプション
    ├ 365 サブスクリプション
    └ Dynamics 365 サブスクリプション
    ```
  - Windows 365（クラウドPC）でもAzure ADが利用される
    - [Azure ADテナントとAzureサブスクリプション](https://docs.microsoft.com/ja-jp/windows-365/requirements)
    - ユーザーへの[Windows 365ライセンス](https://docs.microsoft.com/ja-jp/windows-365/assign-licenses)の割り当て
- (Microsoftのサービスだけではなく) 数千のアプリケーションにもシングルサインオンができる
  - 一度Azure ADにサインインすると、多数のアプリケーションにサインインなしでアクセスできる
    - シングルサインオン（SSO）
  - ユーザーは、それぞれのアプリケーション用のユーザーIDやパスワードを管理する必要がなくなる
  - 管理者は、組織のユーザーIDを集中管理できる
- 対応アプリケーション
  - Azure
  - Microsoft 365
  - Dynamics 365
  - Salesforce （SFA/CRM）
  - Dropbox（クラウドストレージ）
  - Box（クラウドストレージ）
  - Concur（経費管理）
  - ServiceNow（ITサービスマネジメント）
  - など、数千のアプリ
    - [Azure Marketplace内のActive Directory Marketplace](https://azuremarketplace.microsoft.com/ja/marketplace/apps/category/azure-active-directory-apps)で検索可能
    - 実際にアプリをAzure ADに登録する際に利用できる多数の[チュートリアル](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/tutorial-list)（構成手順）が提供されている
- さまざまなデバイスで動作
  - Windows
  - macOS
  - iOS
  - Android
  - ```
    Azure AD テナント
          ↑   ↑       サインイン
    Windows   iPhone  様々なデバイス上からアプリケーションを利用
          ↑   ↑
         ユーザー
    ```
- ユーザーは、[「マイアプリ」ポータルを使用](https://docs.microsoft.com/ja-jp/azure/active-directory/user-help/my-apps-portal-end-user-access)して、組織のアプリケーションにアクセスできる
  - https://myapplications.microsoft.com/
  - （以前は https://myapps.microsoft.com/ というURLで、「アクセスパネル」とも呼ばれていた）
    - [参考](https://azuread.net/archives/9380)
- オンプレミスのWebアプリケーションにアクセスすることも可能
  - [Azure ADアプリケーション プロキシ](https://docs.microsoft.com/ja-jp/azure/active-directory/app-proxy/what-is-application-proxy)


■Azure ADのエディション

https://www.microsoft.com/ja-jp/security/business/identity-access-management/azure-ad-pricing

- Free: 無料
- Office 365: ※Office 365ユーザーが利用可能
- Premium P1: ￥650 ユーザー/月（税抜）
- Premium P2: ￥980 ユーザー/月（税抜）

■エディションとは？

- Free ⊂ Office 365 ⊂ Premium P1 ⊂ Premium P2。
- テナントでP1/P2を購入し、ユーザーに割り当てる。
- 組織の全ユーザーに同じライセンスを割り当てる必要はない。
- P2を割り当てたユーザーではP1の機能も利用できる。
- P1とP2をまとめて「Azure ADプレミアムライセンス」と呼ぶ場合がある。プレミアムライセンスを必要とする機能は、P1またはP2があれば利用できる。
- Office 365（Microsoft 365）のユーザーは、Azure AD Freeの機能に加えて、Azuer ADの「Office 365」の機能を利用することができる。
- [Microsoft 365 Business（2020/4/1に「Microsoft 365 Business Premium」に名称変更）では、Premium P1のフル機能が含まれる。](https://blogs.windows.com/japan/2020/04/08/azure-active-directory-premium-p1-is-coming-to-microsoft-365/)

Azure AD 機能とライセンス:

高度な機能を利用するにはP1/P2が必要となる。

- Azure AD Connect: [無料](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#license-requirements-for-using-azure-ad-connect)
- Azure AD Connect Health: [P1](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#license-requirements-for-using-azure-ad-connect-health)
- 動的グループ: [P1](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-create-rule)
  - 動的グループのメンバーであるユーザーごとに P1 ライセンスが必要
  - ユーザーを動的グループのメンバーにするために、そのユーザーにライセンスを割り当てる必要はない
  - 必要なP1ライセンス数がテナントに含まれる必要がある
  - 動的なデバイス グループのライセンスは不要
- パスワードの変更/リセット/オンプレミスへのライトバック: [参照](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-licensing#compare-editions-and-features)
  - オンプレミスへのライトバック: P2
- Azure AD MFA: [参照](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-licensing)
- デバイスID: [P1](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/overview#license-requirements)
- Azure AD 条件付きアクセス: [P1](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview#license-requirements)
- Azure AD Privileged Identity Management: [P2](https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-configure#license-requirements)
- Azure AD Identity Protection: [P2](https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection#license-requirements)
- [Azure ADアクセスレビュー](mod10-02-access-review.md): [P2](https://docs.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview#license-requirements)
- Azure AD DS: [価格](https://azure.microsoft.com/ja-jp/pricing/details/active-directory-ds/) ※ライセンスは不要
- セキュリティ レポート: [参照](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/overview-reports#what-azure-ad-license-do-you-need-to-access-a-security-report)
- レポートと監視: [Azure AD プレミアム ライセンス(P1/P2)](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/overview-monitoring#licensing-and-prerequisites-for-azure-ad-reporting-and-monitoring)
- Azure AD アクティビティレポート等のデータ保存期間: [参照](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/reference-reports-data-retention#how-long-does-azure-ad-store-the-data)

■まとめ: Azure ADとAD DS

[まとめPDF: Azure ADとAD DS](../AZ-104/pdf/mod01/Azure%20AD%20と%20AD%20DS%20の位置づけ.pdf)

■Azure ADの概念

[まとめPDF: テナントとサブスクリプション](../AZ-104/pdf/mod01/テナント.pdf)

基本的な用語。

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis#terminology

- テナント
  - Azure ADのインスタンス（Azure ADの世界に作られる、1つの組織を表すもの）
  - 組織（会社や学校）を表す。
  - [各テナント（組織）は完全に独立している](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/licensing-directory-independence)
    - テナントには親子関係や階層構造はない
  - 基本的に、1組織1テナントを利用。
    - 検証用のテナントは簡単に作成することができる
  - Azure ADの世界には、テナントがたくさん存在する。
- ディレクトリ
  - テナントの中に1つのディレクトリがある。
  - ディレクトリはユーザー、グループ、アプリなどを含む。
  - テナントとディレクトリは1対1。
    - テナントをディレクトリと呼んだり、ディレクトリをテナントと呼んだりする場合もある。
    - テナント≒ディレクトリと考えてもほとんど問題ない。
- Azureサブスクリプション
  - VM（仮想マシン）などのリソースを管理する。
  - 課金の単位
  - 1つのテナントで複数のサブスクリプションを管理できる
  - ```
    Azure ADテナント
    ├ Azureサブスクリプション1
    └ Azureサブスクリプション2
    ```
  - [テナントに「信頼関係」で関連付けられる](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-how-subscriptions-associated-directory)
    - サブスクリプションはテナントを「信頼」する
    - あるユーザーがサブスクリプションを操作する際に、そのユーザーの認証が、信頼関係で結びついたテナントで行われる
- Azure ADアカウント
  - ディレクトリ内に作成されたユーザー。
  - 「職場または学校アカウント」とも呼ばれる。
  - 「[Microsoftアカウント](https://support.microsoft.com/ja-jp/windows/microsoft-%E3%82%A2%E3%82%AB%E3%82%A6%E3%83%B3%E3%83%88%E3%81%A8%E3%81%AF-4a7c48e9-ff5a-e9c6-5a5c-1a57d66c3bfa)」とは別のもの。


■初期ドメイン名、カスタムドメイン名、プライマリドメイン

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-custom-domain

https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/domains-manage

- 初期ドメイン名
  - 新しい Azure AD テナントにはすべて、 ～～.onmicrosoft.com という初期ドメイン名が付与される。
  - 変更したり削除したりできない。
  - Azureのサインアップに使用したメールアドレスが user@example.com だった場合、初期ドメイン名は userexample.onmicrosoft.com のようになる。
- カスタム ドメイン名
  - ドメイン レジストラーでドメイン名を作成（購入）し、Azure AD テナントに追加することができる。
  - 通常、組織（会社や学校等）で所有しているドメインを、Azure ADに、カスタム ドメイン名として追加する。
- プライマリ ドメイン
  - カスタム ドメインを追加後、それをテナントのプライマリ ドメインに設定することができる。
  - プライマリ ドメインは、新しいユーザーを作成したときの既定のドメインになる。

■参考: Azure DNS

https://docs.microsoft.com/ja-jp/azure/dns/

- DNS ドメインのホスティング サービス
- Microsoft Azure インフラストラクチャを使用した名前解決を提供
- 「パブリックゾーン」と「プライベートゾーン」を作成できる
- パブリックゾーン
  - インターネットでの名前解決に利用できるゾーン
- プライベートゾーン
  - 仮想ネットワーク(Virtual Network, VNET)内での名前解決に利用できるゾーン
  - プライベートゾーンと（1つ以上の）VNetを関連付ける

Azure DNSは「ドメイン レジストラ」ではない。

- Azure DNS を使用してドメイン名を購入することはできない。
  - [「App Service ドメイン」](https://docs.microsoft.com/ja-jp/azure/app-service/manage-custom-dns-buy-domain#buy-an-app-service-domain) というサービスを使用してドメインを購入することができる。

■ユーザー

ユーザーの種類

- クラウドID
  - テナントに直接登録されたユーザーID
- ディレクトリ同期 ID
  - オンプレミスのAD DSに登録され、Azure ADに同期されたユーザーID
- ゲストユーザー
  - 「ユーザーの招待」によって招待されたユーザーID

■グループ

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-groups-create-azure-portal

グループを作り、ユーザーを追加することができる。

グループに対してロール（権限）やライセンスを割り当てることができる。

グループの種類:
- セキュリティ グループ
  - ユーザー、デバイス、グループ、およびサービス プリンシパルをメンバーとして設定できる
- Microsoft 365グループ
  - 共有メールボックス、カレンダー、ファイル、SharePoint サイトなどへのアクセスをメンバーに付与する
  - ユーザーのみをメンバーとして設定することができる

メンバーシップの種類:
- 割り当て済み
  - 手動でメンバーをグループに割り当てる
- 動的ユーザー
  - ルールに該当するユーザーをメンバーとして追加
- 動的デバイス
  - ルールに該当するデバイスをメンバーとして追加


■Azure RBAC(Role-Based Access Control)

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview

「セキュリティ プリンシパル」（ユーザー、グループ、サービスプリンシパル、マネージドID）に対し、仮想マシンの作成・削除などのリソース操作権限を割り当てる仕組み。

管理グループ、サブスクリプション、リソースグループ、リソースなどのスコープで、ユーザーにロールを割り当てることができる。

ロールの種類（代表的なもの）:

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/rbac-and-directory-admin-roles#azure-roles

- Owner 所有者: Contributor + User Access Administrator
- Contributor 共同作成者: リソースの管理（作成・削除・変更・読み取りなど）ができる
- Reader: リソースの情報を読み取りできる
- User Access Administrator ユーザーアクセス管理者: リソースに対するアクセス権を管理する

■Azure Policy

https://docs.microsoft.com/ja-jp/azure/governance/policy/overview

- リソースに対するポリシー（ルール）を作成し、評価するしくみ
- ポリシーに一致しないリソースの情報をレポート出力することができる。
- ポリシー定義: JSON形式で定義される。
- イニシアチブ: ポリシーの集まり。

たとえば「許可されていない場所」ポリシーを使用して、「東日本リージョンにしかリソースを作成できない」といったルールをサブスクリプションに適用することができる。

GitHub ( https://github.com/Azure/azure-policy )には多数のポリシーサンプルが登録されており、ここから必要なポリシーをインポートして利用することもできる。

■ラボ1
最初にP2試用版を有効化しておくとスムーズ


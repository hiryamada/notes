# Azure Active Directory (Azure AD)とは

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis

- クラウドベースの「ID およびアクセス管理」サービス
  - [Azure ADのテナントとサブスクリプションまとめPDF](../AZ-104/pdf/mod01/テナント.pdf)
  - 従来オンプレミスで使われてきた「[Active Directory Domain Services(AD DS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-ds/get-started/virtual-dc/active-directory-domain-services-overview)」とは別のもの。
  - Azure AD: クラウドベース、インストール作業は不要
  - AD DS: オンプレミスのWindows Serverへのインストール作業が必要
  - オンプレミスAD DSからAzure ADへのIDの「同期」を行うことは可能。
    - Azure AD Connectを使用（後述）
    - AD DS上に登録されたユーザーIDをAzure AD側に転送
    - この場合、ユーザーID管理は引き続きオンプレミス側のAD DSで実施
    - ユーザーは、同じID・パスワードで、オンプレミスAD DSとAzure AD両方を利用できる（ハイブリッドID）
  - [AD DSとAzure ADまとめPDF](../AZ-104/pdf/mod01/Azure%20AD%20と%20AD%20DS%20の位置づけ.pdf)
- Microsoft Azure、Microsoft 365、Microsoft Dynamics 365などのID管理に利用される
  - これらのサービスを使用する場合、必然的に「Azure AD」を使うことになる
  - 基本的に1つの組織（会社）で1つの「Azure ADテナント」を作る
  - Azure, M365, D365のサブスクリプションと関連付けて利用する
  - ```
    Azure ADテナント ... 組織（会社）のユーザーID（社員）を管理
    ├ Azure サブスクリプション
    ├ Microsoft 365 サブスクリプション
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

# Azure ADのエディション（ライセンスの種類）

https://www.microsoft.com/ja-jp/security/business/identity-access-management/azure-ad-pricing

■エディション

- Free: 無料
- Office 365: ※Office 365ユーザーが利用可能
- Premium P1: ￥650 ユーザー/月（税抜）
- Premium P2: ￥980 ユーザー/月（税抜）

■概要

- Free ⊂ Office 365 ⊂ Premium P1 ⊂ Premium P2。
- テナントでP1/P2を購入し、ユーザーに割り当てる。
- 組織の全ユーザーに同じライセンスを割り当てる必要はない。
- P2を割り当てたユーザーではP1の機能も利用できる。
- P1とP2をまとめて「Azure ADプレミアムライセンス」と呼ぶ場合がある。プレミアムライセンスを必要とする機能は、P1またはP2があれば利用できる。
- Office 365（Microsoft 365）のユーザーは、Azure AD Freeの機能に加えて、Azuer ADの「Office 365」の機能を利用することができる。
- [Microsoft 365 Business（2020/4/1に「Microsoft 365 Business Premium」に名称変更）では、Premium P1のフル機能が含まれる。](https://blogs.windows.com/japan/2020/04/08/azure-active-directory-premium-p1-is-coming-to-microsoft-365/)

# Azure AD 機能とライセンス

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

■ハンズオン: Azure AD P2 試用版の有効化

- Azure portalの画面上部の検索で「Azure Active Directory」を検索し、「Azure Active Directory」の画面に移動
- 画面左メニュー「ライセンス」をクリック
- 「すべての製品」をクリック
- 画面上部の「試用/購入」をクリック
- 「AZURE AD PREMIUM P2」の「無料試用版」をクリック
- 「アクティブ化」をクリック
- 画面右上に「Azure AD Premium P2 試用版が正常にアクティブ化されました」と通知が表示される。通知は5秒ほどで消える。
- Webブラウザーで、ページをリロードする（Ctrl + R）
- 「試用/購入」の下の一覧に「Azure Active Directory Premium P2」が表示されていればOK

※「Azure Active Directory」の「概要」の「ライセンス」の表示が「Free」から「Azure AD Premium P2」に変わるまで、5分ほどかかる。

# Azure ADの概念

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

# Azure ADにおけるデバイスの管理

https://docs.microsoft.com/ja-jp/azure/active-directory/devices/overview

■デバイスとは？

PC（ノートPC等）、モバイル デバイス（スマートフォンやタブレット）のこと。

■ユーザーによるデバイスの利用

ユーザーは、さまざまなデバイス、さまざまな場所から、Azure ADを使用する必要がある。

背景
- リモートワークの必要性
- 社外の場所、社外のネットワークからアクセスする必要がある
- 個人のスマートフォンなどのデバイスからアクセスしたい

■デバイス管理の必要性

組織は、Azure ADにアクセスするデバイスを識別し（デバイスID）、デバイスからのアプリへのアクセスをコントロールする必要がある。

デバイスのセキュリティを確保する必要がある

■Azure ADでデバイスを管理するメリット

- ユーザー
  - 個人のデバイスを使用して、組織のアプリケーションにサインインできるようになる
    - 個人所有のiPhone、Android、PCを使用して、会社のアプリを利用することができる
    - 組織所有のWindows 10ノートPCにサインインすると、Azureに、ユーザー名・パスワードを入力することなくサインインすることができる
    - 複数のWindowsデバイス間で、ユーザー設定とアプリケーション設定のデータを同期させることができる
      - [Enterprise State Roaming](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/enterprise-state-roaming-overview)
      - 「Azure AD 参加」または「Azure AD ハイブリッド参加」で利用可能
- 組織
  - 組織の要求するセキュリティ要件を、デバイスに適用することができる
    - 重要なアプリケーションへのアクセスを特定のデバイスに制限することができる

■Azure ADでデバイスを管理するには

以下のいずれかの方法を利用する。

- [「Azure AD 登録」（Azure AD registered）](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/concept-azure-ad-register)
  - 個人が所有するiOS/Android/Windows 10デバイスをAzure ADで管理
  - Bring Your Own Device (BYOD) を想定
- [「Azure AD 参加」（Azure AD joined）](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/concept-azure-ad-join)
  - 組織が所有するWindows 10（Homeを除く）ノートPC等をAzure ADで管理
  - オンプレAD DSがない場合に利用
- [「Azure AD ハイブリッド参加」（Hybrid Azure AD joined）](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/concept-azure-ad-join-hybrid)
  - 組織が所有するWindows 7, 8.1, 10ノートPC等、Windows Server 2008以降のサーバー等をAzure ADで管理
  - オンプレAD DSがある場合に利用
  - オンプレADとAzure ADの両方にデバイス情報を保持

■ライセンス要件

Azure ADデバイスID管理を利用するにはAzure AD Premium P1ライセンスが必要。

■さらに詳しく

登録・参加・ハイブリッド参加の違い、ユースケースの詳細については以下資料を参照:
- https://jpazureid.github.io/blog/azure-active-directory/azure-ad-join-vs-azure-ad-device-registration/
- https://www.slideshare.net/yamarara/azure-active-directory-151286832

■参考: Intune (AZ-303範囲外)

高度なモバイル デバイス管理（MDM: Mobile Device Management）については Microsoft Intune を使用する。

https://docs.microsoft.com/ja-jp/mem/intune/fundamentals/what-is-intune

- 脱獄されたデバイスをブロックする
- ユーザーが Wi-Fi ネットワークに簡単にアクセスできるように、または VPN を使用してネットワークに接続できるように、デバイスに証明書をプッシュする
- デバイスが紛失された、盗難された、または使用されなくなった場合に、組織のデータを削除する。

■おすすめ書籍

ひと目でわかるAzure Active Directory 第3版 2020/12/14
https://www.nikkeibp.co.jp/atclpubmkt/book/20/P86590/

ひと目でわかるIntune 改訂新版 2021/6/14
https://www.nikkeibp.co.jp/atclpubmkt/book/21/S80000/

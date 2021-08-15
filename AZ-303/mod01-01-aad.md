# Azure Active Directory (Azure AD)とは

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis

- クラウドベースの「ID およびアクセス管理」サービス
  - 従来オンプレミスで使われてきた「[Active Directory Domain Services(AD DS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-ds/get-started/virtual-dc/active-directory-domain-services-overview)」とは別のもの。
  - Azure AD: クラウドベース、インストール作業は不要
  - AD DS: オンプレミスのWindows Serverへのインストール作業が必要
  - オンプレミスAD DSからAzure ADへのIDの「同期」を行うことは可能。
    - Azure AD Connectを使用（後述）
    - AD DS上に登録されたユーザーIDをAzure AD側に転送
    - この場合、ユーザーID管理は引き続きオンプレミス側のAD DSで実施
    - ユーザーは、同じID・パスワードで、オンプレミスAD DSとAzure AD両方を利用できる（ハイブリッドID）
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

3つのユースケースの詳細については以下資料を参照:
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

ひと目でわかるIntune　改訂新版 2021/6/14
https://www.nikkeibp.co.jp/atclpubmkt/book/21/S80000/

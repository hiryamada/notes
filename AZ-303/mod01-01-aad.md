# Azure Active Directory (Azure AD)とは

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis

- クラウドベースの ID およびアクセス管理サービス
- 多数のアプリケーションにシングルサインオンできる
  - 一度Azure ADにサインインすると、多数のアプリケーションにサインインなしでアクセスできる
  - ユーザーは、それぞれのアプリケーション用のユーザーIDやパスワードを管理する必要がなくなる
  - 管理者は、組織のユーザーIDを集中管理できる
- 対応アプリケーション
  - Azure
  - Microsoft 365
  - Salesforce
  - Dropbox
  - Concur
  - ServiceNow
  - Box
  - など、数千のアプリ
    - [Azure Marketplace内のActive Directory Marketplace](https://azuremarketplace.microsoft.com/ja/marketplace/apps/category/azure-active-directory-apps)で検索可能
    - 多数の[チュートリアル](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/tutorial-list)（構成手順）も利用可能
- さまざまなデバイスで動作
  - Windows
  - macOS
  - iOS
  - Android
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
  - Azure ADのインスタンス。
  - 組織（会社や学校）を表す。
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
  - テナントに「信頼関係」で関連付けられる
    - サブスクリプションはテナントを「信頼」する
    - あるユーザーがサブスクリプションを操作する際に、そのユーザーの認証が、信頼関係で結びついたテナントで行われる
- Azure ADアカウント
  - ディレクトリ内に作成されたユーザー。
  - 「職場または学校アカウント」とも呼ばれる。

# Azure ADにおけるデバイスの管理

https://docs.microsoft.com/ja-jp/azure/active-directory/devices/overview

■デバイスとは？

PC（ノートPC等）、モバイル デバイス（スマートフォンやタブレット）のこと。

■ユーザーによるデバイスの利用

ユーザーは、さまざまなデバイス、さまざまな場所から、Azure ADを使用する必要がある。

リモートワークへの対応など。

■デバイス管理の必要性

組織は、Azure ADにアクセスするデバイスを識別し（デバイスID）、デバイスからのアプリへのアクセスをコントロールする必要がある。

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

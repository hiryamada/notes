# mod1-1 Azure AD (Azure Active Directory)


■Azure ADとは

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis

まとめPDF: https://github.com/hiryamada/notes/blob/main/AZ-104/pdf/mod01/mod01.pdf

- ID の管理サービス
- シングルサインオン機能を提供
- オンプレミスのAD DS (Active Directory Domain Services)と統合（同期）できる
  - Azure AD Connect

■参考: Azure ADのデプロイガイド

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-deployment-checklist-p2

Azure ADの多数の機能について、かんたんな説明とリンクが記述されている。

■Azure ADと、オンプレミスのAD DSの違い

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-compare-azure-ad-to-ad

- Azure Active Directory (Azure AD) - クラウドで運用
- オンプレミスのActive Directory Domain Services(AD DS) - Windows Server上で運用

同じ「Active Directory」という名前が付いているが、Azure ADとAD DSは完全に別のサービスである。

似ている点:
- ID管理の機能を提供

異なる点:
- 対象とする領域
  - Azure AD: インターネットとオンプレミス
  - AD DS: 基本的にオンプレミス
- プロトコル
  - Azure AD: インターネットに対応したプロトコル(OpenID Connect, OAuth, SAMLなど)
  - AD DS: Kerberos, LDAP
- 構造
  - Azure AD: ユーザー、グループ、ロール
  - AD DS: ユーザー、グループ、OU、GPO（グループポリシーオブジェクト）

■Azure ADの管理者ロール

ロールのドキュメント:
https://docs.microsoft.com/ja-jp/azure/active-directory/roles/

組み込みのロール一覧:
https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference

- グローバル管理者（全体管理者とも）
  - Azure AD テナントのフルコントロールが可能
  - 組織内の5名未満のユーザーに割り当てることを推奨
  - グローバル管理者が多すぎると責任の所在があいまいになる
- ユーザー管理者
  - ユーザーとグループのすべての側面を管理できる。
- ライセンス管理者
  - ユーザーにライセンスを割り当てる/取り消す


■テナント/ディレクトリ/サブスクリプション

[→解説PDF](../../AZ-104/pdf/mod01/テナント.pdf)

■Azure AD DS (Domain Services)

Azure上で、Active Directory ドメインコントローラを運用するためのマネージド・サービス。従来 Windows Server で運用していたドメイン コントローラーと完全な互換性がある。

https://docs.microsoft.com/ja-jp/azure/active-directory-domain-services/overview

Azure AD DSの導入シナリオ:
https://jpazureid.github.io/blog/azure-active-directory/azure-ad-ds-scenario/

■Azure ADユーザー

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-users-azure-active-directory

■Azure ADグループ

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-manage-groups

■管理単位 (Administrative units)

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/administrative-units

- Azure ADに「管理単位」を作成できる
- 管理単位には、ユーザーとグループのみを含めることができる
- 各管理単位で、ユーザーにロールを割り当てることができる
- 各管理単位の管理者に Azure AD Premium P1 ライセンスが必要
- 管理単位のメンバーに Azure AD Free ライセンスが必要

例
- 管理単位「部署1」を作成
- 「部署1」に、user1, user2 を追加
- 「部署1」の「パスワード管理者」として、user3を割り当てる
- user3は、部署1のユーザー（user1, user2）に対してのみ、パスワードの管理操作を実行できる。
- user1, user2はAzure AD Freeライセンスがあれよい
- user3には、Azure AD Premium P1ライセンスが必要

■パスワードレス

Microsoft Authenticator アプリなどを使用すると、パスワードを使用せずに Azure AD アカウントにサインインできる。

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-authentication-passwordless

- Windows Hello for Business
- Microsoft Authenticator アプリ
- FIDO2 セキュリティ キー

マイクロソフトのCISOが語る--なぜパスワードをなくそうとしているのか
https://japan.zdnet.com/article/35172673/

■ハンズオン: Azure Active Directory Premium P2 無料試用版 のアクティブ化
- Azure portalにアクセス https://portal.azure.com/ 
- 画面左上メニューのボタン＞Azure Active Directory
- 画面左の「ライセンス」
- 「すべての製品」
- 「＋試用/購入」
- AZURE AD PREMIUM P2 の下の「無料試用版」を展開
- 「アクティブ化」
- Webブラウザで、ページを何度かリロードする
- 「すべての製品」の「＋試用/購入」の下に、「Azure Active Directory Premium P2」が出てくればOK

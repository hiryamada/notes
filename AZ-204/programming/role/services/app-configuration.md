■概要

Azure App Configuration リソースに対するすべての要求は、認証されなければなりません。 

既定では、Azure Active Directory (Azure AD) の資格情報、またはアクセス キーを使用して、要求を認証することができます。 

これら 2 種類の認証スキームでは、Azure AD の方がセキュリティが優れ、アクセス キーより使いやすいので、Microsoft ではそちらをお勧めします。

■エンドポイント

https://appcfg12345.azconfig.io
のようなエンドポイントが作成される。

■コントロールプレーンのロール

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-enable-rbac

- 共同作成者 または 所有者: 
  - このロールを使用して、App Configuration リソースを管理します。 これは、リソースのアクセス キーへのアクセスを許可します。 App Configuration データにはアクセス キーを使用してアクセスできますが、このロールでは Azure AD を使用したデータへの直接アクセスは許可されません。
- 閲覧者:
  - このロールを使用して、App Configuration リソースへの読み取りアクセス権を付与します。 リソースのアクセス キーへのアクセスと、App Configuration に格納されているデータへのアクセスは許可されません。


■データプレーンのロール

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-enable-rbac

- App Configuration データ所有者: 
  - このロールを使用して、App Configuration データへの読み取り/書き込み/削除アクセス権を付与します。 App Configuration リソースへのアクセスは許可されません。
- App Configuration データ閲覧者: 
  - このロールを使用して、App Configuration データへの読み取りアクセス権を付与します。 App Configuration リソースへのアクセスは許可されません。


■アクセスキー認証を無効にする

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-disable-access-key-authentication?tabs=portal

設定＞アクセスキー＞アクセスキーを有効化 をOFFにする

- この操作により、アクセス キー認証が無効になります。現在のアクセス キーのセットは完全に削除されます。
- アプリ構成に関連した Azure AD ロールが割り当てられていない、このリソースのすべてのユーザーは、アプリ構成データにアクセスできなくなります。
- 下の [アクセス制御に移動] を選択して、必要なロールが割り当てられていることを確認してください。 
- 認証にアクセス キーを使用するアプリケーションはすべて動作しなくなります。 
- アクセス キーを再度有効にすると、新しいアクセス キーのセットが生成されます。認証にアクセス キーを使用する必要があるアプリケーションは、これらの新しいキーのいずれかを使用するように更新する必要があります。
- **ロールが最近付与された場合は、ロールの割り当てが反映されるまで 15 分お待ちください**。 

■接続文字列を使用しない（マネージドIDを使用した）App Configurations利用

コード例あり
https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-integrate-azure-managed-service-identity?tabs=core5x

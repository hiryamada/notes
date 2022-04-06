# 「アプリケーションオブジェクト」と「サービスプリンシパル」

■アプリケーションオブジェクト

Azureポータルでアプリケーションを登録すると、そのテナント（ホーム テナント）に「アプリケーション オブジェクト」が作成され、「アプリケーション（クライアント）ID」が割り当てられる。

「Azure ADテナントにアプリを登録する」＝「そのテナントにアプリケーション オブジェクトを作る」といえる。

アプリケーションオブジェクトは、グローバルに一意なインスタンスである。

■サービスプリンシパル

Azureポータルでアプリケーションを登録した場合は、さらに、そのテナントに「サービス プリンシパル」も作成される。

サービス プリンシパルは、テナントによってセキュリティ保護されているリソースにアクセスするための ID。

サービス プリンシパル:
- アプリケーションが使用される各テナントで作成される
- 「アプリケーション オブジェクト」を参照する（つまり、プロパティの一部として「アプリケーション（クライアント）ID」を持つ）
- テナント内でアプリが実際に実行できることを定義する。
- アプリにアクセスできるユーザーを定義する。

サービスプリンシパルは、Azure ADの「エンタープライズアプリケーション」で確認することができる。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/app-objects-and-service-principals

https://tech-lab.sios.jp/archives/23371

https://qiita.com/watahani/items/1f3f533097b7a15d6698

■参考: セキュリティ プリンシパル

サービス プリンシパルは、セキュリティ プリンシパルの一種。

```
セキュリティ プリンシパル
├ユーザー
├グループ
├サービス プリンシパル
└マネージドID
```

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview


■参考: Azure AD 同意のフレームワーク（consent framework）

ユーザーが、アプリケーションに対し、権限を委任する仕組み。

※委任＝（仕事などを）（別の人間などに）まかせること。許可を出すこと。

アプリケーションが動作するために必要な権限だけを許可（付与）することができる。

一般ユーザーによる同意と、管理者による同意の2種類がある。

https://jpazureid.github.io/blog/azure-active-directory/azure-ad-consent-framework/

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/consent-framework

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-permissions-and-consent

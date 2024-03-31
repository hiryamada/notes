# Microsoft Entra Permissions Management

公式サイト https://www.microsoft.com/ja-jp/security/business/identity-access/microsoft-entra-permissions-management


参考: Microsoft社員によるわかりやすい解説動画（YouTube）「Microsoft Entra Permissions Management って何？分かりやすく解説！ | 日本マイクロソフト」 https://www.youtube.com/watch?v=gBD9-jv9TtI

参考: AWSからの利用例 https://dev.classmethod.jp/articles/entra-permissions-management-identity-center-user/

## 2021/7 MicrosoftがCloudKnoxを買収
https://blogs.microsoft.com/blog/2021/07/21/microsoft-acquires-cloudknox-security-to-offer-unified-privileged-access-and-cloud-entitlement-management/

※CloudKnoxはCloud Infrastructure Entitlement Management (CIEM)製品のリーダー。

※Cloud Infrastructure Entitlement Management (CIEM, シーアイイーエム, クラウド・インフラストラクチャ・エンタイトルメント管理):クラウド環境でのユーザー・エンタイトルメントと権限の管理プロセスを自動化。 https://www.checkpoint.com/jp/cyber-hub/cloud-security/what-is-cloud-infrastructure-entitlement-management-ciem/

※SIEM(Security Information and Event Management, シーム): セキュリティー情報イベント管理。多数の情報ソースからセキュリティ情報とイベントを集めて集中監視するシステム。CIEMとは異なる。

※エンタイトルメント: 資格、権利。https://eow.alc.co.jp/search?q=entitlement

## 2022/2 Microsoftが「CloudKnox Permissions Management」 のパブリック プレビューを発表
https://jpazureid.github.io/blog/azure-active-directory/cloudknox-permissions-management-is-now-in-public-preview/

- クラウド基盤全体のすべての ID とそれらに付与されたアクセス許可および実際に使用されたアクセス許可の内容を詳細に可視化
- どの ID が何のリソースに対してどのような操作を実行したかを確認することが可能
- 確認可能なIDとしては、ユーザー ID に限らず、仮想マシン、アクセス キー、コンテナ、スクリプトなどのワークロード ID も含まれる
- Amazon Web Services (AWS)、Google Cloud Platform (GCP)、Microsoft Azure の 3 つの主要クラウド プロバイダーで確認可能
- ダッシュボードでは、組織のアクセス許可状況の概要を確認し、基盤全体で最もリスクの高い ID とリソースがどこにあるのかを特定できる。
- 与えられたアクセス許可と使用されたアクセス許可との間の乖離を計算する 0 から 100 までの単一の指数である 「Permission Creep Index」 が表示される。未使用のアクションや手つかずのリソースが多いほど、その乖離と指数は高くなる。

※（特権の）Creep（クリープ）: 個人が業務を遂行するために必要な範囲を超えて、ネットワークアクセスレベルが徐々に蓄積していくこと。 https://www.keepersecurity.com/blog/ja/2024/03/12/what-is-privilege-creep/

## 2022/7 Microsoft Entra Permissions Management の一般提供開始

https://jpazureid.github.io/blog/azure-active-directory/microsoft-entra-permissions-management-is-now-generally/

- Permissions Management は、スタンドアロンのソリューションとして、1 リソースあたり年間 125 ドル （¥1,300 リソース/月）で提供
- 90 日間無料トライアルが利用可能

## 2023/7 Azure ADがMicrosoft Entra IDにリブランディング

https://devblogs.microsoft.com/identity/aad-rebrand/

リブランディング後の製品構成(Permissions ManagementはEntraの3製品の一部。)

```
Microsoft Entra
├Entra ID (旧Azure AD)
├Permissions Management
└Verified ID
```

※Verified IDのわかりやすい解説: https://qiita.com/junichia/items/803209e403299fe461fc


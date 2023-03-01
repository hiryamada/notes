# アプリの登録

■アプリの登録

https://learn.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-how-applications-are-added#why-do-applications-integrate-with-azure-ad

「Azure AD アプリケーション ギャラリー」に登録されていない、組織で新規に開発したアプリケーションは、Azure ADに登録できる。

![](images/ss-2023-03-01-22-12-27.png)

アプリケーションをAzure ADに登録することで、次のようなメリットが得られる。

- ユーザーの認証に「Microsoft ID プラットフォーム」を使用できる
  - ユーザーは以下のようなアカウントを使用してアプリにサインインできる
    - Azure ADアカウント
    - Microsoftアカウント
    - ソーシャルアカウント
- 条件付きアクセス、MFA、シングルサインオンなどのAzure ADの機能を活用できる
- アプリからMicrosoft Graphを呼び出すことができるようになる
  - アプリからAzure AD、Outlook、OneDriveなどのデータや機能にアクセスできる

![](images/ss-2023-03-01-22-15-49.png)

■ユーザーによる「アプリの登録」を制限する

https://learn.microsoft.com/ja-jp/azure/active-directory/roles/delegate-app-roles#restrict-who-can-create-applications

Azure AD の既定では、すべてのユーザーが、「アプリの登録」を作成できる。

組織の [ユーザー設定] ページで、 [ユーザーはアプリケーションを登録できる] 設定を [いいえ] に設定することで、「アプリケーション開発者」ロールを割り当てられたユーザーだけが、「アプリの登録」を作成できるようになる。

![](images/ss-2023-03-01-22-16-37.png)


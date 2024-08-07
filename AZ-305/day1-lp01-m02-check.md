[知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-authentication-authorization-solutions/11-knowledge-check)

# 1. 承認されたタブレットからのみ、アプリケーションにアクセスできるようにする。

「条件付きアクセス」を使用して、特定のデバイス（タブレット）からのみ、アプリケーションにアクセスできるようにする。

# 2. 従業員が、適切なロールを持つようにする

「アクセス レビュー」を定期的に実施する。

# 3. 自社のテナントに所属していない（子会社や関連会社の）社員に、自社のテナントのアプリへのアクセス権を付与する

その社員を「ゲスト ユーザー」として、自社のテナント（ディレクトリ）に招待する。

# 4. 匿名IPアドレスからのアクセスの際は、ID・パスワードによる認証に加えて、多要素認証（MFA）を要求するようにする。

Azure AD Identity Protectionの「サインイン リスク ポリシー」を作成する

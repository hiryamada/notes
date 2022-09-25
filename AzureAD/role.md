# Azure ADの管理者ロール

ロールのドキュメント:
https://docs.microsoft.com/ja-jp/azure/active-directory/roles/

組み込みのロール一覧:
https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference

85種類の「Azure AD管理者ロール」が存在する（2022/9現在）

■覚えておきたいロール:

- グローバル管理者（全体管理者とも）
  - Azure AD テナントのフルコントロールが可能
  - 組織内の5名未満のユーザーに割り当てることを推奨
  - グローバル管理者が多すぎると責任の所在があいまいになる
- グローバル閲覧者
  - Azure AD テナントの情報の読み取りのみ可能
- ユーザー管理者
  - ユーザーとグループのすべての側面を管理できる
- ライセンス管理者
  - ユーザーにライセンスを割り当て/取り消しできる
- パスワード管理者
  - ユーザーのパスワードを管理できる
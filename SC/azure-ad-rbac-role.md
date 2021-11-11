# Azure Active Directory のロールベースのアクセス制御

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/custom-overview

■概要

- 最小限の特権の原則に従って、管理者に詳細なアクセス許可を付与できる
- ロールの種類として2種類ある。
  - 組み込みのロール（種類：ビルトイン）
  - カスタム ロール（種類：カスタム）

■スコープ

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/custom-overview#scope

ロールを割り当てるときには、次の種類のスコープのいずれかを指定する。

- テナント
- 管理単位
- Azure ADリソース
  - Azure AD グループ
  - エンタープライズ アプリケーション
  - アプリケーションの登録

■セキュリティプリンシパル

セキュリティ プリンシパルは、Azure AD リソースへのアクセスを割り当てられるユーザー、グループ、またはサービス プリンシパルを表す。

- ユーザー
  - Azure Active Directory 内にプロファイルを持つ個人
- グループ
  - isAssignableToRole プロパティが true に設定されている新しい Microsoft 365 またはセキュリティ グループ
  - 現在はプレビュー段階
- サービス プリンシパル
  - アプリケーション、ホステッド サービス、自動ツールなどのためのID

■ライセンス

- 組み込みロール: 無料
- カスタム ロールの利用: Azure AD Premium P1 ライセンスが必要


■カスタムロールの作成

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/custom-overview

Azure AD ＞ ロールと管理者 ＞ ＋新しいカスタムロール

- カスタムロールの名前と説明文
- アクセス許可を1つ以上選択
  - 例: microsoft.directory/auditLogs/allProperties/read (監査ログの読み取り)


■ライセンス

- Azure AD の組み込みロールは無料で使用できる
- カスタム ロールには Azure AD Premium P1 ライセンスが必要
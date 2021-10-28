# ID インフラストラクチャをセキュリティ保護する 5 つのステップ

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity

以下、特に重要と思われる部分の抜粋。

- 作業を開始する前に - MFAで特権アカウントを保護する。
  - 「Azure AD セキュリティの既定値群」または「条件付きアクセス」を使用
- ステップ 1 - 資格情報を強化する
  - [不適切なパスワードを禁止する](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#start-banning-commonly-attacked-passwords-and-turn-off-traditional-complexity-and-expiration-rules)
- ステップ 2 - 攻撃の対象となる領域を減らす
  - [Azure AD Privileged Identity Managementを実装する](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#implement-azure-ad-privileged-identity-management)
    - 時間ベース・承認ベースのロールのアクティブ化
- ステップ 3 - 脅威への対応を自動化する
  - [Azure AD Identity Protection を使用してユーザーのリスク セキュリティ ポリシーを実装する](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#implement-user-risk-security-policy-using-azure-ad-identity-protection)
    - ユーザーのID・パスワードが侵害された可能性が高い場合に、パスワードの変更を要求することができる。
  - [Azure AD Identity Protection を使用してサインインのリスク ポリシーを実装する](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#implement-sign-in-risk-policy-using-azure-ad-identity-protection)
    - 各サインインにおける不正の可能性が高い場合に、MFAを要求することができる。
- ステップ 4 - クラウド インテリジェンスを利用する
  - [Azure ADの監視を行う](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#monitor-azure-ad)
    - たとえば、[Azure ADのサインインログをAzure Sentinelに接続し、Sentinelで監視・調査・自動対応を行うことができる](https://docs.microsoft.com/ja-jp/azure/sentinel/connect-azure-active-directory)
  - [Azure AD Identity Protectionのイベントの監視を行う](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#monitor-azure-ad-identity-protection-events)
    - サインインに関するリスク分析結果を管理者にメールでレポートできる。
- ステップ 5 - エンドユーザー セルフサービスを有効にする
  - [セルフサービス パスワードリセットを実装する](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#implement-self-service-password-reset)
    - エンドユーザーが自分のパスワードを自分でリセットすることができる。
  - [Azure AD アクセスレビューを実装する](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/steps-secure-identity#implement-azure-ad-access-reviews)
    - 不要なグループ所属やロール割り当てを取り除くことができる。
    - レビューのプロセスを定期的に実行できる。

わかりやすい解説:
https://qiita.com/Shinya-Yamaguchi/items/a71b4ebf864166e78415

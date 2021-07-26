# mod1-3-2 Azure AD MFA (Multi-Factor Authentication)

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-howitworks

# ラボ4a(演習1,2) MFA


■MFA(Multi-Factor Authentication)とは？
- 2 つ目の認証を要求するしくみ

■Azure ADでMFAを有効化する方法

- (a)「セキュリティの既定値群」を有効化
  - 無料でセキュリティを向上させる仕組み
  - 新しく作られたテナントではデフォルトで有効になっている
  - Microsoft Authenticatorを利用
  - Azure AD＞プロパティ＞セキュリティの既定値群
- (b)「条件付きアクセス」
  - 例1
    - 社内ネットワークアクセスの場合は追加の認証をスキップする
    - インターネットからのアクセスの場合は、追加の認証を要求する
  - 例2
    - 重要なアプリケーションへのアクセスの場合は、追加の認証を要求する
    - 重要度が低いアプリケーションへのアクセスの場合は、追加の認証をスキップする
  - 利用者にとって、より便利なしくみ
  - 有料（ライセンスが必要）
  - Microsoft Authenticatorのほか、電話、SMSなども利用できる
- (c)Azure AD＞ユーザー＞MFA
  - ユーザーごとにMFAを有効化する仕組み
  - (a)も(b)を使わない場合に利用する。
  - 古いやり方。

# mod1-3-1 Azure AD Identity Protection

https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection

■Identity Protectionとは？

ID ベースのリスクの検出。以下のようなサインインを検出することができる。

- 匿名 IP アドレスからのサインイン（Tor等）
- ユーザーの最近のサインインに基づき特殊と判断された場所からのサインイン。
- 指定されたユーザーで最近観察されていないプロパティを使用したサインイン。
- パスワードスプレー
  - よく使われるパスワードを多数のユーザーIDに対して試してみる攻撃

検出された場合に以下の「修復作業」をトリガーすることができる。

- 多要素認証(MFA)を要求する
- セルフサービス パスワード リセット(SSPR)を使用したパスワードのリセット
- 管理者がアクションを実行するまで、サインインをブロックする

管理者は、ポータルを使用してリスクを調査することができる。

- 検出内容を確認
- 必要に応じて手動で操作(ブロック等)

詳細な分析のために、サードパーティ製ユーティリティにリスク検出データをエクスポートすることができる。

- セキュリティ情報とイベント管理 (SIEM) ツールに送り戻して、組織の適用するポリシーに基づく詳細な調査を行う
- 例: Identity Protection からAzure Sentinelへのデータ接続
https://docs.microsoft.com/ja-jp/azure/sentinel/connect-azure-ad-identity-protection
  - Azure AD Identity Protection から Azure Sentinel にログをストリーミングし、Azure Sentinel にストリーミングしたアラームのダッシュボードに表示し、カスタム アラームを作成し、調査を改善できます。

■ポリシー

- 多要素認証（MFA）登録ポリシー
  - 新しいユーザーにMFAを登録させるかどうかの設定
- サインインリスクポリシー
  - 例
    - 匿名IPからのアクセス
    - ありえない移動
  - 正規のユーザーによるサインインが行われなかった確率をスコア化
    - スコアに基づいて、アクセスのブロック、追加のMFA要求などを発動
- ユーザーリスクポリシー
  - 例
    - ユーザーのID・パスワードがダークウェブに流出している場合、アクセスをブロックする
  - IDが侵害されている確率をスコア化
    - スコアに基づいて、アクセスのブロック、パスワードの変更などを発動

■「ユーザー リスク ポリシー」と「サインイン リスク ポリシー」の導入メリット

https://jpazureid.github.io/blog/azure-active-directory/identity-protection-riskpolicy-introduction/

# mod1-3-3 Azure AD 条件付きアクセス

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview

■条件付きアクセスとは？
    
- ユーザーがリソースにアクセスする場合、ユーザーはアクションを完了する必要があるという if-then ステートメント
- 条件付きアクセス ポリシーを使用すると、必要な場合は適切なアクセス制御を適用して組織のセキュリティを維持し、必要でない場合はユーザーの邪魔にならないようにすることができます。

# ラボ4b Identity Protection (演習3/4/5)

https://github.com/hiryamada/notes/blob/main/AZ-500/lab/lab04b-idp.md

# mod1-3-4 Azure AD アクセスレビュー

https://docs.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview


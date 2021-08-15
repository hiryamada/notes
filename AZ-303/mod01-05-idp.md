# Azure AD Identity Protection

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

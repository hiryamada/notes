# Identity Protection

https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/concept-identity-protection-risks#risk-types-and-detection

■ユーザーリスク

ユーザー関連の危険なアクティビティでは、特定の悪意のあるサインインではなく、ユーザーそのものに関連するものを検出します。

Risky activity can be detected for a user that isn't linked to a specific malicious sign-in but to the user itself.


- 漏洩した資格情報
- Azure AD脅威インテリジェンス

■サインインリスク

サインイン リスクは、特定の認証要求が ID 所有者によって承認されていない可能性があることを表します。

A sign-in risk represents the probability that a given authentication request isn't authorized by the identity owner.

- 匿名 IP アドレス
- 特殊な移動
- 異常なトークン
- トークン発行者の異常
- マルウェアにリンクした IP アドレス
- 疑わしいブラウザー
- 通常とは異なるサインイン プロパティ
- ユーザーに対するセキュリティ侵害を管理者が確認しました
- 悪意のある IP アドレス
- 受信トレイに対する疑わしい操作ルール
- パスワード スプレー
- あり得ない移動
- 初めての国
- 受信トレイからの疑わしい転送
- Azure AD 脅威インテリジェンス
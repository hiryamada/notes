# 条件付きアクセス

■ライセンス

Azure AD Premium P1 ライセンスが必要。

■ポリシーの適用条件

条件付きアクセス ポリシーは、第 1 段階認証が完了した後で適用される。

■MFA

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-azure-mfa

Azure AD Multi-Factor Authentication を有効にして使用する手段として、条件付きアクセス ポリシーを使った方法が推奨される。

■サインインリスクベースの条件付きアクセス

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-policy-risk

Azure AD Premium P2 のライセンスを所持する組織では、Azure AD Identity Protection のサインイン リスク検出を組み込んだ条件付きアクセス ポリシーを作成できる。

■ユーザーリスクベースの条件付きアクセス

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-policy-risk-user

Azure AD Premium P2 のライセンスを所持する組織では、Azure AD Identity Protection のユーザー リスク検出を組み込んだ条件付きアクセス ポリシーを作成できる。

拡張診断データ、レポート専用モードの統合、Graph API のサポート、ポリシーで他の条件付きアクセス属性を使用する機能など、より多くのコンテキストを提供するときは、条件付きアクセス ポリシーを使用した構成をお勧めします。


■Azure ADユーザー

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-users-azure-active-directory

Azure ADテナントに新しいユーザーを作成できる。

■ユーザーの種類

- テナント内に直接ユーザーを作成する（クラウド専用ID）
- 外部のユーザーをゲストとして招待する（ゲストユーザー）
- オンプレミスAD DSで管理されているユーザーIDを同期することでユーザーを作成する（同期ユーザー）

■ゲストユーザー

ゲストユーザーを作成できる。作成時に、メールアドレスを指定して、外部のユーザーをゲストユーザーとして「招待」することができる。

指定したメールアドレスに招待のメールが送信される。

招待されたゲストユーザーは、招待されたテナントで共同で作業ができるようになる。(B2Bコラボレーション)

B2Bコラボレーション:
https://learn.microsoft.com/ja-jp/azure/active-directory/external-identities/what-is-b2b

ゲストユーザーについてのよくある質問:
https://jpazureid.github.io/blog/azure-active-directory/b2bfaq/

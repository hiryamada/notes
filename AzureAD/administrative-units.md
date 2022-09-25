■管理単位 (Administrative units)

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/administrative-units

管理単位により、ロールのアクセス許可を、組織の任意の定義部分に限定することができる。

■例

- 管理単位を使わない場合
  - ユーザー user1 に「[パスワード管理者](https://learn.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#password-administrator)」を割り当てる
  - user1 はテナント内のすべてのユーザーのパスワードを管理できる
- 管理単位を使う場合
  - 管理単位「部署1」を作成する。
  - 「部署1」にユーザー user1, user2, user3 を含める
  - 「部署1」において、user1 に「[パスワード管理者](https://learn.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#password-administrator)」を割り当てる
  - user1 は、部署1 内のユーザー (user2, user3)のパスワードを管理できる

■ライセンス:

- 管理単位の管理者（ロールを割り当てるユーザー）には Azure AD Premium P1 ライセンスが必要
- 管理単位のメンバー（その他のユーザー）には P1ライセンスは不要（Azure AD Free でOK）

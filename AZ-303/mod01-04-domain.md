# 初期ドメイン名

https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/domains-manage

組織（テナント）が作成されると、その組織の「初期ドメイン名」が作成される。

その名前は「～～.onmicrosoft.com」となる。

たとえば、test@outlook.jp というメールアドレスのユーザーがAzureにサインアップすると、testoutlook.onmicrosoft.com という初期ドメイン名となる。

# カスタム ドメイン名

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-custom-domain

- ドメイン レジストラー側: ドメイン名を作成（購入）する
- Azure ADテナント側: カスタム ドメイン名として、そのドメイン名を追加する
  - TXTレコード/MXレコードの情報が表示される
- ドメイン レジストラー側: ドメインにTXTレコードまたはMXレコードを追加する
- Azure ADテナント側: カスタム ドメイン名を検証する

※検証が終わったらドメイン レジストラーに追加したレコードは削除できる

# プライマリ ドメイン名

- 新しいユーザーを作成したときの、そのユーザーの既定のドメイン名。
- テナント作成直後は、初期ドメイン名が、プライマリ ドメイン名となっている。
- カスタム ドメイン名を追加後、それを選択して「プライマリにする」をクリックすることで、追加したカスタム ドメイン名をプライマリ ドメイン名として利用できる。
- プライマリ ドメイン名を切り替えても、既存のユーザーのユーザー名は変更されない。


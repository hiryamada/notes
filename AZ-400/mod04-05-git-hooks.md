
## Git フックの重要性

フックを使用して、特定のアクションが発生したときにカスタムスクリプトを実行することができる。

[Git hook](https://git-scm.com/book/ja/v2/Git-%E3%81%AE%E3%82%AB%E3%82%B9%E3%82%BF%E3%83%9E%E3%82%A4%E3%82%BA-Git-%E3%83%95%E3%83%83%E3%82%AF)

フックでは、シェルスクリプト、PowerShell、Pythonコードなど、あらゆる実行可能形式を起動することができる。

フックは .git/hooks フォルダー以下に保存する。「～.sample」というサンプルが格納されているので、これを参考にすることができる。

フックの利用例: [1](https://blog.fenrir-inc.com/jp/2017/10/code-review-git-hooks.html), [2](https://efcl.info/2020/03/24/secretlint/)

コミット前に以下のコードチェックを実施
- コーディング規約に沿ってコードを書き換え
- ドキュメントコメントの有無のチェック
- 未使用コードの有無のチェック
- ユニットテストの実行
- APIトークンや秘密鍵のような機密情報の有無のチェック

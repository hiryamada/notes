# Azure Marketplace


# 使用例

Mattermostの起動とログインまで

- 画面上部の検索窓で「mattermost」と検索する
  - 検索結果の右上に「Marketplace」に検索結果が見つかる
  - 「Mattermost Team Edition Certified by Bitnami」をクリック
- 「概要」や「プランと価格」を確認する
- 「作成」または「デプロイ」をクリックする
- 仮想マシンの作成に必要な情報を入力する
  - 仮想マシン名 例：「mm」
  - 地域 例：「東日本」
  - サイズ 例：「B1ls」1vcpu, 0.5GiB, 556円/月
- 「確認及び作成」をクリック、「作成」をクリック
- デプロイの完了を待ち、「リソースに移動」をクリック
- 「ブート診断」の「シリアル ログ」で、初期パスワードを確認
  - `Setting Bitnami application password to 'xxxxxx'`といった出力
- 仮想マシンのパブリックIPアドレスをコピーし、別のタブで開く
- 「接続がプライベートではありません」といったエラー（`NET::ERR_CERT_AUTHORITY_INVALID`）となる
  - 「詳細設定」をクリック、「x.x.x.x へ進む」（安全ではありません）」をクリック
- Mattermostのログインを行う
  - Email or Username: user
  - Password: 「ブート診断」の「シリアル ログ」に表示された初期パスワード

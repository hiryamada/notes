# ラボ4b Identity Protection

想定時間: 60min

ラボ4の3, 4, 5を行います。

[ラボの手順書](https://microsoftlearning.github.io/AZ-500JA-AzureSecurityTechnologies/)の「04 - MFA、条件付きアクセス、AAD ID 保護」を見ながら実施します。また、本ページの補足事項も合わせてご確認ください。

演習1, 2は[ラボ4a](lab04a-mfa.md)で実施済みです。

（まだ準備していない場合は）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-500JA-AzureSecurityTechnologies/archive/master.zip)をダウンロードして展開しておきましょう。


## ラボの重要ポイント

- 演習3 (条件付きアクセス)Azure portal にサインインするときに MFA を必要とするポリシーを作成します
- 演習4 (Azure AD Identity Protection) 演習1で立ち上げたVM内で、ToRブラウザーを使って、匿名IPアドレスからの「アプリケーション アクセス パネル」へのアクセスを試行します。
- 演習5 (Azure AD Identity Protection) 演習4のアクセスのレポートを確認します。

# 事前準備

- 演習で使用するファイル: [ラボの目次ページ](https://microsoftlearning.github.io/AZ-500JA-AzureSecurityTechnologies/)上部の「こちらからダウンロードできます」をクリックしてZIPファイルをダウンロードし、展開しておきます。
- ご自身の携帯電話をご準備ください。
  - 電話番号によるテキストメッセージの着信ができる必要があります。
  - Microsoft Authenticatorアプリをインストールしておきます。
- 手順書と実際の画面の文言が異なる場合があります。実際の画面の表示をよく読んで操作を進めてください。

途中、Windows VMへのリモートデスクトップ接続が必要となります。リモートデスクトップ接続が使用できない環境では、代わりに[Azure Bastion](https://docs.microsoft.com/ja-jp/azure/bastion/tutorial-create-host-portal)を使用できます。

## 補足事項

### 演習3

演習3は[ラボ4a](lab04a-mfa.md)で作ったテナント「AdatumLab500-04」で実施します。

タスク1-5 「ユーザーとグループ」 をクリック → 「0 個のユーザーとグループが選択されました」をクリック

タスク1-5 「クラウド アプリまたはアクション」 をクリック → 「クラウド アプリまたは操作が選択されていません」をクリック

「Microsoft Azure 管理」 をクリック → 「Microsoft Azure Management」をクリック

「条件」 をクリック → 「0 個の条件が選択されました」をクリック

「サインイン情報のリスク」 → 「サインインのリスク」の「未構成」をクリック

### 演習4

タスク2-2 ユーザー アカウントを選択→→aaduser1/2/3以外の、最初から登録されているユーザー(Microsoftアカウントの名前が付いています)を選択します。

タスク4-5 ユーザー名「受講生」→Student

タスク6-6 IE セキュリティ強化の構成」 をクリック→ IE Enhanced Security Configuration

タスク6-14～15: 認証が終わると、画面に「NoScript XSS Warning」という青い画面が出ます（これは、Torのブラウザーに[NoScriptプラグイン](https://addons.mozilla.org/ja/firefox/addon/noscript/)が組み込まれていて、それが出している警告です。）。選択肢の一番下の「Always Allow」を選んで「OK」をクリックしてください。

タスク6-15: アプリケーション アクセス パネルに正常にサインインしたことを確認します。→ 画面左上に「My Apps」と表示されていればOKです。

# セキュリティの既定値群

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/concept-fundamentals-security-defaults

2020/11以降、「セキュリティの既定値群」が「有効」となっている。

- Entra ID P1/P2 ライセンスを持たない組織:
  - 「セキュリティの既定値群」を「有効」で使用する。
  - デフォルトのMFA設定が適用される。
- Entra ID P1/P2 ライセンスを持つ組織:
  - セキュリティの既定値群を「無効」に設定する
  - 組織独自のMFA設定を適用する。

# 組織独自のMFA設定例

- 新しい検証用テナントを作り、そのテナントに切り替える
- セキュリティの既定値群の有効化を「いいえ」に設定する。
- Entra ID Premium P2試用版を有効化する。
- ユーザーを作成する。パスワードを記録する。利用場所を設定する。ユーザーのUPNを記録する。
- ユーザーにP2ライセンスを割り当てる。
- 組織のMFAの設定を変更する。AAD＞セキュリティ＞MFA＞追加のクラウドベースのMFA設定＞サービス設定
- 例：「モバイル アプリまたはハードウェア トークンからの確認コード」にチェック
- ユーザーに対してMFAを有効化する。AAD＞セキュリティ＞MFA＞追加のクラウドベースのMFA設定＞ユーザー

# ユーザーの初回サインインとMFA登録
- スマートフォンにMFAアプリ（Microsoft Authenticator や Google Authenticator）をインストールする。
- portal.azure.comにアクセスする
- UPNとパスワードを入力する。
- MFAアプリで、画面に表示されたQRコードを読み取る

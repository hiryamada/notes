# FIDO

公式: https://fidoalliance.org/fido2/

MicrosoftのFIDO2のドキュメント:
https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-authentication-passwordless#fido2-security-keys

- パスワードレスの認証方法
- 2 番目のファクターとしての電話の使用を望まない、あるいは使用できないシナリオまたは従業員が存在する企業向けの優れたオプション

■FIDO（ファイド）とは？

参考: https://www.nec-solutioninnovators.co.jp/ss/insider/security-words/27.html

- FIDO（Fast Identity Online, ファイド）
  - 従来のパスワードに代わる認証手段として期待される認証技術の一つ
  - FIDO Allianceによって規格作成・推進が進められている
  - 2012年にFIDO 1.0、2017年にはFIDO 2.0 がリリースされた。
- FIDO Alliance
  - 大手IT企業も多数参加する業界団体
  - FIDOの規格の策定および普及推進を行う

参考: https://solution.kamome-e.com/blog/archive/blog-auth-20200908/

- FIDOでは、サーバーから認証を切り離し、ユーザーの手元に置く「認証器」と名付けたデバイスでユーザーを認証する。
- 認証器として想定しているのは、パソコンやスマートフォンなどのクライアントに組み込まれている生体認証装置、USBキーのような外付けの認証装置、パソコンでログインするときに認証でスマホを使うような場合の独立した認証装置――の3種類。
- 認証器を使うことで、サーバーがパスワードを管理する必要がなくなり、パスワードに頼らず複数のサーバーにアクセスできるようになり、ユーザーが複数のパスワードを覚える必要もなくなる。
- Webブラウザ上のアプリケーションがFIDO2を利用するためにWebAuthn（ウェブオースン）というJavaScript APIを規定している。

参考: https://www.cao.go.jp/others/soumu/pitch2m/pdf/20190820_6303siryou.pdf

- FIDOは、ID＋生体認証（パスワードレス）
- FIDO認証機には秘密鍵を保存。生体認証またはPINを使用して認証（パスワードレス）。
- サーバー側には公開鍵を保存。
- docomo、三菱UFJ銀行、LINE、Yahoo! Japan、Google、DropBox、GitHub、Facebook、Twitter、YouTube、AWSなどで利用可能。

■Azure ADで利用可能なFIDO2セキュリティキー

公式の一覧表（パスワードレスのエクスペリエンスと互換性があると認識されている、さまざまなフォーム ファクターの FIDO2 セキュリティ キー）
https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-authentication-passwordless#fido2-security-key-providers

Azure ADセキュリティキー（飛天ジャパン株式会社）
https://www.idaten.ne.jp/portal/page/out/dsf2/C1569_maker.pdf

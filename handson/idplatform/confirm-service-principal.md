
# ハンズオン: サービスプリンシパルの確認

Azure AD＞エンタープライズ アプリケーション

前のハンズオンで登録したアプリが一覧に表示されるので、それをクリックする。
- 画面左「アクセス許可」をクリック
- 「規定のディレクトリ に管理者の同意を与えます」をクリック。
  - この操作により、このテナントにおいて、管理者として、アプリケーションが要求するアクセスを許可することになる（管理者による同意）。
- 30秒ほど待って、画面上「更新」をクリック
- Microsoft.Graph という行が追加される。それをクリック
- 「クレームの値」で「User.Read」などが確認できる。

# Azure AD Connect

■Azure AD Connect

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect

- オンプレミスAD DSとAzure ADを同期するソフトウェア。
- 無料
- 以前DirSync や Azure AD Syncと呼ばれていたツールの後継
- Windowsアプリケーション
- オンプレミスのWindows Server 2012,2012 R2, 2016, 2019 にインストールする
- ドメインコントローラに同居させることもできる
- 複数のAzure AD Connectをデプロイして、可用性を向上させることもできる

ダウンロードはこちら:
https://www.microsoft.com/en-us/download/details.aspx?id=47594

■Azure AD Connectのインストール

- [簡単設定（Express Setting）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-express)
  - オンプレミスAD DSのフォレストが1つだけの場合に選択。
  - パスワードハッシュ同期（PHS）が設定される
- [カスタム設定（Custom Setting）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-custom)
  - 上記以外の設定を行う場合に選択。


■Azure AD ConnectのシームレスSSO（sSSO）

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso

- ユーザーが企業ネットワークに接続される会社のデバイスを使用するときに、自動的にサインインを行う仕組み。
- ユーザーは、オンプレミスとクラウドベースの両方のアプリケーションに自動的にサインインすることができる。
- Windows 10 + Microsoft Edge 等、さまざまなOS・ブラウザーの組み合わせをサポート
- パスワードハッシュ同期(PHS) または パススルー同期(PTA)と組み合わせて利用できる
- フェデレーション統合には適用できない
  - フェデレーション統合ではAD FSサーバーによるSSOを利用できる
- Azure AD Connectインストール中に、「Enable Single Sign On」（シングル サインオンを有効にする）にチェックを入れて有効化する。
- Active Directory のグループ ポリシーを利用して、対象ユーザーを選択する

SSO（sSSO）の利用パターン:

- PHS + sSSO
- PTA + sSSO
- フェデレーション + AD FSのSSO

具体的な設定方法:
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso-quick-start

■Azure AD Connectのステージングモード

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sync-staging-server

- インストール時、サーバーを ステージング モード に設定することを選択できる
- 新しい構成をテストする際や、高可用性の構成を取る（バックアップのAzure AD Conenctサーバーをステージングモードで動作させておき、メインのAzure AD Connectサーバーの障害発生時にバックアップに切り替える）場合などに利用できる
- 「インポート」（ADDSとAzure ADからAzure AD Connectサーバーへの情報の取り込み）と「同期」（Azure AD Connectサーバー内での、取り込んだ情報の統合）は行うが「エクスポート」（統合した情報のAzure ADへの反映）は行わない
  - ※[インポート・同期・エクスポートのわかりやすい解説](https://tech-lab.sios.jp/archives/20631#AADC3)

■Azure AD Connect Health

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#why-use-azure-ad-connect-health

- Azure AD Connect, AD DS, AD FSなどを監視する仕組み。
- 「Azure AD Connect Healthエージェント」とも呼ばれる
  - Azure AD Connect Health Agent for Sync - Azure AD Connect監視用エージェント
  - Azure AD Connect Health Agent for AD DS - AD DS監視用エージェント
  - Azure AD Connect Health AD FS Agent - AD FS監視用エージェント
- Azure AD Connectの場合、Connectがインストールされたサーバーに同居できる
- ライセンス: P1(最初のエージェントに1ライセンス、追加のエージェントごとに25ライセンス)
- 監視結果は、https://aka.ms/aadconnecthealth （Azure AD Connect Healthポータル）で確認できる

ダウンロードのリンクや、インストールの詳細についてはこちら: 
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-health-agent-install

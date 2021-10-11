# Azure AD Connect

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect

最新バージョンとダウンロードリンク
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/reference-connect-version-history

■歴史

2014/7 「Windows Azure Active Directory Sync (DirSync) 」最終リリース
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/reference-connect-dirsync-deprecated

2015/5 「Azure AD Sync (AADSync)」最終リリース
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/reference-connect-dirsync-deprecated

2015/6 「Azure AD Connect」 一般提供開始
https://azure.microsoft.com/en-us/updates/general-availability-azure-active-directory-connect/

2016/4/13 「Windows Azure Active Directory Sync (DirSync) 」と「Azure AD Sync (AADSync)」が非推奨となる
https://atmarkit.itmedia.co.jp/ait/articles/1704/12/news078.html

2017/4/13 「Windows Azure Active Directory Sync (DirSync) 」と「Azure AD Sync (AADSync)」のサポートが終了
https://atmarkit.itmedia.co.jp/ait/articles/1704/12/news078.html

2019/12 Azure AD Connect クラウド同期 プレビュー
https://techcommunity.microsoft.com/t5/azure-active-directory-identity/bring-identities-from-disconnected-ads-into-azure-ad-with-just-a/ba-p/827835

2021/2/3 Azure AD Connect クラウド同期 一般提供開始
https://techcommunity.microsoft.com/t5/azure-active-directory-identity/strengthen-your-hybrid-identity-with-these-new-azure-ad-connect/ba-p/1994721

2021/7/20 Azure AD Connect v2 (2.0.3.0) 提供開始
https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/whats-new#august-2021

■Azure AD Connect

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect

- オンプレミスAD DSとAzure ADを同期するソフトウェア。
- 無料
- 以前DirSync や Azure AD Syncと呼ばれていたツールの後継
- Windowsアプリケーション
- オンプレミスのWindows Server 2012,2012 R2, 2016, 2019 にインストールする
- ドメインコントローラに同居させることもできる
- 複数のAzure AD Connectをデプロイして、可用性を向上させることもできる

インストール要件
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-prerequisites

■リリース履歴

最新バージョンとダウンロードリンク

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/reference-connect-version-history

■Azure AD Connectのインストール

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-roadmap

- [簡単設定（Express Setting）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-express)
  - オンプレミスAD DSのフォレストが1つだけの場合に選択。
  - パスワードハッシュ同期（PHS）が設定される
- [カスタム設定（Custom Setting）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-custom)
  - 上記以外の設定を行う場合に選択。

■Azure AD ConnectのシームレスSSO（sSSO）

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso

- ユーザーが企業ネットワークに接続される会社のデバイスを使用するときに、自動的にサインインを行う仕組み。
- ユーザーは Azure AD にサインインするためにパスワードを入力する必要がなくなる
- ユーザーは、オンプレミスとクラウドベースの両方のアプリケーションに自動的にサインインすることができる。
- Windows 10 + Microsoft Edge, Mac OS X + Safari 等、[さまざまなOS・ブラウザーの組み合わせをサポート](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso#feature-highlights)
- パスワードハッシュ同期(PHS) または パススルー同期(PTA)と組み合わせて利用できる
- 「フェデレーション」には適用できない
  - 「フェデレーション」ではAD FSサーバーによるSSOを利用
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
- 「インポート」（ADDSとAzure ADからAzure AD Connectサーバーへの情報の取り込み）と「同期」（Azure AD Connectサーバー内での、取り込んだ情報の統合）は行うが「エクスポート」（統合した情報のAzure ADへの反映）は行わない
  - ※[インポート・同期・エクスポートのわかりやすい解説](https://tech-lab.sios.jp/archives/20631#AADC3)
- 新しい構成をテストする際や、高可用性の構成を取る（バックアップのAzure AD Conenctサーバーをステージングモードで動作させておき、メインのAzure AD Connectサーバーの障害発生時にバックアップに切り替える）場合などに利用できる

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


■参考: Azure AD Connect v2

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect-v2

https://atmarkit.itmedia.co.jp/ait/articles/2108/02/news010.html

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/whats-new#august-2021

- [最初のメジャーリリース 2.0.3.0 は 2021/7/20 にリリース。](https://docs.microsoft.com/en-us/azure/active-directory/hybrid/reference-connect-version-history#2030)

- Azure Active Directory (Azure AD) Connect の 1.x バージョンは2022 年 8 月 31 日にすべて廃止される

■参考: Azure AD Connect クラウド同期

https://docs.microsoft.com/ja-jp/azure/active-directory/cloud-sync/what-is-cloud-sync

2019/12 プレビュー
https://techcommunity.microsoft.com/t5/azure-active-directory-identity/bring-identities-from-disconnected-ads-into-azure-ad-with-just-a/ba-p/827835

2021/2/3 一般提供開始
https://techcommunity.microsoft.com/t5/azure-active-directory-identity/strengthen-your-hybrid-identity-with-these-new-azure-ad-connect/ba-p/1994721

- ユーザー、グループ、連絡先を Azure AD に同期するためのハイブリッド ID の目標を満たすために設計された新しいオファリング
- 複数の、接続されていないActive Directoryフォレストからの、AzureADテナントへの同期が可能
- Azure AD Connect アプリケーションではなく Azure AD エージェントを使用
- エンタープライズグレードの高可用性-複数のプロビジョニングエージェントを導入して、特にパスワードハッシュ同期のプロビジョニングの高可用性を確保できる

クラウド同期登場以降の名称:
- オンプレミスで運用されるAzure AD Connectは「Azure AD Connect同期」という。
  - オンプレミスには「Azure AD Connectアプリケーション」をインストールする
- クラウドで運用されるAzure AD Connectは「Azure AD Connect クラウド同期」という。
  - オンプレミスには軽量の「プロビジョニングエージェント」をインストールする
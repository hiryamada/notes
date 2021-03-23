# Azure AD Connect (ハイブリッドID)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect)

[デシジョンツリー（どの方式を使えばよいか？）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/choose-ad-authn#decision-tree)



# [パスワード ハッシュ同期（password hash synchronization: PHS）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-phs)

オンプレミスの Active Directory インスタンスから、クラウドベースの Azure AD インスタンスに、ユーザーのパスワードのハッシュを同期します。

オプションで「シームレスSSO」を有効化することで、オンプレミスのユーザーは、クラウドのアプリケーションにシングルサインオンを行うことができます。

最もシンプルな構成です。

パスワード（のハッシュ値）がクラウドに保存されます。それを避けたい場合は、「パススルー認証」または「フェデレーション統合」を使用します。

# [パススルー認証（Pass-through Authentication: PTA）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-pta)

ユーザーが Azure AD を使用してサインインするとき、ユーザーのパスワードがオンプレミスの Active Directory に対して直接検証されます。

オンプレミス パスワードが何らかの形でクラウドに保存されることはありません。

[オンプレミス側にPTAエージェント（認証エージェント）が必要。](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-pta-quick-start)追加のエージェントを複数のオンプレミス サーバーにインストールすることで、サインイン要求の高可用性を実現できます。


# [フェデレーション統合](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-fed)



# [シームレスSSO（sSSO）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso)

Azure Active Directory シームレス シングル サインオン (Azure AD シームレス SSO) では、ユーザーが企業ネットワークに接続される会社のデバイスを使用するときに、自動的にサインインを行います。

この機能を有効にすると、ユーザーは Azure AD にサインインするためにパスワードを入力する必要がなくなります。

シームレス SSO は、サインインの方法として、 パスワード ハッシュ同期またはパススルー認証のどちらとも組み合わせることができます。

シームレス SSO は、Active Directory フェデレーション サービス (ADFS) には適用できません。（ADFSを使用する場合は、AD FSサーバーを使用したシングルサインオンが可能です）

# パスワードライトバック

https://jpazureid.github.io/blog/azure-active-directory-connect/password-writeback-overview/

パスワード ライトバックを利用する上で、パスワード ハッシュ同期の有効化は必須ではありません。
パスワード ライトバックはパスワード ハッシュ同期による認証だけではなく、パススルー認証や AD FS の環境でもサポートされています。よって、認証方法によらず、同期ユーザーは Azure AD 側からもパスワード変更 (SSPR) をおこなうことができます。


# [Azure AD Connect Health](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#what-is-azure-ad-connect-health)

Azure AD Connectの正常性の監視機能。

[「Azure AD Connect Healthエージェント」をインストール](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-health-agent-install)する。

監視結果は「[Azure AD Connect Healthポータル](https://portal.azure.com/#blade/Microsoft_Azure_ADHybridHealth/AadHealthMenuBlade/QuickStart)」（Azure portal内）に表示される。

監視対象

- [Azure AD Connectの同期の監視](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-health-sync)
- [AD DSの監視](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-health-adds)
- [AD FSの監視](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-health-adfs)

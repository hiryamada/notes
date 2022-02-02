
https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/auth-radius

Azure Active Directory (Azure AD) では、RADIUS ベースのシステムを使用した多要素認証が有効になっています

https://kfep.jp/radius-news-2016-03-16-3001

「RADIUSサーバ」は、リモートアクセスにおいて、集中的にユーザ認証処理を行います。外部からの不正アクセス/不正侵入を防止するために、アクセスしてきたユーザが本当に利用権限を持つ者なのかを確認します。システム防衛の関所となる機能を果たします。

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps

P2S 接続には、以下のものが必要です。

ユーザー認証を処理する RADIUS サーバー。 RADIUS サーバーは、オンプレミスまたは Azure VNet にデプロイできます。 また、高可用性のために 2 つの RADIUS サーバーを構成することもできます。

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps#aboutad

P2S VPN の Active Directory (AD) ドメイン認証について

AD ドメイン認証では、ユーザーは組織のドメイン資格情報を使用して Azure にサインインできます。 これには AD サーバーと統合する RADIUS サーバーが必要です。 また、組織は既存の RADIUS デプロイを利用することもできます。

# Windows RADIUS サーバー (NPS) 

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps#3-set-up-your-radius-server

Windows RADIUS サーバー (NPS) 

ネットワーク ポリシー サーバー

https://docs.microsoft.com/ja-jp/windows-server/networking/technologies/nps/nps-top

RADIUS サーバー。 NPS は、ワイヤレス、認証スイッチ、リモート アクセス ダイヤルアップ、仮想プライベート ネットワーク (VPN) 接続の一元的な認証、承認、アカウンティングを実行します。 

# ハイブリッドID

■ハイブリッドIDとは？

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-hybrid-identity

- オンプレミスとクラウドの両方のアプリにアクセスできる、共通のユーザーID
- ユーザーは、同じIDを使用して、オンプレミスとクラウドの両方のアプリにアクセスすることができる
- Azure AD Connectを使用して実現する

```
Azure AD
└ユーザーA,B,CのID

↑ Azure AD Connect で同期（IDをコピー）

オンプレミスAD DS
└ユーザーA,B,CのID
```

■Azure AD Connect

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect

- オンプレミスAD DSとAzure ADを同期するソフトウェア。
- オンプレミスのWindows Serverにインストールする。
- 以前提供されていた古いID統合ツール（DirSync, Azure AD Sync）を置き換えるもの。
- 無料で利用できる。

```
Azure AD
↑同期
オンプレミス
├ Windows Server + Azure AD Connect
└ Windows Server（AD DS機能を追加）
```

詳しくは[次のページ](mod02-02-connect.md)で説明。

■同期

https://jpazureid.github.io/blog/azure-active-directory-connect/basic-points-directory-synchronization/

Azure AD Connectを使用して、オンプレミス側のID情報をAzure ADへ伝達すること。

同期は、Azure AD Connectに含まれる「[Azure AD Connect Sync](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sync-whatis)」コンポーネントで実行される。

同期は、**基本的に** 、オンプレミスAD DS → Azure AD の方向で行われる。

```
Azure AD
↑
Azure AD Connect
↑同期
オンプレミスAD DS
└ユーザーID
```

※パスワード ライトバックなど、[一部のオプション](https://jpazureid.github.io/blog/azure-active-directory-connect/basic-points-directory-synchronization/#1-AADC-%E3%81%AF%E3%82%AA%E3%83%B3%E3%83%97%E3%83%AC%E3%83%9F%E3%82%B9-AD-%E5%81%B4%E3%81%AE%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%81%8C-AAD-%E3%81%AB%E5%90%91%E3%81%91%E3%81%A6%E5%90%8C%E6%9C%9F%E3%81%95%E3%82%8C%E3%82%8B)では、Azure ADからオンプレミスAD DSへの情報の書き戻しが利用できる。

■パスワード ライトバック

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr-writeback

Azure AD側のパスワード変更を行った際、オンプレミスAD DS側に反映させることができる。

```
Azure AD ユーザーがパスワードを変更
↑      ↓ 変更後のパスワード
Azure AD Connect
↑同期  ↓
オンプレミスAD DS
```

使用するユーザーごとにP1またはP2ライセンスが必要。

サポートチームによる解説
https://jpazureid.github.io/blog/azure-active-directory-connect/password-writeback-overview/

■3つの認証方式

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-hybrid-identity

Azure AD Connectのインストール中に、認証方式を選択する。

- パスワードハッシュ同期 (Passsword Hash Sync: PHS)
  - Azure 側に、パスワードのハッシュ値を保存する方式。
- パススルー認証 (Pass Through Auth: PTA)
  - Azure 側で入力されたID/パスワードをオンプレミスのAD DSに送信して検証する方式。
- フェデレーション
  - オンプレミスの「AD FS」や「PingFederate」に、認証プロセスを引き継ぐ方式。

[まとめPDF](../AZ-500/pdf/mod1/Azure%20AD%20Connect.pdf)

■参考: フェデレーションとは

https://www.atmarkit.co.jp/fwin2k/operation/adfs2sso03/adfs2sso03_01.html

- オンプレミスに 以下をデプロイ
  - AD DS
  - 「Active Directory Federation Service (AD FS) 」または 「PingFederate(ピンフェデレート）」
- AD DSを使用して、IDを管理
- AD FSまたはPingFederateを使用して、クラウドアプリケーションへのシングルサインオンを実現

■参考: PingFederate(ピンフェデレート）とは

https://www.ntt.com/business/services/application/authentication/idf/pingfederate.html

https://www.pingidentity.com/en/software/pingfederate.html

- Ping Identity社のシングルサインオン製品
- オンプレミスのAD DSと連携できる
- Azure AD Connect でサポートされている。

■3つの認証方式の選択

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/choose-ad-authn

- Azure 側にパスワードハッシュ値を保存してもよい場合は、**パスワードハッシュ同期(PHS)** を使用。
- Azure 側にパスワードハッシュ値を保存したくない場合は、**パススルー認証(PTA)** または **フェデレーション** を使用
  - オンプレミスの AD DS のセキュリティとパスワード ポリシーを適用する必要がある場合は、**パススルー認証** を使用
  - オンプレミスに Active Directory Federation Service (AD FS) がデプロイされていて、引き続きそれを使用したい場合、オンプレのサードパーティMFAソリューションを使う場合、スマートカード認証をサポートするなどは、**フェデレーション** を使用。

■認証方式1: パスワードハッシュ同期 (Password hash synchronization, PHS)

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-phs

- パスワードのハッシュ値を同期
  -  [同期プロセスは 2 分間隔で実行される](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-password-hash-synchronization#how-password-hash-synchronization-works)
- ダークウェブ等に漏洩した資格情報の検出にも役立つ
  - [Identity Protection](https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection)の[リスク検出「漏洩した資格情報」](https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/concept-identity-protection-risks#user-linked-detections)
  - [パスワードハッシュ同期が必要](https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/concept-identity-protection-risks#password-hash-synchronization)

■※参考: ハッシュ値

Azure側には、生パスワードではなく、[ハッシュ関数](https://ja.wikipedia.org/wiki/%E3%83%8F%E3%83%83%E3%82%B7%E3%83%A5%E9%96%A2%E6%95%B0)から計算されたハッシュ値が保存される。

```
パスワード
 ↓ ハッシュ関数
ハッシュ値
```

ハッシュ値からパスワードを逆算することはできない.

■認証方式2: パススルー同期 (Pass-through authentication, PTA)

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-pta

- Azure ADに送信されたパスワードを、オンプレミスAD DSに送信して検証
- オンプレミスのインフラストラクチャに障害が発生した場合に、パスワード ハッシュ同期へフェイルオーバー（切り替え）することもできる
  - [自動でフェイルオーバーはしない](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-pta-faq#---------------------------------------)。手動で切り替えが必要

■認証方式3: フェデレーション (federation)

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-fed

- オンプレミスの「AD FS」や「PingFederate」とAzure ADでフェデレーションを構成
- オンプレミスの「AD FS」や「PingFederate」に、認証プロセスを引き継ぐ仕組み
- オンプレのサードパーティMFAソリューションを使う場合や、スマートカード認証をサポートするなど、高度な機能を利用できる
- AD FSで障害が発生した場合に備えて、[PHSを組み合わせる](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/tutorial-phs-backup)こともできる


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
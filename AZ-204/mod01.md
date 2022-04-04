# Azure App Service

https://docs.microsoft.com/ja-jp/azure/app-service/overview

[2015/3/24 一般提供開始](https://weblogs.asp.net/scottgu/announcing-the-new-azure-app-service)

以前に「Azure Websites」「Azure Mobile Services」と呼ばれていたものを統合。

2017/9/6 [App Service on Linux](https://azure.microsoft.com/en-us/blog/general-availability-of-app-service-on-linux-and-web-app-for-containers/) 

2017/9/6 [Linuxコンテナーをサポート（App Service Web App for Containers）](https://azure.microsoft.com/en-us/blog/general-availability-of-app-service-on-linux-and-web-app-for-containers/) 

2020/9/22 Windowsコンテナーをサポート https://azure.microsoft.com/ja-jp/updates/app-service-announces-general-availability-of-windows-container-support/

2021/8/25 可用性ゾーンをサポート https://azure.github.io/AppService/2021/08/25/App-service-support-for-availability-zones.html

■Azure App Serviceとは？

AzureのPaaSサービスの一つ。([PaaSの説明](https://azure.microsoft.com/ja-jp/overview/what-is-paas/))

Azure上で、HTTPベースのアプリケーション（WebアプリやWeb API）を稼働させることができる。

主な特徴:

- VM（仮想マシン）の管理や、OSの管理（アップデート）、.NETやJavaなどの言語ランタイムの管理（インストールやアップデート）が不要。
- VMスケールセットのような、負荷状況に合わせてインスタンス（VM）を増減させることができる機能も利用できる。
- ロードバランサーの機能も組み込まれている。
- Dockerコンテナー（LinuxとWindows）もサポートされている。開発者は、開発したDockerコンテナーをApp Serviceにデプロイすることもできる。

■Azure仮想マシン（VM）とApp Serviceは何が違うのか？

VMは、自由度が高いが、運用が大変。

App Serviceは、自由度はVMよりも低いが、運用が楽。

- VM: 
  - 使用するOSをイメージから指定（選択）できる
  - 任意のアプリやドライバーをインストールできる
  - 言語ランタイム（.NET、JRE、Python、Node.js等）はユーザーがインストールする
  - OSやソフトウェアのアップデート（セキュリティパッチ適用等）はユーザーが行う
  - RDPやSSHで接続できる
  - 開発したアプリのデプロイ方法を確立する必要がある
- App Service
  - 使用するOSは「Windows」と「Linux」とだけ指定できる
  - 開発したWebアプリ等をデプロイして運用できる
  - 言語ランタイム（.NET、JRE、Python、Node.js等）はあらかじめインストールされている
  - [OSやソフトウェアのアップデート（セキュリティパッチ適用）はAzureが行う](https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime)
  - [RDPやSSHで接続することはできない](https://docs.microsoft.com/ja-jp/azure/app-service/operating-system-functionality#remote-desktop-access)
  - App Service自身に複数のデプロイ方法が用意されている

■Azure仮想マシン（VM）とApp Serviceとはどう使い分ければよいのか？

https://docs.microsoft.com/ja-jp/azure/architecture/guide/technology-choices/compute-decision-tree

- VM
  - OSのアップデートのタイミングをコントロールしたい
  - 好きな言語ランタイムをインストールしたい
  - VMにRDPやSSHで接続してOSを細かくコントロールしたい
  - 負荷分散やスケーリングを自分でこまかく設定したい
- App Service
  - OSのアップデートはAzureに任せたい
  - App Serviceが提供する言語ランタイムを使用したい
  - VMにRDPやSSHで接続する必要がない
  - App Serviceが提供する負荷分散やスケーリングを使用したい

■Webアプリとは？

Webアプリ: ユーザーがWebブラウザーを使用して直接アクセスするアプリ。

```
ユーザー
↓
Webアプリ（Azure App Service上で稼働）
```

ASP.NET, ASP.NET Core, Node.js, Python, Ruby, PHPなどのWebアプリをApp Serviceで運用することができる。

その他の言語ランタイムを使用したい場合は、Dockerコンテナーを利用することで対応できる。

■Web APIとは？

Web API: ユーザーが使用するWebアプリやモバイルアプリ等から間接的にアクセスされるアプリ。バックエンド。

```
ユーザー
↓
Webアプリ/モバイルアプリ
↓ データの取得や保存など
Web API（Azure App Service上で稼働）
```

■App Service アプリ

App Service上にデプロイする、ユーザーのアプリケーション。

Webアプリや、Web APIなど。

Visual Studio、Visual Studio Code、Eclipse、PyCharmなどを使用して、ローカルの開発環境でWebアプリ等を開発する。

その後、開発したコードをApp Service上にデプロイして、Azure上で稼働させる。

App Serviceアプリは「App Serviceプラン」にデプロイする。つまり、App Serviceアプリを動かすには必ずApp Serviceプランが必要となる。

■App Serviceプラン

「App Serviceプラン」を作成し、そこに「App Serviceアプリ」をデプロイする。

（アプリを作成するときに、プランがなければ、プランも同時に作られる）

1つのプランで複数のアプリを運用することができる。

```
App Service プラン (米国東部リージョン、Windows、Free)
├App Service アプリ1 (ASP.NET Core Webアプリ)
└App Service アプリ2 (Java Webアプリ)

App Service プラン (米国西部リージョン、Linux、Standard S1)
├App Service アプリ1 (ASP.NET Core Webアプリ)
└App Service アプリ2 (Java Webアプリ)
```

■開発の流れの例

まずAzure上にプランとアプリのリソースをデプロイ（作成）する。

```
App Service プラン (米国東部リージョン、Windows、Free)
└App Service アプリ (.NET)
```

このとき、アプリでは、サンプルのWebアプリケーションが稼働する。

次に、開発者のローカルの開発環境で、Webアプリを開発・デバッグする。

```
Webアプリ
  ↑ 開発・デバッグ
開発者のローカルPC
```

開発が完了したWebアプリを、App Serviceアプリへとデプロイする。

```
App Service プラン (米国東部リージョン、Windows、Free)
└App Service アプリ (.NET)
  ↑ デプロイ
Webアプリ
  ↑ 開発
開発者のローカルPC
```

■プランの「価格レベル」

- Free
  - F1
- Shared(Windowsのみ)
  - D1
- Basic
  - B1, B2, B3
- Standard
  - S1, S2, S3
- Premium
  - P1, P2, P3
  - P1V2, P2V2, P3V2
  - P1V3, P2V3, P3V3
- Isolated
  - l1, l2, l3
  - l1v2, l2v2, l3v2

これらの選択により、プランで使える性能と機能が変化する。

例1:
- 「Basic」
  - 手動スケールが使用できる
  - インスタンス数を1個～3個の間で調節できる。
- 「Standard S1」
  - 自動スケールが使用できる
  - インスタンス数を1個～10個の間で調節できる。

例2:
- 「Standard S1」
  - 1 コア、1.75 GB メモリ
- 「Standard S2」
  - 2 コア、3.50 GB メモリ
- 「Standard S3」
  - 4 コア、7 GB メモリ

プランの価格レベルは変更することができる。

■プランのOS

- https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/
- https://azure.microsoft.com/ja-jp/pricing/details/app-service/linux/
 
WindowsとLinuxから選べる。

言語によっては、OSが限定される場合がある。

例: 
- .NETアプリ: WindowsでもLinuxでも動く。
- Rubyアプリ: Linuxでのみ動く。

■プランのスケールアップ・スケールダウン

プランの「価格レベル」を変更すること。

- Free
- Shared(Windowsのみ)
- Basic
- Standard
- Premium
- (Isolated)

注: Isolatedプラン以外のプランと、Isolatedのプランの間での変更はできない。

■Freeプランはいくつまで使える？

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#app-service-limits

リージョンあたり 10 個まで。

■プランのスケールアウト・スケールイン

https://docs.microsoft.com/ja-jp/azure/app-service/overview-hosting-plans#how-does-my-app-run-and-scale

よりたくさんのトラフィックを処理するには、App Serviceプランの「インスタンス数」（＝プランを構成する内部のVMの数）を増やす。

※FreeとSharedを除く。

```
App Service プラン(インスタンス数: 1)
├ App Serviceアプリ1
└ App Serviceアプリ2

↓ スケールアウト ↑ スケールイン

App Service プラン(インスタンス数: 2)
├ App Serviceアプリ1
└ App Serviceアプリ2
```

※プラン内のアプリは、すべてのインスタンスで実行される。

※App Service内にロードバランサーが内蔵されているため、インスタンス数が1個でも複数個でも、特にアクセス方法に変わりはない。

■手動スケールと自動スケール

Free、Sharedでは自動スケールも手動スケールも利用できない。

Basic以上のプランでは、手動スケールを利用することができる。管理者が、状況に応じて、手動でインスタンスを増減させる。

プランの負荷が高いときはインスタンスを増やして処理能力を高めることができる。プランの負荷が低いときはインスタンスを減らしてコストを削減できる。

Standard以上のプランでは、自動スケールを利用することができる。プランの負荷状況に合わせて、自動的にインスタンスを増減させることができる。

■App Serviceの料金

https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/

この料金表は、インスタンスが1個の場合の料金を示している。インスタンスが複数個の場合の料金は[Azure料金計算ツール](https://azure.microsoft.com/ja-jp/pricing/calculator/)を使用して計算できる。

- App Serviceの料金は「プラン」に対して発生。
  - プランの上でいくつアプリを動かしても料金は変わらない
- （Azure VMとは異なり）プランは「停止」することができない
  - 「停止」して料金の発生をストップさせることはできない
- プラン内で「インスタンス」を増減できる場合(Basicプラン以上)
  - インスタンスに比例した料金が発生する
- プランの「価格レベル」は変更することができる
  - Premium P1 から Standard S1 に変更する、など。

例: Standard S1 (1コア、1.75 GB メモリ), West US, Windows
- 1インスタンス: 月73ドル
- 2インスタンス: 月146ドル
- 3インスタンス: 月219ドル
- ...
- 10インスタンス: 月730ドル


■主なコードのデプロイ方法

(1) [ローカル Git デプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-local-git)

```
App Serviceアプリ(Gitリポジトリ)
↑ git push
ローカル開発環境
```

(2) [ZIP/WARデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip) - [az webapp depoloyment source config-zipコマンドを利用](https://docs.microsoft.com/ja-jp/cli/azure/webapp/deployment/source?view=azure-cli-latest#az_webapp_deployment_source_config_zip)

```
App Serviceアプリ
↑ 成果物のZIP/WARをアップロード
ローカル開発環境
```

(3) [GitHub Actions](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-github-actions?tabs=applevel)

```
App Serviceアプリ
↑ GitHubアクション
GitHub
↑ git push
ローカル開発環境
```

(4) [継続的デプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-continuous-deployment)

```
App Serviceアプリ
↑ git pull
GitHub/BitBucket/Azure Repos
↑ git push
ローカル開発環境
```

その他:

- [FTP/FTPSによるデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-ftp?tabs=portal)
- [Dropbox/OneDriveからのデプロイ(コンテンツ同期)](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-content-sync?tabs=portal)
- [コンテナーのCI/CD](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-ci-cd-custom-container?tabs=acr&pivots=container-linux)
- [ARMテンプレートによるデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-complex-application-predictably)

■App Service組み込みのユーザー認証機能（Easy Auth）

https://docs.microsoft.com/ja-jp/azure/app-service/overview-authentication-authorization

（アプリ自体に認証の仕組みがない場合）デフォルトでは、App Serviceアプリには、ユーザー認証なしでアクセスすることができる。

最小限のコードと設定で、アプリにユーザー認証機能を追加することができる。

- Microsoft IDプラットフォーム
  - Azure ADのユーザー
  - Microsoftアカウント
- Facebook
- Google
- Twitter
- 任意のOpenID Connectプロバイダー

※App Service組み込みのユーザー認証機能を使用せず、アプリ側で独自のユーザー認証を実装することもできる。すでにアプリが独自のユーザー認証機能を実装している場合は、App Service組み込みのユーザー認証機能を使用する必要はない。

■App ServiceにおけるOSの更新

https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime


Azure では、2 つのレベルで OS が管理される。

- 物理サーバー
  - [Windows Hyper-Vを基盤としている](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/hypervisor)
- App Service を実行するゲスト仮想マシン(VM)
  - ユーザーが選択したOS(Windows/Linux)

```
App Serviceアプリ
-----------------
 ゲスト仮想マシン ← OS
-----------------
   物理サーバー ← OS
```


- [セキュリティ更新プログラムは通常、米国日付の毎月第 2 火曜日に公開される。](https://msrc-blog.microsoft.com/2020/11/10/securityupdatereleaseschedule2021/)
- App Serviceも、このスケジュールに従って更新が適用される
- ゼロデイ脆弱性など、深刻な脆弱性に対して迅速にパッチを適用する必要がある場合、ケースバイケースで優先度の高い更新プログラムが適用される

このとき、[App Serviceの可用性が低下しない方法で、OS更新が実施される](https://satonaoki.wordpress.com/2018/01/25/demystifying-the-magic-behind-app-service-os-updates/)。

```
   App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v1)    ゲスト仮想マシン2(v1) 
---------------------   ---------------------
   物理サーバー1(v1)        物理サーバー2(v1)
```

アプリが動作していない利用可能なインスタンスをアップデート

```
   App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v1)    ゲスト仮想マシン2(v2) 
---------------------   ---------------------
   物理サーバー1(v1)        物理サーバー2(v2)
```

アップデート済みのインスタンスにアプリを移動（アプリはコールドスタートする）

```
                           App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v1)    ゲスト仮想マシン2(v2) 
---------------------   ---------------------
   物理サーバー1(v1)        物理サーバー2(v2)
```

アプリがなくなったインスタンスをアップデート

```
                           App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v2)    ゲスト仮想マシン2(v2) 
---------------------   ---------------------
   物理サーバー1(v2)        物理サーバー2(v2)
```

■App Serviceの言語ランタイムの更新・追加・非推奨化・廃止

https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime#when-are-supported-language-runtimes-updated-added-or-deprecated

[まとめ資料](pdf/mod01/App%20Serviceの「更新」.pdf)

サポートされる言語ランタイムの新しい安定バージョン (メジャー、マイナー、またはパッチ) は、App Service に定期的に追加される。

ランタイムの追加と廃止は以下で発表される。

- https://azure.microsoft.com/ja-jp/updates/?product=app-service
- https://github.com/Azure/app-service-announcements/issues

[Java](https://docs.microsoft.com/ja-jp/azure/app-service/configure-language-java?pivots=platform-linux#deprecation-and-retirement)については、影響を受けるランタイムを使用している Azure の開発者には、ランタイム終了の少なくとも 6 か月前までに廃止の通知が送信される。

アプリ側では、使用する言語ランタイムのバージョンを以下のようにして指定する。

```
az webapp config set --net-framework-version v4.7 
az webapp config set --linux-fx-version "DOTNETCORE|3.1"
az webapp config set --php-version 7.0 
az webapp config appsettings set --settings WEBSITE_NODE_DEFAULT_VERSION=8.9.3 
az webapp config set --python-version 3.8 
az webapp config set --java-version 1.8 --java-container Tomcat --java-container-version 9.0 
```

参考: 
- [ランタイムバージョンの指定](https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime#new-major-and-minor-versions)
- [.NET Coreバージョンの設定](https://docs.microsoft.com/ja-jp/azure/app-service/configure-language-dotnetcore?pivots=platform-linux#set-net-core-version)

■VNetでのApp Service運用

https://docs.microsoft.com/ja-jp/azure/app-service/environment/overview

App ServiceをVNet内で運用したい場合は、「App Service Environments」を使用する。

[App Service Environmentについてのまとめ](mod01-ase.md)

■アクセスの制限

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#access-restrictions

App Serviceに対する、特定のIPアドレスからの接続を許可・拒否したい場合は、「アクセスの制限」を使用する。

- 優先順位に従って評価される許可規則と拒否規則のリスト。
- 受信要求をフィルター処理する。

■サービスエンドポイント/プライベートエンドポイント

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#access-restriction-rules-based-on-service-endpoints

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#private-endpoint

特定のVNetの特定のサブネットからのみ、App Serviceへの接続を許可したい場合は、「サービスエンドポイント」 または 「プライベート エンドポイント」を使用する。

サービスエンドポイント:

```
         App Service
              ↑
VNet          |
└サブネット（サービスエンドポイント）
 └VM
```

プライベート エンドポイント:

```
          App Service
               ↑
VNet           |
└サブネット     |
 ├プライベートエンドポイント(NIC)
 └VM
```

いずれの場合でも、トラフィックはAzureの内部を通り、インターネットを経由しない。

参考: [まとめ資料: サービスエンドポイントとプライベートエンドポイント](../AZ-104/pdf/mod06/サービスエンドポイントvsプライベートエンドポイント.pdf)

■ハイブリッド接続

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#hybrid-connections

https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections

VPNや専用線（ExpressRoute）を使用せず、App Serviceから、オンプレミスのDB等にアクセスしたい場合、「ハイブリッド接続」を利用する。

```
App Service
 ↑   ↓ 
オンプレミスのファイアウォール
 ↑   ↓
オンプレミス Windows Server＋「ハイブリッド接続マネージャー」
     ↓
オンプレミスDB等
```

このとき、オンプレミス側のファイアウォールに「穴」を開ける必要はない。Azureへの接続は、ハイブリッド接続マネージャの側から、ポート443(HTTPS)を使用して行われる。この接続を利用して、App Serviceアプリは、オンプレミスのDB等へTCP接続することができる。

特徴:
- オンプレミスのシステムとサービスに簡単に接続できる
- UDPは使用できない

詳しくは[ハイブリット接続のメリット](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections#app-service-hybrid-connection-benefits)・[ハイブリット接続で実行できないこと](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections#things-you-cannot-do-with-hybrid-connections)を参照。


■App Serviceのアドレス(FQDN)

たとえば example という名前のアプリをデプロイすると example.azurewebsites.net という名前のFQDNがアプリに割り当てられる。


■App Serviceの受信IPアドレス

https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#find-the-inbound-ip

オンプレミスから、App Serviceへのアクセスを許可する際に、App Serviceのアプリの受信IPアドレスを特定する必要がある。

```
App Service アプリ(a.b.c.d)
↑
オンプレミスのファイアウォール(a.b.c.dへの発信を許可)
↑
オンプレミスのコンピュータ
```

たとえば example という名前のアプリをデプロイした場合、そのIPアドレスは以下のようにして調べることができる。

```
nslookup example.azurewebsites.net
```

受信IPアドレスはアプリに対して1つだけである。

アプリを削除して、別のリソースグループにアプリを再作成するなどした場合に、アプリの受信IPアドレスが変わる場合がある。[詳細](https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#when-inbound-ip-changes)

■App Serviceの送信IPアドレス

App Serviceから、オンプレミスのコンピュータへのアクセスを許可する際に、App ServiceのアプリのIPアドレスを特定したい場合がある。

```
App Service アプリ(a.b.c.d)
↓
オンプレミスのファイアウォール(a.b.c.dへの着信を許可)
↓
オンプレミスのコンピュータ(DMZ)
```

送信IPアドレスは、アプリに対して複数割り当てされる。これらは、アプリの受信IPアドレスとは異なる。

https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#find-outbound-ips

以下のコマンドでアプリの送信IPアドレスを調べることができる。

```
az webapp show --query outboundIpAddresses 
```

■デプロイスロット

Standard以上のプランで実行しているアプリでは、一つのアプリで複数の「デプロイスロット」を使用することができる。

初期状態:

```
App Service アプリ(example)
└運用スロット(example.azurewebsites.net)
```

「ステージング」(staging)という名前の「デプロイスロット」を追加した状態:

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net)
└ステージングスロット(example-staging.azurewebsites.net)
```

デプロイスロットは、それぞれ「～.azurewebsites.net」というFQDNを持つ。これらのFQDNを使用して、それぞれのデプロイスロットのアプリにアクセスできる。

デプロイスロットはそれぞれ独立して動作し、他のデプロイスロットの動作に影響を与えない。

たとえば、あるアプリで、「運用スロット」に、バージョン1(v1)のコードがデプロイされているとする。エンドユーザー（一般の利用者）は、「運用スロット」にアクセスして、このアプリを利用する。

```
App Service アプリ(example)
└運用スロット(example.azurewebsites.net): v1 ← エンドユーザー
```

開発者は、「ステージングスロット」を追加し、そこにバージョン2(v2)のコードをデプロイし、動作を確認することができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v1 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v2 ← 開発者
```

動作確認が終わったら、開発者は「スワップ」（入れ替え）操作を実行して、v1とv2を入れ替えることができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v2 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v1 ← 開発者
```

エンドユーザーは、今までと同じFQDN（example.azurewebsites.net）を使用してアプリにアクセスすることができる。

開発者は、ステージングスロットを使用して、引き続き次のバージョン（v3）のデプロイと動作確認を行うことができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v2 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v3 ← 開発者
```

※実際には、「スワップ」は、2つのスロットのルーティング規則を入れ替えることで行われる。（ドキュメントの[手順5番](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-staging-slots#swap-operation-steps)を参照）

■カスタム ドメインの利用

App Serviceでは、各アプリ（のデプロイスロット）に`example.azurewebsites.net`といったFQDNが割り当てられる。

このFQDNではなく、独自のドメイン（`www.example.co.jp`等）を使用してアプリを運用したい場合は、カスタム ドメインの割り当てを行う。

[既存の（取得済みの）カスタム ドメイン名をApp Serviceに割り当てる](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-web-tutorial-custom-domain?tabs=cname)ことができる。

また、Azure 上で、[新しいカスタム ドメイン名を購入する](https://docs.microsoft.com/ja-jp/azure/app-service/manage-custom-dns-buy-domain)こともできる。





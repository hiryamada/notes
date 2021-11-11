# Azure AD アプリケーション プロキシ

https://docs.microsoft.com/ja-jp/azure/active-directory/app-proxy/what-is-application-proxy

- アプリケーション プロキシは、Azure portal で構成する Azure AD サービス
- Azure Cloud に外部のパブリック HTTP/HTTPS URL エンドポイントを発行し、それを組織の内部アプリケーション サーバーの URL に接続することができる
- コンポーネント
  - クラウドで実行するアプリケーション プロキシ サービス
  - オンプレミスのサーバーで実行する軽量エージェントのアプリケーション プロキシ コネクタ
  - Azure AD（IDプロバイダー）
- ユーザーは、サインイン後、使い慣れた URL を使用するか、自分のデスクトップまたは iOS/MAC デバイスのマイ アプリから、オンプレミス Web アプリケーションにアクセスできる

https://docs.microsoft.com/ja-jp/azure/active-directory/app-proxy/application-proxy

- オンプレミス Web アプリケーションへのセキュリティ保護されたリモート アクセスを提供
- クラウド アプリケーションとオンプレミス アプリケーションの両方にアクセスできる
- ユーザーは、Microsoft 365 や Azure AD に統合された他の SaaS アプリにアクセスするのと同じように、オンプレミスのアプリケーションにアクセスできる



# Webアプリケーション プロキシ (WAP)

https://atmarkit.itmedia.co.jp/ait/articles/1508/25/news018.html

- **Active Directoryフェデレーションサービス（AD FS）と連携して動作**する“HTTPSアプリケーションのためのリバースプロキシ”。
- 企業ネットワークの内部で稼働するアプリケーションに対し、AD FS認証に基づくアクセスを外部のユーザーやデバイスに提供できる

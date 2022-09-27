# Azure Web Application Firewall (WAF)

https://docs.microsoft.com/ja-jp/azure/web-application-firewall/overview

- Webアプリケーションファイアウォールのサービス。
- SQL インジェクション攻撃やクロスサイト スクリプティング攻撃から、Webアプリを保護
- 以下のサービスと組み合わせて利用できる
  - Azure Application Gateway
  - Azure Front Door
  - Azure Content Delivery Network (CDN)

■WAFのモード

- 検出モード（Detection mode）
  - すべての脅威アラートを監視してログに記録
  - リクエストをブロックしない
- 防止モード（Prevention mode）
  - 規則で検出された侵入や攻撃のリクエストをブロックする
  - WAFログにも記録

本番環境では、まず検出モードでしばらく運用し、例外やカスタムルールを設定してから、防止モードにするとよい。

■App Service Environment (ASE) について

- より大規模なスケーリングへの対応が可能
  - 極めて高い RPS (Requests Per Second: 1 秒あたりの要求数)への対応が可能
- 分離およびセキュリティで保護されたネットワーク アクセスを提供
  - App Service環境を特定のVNetにデプロイすることができる
- サブスクリプションで専有されるホスティング環境を提供
  - 特定のコンプライアンス要件を満たすことができる

■ASEのバージョン

v1, v2, v3がある。

App Service Environment v1の概要
https://docs.microsoft.com/ja-jp/azure/app-service/environment/app-service-app-service-environment-intro

App Service Environment v2の概要
https://docs.microsoft.com/ja-jp/azure/app-service/environment/intro

App Service Environment v3の概要
https://docs.microsoft.com/ja-jp/azure/app-service/environment/overview

■各バージョン登場時のブログ等

2015/4/29 App Service Environment preview
https://azure.microsoft.com/en-us/updates/preview-azure-app-service-environment/

- サブスクリプションで専有されるランタイム環境
- より細かいカスタマイズとコントロールが可能
- VNet内でのASE作成
- より高いスケール

2017/7/27 App Service Environment v2 (v1からのアップグレードがリリースされた)
https://azure.microsoft.com/en-us/blog/announcing-app-service-environment-v2/

- ワーカープールを選択するのではなく、「Pricing cards」から選択するようになった。ワーカーは自動で追加される。
- Isolatedプランが提供されるようになった
- v1では50ワーカーまでだったスケーリングが、100までスケールできるようになった。
- Dv2ベースのワーカーを使用することで、CPUがより高速になった

2018/8/8 Linux on Azure App Service Environment の一般提供
https://azure.microsoft.com/ja-jp/blog/linux-on-azure-app-service-environment-now-generally-available/

2021/7/7 App Service Environment v3
https://azure.microsoft.com/ja-jp/updates/app-service-environment-v3-now-generally-available/

- Isolated v2プランで利用
- 可用性ゾーンのサポート
- 専有ホストグループへのデプロイ

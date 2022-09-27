# Azure Firewall

https://docs.microsoft.com/ja-jp/azure/networking/fundamentals/networking-overview#azure-firewall

https://docs.microsoft.com/ja-jp/azure/firewall/overview

■Azure Firewallとは？

[まとめ資料](https://github.com/hiryamada/notes/blob/main/AZ-104/pdf/mod04/Azure%20Firewall.pdf)

- VNet内のリソースを保護するためのサービス
- マネージド サービス (Firewall as a Service)
  - 組み込みの高可用性
  - 無制限のスケーラビリティ
- ステートフルなファイアウォール(戻りのトラフィックを自動で許可)
- アプリケーションとネットワークの接続ポリシーを、サブスクリプションと仮想ネットワークをまたいで一元的に作成、適用、記録することができる

■参考: Azure Filrewall Premium とは？

現在プレビュー
- https://azure.microsoft.com/ja-jp/updates/azure-firewall-premium-now-in-public-preview/
- https://docs.microsoft.com/ja-jp/azure/firewall/premium-features
- https://www.ether-zone.com/azure-firewall-premium/

特徴
- ファイアウォール ポリシー
  - このリリースからは、すべての新機能はファイアウォール ポリシーによってのみ構成
- TLSインスペクション（TLS検査）
  - アウトバウンド トラフィックを復号化し、データを処理し、その後にデータを暗号化して宛先に送信
  - Azure Firewallに中間CA証明書が必要
- シグネチャベースのIDPS（ネットワーク侵入検出と防止システム） 
  - ネットワーク トラフィック内のバイト シーケンスやマルウェアによって使用される既知の悪意のある命令シーケンスなど、特定のパターンを探すことによって攻撃を迅速に検出できます。
- URL フィルタリング
  - Azure Firewall の FQDN フィルタリング機能を拡張して URL 全体が考慮対象になるようにします。
- Web カテゴリ
  - 管理者は、ギャンブルの Web サイトやソーシャル メディアの Web サイトなどの Web サイト カテゴリへのユーザーのアクセスを許可または拒否できます。

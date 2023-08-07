# AZ-104 まとめ

## ラーニングパス1 IDとガバナンス

- IDの管理
  - [Azure AD(ユーザー管理を一元化)](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis)
  - [Azure AD 動的グループ(条件に従いユーザーのグループへの所属を自動で調整)](https://learn.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-dynamic-membership)
  - [Azure AD SSPR(セルフサービスパスワードリセット、エンドユーザーがパスワードを自分でリセットできる)](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)

## ラーニングパス2 Azure管理者の前提条件

- Azureの基本的な構造・管理の仕組み
  - [管理グループ(複数のサブスクリプションをグループ化・階層化)](https://learn.microsoft.com/ja-jp/azure/governance/management-groups/overview)
  - [サブスクリプション(リソースの管理と課金の管理)](https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/considerations/fundamental-concepts#azure-subscription-purposes)
  - [リソースグループ(複数のリソースをまとめる)](https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/management/manage-resource-groups-portal)
  - [タグ(リソースに管理用の情報を付与)](https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/management/tag-resources)
  - [ロック(重要なリソースの変更・削除を防止)](https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/management/lock-resources?tabs=json)
  - [Azureポリシー(リソースのルールを設定)](https://learn.microsoft.com/ja-jp/azure/governance/policy/overview)
  - [Azureロール(ユーザー等に操作の許可を与える)](https://learn.microsoft.com/ja-jp/azure/role-based-access-control/overview)
- Azureの操作
  - [Azure portal(Azureの管理画面)](https://learn.microsoft.com/ja-jp/azure/azure-portal/azure-portal-overview)
  - [Azure Cloud Shell(Azure portalに組み込まれたシェル環境)](https://learn.microsoft.com/ja-jp/azure/cloud-shell/quickstart-powershell)
  - [ARMテンプレート(リソースをJSONで定義、一括デプロイ) ](https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview)
  - [Azure PowerShell(PowerShellに組み込むモジュール、Azureの操作用) ](https://learn.microsoft.com/ja-jp/powershell/azure/what-is-azure-powershell?view=azps-9.4.0)
  - [Azure CLI(Azureの操作を行うコマンド) ](https://learn.microsoft.com/ja-jp/cli/azure/what-is-azure-cli)


## ラーニングパス3 ストレージ

- Azureの基本的なストレージのサービス
  - [ストレージアカウント(Blob/Files/Table/Queueの4サービスを提供)](https://learn.microsoft.com/ja-jp/azure/storage/common/storage-account-overview)
  - [Blob Storage(オブジェクトストレージ)](https://learn.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction)
  - [Azure Files(ネットワーク接続で利用するファイルシステム、SMB/NFSでアクセス可)](https://learn.microsoft.com/ja-jp/azure/storage/files/storage-files-introduction)
  - [Azure File Sync(Azure FilesのファイルをオンプレミスWindows Serverにキャッシュ)](https://learn.microsoft.com/ja-jp/azure/storage/file-sync/file-sync-introduction)
- アクセス制御、暗号化
  - [SAS(別のクライアントへのデータアクセスの委任を行う)](https://learn.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview)
  - [SSE(サーバーサイドでデータを自動で暗号化。カスタマーマネージドキーなども使用可)](https://learn.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption)

## ラーニングパス4 コンピューティング

- 仮想マシン
  - [Azure 仮想マシン(Windows/Linuxの仮想サーバー)](https://learn.microsoft.com/ja-jp/azure/virtual-machines/overview)
  - [仮想マシンスケールセット（VMのグループを作成、インスタンスを増減）](https://learn.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview)
- PaaS
  - [Azure App Service(Webアプリを素早くホスティング)](https://learn.microsoft.com/ja-jp/azure/app-service/overview)
- コンテナー
  - [Azure Container Instance(コンテナーを素早く実行)](https://learn.microsoft.com/ja-jp/azure/container-instances/container-instances-overview)
  - [Azure Kubernetes Service(Kubernetesクラスターを素早く作成)](https://learn.microsoft.com/ja-jp/azure/aks/intro-kubernetes)

## ラーニングパス5 ネットワーク

- [仮想ネットワーク(Azure上に隔離されたネットワークを作成,VMを運用)](https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview)
- [ネットワークセキュリティグループ（IPアドレス・ポート番号・プロトコルで、ネットワークアクセスを許可・拒否）](https://learn.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview)
- [Azure Load Balancer（レイヤー4 TCP/UDPで動作するロードバランサー）](https://learn.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview)
- [Azure Application Gateway （レイヤー7 HTTP/HTTPSで動作するロードバランサー）](https://learn.microsoft.com/ja-jp/azure/application-gateway/overview)

## ラーニングパス6 監視とバックアップ

- 監視(モニタリング)
  - [Azure Monitor（Azureリソースの監視。ログとメトリックを収集）](https://learn.microsoft.com/ja-jp/azure/azure-monitor/overview)
  - [Log Analytics（ログを蓄積、クエリを実行）](https://learn.microsoft.com/ja-jp/azure/azure-monitor/logs/log-analytics-overview)
- バックアップ
  - [Azure Backup（VMなどをバックアップ）](https://learn.microsoft.com/ja-jp/azure/backup/backup-overview)

# AZ-104 まとめ(用語集)

## ラーニングパス1 前提条件

Azure portal(Azureの管理画面)
https://learn.microsoft.com/ja-jp/azure/azure-portal/azure-portal-overview

Azure Cloud Shell(Azure portalに組み込まれたCUI)
https://learn.microsoft.com/ja-jp/azure/cloud-shell/quickstart-powershell

ARMテンプレート(リソースをJSONで定義、一括デプロイ) 
https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview

Bicep(リソースを独自の言語で定義、一括デプロイ) 
https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/bicep/overview?tabs=bicep

Azure PowerShell(PowerShellに組み込むモジュール、Azureの操作用) 
https://learn.microsoft.com/ja-jp/powershell/azure/what-is-azure-powershell?view=azps-9.4.0

Azure CLI(Azureの操作を行うコマンド) 
https://learn.microsoft.com/ja-jp/cli/azure/what-is-azure-cli

管理グループ(複数のサブスクリプションをグループ化・階層化)
https://learn.microsoft.com/ja-jp/azure/governance/management-groups/overview

サブスクリプション(リソースの管理と課金の管理)
https://learn.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/considerations/fundamental-concepts#azure-subscription-purposes

リソースグループ(複数のリソースをまとめる)
https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/management/manage-resource-groups-portal

ロック(重要なリソースの変更・削除を防止)
https://learn.microsoft.com/ja-jp/azure/azure-resource-manager/management/lock-resources?tabs=json

Azureポリシー(リソースのルールを設定)
https://learn.microsoft.com/ja-jp/azure/governance/policy/overview

イニシアチブ(複数のポリシーをまとめて割り当て)
https://learn.microsoft.com/ja-jp/azure/governance/policy/concepts/initiative-definition-structure

Azureロール(ユーザー等に操作の許可を与える)
https://learn.microsoft.com/ja-jp/azure/role-based-access-control/overview

## ラーニングパス2 IDとガバナンス

Azure AD(ユーザー管理を一元化)
https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis

Azure AD Connect(オンプレミスAD DSからユーザー情報をAzure ADへ同期)
https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect

Azure AD MFA(他要素認証)
https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-howitworks

Azure AD 動的グループ(条件に従いユーザーのグループへの所属を自動で調整)
https://learn.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-dynamic-membership

Azure AD SSPR(セルフサービスパスワードリセット、エンドユーザーがパスワードを自分でリセットできる)
https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks

Azure のリージョン、可用性ゾーン（データセンターのあつまり）
https://learn.microsoft.com/ja-jp/azure/reliability/availability-zones-overview

Azure のリージョンペア(同じ地域内で2つのリージョンがペアとなっている)
https://learn.microsoft.com/ja-jp/azure/reliability/cross-region-replication-azure#azure-cross-region-replication-pairings-for-all-geographies

## ラーニングパス3 ストレージ

ストレージアカウント(Blob/Files/Table/Queueの4サービスを提供)
https://learn.microsoft.com/ja-jp/azure/storage/common/storage-account-overview

Blob Storage(オブジェクトストレージ)
https://learn.microsoft.com/ja-jp/azure/storage/blobs/storage-blobs-introduction

Azure Files(ネットワーク接続で利用するファイルシステム、SMB/NFSでアクセス可)
https://learn.microsoft.com/ja-jp/azure/storage/files/storage-files-introduction

Azure File Sync(Azure FilesのファイルをオンプレミスWindows Serverにキャッシュ)
https://learn.microsoft.com/ja-jp/azure/storage/file-sync/file-sync-introduction

SAS(別のクライアントへのデータアクセスの委任を行う)
https://learn.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview

SSE(サーバーサイドでデータを自動で暗号化。カスタマーマネージドキーなども使用可)
https://learn.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption


## ラーニングパス4 コンピューティング

Azure 仮想マシン(Windows/Linuxの仮想サーバー)
https://learn.microsoft.com/ja-jp/azure/virtual-machines/overview

仮想マシンスケールセット（VMのグループを作成、インスタンスを増減）
https://learn.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview

予約（VMなどの利用を予約して割引価格で利用）
https://learn.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations

スポットVM(余剰キャパシティを安く利用)
https://learn.microsoft.com/ja-jp/azure/virtual-machines/spot-vms

Azureハイブリッド特典(オンプレミスのWindows Serverライセンスを持ち込み)
https://azure.microsoft.com/ja-jp/pricing/hybrid-benefit/


Azure App Service(Webアプリを素早くホスティング)
https://learn.microsoft.com/ja-jp/azure/app-service/overview

Azure Container Instance(コンテナーを素早く実行)
https://learn.microsoft.com/ja-jp/azure/container-instances/container-instances-overview

Azure Container Registry(コンテナーイメージをビルド・格納)
https://learn.microsoft.com/ja-jp/azure/container-registry/container-registry-intro

Azure Kubernetes Service(Kubernetesクラスターを素早く作成)
https://learn.microsoft.com/ja-jp/azure/aks/intro-kubernetes

## ラーニングパス5 ネットワーク

仮想ネットワーク(Azure上に隔離されたネットワークを作成,VMを運用)
https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview

ネットワークセキュリティグループ（IPアドレス・ポート番号・プロトコルで、ネットワークアクセスを許可・拒否）
https://learn.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview

Azure Load Balancer（レイヤー4 TCP/UDPで動作するロードバランサー）
https://learn.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview

Azure Application Gateway （レイヤー7 HTTP/HTTPSで動作するロードバランサー）
https://learn.microsoft.com/ja-jp/azure/application-gateway/overview

## ラーニングパス6 監視とバックアップ

Azure Backup（VMなどをバックアップ）
https://learn.microsoft.com/ja-jp/azure/backup/backup-overview

Azure Monitor（Azureリソースの監視。ログとメトリックを収集）
https://learn.microsoft.com/ja-jp/azure/azure-monitor/overview

Log Analytics（ログを蓄積、クエリを実行）
https://learn.microsoft.com/ja-jp/azure/azure-monitor/logs/log-analytics-overview

Application Insights (さまざまな場所で実行されるアプリの監視)
https://learn.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview?tabs=net


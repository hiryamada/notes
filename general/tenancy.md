テナンシー

マルチテナント / マルチテナンシー


シングルテナント / シングルテナンシー

■Azure ADの「テナント」

https://learn.microsoft.com/ja-jp/azure/active-directory/develop/single-and-multi-tenant-apps

Azure Active Directory (Azure AD) では、ユーザーやアプリなどのオブジェクトを "テナント" と呼ばれるグループにまとめます。

アプリを開発する場合、開発者は Azure portal でアプリを登録する際に、アプリをシングルテナントまたはマルチテナントとして構成できます。

シングルテナント アプリは、それらが登録されているテナント (ホーム テナントとも呼ばれます) でのみ使用できます。

マルチテナント アプリは、ホーム テナントと他のテナントの両方のユーザーが使用できます。

■VM/VMSS: Azure専用ホスト


https://learn.microsoft.com/ja-jp/azure/virtual-machines/dedicated-hosts

Azure Dedicated Host は、1 つの Azure サブスクリプションに割り当てられた 1 つ以上の仮想マシンをホストできる物理サーバーを提供するサービスです。 専用ホストは、データ センターで使われるものと同じ物理サーバーですが、代わりに直接アクセス可能なハードウェア リソースとして提供されます。

セキュリティ: 物理サーバー レベルでのハードウェアの分離により、機密のメモリ データを物理ホスト内で分離したままにできます。 他の顧客の VM はホスト上に配置されません。 専用ホストは同じデータ センターに展開され、他の分離されていないホストと同じネットワークおよび基になるストレージ インフラストラクチャを共有します。

■App Service: App Service Environment

https://learn.microsoft.com/ja-jp/azure/app-service/environment/overview

App Service Environment は、仮想ネットワーク内で実行される Azure App Service のシングル テナント デプロイです。

App Service Environment は、App Service アプリを大規模かつ安全に実行するために完全に分離された専用の環境を提供する、Azure App Service の機能です。

App Service Environment では、単一の顧客のみのアプリケーションをホストすることができ、顧客の仮想ネットワークの 1 つでそれが行われます。 顧客は、受信と送信の両方のアプリケーション ネットワーク トラフィックをきめ細かく制御することができます。 アプリケーションは VPN を介した、オンプレミスの企業リソースへのセキュリティで保護された高速な接続を確立することができます。

内部のコンプライアンスまたはセキュリティ要件を満たすための単一のテナント システム。

■Azure Functions

https://learn.microsoft.com/ja-jp/azure/azure-functions/dedicated-plan

App Service Environment (ASE) で実行すると、関数を完全に分離し、App Service プランより多い数のインスタンスを利用できます。

関数アプリを仮想ネットワークで実行するだけであれば、Premium プランを使用。

■Azure Key Vault Managed HSM

https://learn.microsoft.com/ja-jp/azure/key-vault/managed-hsm/overview

Azure Key Vault Managed HSM (ハードウェア セキュリティ モジュール) は、フル マネージド、高可用性、シングル テナント、標準準拠を特徴とするクラウド サービスで、FIPS 140-2 レベル 3 適合の HSM を使用してクラウド アプリケーションの暗号化キーを保護することができます。

シングルテナント: 各 Managed HSM インスタンスはお客様ごとに確保され、複数の HSM パーティションのクラスターから成ります。 各 HSM クラスターでは、個々のお客様を対象としたセキュリティ ドメインが使用され、お客様ごとに HSM クラスターが暗号的に分離されます。

■Azure Logic Apps

https://learn.microsoft.com/ja-jp/azure/logic-apps/single-tenant-overview-compare

ロジック アプリ (従量課金) ホスト環境: マルチテナント

ロジック アプリ (Standard) ホスト環境: シングルテナント

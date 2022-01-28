知識チェックの解説

# App Service セクション1-モジュール1

https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-azure-app-service/8-knowledge-check

## 1. 次の App Service プランのうち、関数アプリのみをサポートしているのはどれですか?

App Service の「Webアプリ」や、Azure Functionの「関数アプリ」は、「プラン」の上で動きます。ただし、「プラン」にもいろいろな種類があり、組み合わせて使うことができるものとそうでないものがあります。

```
App Service(Webアプリ)用のプラン:
├Free, Shared: 「共有コンピューティング」とも。
├Basic, Standard, Premium: 「専用コンピューティング」とも。
└Isolated: 「分離」とも。
```
詳細: https://docs.microsoft.com/ja-jp/azure/app-service/overview-hosting-plans

```
Azure Functions(関数アプリ)用のプラン:
├従量課金プラン: 「使用量」や「消費」とも。関数が実行された分だけお支払い。
├Premium プラン: App ServiceのPremiumプランとは別もの。
└App Service プラン: 上記のApp Serviceプラン(Basic以上)の上で、関数アプリを実行
```
詳細: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale


したがって、選択肢の中で「関数アプリのみサポートしているもの」は、「従量課金プラン」となります。

## 2. 次の App Service のネットワーク機能のうち、送信 ネットワーク トラフィックを制御するために使用できるのはどれですか?

- アプリに割り当てられたIPアドレス
- ハイブリッド接続
- サービス エンドポイント

```
受信に使える機能（一部）
├アプリに割り当てられたIPアドレス: 「IPベースSSL」を有効化すると、アプリ用の新規IPアドレスが割り当てられる。
└サービスエンドポイント: Webアプリへのアクセスを、明示的な許可したVNet/サブネットからのアクセスに制限する。
```

```
送信に使える機能（一部）
└ハイブリッド接続: Webアプリから、オンプレミスのサーバー等に、VPNや専用線なしで、接続するための機能。
```

```
App Service Webアプリ
↓ハイブリッド接続
オンプレミス（のサーバ）
```

詳細: App Serviceのネットワーク機能
https://docs.microsoft.com/ja-jp/azure/app-service/networking-features

詳細: サービスエンドポイント
https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#access-restriction-rules-based-on-service-endpoints

詳細: アプリに割り当てられたIPアドレス（IPベースSSL）
- https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#app-assigned-address
- https://docs.microsoft.com/ja-jp/azure/app-service/configure-ssl-bindings#remap-records-for-ip-ssl
- https://tech-lab.sios.jp/archives/23123

詳細: ハイブリッド接続
https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#hybrid-connections

# Azure Functions セクション2-モジュール1

https://docs.microsoft.com/ja-jp/learn/modules/explore-azure-functions/5-knowledge-check

## 1. 予測的なスケーリングとコストが必要な場合、次の Azure Functions ホスティング プランのうちどれが最適ですか?


- Functions Premium プラン
- App Service プラン
- 従量課金プラン


解説: 

- スケーリングが「予測的である」とは、「スケーリングがどの程度になるかが事前にわかる」「スケーリングの規模をユーザーが指定できる」という意味。App Serviceプランであれば、インスタンスの台数を1～5の範囲といった形で指定することができるので「予測的である」。
- コストが「予測的である」とは、「（利用量がどのように変化しようとも）コストの範囲が事前にわかる）」という意味。App Serviceプランであれば、プランとスケーリング（インスタンス数）を指定することで、下限～上限のコスト範囲がその時点で明確にわかるので「予測的」である。
- 「FunctionのPremiumプラン」「従量課金プラン」は、処理量によりインスタンス数が動的に変化するため、予測が難しい。

詳細: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale

※App Serviceプランは上記のページで「専用プラン」と表示されている。

## 2. ある組織が、ビジネス上の問題を解決するためにサーバーレス ワークフローを導入しようとしています。 要件の 1 つは、デザイナー第一 (宣言型) 開発モデルを使用するソリューションにする必要があることです。 次の選択肢のうち、どれがこの要件を満たしていますか?

- Azure Functions
- Azure Logic Apps
- WebJobs

解説:

Logic Appsは、コードを書かず、GUIでロジック（ワークフロー）を開発することができるので、「コード第一」ではなく「デザイナー第一」である。

# Blob Storage - セクション3

## 1. 次の標準 HTTP ヘッダーのうち、REST を使用してプロパティを設定するときに、コンテナーと BLOB の両方でサポートされているものはどれですか。

- 更新日時 (Last-Modified)
- Content-Length
- 出発地 (Origin)

解説: 

Last-Modified は、リソースが最後に変更された日時。

https://developer.mozilla.org/ja/docs/Web/HTTP/Headers/Last-Modified

Last-Modifed は、BLOBコンテナーと、BLOBの両方でサポートされている。


## 2. 次に示す .NET 用 Azure Storage クライアント ライブラリのクラスのうち、Azure Storage コンテナーとその BLOB の両方で操作できるものはどれですか。

- BlobClient
- BlobContainerClient
- BlobUriBuilder

解説: 

```
ストレージアカウント  .... BlobServiceClient
└Blobコンテナー ......... BlobContainerClient
 └Blob  ................. BlobClient
```

BlobContainerClientは、Blobコンテナーレベルの操作と、そのコンテナー内のBlobの一覧取得といった一部のBlobレベルの操作をサポートする。

# Cosmos DB - セクション4


# Azure VM - セクション5-モジュール1

## 1. 次の Azure 仮想マシンの種類のうち、テストと開発に最適なものはどれですか?

- コンピューティング最適化
- General Purpose
- ストレージ最適化

解説: 開発・テストには、CPUコアとメモリがバランス良く配置された「General Purpose」（汎用）が適している。具体的にはDシリーズ等。

## 2. 冗長性と可用性を実現するためのアプリケーションの構築方法を Azure で理解できるようにする VM の論理的なグループ化を表しているのは次のうちのどれですか?

- Load Balancer
- 可用性ゾーン
- 可用性セット

解説: VMをグループ化する仕組みは「可用性セット」。「可用性セット」のリソースを作り、VMを作成する際に「可用性セット」を指定することで、そのグループに含めることができる。VMは復数のFD・UDに分散し、可用性が向上する。(99.9% → 99.95%)

# Microsoft ID Platform セクション6-モジュール1

## 1. サインインしているユーザーが存在するアプリで、Microsoft ID プラットフォームによってサポートされるアクセス許可の中でどの種類が使用されますか?

- デリゲート(委任)されたアクセス許可
- アプリケーションのアクセス許可
- 委任されたアクセス許可とアプリケーションのアクセス許可の両方

解説:

「デリゲート(委任)されたアクセス許可」が正しい。

- 「委任されたアクセス許可」
  - ユーザーがサインインして利用するタイプのアプリで使用する許可
  - 各ユーザーまたは管理者が同意する。
- 「アプリケーションのアクセス許可」
  - ユーザーがサインインせず利用するタイプのアプリ（サービス、デーモン等）で使用する許可。
  - 管理者が同意する。

## 2. 条件付きアクセス チャレンジを処理するコードが必要なアプリ シナリオは次の中のうちどれですか?

- デバイスコード フローを実行するアプリ
- On-Behalf-Of フローを実行するアプリ
- 統合 Windows 認証フローを実行するアプリ

解説:

「条件付きアクセス」は、Azure ADの機能の一種。たとえば、特定のアプリケーションへのアクセス時に、多要素認証（MFA）を要求する、といった条件を追加できる。

OAuth 2.0 の On-Behalf-Of (OBO) フローは、アプリケーションがサービス/Web API を呼び出し、それがさらに別のサービス/Web API を呼び出す必要のあるユース ケース。

On-Behalf-Of フローを実行するアプリでは、条件付きアクセスを処理するために、コード（の変更）が必要となる。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-conditional-access-dev-guide#scenario-app-performing-the-on-behalf-of-flow


# Azure Key Vault セクション7-モジュール1

## 1. ほとんどのシナリオで推奨される Azure Key Vault への認証方法は次のうちどれですか?

- サービス プリンシパルと証明書
- サービス プリンシパルとシークレット
- マネージド ID

正解: マネージドID。

解説: マネージドIDは、サービスプリンシパルの一種であるが、パスワードを利用者が扱う必要がないのでより安全である。サービス プリンシパルは、利用者が、明示的にIDとパスワード（またはIDと証明書）を発行し、安全に保管する必要があり、また定期的にローテーションする必要があるので、運用により手間がかかる。VM、App Service, Functions, ACI, AKSなど、多くのAzureのコンピューティングサービスで、マネージドIDを使用することができる。

## 2. Azure Key Vault は、Azure Key Vault とクライアント間を移動するときにデータを保護します。 暗号化にはどのようなプロトコルが使用されますか?

- セキュア ソケット レイヤー (Secure Sockets Layer, SSL)
- トランスポート層セキュリティ (Transport Layer Security, TLS)
- プレゼンテーション層

解説: [Key Vault自身は、転送中のデータの暗号化にTLSを使用している](https://docs.microsoft.com/ja-jp/azure/key-vault/general/basic-concepts#encryption-of-data-in-transit)。一般的に、ネットワークで情報を送受信する際に、SSLまたはTLSを使用して暗号化を行う場合がある。[TLSはSSLの後継のプロトコルである](https://www.infraexpert.com/study/security7.html)。

なお、Key Vault内に記録される「[証明書](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/about-certificates)」としては、TLS/SSLの証明書を扱うことができる。

# Azure Event Grid セクション9-モジュール1

## 1. 値が必要なイベント スキーマ プロパティは、次のうちどれですか?

- トピック
- データ
- サブジェクト

解説: イベントはJSONで送信される。JSONのフォーマット（形式）は「スキーマ」と呼ばれる。スキーマの形式の1つとして「[Azure Event Grid イベント スキーマ](https://docs.microsoft.com/ja-jp/azure/event-grid/event-schema)」がある。このスキーマの「subject」（イベントの対象のパス）は、必須のプロパティとなっており、イベントの発行元側で、必ず値を指定しなればならない。たとえば、Blobがアップロードされたというイベントの場合、その「subject」の値として、Blobのパスが指定される。

## 2. Event Grid リソースの管理に適している Event Grid 組み込みロールは、次のうちどれですか?

- Event Grid の共同作成者
- Event Grid サブスクリプションの共同作成者
- Event Grid データ送信者

解説: 

Event Grid リソース（＝トピック）を管理するユーザーには、「Event Gridの共同作成者」ロールを割り当てる。

```
イベント
↓ イベントの送信 ← Event Grid データ送信者
Event Grid トピック の管理 ← Event Gridの共同作成者
└サブスクリプション の管理 ← サブスクリプション共同作成者
```



# Azure SQL

https://docs.microsoft.com/ja-jp/azure/azure-sql/azure-sql-iaas-vs-paas-what-is-overview

[Microsoft SQL Server（以下SQL Server）](https://docs.microsoft.com/ja-jp/sql/)は、Microsoftが開発するリレーショナル データベース製品。

SQL Serverは、オンプレミスでも、Azure上でも実行できる。

Azure上でSQL Serverを実行するためのサービスは、「Azure SQL」と呼ばれる。

■Azure SQLに含まれるサービス(★)

(★): 重要

- [Azure SQL Database](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/sql-database-paas-overview)
  - PaaS 型のサービス
  - ほとんどのオンプレミス データベース レベルの機能をサポート
  - 組み込みの高可用性、インテリジェンス、管理などの追加の機能も利用できる
- [Azure SQL Managed Instance (MI)](https://docs.microsoft.com/ja-jp/azure/azure-sql/managed-instance/sql-managed-instance-paas-overview)
  - PaaS 型のサービス
  - オンプレミスの SQL Serverとの100%に近い互換性を持つ
  - 既存のオンプレミス アプリケーションの移行に適する
- [Azure SQL Server on VM](https://docs.microsoft.com/ja-jp/azure/azure-sql/virtual-machines/)
  - IaaS 型のサービス。
  - データベース エンジンと OS に対する完全な管理制御を必要とするアプリケーションに最適

いずれも、データベースエンジンとしてSQL Serverを使用。

■可用性（SLA）

https://azure.microsoft.com/ja-jp/support/legal/sla/azure-sql-database/v1_6/

デプロイ方法によるが、99.9% ～ 99.995% の可用性を SLA で保証。

■Azure SQL Database

Azure SQL Databaseは、フルマネージドのデータベース。

アップグレード、修正プログラムの適用、バックアップ、監視などのほとんどのデータベース管理機能をユーザーの介入なしで処理。 

他の2つのサービス（Azure SQL Managed Instance と SQL Server on VM）に比べて、データベース管理の手間を省くことができる。

よく使われるSQL Server機能をサポートしているが、従来のSQL Serverとの完全な互換性は利用できない。

オンプレミスからの移行など、従来のSQL Serverとの互換性が重要である場合は、Azure SQL Managed Instanceか、SQL Server on VMを使用する。

■Azure SQL Databaseの主な特徴

- OSとデータベースエンジンの自動アップグレード
  - アップグレードは継続的に自動で実行
- スケーラビリティ
  - データベースなどに対する性能の指定をいつでも変更することができる。
  - アプリケーションのダウンタイムは、最小限 (通常、平均で 4 秒未満)。
    - アプリケーションは、[再試行ロジック](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/troubleshoot-common-connectivity-issues)を使うことで、接続を回復させることができる
- [自動バックアップ](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/automated-backups-overview?tabs=single-database)
  - 完全バックアップを毎週、差分バックアップを 12 から 24 時間ごと、そしてトランザクション ログ バックアップを 5 から 10 分ごとに作成
- ポイントインタイムリストア(PITR)
  - データベースを、過去のある時点における別のデータベースのコピーとして作成することができる。
- 長期リテンション（長期保有）(★)
  - LTR(Long Term Retension)バックアップとも。
  - 完全バックアップを最大で10年間、Azure Blob Storageに格納することができる。
- 可用性ゾーンの利用
  - 単一のゾーン構成を取ることも、ゾーン冗長の構成を取ることもできる。
  - ゾーン冗長構成を取ることで、データセンターの壊滅的な障害を含む、大規模な障害から、データベースを回復できるようになる。

■Azure SQL Databaseのリソース

Azure SQL Databaseの主なリソースとして「SQLサーバー」「SQLデータベース」「SQLエラスティックプール」がある。

■SQL サーバー

「SQLサーバー」（以下、「サーバー」）は「SQLデータベース」（後述）や「SQLエラスティックプール」（後述）を管理するための論理的なコンテナー。

サーバーは、リソース グループ以下に作成する。サーバーの作成時に、サーバーの名前を指定する。名前によって、サーバーに接続するための「エンドポイント」も決まる。

たとえば「server1」という名前でサーバーを作成すると、そのサーバーに「server1.database.windows.net」というエンドポイントが与えられる。

サーバーの「サーバー管理者」の「ログイン」と「パスワード」も指定する。

管理者は、この「ログイン」と「パスワード」を使用して、サーバーに接続し、管理操作（他のユーザーの作成など）を実行する。

■SQLデータベース

サーバー内には、SQLデータベース（以下、「データベース」）を作成することができる。

データベースの作成時に、名前や性能（後述）などを指定。

データベース内には、アプリケーションが使用するテーブルやビューなどを作成することができる。

■SQLエラスティックプール(★)

適用対象: Azure SQL Database のみ

[解説PDF](../AZ-500/pdf/mod3/Elastic%20Pool.pdf)

サーバー内には、「SQLエラスティックプール」（以下、プール）を作成することもできる。

プールの作成時に、プールの名前や性能（後述）などを指定。

新しいデータベースは、プールの中に作成することも、プールの外（サーバー内）に作成することもできる。

また、プールの外に作成されている既存のデータベースを、プールに移動したり、プールの中にあるデータベースを、プールの外に移動したりすることができる。

プール内の複数のデータベースは、プールに指定された性能を共有する。

■性能の指定方法

データベースまたはプールの性能は、従来の「DTUベースの購入モデル」と、より新しい「仮想コアベースの購入モデル」のいずれかで指定することができる。

|購入モデル|概要|
|-|-|
|DTUベース|必要な性能を「データベース トランザクション ユニット (DTU)」で指定。DTUは、CPU、メモリ、IO（入出力）を組み合わせた、性能の目安の値。データベースの負荷が高い場合、データベースによりたくさんのDTUを割り当てる。|
|仮想コアベース|ハードウェアの世代、仮想コア（論理CPU）数、メモリ量、ストレージサイズなどを事前に指定する「プロビジョニング済み」、または、使用されているコンピューティングリソースを毎秒測定して課金を計算する「サーバーレス」を選ぶ。|

「プロビジョニング済み」は、データベースまたはプールに対する性能の指定時に選択することができ、1時間単位で課金が計算される。

「サーバーレス」は、データベースにおける性能の指定時にのみ選択することができ、1秒単位で課金が計算される。

■ハンズオン: SQL Database

まず、Windows Server の VMを作成します。このVMは、Azure Data Studioを実行するために使用します。

Cloud Shell (bash) を起動し、以下を入力します。

```
git clone https://github.com/hiryamada/labvm2
cd labvm2
sh deploy.sh
```
すると、以下のようなプロンプトが表示されます。
```
Please provide securestring value for 'adminPassword' (? for help):
```
ここで、VMのパスワード(12文字以上、大文字・小文字・数字・記号の組み合わせ)を決めて、それを入力し、エンターキーを押します。

VMの作成が始まります。Cloud Shellはそのままにしておいて、VMを作成しつつ、続いてSQLサーバーとSQLデータベースを作成します。

Azure portalで、以下の手順を実行します。

```
画面上部の検索で「SQL」を入力→「SQL データベース」
＋作成
リソースグループ: 新規作成、「rg1」
データベース名「db1」
サーバー: 「新規作成」をクリック

サーバー名: 「dbsv(乱数)」
場所「(US) East US」
サーバー管理者ログイン: 「azureuser」
パスワード/パスワードの確認: (適当なパスワードを入力、記録しておく)
OK

コンピューティングとストレージ: 「データベースの構成」をクリック
コンピューティングレベル: サーバーレス
最大仮想コア数: 1
データの最大サイズ: 1GB
適用

バックアップ ストレージの冗長性: ローカル冗長バックアップ ストレージ

次: ネットワーク
次: セキュリティ
次: 追加設定
次: タグ
次: 確認および作成
作成
```

作成が完了すると以下のような構成となります。

```
リソースグループ rg1
└SQLサーバー dbsvNNNNNN
  └SQLデータベース db1
```

画面上部の検索で「SQL」を入力→「SQL データベース」として、作成したSQLデータベース「db1」を表示し、画面左の「接続文字列」をクリックします。表示された接続文字列をコピーしておきます。

画面上部の検索で「vm」を入力→「Virtual Machines」として、先ほど起動しておいたVM「labvm」を表示します。

「labvm」のパブリックIPアドレスをコピーします。

画面上部の検索で「SQL」を入力→「SQL データベース」として、作成したSQLデータベース「db1」を表示し、「概要」画面の「サーバー名」のリンクをクリックします。

サーバーの概要画面が表示されます。「ファイアウォール設定の表示」をクリックします。

「規則名」「開始IP」「終了IP」に以下を入力します。

- 規則名: labvm
- 開始IP / 終了IP: コピーしたIPアドレス

「保存」をクリックします。

画面上部の検索で「vm」を入力→「Virtual Machines」として、先ほど起動しておいたVM「labvm」を表示します。「labvm」にリモートデスクトップで接続します。

```
ユーザー名: azureuser
パスワード: （自分で決めたパスワード）
```

以降、リモートデスクトップ内で作業します。

Webブラウザーを起動し、以下のページを開きます。

https://docs.microsoft.com/ja-jp/sql/azure-data-studio/download-azure-data-studio

ページ内の、Azure Data Studioの「Windows」の「ユーザーインストーラー」をクリックし、インストーラーをダウンロードし、実行します。

Setupダイアログで「This User Installer is not meant to be run as Administrator...」というメッセージが出た場合「OK」をクリックして先に進みます。

「I Accept...」にチェックし、「Next」「Next」「Next」「Next」「Install」とクリックします。インストールが完了したら「Finish」をクリックします。

Azure Data Studioが起動します。

New Connectionをクリックします。

- ここで、クリップボードに接続文字列が入っていなかった場合は、「Server」の部分が空欄となります。そこに、さきほどコピーしておいた接続文字列を貼り付けます。
- クリップボードに接続文字列が入っていた場合は、「Server」などが入力された状態となります。

Passwordは、いったん削除して打ち直す必要があります。SQLデータベース「db1」の作成時に決めたパスワードをここで入力します。

Connectをクリックします。データベースに接続されます。

画面上部「New Query」をクリックします。

以下を入力します。

```
CREATE TABLE items (
	id INT PRIMARY KEY,
	name VARCHAR(100),
	price INT
);

INSERT INTO items (id, name, price) VALUES (1, 'apple', 100);
INSERT INTO items (id, name, price) VALUES (2, 'banana', 200);
INSERT INTO items (id, name, price) VALUES (3, 'cherry', 300);

SELECT * FROM items ORDER BY id ASC;
```
画面上部の「Run」ボタンをクリックします。テーブルの作成、データのINSERTED、SELECTが実行され、検索結果が表示されます。

VM上から、SQL Databaseに接続し、SQL文を実行することができました。

ハンズオンは以上です。リモートデスクトップを切断し、Azure portalで、リソースグループ rg1 と labvmrg を削除してください。


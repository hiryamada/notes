
SQL Database

SQLサーバー内に複数のSQL Databaseができる

RBACは、サーバーの設定ができるかどうかを決める。

SQL DatabaseにアクセスするにはRBACとは別の権限が必要

(1)SQL Server内に「ログイン」オブジェクトを作る。SQL Server認証を使用することも、AADのユーザーを使用することもできる。

接続はSSMSやAzure Data Studio

https://docs.microsoft.com/ja-jp/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15

https://docs.microsoft.com/ja-jp/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15

(2)各SQL Database内にユーザーを作ることができる。この場合はそのSQL Databaseにしかログインできない。このユーザーもSQL Server認証を使用することも、AADのユーザーを使用することもできる。


# ファイアウォール

SQL DBのファイアウォールが2つ存在する。

SQLサーバーのファイアウォールと、SQL Databaseのファイアウォール。

Portalで設定できるのはSQLサーバーのファイアウォールである。

SQL Databaseのファイアウォールは、Portalから操作はできない。SQL文を書いてFWをコントロールする。

DBレベル、または、サーバーレベルのファイアウォールのどちらかで許可されていればアクセスできる。両方ではないことに注意。

# DBアクセス監査ログを吐き出すことができる

# データ検出と分類

スキャンして、機密性の高い列を特定

分類ラベル付け

# 脆弱性評価（有償）

Security Center内のスタンダード版として提供されていたもの。現在はAzure Defenderという名前になっている。そのSQL Database版。

脆弱性スキャンを実行

設定などをチェックして脆弱性につながるようなものを検出できる。

設計漏れ・設定漏れを防ぐことができる

定期的にスキャンを実行することが望ましい。新しい脆弱性を発見する場合もある

# ATP(Advanced Threat Protection)

監査ログに対してMSがチェックを行い、SQLインジェクション、ブルートフォース、異常なログインなどを検出できる。

https://docs.microsoft.com/ja-jp/azure/azure-sql/database/threat-detection-overview

https://azure.microsoft.com/ja-jp/blog/announcing-sql-atp-and-sql-vulnerability-assessment-general-availability/

http://news.line.me/articles/oa-ascii/f390dbf42268

Azure SQL Databaseのサーバーあたり1680円/月です。最初の60日間は無料で試用可能


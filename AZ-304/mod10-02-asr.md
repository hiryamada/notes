# Azure Site Recovery

Microsoft Learn: Azure Site Recovery を使用して Azure インフラストラクチャを保護する
https://docs.microsoft.com/ja-jp/learn/modules/protect-infrastructure-with-site-recovery/

■Azure Site Recoveryとは

https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-overview

Site Recovery は、物理マシンと仮想マシン (VM) で実行中の**ワークロード**を、**プライマリ サイト**から**セカンダリ ロケーション**にレプリケートする。


※**プライマリ サイト**: オンプレミス または Azureリージョン

※**セカンダリ ロケーション**: Azureリージョン

```
プライマリ サイト ← ユーザー
  ↓ レプリケート（継続的）
セカンダリ ロケーション   
```

**プライマリ サイト**で障害が発生した場合は、**セカンダリ ロケーション**に**フェールオーバー**し、そこからアプリにアクセスできる。

```
プライマリ サイト（障害発生）
  ↓ フェールオーバー
セカンダリ ロケーション ← ユーザー
```

**プライマリ サイト**が再度実行中になったら、そこに**フェールバック**できる。

```
プライマリ サイト ← ユーザー
  ↑ フェールバック
セカンダリ ロケーション
```

■ワークロード

https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#workload-summary

[Active Directory](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#replicate-active-directory-and-dns)、[IIS](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#protect-internet-information-services)、[SharePoint](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#protect-sharepoint)、[SAP](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#protect-sap)、[Exchange](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#protect-exchange)、[SQL Server](https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-workload#protect-sql-server)などの「ワークロード」をサポート。

■サポートされるシナリオ

https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-overview#what-does-site-recovery-provide

Azureへのレプリケーション:

- [Azureリージョン間でAzure VMをレプリケート](https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-enable-replication)
  - ※特に「地域」内の「ペアのリージョン」である必要はない。東日本リージョン→東日本リージョンといったレプリケーションも可能
- [オンプレミスの VMware VM、Hyper-V VM、Windows/Linux 物理サーバーを Azure にレプリケート](https://docs.microsoft.com/ja-jp/azure/site-recovery/tutorial-prepare-azure)

Azure Site Recoveryによる、オンプレミスへのレプリケーションは、サポート終了。

- [オンプレミスの VM や物理サーバーを、オンプレミスのセカンダリ データセンターにレプリケート（サポート終了）](https://docs.microsoft.com/ja-jp/azure/site-recovery/vmware-physical-secondary-disaster-recovery#end-of-support-announcement)
- [オンプレミスの VMware データセンターまたは物理データセンター間のレプリケーション（サポート終了）](https://docs.microsoft.com/ja-jp/azure/site-recovery/vmware-physical-secondary-disaster-recovery#end-of-support-announcement)


**※本資料では、以降、Azureリージョン間のレプリケーションについて説明する。第1のリージョンを「プライマリリージョン」、第2のリージョンを「セカンダリリージョン」と呼ぶ。**

```
プライマリリージョン: 平常時、ワークロードの稼働に利用

セカンダリリージョン: プライマリの災害時に使用
```


**レプリケーションの元となる方を「ソース」、レプリケーションの先となる方を「ターゲット」と呼ぶ。**

フェールオーバー前:

```
プライマリリージョン: ソース
 ↓フェールオーバーのためのレプリケーション
セカンダリリージョン: ターゲット
```

フェールバック前:

```
プライマリリージョン: ターゲット
 ↑フェールバックのためのレプリケーション
セカンダリリージョン: ソース
```

※たとえば「ソースVM」「ソースリージョン」「ターゲットリソース」「ターゲット環境」といった言葉が使われる。

■Recovery Services コンテナー

https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-recovery-services-vault-overview

Recovery Services コンテナーは、データを格納する Azure のストレージ エンティティ。Azure Site Recoveryや、Azure Backupで使用される。

■レプリケーションのしくみ

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-architecture#replication-process

平常時、プライマリリージョンからセカンダリリージョンへ、VM（のディスク）をレプリケーション（継続的に複製）しておく。

VMのレプリケーションを有効化すると、次のことが起こる。

- VM に**Site Recovery モビリティ サービス拡張機能**がインストールされる。
  - 拡張機能は、VM を Site Recovery に登録する。
- 継続的なレプリケーションが開始される。
  - ディスクへの書き込みが、ソースリージョンの**キャッシュ ストレージ アカウント**に送信される。
  - キャッシュ内のデータは、ターゲットリージョンの **レプリカ マネージド ディスク**に送信される。

```
プライマリリージョン
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
|              ↓
└キャッシュストレージアカウント
               ↓
セカンダリリージョン
└レプリカマネージドディスク（～-ASRReplica）
```

■レプリカマネージドディスク

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-how-to-reprotect#what-happens-during-reprotection

元ディスクのコピーが -ASRReplica サフィックスを使用して作成される。-ASRReplica のコピーはレプリケーションに使用される。


■復旧ポイント（Azure portalでは「回復ポイント」）

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-architecture#snapshots-and-recovery-points

レプリケーション中は、Recovery Servicesコンテナー内に「復旧ポイント」が作られていく。

復旧ポイントは、特定の時点で取得された VM のディスクのスナップショットから作成される。

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-architecture#replication-process

- **クラッシュ整合性復旧ポイント**が 5 分ごとに生成される。
- **アプリ整合性復旧ポイント**が、**レプリケーション ポリシー**で指定された設定に従って生成される。

例: win1 というVMのレプリケーションを有効化した場合

```
Recovery Servicesコンテナー
└レプリケートされたアイテム
 └win1
  ├復旧ポイント 11:55 - クラッシュ整合性
  ├復旧ポイント 11:50 - クラッシュ整合性
  ├復旧ポイント 11:45 - アプリ整合性
  └復旧ポイント 11:40 - クラッシュ整合性
```

■レプリケーションポリシー

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-architecture#replication-policy

レプリケーションを有効化する際に、新しい「レプリケーション ポリシー」が作成される。

デフォルトの設定:
- 復旧ポイントの保持期間（Site Recovery で復旧ポイントを保持する長さ）: 24 時間
- アプリ整合性スナップショットの頻度: 4 時間

■クラッシュ整合性

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-architecture#crash-consistent

クラッシュ整合性スナップショットでは、スナップショットが作成されたときにディスクに存在していたデータがキャプチャされる。

（スナップショットが作成された瞬間に VM がクラッシュしたり、電源コードがサーバーから抜かれたりした場合にディスク上に存在していたデータと同じもの）

■アプリ整合性

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-architecture#app-consistent

アプリ整合性スナップショットには、クラッシュ整合スナップショット内のすべての情報に加えて、メモリ内のすべてのデータと進行中のトランザクションが含まれる。

■テストフェールオーバー

※「ディザスター リカバリー訓練（disaster recovery drill）」とも呼ばれる。

テストフェールオーバーを実行することで、レプリケーションを検証することができる。

テストフェールオーバーは、実行中のレプリケーションや運用環境に影響を与えない。

いずれかの「回復（復旧）ポイント」を選択して、テストフェールオーバーを開始する。

ターゲットリージョンにテスト用のVMとディスクが作成される。

テストフェールオーバー実行前:

```
プライマリリージョン
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
|              ↓
└キャッシュストレージアカウント
               ↓
セカンダリリージョン
├Recovery Servicesコンテナー
└レプリカマネージドディスク（～-ASRReplica）
```

テストフェールオーバー実行後:

```
プライマリリージョン
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
|              ↓
└キャッシュストレージアカウント
               ↓
セカンダリリージョン
├Recovery Servicesコンテナー
├テストVM
|  └マネージドディスク（～-ASRtest）
└レプリカマネージドディスク（～-ASRReplica）
```

「テストフェールオーバーのクリーンアップ」を実行すると、テストフェールオーバーで作成されたリソース（テストVM、ディスク、NIC）が削除され、テストフェールオーバー実行前の状態に戻る。

■参考: テストフェールオーバーは必須ではない

テストフェールオーバーを行わず、いきなりフェールオーバーを実行することもできる。

Azure portalにはこのようなメッセージが表示される。
「過去 180 日間にわたりテスト フェールオーバーが実行されていません。フェールオーバーの前にテスト フェールオーバーの実行をお勧めします。」

「リスクを理解したうえでフェールオーバーを続行します」にチェックを入れると、フェールオーバーを行うことができる。

■フェールオーバー

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-failover-failback

プライマリリージョンに災害・障害が発生したら、フェールオーバーを実行する。

いずれかの「回復（復旧）ポイント」を選択して、フェールオーバーを開始する。

フェールオーバー実行前:

```
プライマリリージョン（災害発生中）
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
|              
└キャッシュストレージアカウント
               
セカンダリリージョン
├Recovery Servicesコンテナー
└レプリカマネージドディスク（～-ASRReplica）
```

フェールオーバー実行後:

```
プライマリリージョン（災害発生中）
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
|              
└キャッシュストレージアカウント
              
セカンダリリージョン
├Recovery Servicesコンテナー
├VM
| └マネージドディスク
└レプリカマネージドディスク（～-ASRReplica）
```

フェールオーバーが完了すると、
- 状態は「フェールオーバーが完了しました」となる。
- ターゲットリージョンに作成されたVMの名前は、ソースVMの名前と同じになる。VMやディスクには「～test」という接尾辞は**付与されない**。
- 「コミット」「復旧ポイントの変更」が選択できるようになる。

■復旧ポイントの変更

異なる復旧ポイントを使用したい場合は、「復旧ポイントの変更」を選択する。

通知には「フェールオーバーのために選択された復旧ポイントを適用しています」と表示される。

状態は「フェールオーバーの取り消し中」となる。

フェールオーバーで作成されたリソースがいったん削除され、指定した復旧ポイントで再度フェールオーバーが実行される。

変更が完了すると状態は「フェールオーバーが完了しました」となる。

■コミット

フェールオーバーされたVMに問題がなければ、「コミット」を選択する。

「コミット」を行うと、そのVMに関して利用可能な復旧ポイントがすべて削除される（「復旧ポイントの変更」はできなくなる）。

レプリカマネージドディスク（～-ASRReplica）も削除される。

状態は「コミットが進行中」となる。1分ほどすると「フェールオーバーがコミットされました」となる。

コミット完了後:

```
プライマリリージョン（災害発生中）
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
└キャッシュストレージアカウント

セカンダリリージョン
├Recovery Servicesコンテナー
└VM
  └マネージドディスク
```

■再保護（reprotect）

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-failover-failback#reprotect-the-vm

プライマリリージョンが災害から復旧したら、プライマリリージョンへのフェールバックを行う。その前に「再保護」（セカンダリからプライマリへのレプリケーション）を行う。

ソース（セカンダリリージョン）にキャッシュストレージアカウントが作成される。ターゲット（プライマリリージョン）に、レプリカマネージドディスクが作成される。

「再保護」にはかなり時間がかかる。「Site Recovery ジョブ」から、状況を確認することができる。

「再保護」により、「状態」は「～%同期済み」から「プロテクト」となる。


「再保護」実行後: 

```
プライマリリージョン（災害から復旧）
├VM ＋ Site Recovery モビリティ サービス拡張機能
| └マネージドディスク
|
├キャッシュストレージアカウント
└レプリカマネージドディスク（～-ASRReplica）
                    ↑
セカンダリリージョン
├キャッシュストレージアカウント
├Recovery Servicesコンテナー
└ VM ＋ Site Recovery モビリティ サービス拡張機能
   └マネージドディスク
```

■テストフェールオーバー

セカンダリからプライマリへのフェールオーバーが実施できることを確認する。

■フェールオーバー（フェールバック）

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-failback

セカンダリからプライマリへのフェールオーバーを実施する。


■参考: 「復旧ポイント」と「スナップショット」の関係

https://docs.microsoft.com/ja-jp/azure/backup/backup-instant-restore-capability#whats-new-in-this-feature

（Microsoftが管理する）ストレージアカウント
├マネージドディスク
└スナップショット(s1)

Recovery Servicesコンテナー
├復旧ポイント(r1)
└復旧ポイント(r2)
 └スナップショット(s2)

(s1)は、ディスクと共に格納されるスナップショット。既定で 2 日、1～5日の間で設定可能
(r1)は、種類が「スナップショット」の復旧ポイント。s1を参照する。

(s2)は、Recovery Servicesコンテナーにコピーされたスナップショット。
(r2)は、種類が「スナップショットとコンテナー」の復旧ポイント。s2を参照する。

■参考: 「キャッシュ ストレージ アカウント」と「復旧ポイント」の関係

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-enable-replication
レプリケーション中、VM ディスクへの書き込みは、ソース リージョンのキャッシュ ストレージ アカウントに送信される。

データは、そこからターゲット リージョンに送信され、そのデータから復旧ポイントが生成される。

```
ソースリージョン
└キャッシュストレージアカウント
 └VMディスクへの書き込み（ページBlob）
            ↓送信
ターゲットリージョン
└Recovery Servicesコンテナー
  └復旧ポイント
    └スナップショット
```


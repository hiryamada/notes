# ストレージアカウントのフェールオーバー

■公式ドキュメント

ストレージ アカウントのフェールオーバーを開始する
https://docs.microsoft.com/ja-jp/azure/storage/common/storage-initiate-account-failover?tabs=azure-portal

ディザスター リカバリーとストレージ アカウントのフェールオーバー
https://docs.microsoft.com/ja-jp/azure/storage/common/storage-disaster-recovery-guidance

■推奨関連コンテンツ

Microsoft Learn: リージョン間でストレージ データをレプリケートし、セカンダリ ロケーションにフェールオーバーすることで、ディザスター リカバリーを実現する（フェールオーバーの基礎知識や具体的な手順を学習できます）
https://docs.microsoft.com/ja-jp/learn/modules/provide-disaster-recovery-replicate-storage-data/

■歴史

2019/2/5 ストレージ アカウント フェールオーバーのパブリック プレビュー。ユーザーが、フェールオーバーのタイミングを制御できるようになった。
https://azure.microsoft.com/ja-jp/updates/azure-storage-account-failover-is-now-in-public-preview/

2020/6/17 ストレージ アカウント フェールオーバーの一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-storage-account-failover-ga/

■フェールオーバーとは？

- 何らかの理由でストレージ アカウントのプライマリ エンドポイントが利用できなくなった場合、アカウントのフェールオーバーを開始できる。
- フェールオーバーでは、セカンダリ エンドポイントが更新されて、ストレージ アカウントのプライマリ エンドポイントになる。
- フェールオーバーが完了すると、クライアントは新しいプライマリ リージョンへの書き込みを開始できる。

■フェールオーバーはどのような場合に必要となるか？

- 何らかの理由でプライマリ リージョンが長期間にわたって利用できなくなった場合
- 大きな災害のためにリージョンが失われるような状況

■フェールオーバーの例

★(1)最初の状態

GRS（geo 冗長ストレージ）のストレージアカウントを東日本リージョンで作成

```
ストレージアカウント (GRS)
├プライマリリージョン（プライマリエンドポイント）: 東日本
└セカンダリリージョン（セカンダリエンドポイント）: 西日本

アプリ:
- プライマリエンドポイントで読み書きを実行できる
- セカンダリエンドポイントで読み込みを実行できる
```

★(2)フェールオーバーを実行（約1時間かかる）

```
ストレージアカウント (LRS)
├＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
└プライマリリージョン（プライマリエンドポイント）: 西日本

アプリ:
- プライマリエンドポイントで読み書きを実行できる
```

ストレージアカウントを利用するアプリケーションやシステムが使用しているプライマリのエンドポイントを書き換える必要はない。

■フェールオーバーを実行するとどうなるのか？

- セカンダリエンドポイントが新たなプライマリエンドポイントとなる
- ストレージアカウントのレプリケーション種別はLRSとなる（※）
- 元のリージョンのデータはすべて失われる

（※）[このアカウントのZRS または GZRS への「ライブ マイグレーション（Azureサポートに依頼して、ダウンタイムなしの移行作業を行ってもらうこと）は不可能。](https://docs.microsoft.com/ja-jp/azure/storage/common/redundancy-migration?tabs=portal#switch-between-types-of-replication)「手動移行」（新しい別のストレージアカウントを作り、ツールを使ってデータをコピーする）が必要。

■フェールオーバーはどのように開始されるか？

- マイクロソフトが開始するフェイルオーバー
  - 大きな災害のためにリージョンが失われるような極端な状況で、Microsoft がリージョン間のフェールオーバーを開始する可能性がある
  - [これまで一度も行われていない](https://ascii.jp/elem/000/001/814/1814446/) (2019/2/18時点)
- ユーザーが開始するフェイルオーバー
  - [「強制フェールオーバー」（Forced failover）とも](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-initiate-account-failover?tabs=azure-portal)
  - [2020/6 一般提供開始](https://azure.microsoft.com/ja-jp/updates/azure-storage-account-failover-ga/)
  - ユーザーが、フェールオーバーのタイミングを制御できる。


■フェールオーバーはどのストレージアカウントで実行できるのか？

- GRS（geo 冗長ストレージ）
- GZRS（geo ゾーン冗長ストレージ）
- RA-GRS（読み取りアクセス geo 冗長ストレージ）
- RA-GZRS（読み取りアクセス geo ゾーン冗長ストレージ）

注意: [フェールオーバーでサポートされていない機能とサービスがある。](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-initiate-account-failover?tabs=azure-portal#prerequisites) Azure File Sync、階層型名前空間が有効になっているストレージ アカウント (Data Lake Storage Gen2 など) 、Premium ブロック BLOB 含むストレージ アカウントなど。

■フェールオーバーはどうやって開始するのか？

ユーザーが開始するフェイルオーバーは、Azure portal、Azure PowerShell、Azure CLI、Azure Storage リソース プロバイダー API から開始できる。

■フェールオーバーが完了するまでどのくらいの時間がかかるのか？

[通常、約 1 時間かかる](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-disaster-recovery-guidance#understand-the-account-failover-process)

■フェールオーバーによるデータの損失はあるのか？

フェールオーバーが発生した時点において、
- セカンダリに既にコピーされているデータはすべて維持される。
- セカンダリにコピーされていなかったものは、失われる。

■損失したデータを特定する方法はあるか？

- [ストレージアカウントの「最終同期時刻」を確認する。](https://docs.microsoft.com/ja-jp/azure/storage/common/last-sync-time-get?tabs=azure-powershell)
- （ユーザー側で）すべての書き込み操作をログに記録する。
- ログの時刻と、最終同期時刻と比較することで、セカンダリに同期されていない書き込みを特定できる。

■フェールバックは可能か？

可能。ただし「フェールバック」という機能は特にないため、フェイルオーバーとレプリケーション種別の変更により実施する。

★(1)最初の状態

```
ストレージアカウント (GRS)
├プライマリリージョン（プライマリエンドポイント）: 東日本
└セカンダリリージョン（セカンダリエンドポイント）: 西日本
```

★(2)フェールオーバーを実行（約1時間かかる）

```
ストレージアカウント (LRS)
├＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
└プライマリリージョン（プライマリエンドポイント）: 西日本
```

★(3)ストレージアカウントのレプリケーション種別をGRSに設定

```
ストレージアカウント (GRS)
├セカンダリリージョン（セカンダリエンドポイント）：東日本
└プライマリリージョン（プライマリエンドポイント）: 西日本
```

★(4)フェールオーバーを実行（約1時間かかる）

```
ストレージアカウント (LRS)
├プライマリリージョン（プライマリエンドポイント）：東日本
└＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
```

★(5)ストレージアカウントのレプリケーション種別をGRSに設定

```
ストレージアカウント (GRS)
├プライマリリージョン（プライマリエンドポイント）: 東日本
└セカンダリリージョン（セカンダリエンドポイント）: 西日本
```

以上で、元の状態に戻る。

■フェールバックは自動的に行われるのか？

いいえ。


■参考資料

https://jpaztech1.z11.web.core.windows.net/%E3%82%B9%E3%83%88%E3%83%AC%E3%83%BC%E3%82%B8%E3%82%B5%E3%83%BC%E3%83%93%E3%82%B9%E3%81%AE%E5%9C%B0%E7%90%86%E5%86%97%E9%95%B7(GRS)%E3%81%AE%E9%9A%9C%E5%AE%B3%E6%99%82%E3%81%AE%E6%8C%99%E5%8B%95%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6[20181031%E8%BF%BD%E8%A8%98].html

https://blog.azure.moe/2019/02/14/azure-storage-account-failover/

https://ascii.jp/elem/000/001/814/1814446/

https://qiita.com/y10exxx/items/80387725767f4794b7bd

■参考: ストレージ アカウントのプライマリ エンドポイントに対する要求エラーをシミュレートする

https://docs.microsoft.com/ja-jp/azure/storage/blobs/simulate-primary-region-failure#simulate-a-failure-with-an-invalid-static-route


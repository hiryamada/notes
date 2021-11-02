# Azure Blob Storage

https://docs.microsoft.com/ja-jp/azure/storage/blobs/access-tiers-overview

■Azure Blob Storageの「アクセス層」

- ホット
  - オンライン（即座にアクセス可能）
  - 読み取り SLA 99.99% (RA-GRS)
  - 読み取り SLA 99.9% (LRS, ZRS, GRS)
  - 書き込み SLA 99.9% (LRS, ZRS, GRS, RA-GRS)
- クール
  - オンライン（即座にアクセス可能）
  - 読み取り SLA 99.9% (RA-GRS)
  - 読み取り SLA 99% (LRS, ZRS, GRS)
  - 書き込み SLA 99% (LRS, ZRS, GRS, RA-GRS)
- アーカイブ
  - オフライン（即座にアクセスはできない）
  - 保存コストが最も安い
  - 待機時間が長い
    - 「[リハイドレート](https://docs.microsoft.com/ja-jp/azure/storage/blobs/archive-rehydrate-overview)」を行って（最大15時間）、「ホット」または「クール」に変更するか、「ホット」または「クール」のBlobにコピーすると、オンラインとなり、アクセスが可能となる
  - データは、少なくとも 180 日間、アーカイブ層に保持される必要がある
    - それよりも早く削除すると「早期削除料金」の対象となる


■アクセス層の設定

- ストレージアカウントの「デフォルト アクセス層」
  - 「ホット」または「クール」
- 個々のBlob
  - 「ブロックBlob」でのみ指定可能。「ページBlob」「追加Blob」では指定できない
  - 「ホット」「クール」「アーカイブ」
  - アップロード時に指定
  - アップロード後の変更も可能
  - 指定しない場合はストレージアカウントの「デフォルト アクセス層」が使用される
    - 「ホット（推定）」「クール（推定）」などのように表示される

■ライフサイクル管理ポリシー

「最終変更から30日後に、Blobをクールに変更する」といったルールを設定できる。

アクセス層の設定を自動化することができる。

[最終アクセス時刻](https://docs.microsoft.com/ja-jp/azure/storage/blobs/lifecycle-management-overview#move-data-based-on-last-accessed-time)に基づくルール設定も可能。

# Azure Files

Azure Files ファイル共有の「ストレージ層」

（Azure portalでは「レベル」）

https://docs.microsoft.com/ja-jp/azure/storage/files/storage-files-planning#storage-tiers


- Premium
  - 「Premium ファイル共有」ストレージアカウントで利用可能
  - ほとんどの IO 操作で 1 桁のミリ秒以内の低待機時間を提供
  - SSD
  - 100 GiB ～ 102,400 GiB (約100TiB)
  - プロビジョニングされた共有サイズに基づいて課金
  - 保存コスト 0.16 ドル/GiB/月
- トランザクション最適化
  - 「Standard 汎用 v2」ストレージアカウントで利用可能
  - トランザクション負荷の高いワークロード
  - HDD
  - ポータルからファイル共有を作成する際のデフォルト
  - 最大 5 TiB
  - 保存コスト 0.06 ドル/GiB/月
- ホット
  - 「Standard 汎用 v2」ストレージアカウントで利用可能
  - チーム共有などの汎用ファイル共有シナリオに最適化
  - HDD
  - 最大 5 TiB
  - 保存コスト 0.0287 ドル/GiB/月
- クール
  - 「Standard 汎用 v2」ストレージアカウントで利用可能
  - オンライン アーカイブ ストレージのシナリオ向け
  - HDD
  - 最大 5 TiB
  - 保存コスト 0.0228 ドル/GiB/月

※コストはEast US(米国東部)。他に操作等に対するコストが発生。https://azure.microsoft.com/ja-jp/pricing/details/storage/files/

パフォーマンスは、ストレージアカウントの種類によって決まる。
- 「Premium ファイル共有」ストレージアカウント
  - 最大同時要求レート: 20,000 IOPS
- 「Standard 汎用 v2」ストレージアカウント
  - 最大同時要求レート: 100,000 IOPS

https://docs.microsoft.com/ja-jp/azure/storage/files/storage-files-scale-targets

■参考

[ストレージアカウントの種類, レプリケーション(LRS, ZRS, GRS, GZRS, RA-GRS, RA-GZRS)まとめ](../AZ-104/pdf/mod07/ストレージアカウントの種類.pdf)


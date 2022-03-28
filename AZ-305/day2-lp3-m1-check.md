# 知識チェック

[知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-data-storage-solution-for-non-relational-data/9-knowledge-check)

# ケーススタディ

https://github.com/MicrosoftLearning/AZ-305-DesigningMicrosoftAzureInfrastructureSolutions.ja-jp/blob/main/Instructions/CaseStudy/03-Nonrelationalstorage.md

■タスク

あなたは、Tailwind Traders社の[クラウドアーキテクト](https://www.google.com/search?q=%E3%82%AF%E3%83%A9%E3%82%A6%E3%83%89%E3%82%A2%E3%83%BC%E3%82%AD%E3%83%86%E3%82%AF%E3%83%88)です。

- 上記の「ケーススタディ」ページの「要件」を読んでください。
- Tailwind Traders社の問題点を分析し、改善案を一つ以上提案してください。
  - 例: 配信速度を向上させるために～～を～～に配置する
  - 例: コストを削減するために～～を～～に配置する
  - 例: 原稿としてのOfficeファイルは～～に配置し、それらのWebサイト公開用のPDFは～～に配置する
  - 例: 容量が極端に大きなファイルを検出して～～する
  - 例: ファイルサーバーの性能を向上させるため～～する
  - 例: あるシーズンだけアクセスが多くなるファイルを～～に配置する
- 改善案は、Klaxoonに記入してください。
- ※上記「ケーススタディ」ページ内の「タスク」はスキップしてください。
- ※このコースでここまでに学習した知識に限定する必要はありません。
- ※「要件」に書かれていないことについて、講師に質問してはっきりさせる必要はなく、適当に仮定を置いて大丈夫です。
  - 例: 「WordやExcelはデスクトップアプリを使用し、OneDriveではなく社内ファイルサーバーに格納しているものと仮定します」
  - 例: 「製品は500種類あり、1製品につき5～6枚のJPEG画像があり、1枚あたり5MBのサイズを想定します」
- ※できればAzureを活用して問題を解決してください。
  - あまりよくない例: 「MP4の公開を停止します」
  - あまりよくない例: 「Webアプリに[遅延ロード](https://www.google.com/search?q=%E7%94%BB%E5%83%8F+%E9%81%85%E5%BB%B6%E8%AA%AD%E3%81%BF%E8%BE%BC%E3%81%BF)を実装します」

■ヒント

- ストレージアカウント内で、適切なサービスを選択する
  - インターネットに公開される動画、PDFファイル: Blob Storage
  - WordやExcelなど、アプリで開くファイル: Azure Files ファイル共有
- Blobで、適切なアクセス階層を使用する
  - 頻繁にアクセスされるファイル: ホット
  - 年に数回しかアクセスされないファイル: クール
  - ほとんどアクセスされない（が、長期保存する必要がある）ファイル: アーカイブ
- Blobで、「[ライフサイクル管理ポリシー](https://docs.microsoft.com/ja-jp/azure/storage/blobs/lifecycle-management-overview)」を設定する
  - アクセスがされないファイルを自動的にクールやアーカイブにする
  - [BLOB がクールに階層化された後で再びアクセスされた場合に、BLOB を自動的にクールからホットに階層化する](https://docs.microsoft.com/ja-jp/azure/storage/blobs/lifecycle-management-overview#move-data-based-on-last-accessed-time)
- [Azure CDNを使用する](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-overview)


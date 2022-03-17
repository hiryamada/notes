# オープンソースソフトウェアとライセンス

- オープンソースソフトウェアとは
- ライセンスとは

## オープンソース ソフトウェア

### ソフトウェアのビルト方法

注: タイトルに「ビルド方法」とあるが、ここはOSSの使用に関する解説。

■ライセンス

参考: http://www.it-houmu.com/archives/1848

利用するソフトウェアの各ライセンスを確認し、それを遵守することが重要。

[TLDRLegal](https://tldrlegal.com/) - ソフトウェアのライセンスの概要、Can, Cannot, Mustをわかりやすく説明。

[FOSSA](https://www.hitachi-solutions.co.jp/fossa/) - OSSライセンス管理ツール

プロジェクトで使用しているライブラリのライセンスの一覧を生成するツール:

- [LicensePlist](https://medium.com/swift-column/license-plist-c0363a008c67) - iOS/Androidアプリ用
- [Nuget License Utility](https://github.com/tomchavakis/nuget-license) - .NETアプリ用
- [licensee](https://backport.net/blog/2021/12/18/licensee/) - Androidアプリ向け。依存関係グラフに含まれる各ライブラリのライセンスが期待通りのものかどうかを検証してくれるGradleプラグイン

■オープンソースとクローズドソース


### オープンソース ソフトウェアとは?

■オープンソースの定義

- オープンソースの定義
  - 米国の公益法人であるOpen Source Initiative (OSI)が策定した、オープンソースとされるものが満たすべき条件を示した文書
  - [原文](https://opensource.org/osd-annotated)
  - [OSG-JP(Open Source Group Japan)による日本語訳](https://opensource.jp/osd/osd19/)
  - [Wikipedia](https://ja.wikipedia.org/wiki/%E3%82%AA%E3%83%BC%E3%83%97%E3%83%B3%E3%82%BD%E3%83%BC%E3%82%B9%E3%81%AE%E5%AE%9A%E7%BE%A9)

■Microsoftとオープンソースの関係

マイクロソフトはオープンソースに関して以下のような取り組みを行っている。

- いくつかのソフトウェアをオープンソースとして提供している
  - [.NETは、オープンソースである](https://dotnet.microsoft.com/ja-jp/platform/open-source)
  - Visual Studio Code
  - TypeScript
  - Windows Terminal
- [オープンソースプロジェクトにAzureの無償クレジットを提供している。](https://www.publickey1.jp/blog/21/azure_1.html)
- [すべてのオープン ソース プロジェクトで、Azure Pipelinesの10 個の無料の並列ジョブ (ビルド時間無制限) を利用できる。](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)
- [Azureでは、Linux, MySQL, PostgreSQL, MongoDB, Cassandra, Redisなどのオープンソースソフトウェアを利用できる](https://azure.microsoft.com/ja-jp/overview/open-source/#open-source)
- [Microsoftのオープンソースへの取り組みを紹介する公式サイト](https://opensource.microsoft.com/)
- [Cloud Foundry Foundation と Cloud Native Computing Foundation に参加している](https://blogs.partner.microsoft.com/mpnjapan/2017/08/03/%E3%83%9E%E3%82%A4%E3%82%AF%E3%83%AD%E3%82%BD%E3%83%95%E3%83%88%E3%81%AE%E3%82%AA%E3%83%BC%E3%83%97%E3%83%B3%E3%82%BD%E3%83%BC%E3%82%B9%E3%81%B8%E3%81%AE%E5%8F%96%E3%82%8A%E7%B5%84%E3%81%BF-cloud-fou/)

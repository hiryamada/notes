
# モノレポ vs 複数リポジトリ

単一のリポジトリに多数のプロジェクトを入れるべきか？(monorepo)

```
リポジトリ
├プロジェクト1のコード
├プロジェクト2のコード
└プロジェクト3のコード
```

それとも、(GitHubのリポジトリのように)プロジェクトごとにリポジトリを分けたほうがよいか？(manyrepo,multirepo,polyrepo)

```
プロジェクト1のリポジトリ
└プロジェクト1のコード

プロジェクト2のリポジトリ
└プロジェクト2のコード

プロジェクト3のリポジトリ
└プロジェクト3のコード
```

## モノレポとは？

[モノレポ](https://en.wikipedia.org/wiki/Monorepo)（monorepo, monolithic repository）モノリポとも
- 複数のアプリのソースコードを単一のリポジトリに格納
  - 数百万～数千万行のソースコード
  - 数十万～数十億ファイル
  - 数GB～数TB
- 大企業での採用が多い: 
  - Google社、Facebook社、Twitter社などでこの戦略をとっている
- モノレポ＝モノリス（一枚岩の巨大なアプリケーション）ではない。[原文](https://blog.nrwl.io/misconceptions-about-monorepos-monorepo-monolith-df1250d4b03c)、[翻訳](https://www.graat.co.jp/blogs/ck1099bcoeud60830rf0ej0ix)。
- [「コードベース」（Wikipedia）](https://ja.wikipedia.org/wiki/%E3%82%B3%E3%83%BC%E3%83%89%E3%83%99%E3%83%BC%E3%82%B9)とも。
  - GoogleやFacebookは巨大なモノリシックコードベースを運用している。企業内のすべてのソースコードがそこに集約されている。

## Googleでの事例

[Googleのソースコード管理 Piper](https://www.school.ctc-g.co.jp/columns/nakai2/nakai220.html)

> 1つの巨大なリポジトリ内に、ディレクトリーを分けるかたちで、すべてのソフトウェアのソースコードが保存されています。

[モノリシックなバージョン管理の利点(postd.cc)](https://postd.cc/monorepo/)


> Google内部のビルドシステム では、モジュール化された大規模なコードブロックを使用することで、ソフトウェアの構築が信じられないほど容易になっています。例えば、クローラが必要な時にはこちらから数行、RSSパーサが必要な時にはあちらから数行、そしてフォールトトレランス機能を持った大規模な分散データストアが必要な時には数行を追加、といった具合です。これらは多くのプロジェクト間で共有されているビルディングブロックやサービスで、統合も簡単にできます。


[PiperはGoogle社内のシステムであって、オープンソース化されていない](https://stackoverflow.com/questions/46391415/is-there-an-open-source-equivalent-to-piper-googles-version-control-tool)

[動画（Youtube）: Googleが数十億行のコードを単一のリポジトリに保存する理由](https://www.youtube.com/watch?v=W71BTkUbdqE)

## Microsoftでの事例

Microsoftは、OneDrive、SharePointなどのいくつかの製品プロジェクトでモノレポを使用している。また、それらのプロジェクトで使われているモノレポマネージャ Rush を公開している。

[Rush よりも Lerna のほうが人気が高い](https://www.npmtrends.com/@microsoft/rush-vs-lerna-vs-oao-vs-bolt)

- [Lerna（レーナ）](https://github.com/lerna/lerna)
- [Rush](https://rushjs.io/)

[動画（Youtube）: Lernaを使ったモダンなモノレポ](https://www.youtube.com/watch?v=ZSdCNf1ncOE)

## モノレポ vs 複数リポジトリ

https://messagepassing.github.io/007-repo/03-morrita/

> Monorepo は企業ソフトウェア開発のベストプラクティスを自然と実現してしまう矯正ギプスとして機能した。ツール・インフラの統一、ライブラリバージョンの統一、ビルドの自己完結性、ソースコードの可視性、変更のアトミック性などなど。こういうのは理論上は Monorepo でなくても実現できるけれど、Monorepo にしておくとすごいラクで、むしろ逆らうのが難しい。
> 
> （略）
> 
> 少し前に出た “Software Engineering at Google” という本では Monorepo と Manyrepo の利点欠点を比較し、いちばん重要なのはライブラリバージョンの統一 “One Version Rule” であって、これをはじめとする様々なベストプラクティスを実現できるなら別に Monorepo である必要はないと書いている。そしてバージョン管理は小さなレポジトリを Monorepo の原則に従って寄せ集める “Federated Monorepo” になるだろうと締めくくっている。

## Azure DevOpsでの運用

Azure DevOpsでは、モノレポも複数リポジトリも運用できる。

- モノレポ: [事例1](https://julie.io/writing/monorepo-pipelines-in-azure-devops/), [2](https://florian-rappl.de/Articles/Page/390), [3](https://tech-lead.eu/architecture/monorepo-in-azure-devops/)
- 複数リポジトリ: 1つのプロジェクトの中に複数のリポジトリを持つことができる。プロジェクトが複数のモジュールで構成されている場合に、モジュールごとにリポジトリを持つことができる。

## GitHubでの運用

基本的にGitHubは複数リポジトリとなるが、モノレポとして運用することもできる（1つのリポジトリに多数のモジュールを含める等）。

[JavaScriptのコンパイラBabel](https://babeljs.io/)の多数のモジュールは、GitHub上で、[モノレポ](https://github.com/babel/babel/blob/master/packages/README.md)で開発されている

[Bablelのプロジェクトではモノレポの管理にLernaを使用している。](http://shokai.org/blog/archives/10574)
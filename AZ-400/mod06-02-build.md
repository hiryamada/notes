
## ビルド戦略の実装

### エージェント要求の構成

すべてのセルフホステッド エージェントには、何が可能かを示す一連の「機能（Capabilities）」があります。

「機能（Capabilities）」の種類
- システム機能: マシン名やオペレーティング システムの種類など。自動的に検出される。
- ユーザー機能: ユーザーが定義するもの
  - マシンにインストールされている特定のソフトウェアのバージョンなど

パイプライン側で、「要求（demands）」を使用して、パイプラインが必要とする「機能（Capabilities）」が、それを実行するエージェント上に存在することを確認します。[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/demands?view=azure-devops&tabs=yaml)

### マルチ エージェント ビルドの実装

並列ビルドとは。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#multi-job-configuration)

1つのジョブで、複数のエージェントを使用して、複数のビルドやリリースを並列で行うことができます。

並列化することで、それぞれの作業を順番に実行する場合にくらべて、より早く作業を完了させることができます。

例:
- x86版(32 bit)とx64版(64 bit)を同時にビルドする
- ビルドした成果物を複数のリージョンに同時にデプロイする

### ディスカッション - ビルド関連のツール

講師（山田）は昔、Javaの開発案件で、[Maven](https://maven.apache.org/), [Gradle](https://gradle.org/) などのビルドツールを使用したことがあります。また、（ビルドツールと呼んでよいのかわかりませんが）Ruby on Railsで開発する際に、「[rails db:migurate](https://railsguides.jp/active_record_migrations.html#%E3%83%9E%E3%82%A4%E3%82%B0%E3%83%AC%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E5%AE%9F%E8%A1%8C%E3%81%99%E3%82%8B)」を使用してデータベースのスキーマ変更を行ったり、「[rails assets:precompile](https://railsguides.jp/command_line.html#rails-assets)」を使用して、JavaScriptやCSSをプリコンパイルする、といったことをやっていました。最近は、仕事柄、.NET(C#)のサンプルコードを記述する事が多く、[dotnet build](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-build) というコマンドを使用することがありますが、Visual Studio や Visual Studio Code を使用する場合は、F5を押してプロジェクトを実行する際に自動的にビルドが裏側で走るので、あまりビルドという作業自体を意識しないことも多いです。ただ、CI/CDを構成する場合は、明示的にビルドを実行するコマンドを指定しなければならない場面がありますね。

なにか思い出や教訓などがございましたら、ぜひチャットに書き込んでください。

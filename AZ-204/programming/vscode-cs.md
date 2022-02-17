# Visual Studio CodeによるC#プログラミング


## .vscode フォルダ

フォルダの作り方

- VS Codeでプロジェクトを開いた際に「Required assets to build and debug are missing from '...'. Add them?」というプロンプトが出るので、「Yes」をクリックする
- コマンドパレットから「.NET: Generate Assets for Build and Debug」を実行する

フォルダに含まれるもの

- launch.json
- tasks.json
  - build
  - publish
  - watch

## VS Codeの「タスク」

https://code.visualstudio.com/docs/editor/tasks

task.json: VSCode > Terminal > Run Task... で、`tasks.json` で定義された名前のタスクを実行できる。

※watchでコンソールアプリを実行し、ファイルを編集して保存すると、ビルドが繰り返し実行されてしまう。ワークアラウンドとしては、 `--no-host-reload` オプションを使用する。（`watch`タスクの`args`に`"--no-host-reload"`を追加）https://github.com/dotnet/aspnetcore/issues/38064

ビルドタスクは Ctrl + Shift + B で実行できる。

## launch.json

https://code.visualstudio.com/docs/editor/debugging#_launchjson-attributes

https://amateur-engineer-blog.com/vscode-launchjson/

デバッグ実行時に使用される設定が格納されている。


## bin フォルダとobjフォルダ

https://stackoverflow.com/questions/5308491/what-are-the-obj-and-bin-folders-created-by-visual-studio-used-for/5308538

- obj
  - （まだリンクされていない）オブジェクトファイルを格納する
- bin
  - （リンクされた）バイナリーファイル（実行可能形式）を格納する
  - `dotnet publish` とすると、publish フォルダができる

## ビルド構成 - デバッグとリリース

「obj/Debug」「bin/Debug」といったフォルダがある。

https://docs.microsoft.com/ja-jp/visualstudio/debugger/how-to-set-debug-and-release-configurations?view=vs-2022

https://docs.microsoft.com/ja-jp/visualstudio/ide/understanding-build-configurations?view=vs-2022

- デバッグ
  - シンボリックデバッグ情報が含まれる
  - 最適化は行われない
- リリース
  - シンボリックデバッグ情報が含まれない
  - 最適化が行われる
  - `dotnet build -c Release`
  - `dotnet publish -c Release`
  - `dotnet run -c Release`
  - .cscodeの `PropertyGroup` 要素内で `Configration` 要素を作り、その値を `Release`にする

C#コード中に以下のような記述を行うと、デバッグとリリースで実行するコードを変えることができる。（[条件付きコンパイル](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/preprocessor-directives#conditional-compilation)）

```csharp
#if DEBUG
Console.WriteLine("debug");
#elif RELEASE
Console.WriteLine("release");
#endif
```

`DEBUG`のようなものは「シンボル」という。


Azure Functions Core Toolsで、パブリッシュ時にRelease構成を使用したい場合は、明示的に指示をする必要がある。https://github.com/Azure/azure-functions-core-tools/issues/670



## exeファイルとdllファイル

## コンパイルしたコードは、どの環境で動くのか？ -> 「クロスプラットフォーム」

たとえばWindows環境でコンパイルして作った実行可能ファイルは、Linuxでも動くのか？

Nugetライブラリは、どの環境でも動くのか？ Windows用/Linux用/Mac用といった区別はないのか？

- 実行可能ファイルはクロスプラットフォームではありません
- dll ファイルの形式でフレームワーク依存として発行すると、クロスプラットフォーム バイナリが作成されます。

`dotnet build -r linux-arm64 --no-self-contained` などのようにして、ランタイムを指定することができる。

## フレームワーク

https://docs.microsoft.com/ja-jp/dotnet/standard/frameworks

ターゲットフレームワークは「ターゲットフレームワークモニカー(TFM)」で指定する。

- .NET 6
  - net6.0
- .NET 5
  - net5.0
- .NET Core 3.1
  - netcoreapp3.1
- .NET Framework 4.8
  - net48

## .NET 6  C# 10

https://docs.microsoft.com/ja-jp/dotnet/core/whats-new/dotnet-6

## セルフコンテインド (self-contained)

https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-publish

アプリケーションと併せて .NET ランタイムを発行します。これにより、ランタイムをターゲット コンピューターにインストールする必要がなくなります。

.NET Runtime不要？？

## publish

https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-publish

ホスティング システムへの展開のため、アプリケーションとその依存関係をフォルダーに発行します。

アプリケーションをコンパイルし、プロジェクト ファイルに指定されたその依存関係を読み取り、結果のファイル セットをディレクトリに発行します。 出力には次のアセットが含まれます。

- アセンブリの中間言語 (IL) コード (dll 拡張子)。
- .deps.json ファイル。プロジェクトのすべての依存関係が含まれます。
- .runtimeconfig.json ファイル。アプリケーションが想定する共有ランタイムと、ランタイム用の他の構成オプション (ガベージ コレクションの種類など) を指定します。
- アプリケーションの依存関係。NuGet キャッシュから出力フォルダーにコピーされます。





## gitとgitignore

```
git init
```

```
dotnet new gitignore
```

## user-secrets

https://qiita.com/tnishiki/items/0c3e73ed28a66591d676

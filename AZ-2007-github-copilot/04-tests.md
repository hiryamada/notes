dotnet new sln
dotnet new classlib -n PrimeService
dotnet sln add PrimeService
dotnet new xunit -n PrimeService.Tests
dotnet sln add PrimeService.UnitTests
dotnet add PrimeService.UnitTests reference PrimeService
dotnet test


dotnet new sln
dotnet new classlib -n PrimeService -o src
dotnet sln add src
dotnet new xunit -n PrimeService.Tests -o tests
dotnet sln add tests
dotnet add tests reference src
dotnet test

dotnet new sln -f slnx
dotnet new classlib -n MyService -o src
dotnet new xunit -n MyService.Tests -o tests
dotnet sln add src
dotnet sln add tests
dotnet sln add tests reference src
dotnet add tests reference src

Ctrl + Shift + B: build
Ctrl + ;, a : run all test

Ctrl + / コンテキストのアタッチ（クリップマーク）
#file

dotnet new sln
dotnet new classlib -o src
dotnet new xunit -o tests
dotnet sln add src tests
dotnet add tests reference src

(vscode command palette).NET: Install New .NET SDK

Alt Click test to expand all nodes

※テストプロジェクトの命名規則として、{YourProject}.Testsにするのが一般的
https://zenn.dev/yuriemori/articles/f6a73b326a3f0f

/generate IsPrime


dotnet new sln -o unit-testing-using-dotnet-test
cd unit-testing-using-dotnet-test
dotnet new classlib -o PrimeService
ren .\PrimeService\Class1.cs PrimeService.cs
dotnet sln add ./PrimeService/PrimeService.csproj
dotnet new xunit -o PrimeService.Tests
dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
rm .\PrimeService.Tests\UnitTest1.cs
New-Item PrimeService.Tests/PrimeService_IsPrimeShould.cs

rename test methods following to xunit best practices

■コード提案を使って直接テストコードを書いていく
特に問題はない

■右クリック＞Copilot＞Generate Tests

新しいタブ Class1Tests.cs の中にテストコードが生成される
NUnitが使われる。
追加の指示で「use xUnit」のように指示すると、xUnitを使ったテストコードが再生成される。
追加の指示で「use InlineData」のように指示すると、[Theory][InlineData]を使ったテストコードが再生成される。
Ctrl + EnterでAccept。ファイルはまだこの時点では保存されていない。
Ctrl + S でファイルを保存すると、tests ではなく srcの方に保存される。ファイルを手動で src 以下へと移動する。

または、Ctrl + Shift + S で、ファイルを明示的に src/PrimeServiceTests.cs などに保存。

■インラインチャット(Ctrl + I)、/tests

右クリック＞Copilot＞Generate Tests と同じ結果になる

■チャット(Ctrl + Alt + I)、/tests

/tests と打つと @workspace /tests  に展開される（/tests スラッシュコマンドは @workspace に属する）

Workspaceによってプランと、src/Class1Test.csのソースが表示される。
ソースの右上の「Apply Edits」がクリックできる。
	クリックすると新しいタブにClass1Tests.csのソースが出力される（1行目に// filepath: /C:/Users/hiryamada/github/sample8/src/Class1Test.cs）
	Ctrl+Sで保存しようとするとファイル保存ダイアログが出てくるので、ここで tests フォルダを選択できる。
ソースの左下では「Retry」「Helpful」「Unhelpful」「Edits with Copilot」がクリックできる
	「Edits with Copilot」をクリックすると、そこまでのチャットが Copilot Editsに移される。またParticipantsはGitHub Copilotとなる。が、
	「Sorry I can't assist with that」と表示される。

@workspace /tests in tests folder といったように補足してやると、1行目に// filepath: /C:/Users/hiryamada/github/sample8/tests/Class1Test.cs と書かれたものが生成される・・・が、ファイル保存ダイアログの初期位置は特に変わらない。

■Copilot Edits（Ctrl + Shift + I） ※@workspace などのparticipantは使えない。常に@github に対する指示となる。

Write xUnit tests for IsPrime. Output it to tests folder.
といったプロンプトでうまくいく。
tests/PrimeCheckerTests.cs といった適切な場所、適切なファイル名が使用される。
[Accept][Done]とクリック。

■チャットの中で
Write xUnit tests for IsPrime. Output it to tests folder.
とやると、@github がそれを @workspace /tests を使う形へと変換して実行する。

Rerun withoutをクリックすると、@githubがコードを書いてくれる。
この画面では「Apply to tests/PrimeCheckerTest.cs」ボタン、「Insert At Cursor」ボタン、Copyボタン、
「Insert Into Terminal」ボタン、「Insert Into new File」ボタンなどが利用できる。

■チャットの中で
@github Write xUnit tests for IsPrime. Output it to tests folder.
とやると、
Please provide the repository name and owner so I can retrieve the latest version of the PrimeChecker class and proceed with writing the xUnit tests.
Please provide the repository name and owner so I can retrieve the PrimeChecker.cs file content.
といった結果になる場合があるが、うまくいくこともある。



■チャットの中で
@github Write xUnit tests for IsPrime.
とだけ指示するとうまくいく


＝＝＝＝＝＝＝＝＝＝＝＝


Code Review

不適切なファイル名の修正 class1 => PrimeChecker
性能の改善 Math.Sqrtをループの外で計算
読みやすさの改善 if (...) return ... を複数行に展開
コメントの追加 


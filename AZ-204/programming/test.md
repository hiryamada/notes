# テストの種類

https://docs.microsoft.com/ja-jp/learn/modules/run-functional-tests-azure-pipelines/2-what-is-functional-testing

https://auth0.com/blog/xunit-to-test-csharp-code/

テストの種類

- Unit test
  - 関数やクラスの単位のテスト
- Integration test
  - 複数のユニットを組み合わせたコンポーネントのテスト
- End-to-end (E2E) test
  - ユーザーレベルの機能のテスト
    - APIアプリの場合はAPIからテスト
    - モバイルアプリの場合はモバイルアプリのUIからテスト
  - 複数のシステムにまたがる動作
  - プロダクションのシナリオに対応

AAAパターン

- Arrange: 前提条件の準備
- Act: 実際のテスト
- Assert: Actが期待した結果になっているかどうかの確認

xUnit.net

https://xunit.net/

- unit testing tool for the .NET framework
  - [Integaration testも可能](https://auth0.com/blog/xunit-to-test-csharp-code/#Introducing-Integration-Tests)
- 最も人気がある
- [.NET Foundationによってサポートされている](https://dotnetfoundation.org/projects/xunit)

使い方
- `[Fact]`属性を付けたメソッド
- `Assert.True()`
- `Assert.False()`
- `[Theory]`属性と`[InlineData(...)]`
- `Assert.Equal()`


# VS Codeでの自動単体テスト by Scott Hanselman

https://www.hanselman.com/blog/automatic-unit-testing-in-net-core-plus-code-coverage-in-visual-studio-code

# ClassData

InlineDataの仲間？

IEnumerable を実装したクラスをデータソースとする

https://kuttsun.blogspot.com/2020/06/c-classdata.html

# MemberData

InlineDataの仲間？

クラスのプロパティ/メソッドをデータソースとする

# Chaining Assertion

https://github.com/neuecc/ChainingAssertion

by neuecc(Yoshifumi Kawai)

# テストの種類 / 単体テスト

https://docs.microsoft.com/ja-jp/dotnet/core/testing/

https://docs.microsoft.com/ja-jp/azure/architecture/framework/devops/release-engineering-testing

# 統合テスト - integration test


https://docs.microsoft.com/ja-jp/aspnet/core/test/integration-tests?view=aspnetcore-6.0

統合テストの説明では、テスト対象のプロジェクトをよくテスト対象システム、または短縮して "SUT" と呼びます。

System Under Test, or "SUT" for short

統合テストでは、通常の Arrange (配置) 、Act (実行) 、および Assert (確認) のテスト ステップを含む一連のイベントに従います。

統合テストの例

https://medium.com/compendium/self-contained-real-integration-tests-with-example-in-net-core-8dc581276562

xUnitを使用。Processを使用。Mainメソッドのテスト。

https://www.c-sharpcorner.com/article/implementing-unit-and-integration-tests-on-net-with-xunit/

xUnitを使用。dotnet-reportgenerator-globaltool を使用して、カバレッジレポートを生成。

https://www.c-sharpcorner.com/article/restful-day-sharp7-unit-testing-and-integration-testing-in-weba/

# スタブとモック

https://qiita.com/k5trismegistus/items/10ce381d29ab62ca0ea6

- スタブ
  - テスト対象のオブジェクトが内部で使用するオブジェクトの代わり
  - 決まりきった値を返す
  - 「受信メッセージのテスト」（オブジェクトがメッセージを受け取ったとき適切な返事をするか）で使用
- モック
  - メッセージの引数や呼び出し回数が想定通りかを検証する
  - 「送信メッセージのテスト」（オブジェクトが副作用のあるメッセージを送信するとき、適切な引数・回数で送信しているか）で使用

たとえば以下のようなコードを考えた場合
```
指定されたURLのBlobの内容を読み取るコード
↓
サービス（Azure Blob Storage）
```

- スタブ
  - サービスの代わりのオブジェクト。ダウンロード命令に対して、適当な戻り値を返す。
- モック
  - サービスに対して適切な引数を渡しているか、適切な回数を呼び出しているかを確認する。

https://docs.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-best-practices#lets-speak-the-same-language

「フェイク」: モック または スタブ

# Microsoft Fakes

https://docs.microsoft.com/ja-jp/visualstudio/test/improve-code-quality?view=vs-2022#microsoft-fakes

Enterprise Edition でのみ使用可能。

# BlobContainerClient() の モックはどうすればよいのか？

https://stackoverflow.com/questions/64385008/how-to-mock-blobcontainerclient-of-azure-storage-blobs

```
public static BlobContainerClient GetBlobContainerClientMock()
{
    var mock = new Mock<BlobContainerClient>();
    mock
        .Setup(i => i.AccountName)
        .Returns("Test account name");
    return mock.Object;
}
```


# xUnitでIntegaration testを実装

https://auth0.com/blog/xunit-to-test-csharp-code/#Introducing-Integration-Tests

https://www.c-sharpcorner.com/article/implementing-unit-and-integration-tests-on-net-with-xunit/

xUnitでの `IDisposable` の使い方
https://qiita.com/inabe49/items/0dad7360a485c68e291e

https://xunit.net/docs/shared-context


# Bogus


https://github.com/bchavez/Bogus

faker.js の C#移植版

([Rubyのfaker](https://github.com/faker-ruby/faker))


# bUnit

https://bunit.dev/

Blazor テスト用
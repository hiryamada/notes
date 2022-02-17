# xunitの導入

https://news.mynavi.jp/techplus/article/20100716-xunit/

https://artisan.jp.net/blog/c_sharp-xunit-vscode/

https://docs.microsoft.com/ja-jp/dotnet/core/testing/

https://docs.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-with-dotnet-test

https://xunit.net/

# ソリューション内にテスト対象プロジェクトとテストプロジェクトを作る

https://docs.microsoft.com/ja-jp/visualstudio/get-started/tutorial-projects-solutions?view=vs-2022

構造
```
ソリューション
├テスト対象プロジェクト X
│└X.csproj
└テストプロジェクト X.Tests
  └X.Tests.csproj
```

実際の操作

```
# ソリューションを作る
dotnet new sln -o solutionName
cd solutionName

# テスト対象プロジェクトを作りソリューションに追加
dotnet new classLib -o PrimeService
dotnet sln add ./PrimeService/PrimeService.csproj

# テストプロジェクトを作りソリューションに追加
dotnet new xunit -o PrimeService.Tests
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj

# テスト対象のプロジェクトを依存関係としてテストプロジェクトに追加
# dotnet add テストプロジェクト reference テスト対象プロジェクト
dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
```

# Azuriteの使用例

https://itbackyard.com/how-to-unit-testing-azure-storage-in-csharp-part-2-3/


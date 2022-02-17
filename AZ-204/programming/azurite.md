
# Azurite

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azurite?tabs=visual-studio

※Azurite自身はNode.js (TypeScript)で書かれている。


# Azurite, Dockerを利用した統合テスト

https://itbackyard.com/how-to-unit-testing-azure-storage-in-csharp-part-1-3

Azurite, xunit. Azuriteは Docker.DotNet を使用して、C#コード内でコンテナーを作成している。

https://medium.com/purplebricks-digital/integration-testing-applications-that-use-azure-blob-storage-ad1ea83f5451

Processを使用して、C#から`docker`コマンドを直接叩くことで、Azuriteを駆動させている。

# クラウドを活用したテストはできないのか？

テスト開始
→テストに必要なインフラをデプロイ
→インフラを使用してコードをテスト
→テストが完了したらインフラを削除

といったような・・・?

https://samlearnsazure.blog/2020/02/27/creating-a-dynamic-pull-request-environment-with-azure-pipelines/

プルリクエストに対応した環境を作成する例。


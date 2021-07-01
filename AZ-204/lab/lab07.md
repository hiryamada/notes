# ラボ7

## 概要

```
Key Vault シークレット（ストレージアカウント接続文字列）
  ↓ シークレットの取得
Function(+マネージドID) → ストレージアカウントへのアクセス
```

## 重要ポイント

- 演習1 タスク2
  - ストレージアカウントを作成
  - 接続文字列をコピー
- 演習1 タスク3
  - KeyVaultを作成
- 演習1 タスク4
  - Azure Functions 関数アプリを作成 .NET 3.1, Linux, 従量課金
- 演習2
  - 関数アプリにマネージドIDを割り当て
  - Key Vaultにシークレットとして接続文字列を追加
  - シークレット識別子をコピー
  - Key Vaultにて、シークレットのGETができるアクセスポリシーを作成
  - 関数アプリのアプリケーション設定に以下を追加
    - `@Microsoft.KeyVault(SecretUri=シークレット識別子)`
- 演習3 環境変数から値を読み取るアプリを作成
  - funcコマンドでプロジェクトを作成
    - `func init --worker-runtime dotnet`
    - `func new --template "HTTP trigger"`
  - `local.settings.json`に、テスト用の設定値を追加
  - ローカルで実行して、テスト用設定値が取り出されることを確認
  - Azure Functionsにデプロイ
    - `func azure functionapp publish`
  - 関数をAzure portal上からテスト実行し、接続文字列が返されることを確認
- 演習4 Blobの内容を読み取るアプリを作成
  - テスト用のBlobを追加
  - プロジェクトにストレージクライアントライブラリを追加
    - `dotnet add package Azure.Storage.Blobs`
  - Blobを読み取る
    - `BlobClient blob = new BlobClient(connectionString, "drop", "records.json")`
    - `var response = await blob.DownloadAsync()`
  - 読み取ったBlobの内容をHTTP関数のレスポンスとして返す
    - `return new FileStreamResult(response?.Value?.Content, response?.Value?.ContentType)`
  - Azure Functionsにデプロイ
    - `func azure functionapp publish`
  - 関数をAzure portal上からテスト実行し、Blobの内容が返されることを確認

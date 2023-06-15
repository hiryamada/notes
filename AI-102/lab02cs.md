# ラボ02

- Azure portalを開く。サインイン、UIを日本語化。
- Cognitive Servicesマルチサービスアカウントを作成
  - リージョン: East US
  - リソースグループ: 作成済みの ResourceGroup1 を選択
  - 名前: cog902387423 など適当に
  - キーとエンドポイントをコピー
- キーコンテナー (Key Vault)を作成
  - 地域(リージョン): East US
  - リソースグループ: 作成済みの ResourceGroup1 を選択
  - 名前: kv902387423 など適当に
  - リソース名をコピー
- サービスプリンシパルを作成
  - `az login`
  - `az ad sp create-for-rbac`
- VSCodeを起動
- リポジトリをクローン
  - https://github.com/MicrosoftLearning/AI-102-AIEngineer
- ファイル内の文字列を置換
  - YOUR_COGNITIVE_SERVICES_ENDPOINT
  - →コピーしたエンドポイント
  - YOUR_COGNITIVE_SERVICES_KEY
  - →コピーしたキー
- 統合ターミナルで `01-getting-started/C-Sharp/rest-client` を開く
- `dotnet run`
- 「Hello」、「Bonjour」、「Gracias」などを入力し、対応する言語「English」「French」「Spanish」が表示されることを確認
- 統合ターミナルで `01-getting-started/C-Sharp/sdk-client` を開く
- `dotnet add package Azure.AI.TextAnalytics`
- `dotnet run`
- 「Hello」、「Bonjour」、「Gracias」などを入力し、対応する言語「English」「French」「Spanish」が表示されることを確認

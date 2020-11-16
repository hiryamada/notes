https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview


https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/tutorial-windows-vm-access-nonaad


システム割り当てマネージド ID によって、コード内に資格情報を格納せずに、Azure リソースをクラウド サービス (Azure Key Vault など) に対して認証させることができます。有効にすると、Azure ロールベースのアクセス制御を介して必要なすべてのアクセス許可を付与できます。この種類のマネージド ID のライフサイクルは、このリソースのライフサイクルに関連付けられています。また、各リソース (仮想マシンなど) は、システム割り当てマネージド ID を 1 つしか持つことができません。マネージド ID の詳細情報を表示します。

ユーザー割り当てマネージド ID によって、コード内に資格情報を格納せずに、Azure リソースをクラウド サービス (Azure Key Vault など) に対して認証させることができます。この種類のマネージド ID は、スタンドアロンの Azure リソースとして作成され、独自のライフサイクルを持ちます。単一のリソース (仮想マシンなど) は、複数のユーザー割り当てマネージド ID を利用することができます。同様に、単一のユーザー割り当てマネージド ID を複数のリソース (仮想マシンなど) で共有することができます。マネージド ID の詳細情報を表示します。

# 操作手順例（ユーザー割り当てマネージドIDの場合）

※ Key Vaultとシークレットは[事前に作っておきます](mod07-01-keyvault.md)。

- ユーザー割り当てマネージドIDを作成。
  - 検索＞「マネージド ID」）＞追加
- マネージドIDにAzureロールを割り当て
  - マネージドID＞Azureロールの割り当て＞＋ロールの割り当て、スコープ：サブスクリプション、役割：Key Vault Secret User
- VMを作成
- VMにユーザー割り当てマネージドIDを追加。
  - VM＞ID＞ユーザー割り当て済み＞追加、ユーザー割り当て済みマネージドIDを選択、追加
- VMにSSH接続
- Azure CLIをインストール
  - `curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash`
- ログインする
  - `az login --identity`
- Key Valutからシークレットを読み込む
  - `az keyvault secret show --vault-name '' --name ''`


■マネージドIDの割り当て

Azure Logic Apps でマネージド ID を使用して Azure リソースへのアクセスを認証する
https://docs.microsoft.com/ja-jp/azure/logic-apps/create-managed-service-identity


ロジック アプリ ワークフローの一部のトリガーとアクションは、Azure Active Directory (Azure AD) によって保護されているリソースへの接続の認証にマネージド ID (旧称はマネージド サービス ID (MSI)) を使用することをサポートしています。 ロジック アプリ リソースでマネージド ID が有効化されている場合、資格情報、シークレット、または Azure AD トークンを渡す必要はありません。 この ID は Azure で管理され、認証情報が安全に保たれます。この機密情報をユーザー側で管理する必要がないからです。

Azure Logic Apps は、システム割り当てマネージド ID とユーザー割り当てマネージド ID の両方をサポートしています。

■コマンド

az logic

az logicapp create

az group create -n testrg -l japaneast
az storage account create -g testrg -l japaneast -n test92374124
az logicapp create -g testrg -n testlogicapp1345235 -s test92374124 -c japaneast

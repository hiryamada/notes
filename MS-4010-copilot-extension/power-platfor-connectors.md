# Microsoft Power Platformのコネクタ connectors

https://learn.microsoft.com/en-us/microsoft-copilot-studio/advanced-connectors

https://learn.microsoft.com/en-us/connectors/connector-reference/

3種類のコネクタがある。これらは、もともと、Azure Logic Apps, Power Automate, Power Appsで使われていたもの。

- 標準コネクタ
  - すべての Copilot Studio プランに含まれている
- プレミアム コネクタ
  - 「standalone Copilot Studio subscription」で利用できる
- カスタム コネクタ
  - 既存のコネクタではカバーされていないサービスの公開 API に接続

## プレミアム コネクタを使用するためのライセンス

※Copilot studioのプランとして「Copilot Studio for Microsoft Teams plans」と「standalone Copilot Studio subscription」があり、プレミアムコネクタを使用するには後者が必要。https://learn.microsoft.com/ja-jp/microsoft-copilot-studio/requirements-licensing-subscriptions

コネクタは、コパイロット内で「コネクタ アクション」として、 会話型トピック 内の アクションの呼び出し ノードから、またアクションとしてまたはトピック内でクラウド フローを通じて呼び出すことができる。

You can call connectors as connector actions in your copilot, from the Call an action node in conversational topics, and through cloud flows as actions or within topics.

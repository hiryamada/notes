Azure API Management

API Management (APIM) は、**既存のバックエンドのサービスに対して**一貫性のある最新の API ゲートウェイを迅速に作成する手段です。

[製品ページ](https://azure.microsoft.com/ja-jp/services/api-management/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/api-management/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/api-management/api-management-key-concepts)

Microsoft Learn

- [Azure での API 統合の設計](https://docs.microsoft.com/ja-jp/learn/paths/architect-api-integration/)


[aka.ms/apimlove](https://azure.github.io/api-management-resources/)

# [「APIゲートウェイ」パターン](https://docs.microsoft.com/ja-jp/dotnet/architecture/microservices/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern)

[本家](https://microservices.io/patterns/apigateway.html)

Implement an API gateway that is the single entry point for all clients. 

The API gateway handles requests in one of two ways. Some requests are simply proxied/routed to the appropriate service. 

It handles other requests by fanning out to multiple services.

# 価格レベル

- 使用量（Consumption）
- Developer
- Basic
- Standard
- Premium
- Isolated

[Azure API Management レベルの機能に基づく比較](https://docs.microsoft.com/ja-jp/azure/api-management/api-management-features) - 価格レベルにより提供される機能が異なる。

# [バージョン](https://docs.microsoft.com/ja-jp/azure/api-management/api-management-versions)

バージョンを使用すると、関連する API のグループを開発者に示すことができます。 バージョンを使用すると API の重大な変更を安全に処理できます。 クライアントは、準備ができたら新しい API バージョンを使用することを選択できます。その一方で、既存のクライアントは以前のバージョンを引き続き使用します。 

バージョンは (ユーザーが選択する任意の文字列値である) バージョン識別子で区別されるため、バージョン管理スキームにより、クライアントは使用する API のバージョンを識別できます。

パスベース、ヘッダーベース、クエリ文字列ベースのバージョン管理を利用できます。

# [リビジョン](https://docs.microsoft.com/ja-jp/azure/api-management/api-management-revisions)

リビジョンを使用すると、制御された安全な方法で、API に変更を加えることができます。 変更を加える場合は、新しいリビジョンを作成します。 そうすれば、API のコンシューマーに影響を及ぼすことなく、API を編集してテストすることができます。 準備ができたら、そのリビジョンを現在のリビジョンにします。

API の各リビジョンには、特別な形式の URL を使用してアクセスできます。 クエリ文字列の前ではなく、対象の API の URL の末尾に ;rev={revisionNumber} を追加することで、その API の特定のリビジョンにアクセスします。 

[バージョンとリビジョンについての説明](https://azure.microsoft.com/ja-jp/blog/versions-revisions/)

# 呼び出し元の制限

- OAuth 2.0
- クライアント証明書
- 呼び出し元IPの制限
- サブスクリプションキー

# [サブスクリプション](https://docs.microsoft.com/ja-jp/azure/api-management/api-management-subscriptions)

サブスクリプションは、Azure API Management の重要な概念です。 これは、API ユーザーが API Management インスタンスを介して公開されている API へのアクセス権を取得するための最も一般的な方法です。 

API へのアクセスをセキュリティで保護する簡単で一般的な方法は、サブスクリプション キーを使用することです。

公開された API を使用する必要がある開発者は、これらの API を呼び出すときに、有効なサブスクリプション キーを HTTP 要求に含める必要があります。


Azure portal の製品の [設定] ページで [サブスクリプションを要求する] オプションをオフにすることができます。 その結果、API キーを使用せずに製品のすべての API にアクセスできるようになります。


# Ocp-Apim-Subscription-Key 

[What is OCP ?](https://stackoverflow.com/questions/52648362/what-does-the-ocp-stand-for-in-ocp-apim-subscription-key-header-azure-api-man)

Ocp-Apim-Subscription-Key には、この API に関連付けられているサブスクリプション キーの値が自動的に入力されます。

# アクセス制限ポリシー

Azure API Management (APIM) のポリシーは、発行者がその構成を通じて API の動作を変更できる、システムの強力な機能の 1 つです。 ポリシーは、API の要求または応答に対して順に実行される一連のステートメントのコレクションです。 代表的なステートメントとしては、XML 形式から JSON 形式への変換や、(開発者からの呼び出しの回数を制限する) 呼び出しレート制限が挙げられます。

# ポリシー構成

ポリシー定義は、一連の受信ステートメントと送信ステートメントが記述された単純な XML ドキュメントです。 XML は、定義ウィンドウで直接編集できます。

```
<policies>
  <inbound>
    <!-- statements to be applied to the request go here -->
  </inbound>
  <backend>
    <!-- statements to be applied before the request is forwarded to 
         the backend service go here -->
  </backend>
  <outbound>
    <!-- statements to be applied to the response go here -->
  </outbound>
  <on-error>
    <!-- statements to be applied if there is an error condition go here -->
  </on-error>
</policies> 
```

要求の処理中にエラーが発生した場合、inbound、backend、または outbound セクションの残りの手順はスキップされ、実行は on-error セクションのステートメントにジャンプします。 on-error セクションにポリシー ステートメントを配置することで、context.LastError プロパティを使用してエラーを確認し、set-body ポリシーを使用してエラーの検査とカスタマイズを行い、エラーが発生した場合の動作を構成できます。

# ポリシーの主な種類

- アクセス制限ポリシー
  - ヘッダーの確認
  - 呼び出しレートに基づく制限
  - 使用量クォータに基づく制限
  - 呼び出し元IPに基づく制限
  - JWTの検証
- 高度なポリシー
  - コンカレンシー制限
  - Event Hubsにログ記録
  - Mock response
  - 再試行（条件が満たされるまで囲まれたポリシーステートメントの実行を繰り返す）
  - 制御フロー（条件付きでポリシーを適用）
  - 要求を送信する
  - 変数を設定する
  - 状態コードを設定する
- キャッシュポリシー
- クロスドメインポリシー
- 変換ポリシー
  - JSONからXML
  - XMLからJSON
  - 本文中の文字列の置換
  - ヘッダーの設定
  - クエリ文字列パラメーターの設定



```
(in) 
-> inbound policy 
-> backend policy 
-> backend 
-> outbound policy 
-> (out)
```

# [ポリシーの式](https://docs.microsoft.com/ja-jp/azure/api-management/api-management-policy-expressions)

単一ステートメントの式: `@(expression)`

複数ステートメントの式: `@{expressions... return ...;}`

# rate-limit - 呼び出しレートをサブスクリプション別に制限

429 Too Many Requests

# rate-limit-by-key - 呼び出しレートをキー別に制限

429 Too Many Requests

# quota - 使用量のクォータをサブスクリプション別に設定

# quota-by-key - 使用量のクォータをキー別に設定

403 Forbidden

# マイクロサービス用の API の設計

https://docs.microsoft.com/ja-jp/azure/architecture/microservices/design/api-design

■RESTful APIの設計

- [Microsoft REST API Guidelinesが公開されている。](https://github.com/Microsoft/api-guidelines)
  - マイクロソフトが社内で使用しているAPI設計ガイドライン
  - 例: [HTTPの動詞をどのように使うか、成功時のステータスコードに何を使うか、URLとしてどのようなパターンを使用すべきか](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md)などが定められている
    - 抜粋:
      - PUT: リソース（全体）の作成
      - POST: リソースの作成（IDはサービスによりセットされる）/任意のアクション
      - GET: リソースの読み取り
      - DELETE: リソースの削除

■べき等（冪等、べきとう）操作

- [ある操作を1回実行しても複数回実行しても同じ結果になること](https://ja.wikipedia.org/wiki/%E5%86%AA%E7%AD%89)
  - たとえば絶対値を求めるabs(x)は、何度適用しても同じ。
    - abs(x) == abs(abs(x)) == abs(abs(abs(x))) = ...
- べき等な操作
  - 最初の呼び出しの後に複数回呼び出しても副次的な影響が生じない
  - HTTP 仕様では、GET、PUT、DELETE メソッドはべき等である必要があると規定されている
- なぜ「べき等」が重要なのか？
  - REST API(マイクロサービス): 
    - [リトライ処理が行われる可能性があるため](https://aws.amazon.com/jp/builders-flash/202104/serverless-idempotency/)
  - 構成管理ソフトウェア
    - [複数回の処理で環境を壊さないようにするため](https://www.intellilink.co.jp/article/column/devops02.html)


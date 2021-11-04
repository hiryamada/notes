# マイクロサービス用の API の設計

https://docs.microsoft.com/ja-jp/azure/architecture/microservices/design/api-design

■RESTful APIの設計

■べき等（冪等、べきとう）操作


- べき等な操作
  - 最初の呼び出しの後に複数回呼び出しても副次的な影響が生じない
  - HTTP 仕様では、GET、PUT、DELETE メソッドはべき等である必要があると規定されている
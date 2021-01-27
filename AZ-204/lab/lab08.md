ラボ8

注意：API Management サービスの作成には40分ほどかかります。事前に作成しておきます。下記の「演習（エクササイズ）2」を参考にしてください。

# httpbinについて
https://httpbin.org/headers にアクセスしてください。JSONが表示されることを確認します。これは、実際にWebブラウザがWebサーバーに送信したHTTPヘッダーがJSON化されて出力されたものです。

https://httpbin.org/xml にアクセスしてください。適当なXMLが表示されることを確認します。

つまり、この「httpbin.org」は、テスト用のレスポンス（XML等）を生成したり、リクエストのヘッダー情報を確認したりすることができるサービスです。

タスク2では、これと同じサービスを、App Serviceにデプロイします。


# 演習（エクササイズ）1:

タスク3 の 1～4 - 作成したApp Service Web App を開き、「概要」の「参照」をクリックします。

タスク3 の 5 の a. ～ f. - Response formats をクリックします。「Get /xml」をクリックします。画面右側の「Try it out」をクリックします。Execute をクリックします。Response bodyに適当なXMLが表示されることを確認します。

# 演習（エクササイズ）2:

タスク1 の 1～5 - 画面上部の検索ボックスに「apim」と入力して、「API Management サービス」をクリックし、画面左上の「＋ 作成」をクリックしてください。

タスク1 の 6.f - 「Administrator email」に、自分のメールアドレスを入力してください。

タスク1 の 6.g - Pricing tier で、Comsumption (99.95% SLA) を選択してください。




# DALL-E playground

DALL-E（ダリ）

OpenAI、「DALL-E 3」を発表 ～「ChatGPT」に統合、プロンプトに忠実な画像を生成(9/21)
https://news.yahoo.co.jp/articles/e64a7e03872b48449e9c7bc71908bb2a68ddc53c
10月上旬には「ChatGPT Plus」と「ChatGPT Enterprise」のユーザーに提供されるとのこと。


プレイグラウンド playground: （遊具などが置いてある）遊び場。IT用語としては、開発者がAPIなどを試用できるツール。

画像生成 API（DALL-E モデル） は、ユーザーが提供するテキスト プロンプトから画像を作成します。
現在プレビュー段階
既存の画像を編集したり、バリエーションを作成したりすることはありません。

モデルID: dalle2
リージョン: East USのみ（現在）
最大要求数: 1000文字

モデルのデプロイは不要

DALL-Eプレイグランドを開く
モデルのデプロイは不要
左上のView codeでは、一般的なDALL-Eのサンプルコードが表示される

Promptにテキストを入力して「Generate」をクリック。

画像が生成される。

生成した画像をクリックすると拡大表示される。

生成した画像のボタン
- Copy prompt: プロンプトをコピー
- Generate new image: 同じプロンプトから別の画像を再生成
- Download: 画像をダウンロード
- Show code: その画像のプロンプトが埋め込まれたDALL-Eのサンプルコードが表示される
- Delete: 画像を削除


Settingsでは、
一度に生成する画像の数を1から3の間で指定できる。
画像サイズを1024x1024、512x512、256x256の3種類で変更できる。
この設定は、DALL-Eプレイグランドから別の画面へ移動するとリセットされる。

Searchでは、過去に入力したプロンプトを検索できる。

Tile Size: アイコンのサイズ。Small tiles / Medium tiles / Large tiles の3種類の切り替えが可能。


コード生成は、現在のプレイグランドでは、JSONとPythonしか表示されないが、SDKはC#/Java/JavaScript/Go/Pythonに対応。PowerShellなどその他の言語ではAPIを利用することも可能。
https://learn.microsoft.com/ja-jp/azure/ai-services/openai/dall-e-quickstart?tabs=command-line&pivots=programming-language-csharp


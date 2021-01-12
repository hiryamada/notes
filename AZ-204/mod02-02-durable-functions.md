# Durable Functions

[Durable Functions](https://docs.microsoft.com/ja-jp/azure/azure-functions/durable/durable-functions-overview) は、サーバーレス コンピューティング環境でステートフル関数を記述できる Azure Functions の拡張機能です。 

オーケストレーター関数から、複数の関数を呼び出すことができます。

それぞれの関数を非同期で扱うことができる。Func1が終わったらFunc2を呼び出す、といったことができる（チェーン）。そこを制御するのがオーケストレーター。

# 構成例：チェーン

# 構成例：ファンアウト

複数の関数を並行で呼び出して、全部の関数の終了を待つ、ということができる。

# 構成例：監視

タイマーを設定してスリープ

スリープ中はコストが発生しない

CreateTimer

# 構成例：人間相互作用

途中で人間が承認を挟むようなパターン


# Durable Functions

[解説PDF](pdf/mod02/durable-function.pdf)

[Durable Functions](https://docs.microsoft.com/ja-jp/azure/azure-functions/durable/durable-functions-overview) は、サーバーレス コンピューティング環境でステートフル関数を記述できる Azure Functions の拡張機能。 

オーケストレーター関数から、複数の関数を呼び出すことができる。

それぞれの関数を非同期で扱うことができる。Func1が終わったらFunc2を呼び出す、といったことができる（チェーン）。

「オーケストレーター関数」が、全体のコントロールを行う。

# 構成例：チェーン

関数Aが終了したら、関数Bを開始する・・・というように、複数の関数を連続的に呼び出すことができる

# 構成例：ファンアウト

複数の関数を並行で呼び出して、全部の関数の終了を待つ、ということができる。

# 構成例：監視

タイマーを設定してスリープ

スリープ中はコストが発生しない


# 構成例：人間相互作用

関数Aと関数Bの途中で、人間が承認を挟むパターン


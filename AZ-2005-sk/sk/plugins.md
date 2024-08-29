# プラグイン

## 組み込みプラグイン

https://github.com/microsoft/semantic-kernel/tree/21507472dbfb2f82c4cee14827624e2d14dc0b39/dotnet/src/Plugins/Plugins.Core

TimePlugin, HttpPlugin, TimePlugin, FileIOPluginなど。


## プラグインの関数（メソッド）を直接呼び出す

プラグインの関数とは、属性が付与されていることをを除けば、ただのインスタンスメソッドに過ぎない。

したがって以下のように、プラグインのオブジェクトをnewして、メソッドを普通に呼び出せば動かせる。

```c#
#pragma warning disable SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

using Microsoft.SemanticKernel.Plugins.Core;

var plugin = new TimePlugin();
var now = plugin.Now();

System.Console.WriteLine(now);
```
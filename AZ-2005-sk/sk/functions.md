# 関数（functions）

~~「ネイティブ関数」~~ → メソッド関数と~~「セマンティック関数」~~ → プロンプト関数がある。

https://learn.microsoft.com/en-US/semantic-kernel/support/v1-migration-guide#convention-name-changes

## ~~「ネイティブ関数」~~ → メソッド関数

Native Function - expressed with traditional computing language (C#, Python, Typescript) and easily integrates with SK

「メソッド関数」は、C#等で書かれた関数。

## ~~「セマンティック関数」~~ → プロンプト関数

Semantic Function - expressed in natural language in a text file "skprompt.txt" using SK's Prompt Template language. 

Each semantic function is defined by a unique prompt template file, developed using modern prompt engineering techniques.

「プロンプト関数」は、自然言語で書かれたもの。

Semantic Kernelのプロンプトテンプレート言語を使用して展開される。

※つまりは、プロンプトを関数化できる。プロンプトは、入力（引数、`KernelArguments`）を受取り、LLMで処理（生成）を行い、生成された文字列を返す「関数」とも考えられる。

ソースコード内にリテラルで書かれるもの:「インラインプロンプト関数」
Inline Prompt Functions
https://jamiemaguire.net/index.php/2024/06/22/semantic-kernel-working-with-prompts/

「skprompt.txt」内に書かれるもの:「ファイルベースプロンプト関数」
File-Based Prompt Functions
https://jamiemaguire.net/index.php/2024/06/29/semantic-kernel-working-with-file-based-prompt-functions/


## 実装

関数は `KernelFunction` クラスとして表現される。

https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.kernelfunction?view=semantic-kernel-dotnet

カーネルは `Task<TResult?> InvokeAsync(KernelFunction, KernelArguments, CancellationToken)` メソッドを持つ。これを使用して `KernelFunction` を呼び出せる。

https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.kernel.invokeasync?view=semantic-kernel-dotnet#microsoft-semantickernel-kernel-invokeasync-1(microsoft-semantickernel-kernelfunction-microsoft-semantickernel-kernelarguments-system-threading-cancellationtoken)

関数に対する引数は `KernelArguments` として表現される。

https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.kernelarguments?view=semantic-kernel-dotnet



## プロンプトからの関数/プラグイン作成

`KernelExtensions.CreateFunctionFromPrompt()` https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.kernelextensions.createfunctionfromprompt?view=semantic-kernel-dotnet

※オーバーロードされたうちの1つ

```c#
public static Microsoft.SemanticKernel.KernelFunction CreateFunctionFromPrompt (
    this Microsoft.SemanticKernel.Kernel kernel, 
    string promptTemplate, 
    Microsoft.SemanticKernel.PromptExecutionSettings? executionSettings = default, 
    string? functionName = default, 
    string? description = default, 
    string? templateFormat = default, 
    Microsoft.SemanticKernel.IPromptTemplateFactory? promptTemplateFactory = default);
```

`KernelExtensions.ImportPluginFromPromptDirectory()` https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.kernelextensions.importpluginfrompromptdirectory?view=semantic-kernel-dotnet

```c#
public static Microsoft.SemanticKernel.KernelPlugin ImportPluginFromPromptDirectory (
    this Microsoft.SemanticKernel.Kernel kernel, 
    string pluginDirectory, 
    string? pluginName = default, 
    Microsoft.SemanticKernel.IPromptTemplateFactory? promptTemplateFactory = default);
```

# テンプレート

## サポートされているテンプレート言語

https://learn.microsoft.com/en-us/semantic-kernel/get-started/supported-languages#prompt-template-formats

- Semantic Kernel template language
- Handlebars
- Liquid (C#のみ)
- Jinja2 (Pythonのみ)

## デフォルトのテンプレートエンジン

デフォルトのテンプレートエンジンは `BasicPromptTemplateEngine`である
https://github.com/microsoft/semantic-kernel/blob/main/docs/decisions/0016-custom-prompt-template-formats.md

と、資料には書かれているが、現在そのようなクラスはない模様。 `Microsoft.SemanticKernel.TemplateEngine` 名前空間があり、そこに以下のような基本的なトークナイザが用意されている。

https://github.com/microsoft/semantic-kernel/blob/main/dotnet/src/SemanticKernel.Core/TemplateEngine/TemplateTokenizer.cs

Handlebarsと同様に ``{{ ... }}`` で囲まれた変数、値、関数呼び出しを認識する。ただし配列の展開や変数のセットといった複雑な仕組みは持っていない。

## Handlebars テンプレートエンジン

Microsoft.SemanticKernel.PromptTemplates.Handlebars Namespace
https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.prompttemplates.handlebars?view=semantic-kernel-dotnet

動作:

- GPTにプランの作成を依頼する。具体的には、Handlebarsテンプレートの組み立てを依頼するプロンプトが送信される。使用可能なプラグインの関数などの情報も渡される。
- GPTがHandlebarsテンプレートを返す。
- ローカルでそのテンプレートをHandlebarsエンジンで実行する。テンプレートの中ではプラグインの呼び出しが行われ、結果はHandlebarsの変数に記録されていく。また別のプラグインの呼び出しの際に、記録された変数が引数として利用される。最後のプラグイン関数を実行したら、その結果をJSONで表示（出力）する。

## Liquid テンプレートエンジン

Liquid is an open-source template language created by Shopify and written in Ruby.
https://shopify.github.io/liquid/

Fluid is an open-source .NET template engine based on the Liquid template language.
https://github.com/sebastienros/fluid

Liquidテンプレートエンジンは、この問題に対する強力で柔軟なソリューションを提供し、開発者が制御フロー、反復、および変数補間を備えた動的テンプレートを作成できるようにします。
https://github.com/microsoft/semantic-kernel/issues/344

Microsoft.SemanticKernel.PromptTemplates.Liquid Namespace
https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.prompttemplates.liquid?view=semantic-kernel-dotnet


## プロンプトテンプレート

https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.prompttemplateconfig?view=semantic-kernel-dotnet

A prompt template is a template that can be used to generate a prompt to be submitted to an AI service.

プロンプトテンプレートは、プロンプトを生成するのに使用されるテンプレートである。

※プロンプト内に `{{NNN}}` といった記述がある場合、それは変数の埋め込みであったりプラグインの呼び出しの埋め込みであったりテンプレート言語の組み込み関数の呼び出しであったりするため、テンプレートエンジンを使用してそこに値を埋め込んだり展開したりする必要がある。

```
プロンプトテンプレート
↓
プロンプト
↓
（AI）
```

## インターフェース/クラス等

`IPromptTemplateFactory` インターフェース:

`bool TryCreate(PromptTemplateConfig, IPromptTemplate)` ... Creates an instance of `IPromptTemplate` from a PromptTemplateConfig.

`IPromptTemplate` インターフェース:

`Task<string> RenderAsync(Kernel, KernelArguments)` ... Renders the template using the supplied kernel and arguments.

`PromptTemplateConfig` クラス ... プロンプトテンプレートの作成に必要な構成情報を提供

## 詳しい解説

https://github.com/microsoft/semantic-kernel/blob/main/docs/decisions/0016-custom-prompt-template-formats.md


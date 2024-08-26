# いろいろな変更点

https://learn.microsoft.com/en-US/semantic-kernel/support/v1-migration-guide#convention-name-changes

## `SKFunction` → `SemanticKernel`

https://github.com/microsoft/semantic-kernel/issues/4511

## スキル → プラグイン

https://devblogs.microsoft.com/semantic-kernel/skills-to-plugins-fully-embracing-the-openai-plugin-spec-in-semantic-kernel/
「スキル」の名前をプラグインに変更する

https://qiita.com/nohanaga/items/3c9446375491f46e4aae
Semantic Kernel で「スキル」と呼んでいた機能は「プラグイン」へ改名となります。その心は、Semantic Kernel でこれまで作成したセマンティック関数やネイティブ関数の集合であるスキルを Copilot stack における「プラグイン」としてエコシステムに柔軟に統合できるというビジョンに基づいています。

https://gooner.hateblo.jp/entry/2023/07/04/121253
Copilot stack との連携強化に伴い、Semantic Kernel で「スキル」と呼んでいた機能は「プラグイン」へリネームされています。

## 「プラン」(planning) → 「関数呼び出し」(function calling)

※現状、プランが完全になくなったわけではないが、Stepwise プランナーと Handlebars プランナーはどちらも、Semantic Kernel の将来のリリースで非推奨になる！

https://learn.microsoft.com/en-us/semantic-kernel/concepts/planning?pivots=programming-language-csharp

セマンティックカーネルは、プロンプトを使用してAIに呼び出す関数を選択するように要求するプランナーの概念を早い段階で導入しました。

しかし、セマンティックカーネルが導入されて以来、OpenAIはモデルが関数を呼び出すネイティブな方法、つまり関数呼び出しを導入しました。

その後、Gemini、Claude、Mistral などの他の AI モデルでは、関数呼び出しがコア機能として採用され、クロスモデルをサポートする機能となっています。

これらの進歩により、セマンティックカーネルは、タスクを計画および実行するための主要な方法として関数呼び出しを使用するように進化しました。

https://learn.microsoft.com/en-us/semantic-kernel/concepts/planning?pivots=programming-language-csharp#what-about-the-function-calling-stepwise-and-handlebars-planners

Stepwise プランナーと Handlebars プランナーは、セマンティック カーネルで引き続き使用できます。

ただし、ほとんどのタスクでは関数呼び出しを使用することをお勧めします。これは、より強力で使いやすいためです。Stepwise プランナーと Handlebars プランナーはどちらも、Semantic Kernel の将来のリリースで非推奨になります。

## `IFunctionFilter` -> `IFunctionInvocationFilter` , `IPromptFilter` -> `IPromptRenderFilter`

https://devblogs.microsoft.com/semantic-kernel/filters-in-semantic-kernel/

■m1

カーネルのビルド

インラインプロンプト
var result = InvokePromptAsync(prompt)

■m2

組み込みプラグインの使い方

プロンプトでのテンプレート言語の使用
var history = "..."
var prompt = "... {{$history}}"
var result = InvokePromptAsync(prompt, {{"history": history}})

ペルソナの設定（システムメッセージ/XMLで設定）※現在SKのドキュメントからは削除されている

ChatHistory chatHistory = new("You are a technical support specialist ...");

セマンティックプラグインの例(1)

Prompts/SuggestChords/skprompt.txt ... プロンプト（XML形式でシステム、ユーザー、アシスタントなど）
Prompts/SuggestChords/config.json ... パラメータや引数の定義（JSON）

var plugins = kernel.CreatePluginFromPromptDirectory("Prompts");
var result = kernel.InvokeAsync(plugins["SuggestChords"], new() {{"startingChords", input}})

セマンティックプラグインの例(2)

Prompts/ChordProgressions/SuggestChords/skprompt.txt
Prompts/ChordProgressions/SuggestChords/config.json

var chordProgressionPlugin = kernel.CreatePluginFromPromptDirectory("Prompts/ChordProgressions)
var result = kernel.InvokeAsync(chordProgressionPlugin["SuggestChords"], new() {{"startingChords", input}})

※kernel.ImportPlugin...というメソッドもあり、こちらはプラグインを作成するだけではなくカーネルの「プラグインコレクション」にプラグインをインポートする。

■m3

ネイティブ関数
[KernelFunction, Description("Convert an amount of currency to USD")]
public static string ConvertCurrency(
  [Description("The currency")] string currency, 
  [Description("The amount")] double amount)
{
  // Code to convert currency
}

kernel.ImportPluginFromType<TodoListPlugin>();

var result = await kernel.InvokeAsync<string>(
  "TodoListPlugin", 
  "CompleteTask", 
  new() {{ "task", "Buy groceries" }}
);

■m4

プロンプトの中で関数を呼び出す


string prompt = @"User information: {{ConversationSummaryPlugin.SummarizeConversation $history}}"


■m5

関数の自動呼び出し（function calling）
OpenAIPromptExecutionSettings settings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

■m6

通貨の換算を行うネイティブ関数を作る

GetTargetCurrenciesプラグイン
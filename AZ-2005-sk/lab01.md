

https://github.com/MicrosoftLearning/AZ-2005-Develop-AI-agents-OpenAI-Semantic-Kernel-SDK/blob/master/Allfiles/Labs/01/Lab-01-Starter.zip


## 備考

ラボでは `SemanticKernel 1.2.0-preview` といった古いバージョンを使用している。これは 2024/1/24 頃にリリースされたもの。

<a href="https://github.com/microsoft/semantic-kernel/releases/tag/dotnet-1.2.0">Release dotnet-1.2.0 · microsoft/semantic-kernel · GitHub</a>

## Exercise 1

AOAIリソースを作成

キー・エンドポイントをコピー

gpt-35-turbo-16k をデプロイ

デプロイ名をコピー

```
az login

```

## Exercise 2

Plugins/MusicLibraryPlugin.cs を作成

```c#
var kernel = builder.Build();
kernel.ImportPluginFromType<MusicLibraryPlugin>();

var result = await kernel.InvokeAsync(
    "MusicLibraryPlugin", 
    "AddToRecentlyPlayed", 
    new() {
        ["artist"] = "Tiara", 
        ["song"] = "Danse", 
        ["genre"] = "French pop, electropop, pop"
    }
);
```

といった感じで `InvokeAsync` で直接呼び出してテスト。

```c#
 string prompt = @"This is a list of music available to the user:    
 {{MusicLibraryPlugin.GetMusicLibrary}}     
 This is a list of music the user has recently played:    
 {{MusicLibraryPlugin.GetRecentPlays}}    
 Based on their recently played music, suggest a song from    the list to play next";
 var result = await kernel.InvokePromptAsync(prompt);Console.WriteLine(result);
```

といった感じで `{{プラグイン名.関数名}}` で、プロンプトの中から呼び出してテスト。

`Prompts/SuggestConcert` フォルダを作り、その中に `config.json` と `skprompt.txt` を作成。

## Exercise 3

Handlebars プラン


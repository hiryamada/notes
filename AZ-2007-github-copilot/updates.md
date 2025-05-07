# GitHub Copilots関連のアップデート情報


## (2021頃？～)GitHub Next

https://githubnext.com/
https://thinkit.co.jp/article/37929
GitHub Nextチームは、GitHubの中でCopilotを最初期から使っているエンジニアチームであり、Copilotを使ってCopilotそのものを作るという経験を常に行っているエンジニア達の集まり
GitHub Nextが約20名のリサーチャーとエンジニアのグループ
GitHubの中では小さな組織
このチームの目的はソフトウェア開発の未来を調査し、それを実際に実験として形にすること
https://dev.classmethod.jp/articles/what-is-github-next/
GitHub Copilotは、GitHub Nextの推進するプロジェクトのうちの1つ（にすぎない）。
GitHub Nextでは、GitHubによる次世代の開発エクスペリエンスを実現するために、現在次の16のプロジェクトを提供中または提供予定

https://learn.microsoft.com/en-us/shows/vs-code-day-2023/whats-new-with-github-next
https://www.tech-street.jp/entry/2023/07/13/174226#GitHub-Copilot-X

## 2021/6/29 GitHub Copilot テクニカルプレビューを発表

https://github.blog/news-insights/product-news/introducing-github-copilot-ai-pair-programmer/

Visual Studio Code開発環境でのGitHub Copilotのテクニカルプレビューを発表
AIペアプログラマー
コードを提案
コメントを書くと続きのコードを書く、など。
powered by OpenAI Codex

## 2022/6/21 GitHub Copilotを正式リリース

https://github.blog/news-insights/product-news/github-copilot-is-generally-available-to-all-developers/

https://github.blog/jp/2022-06-22-github-copilot-is-generally-available-to-all-developers/
個人開発者向け有償サブスクリプション一般提供開始

## 2022/8/11 GitHub Codespaces が一般提供開始
https://qiita.com/uikou/items/1feb83865f9d638807ad

※GitHub Codespacesの中でもGitHub Copilotが利用できる。


## 2023/2/?? GitHub Copilot Labs

https://techcommunity.microsoft.com/blog/educatordeveloperblog/how-to-use-github-copilot-labs-to-improve-your-code-quality-and-productivity/3743021

※現在は廃止されている

## 2023/2/14 GitHub Copilot for Business を発表
https://forest.watch.impress.co.jp/docs/news/1478891.html
https://learn.microsoft.com/ja-jp/training/modules/introduction-to-github-copilot-for-business/

## 2023/3 OpenAI Codexが非推奨に。

GitHub Copilotは「Sahara-base」と呼ばれるモデルを使用。

## 2023/3/22 GitHub Copilot X（GitHubの新しいビジョン）を発表
https://dev.classmethod.jp/articles/github-copilot-x-and-github-next-waitlist/
https://github.blog/news-insights/product-news/github-copilot-x-the-ai-powered-developer-experience/
・GitHub Copilot chat ... チャットで生成・修正を指示したり、コードの説明やエラーの原因を解説させることが可能に。
・GitHub Copilot for docs https://githubnext.com/projects/copilot-for-docs ドキュメントに対する質問
・GitHub Copilot for pull requests ... GitHub Copilotをプルリクエストに組み込む
・GitHub Copilot for CLI ... ターミナルでGitHub Copilotを利用
・GitHub Copilot Voice ... GitHub Copilotを音声で操作

※まだこの時点では複数ファイルの同時編集はできなかった。


## 2023/07/21 GitHub Copilot Chat がパブリックベータとして提供開始

https://dev.classmethod.jp/articles/github-copilot-chat-beta-launch/

GitHub Copilot for Business ユーザーによるプレビュー利用が可能に。

モデルはgpt-3.5-turboを使用。

## 2023/9/21 GitHub Copilot Chatを個人ユーザーにも提供開始すると発表

https://www.publickey1.jp/blog/23/githubgithub_copilot_chat.html

## 2023/11/9 GitHub Universe 2023

https://github.blog/jp/2023-11-09-universe-2023-copilot-transforms-github-into-the-ai-powered-developer-platform/

- GitHubモバイルアプリに対してもGitHub Copilot Chatが統合
- Code scanning autofix プレビュー開始
- GitHub.comへのGitHub Copilot Chatの統合
- GitHub Copilot にスラッシュコマンドとコンテキスト変数を導入。コードの修正や改良は /fix 、テストの生成は /tests https://devblogs.microsoft.com/visualstudio/copilot-chat-slash-commands-and-context-variables/
- GitHub Copilot Enterprise プランを発表

## 2023/11/10 GitHub Copilotの将来像「Copilot Workspace」 を発表

自然言語で書かれたIssue（課題）を基に、Copilotが仕様案と実装計画を示し、コーディングや既存のコードの修正を行い、ビルドをしてエラーがあればデバッグも行うという、プログラミングのほとんど全ての工程をCopilotが自動的に実行してくれる
プルリクエストを作ってくれる
2024リリース予定とされた
https://www.publickey1.jp/blog/23/githubcopilotcopilot_workspacecopilotcopilotgithub_universe_2023.html


## 2023/11/30 「エージェント」を導入

https://github.blog/changelog/2023-11-30-github-copilot-november-30th-update/#introducing-agents-in-copilot-chat-in-vs-code
@workspace: This agent has knowledge about the code in your workspace and can help you navigate it by finding relevant files or classes. 
The @workspace agent uses a meta prompt to determine what information to collect from the workspace to help answer your question.

@vscode: This agent is knowledgeable about commands and features in the VS Code editor itself, and can assist you in using them.

※現在はエージェントではなく「Chat participant」(チャット参加者)と呼ばれている。
https://zenn.dev/yuma_prog/articles/vscode-chat-extension

## 2023/12/15 Technical Previewで発表された機能のいくつかを終了（利用できなくなった）
https://gist.github.com/idan/325676d192b32f169b032fde2d866c2c#github-next--technical-preview-sunsets
Copilot for PRs
Copilot for Docs
Copilot Labs
Blocks

## 2023/12/29 GitHub Copilot Chat を一般提供開始

https://github.blog/news-insights/product-news/github-copilot-chat-now-generally-available-for-organizations-and-individuals/

Visual Studio Code と Visual Studioで利用可能に。
モデルはgpt-4を使用。

## 2024/1/19 GitHub Copilot Chat、組織と個人向けに一般提供(GA)開始
https://github.blog/jp/2024-01-09-github-copilot-chat-now-generally-available-for-organizations-and-individuals/


## 2024/2/22 VSCodeで音声操作が可能に。「Hey Code」
https://www.publickey1.jp/blog/24/vscodehey_codecopilot_chat20241.html
この音声認識機能は、設定「accessibility.voice.keywordActivation」を有効にし、拡張機能の「VS Code Speech」と「GitHub Copilot Chat」を導入することで利用可能になります。

## 2024/2/29 エディターで音声入力（ディクテーション）がサポート
https://forest.watch.impress.co.jp/docs/news/1572582.html
［Ctrl］＋［Alt］＋［V］キーを押すことで声によるテキスト入力が行えるようになった。ディクテーションの中止は［Esc］キーで可能。

※音声入力はCopilotだけではなくエディタでの文章の入力でも利用できる。

## 2024/3/4 GitHub Copilot Enterpriseの一般提供を開始
https://github.blog/jp/2024-03-04-github-copilot-enterprise-is-now-generally-available/
https://www.publickey1.jp/blog/24/githubcopilot_enterprise.html
外部に公開されていない社内のコードやドキュメント、プルリクエストなどを追加でCopilotに学習させることで、社内のコードベースに基づいたCopilotによるコードの生成や、Copilot Chatでの質問に対する回答が可能になる

## 2024/4/30 GitHub Copilotの将来像「Copilot Workspace」のテクニカルプレビューを開始
https://github.blog/jp/2024-04-30-github-copilot-workspace/

https://www.publickey1.jp/blog/24/githubcopilot_workspaceai.html
https://github.blog/jp/2024-04-30-github-copilot-workspace/
開発者がソフトウェア構築への参入する障壁を大幅に引き下げる

https://dev.classmethod.jp/articles/github-copilot-workspace-tech-preview/
https://aadojo.alterbooth.com/entry/2024/05/13/090000
https://zenn.dev/headwaters/articles/36294cbd04c721

## 2024/5/10 GitHub Copilot ChatがGitHub Mobileで一般利用開始
https://news.mynavi.jp/techplus/article/20240510-2942316/

## 2024/8/15 コードの脆弱性を自動的に見つけてCopilotが修正案まで示す「Copilot Autofix」正式サービスに
https://www.publickey1.jp/blog/24/githubcopilotcopilot_autofix.html

https://docs.github.com/ja/code-security/code-scanning/managing-code-scanning-alerts/responsible-use-autofix-code-scanning

GitHub Copilot Autofix の使用には、GitHub Copilot のサブスクリプションは不要です。
Copilot Autofix は、GitHub.com のすべてのパブリック リポジトリと、GitHub Advanced Security のライセンスを持つ GitHub Enterprise Cloud Enterprise のプライベート リポジトリで使用できます。

## 2024/9/20 GitHub CopilotとGitHub ModelsでOpenAI o1のプレビュー開始
https://github.blog/jp/2024-09-20-try-out-openai-o1-in-github-copilot-and-models/

## 2024/9/18 GitHub Copilot Extensions公開ベータ開始:GitHub Copilotエコシステムを強化
https://github.blog/jp/2024-09-18-enhancing-the-github-copilot-ecosystem-with-copilot-extensions-now-in-public-beta/

## 2024/9/12 GitHub Copilot Enterpriseの限定公開ベータでモデルのファインチューニングが可能に
https://github.blog/jp/2024-09-12-fine-tuned-models-are-now-in-limited-public-beta-for-github-copilot-enterprise/

## 2024/10/1 GitHub CopilotとMicrosoft Azure AIでコード参照機能を一般提供開始
https://github.blog/jp/2024-10-01-code-referencing-now-generally-available-in-github-copilot-and-with-microsoft-azure-ai/

開発者は、一致するコードを含む提案をブロックするか、一致するコードに関する情報を含む提案を許可するかを選択できるようになりました。
この機能は現在 VS Code で利用可能で、近々より広く利用できるようになる予定です。
これまでも、GitHub Copilot が公開コードに一致する提案を作成しないように、ユーザーが適用できるフィルターを用意していました。
これからは、GitHub Copilotが公開コードに一致する150文字以上の提案を作成した場合、見つかった一致、コードが見つかったリポジトリ、検出されたライセンスの可能性について通知されます。

## 2024/10/30 「GitHub Spark」の テクニカルプレビューを発表
https://www.publickey1.jp/blog/24/githubgithub_spark.html
小規模なアプリを自然言語による指示で生成できる

## 2024/10/31 「GitHub Copilot in Windows Terminal」のプレビューを発表
https://forest.watch.impress.co.jp/docs/news/1635741.html


## 2024/11/6 Copilot Edits プレビュー開始

VSCode version 1.95において利用可能に。
複数のファイルにまたがるようなコードの変更や生成に対応。
https://www.publickey1.jp/blog/24/vscodecopilot_editsgithub_copilot.html

## 2024/11/12 AnthropicのClaude 3.5 Sonnet、GoogleのGemini 1.5 Pro、OpenAIのo1-preview, o1-mini がGitHub Copilotで利用可能に
https://github.blog/jp/2024-11-12-bringing-developer-choice-to-copilot/
https://zenn.dev/galirage/articles/github_universe_2024

## 2024/11/14 Gemini モデルが GitHub Copilot で利用可能に
https://cloud.google.com/blog/ja/products/ai-machine-learning/gemini-models-on-github-copilot


## 2024/11/25 GitHub Copilot for Azure プレビュー
https://www.publickey1.jp/blog/24/vscodecopilotazuregithub_copilot_for_azure.html

VSCodeの拡張機能として、Microsoft Azureに関するさまざまな質問についてGitHub Copilotが答えてくれる

## 2024/12/2 GitHub Copilot Variable Analysis (Visual Studio)
https://devblogs.microsoft.com/visualstudio/ai-powered-insights-streamlining-variable-analysis-with-github-copilot-in-visual-studio/

https://thenote.app/note?id=CdXz5zHNQW_GwSRsJNZIr
コード内のエラーや予期せぬ値をトラブルシューティングするために無限の時間を費やしていることに疲れたでしょうか。 Visual Studio 2022 では、GitHub Copilot Variable Analysis を導入しました。この強力なツールにより、ローカル変数、自動変数、ウォッチウィンドウ、データチップから変数を検査および分析することが容易になり、問題をより迅速に解決し、時間とストレスを削減することができます。

## 2024/12/19「GitHub Copilot Free」プランを発表し、Viusal Studio Code（以下VSCode）で利用可能に
https://www.publickey1.jp/blog/24/vscodegithub_copilot_freeclaude_35_sonnetgpt-4o1200050.html


## 2025/1/23 全てのVisual Studioユーザーが無料版「GitHub Copilot」を利用可能に
https://atmarkit.itmedia.co.jp/ait/articles/2502/14/news059.html

## 2025/2/6 Copilot NES（Next Edit Suggestions） プレビュー
https://github.blog/changelog/2025-02-06-next-edit-suggestions-agent-mode-and-prompts-files-for-github-copilot-in-vs-code-january-release-v0-24/

https://forest.watch.impress.co.jp/docs/news/1661141.html

## 2025/2/6 Copilot Edits 一般提供開始
https://github.blog/jp/2025-02-07-github-copilot-the-agent-awakens/

https://github.blog/news-insights/product-news/github-copilot-the-agent-awakens/

## 2025/2/6 GitHub Copilot agemt modeのプレビューを開始
https://github.blog/changelog/2025-02-06-next-edit-suggestions-agent-mode-and-prompts-files-for-github-copilot-in-vs-code-january-release-v0-24/

https://github.blog/news-insights/product-news/github-copilot-the-agent-awakens/
VSCodeで利用できる

## 2025/2/14 GitHub Copilot for Eclipse パブリックプレビュー
https://www.publickey1.jp/blog/25/copilot_for_eclipse.html

## GitHub Copilot for Xcode パブリックプレビュー
https://www.publickey1.jp/blog/24/github_copilotapplexcodegithub_copilot_for_xcode.html

Appleが提供する開発環境であるXcode上で生成AIによるコード補完やコード生成などを可能にする「GitHub Copilot for Xcode」のパブリックプレビューを発表しました。

## 2025/2/3 OpenAIの最新推論モデル「o3-mini」が「GitHub Copilot」などで利用可能に

https://forest.watch.impress.co.jp/docs/news/1659601.html
「o1-mini」とほぼ同じレイテンシで品質が向上
「OpenAI o3-mini」は、昨年末に発表された同社の最新鋭推論モデル「o3」の軽量版。従来の「o1-mini」に匹敵する応答時間を誇る一方で、コーディングベンチマークでは「o1」を上回る。つまり、ほぼ同じレイテンシでありながら品質の向上が期待できる。
「GitHub Copilot」のPro、Business、Enterpriseユーザーであれば、同日より「Visual Studio Code」のモデルピッカーと「github.com」チャットで「OpenAI o3-mini」が選べる。12時間ごとに最大50メッセージを受信可能だ。

## 参考: (Copilotに限定されない）すべてのGitHubの最新機能のプレビュー
https://github.com/features/preview
Copilot関連のプレビュー機能としては以下のものがある。このページからwaitlistに参加できる。

GitHub Workspace
Copilot-powered code review
GitHub Copilot upgrade assistant for Java
Copilot Autofix for Partners

## 参考: GitHub Extensions
https://github.com/marketplace?type=apps&copilot_app=true

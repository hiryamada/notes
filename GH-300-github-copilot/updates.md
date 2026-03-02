## VS Code公式サイト内のリンクやボタンをクリックしてVS Code内でプロンプトを実行できる

Try This
https://code.visualstudio.com/docs/copilot/agents/overview

Open in VS Code
https://code.visualstudio.com/docs/copilot/agents/agents-tutorial

## Windowsでは Python 3.14.0 以降、Python install manager を使ってPythonをインストールする。

https://atmarkit.itmedia.co.jp/ait/articles/2510/15/news018.html

## 「GitHub Copilot拡張機能」は非推奨となった

拡張機能の検索でID「GitHub.copilot」で検索すると出てくる。
代わりに「GitHub Copilot Chat 拡張機能」（ID: GitHub.copilot-chat）をインストールする。

## インストールする拡張機能はIDで指定するとよい

- `GitHub.copilot-chat`
- `ms-python.python`
- `ms-ossdata.vscode-pgsql`

## ショートカット

- `Ctrl + Shift + I`: チャットビューを開き、Agentを選択。（閉じることはできない）
- `Ctrl + Alt + B`: セカンダリサイドバーの開閉

## ツールのアイコン

- Ask、Editではツールのアイコンは表示されない。
- Agent、Planでは、ツールのアイコンが表示される。

## Planエージェントの設定ファイル

チャットビュー内の「エージェントの設定」（エージェント選択スイッチ）内で、Planの右のアイコンをクリック。

Planエージェントの定義ファイル（Plan.agent.md）が確認できる。

つまりPlanエージェントはカスタムエージェントと同様の仕組みで作られている。

## モデルの管理画面

モデルが一覧表示される。名前、コンテキスト サイズ、機能、乗数を確認できる。

「チャットモデルピッカー」で表示するかしないかを選択できる。

「＋モデルを追加...」からOllamaやAzureなどのモデルを追加できる。

## セッション一覧

https://code.visualstudio.com/docs/copilot/agents/overview#_agent-sessions-list

チャットの上部に「SESSIONS」が表示されるようになった。

セッション名をクリックすると過去のセッション（チャット履歴）にアクセスできる。

右クリック→「Show Sessions」でこれを表示・非表示にできる。

虫眼鏡アイコンでセッションを検索できる。

漏斗アイコンでセッションをフィルタリングできる。

Show Agent Sessions / Hide Agent Sessionsボタンで、セッション一覧をサイドバー（チャットのさらに右側）に表示するかどうかを切り替え。
（Compact viewとSide-by-side view）

チャットの上部に「SESSIONS」が表示されている場合（サイドバーを使っていない場合）、新しいチャットメッセージを送信するとSESSIONSは消える。

チャットを開始後チャットのタイトル左の「←」をクリックするとセッション一覧が表示される。

## Set session targetボタン（セッション関連）（Agent Type）

チャットビュー内の「エージェントの設定」（エージェント選択スイッチ）の左に、
Set session targetボタンが追加された。

- 「ローカル」... タスクをVS Code チャット内で実行（従来の動作）
- 「背景」... タスクをGitHub Copilot CLIで実行
- 「クラウド」... タスクをGitHub Copilot Coding Agentで実行
- 「Claude」...タスクをClaudeで実行

https://code.visualstudio.com/docs/copilot/agents/overview#_types-of-agents

https://code.visualstudio.com/blogs/2026/02/05/multi-agent-development

https://code.visualstudio.com/blogs/2025/11/03/unified-agent-experience

## コンテキストの追加

GitHub IssuesとGitHub Pull Requestsを指定できるようになった。

## チャットビューの「＋」ボタン

- 「新しいチャット エディター」... 新しいタブ内でチャットを起動
- 「新しいチャット ウィンドウ」 ... 新しいウィンドウ内でチャットを起動
- 「新しいCLIセッション」 ... GitHub Copilot CLI をVS Codeのタブ内で起動。
- 「New Codex Agent」 ... 「Codex – OpenAI’s coding agent」を起動

## subAgents (runSubagents)

https://code.visualstudio.com/docs/copilot/agents/subagents

メインエージェントからサブエージェントを呼び出せる

https://code.visualstudio.com/blogs/2025/11/03/unified-agent-experience#_subagents

`～.agent.md` （カスタムエージェントの定義ファイル）内では、ヘッダーの`agents: [...]` という記述で、このエージェントが使用するサブエージェントを指定できる。

## Agent hooks

https://code.visualstudio.com/docs/copilot/customization/hooks

エージェントセッションでの「UserPromptSubmit」といったイベントで、シェルコマンドを実行できるようになった


## GitHub Copilot CLIのHook

https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/use-hooks


## チェックポイント

https://code.visualstudio.com/docs/copilot/chat/chat-checkpoints

会話内の各チャットリクエストで、復元可能なチェックポイントを作る。
つまりセッション内で以前の時点に戻すことができる。

## エージェントスキル

https://code.visualstudio.com/docs/copilot/customization/agent-skills

SKILL.md ファイルに「スキル」を定義しておく。
エージェントがタスクを実行する際に使える「スキル」が発見できた場合はその「スキル」を読み込んで実行する。

カスタムインストラクションが、VS CodeとGitHub.com でしか動作しないのに対し「エージェントスキル」はより汎用的（オープンスタンダード）

Agent Skills公式
https://agentskills.io/home

## デバッグ

https://code.visualstudio.com/docs/copilot/guides/debug-with-copilot

/startDebugging

copilot-debug コマンド

## Copilot memory

https://code.visualstudio.com/updates/v1_109#_copilot-memory-preview

## Agent HQ (in VS Code)

2025/10/29 Agent HQ発表。さまざまなエージェントを単一のプラットフォームに統合。
Anthropic、OpenAI、Google、Cognition、xAIなどのコーディングエージェントがGitHub内から利用できるようになった。

https://github.blog/jp/2025-10-29-welcome-home-agents/

ミッションコントロール
https://github.blog/changelog/2025-10-28-a-mission-control-to-assign-steer-and-track-copilot-coding-agent-tasks/?utm_source=blog-day1-recap-mission-control-cta&utm_medium=blog&utm_campaign=universe25

（「Agent HQ」はコンセプト名・ビジョン名、「ミッションコントロール」はそのUIのこと、か？）

https://gihyo.jp/article/2025/11/vscode-updates-october-2025


2025/10のVS Codeでは「Agent Sessions view」というボタンが左のアクティビティバーに表示されていた

https://code.visualstudio.com/updates/v1_106

2025/12のVS Codeではこれがチャットビューに統合された。

https://code.visualstudio.com/updates/v1_108#_improvements-to-agent-sessions-view

https://gihyo.jp/article/2025/12/vscode-updates-november-2025

Visual Studio Codeは2025年12月10日、今月の更新版であるNovember 2025（バージョン1.107）をリリースした。エージェントセッション一覧がチャットビューに統合されて、バックグラウンドエージェントやクラウドエージェントとの引き継ぎが改善されるなど、VS CodeでのAgent HQの機能強化が行われた

## GitHub Copilot SDK

任意のアプリケーションにGitHub Copilotの機能を組み込むためのSDK

https://gihyo.jp/article/2026/01/github-copilot-sdk

https://github.blog/engineering/build-an-agent-into-any-app-with-the-github-copilot-sdk/

https://github.com/github/copilot-sdk

## GitHub Copilot SDKがMicrosoft Agent Frameworkに統合された

https://devblogs.microsoft.com/semantic-kernel/build-ai-agents-with-github-copilot-sdk-and-microsoft-agent-framework/

https://atmarkit.itmedia.co.jp/ait/articles/2602/25/news067.html

## GitHub Spec Kit

https://github.com/github/spec-kit

https://qiita.com/goataka/items/66ecf5f472208d6185ce

## GitHub Copilot CLI 現状確認会議

https://speakerdeck.com/torumakabe/github-copilot-cli-xian-zhuang-que-ren-hui-yi?slide=17

## メモリー

https://docs.github.com/en/copilot/how-tos/use-copilot-agents/copilot-memory

## MCPサーバーのツール以外のもの（Prompts と Resources）

https://zenn.dev/microsoft/articles/github-copilot-mcp

https://qiita.com/ipeblb/items/535709fa06cbb40c400c


## MCP Apps

https://code.visualstudio.com/blogs/2026/01/26/mcp-apps-support

対話中に直接レンダリングされるインタラクティブなUIコンポーネントを返すことが可能です:ダッシュボード、フォーム、可視化、多段階ワークフローなどです。これにより、より豊かで効果的な人間とエージェントの協働の機会が生まれます。

（Adaptive Cards https://adaptivecards.io/ に似ている）

https://modelcontextprotocol.github.io/ext-apps/api/

https://modelcontextprotocol.io/docs/extensions/apps

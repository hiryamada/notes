
■クックブック

https://docs.github.com/ja/copilot/copilot-chat-cookbook

■ベストプラクティス

https://docs.github.com/ja/copilot/using-github-copilot/best-practices-for-using-github-copilot

■カスタムインストラクション

https://docs.github.com/ja/copilot/customizing-copilot/adding-repository-custom-instructions-for-github-copilot

https://docs.github.com/ja/copilot/customizing-copilot/adding-personal-custom-instructions-for-github-copilot

個人用カスタム命令はリポジトリ カスタム命令より優先されますが、どちらも Copilot Chat に提示される最終プロンプトに組み込まれます。

■追加コンテキスト

追加コンテキスト情報は、ユーザーが作成できるオプションの .github/copilot-instructions.md ファイルからチャット プロンプトに自動的に追加できます。

■プルリクエストのテキスト補完

https://docs.github.com/en/copilot/responsible-use-of-github-copilot-features/responsible-use-of-github-copilot-text-completion



■スパークル sparkle

https://github.com/microsoft/vscode-copilot-release/issues/865

https://composeicons.com/icons/vscode-codicon/sparkle

■コミットメッセージの生成

https://github.blog/changelog/2023-11-30-github-copilot-november-30th-update/#commit-message-generation-using-copilot-in-vs-code

再度スパークリングボタンを押すと、コミットメッセージが変更されます。

日本語化
    "github.copilot.chat.commitMessageGeneration.instructions": [
        {
            "text": "Write in Japanese. Use conventional commit message format."
        }
    ]

ターミナルでも使える？
https://dev.classmethod.jp/articles/https-code-visualstudio-com-docs-editor-github-copilot/

■ターミナルでのインラインチャット

/explain

■名前変更での提案

https://zenn.dev/ma_me/articles/d5779582006ea1#%E3%83%AA%E3%83%8D%E3%83%BC%E3%83%A0%E6%8F%90%E6%A1%88%E3%83%9C%E3%82%BF%E3%83%B3%E3%81%AE%E8%BF%BD%E5%8A%A0
名前変更の提案を受け付けたいコード部分を選択し、F2ボタンを押すと、
欄の右側にスパークルアイコンが出てきます。
このアイコンを押すことで、名前変更提案を簡単にトリガーできます。

■GitHub Codespaces in Visual Studio Code

GitHub Codespaces provides cloud-hosted development environments for any activity - whether it's a long-term project, or a short-term task like reviewing a pull request.

You can connect to Codespaces from Visual Studio Code or a browser-based editor that's accessible anywhere.

https://docs.github.com/en/codespaces/developing-in-a-codespace/using-github-codespaces-in-visual-studio-code

https://marketplace.visualstudio.com/items?itemName=GitHub.codespaces

■Jupyter Notebook / Polyglot notebooks + GitHub Copilot

https://code.visualstudio.com/docs/languages/polyglot#_polyglot-notebooks

Jupyter Notebook
https://learn.microsoft.com/ja-jp/shows/github-copilot-series/using-copilot-with-jupyter-notebooks

■Markdown file を書くのにCopilotを使う

https://learn.microsoft.com/ja-jp/shows/github-copilot-series/markdown-using-copilot



■コンテキストウィンドウ 64k token window

https://github.blog/changelog/2024-12-06-copilot-chat-now-has-a-64k-context-window-with-openai-gpt-4o/

Copilot Chat on GitHub.com, GitHub Mobile, the GitHub CLI, as well as officially supported IDEs now have a 64k token window available when working with OpenAI GPT-4o. 

With this change, customers working with large files and repositories should expect improved responses from Copilot. 

This change helps Copilot retrieve more information when executing skills to provide contextually relevant responses.

コンテキストウィンドウ（Context Window）
コンテキストウィンドウとは、モデルが一度に処理できるトークン数
コンテキストウィンドウは、実質的にプロンプトに入力できる情報量ということになるが、より厳密にいうと、入力トークン、出力トークン、制御（システム）トークンすべてを含む情報量となる。

■GitHub Enterprise Server

https://docs.github.com/en/enterprise-cloud@latest/copilot/about-github-copilot/subscription-plans-for-github-copilot
Copilot is not currently available for GitHub Enterprise Server.

■Web版のVSCodeではCopilotが使用できない。拡張機能がインストールできない。

https://code.visualstudio.com/docs/editor/vscode-web#_extensions

public preview of Visual Studio Code for the Web: 2021/10/20
https://azure.microsoft.com/en-us/updates?id=public-preview-visual-studio-code-for-the-web-2

■コードブロック間の移動

チャットビューで複数のコードブロックが表示された際、以下のキーでそれらの間でカーソルを移動できる

Ctrl + Alt + PageUp
Ctrl + Alt + PageDown


# GitHub Copilot Extensions を発表 2024/5/21

https://github.blog/news-insights/product-news/introducing-github-copilot-extensions/

https://japan.zdnet.com/article/35219182/

開発者が統合開発環境（IDE）やGitHub.comを離れることなく、自然言語を用いながら好みのツールやサービスを使ってビルドし、クラウドにデプロイすることがパートナーエコシステムを通じて可能になる

@azure
@docker
など

# GitHub Copilot Extensions
https://docs.github.com/en/copilot/using-github-copilot/using-extensions-to-integrate-external-tools-with-copilot-chat#about-context-passing-in-github-copilot-extensions

GitHub Copilot Extensions are a type of GitHub App that integrates the power of external tools into GitHub Copilot Chat. 
https://github.com/marketplace/stack-overflow-extension-for-github-copilot
たとえば@askstackoverflow で、Get answers to your most complex coding questions right where you’re already working.

Copilot Extensions can be developed by anyone, for private or public use, and can be shared with others through the GitHub Marketplace.


「GitHub Copilot Extensions」は、VSCodeの拡張機能の「GitHub Copilot extension」とは別のもの。

For example, if you install the Sentry extension for GitHub Copilot, you can use the extension to get information about Sentry issues, then create and assign related tracking issues on GitHub.

https://qiita.com/MaSi1031/items/3297e99b7f838524c322

Sentryは、デベロッパーが自分のアプリケーションのエラーを追跡し、監視するためのオープンソースのエラーモニタリングプラットフォーム。

https://sentry.io/welcome/

https://github.blog/changelog/2025-02-19-announcing-the-general-availability-of-github-copilot-extensions/
GitHub Copilot Extensions are now generally available for users across all Copilot license tiers.

■GitHub Copilot Extensionsの作成

https://github.blog/changelog/2025-02-19-announcing-the-general-availability-of-github-copilot-extensions/

Builders have several ways to develop customized extensions, including:

Copilot skillsets, a faster, lightweight implementation option
Context passing, a capability that helps extensions benefit from a user’s local editor context for more tailored responses
Ready to contribute to our growing ecosystem? Get started with our Copilot Extension builder docs.

■GitHub Apps


https://zenn.dev/takamin55/articles/569875e8346948
GitHub AppsはGitHubの機能を拡張するツール
GitHubを操作したり、GitHub外と連携したりできる。例えばissueを開いたり、Slackに通知したり
リポジトリにインストールして使用する

https://github.com/marketplace?type=apps
マーケットプレースから探せる

https://docs.github.com/en/apps/using-github-apps/about-using-github-apps


# GitHub Copilot Extensions skillsets 2024/11/19

https://github.blog/changelog/2024-11-19-build-copilot-extensions-faster-with-skillsets/

Today we’re introducing skillsets, a new lightweight way to build GitHub App-based Copilot Extensions alongside our existing agents approach. 

While agents offer full control over the user interaction, skillsets make it easy to integrate external tools and services into Copilot Chat by defining simple API endpoints – no AI expertise needed!

Copilot Extension as an agent? Existing agent extensions can be converted into skillsets, but one extension cannot be both a skillset and an agent.

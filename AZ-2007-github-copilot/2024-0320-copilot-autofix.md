# code scanning autofix will be available in public beta for all GitHub Advanced Security  2024/3/20

https://github.blog/news-insights/product-news/found-means-fixed-introducing-code-scanning-autofix-powered-by-github-copilot-and-codeql/

# GitHub Copilot Autofix

https://docs.github.com/en/code-security/code-scanning/introduction-to-code-scanning/about-code-scanning

Code scanning is a feature that you use to analyze the code in a GitHub repository to find security vulnerabilities and coding errors. Any problems identified by the analysis are shown in your repository.


https://docs.github.com/en/code-security/code-scanning/managing-code-scanning-alerts/responsible-use-autofix-code-scanning

GitHub Copilot Autofix is an expansion of code scanning that provides users with targeted recommendations to help them fix code scanning alerts so they can avoid introducing new security vulnerabilities. 

You do not need a subscription to GitHub Copilot to use GitHub Copilot Autofix. Copilot Autofix is available to all public repositories on GitHub.com, as well as private repositories in GitHub Enterprise Cloud enterprises that have a license for GitHub Advanced Security.

https://github.blog/changelog/2024-10-29-copilot-autofix-now-supports-partner-code-scanning-tools/

Copilot Autofix now supports fix suggestions for problems detected by ESLint, a partner code scanning tool. Autofixes are available both in pull requests and for historical alerts.

https://eslint.org/

ESLint is an open source project that helps you find and fix problems with your JavaScript code.

ESLint statically analyzes your code to quickly find problems. It is built into most text editors and you can run ESLint as part of your continuous integration pipeline.


# 「Copilot Autofix」 2024/8/14 一般提供開始

https://github.blog/news-insights/product-news/secure-code-more-than-three-times-faster-with-copilot-autofix/

https://japan.zdnet.com/article/35222740/
GitHubは米国時間 8月14日、「Copilot Autofix」の一般提供を「GitHub Advanced Security（GHAS）」で開始したと発表した。

https://docs.github.com/en/code-security/code-scanning/managing-code-scanning-alerts/responsible-use-autofix-code-scanning#about-copilot-autofix-for-code-scanning

# Security campaigns with Copilot Autofix are now in public preview. 2024/10/29

https://github.blog/changelog/2024-10-29-security-campaigns-with-copilot-autofix-are-now-in-public-preview/

https://atmarkit.itmedia.co.jp/ait/articles/2412/05/news054.html
　2024年10月現在、セキュリティキャンペーンは主にGitHubの「CodeQL」による脆弱性スキャンとSASTの結果に焦点を当てているが、今後はGitHubの「Dependabot」によるオープンソースの脆弱性や依存関係も含むように拡張されるのではないか、とノートン氏は期待しているという。

ノートン氏の予測を裏付けるかのように、GitHubは2024年10月下旬にDependabot向けのCopilot Autofixのプライベートプレビュー版をリリースした。GitHubの変更ログによるとこの新機能によって、TypeScriptリポジトリでDependabotが作成したプルリクエストにおいて、依存関係のアップグレードが原因で発生するプログラムの動作に大きな影響を与えるような変更を、AIを使って自動的に修正できるようになったという。

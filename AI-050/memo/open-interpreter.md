# Open Interpreter

■ Open Interpreterとは？

https://github.com/KillianLucas/open-interpreter

Open Interpreter lets LLMs run code (Python, Javascript, Shell, and more) locally. You can chat with Open Interpreter through a ChatGPT-like interface in your terminal by running $ interpreter after installing.

■Azure OpenAI Serviceでも使える

`--use-azure`オプションを使用してAzure OpenAI Serviceと連携可能。

Azure OpenAI Service + Open Interpreterやってみたレポート
https://zenn.dev/happy_elements/articles/745e339b5f9d99

■ Code Interpreterとの違い

https://github.com/KillianLucas/open-interpreter

OpenAI's release of **Code Interpreter** with GPT-4 presents a fantastic opportunity to accomplish real-world tasks with ChatGPT.

However, OpenAI's service is hosted, closed-source, and heavily restricted:

- No internet access.
- Limited set of pre-installed packages.
- 100 MB maximum upload, 120.0 second runtime limit.
- State is cleared (along with any generated files or links) when the environment dies.


# 関数呼び出し(function calling)

https://learn.microsoft.com/ja-jp/azure/ai-services/openai/how-to/function-calling

https://zenn.dev/happy_elements/articles/0b2691b3fc53fd


簡単にいうとGPT-4に対してあら予め「あなたはこういう関数を利用できるから、利用したい場合は引数をレスポンスしてね」と伝えておくことで、GPT-4とバックエンドサーバーで自動で何度かやり取りを行い、ユーザーの複雑な要求を解決する機能です。

**本家OpenAIだけでなく、Azure OpenAI Serviceでも（記事公開時点previewで）利用可能です。**


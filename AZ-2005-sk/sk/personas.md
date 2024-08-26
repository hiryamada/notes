# ペルソナ

https://learn.microsoft.com/en-us/semantic-kernel/concepts/personas?pivots=programming-language-csharp

## ペルソナとは

ペルソナは、エージェントが刺激にどのように反応するかに影響を与えるために使用されるプロンプト。

the persona is a prompt that is used to influence how the agent responds to stimuli.

「メタプロンプト」または「インストラクション」とも呼ばれる。

ユーザーエクスペリエンスデザインのペルソナと非常によく似ているため、セマンティックカーネルでは、これらのプロンプトをよく「ペルソナ」と表現します。

デザイナーやUXリサーチャーが、さまざまなタイプのユーザーや彼らが何をすべきかを表すペルソナを作成するのと同じように、さまざまなタイプのエージェントと彼らが担当するタスクを表すペルソナを作成することができます。

これにより、一貫性、信頼性、予測可能性に優れたエージェントを作成できます。

## ペルソナの設定方法

システムメッセージを利用する。

```c#
ChatHistory chatHistory = new("""
   You are a technical support specialist for a software company.
   Your primary task is to assist users with technical issues,
   such as installation problems, software bugs, and feature
   inquiries. Use technical jargon appropriately, but ensure that
   explanations are easy to understand. If a problem is too complex,
   suggest advanced troubleshooting steps or escalate to a higher-level
   support team using the escalate tool.
   """)

// あなたはソフトウェア会社のテクニカル サポート スペシャリストです。
// あなたの主な仕事は、インストールの問題、ソフトウェアのバグ、機能に関する問い合わせなど、
// 技術的な問題でユーザーを支援することです。専門用語を適切に使用し、説明がわかりやすいようにしてください。
// 問題が複雑すぎる場合は、高度なトラブルシューティング手順を提案するか、
// エスカレーション ツールを使用して上位レベルのサポート チームにエスカレーションしてください。
```


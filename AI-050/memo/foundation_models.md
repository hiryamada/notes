# 基盤モデル

https://blog.recruit.co.jp/data/articles/foundation_models/

改めて「基盤モデルとは何か」を説明しましょう。基盤モデルを命名した論文" On the Opportunities and Risks of Foundation Models “では、次のように定義されています。

A foundation model is any model that is trained on broad data at scale and can be adapted (e.g., fine-tuned) to a wide range of downstream tasks

すなわち、基盤モデルとは「大量かつ多様なデータで訓練され、多様な下流タスクに適応（ファインチューニングなど）できるモデル」のことです。具体例としては、大量のテキストデータで学習することで感情分析や質問応答など多数のタスクで使えるようになった BERT や、加えて翻訳などの生成系タスクもできる GPT-3 、大量の画像・説明文ペアで学習することでゼロショット画像分類ができるようになった CLIP などが挙げられます。

基盤モデルは大まかに「言語（language）」を扱うものと「視覚・言語（vision and language）」を扱うものとに分けられます。視覚（vision）は画像と動画の両方を指す言葉です。
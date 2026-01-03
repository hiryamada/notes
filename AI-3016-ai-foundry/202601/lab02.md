# lab 02 Create a generative AI chat app

## 概要

- 簡単なチャットアプリ
- 所要時間20分ほど

## 前提

- 英語版ラボを使用
- ラボVMあり
  - Git
  - Python
  - VS Code
  - Azure CLI

## ローカルで実施する場合

以下のようにして適当な .azure フォルダに認証情報を置ける（普段の認証情報を壊さない）
```
$Env:AZURE_CONFIG_DIR="C:\temp\mslearn-ai-foundry\labfiles\chat-app\python\.azure"
az login --use-device-code
```

## 手順概要

- ai.azure.com
- プロジェクトを作る
  - プロジェクト名、リージョンは手順書内で指定されている
  - リソースグループは既存のもの
- gpt-4oをデプロイ
- https://github.com/microsoftlearning/mslearn-ai-studio をクローン
- VS Codeを起動
- labfiles/chat-app/python フォルダを開く
- requirements.txt に以下を追加
  - azure-identity
  - azure-ai-projects
  - openai
- VS Code F1、Python: Create Environment
- .envにプロジェクトエンドポイント、デプロイ名を記入
  - プロジェクトエンドポイントはMicrosoft Foundryプロジェクトの「概要」からコピー
- az login
- プログラムを完成させる
- ターミナルで python app.py
- 簡単なチャットアプリが動く

## app.py（完成コード）

```python
import os
from dotenv import load_dotenv

# Add references
from azure.identity import AzureCliCredential
from azure.ai.projects import AIProjectClient
from openai import AzureOpenAI

def main(): 

    # Clear the console
    os.system('cls' if os.name=='nt' else 'clear')
        
    try: 
    
        # Get configuration settings 
        load_dotenv()
        project_endpoint = os.getenv("PROJECT_ENDPOINT")
        model_deployment = os.getenv("MODEL_DEPLOYMENT")

        # Initialize the project client
        project_client = AIProjectClient(            
            credential=AzureCliCredential(),
            endpoint=project_endpoint,
        )

        # Get a chat client
        openai_client = project_client.get_openai_client(api_version="2024-10-21")

        # Initialize prompt with system message
        prompt = [
            {"role": "system", "content": "You are a helpful AI assistant that answers questions."}
        ]

        # Loop until the user types 'quit'
        while True:
            # Get input text
            input_text = input("Enter the prompt (or type 'quit' to exit): ")
            if input_text.lower() == "quit":
                break
            if len(input_text) == 0:
                print("Please enter a prompt.")
                continue
            
            # Get a chat completion
            prompt.append({"role": "user", "content": input_text})
            response = openai_client.chat.completions.create(
                    model=model_deployment,
                    messages=prompt)
            completion = response.choices[0].message.content
            print(completion)
            prompt.append({"role": "assistant", "content": completion})

    except Exception as ex:
        print(ex)

if __name__ == '__main__': 
    main()

```
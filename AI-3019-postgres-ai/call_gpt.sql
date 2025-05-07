CREATE EXTENSION plpython3u;

CREATE OR REPLACE FUNCTION call_gpt_azure(prompt TEXT, api_key TEXT, endpoint TEXT, deployment TEXT, api_version TEXT)
RETURNS TEXT
AS $$
import requests, json
u = f'{endpoint}/openai/deployments/{deployment}/chat/completions?api-version={api_version}'
h = {'Content-Type':'application/json','api-key':api_key}
d = {'messages':[{'role':'user','content':prompt}]}
r = requests.post(u, headers=h, json=d)
return r.json()['choices'][0]['message']['content']
$$ LANGUAGE plpython3u;

SELECT call_gpt_azure(
  'AzureのAI機能について教えて',
  'your-azure-api-key',
  'https://your-resource-name.openai.azure.com',
  'your-deployment-name',
  '2024-03-01'
);

CREATE EXTENSION azure_ai;

UPDATE table1
SET text_en = (
  SELECT value
  FROM jsonb_each_text(
    (azure_cognitive.translate(text_ja, 'en'))->0
  )
  WHERE key = 'text'
);


# Azure AI Search の「検索エクスプローラー」の「クエリ ビュー」の検索条件サンプル

名前（Name）またはプロフィール（Profile）または勤務地（Location）に「山本」を含む
```
山本
```

名前（Name）またはプロフィール（Profile）または勤務地（Location）に「C#」を含む

```
C#
```

名前（Name）またはプロフィール（Profile）または勤務地（Location）に「大阪」を含む

```
大阪
```

# Azure AI Search の「検索エクスプローラー」の 「JSON ビュー」の検索条件サンプル

すべての社員の名前と年齢を表示

```json
{
  "select": "Name, Age"
}
```

上級エンジニアの名前のみ表示
```json
{
  "search": "上級",
  "select": "Name"
}
```
名前に「山本」を含む従業員（部分一致）

```json
{
  "search": "山本",
  "searchFields": "Name"
}
```
C# 経験者
```json
{
  "search": "C#",
  "searchFields": "Profile"
}
```
東京在住の上級エンジニア（部分一致、検索する列を複数指定）
```json
{
  "search": "東京 上級",
  "searchFields": "Location,Seniority"
}
```
名前が「山本 大輔」である従業員（完全一致検索）※filterでは部分一致が使用できない
```json
{
  "filter": "Name eq '山本 大輔'"
}
```
リモートワーク可能な社員
```json
{
  "search": "*",
  "filter": "RemoteWork eq true"
}
```
2018年以降に入社した C# 経験者
```json
{
  "search": "C#",
  "searchFields": "Profile",
  "filter": "HireDate ge 2018-01-01T00:00:00Z"
}
```
Python スキルを持ち、30歳未満の従業員
```json
{
  "search": "Python",
  "searchFields": "Profile",
  "filter": "Age lt 30"
}
```
リモートワーク可能な上級エンジニア
```json
{
  "filter": "Location eq '東京' and RemoteWork eq true and Seniority eq '上級'"
}
```
'Microsoft Cettified: Azure AI Engineer' 資格を持つ従業員
```json
{
  "filter": "Certifications/any(c: c eq 'Microsoft Certified: Azure AI Engineer')"
}
```
東京在宅の英語が使える従業員
```json
{
  "search": "*",
  "filter": "Location eq '東京' and Languages/any(l: l eq '英語') "
}
```
日本語と英語が使える従業員
```json
{
  "search": "*",
  "filter": "Languages/any(l1: l1 eq '日本語') and Languages/any(l2: l2 eq '英語')"
}
```


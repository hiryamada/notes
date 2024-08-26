# Handlebars

`Microsoft.SemanticKernel.PromptTemplates.Handlebars`パッケージは、`Handlebars.Net`に依存している。
https://www.nuget.org/packages/Microsoft.SemanticKernel.PromptTemplates.Handlebars#dependencies-body-tab

`Handlebars.Net` は、 https://handlebarsjs.com/ の .NET 実装。
https://www.nuget.org/packages/Handlebars.Net/#readme-body-tab


## 簡単な使い方

https://github.com/Handlebars-Net/Handlebars.Net?tab=readme-ov-file#usage

```c#
string source =
@"<div class=""entry"">
  <h1>{{title}}</h1>
  <div class=""body"">
    {{body}}
  </div>
</div>";

var template = Handlebars.Compile(source);

var data = new {
    title = "My new post",
    body = "This is my first post!"
};

var result = template(data);

/* Would render:
<div class="entry">
  <h1>My New Post</h1>
  <div class="body">
    This is my first post!
  </div>
</div>
*/
```

名前空間は `HandlebarsDotNet` https://github.com/Handlebars-Net/Handlebars.Net/blob/master/source/Handlebars/Handlebars.cs


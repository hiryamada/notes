# CS8618 警告について

```
CS8618
Non-nullable field 'Field1' must contain a non-null value when exiting constructor.
Consider declaring the field as nullable.

Null 非許容フィールド 'Field1' は、コンストラクタが終了する前に非 Null の値を持たなければなりません。
フィールドを Null 許容として宣言することを検討してください。
```

参考: https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/builtin-types/nullable-reference-types

```cs

// C# 8.0 では、値が null になりうる変数の型は「型?」で宣言する。
string? x = null;
string y = null; // CS8600 Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。

// 同様に、値が null になりうるフィールドの型は「型?」で宣言する。
class X0 {
    string? Field1 = null;
    string Field2 = null; // CS8625 null リテラルを null 非許容参照型に変換できません。
}

// 以下のように、参照型のフィールドを宣言していながら、null 以外の値を代入していない場合、
// フィールドの値は null になってしまうので、警告が出る。
class X1
{
    // CS8618
    // Non-nullable field 'Field1' must contain a non-null value when exiting constructor.
    // Consider declaring the field as nullable.
    // Null 非許容フィールド 'Field1' は、コンストラクタが終了する前に非 Null の値を持たなければなりません。
    // フィールドを Null 許容として宣言することを検討してください。
    string Field1;
}

// 対策1: コンストラクタで、フィールドに null 以外の値を代入する
class X2
{
    string Field1;
    X2() // コンストラクタ
    {
        // クラスのオブジェクトを作成した時点で、フィールドに null 以外の値が入るようにする。
        // これで 警告 CS8618 は消える
        Field1 = "";
    }
}

// コンストラクタを使わず、フィールドに直接、null 以外の値を代入してもよい
class X3
{
    string Field1 = "";
    string Field2 = string.Empty;
}

// 対策2: フィールドを Null許容型として宣言する。
class X4
{
    string? Field1;
}

// 対策3: 「null 免除演算子」(null forgiving operator)を使用することで、
// フィールドの値を null としつつ、警告を握りつぶす
// https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/operators/null-forgiving
class X5
{
    string Field1 = null!;
    string Field2 = default!; // default: 規定値式(default value expression) https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/operators/default
}

// 対策4
// ～.csproj ファイル内の
//     <Nullable>enable</Nullable>
// の値を、disable にするか、この行を削除する
```
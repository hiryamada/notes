using System.Text.Json;

#pragma warning disable IDE1006
record Music(
    string artist,
    string id,
    Dictionary<string, int> detail
)
{
    public override string ToString() =>
        JsonSerializer.Serialize(this);
}
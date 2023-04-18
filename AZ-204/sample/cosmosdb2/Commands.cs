using Microsoft.Azure.Cosmos;

class Commands : ConsoleAppBase
{
    private readonly Container _container;
    public Commands(CosmosClient client) =>
        _container = client.GetDatabase("musicdb")
            .GetContainer("music");

    // 項目の作成
    public Task Insert(string artist, string id,
        Dictionary<string, int> detail) =>
            _container.UpsertItemAsync(
                new Music(artist, id, detail));

    // 更新
    public Task Update(string artist, string id,
        Dictionary<string, int> detail) =>
            Insert(artist, id, detail);

    // 項目の読み取り
    public async Task Read(string artist, string id)
    {
        var item = (await _container.ReadItemAsync<Music>(
            id, new PartitionKey(artist))).Resource;
        Console.WriteLine(item);
    }

    // 項目の全件検索
    public async Task SelectAll() =>
        await ExecureQuery<Music>(
            new QueryDefinition("SELECT * from Music c"));

    // 検索の補助メソッド
    private async Task ExecureQuery<T>(QueryDefinition query)
    {
        using var feed = _container.GetItemQueryIterator<T>(query);
        while (feed.HasMoreResults)
        {
            var res = await feed.ReadNextAsync();
            foreach (var item in res) Console.WriteLine(item);
        }
    }

    // アーティスト名を指定して検索
    public async Task SelectByArtist(string artist) =>
        await ExecureQuery<Music>(
            new QueryDefinition(
                "SELECT * from Music c where c.artist = @artist")
                    .WithParameter("@artist", artist));

    // 項目の削除
    public Task Delete(string artist, string id) =>
        _container.DeleteItemAsync<Music>(
            id, new PartitionKey(artist));
}
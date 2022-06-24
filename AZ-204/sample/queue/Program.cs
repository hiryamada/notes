using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// DIコンテナーに、Azureサービスを追加
builder.Services.AddAzureClients(clients =>
{
    // appsettings.jsonの `queue`セクションを取得
    var queueSection = builder.Configuration.GetSection("queue");
    // キューサービスのクライアントをDIコンテナーに追加
    clients.AddQueueServiceClient(queueSection);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

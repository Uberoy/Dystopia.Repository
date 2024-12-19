using Dystopia.Repository.DbContext;
using Dystopia.Repository.Repository;
using Dystopia.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddSingleton<RabbitMqService>();
builder.Services.AddHostedService<RabbitMqConsumerService>();

var app = builder.Build();

app.MapGet("/tickets", async (ITicketRepository repo, int start, int count) =>
{
    return await repo.GetManyAsync(start, count);
});

app.Run("http://0.0.0.0:5050");
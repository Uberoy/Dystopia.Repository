//using Dystopia.Repository.DbContext;
//using Dystopia.Repository.Repository;

//namespace Dystopia.Repository;

//public static class DependencyInjection
//{
//    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
//    {
//        var mongoDbSettings = configuration.GetSection("MongoDb").Get<MongoDbSettings>();
//        if (mongoDbSettings == null)
//        {
//            throw new Exception("MongoDb configuration section is missing or invalid in appsettings.json");
//        }

//        services.AddSingleton(mongoDbSettings);
//        services.AddScoped<IMongoDbContext, MongoDbContext>();
//        services.AddScoped<ITicketRepository, TicketRepository>();

//        return services;
//    }
//}
using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

// Desarrollo
Console.WriteLine("Development");
var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = MongoClientSettings.FromConnectionString(mongoDbSettings.ConnectionString);
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    var client = new MongoClient(settings);
    try 
    {
        var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
        Console.WriteLine("You successfully connected to MongoDB!");
    } 
    catch (Exception ex) 
    {
        Console.WriteLine(ex);
    }
    
    return client;
});

builder.Services.AddScoped<IDatabaseContext, MongoDatabaseContext>();

//builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

/*
// Producción


Console.WriteLine("Production");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
*/

var app = builder.Build();

app.UseExceptionHandler();

// App
app.MapControllers();

app.MapDefaultEndpoints();
app.Run();
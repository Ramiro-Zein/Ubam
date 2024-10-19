using AspireApp1.ApiService.Database_Context;
using AspireApp1.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

/*
 Commands
    $Env:ASPNETCORE_ENVIRONMENT = "Production"
    dotnet run --no-launch-profile
    $Env:ASPNETCORE_ENVIRONMENT = "Development"
    dotnet run

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("Development: http://localhost:5561/api/mongodbstatus/status");
    var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

    builder.Services.AddSingleton<IMongoClient>(sp =>
    {
        var settings = MongoClientSettings.FromConnectionString(mongoDbSettings?.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
    
        try
        {
            var database = client.GetDatabase("ubam").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("You successfully connected to MongoDB!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return client;
    });
    
    builder.Services.AddScoped<IDatabaseContext, MongoDatabaseContext>();
}
else if (builder.Environment.IsProduction())
{
    Console.WriteLine("Production");
    builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
    builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
}
*/

builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("hhttp://localhost:5122/auth/alumnos/agregar-alumno").AllowAnyMethod();;
        });
});
*/

var app = builder.Build();

//app.UseCors("AllowAll");
//app.UseAuthorization();

// App
app.UseExceptionHandler();
app.MapControllers();
app.MapDefaultEndpoints();
app.Run();
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AspireApp1.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MongoDbStatusController : ControllerBase
{
    private readonly IMongoClient _mongoClient;

    public MongoDbStatusController(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        try
        {
            var database = _mongoClient.GetDatabase("ubam");
            var command = new BsonDocument("ping", 1);
            var result = database.RunCommand<BsonDocument>(command);
                
            if (result.Contains("ok") && result["ok"] == new BsonInt32(1))
            {
                return Ok(new
                {
                    status = "success",
                    message = "Connected to MongoDB"
                });
            }

            return StatusCode(500, new
            {
                status = "error",
                message = "Ping command failed",
                result = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                status = "error",
                message = "Failed to connect to MongoDB",
                error = ex.Message
            });
        }
    }
}
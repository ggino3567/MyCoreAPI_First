using Microsoft.AspNetCore.Mvc;
using MyCoreAPI_First.Models;

namespace MyCoreAPI_First.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("[controller]")] 告訴框架，這個控制器底下的所有 API，它們的 URL 都會以控制器名稱（去掉 Controller 後綴）開頭。
    //基底路徑就是 https://localhost:7090/TestAddPost。
    public class TestAddPostController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestAddPostController> _logger;

        public TestAddPostController(ILogger<TestAddPostController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")] //Controller命名；[HttpGet("N")]就是URL路徑 [HttpGet(Name = "Z")]是給它命名
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //為她準備一個小數據結構
        private static Dictionary<string, AddRequest> virtualDb = new Dictionary<string, AddRequest>();

        [HttpPost("PostAdd")]
        public AddResponse addResponse(AddRequest addRequest)
        {
            AddResponse newResponse = new AddResponse();

            try
            {
                virtualDb.Add(addRequest.ISBN, addRequest);
                newResponse.ISBN = addRequest.ISBN;
                newResponse.Message = "SUCCESS!";
                newResponse.States = "T";
            }
            catch (Exception except)
            {
                Console.WriteLine($"{except}\n{except.Message}");
                newResponse.ISBN = "";
                newResponse.Message = "FAILED!";
                newResponse.States = "F";
            }

            return newResponse;
        }
    }
}

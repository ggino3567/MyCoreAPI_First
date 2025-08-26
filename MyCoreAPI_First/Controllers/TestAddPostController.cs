using Microsoft.AspNetCore.Mvc;
using MyCoreAPI_First.Models;

namespace MyCoreAPI_First.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("[controller]")] �i�D�ج[�A�o�ӱ�����U���Ҧ� API�A���̪� URL ���|�H����W�١]�h�� Controller ���^�}�Y�C
    //�򩳸��|�N�O https://localhost:7090/TestAddPost�C
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

        [HttpGet("GetWeatherForecast")] //Controller�R�W�F[HttpGet("N")]�N�OURL���| [HttpGet(Name = "Z")]�O�����R�W
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

        //���o�ǳƤ@�Ӥp�ƾڵ��c
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

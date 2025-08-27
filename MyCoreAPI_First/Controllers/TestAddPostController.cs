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
        private readonly ILogger<TestAddPostController> _logger;

        public TestAddPostController(ILogger<TestAddPostController> logger)
        {
            _logger = logger;
        }

        private static readonly string[] FeelStates = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("GetTest")] //Controller�R�W�F[HttpGet("N")]�N�OURL���| [HttpGet(Name = "Z")]�O�����R�W
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = FeelStates[Random.Shared.Next(FeelStates.Length)]
            })
            .ToArray();
        }

        //���o�ǳƤ@�Ӥp�ƾڵ��c
        private static Dictionary<string, PostRequest> virtualDb = new Dictionary<string, PostRequest>();

        [HttpPost("PostTest")]
        public PostResponse addResponse(PostRequest postRequest)
        {
            PostResponse newResponse = new PostResponse();

            try
            {
                //�L�P�_���Ƥ��e �Y�����ƱNreturn catch exception
                virtualDb.Add(postRequest.ISBN, postRequest);
                newResponse.ISBN = postRequest.ISBN;
                newResponse.Message = "SUCCESS!";
                newResponse.States = "T";
            }
            catch (Exception except)
            {
                Console.WriteLine($"[POST CATCHED!] {except}\n{except.Message}");
                newResponse.ISBN = "";
                newResponse.Message = "FAILED!";
                newResponse.States = "F";
            }

            return newResponse;
        }
    }
}

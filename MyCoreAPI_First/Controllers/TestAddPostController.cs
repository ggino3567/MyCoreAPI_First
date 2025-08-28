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
        /*
        private readonly ILogger<TestAddPostController> _logger;

        public TestAddPostController(ILogger<TestAddPostController> logger)
        {
            _logger = logger;
        }
         */

        [HttpGet("GetTest")] //Controller命名；[HttpGet("N")]就是URL路徑 [HttpGet(Name = "Z")]是給它命名
        public IActionResult Get()
        {
            return Ok(new { message = "HelloWorld!" });
        }

        //為Post準備一個小數據結構
        private static Dictionary<string, PostRequest> virtualDb = new Dictionary<string, PostRequest>();

        [HttpPost("PostTest")]
        public PostResponse addResponse(PostRequest postRequest)
        {
            PostResponse newResponse = new PostResponse();

            try
            {
                //無判斷重複內容 若有重複將return catch exception
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

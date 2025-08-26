//在 ASP.NET Core 中，要讓 JSON 資料能自動轉換為 C# 物件，您需要使用 屬性（Properties） 而不是欄位（Fields）。
//這次使用到的是舊版本.NET Framework的
namespace MyCoreAPI_First.Models
{
    public class AddRequest
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }
        public Authors[] Authors { get; set; } // 注意這裡，JSON屬性是"Authors"，C#屬性名也應該是"Authors"
    }

    public class Authors
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
    }

    public class AddResponse
    {
        public string Message { get; set; }
        public string ISBN { get; set; }
        public string States { get; set; }
    }
}

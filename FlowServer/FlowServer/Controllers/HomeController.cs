using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace FlowServer.Controllers
{
    public class HomeController : Controller
    {
        //获取GET参数 Request.Query["Key"]
        //获取POST参数 :
        //Stream stream = HttpContext.Request.Body;
        //byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
        //stream.Read(buffer, 0, buffer.Length);
        //string content = Encoding.UTF8.GetString(buffer);

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public string Hello()
        {
            Stream stream = HttpContext.Request.Body;
            byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string content = Encoding.UTF8.GetString(buffer);
            return "string";
        }
    }
}
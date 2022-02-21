using Microsoft.AspNetCore.Mvc;

namespace UploadFilesServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

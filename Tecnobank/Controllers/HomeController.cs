using System.Web.Http;
using System.Web.Mvc;

namespace Tecnobank.Controllers
{    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

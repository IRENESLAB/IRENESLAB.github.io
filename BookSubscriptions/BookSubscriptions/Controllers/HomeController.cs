using System.Web.Mvc;

namespace BookSubscriptions.Controllers
{
    public class HomeController :Controller
    {
        public ActionResult Index()
        { 
            return View();
        }
        
    }
}

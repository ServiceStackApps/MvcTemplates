using System.Threading.Tasks;
using System.Web.Mvc;
using ServiceStack.Mvc;
using ServiceStack.Templates;

namespace MvcTemplates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITemplatePages pages;
        public HomeController(ITemplatePages pages) => this.pages = pages;

        public Task<MvcPageResult> Index() =>
            new PageResult(pages.GetPage("index")).ToMvcResultAsync();

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
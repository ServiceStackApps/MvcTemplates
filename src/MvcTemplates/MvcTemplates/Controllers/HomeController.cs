using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using ServiceStack;
using ServiceStack.Mvc;
using ServiceStack.Templates;

namespace MvcTemplates.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index() =>
            await new PageResult(HostContext.TryResolve<ITemplatePages>().GetPage("index")).ToMvcResultAsync();

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
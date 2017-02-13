using System.Web.Mvc;
using DobbyMvcSample.Services;

namespace DobbyMvcSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMessageService _messageService2;

        public HomeController(IMessageService messageService, IMessageService messageService2)
        {
            _messageService = messageService;
            _messageService = messageService2;
        }

        public ActionResult Index()
        {
            _messageService.Send();
            return View();
        }

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
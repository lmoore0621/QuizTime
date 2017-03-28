using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string ClientId = ConfigurationManager.AppSettings["googleClientId"];
            string ClientSecret = ConfigurationManager.AppSettings["googleSecret"];
            return View();
        }

        [Authorize]
        public ActionResult TakeQuiz()
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
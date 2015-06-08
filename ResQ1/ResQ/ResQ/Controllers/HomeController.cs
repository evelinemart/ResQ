using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Using()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Dispatcher");
            else
                return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public FileResult GetFile()
        {
            string file_path = Server.MapPath("~/Files/app.rar");
            string file_type = "application/rar";
            string file_name = "app.rar";
            return File(file_path, file_type, file_name);
        }
    }
}
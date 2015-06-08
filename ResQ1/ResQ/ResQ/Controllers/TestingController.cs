using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ResQ.Models;
using System.IO;
using Novacode;
using System.Drawing;

namespace ResQ.Controllers
{
    public class TestingController : Controller
    {
        private ApplicationDbContext _cont;

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult GetFormForPut()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Put(AddFire model)
        {
            ApplicationUser result = UserManager.FindByEmail(model.Email);
            if (result != null)
            {
                using (_cont = new ApplicationDbContext())
                {                   
                    var loc = new Location() { X = model.X, Y = model.Y, City = " ", Country = " ", House_Number = " ", Street = " " };
                    _cont.Locations.Add(loc);
                    IQueryable<FireStation> r = from s in _cont.FireStations
                                                select s;
                    FireStation q = r.First();
                    _cont.Requests.Add(new Request() { LocationId = loc.Id, Date = DateTime.Now, Status = "Принятый", UserId = result.Id, FireStationId = q.Id, DateFinished=DateTime.Now });
                    _cont.SaveChanges();
                }
                return Json("Принято", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Пользователь не найден", JsonRequestBehavior.AllowGet);
        }
        


    }
}
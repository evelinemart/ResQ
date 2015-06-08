using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using ResQ.Models;
using Microsoft.Owin.Security;
using System.Net;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ResQ.Controllers
{
    [Authorize(Roles="User")]
    public class UserController : Controller
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


        public ActionResult Index()
        {
            _cont = new ApplicationDbContext();
            ViewBag.Count = _cont.Requests.Count();
            ViewBag.Today = (from t in _cont.Requests
                            where t.Date.Day == DateTime.Today.Day
                            select t).Count();           
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.FirsName = currentUser.UserFirstName;
            ViewBag.LastName = currentUser.UserLastName;
            return View();
        }
        public ActionResult MyCalls()
        {
            _cont = new ApplicationDbContext();
            string str = User.Identity.GetUserId();
            var t = (from temp in _cont.Requests.Include("Location")
                     where temp.UserId == str
                     select temp).ToList();

            return View(t);
        }
        public ActionResult MySettings()
        {
            return View();
        }


        public ActionResult ChangeName()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> ChangeName(AccountKeeper model)
        {
            ApplicationUser Model = UserManager.FindById(User.Identity.GetUserId());
            Model.UserFirstName = model.NewValue;
            IdentityResult result = await UserManager.UpdateAsync(Model);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeLastName()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> ChangeLastName(AccountKeeper model)
        {
            ApplicationUser Model = UserManager.FindById(User.Identity.GetUserId());
            Model.UserLastName = model.NewValue;
            IdentityResult result = await UserManager.UpdateAsync(Model);
            return RedirectToAction("Index");
        }


 
    }
}
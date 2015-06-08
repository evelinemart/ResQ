using ResQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http.Owin;

namespace ResQ.Controllers
{
    public class AcceptRequestController : ApiController
    {

        // GET: api/AcceptRequest/5
        //public string Get(int id, LoginViewModel value)
        //{
        //    string mail = "koko@mail.ru";
        //    string password = "kokoko";
        //    if (value.Password == password && mail == value.Email)
        //    {
        //        using (ApplicationDbContext _cont = new ApplicationDbContext())
        //        {
        //            var t = (from temp in _cont.Requests
        //                    where temp.ID == id
        //                    select temp).ToArray()[0];
        //            if (t.Status != "Принятый")
        //                return "True";
        //            else
        //                return "False";
        //        }
        //    }
        //    return "WRONG";
        //}

        // POST: api/AcceptRequest
        //public string Post([FromBody]LoginViewModel value)
        //{
        //    ApplicationDbContext _cont = new ApplicationDbContext();
        //    var user = _cont.Informations.Find(value.Email);
        //    if (value.Password == user.Password && user.Email == value.Email)
        //    {

        //        var loc = new Location() { X = 49.988535, Y = 36.232583, City = "Харьков", Country = "Украина", House_Number = "54", Street = "Коко" };
        //        _cont.Locations.Add(loc);
        //        IQueryable<FireStation> r = from s in _cont.FireStations
        //                                    select s;
        //        FireStation q = r.First();
        //        _cont.Requests.Add(new Request() { LocationId = loc.Id, Date = DateTime.Now, Status = "Принятый", UserId = result.Id, FireStationId = q.Id, DateFinished = DateTime.Now });
        //        _cont.SaveChanges();

        //        return "Okay";

        //    }
        //    else
        //        return "NoOkay";
        //}

        //private ApplicationDbContext _cont;

        //private ApplicationUserManager _userManager;
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
    }
}

using ResQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResQ.Controllers
{
    public class AuthorizationController : ApiController
    {
        // GET: api/Authorization/5
        public string Get(LoginViewModel value)
        {
            ApplicationDbContext _cont = new ApplicationDbContext();
            var user = from t in _cont.Informations
                        where t.Email == value.Email
                        select t;
            //var q = user.First();

            //List<HelpInfo> temp = user.ToList();
            //if (value.Password == temp.Password && temp.Email == value.Email)
            //    return "1";
            //else
                return "0";
            //return "value";
        }

        // POST: api/Authorization
        public string Post([FromBody]LoginViewModel value)
        {
            ApplicationDbContext _cont = new ApplicationDbContext();
            var user = _cont.Informations.Find(value.Email);
            if (value.Password == user.Password && user.Email == value.Email)
                return "1";
            else 
                return "0";
        }
    }
}

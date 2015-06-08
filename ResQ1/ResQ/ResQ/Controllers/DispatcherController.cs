using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using ResQ.Models;
using ResQ.Infrastructure;
using Novacode;
using System.Drawing.Printing;

namespace ResQ.Controllers
{    
    public class DispatcherController : Controller
    {
        private ApplicationDbContext _cont;

        // GET: Dispatcher
        [HttpGet]
        public ActionResult Index()
        {
            _cont = new ApplicationDbContext();
            var listOfRequests = from temp in _cont.Requests.Include("User").Include("Location")
                                 where temp.Status == "Принятый"
                                 select temp;
            return View(listOfRequests);
        }
        // GET: Process
        [HttpGet]
       
        public ActionResult Process(int? id)
        {
            _cont = new ApplicationDbContext();
            Request reqItem = _cont.Requests.Find(id);
            if (reqItem == null || reqItem.Status != "Принятый")
                return View("Error");

            ViewBag.ID = id;
            ViewBag.Station = DataComputing.FindTheNearestFireStation(_cont, id);
            Location hotPoint = (from temp in _cont.Locations
                                 where temp.Id == reqItem.LocationId
                                 select temp).ToArray()[0];
            ViewBag.HotPotinX = hotPoint.X;
            ViewBag.HotPointY = hotPoint.Y;
            ViewBag.FireStations = _cont.FireStations;

            return View();
        }
        // POST: Process
        [HttpPost]
        public ActionResult ProcessingRequest(ProcesRequest post)
        {
            using (_cont = new ApplicationDbContext())
            {
                Request forupp = _cont.Requests.Find(post.RequestID);
                forupp.FireStationId = Convert.ToInt32(post.FireStationID);
                forupp.Status = "Обработанный";
                forupp.DateFinished = DateTime.Now;
                if (TryUpdateModel(forupp))
                    _cont.SaveChanges();
                using (DocX document = DocX.Load(Server.MapPath("~/Files/report.docx")))
                {
                    Request temp = (from t in _cont.Requests.Include("User").Include("Location").Include("FireStation")
                               where t.ID == forupp.ID
                               select t).ToArray()[0];
                    FileCreator.CreateReport(temp, document);
                }
            }
            return View("Index");
        }

        // GET: CallHistory
        [HttpGet]
        public ActionResult CallHistory()
        {
            _cont = new ApplicationDbContext();
            var listOfRequests = from temp in _cont.Requests.Include("User").Include("Location")
                                 where temp.Status != "Принятый"
                                 select temp;
            return View(listOfRequests);
        }

        // GET: PrintReport
        [HttpGet]
        public FileResult PrintReport()
        {
            string file_path = Server.MapPath("~/Files/report.docx");
            string file_type = "application/docx";
            string file_name = "report.docx";
            return File(file_path, file_type, file_name);
        }

        // GET(Partial): NewRequests
        public ActionResult GetNewRequests()
        {
            _cont = new ApplicationDbContext();
            var listOfRequests = from temp in _cont.Requests.Include("User").Include("Location")
                                 where temp.Status == "Принятый"
                                 select temp;
            return PartialView(listOfRequests);
        }

        public ActionResult PostNews()
        {
            return View();
        }

        public ActionResult PostingNews(AccountKeeper model)
        {
            using(_cont = new ApplicationDbContext())
            {
                var res = _cont.Informations.Find(1);
                res.Message = model.NewValue;
                if (TryUpdateModel(res))
                    _cont.SaveChanges();
            }

            return View("Index");
        }
    }
}
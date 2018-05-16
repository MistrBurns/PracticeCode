using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zinshaus_Proto.Models;

namespace Zinshaus_Proto.Controllers
{
    public class HomeController : Controller
    {
        ZinssatzDB _db = new ZinssatzDB();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Detail (int Id)
        {

            var zins = _db.Zinssatzs.Find(Id);
            if (zins != null) {
                return View(zins);
            }
             return HttpNotFound();
            
                        
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
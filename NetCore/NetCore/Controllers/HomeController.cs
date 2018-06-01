using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models;
using NetCore.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurauntData)
        {
            _restaurantData = restaurauntData;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            //object result => default behavior is, later in pipeline, json is generated
            return View(model);

            //return Data structure => later in processing pipeline, content is put into http-response
            return Content("Hello");
        }
    }
}

using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Controllers
{
    public class CarsController : Controller
    {
        CarService _carService;
        public CarsController()
        {
            _carService = new CarService();
        }
        // GET: Cars
        public ActionResult List()
        {
            List<Car> araclar = _carService.GetActive();
            return View(araclar);
        }
    }
}
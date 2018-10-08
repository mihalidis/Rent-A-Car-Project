using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Areas.Admin.Controllers
{
    public class CarBrandController : Controller
    {
        CarBrandService _carBrandService;

        public CarBrandController()
        {
            _carBrandService = new CarBrandService();
        }
        // GET: Admin/Car
        public ActionResult List()
        {
            List<CarBrand> markaList = _carBrandService.GetActive();
            return View(markaList);           
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CarBrand model)
        {
            try
            {
                _carBrandService.Add(model);
                TempData["BrandMsg"] = "Ekleme işlemi başarılı!";
                return RedirectToAction("List", "CarBrand");
            }
            catch (Exception)
            {
                TempData["BrandErr"] = "Ekleme işlemi gerçekleştirilemedi!";
                return View();
            }
            
        }

        public ActionResult Update(Guid id)
        {
            CarBrand marka = _carBrandService.GetById(id);
            return View(marka);
        }
        [HttpPost]
        public ActionResult Update(CarBrand model)
        {
            CarBrand mrka = _carBrandService.GetById(model.Id);

            mrka.BrandName = model.BrandName;
            mrka.Description = model.Description;
            _carBrandService.Update(mrka);
            return RedirectToAction("List", "CarBrand", new { area = "Admin" });
        }
        public ActionResult Delete(Guid id)
        {
            _carBrandService.Remove(id);
            return RedirectToAction("List", "CarBrand", new { area = "Admin" });
        }
    }
}
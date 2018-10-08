using NTier.Model.Entities;
using NTier.Service.Option;
using NTierRentACar.UI.Areas.Admin.Models;
using NTierRentACar.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Areas.Admin.Controllers
{
    public class CarController : Controller
    {
        CarService _carService;

             
        
        CarBrandService _carBrandService;

        public CarController()
        {
            _carBrandService = new CarBrandService();
            _carService = new CarService();
            
        }
        // GET: Admin/CarModel
        public ActionResult List()
        {
            List<Car> araclar = _carService.GetActive();
            return View(araclar);
        }
        public ActionResult Add()
        {
            CarVM vm = new CarVM();
            
            vm.aracmarka = _carBrandService.GetActive();      
            return View(vm);
        }
        [HttpPost]
        public ActionResult Add(Car model,HttpPostedFileBase Image)
        {
            
            try
            {
                model.ImageUrl = ImageUploader.UploadImage("~/Uploads/", Image);
                if (model.ImageUrl == "1" || model.ImageUrl == "2" || model.ImageUrl == "0")
                {
                    model.ImageUrl = "/Content/Images/reaper_cute.png";
                }
                _carService.Add(model);
                TempData["CarMsg"] = "Ekleme işlemi başarılı!";
                return RedirectToAction("List", "Car", new { area = "Admin" });
            }
            catch (Exception)
            {
                TempData["CarErr"] = "Ekleme işlemi gerçekleştirilemedi!";
                return View();
            }

            
        }
        public ActionResult Update(Guid id)
        {

            CarVM vm = new CarVM();
            vm.araba = _carService.GetById(id);
            if (vm.araba!=null)
            {
                ViewBag.araclar = _carService.GetActive();               
                vm.aracmarka = _carBrandService.GetActive();
            }            
            return View(vm);
        }
        [HttpPost]
        public ActionResult Update(Car model, HttpPostedFileBase Image)
        {
            try
            {
                model.ImageUrl = ImageUploader.UploadImage("~/Uploads", Image);
                if (model.ImageUrl == "1" || model.ImageUrl == "2" || model.ImageUrl == "0")
                {
                    model.ImageUrl = "/Content/Images/reaper_cute.png";
                }
                Car arac = _carService.GetById(model.Id);
                arac.CModel = model.CModel;
                arac.CarBrandID = model.CarBrandID;
                arac.CostPerDay = model.CostPerDay;
                arac.PersonCapacity = model.PersonCapacity;
                arac.BaggageCapacity = model.BaggageCapacity;
                arac.MinRentAge = model.MinRentAge;
                arac.Gearbox = model.Gearbox;                
                arac.FuelType = model.FuelType;               
                arac.ImageUrl = model.ImageUrl;                
                _carService.Update(arac);
                TempData["CarMsg"] = "Güncelleme işlemi gerçekleştirilmiştir";

                return RedirectToAction("List", "Car", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                TempData["Err"] = "Güncelleme gerçekleştirilemedi \n" + ex.Message;
                return RedirectToAction("List", "Car", new { area = "Admin" });
            }
        }

        public ActionResult Delete(Guid id)
        {
            _carService.Remove(id);
            return RedirectToAction("List", "Car", new { area = "Admin" });
        }
    }
}
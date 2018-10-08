using NTier.Model.Entities;
using NTier.Service.Option;
using NTierRentACar.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NTierRentACar.UI.Controllers
{
    public class MainController : Controller
    {
        RentService _rentService;
        CarService _carService;
        UserDetailService _userDetailService;
        public MainController()
        {
            _rentService = new RentService();
            _carService = new CarService();
            _userDetailService = new UserDetailService();
            
        }
        // GET: Home
        public ActionResult HomePage(Guid? id) 
        {
            if (id!=null)
            {
                UserDetail userz = new UserDetail();
                userz = _userDetailService.GetById(id.Value);
                string cookie = userz.UserName.ToString();
                FormsAuthentication.SetAuthCookie(cookie, true);
                if (userz.Role==Role.Admin)
                {
                    return RedirectToAction("Statics", "Home", new { area = "Admin" });
                }
            }
            return View();
        }
        
        public ActionResult Renting()
        {
            ViewBag.Araclar = _carService.GetActive();            
            return View();
        }
        [HttpPost]
        public ActionResult Renting(Rent model)
        {
            model.Billed = true;
            model.Returned = false;
            model.Paid = true;
            UserDetail kullanici = _userDetailService.FindByUserName(HttpContext.User.Identity.Name);
            model.UserID = kullanici.Id;
            _rentService.Add(model);
            return RedirectToAction("Fatura", "Invoice", new { area = "" });
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Main/HomePage");
        }

        
        
    }
}
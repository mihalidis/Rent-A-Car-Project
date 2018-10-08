using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        RentService _rentService;
        UserDetailService _userDetailService;
        CarService _carService;
        ContactService _contactService;
        public HomeController()
        {
            _rentService = new RentService();
            _userDetailService = new UserDetailService();
            _carService = new CarService();
            _contactService = new ContactService();
        }
        
        public ActionResult Index()
        {
            List<UserDetail> Kullanicilar = _userDetailService.GetDefault(x => x.Role == Role.Member && x.Durumu == NTier.Core.Entity.Enum.Status.Active);
            ViewBag.Users = Kullanicilar.Count;

            List<Rent> Kiralamalar = _rentService.GetDefault(x => x.Billed == true && x.Durumu== NTier.Core.Entity.Enum.Status.Active);
            ViewBag.Kiralama = Kiralamalar.Count;

            List<Car> araclar = _carService.GetAll();
            ViewBag.Araclar = araclar.Count();


            return View();
        }

        public ActionResult Contacts()
        {
            List<Contact> contactList = _contactService.GetActive();
            return View(contactList);
        }
    }
}
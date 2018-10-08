using NTier.Model.Entities;
using NTier.Service.Option;
using NTierRentACar.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Controllers
{
    public class InvoiceController : Controller
    {
        BillService _billService;
        RentService _rentService;
        UserDetailService _userDetailService;
        CarService _carService;

        public InvoiceController()
        {
            _billService = new BillService();
            _rentService = new RentService();
            _userDetailService = new UserDetailService();
            _carService = new CarService();
        }
        // GET: Bills
        public ActionResult Fatura()
        {
            InvoiceVM Fatura = new InvoiceVM();

            UserDetail rentuser = _userDetailService.FindByUserName(HttpContext.User.Identity.Name);

            Fatura.Kiralayan = rentuser;

            Fatura.Kiralama = _rentService.GetByDefault(x => x.UserDetail.UserName == rentuser.UserName); 

            var days = (int)Fatura.Kiralama.EndDate.Subtract(Fatura.Kiralama.StartDate).TotalDays + 1;

            Car rentalcar = _carService.GetById(Fatura.Kiralama.CarID);

            Bill newBill = new Bill();
            newBill.Date = DateTime.Now;
            newBill.Cost = days * rentalcar.CostPerDay;
            newBill.UserID = rentuser.Id;
            _billService.Add(newBill);

            Fatura.FaturaInfo = newBill.Id;
            Fatura.KiralananGun = days;
            Fatura.Ucret = newBill.Cost;
            Fatura.AracAdi = rentalcar.CModel;
            return View(Fatura);
        }
    }
}
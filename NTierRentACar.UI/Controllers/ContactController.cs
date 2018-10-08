using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Controllers
{
    public class ContactController : Controller
    {
        ContactService _contactService;
        public ContactController()
        {
            _contactService = new ContactService();
        }
        // GET: Contact
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contact model)
        {
            try
            {
                _contactService.Add(model);
                TempData["ContactMsg"] = "Mesajınız Gönderildi";
                return RedirectToAction("Add", "Contact", new { area = "" });
            }
            catch (Exception)
            {
                TempData["ContactErr"] = "Mesajınız Gönderilemedi. Telefon ile iletişime geçiniz.";
                return View();
            }
            
        }
    }
}
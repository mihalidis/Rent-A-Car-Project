using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Areas.Admin.Controllers
{
    public class UserDetailController : Controller
    {
        UserDetailService _userDetailService;
        public UserDetailController()
        {
            _userDetailService = new UserDetailService();
            List<string> roller = Enum.GetNames(typeof(Role)).ToList();            
            ViewBag.Roller = roller;
            
        }
        // GET: Admin/User
        public ActionResult List()
        {
            List<UserDetail> kullanicilar = _userDetailService.GetActive();
            return View(kullanicilar);
        }
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserDetail model)
        {
            try
            {
                _userDetailService.Add(model);
                TempData["UserMsg"] = "Ekleme işlemi başarılı!";
                return RedirectToAction("List", "UserDetail");
            }
            catch (Exception)
            {
                TempData["UserErr"] = "Ekleme işlemi gerçekleştirilemedi!";
                return View();
            }
        }
        public ActionResult Update(Guid id)
        {
            UserDetail kullanici = _userDetailService.GetById(id);

            return View(kullanici);
        }
        [HttpPost]
        public ActionResult Update(UserDetail model)
        {
            UserDetail kllanici = _userDetailService.GetById(model.Id);

            kllanici.FirstName = model.FirstName;
            kllanici.LastName = model.LastName;
            kllanici.UserName = model.UserName;
            kllanici.Password = model.Password;
            kllanici.Email = model.Email;
            kllanici.Role = model.Role;          

            _userDetailService.Update(kllanici);

            return RedirectToAction("List", "UserDetail", new { area = "Admin" });
        }
        public ActionResult Delete(Guid id)
        {
            _userDetailService.Remove(id);
            return RedirectToAction("List", "UserDetail", new { area = "Admin" });
        }
    }
}
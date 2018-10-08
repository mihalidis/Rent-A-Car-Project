using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Controllers
{
    public class UsersController : Controller
    {
        UserDetailService _userDetailService;
        public UsersController()
        {
            _userDetailService = new UserDetailService();
        }
        // GET: Users
        public ActionResult SignUp()
        {                        
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserDetail model)
            {            
                model.Role = Role.Member;
                _userDetailService.Add(model);
                return RedirectToAction("HomePage", "Main");
            
        }
    }
}
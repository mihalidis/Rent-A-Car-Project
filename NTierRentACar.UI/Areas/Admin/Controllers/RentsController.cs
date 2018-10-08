using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Areas.Admin.Controllers
{
    public class RentsController : Controller
    {
        
        RentService _rentService;
        
        public RentsController()
        {                      
            _rentService = new RentService();
        }
        // GET: Admin/Rents
        public ActionResult List()
        {            
            List<Rent> kiraList = _rentService.GetActive();
            return View(kiraList);
        }

        
    }
}
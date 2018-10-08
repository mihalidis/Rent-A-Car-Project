using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierRentACar.UI.Areas.Admin.Controllers
{
    public class BillsController : Controller
    {
        BillService _billService;
        public BillsController()
        {
            _billService = new BillService();
        }
        // GET: Admin/Bills
        public ActionResult List()
        {
            List<Bill> fatura = _billService.GetActive();
            return View(fatura);
        }
    }
}
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierRentACar.UI.Areas.Admin.Models
{
    public class CarVM
    {
        public Car araba { get; set; }        
        public List<CarBrand> aracmarka { get; set; }
    }
}
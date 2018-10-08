using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierRentACar.UI.Models
{
    public class RentVM
    {
        public List<Car> car { get; set; }
        public Rent rent { get; set; }
        
    }
}
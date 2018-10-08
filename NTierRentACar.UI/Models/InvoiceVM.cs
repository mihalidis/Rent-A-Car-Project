using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierRentACar.UI.Models
{
    public class InvoiceVM
    {
        public UserDetail Kiralayan { get; set; }
        public Rent Kiralama { get; set; }
        public Guid? FaturaInfo { get; set; }
        public string AracAdi { get; set; }
        public int KiralananGun { get; set; }
        public int? Ucret { get; set; }
    }
}
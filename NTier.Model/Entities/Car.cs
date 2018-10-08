using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    
    public class Car:CoreEntity
    {
        public string CModel { get; set; }
        public string ImageUrl { get; set; }
        public int? CostPerDay { get; set; }
        public string PersonCapacity { get; set; }
        public string BaggageCapacity { get; set; }
        public string MinRentAge { get; set; }
        public string Gearbox { get; set; }                
        public string FuelType { get; set; }
       

             
        public Guid CarBrandID { get; set; }
                
        
        public virtual CarBrand CarBrand { get; set; }
        public virtual List<Rent> Rents { get; set; }
        
        
        
    }
}

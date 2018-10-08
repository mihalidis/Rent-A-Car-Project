using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class CarMap:CoreMap<Car>
    {
        public CarMap()
        {
            ToTable("Cars");
            Property(x => x.CModel).IsOptional();
            Property(x => x.ImageUrl).IsOptional();
            Property(x => x.CostPerDay).IsOptional();
            Property(x => x.PersonCapacity).IsOptional();
            Property(x => x.BaggageCapacity).IsOptional();
            Property(x => x.MinRentAge).IsOptional();
            Property(x => x.Gearbox).IsOptional();                        
            Property(x => x.FuelType).IsOptional();

            HasMany(x => x.Rents).WithRequired(x => x.Car).HasForeignKey(x => x.CarID);
            HasRequired(x => x.CarBrand).WithMany(x => x.Cars).HasForeignKey(x => x.CarBrandID);
            
        }
    }
}

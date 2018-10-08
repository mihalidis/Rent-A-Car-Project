using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class CarBrandMap:CoreMap<CarBrand>
    {
        public CarBrandMap()
        {
            ToTable("CarBrands");
            Property(x => x.BrandName).HasMaxLength(50).IsOptional();
            Property(x => x.Description).IsOptional();

            HasMany(x => x.Cars).WithRequired(x => x.CarBrand).HasForeignKey(x => x.CarBrandID);
        }
    }
}

using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class CarBrand:CoreEntity
    {
        public string BrandName { get; set; }
        public string Description { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}

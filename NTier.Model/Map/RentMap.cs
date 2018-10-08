
using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class RentMap:CoreMap<Rent>
    {
        public RentMap()
        {
            ToTable("Rents");
            Property(x => x.StartDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.EndDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.PickUpPlace).IsOptional();
            Property(x => x.DropPlace).IsOptional();
            Property(x => x.Paid).IsOptional();
            Property(x => x.Billed).IsOptional();
            Property(x => x.Returned).IsOptional();

            HasRequired(x => x.Car).WithMany(x => x.Rents).HasForeignKey(x => x.CarID);
            HasRequired(x => x.UserDetail).WithMany(x => x.Rents).HasForeignKey(x => x.UserID);

        }
    }
}

using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class BillMap:CoreMap<Bill>
    {
        public BillMap()
        {
            ToTable("Bills");
            Property(x => x.Date).HasColumnType("datetime2").IsOptional();
            Property(x => x.Cost).IsOptional();

            HasRequired(x => x.UserDetails).WithMany(x => x.Bills).HasForeignKey(x => x.UserID);
        }
    }
}

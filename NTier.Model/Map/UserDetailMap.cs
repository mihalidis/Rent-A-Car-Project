using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class UserDetailMap:CoreMap<UserDetail>
    {
        public UserDetailMap()
        {
            ToTable("UserDetails");

            Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsRequired();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.Role).IsOptional();                                    
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();  
            
            HasMany(x => x.Rents).WithRequired(x => x.UserDetail).HasForeignKey(x => x.UserID);
            HasMany(x => x.Bills).WithRequired(x => x.UserDetails).HasForeignKey(x => x.UserID);
        }
    }
}

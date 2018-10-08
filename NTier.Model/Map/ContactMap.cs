using NTier.Core.Map;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Map
{
    public class ContactMap:CoreMap<Contact>
    {
        public ContactMap()
        {
            ToTable("Contacts");
            Property(x => x.Email).HasMaxLength(50).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.Subject).IsOptional();
            Property(x => x.Phone).IsOptional();
            Property(x => x.Message).IsOptional();
           
        }
    }
}

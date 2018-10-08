using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class Bill:CoreEntity
    {
        public DateTime? Date { get; set; }
        public int? Cost { get; set; }

        
        public Guid UserID { get; set; }
        
        
        public virtual UserDetail UserDetails { get; set; }
    }
}

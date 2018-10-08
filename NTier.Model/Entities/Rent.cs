using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public class Rent:CoreEntity
    {
        public Rent()
        {
            this.Returned = false;
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PickUpPlace { get; set; }
        public string DropPlace { get; set; }
        public bool Paid { get; set; }
        public bool Billed { get; set; }
        public bool Returned { get; set; }

        public Guid UserID { get; set; }                
        public Guid CarID { get; set; }
        
        public virtual UserDetail UserDetail { get; set; }        
        public virtual Car Car { get; set; }
        
        

        
        
    }
}

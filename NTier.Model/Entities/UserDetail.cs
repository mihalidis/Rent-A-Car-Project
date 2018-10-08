using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3
    }
    public enum Gender
    {
        None = 0,
        Female = 1,
        Male = 3,
        Other = 5
    }
    
    public class UserDetail:CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }        
        public Role? Role { get; set; }               
        public DateTime? BirthDate { get; set; }


        public virtual List<Rent> Rents { get; set; }
        public virtual List<Bill> Bills { get; set; }
        



    }
}

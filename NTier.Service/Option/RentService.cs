using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class RentService : BaseService<Rent>
    {
        Rent kiralama = new Rent();
        public bool ReturnCar()
        {
           
            try
            {
                kiralama.Returned = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckDate()
        {
            if (kiralama.StartDate <= kiralama.EndDate && kiralama.StartDate >= DateTime.Now.Date && kiralama.EndDate >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }






    }
}

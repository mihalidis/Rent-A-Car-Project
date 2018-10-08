using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class BillService:BaseService<Bill>
    {
        public void CalculateTotalCost(DateTime startDate, DateTime endDate, int costPerDay)
        {
            var days = (int)endDate.Subtract(startDate).TotalDays + 1;
            Bill fatura = new Bill();
            fatura.Cost = days * costPerDay;
        }
    }
}

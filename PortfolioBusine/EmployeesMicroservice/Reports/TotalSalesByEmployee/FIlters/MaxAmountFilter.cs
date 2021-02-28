using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.Reports.TotalSalesByEmployee.FIlters
{
    public class MaxAmountFilter : ICriteria
    {
        decimal? _maxAmount;

        //constructor
        public MaxAmountFilter(decimal? maxAmount)
        {
            _maxAmount = maxAmount;
        }

        public IEnumerable<ITotalSalesByEmployee> meetCriteria(IEnumerable<ITotalSalesByEmployee> reportData)
        {
            return reportData
                .Where(s => s.salesSum <= _maxAmount)
                .ToList();
        }
    }
}

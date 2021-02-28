using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.Reports.TotalSalesByEmployee.FIlters
{
    public class MinAmountFilter : ICriteria
    {
        decimal? _minAmount;

        //constructor
        public MinAmountFilter(decimal? minAmount)
        {
            _minAmount = minAmount;
        }

        public IEnumerable<ITotalSalesByEmployee> meetCriteria(IEnumerable<ITotalSalesByEmployee> reportData)
        {
            return reportData
                .Where(s => s.salesSum >= _minAmount)
                .ToList();
        }
    }
}

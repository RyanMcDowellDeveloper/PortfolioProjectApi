using EmployeesMicroservice.ReportModels.TotalSalesByEmployee;
using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesMicroservice.EFModels;

namespace EmployeesMicroservice.Reports.TotalSalesByEmployee
{

    class EmployeeSales
    {
        public string employeeName { get; set; }
        public decimal? orderAmount { get; set; }
    }

    public class GetEmployeeTotalSales : IGetEmployeeTotalSales
    {
        public IEnumerable<ITotalSalesByEmployee> GetData()
        {
            using (var portfolioContext = new PortfolioProjectContext())
            {
                var queryResult = (from emp in portfolioContext.Employees
                                   join ord in portfolioContext.Orders on emp.UserId equals ord.UserId
                                   join prod in portfolioContext.Products on ord.ProductId equals prod.ProductId 
                                   select new EmployeeSales
                                   {
                                       employeeName = emp.FirstName + " " + emp.LastName,
                                       orderAmount = prod.Price
                                   });

                return queryResult
                    .GroupBy(g => g.employeeName)
                    .Select(s => new TotalSalesByEmployeeModel
                    {
                        employeeName = s.Key,
                        salesCount = s.Count(),
                        salesSum = s.Sum(s1 => s1.orderAmount),
                    }).ToList<ITotalSalesByEmployee>();
            }
        }
    }
}

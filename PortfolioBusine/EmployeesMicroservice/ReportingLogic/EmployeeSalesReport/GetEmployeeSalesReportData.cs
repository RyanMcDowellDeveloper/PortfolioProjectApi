using EmployeesMicroservice.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesMicroservice.EFModels;

namespace EmployeesMicroservice.ReportingLogic.EmployeeSalesReport
{
    public class GetEmployeeSalesReportData
    {
        IApplyQueryFilters _applyFilters = new ApplyQueryFilters();
        IEmployeeSalesReportParams _reportParams;

        //constructor
        public GetEmployeeSalesReportData(IEmployeeSalesReportParams reportParams)
        {
            _reportParams = reportParams;
        }

        public IEnumerable<IEmployeeSalesReportData> GetReportData()
        {
            var reportData = new List<IEmployeeSalesReportData>();

            using (PortfolioProjectContext portfolioContext = new PortfolioProjectContext())
            {
                var queryResult = (from emp in portfolioContext.Employees
                                   join ord in portfolioContext.Orders on emp.UserId equals ord.UserId
                                   join prod in portfolioContext.Products on ord.ProductId equals prod.ProductId
                                   join prodCat in portfolioContext.ProductCategories on prod.ProductCategoryId equals prodCat.ProductCategoryId
                                   //where _reportParams.employeeId.Contains(emp.UserId)
                                   select new EmployeeSalesReportData
                                   {
                                       employeeFullName = emp.FirstName + " " + emp.LastName,
                                       saleDate = ord.SaleDate,
                                       salePrice = prod.Price,
                                       productDescription = prod.Description,
                                       productCategory = prodCat.CategoryName,
                                       userID = emp.UserId
                                   });

                reportData = _applyFilters.filter(_reportParams, queryResult).ToList();
            }

            return reportData;
        }
    }
}


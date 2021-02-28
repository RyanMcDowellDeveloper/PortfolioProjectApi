using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMicroservice.ReportModels
{
    public class EmployeeSalesReportData : IEmployeeSalesReportData
    {
        public string employeeFullName { get; set; }
        public decimal? salePrice { get; set; }
        public DateTime saleDate { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public int userID { get; set; }
    }
}

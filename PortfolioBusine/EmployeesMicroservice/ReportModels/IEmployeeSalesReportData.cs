using System;

namespace EmployeesMicroservice.ReportModels
{
    public interface IEmployeeSalesReportData
    {
        string employeeFullName { get; set; }
        DateTime saleDate { get; set; }
        decimal? salePrice { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public int userID { get; set; }
    }
}
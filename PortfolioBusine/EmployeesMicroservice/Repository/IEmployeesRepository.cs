using EmployeesMicroservice.EFModels;
using EmployeesMicroservice.ReportModels;
using System.Collections.Generic;

namespace EmployeesMicroservice.Repository
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployees(int id);
        void UpdateEmployee(Employee employee);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        IEnumerable<IEmployeeSalesReportData> GetEmployeeSalesReport(EmployeeSalesReportParams reportParams);
    }
}
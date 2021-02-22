using EmployeesMicroservice.EFModels;
using EmployeesMicroservice.ReportingLogic.EmployeeSalesReport;
using EmployeesMicroservice.ReportModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeesMicroservice.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            using (var dbContext = new PortfolioProjectContext())
            {
                employees = dbContext.Employees.ToList();
            }

            return employees;
        }

        public Employee GetEmployees(int id)
        {
            var employees = new Employee();

            using (var dbContext = new PortfolioProjectContext())
            {
                employees = dbContext.Employees
                    .Where(x => x.UserId == id)
                    .SingleOrDefault();
            }
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var dbContext = new PortfolioProjectContext())
            {
                dbContext.Entry(employee).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void CreateEmployee(Employee employee)
        {
            using (var dbContext = new PortfolioProjectContext())
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var dbContext = new PortfolioProjectContext())
            {
                var emp = dbContext.Employees
                    .FirstOrDefault(x => x.UserId == employeeId);

                if (emp != null)
                {
                    dbContext.Employees.Remove(emp);
                    dbContext.SaveChanges();
                }
            }
        }

        public IEnumerable<IEmployeeSalesReportData> GetEmployeeSalesReport(EmployeeSalesReportParams reportParams)
        {
            var getReports = new GetEmployeeSalesReportData(reportParams);
            return getReports.GetReportData();
        }

    }
}

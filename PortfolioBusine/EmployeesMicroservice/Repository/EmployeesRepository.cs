using EmployeesMicroservice.EFModels;
using EmployeesMicroservice.ReportingLogic.EmployeeSalesReport;
using EmployeesMicroservice.ReportModels;
using EmployeesMicroservice.ReportModels.TotalSalesByEmployee;
using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmployeesMicroservice.Reports.TotalSalesByEmployee;
using EmployeesMicroservice.Reports.TotalSalesByEmployee.FIlters;

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
            var getReportData = new GetEmployeeSalesReportData(reportParams);
            return getReportData.GetReportData();
        }

        public IEnumerable<ITotalSalesByEmployee> GetTotalEmployeeSalesReport(TotalSalesByEmployeeParams reportParams)
        {
            var getEmployeeTotal = new GetEmployeeTotalSales();
            ICriteria criteria;

            var reporData = getEmployeeTotal.GetData();

            if (reportParams.maxSalary != null)
            {
                criteria = new MaxAmountFilter(reportParams.maxSalary);
                reporData = criteria.meetCriteria(reporData);
            }

            if (reportParams.minSalary != null)
            {
                criteria = new MinAmountFilter(reportParams.minSalary);
                reporData = criteria.meetCriteria(reporData);
            }
            return reporData;
        }

        public IEnumerable<City> GetCities()
        {
            var cities = new List<City>();

            using (var portfolioContext = new PortfolioProjectContext())
            {
                cities = portfolioContext
                    .Cities
                    .OrderBy(s => s.City1)
                    .ToList();
            }
            return cities;
        }

    }
}

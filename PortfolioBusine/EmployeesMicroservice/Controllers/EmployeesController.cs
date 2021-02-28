using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesMicroservice.EFModels;
using EmployeesMicroservice.ReportingLogic.EmployeeSalesReport;
using EmployeesMicroservice.ReportModels;
using EmployeesMicroservice.ReportModels.TotalSalesByEmployee;
using EmployeesMicroservice.Reports.TotalSalesByEmployee.Models;
using EmployeesMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMicroservice.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeesRepository _employeesRepository;

        //constructor
        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        // GET: EmployeesController
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeesRepository.GetEmployees();
            return new OkObjectResult(employees);
        }

        // GET: EmployeesController/Details/5
        [HttpGet]
        [Route("GetEmployees/{id}")]
        public ActionResult GetEmployees(int id)
        {
            var employee = _employeesRepository.GetEmployees(id);
            return new OkObjectResult(employee);
        }


        // GET: EmployeesController/Edit/5
        [Route("EditEmployee")]
        [HttpPut]
        public ActionResult EditEmployee(Employee employee)
        {
            _employeesRepository.UpdateEmployee(employee);
            return new OkResult();
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public ActionResult CreateEmployee(Employee employee)
        {
            _employeesRepository.CreateEmployee(employee);
            return new OkResult();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            _employeesRepository.DeleteEmployee(employeeId);
            return new OkResult();
        }

        [HttpPost]
        [Route("GetEmployeeSalesReport")]
        public IEnumerable<IEmployeeSalesReportData> GetEmployeeSalesReport(EmployeeSalesReportParams reportParams)
        {
            return _employeesRepository.GetEmployeeSalesReport(reportParams);
        }

        [HttpPost]
        [Route("GetEmployeeTotalSalesReport")]
        public IEnumerable<ITotalSalesByEmployee> GetTotalEmployeeSalesReport(TotalSalesByEmployeeParams reportParams)
        {
            return _employeesRepository.GetTotalEmployeeSalesReport(reportParams);
        }

        [HttpGet]
        [Route("GetListUsaCities")]
        public IEnumerable<City> GetListUsaCities()
        {
            return _employeesRepository.GetCities();
        }
    }
}


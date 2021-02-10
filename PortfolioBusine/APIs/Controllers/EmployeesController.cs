﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.ModelsAzure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [Route("GetEmployees")]
        [HttpGet]
        public IEnumerable<Employee> GetCampaignNameFromProgram()
        {
            var employees = new List<Employee>();

            using (var dbContext = new PortfolioProjectContext())
            {
                employees = dbContext.Employees.ToList();
            }

            return employees;
        }



        [Route("GetEmployees/{id}")]
        [HttpGet]
        public Employee GetCampaignNameFromProgram(int id)
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



    }


}

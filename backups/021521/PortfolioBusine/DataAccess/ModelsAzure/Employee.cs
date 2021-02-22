using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.ModelsAzure
{
    public partial class Employee
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? EmployeeTypeId { get; set; }
        public decimal? PayRate { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesMicroservice.EFModels
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string AccountName { get; set; }
    }
}

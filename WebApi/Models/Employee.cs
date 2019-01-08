using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
    }
}
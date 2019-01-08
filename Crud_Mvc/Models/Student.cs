using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_Mvc.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public String StudentId { get; set; }
        public String StudentName { get; set; }    
        public String Address { get; set; }
        public String City { get; set; }
        public String EmailId { get; set; }
    }
}
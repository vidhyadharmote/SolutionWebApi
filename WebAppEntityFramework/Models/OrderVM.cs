using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEntityFramework.Models
{
    public class OrderVM
    {
        public int? Id { get; set; }
        public string ItemName { get; set; }
        public string EmpName { get; set; }
        public int? Price { get; set; }
        public string Descr { get; set; }
        
    }
}
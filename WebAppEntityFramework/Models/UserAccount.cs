using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppEntityFramework.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage ="User name is required")]
        public string Name { get; set; }
        public string Passwd { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserType { get; set; }

    }
}
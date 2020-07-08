using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class CustomerModel
    {
        [Display(Name = "First Name")]
        public string FName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}

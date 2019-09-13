using CarRentCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CarRentProjectCore.Models.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required,StringLength(55), ]
        public string Name { get; set; }
        [EmailAddress,Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Required,Display(Name="Phone No")]
        [RegularExpression(@"^[0-9]{11,11}$", ErrorMessage = "Phone Number Must 11 Digits!"), StringLength(11)]
        public string Contract { get; set; }

        [Required,StringLength(255),MinLength(3)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        
        public ICollection<CarRentCoreProject.Models.Customer> CustomerColl { get; set; }
    }
}

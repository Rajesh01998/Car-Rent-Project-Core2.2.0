using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentCoreProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Contract { get; set; }
        public string Address { get; set; }
        public bool IsDelete { get; set; }
        public List<RentRequest> RentRequests { get; set; }
        public List<Notification> Notifications { get; set; }

       
    }
}

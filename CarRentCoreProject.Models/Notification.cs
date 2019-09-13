using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace CarRentCoreProject.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public DateTime NotificationDateTime { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("RentRequest")]
        public int RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }
        public bool IsDelete { get; set; }

    }
}

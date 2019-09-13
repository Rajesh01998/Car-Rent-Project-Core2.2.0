using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentProjectCore.Models.Notification
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        [Required,StringLength(255)]
        public string Status { get; set; }

        public string Details { get; set; }
        public DateTime NotificationDateTime { get; set; }

        public int CustomerId { get; set; }
        public CarRentCoreProject.Models.Customer Customer { get; set; }

        public int RentRequestId { get; set; }
        public CarRentCoreProject.Models.RentRequest RentRequest { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRentCoreProject.Models
{
    public class RentRequest
    {
        public int Id { get; set; }
        public string FromPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public string ToPlace { get; set; }
        public DateTime EndDateTime { get; set; }
        public int VehicleQty { get; set; }
        public string Description { get; set; }
        public string AirCondition { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("VehicleType")]
        public int VehiceTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public bool IsDelete { get; set; }
        public List<RentAssign> RentAssigns { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}

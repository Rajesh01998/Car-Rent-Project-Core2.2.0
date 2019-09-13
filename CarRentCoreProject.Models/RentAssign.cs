using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRentCoreProject.Models
{
    public class RentAssign
    {
        public int Id { get; set; }
        public double RentPrice { get; set; }
        public string Status { get; set; }
        public DateTime RentAssignDateTime { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleId { get; set; }
        public VehicleType VehicleType { get; set; }

        [ForeignKey("RentRequest")]
        public int RentRequestId { get; set; }
        public RentRequest RentRequest { get; set; }
        public string Comment { get; set; }
        public bool IsDelete { get; set; }
    }
}

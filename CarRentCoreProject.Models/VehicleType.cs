using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentCoreProject.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public List<RentRequest> RentRequests { get; set; }
        public List<RentAssign> RentAssigns { get; set; }
    }
}

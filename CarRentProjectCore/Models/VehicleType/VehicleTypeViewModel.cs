using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentProjectCore.Models.VehicleType
{
    public class VehicleTypeViewModel
    {
        public int Id { get; set; }
        [Required,StringLength(55),MinLength(3)]
        public string Name { get; set; }
        public ICollection<CarRentCoreProject.Models.VehicleType> vehicleCollection { get; set; }
    }
}

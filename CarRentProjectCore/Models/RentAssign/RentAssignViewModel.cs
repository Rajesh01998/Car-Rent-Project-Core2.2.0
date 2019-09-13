
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentProjectCore.Models.RentAssign
{
    public class RentAssignViewModel
    {
        public int Id { get; set; }

        [Required,Display(Name = "Rent Price")]
        public double RentPrice { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [DataType(DataType.DateTime),Display(Name = "Assign Date")]
        public DateTime RentAssignDateTime { get; set; }
       [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Vehicle")]
        public CarRentCoreProject.Models.VehicleType VehicleType { get; set; }

        [Display(Name = "Rent Request")]
        public int RentRequestId { get; set; }
        [Display(Name = "Request")]
        public CarRentCoreProject.Models.RentRequest RentRequest { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }

       
        public ICollection<SelectListItem>GetAllVehicleTypelookUpdata { get; set; }
        public ICollection<SelectListItem> GetVehicleData { get; set; }
        public ICollection<SelectListItem> GetRentReq { get; set; }
    }
}

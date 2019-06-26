using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarRentCoreProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CarRentProjectCore.Models.RentRequest
{
    public class RentRequestViewModel
    {
        public int Id { get; set; }
        [Required,StringLength(255)]
        [Display(Name = "Destination Point")]
        public string FromPlace { get; set; }
        [Display(Name ="Start Date Time")]
        public DateTime StartDateTime { get; set; }

        [Required, StringLength(255)]
        [Display(Name ="End Point")]
        public string ToPlace { get; set; }
        [Display(Name ="End Date Time")]
        public DateTime EndDateTime { get; set; }

        [Required,Display(Name ="Quentity")]
        public int VehicleQty { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage ="Please Select AC or Non-AC!")]
        [Display(Name ="AC/NON-AC")]
        public string AirCondition { get; set; }
        [Display(Name ="Name")]
        public int CustomerId { get; set; }
        public CarRentCoreProject.Models. Customer Customer { get; set; }
        [Display(Name ="Vehicle Name")]
        public int VehiceTypeId { get; set; }
        public CarRentCoreProject.Models.VehicleType VehicleType { get; set; }
        public ICollection<CarRentCoreProject.Models.RentRequest> RentList { get; set; }
        public ICollection<SelectListItem> CustoemrLookUpdata { get; set; }
        public ICollection<SelectListItem> VehicleTypeLookupData { get; set; }
    }
}


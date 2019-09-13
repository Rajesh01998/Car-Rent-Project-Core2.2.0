using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentProjectCore.Utility
{
    public interface IUtilityManager
    {
        ICollection<SelectListItem> GetAllCustomerLookUpdata();
        ICollection<SelectListItem> GetAllVehicleTypelookUpdata();
        ICollection<SelectListItem> GetRentReq();
       
    }
}

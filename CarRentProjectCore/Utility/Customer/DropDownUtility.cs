using CarRentProjectCore.Manager.Contract;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentProjectCore.Utility.Customer
{
    public class DropDownUtility:IUtilityManager
    {
        private ICustomerManager _customerManager;
       private IVehicleTypeManager _vehicleTypeManager;

        public DropDownUtility(ICustomerManager customerManager, IVehicleTypeManager vehicleTypeManager)
        {
            _customerManager = customerManager;
            _vehicleTypeManager = vehicleTypeManager;
        }

        public ICollection<SelectListItem> GetAllCustomerLookUpdata()
        {
            return _customerManager.GetAllCustomer().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        public ICollection<SelectListItem> GetAllVehicleTypelookUpdata()
        {
            return _vehicleTypeManager.GetAllVehicle().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}

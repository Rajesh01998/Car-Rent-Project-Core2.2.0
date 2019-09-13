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
        private readonly ICustomerManager _customerManager;
       private readonly IVehicleTypeManager _vehicleTypeManager;
       private readonly IRentRequestManager _rentRequestManager;
       private readonly IRentAssignManager _rentAssignManager;

        public DropDownUtility(ICustomerManager customerManager, IVehicleTypeManager vehicleTypeManager,IRentRequestManager rentRequestManager,IRentAssignManager rentAssignManager)
        {
            _customerManager = customerManager;
            _vehicleTypeManager = vehicleTypeManager;
            _rentRequestManager = rentRequestManager;
            _rentAssignManager = rentAssignManager;
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

        public ICollection<SelectListItem> GetRentReq()
        {
            return _rentRequestManager.GetAllRentRequest().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Customer.Name
            }).ToList();
        }

        
    }
}

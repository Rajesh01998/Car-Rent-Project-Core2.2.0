using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Models.Customer;
using CarRentProjectCore.Models.VehicleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentProjectCore.ConfiguringAutomapper
{
    public class CustomerAutomapper:Profile
    {
        public CustomerAutomapper()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<VehicleType, VehicleTypeViewModel>();
            CreateMap<VehicleTypeViewModel, VehicleType>();
        }
    }
}

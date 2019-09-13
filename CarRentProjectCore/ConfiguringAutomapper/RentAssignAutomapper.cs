using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Models.RentAssign;

namespace CarRentProjectCore.ConfiguringAutomapper
{
    public class RentAssignAutomapper:Profile
    {
        public RentAssignAutomapper()
        {
            CreateMap<RentAssign, RentAssignViewModel>();
            CreateMap<RentAssignViewModel, RentAssign>();
        }
    }
}

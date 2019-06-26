using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Models.RentRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentProjectCore.ConfiguringAutomapper
{
    public class RentRequestAutoMapper:Profile
    {
        public RentRequestAutoMapper()
        {
            CreateMap<RentRequest, RentRequestViewModel>();
            CreateMap<RentRequestViewModel, RentRequest>();
        }
    }
}

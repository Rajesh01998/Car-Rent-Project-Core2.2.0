using CarRentCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Repository.Contract
{
    public interface IVehicleTypeRepository:IBaseRepository<VehicleType>
    {
        VehicleType GetVehicleById(int id);
        ICollection<VehicleType> GetAllVehicle();
    }
}

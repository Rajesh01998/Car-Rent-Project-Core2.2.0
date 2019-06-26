using CarRentCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager.Contract
{
    public interface IVehicleTypeManager:IBaseManager<VehicleType>
    {
        VehicleType GetVehicleById(int id);
        ICollection<VehicleType> GetAllVehicle();
    }
}

using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.BaseManager;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager
{
    public class VehicleTypeManager:BaseManager<VehicleType>,IVehicleTypeManager
    {
        private IVehicleTypeRepository _vehicleTypeRepository;
        public VehicleTypeManager(IVehicleTypeRepository vehicleTypeRepository):base(vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public VehicleType GetVehicleById(int id)
        {
            return _vehicleTypeRepository.GetVehicleById(id);
        }
        public ICollection<VehicleType> GetAllVehicle()
        {
            return _vehicleTypeRepository.GetAllVehicle();
        }
    }
}

using CarRentCoreProject.Models;
using CarRentProject.DBContext;
using CarRentProjectCore.Repository.Base;
using CarRentProjectCore.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRentProjectCore.Repository
{
    public class VehicleTypeRepository:BaseRepository<VehicleType>,IVehicleTypeRepository
    {
        private CarRentDBContext context {
            get { return (CarRentDBContext)db; }
        }
        private DbContext db;
        public VehicleTypeRepository(DbContext db):base(db)
        {
            this.db = (CarRentDBContext)db;
        }
        public VehicleType GetVehicleById(int id)
        {
            return context.VehicleTypes.Find(id);
        }
        public ICollection<VehicleType> GetAllVehicle()
        {
            return context.VehicleTypes.Where(c => c.IsDelete == false).ToList();

        }
    }
}

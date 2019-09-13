using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CarRentCoreProject.Models;
using CarRentProject.DBContext;
using CarRentProjectCore.Repository.Base;
using CarRentProjectCore.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace CarRentProjectCore.Repository
{
    public class RentAssignRepository:BaseRepository<RentAssign>,IRentAssignRepository
    {
        private DbContext db;
        
        public CarRentDBContext context
        {
            get { return (CarRentDBContext) db; }
        }
        public RentAssignRepository(DbContext db) : base(db)
        {
            this.db = (CarRentDBContext) db;
        }

        public ICollection<RentAssign> GetAllRentAssign()
        {
          return  context.RentAssigns.Where(r => r.IsDelete == false).Include(r=>r.VehicleType)
              .Include(r => r.RentRequest).ThenInclude(r=>r.Customer).ToList();
        }

        public RentAssign GetRentAssignById(int? id)
        {
            return context.RentAssigns.Include(r => r.RentRequest).ThenInclude(c=>c.Customer).Include(c => c.VehicleType).FirstOrDefault(d=>d.Id==id);
        }

        public RentRequest GetRentRequest(int? assignReqId)
        {
            return context.RentRequests.FirstOrDefault(c => c.Id == assignReqId);
        }
    }
}

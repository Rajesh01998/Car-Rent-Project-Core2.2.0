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
    public class RentRequestRepository:BaseRepository<RentRequest>,IRentRequestRepository
    {
        private DbContext db;
        public RentRequestRepository(DbContext db):base(db)
        {
            this.db = (DbContext)db;
        }
        public CarRentDBContext Context { get
            {
                return (CarRentDBContext)db;
            }
        }

        public ICollection<RentRequest> GetAllRentRequest()
        {
            return Context.RentRequests.Include(r=>r.Customer).Include(r=>r.VehicleType).Where(c => c.IsDelete == false).ToList();
        }

        public RentRequest GetRentRequestById(int id)
        {
            return Context.RentRequests.Find(id);
        }

        public RentRequest GetRentRequestwithNameById(int id)
        {
            return Context.RentRequests.Include(c=>c.Customer).Include(c=>c.VehicleType).SingleOrDefault(d=>d.Id==id);
        }

    }
}

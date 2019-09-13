using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;

namespace CarRentProjectCore.Repository.Contract
{
    public interface IRentAssignRepository:IBaseRepository<RentAssign>
    {
        ICollection<RentAssign> GetAllRentAssign();
        RentAssign GetRentAssignById(int? id);
        RentRequest GetRentRequest(int? assignReqId);
    }
}

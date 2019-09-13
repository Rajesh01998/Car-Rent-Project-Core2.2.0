using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;

namespace CarRentProjectCore.Manager.Contract
{
    public interface IRentAssignManager:IBaseManager<RentAssign>
    {
        ICollection<RentAssign> GetAllRentAssign();
        RentAssign GetRentAssignById(int? id);
        RentRequest GetRentRequest(int? assignReqId);
    }
}

using CarRentCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager.Contract
{
    public interface IRentRequestManager:IBaseManager<RentRequest>
    {
        ICollection<RentRequest> GetAllRentRequest();
        RentRequest GetRentRequestById(int id);
        RentRequest GetRentRequestwithNameById(int id);
    }
}

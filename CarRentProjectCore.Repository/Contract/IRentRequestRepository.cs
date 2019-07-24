using CarRentCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Repository.Contract
{
    public interface IRentRequestRepository:IBaseRepository<RentRequest>
    {
        ICollection<RentRequest> GetAllRentRequest();
        RentRequest GetRentRequestById(int id);
        RentRequest GetRentRequestwithNameById(int id);
    }
}

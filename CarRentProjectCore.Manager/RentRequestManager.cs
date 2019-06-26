using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.BaseManager;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager
{
    public class RentRequestManager:BaseManager<RentRequest>,IRentRequestManager
    {
        private IRentRequestRepository _rentRequestRepository;
        public RentRequestManager(IRentRequestRepository rentRequestRepository):base(rentRequestRepository)
        {
            _rentRequestRepository = rentRequestRepository;
        }
        public ICollection<RentRequest> GetAllRentRequest()
        {
            return _rentRequestRepository.GetAllRentRequest();
        }
    }
}

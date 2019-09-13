using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.BaseManager;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Repository.Contract;

namespace CarRentProjectCore.Manager
{
    public class RentAssignManager:BaseManager<RentAssign>,IRentAssignManager
    {
        private IRentAssignRepository _rentAssignRepository;
        public RentAssignManager(IRentAssignRepository rentAssignRepository ) : base(rentAssignRepository)
        {
            _rentAssignRepository = rentAssignRepository;
        }

        public ICollection<RentAssign> GetAllRentAssign()
        {
            return _rentAssignRepository.GetAllRentAssign();
        }

        public RentAssign GetRentAssignById(int? id)
        {
            return _rentAssignRepository.GetRentAssignById(id);
        }

        public RentRequest GetRentRequest(int? assignReqId)
        {
            return _rentAssignRepository.GetRentRequest(assignReqId);
        }
    }
}

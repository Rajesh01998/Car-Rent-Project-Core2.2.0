using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;

namespace CarRentProjectCore.Repository.Contract
{
    public interface INotificationRepository:IBaseRepository<Notification>
    {
        ICollection<Notification> GetAllNotification();
    }
}

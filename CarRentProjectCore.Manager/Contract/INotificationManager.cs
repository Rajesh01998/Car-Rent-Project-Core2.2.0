using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;

namespace CarRentProjectCore.Manager.Contract
{
    public interface INotificationManager:IBaseManager<Notification>
    {
        ICollection<Notification> GetAllNotification();
    }
}

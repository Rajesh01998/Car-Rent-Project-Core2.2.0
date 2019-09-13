using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.BaseManager;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Repository.Contract;

namespace CarRentProjectCore.Manager
{
    public class NotificationManager:BaseManager<Notification>,INotificationManager
    {
        private INotificationRepository _notificationRepository;
        public NotificationManager( INotificationRepository baseRepository) : base(baseRepository)
        {
            _notificationRepository = baseRepository;
        }

        public ICollection<Notification> GetAllNotification()
        {
           return _notificationRepository.GetAllNotification();
        }
    }
}

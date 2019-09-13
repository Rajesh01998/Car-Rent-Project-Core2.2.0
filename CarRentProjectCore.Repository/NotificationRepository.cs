using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRentCoreProject.Models;
using CarRentProject.DBContext;
using CarRentProjectCore.Repository.Base;
using CarRentProjectCore.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace CarRentProjectCore.Repository
{
    public class NotificationRepository:BaseRepository<Notification>,INotificationRepository
    {
        private DbContext db;

        public CarRentDBContext context
        {
            get { return (CarRentDBContext) db; }
        }
        public NotificationRepository(DbContext db) : base(db)
        {
            this.db = (CarRentDBContext) db;
        }

        public ICollection<Notification> GetAllNotification()
        {
            return context.Notifications.Where(r => r.IsDelete == false).Include(c => c.Customer)
                .Include(c => c.RentRequest).ToList();
        }
    }
}

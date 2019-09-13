using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Models.Notification;

namespace CarRentProjectCore.ConfiguringAutomapper
{
    public class NotifiacationAutomapper:Profile
    {
        public NotifiacationAutomapper()
        {
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<NotificationViewModel, Notification>();
        }
    }
}

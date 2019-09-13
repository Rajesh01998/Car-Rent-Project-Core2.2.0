using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Models.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentProjectCore.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationManager _notificationManager;
        private readonly IMapper _mapper;
        public NotificationController(INotificationManager notificationManager,IMapper mapper)
        {
            _notificationManager = notificationManager;
            _mapper = mapper;
        }
        // GET: Notification
        public ActionResult Index()
        {
            var notification = _notificationManager.GetAllNotification();
            if (notification == null)
            {
                return NotFound();
            }

            var notificationView = _mapper.Map<List<NotificationViewModel>>(notification);
            return View(notificationView);
        }

        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notification/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notification/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
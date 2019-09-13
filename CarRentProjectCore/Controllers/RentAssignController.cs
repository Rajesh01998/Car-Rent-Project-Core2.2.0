using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProject.DBContext;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Models.RentAssign;
using CarRentProjectCore.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentProjectCore.Controllers
{
    public class RentAssignController : Controller
    {
        private IRentAssignManager _rentAssignManager;
        private IUtilityManager _utilityManager;
        private INotificationManager _notificationManager;
        private IMapper _mapper;

        public RentAssignController(IRentAssignManager rentAssignManager,IMapper mapper,IUtilityManager utilityManager,INotificationManager notificationManager)
        {
            _rentAssignManager = rentAssignManager;
            _mapper = mapper;
            _utilityManager = utilityManager;
            _notificationManager = notificationManager;
        }
        
        // GET: RentAssign
        public ActionResult Index()
        {
            var assign = _rentAssignManager.GetAllRentAssign();
            if (assign == null)
            {
                return NotFound();
            }

            var assignView = _mapper.Map < List<RentAssignViewModel>> (assign);
            return View(assignView);
        }

        // GET: RentAssign/Details/5
        public ActionResult Details(int? id)
        {
            var assignDetails = _rentAssignManager.GetRentAssignById(id);
            if (assignDetails == null)
            {
                return NotFound();
            }
            var assignDetailsView = _mapper.Map<RentAssignViewModel>(assignDetails);
            return View(assignDetailsView);
        }

        //GET: RentAssign/Assign
        public ActionResult Assign(int reqId)
        {
        
            var viewModel = new RentAssignViewModel();
           
            if (viewModel != null)
            {

                viewModel.GetAllVehicleTypelookUpdata = _utilityManager.GetAllVehicleTypelookUpdata();
                viewModel.RentRequestId = reqId;
                return View(viewModel);
            }

            return NotFound();
        }
        //POST: RentAssign/Assign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(RentAssignViewModel rentAssignViewModel)
        {
            if (ModelState.IsValid)
            {
                var assignView = _mapper.Map<RentAssign>(rentAssignViewModel);
                assignView.Status = "New Rent Request";
                assignView.RentAssignDateTime=DateTime.Now;
                if (assignView.Comment == null)
                {
                    assignView.Comment = "No Comment";
                }

                var IsSuccess = _rentAssignManager.Add(assignView);
                if (IsSuccess)
                {
                    var rentRequest = _rentAssignManager.GetRentRequest(assignView.RentRequestId);
                    if (rentRequest != null)
                    {
                        var notification= new Notification();
                        notification.Status = assignView.Status;
                        notification.NotificationDateTime=DateTime.Now;
                        notification.Details = "Your rent Vehicle is Assigned.";
                        notification.RentRequestId = assignView.RentRequestId;
                        notification.CustomerId = rentRequest.CustomerId;
                        var add = _notificationManager.Add(notification);

                    }
                }

                return RedirectToAction("Index");
            }
            var viewModel = new RentAssignViewModel();
            viewModel.GetAllVehicleTypelookUpdata = _utilityManager.GetAllVehicleTypelookUpdata();
            viewModel.RentRequestId = rentAssignViewModel.RentRequestId;
            return View(viewModel);

        }
        // GET: RentAssign/Create
        public ActionResult Create()
        {
            var viewModel=new RentAssignViewModel();
            if (viewModel != null)
            {
                viewModel.GetVehicleData = _utilityManager.GetAllVehicleTypelookUpdata();
                viewModel.GetRentReq = _utilityManager.GetRentReq();
                return View(viewModel);
            }

            return NotFound();




        }

        // POST: RentAssign/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentAssignViewModel rentAssignViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var assign = _mapper.Map<RentAssign>(rentAssignViewModel);
                    if (assign == null)
                    {
                        return NotFound();
                    }

                    var IsSuccess = _rentAssignManager.Add(assign);
                    if (IsSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return NotFound();
                }

                return View();

            }
            catch
            {
                return View(rentAssignViewModel);
            }
        }

        // GET: RentAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            var assign = _rentAssignManager.GetRentAssignById(id);

          
           
            if (assign == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<RentAssignViewModel>(assign);
            viewModel.GetVehicleData = _utilityManager.GetAllVehicleTypelookUpdata();
            viewModel.GetRentReq = _utilityManager.GetRentReq();

            return View(viewModel);
        }

        // POST: RentAssign/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RentAssignViewModel rentAssignViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var assign = _mapper.Map<RentAssign>(rentAssignViewModel);
                    if (assign == null)
                    {
                        return NotFound();
                    }

                    var IsSuccess = _rentAssignManager.Update(assign);
                    if (IsSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return NotFound();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RentAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            var assign = _rentAssignManager.GetRentAssignById(id);
            if (assign == null)
            {
                return NotFound();
            }

            var assignView = _mapper.Map<RentAssignViewModel>(assign);
            return View(assignView);
        }

        // POST: RentAssign/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeeleteConfrim(int? id)
        {
            try
            {
                // TODO: Add delete logic here
                var assign = _rentAssignManager.GetRentAssignById(id);
                if (assign == null)
                {
                    return NotFound();
                }

                assign.IsDelete = true;
                var IsUpdate = _rentAssignManager.Update(assign);
                if (IsUpdate)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
               
            }
            catch
            {
                return View();
            }
        }
    }
}
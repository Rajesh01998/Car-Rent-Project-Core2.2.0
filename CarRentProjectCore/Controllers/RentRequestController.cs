using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Models.RentRequest;
using CarRentProjectCore.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentProjectCore.Controllers
{
    public class RentRequestController : Controller
    {
        private IRentRequestManager _rentrequestManager;
        private IMapper _mapper;
        private IUtilityManager _utility;
        public RentRequestController(IRentRequestManager rentRequestManager,IMapper mapper,IUtilityManager utility)
        {
            _rentrequestManager = rentRequestManager;
            _mapper = mapper;
            _utility = utility;
        }
        // GET: RentRequest
        public ActionResult Index()
        {
            var rentRequest = _rentrequestManager.GetAllRentRequest();
            if (rentRequest == null)
            {
                return StatusCode(418);
            }
            var rentRequestView = _mapper.Map<List<RentRequestViewModel>>(rentRequest);
            return View(rentRequestView);
        }

        // GET: RentRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentRequest/Create
        public ActionResult Create()
        {
            var model = new RentRequestViewModel();
            model.RentList = _rentrequestManager.GetAll();
            model.VehicleTypeLookupData = _utility.GetAllVehicleTypelookUpdata();
            model.CustoemrLookUpdata = _utility.GetAllCustomerLookUpdata();
            return View(model);
        }

        // POST: RentRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentRequestViewModel rentRequestViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    var rentRequest = _mapper.Map<RentRequest>(rentRequestViewModel);
                    var IsAdd = _rentrequestManager.Add(rentRequest);
                    if (IsAdd)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    return NotFound();
                }
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RentRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentRequest/Edit/5
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

        // GET: RentRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentRequest/Delete/5
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
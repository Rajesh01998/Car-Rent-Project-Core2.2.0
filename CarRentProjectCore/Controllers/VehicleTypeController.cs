using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Models.VehicleType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentProjectCore.Controllers
{
    public class VehicleTypeController : Controller
    {
        private IVehicleTypeManager _vehicleTypeManager;
        private IMapper _mapper;
        public VehicleTypeController(IVehicleTypeManager vehicleTypemanager,IMapper mapper)
        {
            _vehicleTypeManager = vehicleTypemanager;
            _mapper = mapper;
        }
        // GET: VehicleType
        public ActionResult Index()
        {
            var vehicle = _vehicleTypeManager.GetAllVehicle();
            var vehiclelist = _mapper.Map<List<VehicleTypeViewModel>>(vehicle);

            return View(vehiclelist);
        }

        // GET: VehicleType/Details/5
        public ActionResult Details(int id)
        {
            var vehicle = _vehicleTypeManager.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var vehicleView = _mapper.Map<VehicleTypeViewModel>(vehicle);
            return View(vehicleView);
        }

        // GET: VehicleType/Create
        public ActionResult Create()
        {
            var model = new VehicleTypeViewModel();
            model.vehicleCollection = _vehicleTypeManager.GetAll();
            return View(model);
        }

        // POST: VehicleType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleTypeViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var vehicletype = _mapper.Map<VehicleType>(collection);
                    var IsSuccess = _vehicleTypeManager.Add(vehicletype);
                    if (IsSuccess)
                    {
                        return RedirectToAction("Index");
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

        // GET: VehicleType/Edit/5
        public ActionResult Edit(int id)
        {
            var vehicle = _vehicleTypeManager.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var vehicleView = _mapper.Map<VehicleTypeViewModel>(vehicle);
            return View(vehicleView);
        }

        // POST: VehicleType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleTypeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var vehicle = _mapper.Map<VehicleType>(model);
                    var IsUpdate = _vehicleTypeManager.Update(vehicle);
                    if (IsUpdate)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    return NotFound();
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleType/Delete/5
        public ActionResult Delete(int id)
        {
            var vehicle = _vehicleTypeManager.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var vehicleView = _mapper.Map<VehicleTypeViewModel>(vehicle);
            return View(vehicleView);
        }

        // POST: VehicleType/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComfrim(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var vehicle = _vehicleTypeManager.GetVehicleById(id);
                if (vehicle != null)
                {
                    vehicle.IsDelete = true;
                    var IsUpdate = _vehicleTypeManager.Update(vehicle);
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
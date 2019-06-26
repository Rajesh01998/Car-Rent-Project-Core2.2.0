using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Models.Customer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentProjectCore.Controllers
{
    public class CustomerController : Controller
    {
        private IMapper _mapper;
        private ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager,IMapper mapper)
        {
            _mapper = mapper;
            _customerManager = customerManager;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerViewModel();
            model.CustomerColl = _customerManager.GetAll();

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerViewModel);
                bool IsSuccess = _customerManager.Add(customer);
                if (IsSuccess)
                {
                    //Save Successfully
                    return RedirectToAction("Index");
                }
            }
           
            customerViewModel.CustomerColl = _customerManager.GetAll();
            return View(customerViewModel);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var customer = _customerManager.GetAllCustomer();
            var customerView = _mapper.Map<List<CustomerViewModel>>(customer);
            return View(customerView);


        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var customer = _customerManager.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerView = _mapper.Map<CustomerViewModel>(customer);
            return View(customerView);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var customer = _customerManager.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerView = _mapper.Map<CustomerViewModel>(customer);
            return View(customerView);

        }
        [HttpPost]
        public IActionResult Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                var IsSave = _customerManager.Update(customer);
                if (IsSave)
                {
                    return RedirectToAction("Index");
                }
                return NotFound();
                
            }
            return View(model);
            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _customerManager.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerView = _mapper.Map<CustomerViewModel>(customer);
            return View(customerView);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfrimed(int id)
        {
            var customer = _customerManager.GetCustomerById(id);
            if (customer != null)
            {
                customer.IsDelete = true;
                var IsSuccess=_customerManager.Update(customer);
                if (IsSuccess)
                {
                    return RedirectToAction("Index");
                }
               
            }
            return NotFound();
           
           
        }
      

    }
}

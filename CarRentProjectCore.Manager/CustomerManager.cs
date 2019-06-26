using CarRentCoreProject.Models;
using CarRentProjectCore.Manager.BaseManager;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager
{
    public class CustomerManager:BaseManager<Customer>,ICustomerManager
    {
        private ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository; 
        }
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }
        public ICollection<Customer> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomer();
        }
    }
}

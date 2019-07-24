using CarRentCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Repository.Contract
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
         Customer GetCustomerById(int id);
        ICollection<Customer> GetAllCustomer();
        
    }
}

using CarRentCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager.Contract
{
    public interface ICustomerManager:IBaseManager<Customer>
    {
        Customer GetCustomerById(int id);
        ICollection<Customer> GetAllCustomer();
    }
}

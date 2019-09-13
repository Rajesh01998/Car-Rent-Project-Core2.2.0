using CarRentCoreProject.Models;
using CarRentProject.DBContext;
using CarRentProjectCore.Repository.Base;
using CarRentProjectCore.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRentProjectCore.Repository
{
    public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        private DbContext db;
        private CarRentDBContext Context
        {
            get {return (CarRentDBContext)db;}
        }
        
        public CustomerRepository(DbContext db):base(db)
        {
            this.db = (CarRentDBContext)db;
        }
       public Customer GetCustomerById(int id)
        {
            return Context.Customers.Find(id);
        }
        public ICollection<Customer> GetAllCustomer()
        {
            return Context.Customers.Where(c => c.IsDelete == false).ToList();
        }

      
    }
}

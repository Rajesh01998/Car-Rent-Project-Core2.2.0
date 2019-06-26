using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager.Contract
{
    public interface IBaseManager<T> where T:class
    {
        bool Add(T entity);
        bool Remove(T entity);
        bool Update(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
    }
}

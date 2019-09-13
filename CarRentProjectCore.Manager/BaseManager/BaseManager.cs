using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentProjectCore.Manager.BaseManager
{
    public class BaseManager<T> : IBaseManager<T> where T : class
    {
        private IBaseRepository<T> _baseRepository;
        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual bool Add(T entity)
        {
            return _baseRepository.Add(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual T GetById(int? id)
        {
            return _baseRepository.GetById(id);
        }

        public virtual bool Remove(T entity)
        {
            return _baseRepository.Remove(entity);
        }

        public virtual bool Update(T entity)
        {
            return _baseRepository.Update(entity);
        }
    }
}

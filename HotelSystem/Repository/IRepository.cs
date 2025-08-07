using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
public    interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        T? GetById(object id);
        List<T> GetAll();



    }
}

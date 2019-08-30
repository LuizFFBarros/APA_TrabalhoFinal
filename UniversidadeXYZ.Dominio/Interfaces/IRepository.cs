using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Dominio.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T Select(int id);
        IList<T> Select();
    }
}

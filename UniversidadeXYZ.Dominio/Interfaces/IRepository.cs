using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Dominio.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Insert(T obj);
        T Update(T obj);
        void Delete(int id);
        T Select(int id);
        IList<T> Select();
    }
}

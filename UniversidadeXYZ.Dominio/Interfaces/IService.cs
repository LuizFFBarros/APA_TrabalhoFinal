using System.Collections.Generic;
using System.Linq;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Dominio.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T Select(int id);
        IList<T> Select();
    }
}

using FluentValidation;
using System.Collections.Generic;
using UniversidadeXYZ.Dominio.Entidades;

namespace UniversidadeXYZ.Dominio.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Insert<V>(T obj) where V : AbstractValidator<T>;
        T Update<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        T Select(int id);
        IList<T> Select();
    }
}

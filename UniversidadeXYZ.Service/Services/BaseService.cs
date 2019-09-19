using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;

namespace UniversidadeXYZ.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> baseRepository = new BaseRepository<T>();
        public void Delete(int id)
        {
            baseRepository.Delete(id);
        }

        public T Insert<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());
            var maxCodigo = baseRepository.GetMaxCodigo();
            obj.Codigo = maxCodigo + 1;
            var retorno  =baseRepository.Insert(obj);
            return retorno;
        }

        public T Select(int id)
        {
            return baseRepository.Select(id);
        }

        public IList<T> Select()
        {
            return baseRepository.Select();
        }

        public T Update<V>(T obj) where V : AbstractValidator<T>
        {
            throw new NotImplementedException();
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}

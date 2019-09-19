using System;
using System.Collections.Generic;
using System.Text;


namespace UniversidadeXYZ.Dominio.Entidades
{
    public abstract class BaseEntity
    {
        public virtual int Id { set; get; }
        public virtual int Codigo { get; set; }

    }
}

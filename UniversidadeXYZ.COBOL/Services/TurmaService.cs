using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UniversidadeXYZ.COBOL.Entidades;

namespace UniversidadeXYZ.COBOL.Services
{
    public class TurmaService
    {
        #region Atributos
        private static List<Turma> turmas;
        #endregion

        public TurmaService()
        {
            if (turmas == null)
            {
                turmas = this.MockTurmas();
            }
        }

        public void Delete(int id)
        {
            turmas.RemoveAll(t => t.CodigoDaTurma == id);
        }

        public Turma Insert(Turma turma)
        {
            turmas.Add(turma);

            return turmas.Where(t => t.CodigoDaTurma == turma.CodigoDaTurma).FirstOrDefault();
        }

        public Turma Select(int id)
        {
            return turmas.SingleOrDefault(t => t.CodigoDaTurma == id);
        }

        public IList<Turma> Select()
        {
            return turmas;
        }

        public Turma Update(Turma turma)
        {
            var _turma = turmas.SingleOrDefault(t => t.CodigoDaTurma == turma.CodigoDaTurma);

            if (turma != null)
            {
                turmas.RemoveAll(t => t.CodigoDaTurma == turma.CodigoDaTurma);
                turmas.Add(turma);
            }

            return turmas.Where(t => t.CodigoDaTurma == turma.CodigoDaTurma).FirstOrDefault();
        }

        private List<Turma> MockTurmas()
        {
            List<Turma> listTurmas = new List<Turma>();
            Random r = new Random();

            for (int i = 1; i <= 20; i++)
            {
                listTurmas.Add(new Turma {
                    CodigoDaTurma = i,
                     DataInicio = new DateTime(2020, 01,01).AddDays(i)
                });
            }

            return listTurmas;
        }
    }
}

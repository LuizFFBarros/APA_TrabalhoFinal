using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UniversidadeXYZ.COBOL.Entidades;

namespace UniversidadeXYZ.COBOL.Services
{
    public class AlunoService
    {
        #region Atributos
        private static List<Aluno> alunos;
        #endregion

        public AlunoService()
        {
            if (alunos == null)
            {
                alunos = this.MockAlunos();
            }
        }

        public void Delete(int id)
        {
            alunos.RemoveAll(a => a.Codigo == id);
        }

        public Aluno Insert(Aluno aluno) 
        {
            alunos.Add(aluno);

            return alunos.Where(a => a.CPF == aluno.CPF).FirstOrDefault();
        }

        public Aluno Select(int id)
        {
            return alunos.SingleOrDefault(a => a.Codigo == id);
        }

        public IList<Aluno> Select()
        {
            return alunos;
        }

        public Aluno Update(Aluno aluno)
        {
            var _aluno = alunos.SingleOrDefault(a => a.Codigo == aluno.Codigo);

            if(aluno != null)
            {
                alunos.RemoveAll(a => a.Codigo == aluno.Codigo);
                alunos.Add(aluno);
            }

            return alunos.Where(a => a.CPF == aluno.CPF).FirstOrDefault();
        }

        private List<Aluno> MockAlunos()
        {
            List<Aluno> listAlunos = new List<Aluno>();

            listAlunos.Add(new Aluno {
                Codigo = 1,
                CPF = 32165498778,
                Logradouro = "Rua teste",
                Nome = "João da Silva",
                Telefone = 31998745621
            });

            listAlunos.Add(new Aluno
            {
                Codigo = 1,
                CPF = 32165498778,
                Logradouro = "Rua teste",
                Nome = "Pedro Oliveira",
                Telefone = 31998745621
            });

            listAlunos.Add(new Aluno
            {
                Codigo = 1,
                CPF = 32165498778,
                Logradouro = "Rua teste",
                Nome = "Bruna Santana",
                Telefone = 31998745621
            });

            return listAlunos;
        }
    }
}
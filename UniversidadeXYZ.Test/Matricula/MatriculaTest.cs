using System;
using System.Collections.Generic;
using System.Text;
using UniversidadeXYZ.Dominio.Enum;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using Xunit;

namespace UniversidadeXYZ.Test.Matricula
{
    public class MatriculaTest
    {
        [Fact]
        public void TestaInclusao()
        {
            DisciplinaRepository disciplinaRepository = new DisciplinaRepository();
            DisciplinaService disciplinaService = new DisciplinaService(disciplinaRepository);

            Dominio.Entidades.Disciplina disciplina = new Dominio.Entidades.Disciplina
            {
                Nome = "Disciplina Teste",
                CargaHoraria = 30
            };

            var novaDisciplina = disciplinaService.Insert<DisciplinaValidator>(disciplina);

            DisciplinaTurmaRepository disciplinaTurmmaRepository = new DisciplinaTurmaRepository();
            DisciplinaTurmaService disciplinaTurmaService = new DisciplinaTurmaService(disciplinaTurmmaRepository);

            Dominio.Entidades.DisciplinaTurma DisciplinaTurma = new Dominio.Entidades.DisciplinaTurma
            {
                CodigoDisciplina = novaDisciplina.CodigoDisciplina,
                CodigoDaTurma = 1,
                QuantidadeVagas = 20
            };

            var novaDisciplinaTurma = disciplinaTurmaService.Insert<DisciplinaTurmaValidator>(DisciplinaTurma);

            MatriculaRepository repository = new MatriculaRepository();
            MatriculaService matriculaService = new MatriculaService(repository);

            Dominio.Entidades.Matricula Matricula = new Dominio.Entidades.Matricula
            {
                CodigoAluno = 1,
                CodigoDaTurma = 1,
                CodigoDisciplina = novaDisciplina.CodigoDisciplina,
                DataMatricula = DateTime.Now
            };

            var novaMatricula = matriculaService.Insert<MatriculaValidator>(Matricula);

            Assert.True(novaMatricula != null);

        }

        [Fact]
        public void TestaListagem()
        {
            MatriculaRepository repository = new MatriculaRepository();
            MatriculaService MatriculaService = new MatriculaService(repository);

            var retorno = MatriculaService.Select();

            Assert.True(retorno.Count > 0);

        }

        [Fact]
        public void TestaCancelamento()
        {
            DisciplinaRepository disciplinaRepository = new DisciplinaRepository();
            DisciplinaService disciplinaService = new DisciplinaService(disciplinaRepository);

            Dominio.Entidades.Disciplina disciplina = new Dominio.Entidades.Disciplina
            {
                Nome = "Disciplina Teste",
                CargaHoraria = 30
            };

            var novaDisciplina = disciplinaService.Insert<DisciplinaValidator>(disciplina);

            DisciplinaTurmaRepository disciplinaTurmmaRepository = new DisciplinaTurmaRepository();
            DisciplinaTurmaService disciplinaTurmaService = new DisciplinaTurmaService(disciplinaTurmmaRepository);

            Dominio.Entidades.DisciplinaTurma DisciplinaTurma = new Dominio.Entidades.DisciplinaTurma
            {
                CodigoDisciplina = novaDisciplina.CodigoDisciplina,
                CodigoDaTurma = 1,
                QuantidadeVagas = 20
            };

            var novaDisciplinaTurma = disciplinaTurmaService.Insert<DisciplinaTurmaValidator>(DisciplinaTurma);

            MatriculaRepository repository = new MatriculaRepository();
            MatriculaService matriculaService = new MatriculaService(repository);

            Dominio.Entidades.Matricula Matricula = new Dominio.Entidades.Matricula
            {
                CodigoAluno = 1,
                CodigoDaTurma = 1,
                CodigoDisciplina = novaDisciplina.CodigoDisciplina,
                DataMatricula = DateTime.Now
            };

            var novaMatricula = matriculaService.Insert<MatriculaValidator>(Matricula);

            novaMatricula.CancelaMatricula();

            var matriculaAtualizada = matriculaService.Update(novaMatricula);

            Assert.True(matriculaAtualizada.CodigoSituacao == (int)SituacaoMatricula.Inativa);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Enum;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Controllers
{
    public class AlunoController : Controller
    {
        IMapper _mapper;
        private readonly IService<Aluno> _alunoService;
        //private readonly IService<Matricula> _matriculaService;

        public AlunoController(IMapper mapper, IService<Aluno> alunoService/*, IService<Matricula> matriculaService*/)
        {
            _mapper = mapper;
            _alunoService = alunoService;
            //_matriculaService = matriculaService;

        }

        public IActionResult Index()
        {
            var listaAlunos = _mapper.Map<List<AlunoModel>>(_alunoService.Select());
            return View(listaAlunos);
            //var alunosEntity = _alunoService.Select();
            //var listaAlunosModel= _mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoModel>>(alunosEntity);
            //return View(listaAlunosModel);

        }

        public IActionResult AdicionarAluno(AlunoModel alunoModel = null)
        {
            return View(alunoModel == null ? new AlunoModel() : alunoModel);
        }

        public IActionResult SalvarAluno([FromForm] AlunoModel alunoModel)
        {
            try
            {
                var alunoEntity = _mapper.Map<AlunoModel, Aluno>(alunoModel);
                alunoEntity = _alunoService.Insert<AlunoValidator>(alunoEntity);

            }
            catch (ArgumentException argEx)
            {
                ViewBag.Erro = argEx.Message;
                //return RedirectToAction("AdicionarAluno", alunoModel);
                return View("AdicionarAluno", alunoModel);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;

                //retornar view de erro cabuloso
                //return ViewErroCabuloso();
            }

            return RedirectToAction("Index");
        }

        //public IActionResult VisualizarMatriculas(int codigoAluno)
        //{
        //    var listaMatriculasAluno = _mapper.Map<List<MatriculaModel>>(_matriculaService.BuscaMatriculasAluno(codigoAluno));

        //    List<MatriculaAlunoModel> listaMatriculas = new List<MatriculaAlunoModel>();

        //    foreach (MatriculaModel matricula in listaMatriculasAluno)
        //    {
        //        MatriculaAlunoModel matriculaAluno = new MatriculaAlunoModel
        //        {
        //            Codigo = matricula.CodigoMatricula,
        //            Data = matricula.DataMatricula,
        //            Turma = matricula.CodigoDaTurma,
        //            Disciplina = matricula.DisciplinaTurma.Disciplina.Nome,
        //            Situacao = ((SituacaoMatricula)matricula.CodigoSituacao).ToString()
        //        };

        //        listaMatriculas.Add(matriculaAluno);
        //    }

        //    return View(listaMatriculas);

        //}
    }
}
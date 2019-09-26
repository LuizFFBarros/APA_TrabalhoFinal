using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Enum;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Controllers
{
    public class MatriculaController : Controller
    {
        IMapper _mapper;
        private readonly DisciplinaTurmaService _disciplinaTurmaService;
        private readonly MatriculaService _matriculaService;

        public MatriculaController(
            IMapper mapper, 
            DisciplinaTurmaService disciplinaTurmaService, 
            MatriculaService matriculaService,
            IService<Matricula> matricula,
            IService<Aluno> alunoService)
        {
            _mapper = mapper;
            _disciplinaTurmaService = disciplinaTurmaService;
            _matriculaService = matriculaService;
        }

        public IActionResult Index()
        {
            var matriculaEntity = _matriculaService.Select();

            var matriculaModel = _mapper.Map<IList<Matricula>, IList<MatriculaModel>>(matriculaEntity);
            return View(matriculaModel);

        }

        public IActionResult AdicionarMatricula(MatriculaModel matriculaModel = null)
        {

            var disciplinas = _disciplinaTurmaService.Select();

            var itens = disciplinas.Select(a => new SelectListItem
            {
                Value = $"{a.CodigoDisciplina}-{a.CodigoDaTurma}",
                Text = $"{a.Disciplina.Nome} - Turma: {a.CodigoDaTurma}"
            }).ToList();

            ViewBag.ListaDisciplinasTurma = itens;


            return View(new MatriculaModel());
        }

        public IActionResult SalvarMatricula([FromForm] MatriculaModel matriculaModel)
        {
            try
            {
                var vet = matriculaModel.CodigoDisciplinaTurma.Split('-');
                matriculaModel.CodigoDisciplina = int.Parse(vet[0]);
                matriculaModel.CodigoDaTurma = int.Parse(vet[1]);
                matriculaModel.DataMatricula = DateTime.Now;
                matriculaModel.CodigoSituacao = (int)SituacaoMatricula.Ativa;
                var alunoEntity = _mapper.Map<MatriculaModel, Matricula>(matriculaModel);
                alunoEntity = _matriculaService.Insert<MatriculaValidator>(alunoEntity);

            }
            catch (ArgumentException argEx)
            {
                ViewBag.Erro = argEx.Message;
                return View("AdicionarMatricula", matriculaModel);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;

            }

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult CancelarMatricula([FromBody]MatriculaModel data) 
        {

            var matricula = _matriculaService.Select(data.CodigoMatricula);
            matricula.CancelaMatricula();
            _matriculaService.Update(matricula);
            return Json("OK");
        }
    }
}
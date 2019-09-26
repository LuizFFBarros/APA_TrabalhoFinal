using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Web.Models;


namespace UniversidadeXYZ.Web.Controllers
{
    public class TurmaController : Controller
    {
        private readonly IService<Turma> _turmaService;
        private readonly DisciplinaTurmaService _disciplinaTurmaService;
        private readonly IMapper _mapper;
        public TurmaController(IMapper mapper, IService<Turma> turmaService, DisciplinaTurmaService disciplinaTurmaService)
        {
            _mapper = mapper;
            _turmaService = turmaService;
            _disciplinaTurmaService = disciplinaTurmaService;
        }

        public IActionResult Index()
        {
            var listaTurmas = _mapper.Map<List<TurmaModel>>(_turmaService.Select());
            return View(listaTurmas);
        }

        public IActionResult AdicionarTurma(TurmaModel turmaModel = null)
        {
            return View(turmaModel == null ? new TurmaModel() : turmaModel);
        }

        public IActionResult SalvarTurma([FromForm] TurmaModel turmaModel)
        {
            try
            {
                var turmaEntity = _mapper.Map<TurmaModel, Turma>(turmaModel);
                turmaEntity = _turmaService.Insert<TurmaValidator>(turmaEntity);

            }
            catch (ArgumentException argEx)
            {
                ViewBag.Erro = argEx.Message;
                return View("AdicionarTurma", turmaModel);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;

            }

            return RedirectToAction("Index");
        }

        public IActionResult VisualizarDisciplinas(int codigoTurma)
        {
            List<DisciplinaTurmaModel> listaDisciplinasTurma = _mapper.Map<List<DisciplinaTurmaModel>>(_disciplinaTurmaService.BuscaPorTurma(codigoTurma));

            List<DisciplinaModel> listaDisciplinas = new List<DisciplinaModel>();

            foreach (DisciplinaTurmaModel disciplina in listaDisciplinasTurma)
            {
                DisciplinaModel disciplinaTurma = new DisciplinaModel
                {
                    CodigoDisciplina = disciplina.CodigoDisciplina,
                    Nome = disciplina.Disciplina.Nome,
                    CargaHoraria = disciplina.Disciplina.CargaHoraria
                };

                listaDisciplinas.Add(disciplinaTurma);
            }

            return View(listaDisciplinas);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IService<Disciplina> _disciplinaService;
        private readonly IMapper _mapper;
        public TurmaController(IMapper mapper, IService<Turma> turmaService, DisciplinaTurmaService disciplinaTurmaService, IService<Disciplina> disciplinaService)
        {
            _mapper = mapper;
            _turmaService = turmaService;
            _disciplinaTurmaService = disciplinaTurmaService;
            _disciplinaService = disciplinaService;
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


            ViewBag.CodigoTurma = codigoTurma;

            return View(listaDisciplinasTurma);

        }

        public IActionResult VincularDisciplina(int codigoTurma)
        {
            IList<Disciplina> listaDisciplinas = _disciplinaService.Select();

            List<SelectListItem> listItens = new List<SelectListItem>();

            foreach(Disciplina disciplina in listaDisciplinas)
            {
                listItens.Add(new SelectListItem
                {
                    Text = disciplina.Nome,
                    Value = disciplina.CodigoDisciplina.ToString()
                });
            }

            ViewBag.ListaDisciplinas = listItens;

            DisciplinaTurmaModel disciplinaTurmaModel = new DisciplinaTurmaModel();
            disciplinaTurmaModel.CodigoDaTurma = codigoTurma;

            return View(disciplinaTurmaModel);
        }

        public IActionResult SalvarDisciplinaTurma([FromForm] DisciplinaTurmaModel disciplinaTurmaModel)
        {
            try
            {
                var disciplinaTurmaEntity = _mapper.Map<DisciplinaTurmaModel, DisciplinaTurma>(disciplinaTurmaModel);
                disciplinaTurmaEntity = _disciplinaTurmaService.Inserir(disciplinaTurmaEntity);

            }
            catch (ArgumentException argEx)
            {
                ViewBag.Erro = argEx.Message;
                return View("VincularDisciplina", disciplinaTurmaModel);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;

            }

            return RedirectToAction("VisualizarDisciplinas", new { codigoTurma = disciplinaTurmaModel.CodigoDaTurma });
        }
    }
}
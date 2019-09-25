using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly IService<Disciplina> _disciplinaService;
        private readonly IMapper _mapper;
        public DisciplinaController(IMapper mapper, IService<Disciplina> disciplinaService)
        {
            _mapper = mapper;
            _disciplinaService = disciplinaService;
        }
        public IActionResult Index()
        {
            var listaDisciplinas = _mapper.Map<List<DisciplinaModel>>(_disciplinaService.Select());
            return View(listaDisciplinas);
        }

        public IActionResult AdicionarDisciplina(DisciplinaModel disciplinaModel = null)
        {
            return View(disciplinaModel == null ? new DisciplinaModel() : disciplinaModel);
        }

        public IActionResult SalvarDisciplina([FromForm] DisciplinaModel disciplinaModel)
        {
            try
            {
                var disciplinaEntity = _mapper.Map<DisciplinaModel, Disciplina>(disciplinaModel);
                disciplinaEntity = _disciplinaService.Insert<DisciplinaValidator>(disciplinaEntity);

            }
            catch (ArgumentException argEx)
            {
                ViewBag.Erro = argEx.Message;
                return View("AdicionarDisciplina", disciplinaModel);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;

            }

            return RedirectToAction("Index");
        }
    }
}
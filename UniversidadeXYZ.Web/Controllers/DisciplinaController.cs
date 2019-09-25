using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
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
    }
}
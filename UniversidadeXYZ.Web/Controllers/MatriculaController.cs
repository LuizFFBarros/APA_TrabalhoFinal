using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Service.Services;

namespace UniversidadeXYZ.Web.Controllers
{
    public class MatriculaController : Controller
    {
        IMapper _mapper;
        private readonly DisciplinaTurmaService _disciplinaTurmaService;

        public MatriculaController(IMapper mapper, DisciplinaTurmaService disciplinaTurmaService)
        {
            _mapper = mapper;
            _disciplinaTurmaService = disciplinaTurmaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
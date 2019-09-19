using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Controllers
{
    public class AlunoController : Controller
    {
        IMapper _mapper;
        public AlunoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            AlunoRepository repository = new AlunoRepository();
            AlunoService alunoService = new AlunoService(repository);
            
            List<AlunoModel> listaAlunos = _mapper.Map<List<AlunoModel>>(alunoService.Select());

            return View(listaAlunos);
        }

        public IActionResult AdicionarAluno()
        {
            return View();
        }
    }
}
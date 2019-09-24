using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Controllers
{
    public class AlunoController : Controller
    {
        IMapper _mapper;
        private readonly IService<Aluno> _serviceAluno;
        public AlunoController(IMapper mapper, IService<Aluno> alunoService)
        {
            _mapper = mapper;
            _serviceAluno = alunoService;
             
        }

        public IActionResult Index()
        {
           
            var listaAlunos = _mapper.Map<List<AlunoModel>>(_serviceAluno.Select());
            return View(listaAlunos);
        }

        public IActionResult AdicionarAluno()
        {
            return View();
        }
        
        public IActionResult SalvarAluno([FromForm] AlunoModel alunoModel)
        {
            return RedirectToAction("Index");
        }
    }
}
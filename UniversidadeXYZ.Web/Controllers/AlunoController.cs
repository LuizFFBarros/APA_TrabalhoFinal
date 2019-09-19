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
            return View(new List<AlunoModel>()
            {
                new AlunoModel { Nome="luiz", CPF=11111111111, Telefone= 31111111111, Logradouro = "Rua dos bobos 1"  },
                new AlunoModel { Nome="fernando", CPF=22222222222, Telefone= 31222222222, Logradouro = "Rua dos bobos 2"  },
                new AlunoModel { Nome="Squad", CPF=33333333333, Telefone= 31333333333, Logradouro = "Rua dos bobos 3"  },
                new AlunoModel { Nome="E-commerce", CPF=44444444444, Telefone= 31444444444, Logradouro = "Rua dos bobos 4"  }
            });

            //AlunoRepository repository = new AlunoRepository();
            //AlunoService alunoService = new AlunoService(repository);

            //List<AlunoModel> listaAlunos = _mapper.Map<List<AlunoModel>>(alunoService.Select());

            //return View(listaAlunos);
        }

        public IActionResult AdicionarAluno()
        {
            return View();
        }
    }
}
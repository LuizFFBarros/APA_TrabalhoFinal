using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Service.Validators;
using UniversidadeXYZ.Web.Models;

namespace UniversidadeXYZ.Web.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IService<ServicoCuringa> _servicoCuringa;

        public HomeController()
        {
            //Carina, aqui eu posso popular o banco, como fiz na controller de aluno, na qual populo apenas a tela.
            //se nao houver registro algum no banco, chamamos um metodo em um servico "curinga" e ele realizaria uma pre carga no banco.
            //quando a aplicação inicia ela comeca pela Home, seria este o lugar para verificarmos e popular. Uma alternativa válida


            //_servicoCuringa.VerificarEPopularBase();
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "teste teste";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

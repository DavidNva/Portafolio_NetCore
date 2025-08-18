using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositorioProyectos repositorioProyectos;

        public HomeController(ILogger<HomeController> logger, RepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }
        
        
        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    //ViewBag.Nombre = "David 10";
        //    ViewBag.Edad = 16;
        //    return View("Index","David NG");//Este segundo valor seria el del Model, para acceder desde la vista, pero ahora tipado, en este caso funciona porque es solo un valor que estamos pasando, pero si queremos pasar de igual forma la edad o demas campos tipados, en este caso edad seria de tipo int, tenemos que realizar una clase. 

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

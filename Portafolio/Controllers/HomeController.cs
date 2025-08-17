using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewBag.Nombre = "David 10";
            ViewBag.Edad = 16;
            return View("Index", "David NG");

        }

        //public IActionResult Index()
        //{
        //    //ViewBag.Nombre = "David 10";
        //    ViewBag.Edad = 16;
        //    return View("Index","David NG");//Este segundo valor seria el del Model, para acceder desde la vista, pero ahora tipado, en este caso funciona porque es solo un valor que estamos pasando, pero si queremos pasar de igual forma la edad o demas campos tipados, en este caso edad seria de tipo int, tenemos que realizar una clase. 

        //}

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

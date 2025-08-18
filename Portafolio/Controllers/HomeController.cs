using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly RepositorioProyectos repositorioProyectos;
        private readonly IRepositorioProyectos repositorioProyectos;//A simple vista pareciera que no cambio nada el usar inyeccion de depdencias solo con repositorio directamente a la clase que usar Inyeccion de dependencias con interfaces
        //Pero internatemente debemos enteder que ahora el controller no sabe que clases, no se preocupa por que clases estan usandose  o que directamente usara RepositorioProyectos.cs, sino que simplemente sabe que usa IRepositorioProyectos, ya esa es la que se encarga de orquestar que se esta usando.
        //Esto da una flexibilidad increible, porque si mañana yo creo otro reporitorio proyectos (que ahora si trabaje o se conecte a una base de datos), simplemente creamos dicha clase y  y simplemente hacemos referencia a dicha en Program.cs y con eso HomeController recibirá esa nueva instancia que una clase implementa la interfaz IRepositoryProyectos
        //Esto se llama principio de inversion de dependencias.
        //Ahora, de esta forma, las clases como HomeController no depende de otras clases sino que depende de tipos abstractos como clases abstractas o interfaces en nuestro caso. Esto permite la flexibilidad de poder cambiar en tiempo de ejecucion la implementacion en app programa en services

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
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

//una interfaz es como un contrato que nos obliga a implementar ciertos metodos de una clase
//podemos utilizar inyeccion de dependencias con esas interfaces para asi poder tener flexibilidad en que clases servidas a traves de la inyeccion de dependencias
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        //private readonly RepositorioProyectos repositorioProyectos;//Inyeccion de dependencias sin interfaces
        private readonly IRepositorioProyectos _repositorioProyectos;//Inyeccion de dependencias con interfaces
        private readonly IServicioEmail _servicioEmail;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IConfiguration configuration, IServicioEmail servicioEmail)
        {
            _logger = logger;
            _repositorioProyectos = repositorioProyectos;
            _configuration = configuration;
            _servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            var apellido = _configuration.GetValue<string>("Apellido");

            _logger.LogTrace("Este es un mensaje de log trace");
            _logger.LogDebug("Este es un mensaje de log debug ");
            _logger.LogInformation("Este es un mensaje de log information");
            _logger.LogWarning("Este es un mensaje de log warning");
            _logger.LogError("Este es un mensaje de Error");
            _logger.LogCritical($"Este es un mensaje de Critical {apellido}");
            var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }


        public IActionResult Proyectos()
        {
            var proyectos = _repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        public IActionResult Contacto()//Al action si no se pone http get, se deduce que es get. 
        {
            return View();
        }

        [HttpPost]//Pero para metodos que son tipo post, put, delete, etc. necesitamos colocarlo explicitamente
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await _servicioEmail.Send(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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

//NOTAS SOBRE INYECCION DE DEPENDENCIAS CON INTERFACES

//using System.Diagnostics;

//namespace Portafolio.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        //private readonly RepositorioProyectos repositorioProyectos;//Asi estaba inicialmente con inyeccion de dependencias sin interfaces, donde estaba atado a solo tipos RepositorioProyectos, cualquier cambio afectaba a controller

//        private readonly IRepositorioProyectos repositorioProyectos;//Ahora con interfaces, el controller no sabe ni le importa a que clase sea, simplemente esta asociada a la interfaz. Entonces simplemente en Program.cs en el apartado de servicios  solo seria cambiar la linea de builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>(); por la nueva referencia al nuevo m�todo de la clase en cuestion
        //using Portafolio.Servicios;

        //var builder = WebApplication.CreateBuilder(args);

        //builder.Services.AddControllersWithViews();

        //builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();



//A simple vista pareciera que no cambio nada el usar inyeccion de depdencias solo con repositorio directamente a la clase que usar Inyeccion de dependencias con interfaces
//Pero internatemente debemos enteder que ahora el controller no sabe que clases, no se preocupa por que clases estan usandose  o que directamente usara RepositorioProyectos.cs, sino que simplemente sabe que usa IRepositorioProyectos, ya esa es la que se encarga de orquestar que se esta usando.
//Esto da una flexibilidad increible, porque si ma�ana yo creo otro reporitorio proyectos (que ahora si trabaje o se conecte a una base de datos), simplemente creamos dicha clase y  y simplemente hacemos referencia a dicha en Program.cs y con eso HomeController recibir� esa nueva instancia que una clase implementa la interfaz IRepositoryProyectos
//Esto se llama principio de inversion de dependencias.
//Ahora, de esta forma, las clases como HomeController no depende de otras clases sino que depende de tipos abstractos como clases abstractas o interfaces en nuestro caso. Esto permite la flexibilidad de poder cambiar en tiempo de ejecucion la implementacion en app proh
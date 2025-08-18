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
            var proyectos = ObtenerProyectos().Take(3).ToList();

            //var modelo = new HomeIndexViewModel() { };//Aun si quitasemos esto, funcionaria, claro se mostraria en la pagina sin proyectos
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }
        
        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>(){
                new Proyecto
                {
                    Titulo = "Sistema de Gestión de Préstamos y Laboratorios - ITSSNP",
                    Descripcion = "Plataforma institucional desarrollada para la Unidad de Prácticas del ITSSNP, diseñada para administrar el préstamo de herramientas a estudiantes y gestionar el acceso a laboratorios de manera eficiente y segura.",
                    Link = "https://davidnavadev.netlify.app/",
                    ImagenURL = "/imagenes/sigup_web.webp"
                },
                new Proyecto
                {
                    Titulo = "Chatbot Inteligente con WhatsApp y ChatGPT",
                    Descripcion = "Este chatbot permite la automatización de consultas en bases de datos mediante mensajes de WhatsApp, facilitando el acceso a información sin necesidad de conocimientos técnicos en SQL.",
                    Link = "https://davidnavadev.netlify.app/",
                    ImagenURL = "/imagenes/api-chatbot-whatsapp.webp"
                },
                new Proyecto
                {
                    Titulo = "Sistema de Gestión de Biblioteca Pública",
                    Descripcion = "Desarrollo de un sistema web para la gestión eficiente de préstamos y administración de una biblioteca pública en Zacatlán. Este proyecto fue desarrollado como parte de la carrera de Ingeniería Informática, aplicando una arquitectura escalable y buenas prácticas en desarrollo web.",
                    Link = "https://davidnavadev.netlify.app/",
                    ImagenURL = "/imagenes/dashboard_principal_biblioteca.webp"
                },
                new Proyecto    
                {
                    Titulo = "Integración de PayPal con ASP.NET MVC",
                    Descripcion = "Ejemplo de integración de PayPal en una aplicación ASP.NET MVC, utilizando la API de PayPal para procesar transacciones de pago.",
                    Link = "https://davidnavadev.netlify.app/",
                    ImagenURL = "/imagenes/paypal_integration.webp"
                }
            };
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

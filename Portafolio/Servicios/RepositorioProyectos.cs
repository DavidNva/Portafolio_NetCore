using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class RepositorioProyectos: IRepositorioProyectos
    {
        //Una clase repositorio, mayormente se encarga de servir datos.
        //Ejemplo se conecta a una base de datos para obtener informacion de la misma

        public List<Proyecto> ObtenerProyectos()
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

    }
}

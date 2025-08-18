namespace Portafolio.Models
{
    //Algunos dev le llama por convencion HomeIndexDTO  (Data Transfer Object).
    //Otros le llamdan HomeIndexViewModel
    public class HomeIndexViewModel
    {
        public IEnumerable<Proyecto> Proyectos { get; set; }
        public EjemploGuidViewModel EjemploGuid_1 { get; set; }
        public EjemploGuidViewModel EjemploGuid_2 { get; set; }
    }
}

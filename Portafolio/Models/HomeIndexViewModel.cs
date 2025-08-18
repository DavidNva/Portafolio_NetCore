namespace Portafolio.Models
{
    //Algunos dev le llama por convencion HomeIndexDTO  (Data Transfer Object).
    //Otros le llamdan HomeIndexViewModel
    public class HomeIndexViewModel
    {
        public IEnumerable<Proyecto> Proyectos { get; set; }
    }
}

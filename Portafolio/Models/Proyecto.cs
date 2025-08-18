namespace Portafolio.Models
{
    //Algunos dev le llama por convencion ProyectoDTO  (Data Transfer Object).
    //Otros le llamdan ProyectoViewModel
    //En este caso lo dejaremos tal cual, teniendo en cuenta que como es Model, sabremos para que es
    public class Proyecto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public string Link { get; set; }
    }
}

namespace Portafolio.Servicios
{
    public class ServicioUnico
    {
        public ServicioUnico()
        {
            ObtenerGuid = Guid.NewGuid();//Nuevo string aleatorio 
        }
        public  Guid ObtenerGuid{ get; private set; }
        //Un guid es basicamente un string aleatorio largo 
    }
    public class ServicioDelimitado
    {
        public ServicioDelimitado()
        {
            ObtenerGuid = Guid.NewGuid();//Nuevo string aleatorio 
        }
        public Guid ObtenerGuid { get; private set; }
        //Un guid es basicamente un string aleatorio largo 
    }
    public class ServicioTransitorio
    {
        public ServicioTransitorio()
        {
            ObtenerGuid = Guid.NewGuid();//Nuevo string aleatorio 
        }
        public Guid ObtenerGuid { get; private set; }
        //Un guid es basicamente un string aleatorio largo 
    }
}

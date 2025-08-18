using Portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Con esto ya esta configurado en la inyeccion de dependencias
//Los servicios nos referimos a aquellas clases o interfaces que tenemos registradas en el sistema de inyeccion de dependencias, es decir que podemos luego utilizar a traves del constructor de una clase, como lo hacemos ahora con IRepositorioProyectos, es un ejemplo de un servicio que hemos configurado en la clase program
//AddTransient. 
//Aunque este es un servicio,no todos son iguales, estos pueden cambiar por el tiempo de vida.
//Hay 3 tipos de servicios, los Transient,Scoped Y Singleton
//Transient (Transitorio) son los servicios que piden por menos tiempo, sirve para una nueva instancia del servicio
//Scoped (Delimitado) son servicios cuyo tiempo de vida vive delimitado por una peticion http
//Singleton (Unico) son servicios que viven por mas tiempo, de hecho viven para siempre, solamente se renueva si la aplicacion es reiniciada. Es decir siempre sera la misma instancia del servicio, incluso en peticiones http distintas.
//Un criterio para decidir el tiempo de vidad de nuestros servicios es si necesitan compartir datos entre distintas instancias del servicio, por ejemplo, nuestro servicio de IRepositorioProyectos no necesita compartir datos entre distintas instancias del servicio, por lo tanto utilizamos Transient, si necesitaramos compartir datos con otras instancias, digamos de otras peticiones http, utilizariamos AddSingleton, y si necesitaramos compartir datos pero soloamente dentro de la misma peticion http, usariamos AddScoped
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();
//Ahora tiene dos parametros, que estamos diciendo con esto:
//Que cuando una clase como HomeController pida una intancia de IRepositorioProyectos se le envie una instancia de RepositorioProyectos()
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")//El signo ? en id indica que es opcional (el ultimo campon id es opcional)
    .WithStaticAssets();


app.Run();

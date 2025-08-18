using Portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Con esto ya esta configurado en la inyeccion de dependencias
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

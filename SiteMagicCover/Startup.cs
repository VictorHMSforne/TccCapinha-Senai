using SiteMagicCover.Context;
using SiteMagicCover.Repositories;
using SiteMagicCover.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SiteMagicCover.Models;

namespace SiteMagicCover;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient<ICapinhaRepository, CapinhaRepository>(); // revisar esse registro
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //esse Singleton, signfica que o tempo de vida do HttpContext vai durar enquanto a aplicação estiver rodando 
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

        services.AddControllersWithViews();

        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseSession();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern:"Capinha/{action}/{categoria?}",
                defaults: new { Controller = "Capinha", action = "Listar"});

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Isso aqui é um roteamento, quando tem esse ?, significa que o parâmetro opcional
        });
    }
}
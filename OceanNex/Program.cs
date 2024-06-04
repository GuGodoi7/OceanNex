using Microsoft.EntityFrameworkCore;
using OceanNex.Persistencia;
using OceanNex.Persistencia.Repositorios.Interfaces;
using OceanNex.Persistencia.Repositorios;
using OceanNex.Models;

namespace OceanNex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<OracleFIAPDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAPDbContext"));
            });

            builder.Services.AddScoped<IRepositorio<Biologo>, Repositorio<Biologo>>();
            builder.Services.AddScoped<IRepositorio<FeedBackPostagem>, Repositorio<FeedBackPostagem>>();
            builder.Services.AddScoped<IRepositorio<FeedBackPredicao>, Repositorio<FeedBackPredicao>>();
            builder.Services.AddScoped<IRepositorio<Usuario>, Repositorio<Usuario>>();
            builder.Services.AddScoped<IRepositorio<Postagem>, Repositorio<Postagem>>();
            builder.Services.AddScoped<IRepositorio<Predicao>, Repositorio<Predicao>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

using Microsoft.Data.SqlClient;
using MiPrimeraApi.Hubs;
using Query.Implementations;
using Query.Interfaces;
using System.Data;

namespace MiPrimeraApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddScoped<IDbConnection>(sp =>
            {
                string connectionString = builder.Configuration.GetConnectionString("sql");
                SqlConnection conection = new SqlConnection(connectionString);
                return conection;
            });

            builder.Services.AddTransient<IUsuarioQueries, UsuarioQueries>();  

            string ruta = Path.Combine(AppContext.BaseDirectory, "api.xml");

            builder.Services.AddSwaggerGen(
                opt =>
                {
                    opt.IncludeXmlComments(ruta);
                }
                );

            builder.Services.AddSignalR();

            builder.Services.AddCors(
                opt =>
                {
                    opt.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://127.0.0.1:5500");
                    });
                }
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.MapGet("/", () => "Servidor Signal escuhando");
            app.MapHub<ChatHub>("/chat");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

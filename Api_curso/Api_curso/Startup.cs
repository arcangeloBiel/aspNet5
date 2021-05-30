using Api_curso.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Api_curso.Repository;
using Api_curso.Business;
using Api_curso.Business.Implementations;
using Serilog;
using System;
using System.Collections.Generic;
using Api_curso.Repository.Generic;

namespace Api_curso {
    public class Startup {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        
        public Startup(IConfiguration configuration, IWebHostEnvironment environment) {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            //criada a conexao vinda do appsettings.json
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            //CONFIGURANDO AS MIGRATIONS
            if (Environment.IsDevelopment()) {
                MigrateDatabase(connection);
            }

            //usado para versionar api
            services.AddApiVersioning();
            //add inje�ao de dependencia po @arcangelo
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
        private void MigrateDatabase(string connection) {
            try {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> {"db/migrations","db/dataset"},
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex) {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }

    }
}

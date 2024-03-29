﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversidadeXYZ.Dominio.Entidades;
using UniversidadeXYZ.Dominio.Interfaces;
using UniversidadeXYZ.Infra.Data.Repository;
using UniversidadeXYZ.Service.Services;
using UniversidadeXYZ.Web.Models;
using UniversidadeXYZ.Web.AutoMapper;

namespace UniversidadeXYZ.Web
{
    public class Startup
    {
        public static COBOL.Services.AlunoService cobolAluno = new COBOL.Services.AlunoService();
        public static COBOL.Services.TurmaService cobolTurma = new COBOL.Services.TurmaService();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //AutoMapper
            services.AddSingleton(MappingProfile.configure().CreateMapper());

            //Services
            services.AddSingleton(cobolAluno);
            services.AddSingleton(cobolTurma);
            services.AddSingleton(typeof(MatriculaService));
            services.AddSingleton(typeof(DisciplinaTurmaService));
            services.AddSingleton(typeof(TurmaService));
            services.AddSingleton(typeof(IService<Aluno>), typeof(AlunoService));
            services.AddSingleton(typeof(IService<Disciplina>), typeof(DisciplinaService));
            services.AddSingleton(typeof(IService<DisciplinaTurma>), typeof(DisciplinaTurmaService));
            services.AddSingleton(typeof(IService<Matricula>), typeof(MatriculaService));
            services.AddSingleton(typeof(IService<Turma>), typeof(TurmaService));

            //Repository
            services.AddSingleton(typeof(MatriculaRepository));
            services.AddSingleton(typeof(DisciplinaTurmaRepository));
            services.AddSingleton(typeof(IRepository<Disciplina>), typeof(DisciplinaRepository));
            services.AddSingleton(typeof(IRepository<DisciplinaTurma>), typeof(DisciplinaTurmaRepository));
            services.AddSingleton(typeof(IRepository<Matricula>), typeof(MatriculaRepository));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilesL.BotherMeNot.Api.Actions;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Configuration;
using MilesL.BotherMeNot.Api.Conventions;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Repositories;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using MilesL.BotherMeNot.Api.Services;
using MilesL.BotherMeNot.Api.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace MilesL.BotherMeNot.Api
{
    /// <summary>
    /// Startup configuration for .Net Core
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">A instance of the IConfiguration interface</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets a instance of the IConfiguration interface
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddMvc(mvc =>
            {
                mvc.Conventions.Add(new DefaultRoutePrefixConvention());
            });

            // Configure versioning support
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Add swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new Info { Version = "v1", Title = "Bother Me Not Api", Description = string.Empty, TermsOfService = "None", Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Luke Miles", Email = "lukemiles@outlook.com", Url = "https://lmiles.co.uk" } });
            });

            // Add automapper
            services.AddAutoMapper();
            services.Configure<AppOptions>(this.Configuration.GetSection("AppOptions"));
            services.AddDbContext<BotherMeNotDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IContactAttemptService, ContactAttemptService>();
            services.AddScoped<IContactAttemptRepository, ContactAttemptRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<HangUpContactAction>();
            services.AddScoped<RedirectContactAction>();
            services.AddScoped<PlayFileContactAction>();
            services.AddScoped(factory =>
            {
                Func<ContactAction, IContactAction> accesor = key =>
                {
                    switch (key)
                    {
                        case ContactAction.HangUp:
                            return factory.GetService<HangUpContactAction>();
                        case ContactAction.Redirect:
                            return factory.GetService<RedirectContactAction>();
                        case ContactAction.PlayFile:
                            return factory.GetService<PlayFileContactAction>();
                        default:
                            throw new KeyNotFoundException(); // or maybe return null, up to you
                    }
                };
                return accesor;
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">A instance of the IApplicationBuilder interface</param>
        /// <param name="env">A instance of the IHostingEnvironment interface</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enables development mode
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Adds Swagger
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bother Me Not Api");
            });

            // Adds MVC
            app.UseMvc();
        }
    }
}

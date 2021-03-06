﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoreMVCBackend.Model.SQL;

namespace CoreMVCBackend
{
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
            services.Configure<MySqlConnection>(Configuration.GetSection("MySqlConnection"));
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
                
            }
            else
            {
                app.UseExceptionHandler("/Backend/Error");                
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Backend}/{action=Index}");
            });
        }
    }
}

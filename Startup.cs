﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Session;

namespace homework
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
          // using Microsoft.EntityFrameworkCore;
          services.AddDbContext<ShopingContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
          //Session      
          services.AddDistributedMemoryCache();
          services.AddSession(Options=>{
            Options.Cookie.SecurePolicy=CookieSecurePolicy.Always;
            Options.Cookie.Name="myWebsite";
            Options.IdleTimeout=TimeSpan.FromMinutes(10);
          });

          //Cors
          services.AddCors();
          services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          //dotnet跨網域及表頭
          app.UseCors(builder =>
            builder.WithOrigins("http://localhost:8080")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());

          //使用session
          app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

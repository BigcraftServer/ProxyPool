﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProxyPool.BLL;
using ProxyPool.BLL.Services;
using ProxyPool.DAL;
using Swashbuckle.AspNetCore.Swagger;

namespace ProxyPool.WebAPI {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      #region Swagger
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new Info {
          Version = "V1",
          Title = "ProxyPool",
          Description = "ProxyPool",
          TermsOfService = "None",
          Contact = new Contact() { Name = "ProxyPool", Email = "admin@bigcraft.cn", Url = "www.google.com" }
        });
      });
      #endregion
      services.AddEntityFrameworkNpgsql().AddDbContext<ProxyDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ProxyDB")));
      services.AddTransient<ProxyService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
      #region Swagger
      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
      });
      #endregion
    }
  }
}

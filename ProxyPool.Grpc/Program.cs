using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProxyPool.BLL.Services;
using ProxyPool.DAL;
using ProxyPool.Grpc.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProxyPool.Grpc {
  static class Program {
    static void Main(string[] args) {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      IConfigurationRoot configuration = builder.Build();

      //setup our DI
      var services = new ServiceCollection().AddLogging();
      services.AddEntityFrameworkNpgsql().AddDbContext<ProxyDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("ProxyDB")));
      services.AddTransient<ProxyService>();

      Server proxyPoolService = new Server {
        Services = { ProxyPool.Grpc.ProxyPoolV1.BindService(new ProxyPoolV1Impl(services.BuildServiceProvider().GetService<ProxyService>())) },
        Ports = { new ServerPort(configuration.GetValue<string>("AllowedHost"), configuration.GetValue<int>("AllowedPort"), ServerCredentials.Insecure) }
      };

      proxyPoolService.Start();

      Console.WriteLine("Greeter server listening on port " + configuration.GetValue<int>("AllowedPort"));
      Console.WriteLine("Press any key to stop the server...");
      Console.ReadKey();

      proxyPoolService.ShutdownAsync().Wait();
    }
  }
}

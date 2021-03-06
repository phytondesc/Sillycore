﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sillycore;
using Sillycore.Daemon;
using Sillycore.NLog;

namespace ConsoleApp
{
    class Program
    {
        static ILogger<Program> _logger;

        static void Main(string[] args)
        {
            SillycoreAppBuilder.Instance
                .UseUtcTimes()
                .ConfigureServices(ConfigureServices)
                .UseNLog()
                .UseDaemon<Service>("ConsoleApp")
                .Build();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<TestJob>();
        }
    }
}
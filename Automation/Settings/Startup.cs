using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Automation.Settings
{
    public class Startup : IDisposable
    {
        public static IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var environmentName = env.EnvironmentName;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(@"Properties\launchSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($@"Settings\settings.{environmentName}.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            SetEnvironmentVariables();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { }
        }

        public void SetEnvironmentVariables()
        {
            try
            {
                var variables = Configuration.GetSection("profiles:Automation:environmentVariables").GetChildren();

                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao setar variáveis de ambiente.\n{e.Message}.\n{e.InnerException}");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

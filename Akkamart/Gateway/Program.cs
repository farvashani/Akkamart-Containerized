using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Gateway {
    public class Program {
        public static void Main (string[] args) {
            var root = AppDomain.CurrentDomain.BaseDirectory;

            CreateWebHostBuilder (args)
                .UseWebRoot (AppDomain.CurrentDomain.BaseDirectory)
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseUrls ("http://0.0.0.0:5050")
                .UseStartup<Startup> ()
                .Build ().Run ();
        }

        // public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
        //     WebHost.CreateDefaultBuilder (args).UseUrls ("http://0.0.0.0:5050")
        //     .UseStartup<Startup> ();

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) {
            var builder = new WebHostBuilder ()
                .UseKestrel ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .ConfigureAppConfiguration ((hostingContext, config) => {
                    var env = hostingContext.HostingEnvironment;
                    //config.SetBasePath (hostingContext.HostingEnvironment.ContentRootPath);
                    // config.AddJsonFile ("appsettings.json", optional : false, reloadOnChange : false);

                    if (env.IsDevelopment ()) {
                        var appAssembly = Assembly.Load (new AssemblyName (env.ApplicationName));
                        if (appAssembly != null) {
                            config.AddUserSecrets (appAssembly, optional : true);
                        }
                    }

                    config.AddEnvironmentVariables ();

                    if (args != null) {
                        config.AddCommandLine (args);
                    }
                })
                .ConfigureLogging ((hostingContext, logging) => {
                    logging.AddConfiguration (hostingContext.Configuration.GetSection ("Logging"));
                    logging.AddConsole ();
                    logging.AddDebug ();
                })
                .UseDefaultServiceProvider ((context, options) => {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment ();
                });

            if (args?.Length > 0) {
                builder.UseConfiguration (new ConfigurationBuilder ().AddCommandLine (args).Build ());
            } else {
                builder.UseConfiguration (new ConfigurationBuilder ()
                    .SetBasePath (AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile ("hosting.json", optional : true) //this is not needed, but could be useful
                    .AddCommandLine (args)
                    .Build ()
                );

            }

            return builder;
        }
    }
}
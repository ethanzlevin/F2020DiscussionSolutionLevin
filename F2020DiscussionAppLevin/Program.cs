using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppLevin.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace F2020DiscussionAppLevin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();//.Run();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {

                    DbInitializer.Initialize(services);

                    // as about differences and with static

                    //object/instance method
                    //DbInitializer dbInitializer = new DbInitializer();
                    //dbInitializer.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured creating the DB.");
                }
            }

            host.Run();

        }//end Main method



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }//end class (Program)
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene
{
    public class Program
    {
        public static void InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminExists = roleManager.RoleExistsAsync("Administrator")
                        .GetAwaiter()
                        .GetResult();

            if (!adminExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator"))
                            .GetAwaiter()
                            .GetResult();
            }

            var userExists = roleManager.RoleExistsAsync("Utilizator")
                        .GetAwaiter()
                        .GetResult();

            if (!userExists)
            {
                roleManager.CreateAsync(new IdentityRole("Utilizator"))
                            .GetAwaiter()
                            .GetResult();
            }

        }

        public static void InitializeAdminUsers(UserManager<Utilizator> userManager)
        {
            var adminUser = userManager.FindByEmailAsync("administrator@gmail.com")
                                        .GetAwaiter()
                                        .GetResult();
            if (adminUser != null)
            {
                var result = userManager.AddToRoleAsync(adminUser, "Administrator")
                            .GetAwaiter()
                            .GetResult();
            }
        }
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<Utilizator>>();
                InitializeRoles(roleManager);
                InitializeAdminUsers(userManager);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

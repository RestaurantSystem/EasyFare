namespace RestaurantSystem.Web.Infrastructure.Extensions
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using static WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDataBaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<RestaurantSystemDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var managerName = ManagerRole;

                        var roles = new[]
                        {
                             CookRole,
                             ManagerRole,
                             WaiterRole,
                             NoRole
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var managerEmail = "manager@manager.com";

                        var managerUser = await userManager.FindByEmailAsync(managerEmail);

                        if (managerUser == null)
                        {
                            managerUser = new User
                            {
                                Email = managerEmail,
                                UserName = managerName,
                                Salary = 0
                            };

                            await userManager.CreateAsync(managerUser, "Manager");

                            await userManager.AddToRoleAsync(managerUser, managerName);
                        }
                    }).Wait();
            }

            return app;
        }
    }
}
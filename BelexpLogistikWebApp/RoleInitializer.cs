using BelexpLogistikWebApp.Models;  // пространство имен модели User
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BelexpLogistikWebApp
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string adminLogin = "admin";
            string password = "123123Qw!";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("logistician") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("logistician"));
            }
            if (await roleManager.FindByNameAsync("driver") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("driver"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminLogin };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
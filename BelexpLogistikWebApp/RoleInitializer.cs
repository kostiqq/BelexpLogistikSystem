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
            if (await roleManager.FindByNameAsync("Администратор") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Администратор"));
            }
            if (await roleManager.FindByNameAsync("Логист") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Логист"));
            }
            if (await roleManager.FindByNameAsync("Водитель") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Водитель"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminLogin };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Администратор");
                }
            }
        }
    }
}
using Microsoft.AspNetCore.Identity;
using WAD_DATABASE.Data.Enum;
using WAD_DATABASE.Models;

namespace WAD_DATABASE.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                //context.Database.EnsureCreated();

                ////if (!context.Announcement.Any())
                ////{
                ////    context.Announcement.AddRange(new List<Announcement>()
                ////    {
                ////        new Announcement()
                ////        {
                ////            AnnouncementName = "Roulette",
                ////            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",

                ////            Description = "Roullete Game",

                ////         },
                ////        new Announcement()
                ////        {
                ////            AnnouncementName = "Blackjack",
                ////            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",

                ////            Description = "Blackjack Game",

                ////         },
                ////        new Announcement()
                ////        {
                ////            AnnouncementName = "SlotMachine",
                ////            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",

                ////            Description = "SlotMachine Game",

                ////         },
                ////        new Announcement()
                ////        {
                ////            AnnouncementName = "Soliter",
                ////            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",

                ////            Description = "Soliter Game",

                ////         }
                ////    });
                ////    context.SaveChanges();
                //}

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "mihai.chilom@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "mihaichilom",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Craiova@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                       

                    };
                    await userManager.CreateAsync(newAppUser, "Craiova@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

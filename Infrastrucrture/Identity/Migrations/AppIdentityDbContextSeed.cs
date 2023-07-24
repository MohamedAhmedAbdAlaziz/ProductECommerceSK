using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastrucrture.Identity.Migrations
{ 
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAync(UserManager<AppUser> userManager)
        {
               if(!userManager.Users.Any()){
                var user = new AppUser{
                       DisplayName="Bob",
                       Email="bob@test.com",
                       UserName="bob@test.com",
                       Address=new Address{
                        FirstName="Bob",
                        LastName="Bobbity",
                        Street="10 the Street",City="New York",
                        State="NY",
                        ZipCode="90210"
                                }
                    } ;
                await userManager.CreateAsync(user,"Pa$$w0rd");

                }

               
        }
    }
}
using System.Security.Claims;

namespace API.Extensions
{
    public static class CliamsPrincipalExtensions
    {
        public static string RetriveEmailFromPrincipal(this ClaimsPrincipal user){
            return user.FindFirstValue(ClaimTypes.Email);
        }
        
    }
}
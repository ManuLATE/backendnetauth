using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backendnet.Services;

namespace backendnet.Middlewares;

public class SlidingExpirationJwt(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, JwtTokenService jwtTokenService){
        try
        {
            string authorization = context.Request.Headers.Authorization!;
            JwtSecurityToken? token = null;
            if(!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer"))
                token = new JwtSecurityTokenHandler().ReadJwtToken(authorization[7..]);

            if(token != null && token.ValidTo > DateTime.UtcNow)
            {
                TimeSpan timeRemaining = token.ValidTo.Subtract(DateTime.UtcNow);
                if(timeRemaining.Minutes < 19)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, context.User.FindFirstValue(ClaimTypes.Name)!),
                        new(ClaimTypes.GivenName, context.User.FindFirstValue(ClaimTypes.GivenName)!),
                        new(ClaimTypes.Role, context.User.FindFirstValue(ClaimTypes.Role)!)
                    };
                    context.Response.Headers.Append("Set-Authorization", jwtTokenService.GeneraToken(claims));
                }
            }
        }
        catch(Exception)
        {

        }
        await next(context);
    }
}

public static class SlidingExpirationJwtExtensions
{
    public static IApplicationBuilder UseSlidingExpirationJwt(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SlidingExpirationJwt>();
    }
}
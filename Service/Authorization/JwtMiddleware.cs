using FFStudioServices.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.BusinessService;
using Service.BusinessService.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FFStudioServices.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        //public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        //{
        //    _next = next;
        //    _appSettings = appSettings.Value;
        //}
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task Invoke(HttpContext context, IAccountService accountService)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        //    if(token != null)
        //    {
        //        attachUserToContext(context, accountService, token);
        //    }
        //    await _next(context);
        //}

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if(userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Accounts"] = userService.GetById(userId);
            }

            await _next(context);
        }

        //private void attachUserToContext(HttpContext context, IAccountService accountService, string token)
        //{
        //    try
        //    {
        //        var tokenHanlder = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //        tokenHanlder.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);

        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        var userId = jwtToken.Claims.First(a => a.Type == "id").Value;

        //        // attach user to context on successful jwt validation
        //        context.Items["User"] = accountService.GetById(userId);
        //    }
        //    catch
        //    {
        //        // do nothing if jwt validation fails
        //        // user is not attached to context so request won't have access to secure routes
        //    }
        //}
    }
}

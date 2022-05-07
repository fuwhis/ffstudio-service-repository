using AutoMapper;
using EntityModel.Context;
using EntityModel.Models;
using FFStudioServices.Authorization;
using FFStudioServices.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.RequestModel;
using Service.BusinessService.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FFStudioServices.Controllers
{
    [Route("api/v1/authen")]
    [ApiController]
    public class AuthenTokenController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public AuthenTokenController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("users")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet("user/get/{id}")]
        //public IActionResult GetById(string id)
        //{
        //    var user = _userService.GetById(id);
        //    return Ok(user);
        //}

        //[AllowAnonymous]
        //[HttpPost("register")]
        //public IActionResult Register(RegisterRequest model)
        //{
        //    _userService.Register(model);
        //    return Ok(new { message = "Registration successful" });
        //}

        //[HttpPut("user/update/{id}")]
        //public IActionResult Update(string id, UpdateRequest model)
        //{
        //    _userService.Update(id, model);
        //    return Ok(new { message = "User updated successfully" });
        //}

        //[HttpDelete("user/remove/{id}")]
        //public IActionResult Delete(string id)
        //{
        //    _userService.Delete(id);
        //    return Ok(new { message = "User deleted successfully" });
        //}
    }
}

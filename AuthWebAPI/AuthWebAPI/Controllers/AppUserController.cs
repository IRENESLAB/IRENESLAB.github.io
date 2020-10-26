using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AuthWebAPI.Models;

namespace AuthWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private AuthenticationContext _context;
       
        public IConfiguration _configuration { get; }
        public AppUserController(IConfiguration configuration, AuthenticationContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        //POST: /api/AppUser/Register
        public async Task<Object> Register(AppUserModel model)
        {
            var appUser = new AppUser() {
            UserName = model.EmailAddress,
            FullName = model.FullName,
            Email = model.EmailAddress
            };

            try
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
             
        }
        [HttpPost]
        [Route("Login")]
        //POST: /api/AppUser/Login
        public async Task<Object> Login(LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var key = Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"]);
                
             
                if (user!=null && await _userManager.CheckPasswordAsync(user,model.Password))
                {
                    var jwtToken = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] { new Claim(Constants.UserId, user.Id.ToString()) }),
                        Expires = DateTime.UtcNow.AddMinutes(25),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(jwtToken);
                    var token = tokenHandler.WriteToken(securityToken); 
                    return Ok(new {succeeded = true, token});
                }
                else
                {
                    return (new { message = Constants.UserName_or_Password_is_incorrect });
                }
               
            }
            catch (Exception ex)
            {
                return (new { message = ex.Message });
            }

        }
    }
}

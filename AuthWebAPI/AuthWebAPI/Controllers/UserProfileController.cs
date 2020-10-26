using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AuthWebAPI.Models;

namespace AuthWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private AuthenticationContext _context;

        public IConfiguration _configuration { get; }
        public UserProfileController(IConfiguration configuration, AuthenticationContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        //GET: /api/GetUserProfile
        public async Task<Object> GetUserProfile()
        {
            try
            {
                string userId = User.Claims.First(u => u.Type == "UserId").Value;
                var user = await _userManager.FindByIdAsync(userId);
                return new
                {
                    user.FullName,
                    user.Email,
                    user.UserName,
                    user.Id
                };
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

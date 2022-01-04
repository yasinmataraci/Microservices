using FreeCourse.IdentityServer.DTOs;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Email,
                City = signUpDTO.City
            };
            var result = await _userManager.CreateAsync(user, signUpDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(), 404));
            }

            return NoContent();
        }
    }
}

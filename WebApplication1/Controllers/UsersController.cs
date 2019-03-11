using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using OplogDataChartBackend.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using OplogDataChartBackend.Services;
using OplogDataChartBackend.Dtos;
using OplogDataChartBackend.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace OplogDataChartBackend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
          

            if (result.Succeeded)
            {

                var user = await _userManager.FindByNameAsync(model.UserName);
                var token = GenerateJwtToken(user.Id);

                return Ok(new
                {
                    Id = user.Id, 
                    Username = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Token = token.Token
                });
            }

            return BadRequest(new { message = "Username or password is incorrect" });


        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserDto model)
        {
            var user = new User(
                        model.FirstName,
                        model.LastName,
                        null,
                        model.UserName
                        );

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
               // return Ok(GenerateJwtToken());
            }

            return BadRequest(result.Errors);
        }


        [HttpGet]
        public IActionResult Deneme()
        {
            return Ok("Deneme");
        }

        private TokenResponse GenerateJwtToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}

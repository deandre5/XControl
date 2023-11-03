using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using poryecto_finanzas.DTOs;
using poryecto_finanzas.Repositories;
using proyecto_finanzas.data.DTOs;
using proyecto_finanzas.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace poryecto_finanzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : Controller
    {

        private readonly string secretKey;
        private readonly IUserRepositorie _userRepositorie;
        private readonly ILogger<User> _logger;

        public User(ILogger<User> logger, IUserRepositorie userRepositorie, IConfiguration config)
        {
            _logger = logger;
            _userRepositorie = userRepositorie;
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }


        [HttpGet]
        [Route("api/users/get-user")]
        public async Task<IActionResult> Get(string email) {

            UtilsClass utils = new UtilsClass(); 
            
            if (!utils.IsValidEmail(email))
            {
                ResponseTypeDTO responseType = new ResponseTypeDTO("Por favor ingrese un correo valido", 000, 400);
                ObjectResponseDTO<ResponseTypeDTO> objectResponse = new ObjectResponseDTO<ResponseTypeDTO>(responseType);

                return BadRequest(objectResponse);
            }

            UserDTO user = await _userRepositorie.GetUserByEmail(email);
            ObjectResponseDTO<UserDTO> objectResponseDTO;

            if (user.Id != 0)
            {
                var keybytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.Email, email));
                claims.AddClaim(new Claim(ClaimTypes.Name, user.Nombre));
                claims.AddClaim(new Claim(ClaimTypes.SerialNumber, user.Id.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(keybytes),SecurityAlgorithms.HmacSha256Signature
                        )
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                user.Token = tokenHandler.WriteToken(tokenConfig);
                objectResponseDTO = new ObjectResponseDTO<UserDTO>(user);
                return Ok(objectResponseDTO);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

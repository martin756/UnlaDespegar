using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using UnlaDespegar.Data;
using UnlaDespegar.Models;

namespace UnlaDespegar.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public AuthController(UnlaDespegarContext context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this._mapper = mapper;
            this._configuration = configuration;
        }
        [HttpPost]
        [Route("[action]")]
        public Response Login([FromBody]UsuarioDto usuario)

        {
            Response responseLogin = new Response();
            try { 
                UsuarioResponse user = new UsuarioResponse();
                var resultDb = context.Usuario.FirstOrDefault(u => u.Mail == usuario.Mail);
                user = _mapper.Map<Usuario, UsuarioResponse>(resultDb);

                if (user != null && user.Contraseña.Equals(usuario.Password))
                {
                    // Leemos el secret_key desde nuestro appseting
                    var secretKey = _configuration.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    // Creamos los claims (pertenencias, características) del usuario


                    /* var claims = new[]
                     {

                     new System.Security.Claims.ClaimsIdentity("UserData", JsonConvert.SerializeObject(user))
                      };*/
                    ClaimsIdentity claims = new ClaimsIdentity();
                    Claim datos =  new Claim("UserData", JsonConvert.SerializeObject(user));
                 
                    claims.AddClaim(datos);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        // Nuestro token va a durar un día
                        Expires = DateTime.UtcNow.AddDays(1),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                    responseLogin.cod = 200;
                    responseLogin.data = tokenHandler.WriteToken(createdToken);
                    responseLogin.mensaje = "OK";
                }
                else
                {
                    responseLogin.cod = 401;
                    responseLogin.data = null;
                    responseLogin.mensaje = "Credenciales invalidas";
                }
            }catch(Exception e)
            {
                responseLogin.cod = 502;
                responseLogin.data = null;
                responseLogin.mensaje = "Error al intentar verificar el usuario";
            }
            return responseLogin;
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult UpdatePassword([FromBody]UsuarioDto user)
        {
            try
            {
                Usuario usuario = context.Usuario.FirstOrDefault(u => u.Mail == user.Mail);

                if (usuario != null)
                {
                    usuario.Contraseña = user.Password;
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else 
                { 
                    return NotFound(); 
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

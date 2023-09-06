using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnlaDespegar.Data;
using UnlaDespegar.Models;

namespace UnlaDespegar.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;

        public UsuarioController(UnlaDespegarContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UsuarioResponse> Get()
        {
            IEnumerable<UsuarioResponse> response = new List<UsuarioResponse>();
            var resultDb = context.Usuario.ToList().OrderBy(x => x.Id); 
            response = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponse>>(resultDb);
            return response;
        }

        [HttpGet("{id}")]
        public UsuarioResponse Get(int id)
        {
            UsuarioResponse response = new UsuarioResponse();
            var resultDb = context.Usuario.FirstOrDefault(u => u.Id == id);
            response = _mapper.Map<Usuario, UsuarioResponse>(resultDb);
            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Usuario user)
        {
            try
            {
                var resultDbUsuarios = context.Usuario.ToList().OrderBy(x => x.Id);
                var message = resultDbUsuarios.Any(x => x.Mail.Equals(user.Mail)) ? throw new Exception("Error al registrar usuario, ya existe el mail a registrar.") : "";
                context.Usuario.Add(user);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Usuario user)
        {
            try
            {
                var resultDbUsuarios = context.Usuario.Where(x => x.Id != user.Id);
                var message = resultDbUsuarios.Any(x => x.Mail.Equals(user.Mail)) ? throw new Exception("Error al registrar usuario, ya existe el mail a registrar.") : "";

                if (user.Id == id)
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = context.Usuario.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    context.Usuario.Remove(user);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

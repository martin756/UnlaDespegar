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
    public class ActividadController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;

        public ActividadController(UnlaDespegarContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ActividadResponse> Get()
        {
            IEnumerable<ActividadResponse> response = new List<ActividadResponse>();
            var resultDb = context.Actividad.Include(x => x.DestinoNavigation).ToList().OrderBy(x => x.Id);
            response = _mapper.Map<IEnumerable<Actividad>, IEnumerable<ActividadResponse>>(resultDb);
            return response;
        }

        [HttpGet("{id}")]
        public ActividadResponse Get(int id)
        {
            ActividadResponse response = new ActividadResponse();
            var resultDb = context.Actividad.Include(x => x.DestinoNavigation).FirstOrDefault(u => u.Id == id);
            response = _mapper.Map<Actividad, ActividadResponse>(resultDb);
            return response;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<ActividadResponse> Destino(int id)
        {
            IEnumerable<ActividadResponse> response = new List<ActividadResponse>();
            var resultDb = context.Actividad.Include(x => x.DestinoNavigation).Where(u => u.DestinoNavigation.Id == id);
            response = _mapper.Map<IEnumerable<Actividad>, IEnumerable<ActividadResponse>>(resultDb);
            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Actividad actividad)
        {
            try
            {
                context.Actividad.Add(actividad);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Actividad actividad)
        {
            try
            {
                if (actividad.Id == id)
                {
                    context.Entry(actividad).State = EntityState.Modified;
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
                var actividad = context.Actividad.FirstOrDefault(u => u.Id == id);
                if (actividad != null)
                {
                    context.Actividad.Remove(actividad);
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

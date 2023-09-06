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
    public class VueloController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;

        public VueloController(UnlaDespegarContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<VueloResponse> Get()
        {
            IEnumerable<VueloResponse> response = new List<VueloResponse>();
            var resultDb = context.Vuelo.Include(x=>x.DestinoNavigation).Include(x=>x.OrigenNavigation).ToList().OrderBy(x=>x.Id);
            response = _mapper.Map<IEnumerable<Vuelo>,IEnumerable<VueloResponse>>(resultDb);
            return response;
        }

        [HttpGet("{id}")]
        public VueloResponse Get(int id)
        {
            VueloResponse response = new VueloResponse();
            var resultDb = context.Vuelo.Include(x => x.DestinoNavigation).Include(x => x.OrigenNavigation).FirstOrDefault(u => u.Id == id);
            response = _mapper.Map<Vuelo, VueloResponse>(resultDb);
            return response;
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<VueloResponse> Destino(int id)
        {
            IEnumerable<VueloResponse> response = new List<VueloResponse>();
            var resultDb = context.Vuelo.Include(x => x.DestinoNavigation).Include(x => x.OrigenNavigation).Where(u => u.DestinoNavigation.Id == id);
            response = _mapper.Map<IEnumerable<Vuelo>, IEnumerable<VueloResponse>>(resultDb);
            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Vuelo vuelo)
        {
            try
            {
                context.Vuelo.Add(vuelo);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Vuelo vuelo)
        {
            try
            {
                if (vuelo.Id == id)
                {
                    context.Entry(vuelo).State = EntityState.Modified;
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
                var vuelo = context.Vuelo.FirstOrDefault(u => u.Id == id);
                if (vuelo != null)
                {
                    context.Vuelo.Remove(vuelo);
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

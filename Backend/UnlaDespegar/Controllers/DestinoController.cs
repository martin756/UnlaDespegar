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
    public class DestinoController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;

        public DestinoController(UnlaDespegarContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<DestinoResponse> Get()
        {
            IEnumerable<DestinoResponse> response = new List<DestinoResponse>();
            var resultDb = context.Destino.ToList().OrderBy(x => x.Id);
            response = _mapper.Map<IEnumerable<Destino>, IEnumerable<DestinoResponse>>(resultDb);
            return response;
        }

        [HttpGet("{id}")]
        public DestinoResponse Get(int id)
        {
            DestinoResponse response = new DestinoResponse();
            var resultDb = context.Destino.FirstOrDefault(u => u.Id == id);
            response = _mapper.Map<Destino, DestinoResponse>(resultDb);
            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Destino destino)
        {
            try
            {
                context.Destino.Add(destino);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Destino destino)
        {
            try
            {
                if (destino.Id == id)
                {
                    context.Entry(destino).State = EntityState.Modified;
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
                var destino = context.Destino.FirstOrDefault(u => u.Id == id);
                if (destino != null)
                {
                    context.Destino.Remove(destino);
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

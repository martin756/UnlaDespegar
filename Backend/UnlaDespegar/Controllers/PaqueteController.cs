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
    public class PaqueteController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;

        public PaqueteController(UnlaDespegarContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PaqueteResponse> Get()
        {
            IEnumerable<PaqueteResponse> response = new List<PaqueteResponse>();
            var resultDb = context.Paquete.Include(x => x.DestinoNavigation)
                .Include(x => x.VueloNavigation)
                .Include(x => x.VueloNavigation.OrigenNavigation)
                .Include(x => x.VueloNavigation.DestinoNavigation)
                .Include(x => x.ActividadNavigation)
                .Include(x => x.ActividadNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation)
                .Include(x => x.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.AlojamientoNavigation.TipoAlojamientoNavigation)
                .ToList().OrderBy(x=>x.Id);
            response = _mapper.Map<IEnumerable<Paquete>, IEnumerable<PaqueteResponse>>(resultDb);
            return response;
        }

        [HttpGet("{id}")]
        public PaqueteResponse Get(int id)
        {
            PaqueteResponse response = new PaqueteResponse();
            var resultDb = context.Paquete.Include(x => x.DestinoNavigation)
                .Include(x => x.VueloNavigation)
                .Include(x => x.VueloNavigation.OrigenNavigation)
                .Include(x => x.VueloNavigation.DestinoNavigation)
                .Include(x => x.ActividadNavigation)
                .Include(x => x.ActividadNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation)
                .Include(x => x.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.AlojamientoNavigation.TipoAlojamientoNavigation)
                .FirstOrDefault(u => u.Id == id);
            response = _mapper.Map<Paquete, PaqueteResponse>(resultDb);
            return response;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<PaqueteResponse> Destino(int id)
        {
            IEnumerable<PaqueteResponse> response = new List<PaqueteResponse>();
            var resultDb = context.Paquete.Include(x => x.DestinoNavigation)
               .Include(x => x.VueloNavigation)
               .Include(x => x.VueloNavigation.OrigenNavigation)
               .Include(x => x.VueloNavigation.DestinoNavigation)
               .Include(x => x.ActividadNavigation)
               .Include(x => x.ActividadNavigation.DestinoNavigation)
               .Include(x => x.AlojamientoNavigation)
               .Include(x => x.AlojamientoNavigation.DestinoNavigation)
               .Include(x => x.AlojamientoNavigation.TipoRegimenNavigation)
               .Include(x => x.AlojamientoNavigation.TipoAlojamientoNavigation)
               .Where(u => u.DestinoNavigation.Id == id);
            response = _mapper.Map<IEnumerable<Paquete>, IEnumerable<PaqueteResponse>>(resultDb);
            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Paquete paquete)
        {
            try
            {
                paquete.Precio = 0;
                context.Paquete.Add(paquete);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Paquete paquete)
        {
            try
            {
                if (paquete.Id == id)
                {
                    paquete.Precio = 0;
                    context.Entry(paquete).State = EntityState.Modified;
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
                var paquete = context.Paquete.FirstOrDefault(u => u.Id == id);
                if (paquete != null)
                {
                    context.Paquete.Remove(paquete);
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

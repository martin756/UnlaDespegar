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
    public class PasajeroController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;

        public PasajeroController(UnlaDespegarContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PasajeroResponse> Get()
        {
            IEnumerable<PasajeroResponse> response = new List<PasajeroResponse>();
            var resultDb = context.Pasajero.Include(x => x.ReservaNavigation)
                .Include(x => x.ReservaNavigation.DestinoNavigation)
                .Include(x => x.ReservaNavigation.UsuarioNavigation)
                .Include(x => x.ReservaNavigation.VueloNavigation)
                .Include(x => x.ReservaNavigation.VueloNavigation.OrigenNavigation)
                .Include(x => x.ReservaNavigation.VueloNavigation.DestinoNavigation);
            response = _mapper.Map<IEnumerable<Pasajero>, IEnumerable<PasajeroResponse>>(resultDb);
            return response;
        }

        [HttpGet("{id}")]
        public PasajeroResponse Get(int id)
        {
            PasajeroResponse response = new PasajeroResponse();
            var resultDb = context.Pasajero.Include(x => x.ReservaNavigation)
                .Include(x => x.ReservaNavigation.DestinoNavigation)
                .Include(x => x.ReservaNavigation.UsuarioNavigation)
                .Include(x => x.ReservaNavigation.VueloNavigation)
                .Include(x => x.ReservaNavigation.VueloNavigation.OrigenNavigation)
                .Include(x => x.ReservaNavigation.VueloNavigation.DestinoNavigation);
            response = _mapper.Map<Pasajero, PasajeroResponse>((Pasajero)resultDb);
            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Pasajero pasajero)
        {
            try
            {
                context.Pasajero.Add(pasajero);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Pasajero pasajero)
        {
            try
            {
                if (pasajero.Id == id)
                {
                    context.Entry(pasajero).State = EntityState.Modified;
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
                var pasajero = context.Pasajero.FirstOrDefault(u => u.Id == id);
                if (pasajero != null)
                {
                    context.Pasajero.Remove(pasajero);
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

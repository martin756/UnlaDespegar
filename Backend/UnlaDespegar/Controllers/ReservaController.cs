using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnlaDespegar.Data;
using UnlaDespegar.Data.Requets;
using UnlaDespegar.Models;

namespace UnlaDespegar.Controllers
{
    [Route("api/[controller]")]
    public class ReservaController : Controller
    {
        private readonly UnlaDespegarContext context;
        private readonly IMapper _mapper;
        private readonly PasajeroController _pasajeroController;

        public ReservaController(UnlaDespegarContext context, IMapper mapper, PasajeroController pasajeroController)
        {
            this.context = context;
            this._mapper = mapper;
            _pasajeroController = pasajeroController;
        }

        [HttpGet]
        public IEnumerable<ReservaResponse> Get()
        {
            IEnumerable<ReservaResponse> response = new List<ReservaResponse>();
            var resultDb = context.Reserva.Include(x => x.DestinoNavigation)
                .Include(x => x.UsuarioNavigation)
                .Include(x => x.VueloNavigation)
                .Include(x => x.VueloNavigation.OrigenNavigation)
                .Include(x => x.VueloNavigation.DestinoNavigation)
                .Include(x => x.ActividadNavigation)
                .Include(x => x.ActividadNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation)
                .Include(x => x.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.AlojamientoNavigation.TipoAlojamientoNavigation)
                .Include(x => x.PaqueteNavigation)
                .Include(x => x.PaqueteNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation.OrigenNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.ActividadNavigation)
                .Include(x => x.PaqueteNavigation.ActividadNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.TipoAlojamientoNavigation)
                .ToList().OrderBy(x => x.Id);
            response = _mapper.Map<IEnumerable<Reserva>, IEnumerable<ReservaResponse>>(resultDb);

            var pasajeros = _pasajeroController.Get().ToList();

            foreach(ReservaResponse reserva in response)
            {
                var pasajeroDeReserva = pasajeros.Where(x => x.Reserva == reserva.Id);
                reserva.Pasajeros.AddRange(pasajeroDeReserva);
                if (reserva.EsUnPaquete)
                {
                    reserva.Importe = reserva.Paquete.Precio;
                }
                else
                {
                    reserva.Importe = (reserva.Alojamiento != null ? (reserva.Alojamiento.Precio * Convert.ToDecimal(Math.Round((reserva.FechaSalida - reserva.FechaEntrada).TotalDays))) : 0) + (reserva.Vuelo != null ? (reserva.Vuelo.Precio * reserva.Pasajeros.Count()) : 0) + (reserva.Actividad != null ? (reserva.Actividad.Precio * reserva.Pasajeros.Count()) : 0);
                }
            }

            return response;
        }

        [HttpGet("{id}")]
        public ReservaResponse Get(int id)
        {
            ReservaResponse response = new ReservaResponse();
            var resultDb = context.Reserva.Include(x => x.DestinoNavigation)
                .Include(x => x.UsuarioNavigation)
                .Include(x => x.VueloNavigation)
                .Include(x => x.VueloNavigation.OrigenNavigation)
                .Include(x => x.VueloNavigation.DestinoNavigation)
                .Include(x => x.ActividadNavigation)
                .Include(x => x.ActividadNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation)
                .Include(x => x.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.AlojamientoNavigation.TipoAlojamientoNavigation)
                .Include(x => x.PaqueteNavigation)
                .Include(x => x.PaqueteNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation.OrigenNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.ActividadNavigation)
                .Include(x => x.PaqueteNavigation.ActividadNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.TipoAlojamientoNavigation)
                .FirstOrDefault(u => u.Id == id);
            response = _mapper.Map<Reserva, ReservaResponse>(resultDb);

            var pasajeros = _pasajeroController.Get().ToList();
            var pasajeroDeReserva = pasajeros.Where(x => x.Reserva == response.Id);
            response.Pasajeros.AddRange(pasajeroDeReserva);
            
            if (response.EsUnPaquete)
            {
                response.Importe = response.Paquete.Precio;
            }
            else
            {
                response.Importe = (response.Alojamiento != null ? (response.Alojamiento.Precio * Convert.ToDecimal(Math.Round((response.FechaSalida - response.FechaEntrada).TotalDays))) : 0) + (response.Vuelo != null ? (response.Vuelo.Precio * response.Pasajeros.Count()) : 0) + (response.Actividad != null ? (response.Actividad.Precio * response.Pasajeros.Count()) : 0);
            }

            return response;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<ReservaResponse> Usuario(int id)
        {
            IEnumerable<ReservaResponse> response = new List<ReservaResponse>();
            var resultDb = context.Reserva.Include(x => x.DestinoNavigation)
                .Include(x => x.UsuarioNavigation)
                .Include(x => x.VueloNavigation)
                .Include(x => x.VueloNavigation.OrigenNavigation)
                .Include(x => x.VueloNavigation.DestinoNavigation)
                .Include(x => x.ActividadNavigation)
                .Include(x => x.ActividadNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation)
                .Include(x => x.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.AlojamientoNavigation.TipoAlojamientoNavigation)
                .Include(x => x.PaqueteNavigation)
                .Include(x => x.PaqueteNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation.OrigenNavigation)
                .Include(x => x.PaqueteNavigation.VueloNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.ActividadNavigation)
                .Include(x => x.PaqueteNavigation.ActividadNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.TipoRegimenNavigation)
                .Include(x => x.PaqueteNavigation.AlojamientoNavigation.TipoAlojamientoNavigation)
                .Where(u => u.UsuarioNavigation.Id == id);
            response = _mapper.Map<IEnumerable<Reserva>, IEnumerable<ReservaResponse>>(resultDb);

            var pasajeros = _pasajeroController.Get().ToList();

            foreach (ReservaResponse reserva in response)
            {
                var pasajeroDeReserva = pasajeros.Where(x => x.Reserva == reserva.Id);
                reserva.Pasajeros.AddRange(pasajeroDeReserva);
                if (reserva.EsUnPaquete)
                {
                    reserva.Importe = reserva.Paquete.Precio;
                }
                else
                {
                    reserva.Importe = (reserva.Alojamiento != null ? (reserva.Alojamiento.Precio * Convert.ToDecimal(Math.Round((reserva.FechaSalida - reserva.FechaEntrada).TotalDays)) * reserva.Pasajeros.Count) : 0) + (reserva.Vuelo != null ? (reserva.Vuelo.Precio * reserva.Pasajeros.Count()) : 0);
                }
            }

            return response;
        }

        [HttpPost]
        public ActionResult Post([FromBody]RequestReserva reservaRequest)
        {
            var reservaInsertadaCorrectamente = false;
            var reservaInsertada = new Reserva();
            var idReserva = 0;
            try
            {
                var pasajeros = reservaRequest.Pasajeros.Any() ? _mapper.Map<IEnumerable<RequestPasajero>, IEnumerable<Pasajero>>(reservaRequest.Pasajeros) : null;
                Reserva reserva = _mapper.Map<RequestReserva, Reserva>(reservaRequest);
                context.Reserva.Add(reserva);
                context.SaveChanges();

                if (pasajeros != null)
                {
                    reservaInsertada = context.Reserva.FirstOrDefault(x => x.NroReserva == reserva.NroReserva);
                    idReserva = reservaInsertada.Id;
                    pasajeros.ToList().ForEach(x => x.Reserva = idReserva);
                    reservaInsertadaCorrectamente = true;
                    context.Pasajero.AddRange(pasajeros);
                    context.SaveChanges();
                    
                }

                return Ok();
            }
            catch (Exception e)
            {
                if (reservaInsertadaCorrectamente)
                {
                    context.Reserva.Remove(reservaInsertada);
                    context.SaveChanges();
                }
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Reserva reserva)
        {
            try
            {
                if (reserva.Id == id)
                {
                    reserva.Importe = 0;
                    context.Entry(reserva).State = EntityState.Modified;
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
                var reserva = context.Reserva.FirstOrDefault(u => u.Id == id);
                var pasajerosAux = context.Pasajero.Where(x => x.Reserva == reserva.Id).ToList();
                if (reserva != null)
                {
                    context.Reserva.Remove(reserva);

                    if(pasajerosAux != null)
                    {
                        context.Pasajero.RemoveRange(pasajerosAux);
                    }
                    
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

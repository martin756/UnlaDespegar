using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Reserva
    {
        public Reserva()
        {
            Pasajero = new HashSet<Pasajero>();
        }

        public int Id { get; set; }
        public string NroReserva { get; set; }
        public int Usuario { get; set; }
        public int Destino { get; set; }
        public int? Alojamiento { get; set; }
        public int? Actividad { get; set; }
        public int? Vuelo { get; set; }
        public bool EsUnPaquete { get; set; }
        public int? Paquete { get; set; }
        public decimal Importe { get; set; }
        public bool ReservaFinalizada { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }

        public Actividad ActividadNavigation { get; set; }
        public Alojamiento AlojamientoNavigation { get; set; }
        public Destino DestinoNavigation { get; set; }
        public Paquete PaqueteNavigation { get; set; }
        public Usuario UsuarioNavigation { get; set; }
        public Vuelo VueloNavigation { get; set; }
        public ICollection<Pasajero> Pasajero { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Paquete
    {
        public Paquete()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string TipoPaquete { get; set; }
        public int Destino { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public int Alojamiento { get; set; }
        public int Vuelo { get; set; }
        public int Actividad { get; set; }
        public int CantidadPersonas { get; set; }
        public int Habitaciones { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public decimal Precio { get; set; }

        public Actividad ActividadNavigation { get; set; }
        public Alojamiento AlojamientoNavigation { get; set; }
        public Destino DestinoNavigation { get; set; }
        public Vuelo VueloNavigation { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}

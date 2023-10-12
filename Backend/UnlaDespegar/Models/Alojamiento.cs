using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Alojamiento
    {
        public Alojamiento()
        {
            Paquete = new HashSet<Paquete>();
            Reserva = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int? CantidadEstrellas { get; set; }
        public string NombreAlojamiento { get; set; }
        public string Link { get; set; }
        public string TipoServicio { get; set; }
        public string TipoHabitacion { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public int Destino { get; set; }
        public int TipoAlojamiento { get; set; }
        public int TipoRegimen { get; set; }
        public decimal Precio { get; set; }

        public Destino DestinoNavigation { get; set; }
        public TipoAlojamiento TipoAlojamientoNavigation { get; set; }
        public TipoRegimen TipoRegimenNavigation { get; set; }
        public ICollection<Paquete> Paquete { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Actividad
    {
        public Actividad()
        {
            Paquete = new HashSet<Paquete>();
            Reserva = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string NombreActividad { get; set; }
        public string Link { get; set; }
        public string Descripcion { get; set; }
        public string FranjaHoraria { get; set; }
        public string Valoracion { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public int Destino { get; set; }
        public decimal Precio { get; set; }

        public Destino DestinoNavigation { get; set; }
        public ICollection<Paquete> Paquete { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}

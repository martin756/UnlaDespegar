using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Vuelo
    {
        public Vuelo()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public string NombreAereolinea { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public string Link { get; set; }
        public bool IdaVuelta { get; set; }
        public int? ValoracionAereolinea { get; set; }
        public string Clase { get; set; }
        public bool ConEscala { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public decimal Precio { get; set; }

        public Destino DestinoNavigation { get; set; }
        public Destino OrigenNavigation { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
    }
}

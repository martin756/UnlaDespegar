using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlaDespegar.Data
{
    public class PaqueteResponse
    {
        public int Id { get; set; }
        public string TipoPaquete { get; set; }
        public DestinoResponse Destino { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public AlojamientoResponse Alojamiento { get; set; }
        public VueloResponse Vuelo { get; set; }
        public ActividadResponse Actividad { get; set; }
        public int CantidadPersonas { get; set; }
        public int Habitaciones { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public decimal Precio { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlaDespegar.Data
{
    public class AlojamientoResponse
    {
        public int Id { get; set; }
        public int? CantidadEstrellas { get; set; }
        public string NombreAlojamiento { get; set; }
        public string Link { get; set; }
        public string TipoServicio { get; set; }
        public string TipoHabitacion { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public DestinoResponse Destino { get; set; }
        public TipoAlojamientoResponse TipoAlojamiento { get; set; }
        public TipoRegimenResponse TipoRegimen { get; set; }
        public decimal Precio { get; set; }
    }
}

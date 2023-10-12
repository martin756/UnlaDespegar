using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlaDespegar.Data
{
    public class ActividadResponse
    {
        public int Id { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string NombreActividad { get; set; }
        public string Link { get; set; }
        public string Descripcion { get; set; }
        public string FranjaHoraria { get; set; }
        public string Valoracion { get; set; }
        public bool AccesoDiscapacitados { get; set; }
        public DestinoResponse Destino { get; set; }
        public decimal Precio { get; set; }
    }
}

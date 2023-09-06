using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlaDespegar.Data.Requets
{
    public class RequestReserva
    {
        public string NroReserva { get; set; }
        public int Usuario { get; set; }
        public int Destino { get; set; }
        public int? Vuelo { get; set; }
        public decimal Importe { get; set; }
        public bool ReservaFinalizada { get; set; }
        public List<RequestPasajero> Pasajeros { get; set; }  = new List<RequestPasajero>();
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}

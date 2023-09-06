using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnlaDespegar.Data.Requets
{
    public class RequestPasajero
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public string Domicilio { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
    }
}

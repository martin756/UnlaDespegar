using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Pasajero
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public string Domicilio { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public int Reserva { get; set; }

        public Reserva ReservaNavigation { get; set; }
    }
}

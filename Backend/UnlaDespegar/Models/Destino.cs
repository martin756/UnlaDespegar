using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Destino
    {
        public Destino()
        {
            Actividad = new HashSet<Actividad>();
            Alojamiento = new HashSet<Alojamiento>();
            Paquete = new HashSet<Paquete>();
            Reserva = new HashSet<Reserva>();
            VueloDestinoNavigation = new HashSet<Vuelo>();
            VueloOrigenNavigation = new HashSet<Vuelo>();
        }

        public int Id { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Ciudad { get; set; }

        public ICollection<Actividad> Actividad { get; set; }
        public ICollection<Alojamiento> Alojamiento { get; set; }
        public ICollection<Paquete> Paquete { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
        public ICollection<Vuelo> VueloDestinoNavigation { get; set; }
        public ICollection<Vuelo> VueloOrigenNavigation { get; set; }
    }
}

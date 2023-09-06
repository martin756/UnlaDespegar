using System;
using System.Collections.Generic;

namespace UnlaDespegar.Models
{
    public partial class Destino
    {
        public Destino()
        {
            Reserva = new HashSet<Reserva>();
            VueloDestinoNavigation = new HashSet<Vuelo>();
            VueloOrigenNavigation = new HashSet<Vuelo>();
        }

        public int Id { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Ciudad { get; set; }

        public ICollection<Reserva> Reserva { get; set; }
        public ICollection<Vuelo> VueloDestinoNavigation { get; set; }
        public ICollection<Vuelo> VueloOrigenNavigation { get; set; }
    }
}

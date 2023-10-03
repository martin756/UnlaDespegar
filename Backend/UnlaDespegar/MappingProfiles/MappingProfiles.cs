using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlaDespegar.Data;
using UnlaDespegar.Data.Requets;
using UnlaDespegar.Models;

namespace UnlaDespegar.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Map Vuelo
            CreateMap<Vuelo, VueloResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.FechaIda, opts => opts.MapFrom(src => src.FechaIda))
            .ForMember(dest => dest.FechaVuelta, opts => opts.MapFrom(src => src.FechaVuelta))
            .ForMember(dest => dest.NombreAerolinea, opts => opts.MapFrom(src => src.NombreAerolinea))
            .ForMember(dest => dest.IdaVuelta, opts => opts.MapFrom(src => src.IdaVuelta))
            .ForMember(dest => dest.ValoracionAerolinea, opts => opts.MapFrom(src => src.ValoracionAerolinea))
            .ForMember(dest => dest.Clase, opts => opts.MapFrom(src => src.Clase))
            .ForMember(dest => dest.ConEscala, opts => opts.MapFrom(src => src.ConEscala))
            .ForMember(dest => dest.AccesoDiscapacitados, opts => opts.MapFrom(src => src.AccesoDiscapacitados))
            .ForMember(dest => dest.Precio, opts => opts.MapFrom(src => src.Precio))
            .ForMember(dest => dest.Link, opts => opts.MapFrom(src => src.Link))

            .ForPath(dest => dest.Origen, opts => opts.MapFrom(src => new DestinoResponse
            {
                Id = src.OrigenNavigation.Id,
                Ciudad = src.OrigenNavigation.Ciudad,
                Pais = src.OrigenNavigation.Pais,
                Region = src.OrigenNavigation.Region
            }))
            .ForPath(dest => dest.Destino, opts => opts.MapFrom(src => new DestinoResponse
            {
                Id = src.DestinoNavigation.Id,
                Ciudad = src.DestinoNavigation.Ciudad,
                Pais = src.DestinoNavigation.Pais,
                Region = src.DestinoNavigation.Region
            }));
            #endregion

            #region Map Destino
            CreateMap<Destino, DestinoResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Pais, opts => opts.MapFrom(src => src.Pais))
            .ForMember(dest => dest.Ciudad, opts => opts.MapFrom(src => src.Ciudad))
            .ForMember(dest => dest.Region, opts => opts.MapFrom(src => src.Region));
            #endregion

            #region Map Usuario
            CreateMap<Usuario, UsuarioResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Dni, opts => opts.MapFrom(src => src.Dni))
            .ForMember(dest => dest.Nombre, opts => opts.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellido, opts => opts.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Nacionalidad, opts => opts.MapFrom(src => src.Nacionalidad))
            .ForMember(dest => dest.Domicilio, opts => opts.MapFrom(src => src.Domicilio))
            .ForMember(dest => dest.Mail, opts => opts.MapFrom(src => src.Mail))
            .ForMember(dest => dest.Telefono, opts => opts.MapFrom(src => src.Telefono))
            .ForMember(dest => dest.Contraseña, opts => opts.MapFrom(src => src.Contraseña))
            .ForMember(dest => dest.IsAdmin, opts => opts.MapFrom(src => src.IsAdmin));
            #endregion

            #region Map Reserva
            CreateMap<Reserva, ReservaResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Importe, opts => opts.MapFrom(src => 0))
            .ForMember(dest => dest.NroReserva, opts => opts.MapFrom(src => src.NroReserva))
            .ForMember(dest => dest.ReservaFinalizada, opts => opts.MapFrom(src => src.ReservaFinalizada))
            .ForMember(dest => dest.FechaEntrada, opts => opts.MapFrom(src => src.FechaEntrada))
            .ForMember(dest => dest.FechaSalida, opts => opts.MapFrom(src => src.FechaSalida))

            .ForPath(dest => dest.Destino, opts => opts.MapFrom(src => new DestinoResponse
            {
                Id = src.DestinoNavigation.Id,
                Ciudad = src.DestinoNavigation.Ciudad,
                Pais = src.DestinoNavigation.Pais,
                Region = src.DestinoNavigation.Region
            }))

            .ForPath(dest => dest.Vuelo, opts => opts.MapFrom(src => new VueloResponse
            {
                Id = src.VueloNavigation.Id,
                AccesoDiscapacitados = src.VueloNavigation.AccesoDiscapacitados,
                FechaVuelta = src.VueloNavigation.FechaVuelta,
                FechaIda = src.VueloNavigation.FechaIda,
                NombreAerolinea = src.VueloNavigation.NombreAerolinea,
                Clase = src.VueloNavigation.Clase,
                ConEscala = src.VueloNavigation.ConEscala,
                IdaVuelta = src.VueloNavigation.IdaVuelta,
                ValoracionAerolinea = src.VueloNavigation.ValoracionAerolinea,
                Precio = src.VueloNavigation.Precio,
                Link = src.VueloNavigation.Link,
                Destino = new DestinoResponse
                {
                    Id = src.VueloNavigation.DestinoNavigation.Id,
                    Ciudad = src.VueloNavigation.DestinoNavigation.Ciudad,
                    Pais = src.VueloNavigation.DestinoNavigation.Pais,
                    Region = src.VueloNavigation.DestinoNavigation.Region
                },
                Origen = new DestinoResponse
                {
                    Id = src.VueloNavigation.OrigenNavigation.Id,
                    Ciudad = src.VueloNavigation.OrigenNavigation.Ciudad,
                    Pais = src.VueloNavigation.OrigenNavigation.Pais,
                    Region = src.VueloNavigation.OrigenNavigation.Region
                }
            }))

            .ForPath(dest => dest.Usuario, opts => opts.MapFrom(src => new UsuarioResponse
            {
                Id = src.UsuarioNavigation.Id,
                Apellido = src.UsuarioNavigation.Apellido,
                Contraseña = src.UsuarioNavigation.Contraseña,
                Dni = src.UsuarioNavigation.Dni,
                Domicilio = src.UsuarioNavigation.Domicilio,
                Mail = src.UsuarioNavigation.Mail,
                Nacionalidad = src.UsuarioNavigation.Nacionalidad,
                Nombre = src.UsuarioNavigation.Nombre,
                IsAdmin = src.UsuarioNavigation.IsAdmin,
                Telefono = src.UsuarioNavigation.Telefono
            }));
            #endregion

            #region Map Pasajero
            CreateMap<Pasajero, PasajeroResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Dni, opts => opts.MapFrom(src => src.Dni))
            .ForMember(dest => dest.Nombre, opts => opts.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellido, opts => opts.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Nacionalidad, opts => opts.MapFrom(src => src.Nacionalidad))
            .ForMember(dest => dest.Domicilio, opts => opts.MapFrom(src => src.Domicilio))
            .ForMember(dest => dest.Mail, opts => opts.MapFrom(src => src.Mail))
            .ForMember(dest => dest.Telefono, opts => opts.MapFrom(src => src.Telefono))
            .ForMember(dest => dest.Reserva, opts => opts.MapFrom(src => src.Reserva));
            #endregion

            #region Map RequestPasajero
            CreateMap<RequestPasajero, Pasajero>()
            .ForMember(dest => dest.Id, opts => opts.Ignore())
            .ForMember(dest => dest.Dni, opts => opts.MapFrom(src => src.Dni))
            .ForMember(dest => dest.Nombre, opts => opts.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellido, opts => opts.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Nacionalidad, opts => opts.MapFrom(src => src.Nacionalidad))
            .ForMember(dest => dest.Domicilio, opts => opts.MapFrom(src => src.Domicilio))
            .ForMember(dest => dest.Mail, opts => opts.MapFrom(src => src.Mail))
            .ForMember(dest => dest.Telefono, opts => opts.MapFrom(src => src.Telefono))
            .ForMember(dest => dest.Reserva, opts => opts.Ignore());
            #endregion

            #region Map RequestReserva
            CreateMap<RequestReserva, Reserva>()
            .ForMember(dest => dest.Id, opts => opts.Ignore())
            .ForMember(dest => dest.NroReserva, opts => opts.MapFrom(src => src.NroReserva))
            .ForMember(dest => dest.Usuario, opts => opts.MapFrom(src => src.Usuario))
            .ForMember(dest => dest.Destino, opts => opts.MapFrom(src => src.Destino))
            .ForMember(dest => dest.Vuelo, opts => opts.MapFrom(src => src.Vuelo))
            .ForMember(dest => dest.ReservaFinalizada, opts => opts.MapFrom(src => src.ReservaFinalizada))
            .ForMember(dest => dest.FechaEntrada, opts => opts.MapFrom(src => src.FechaEntrada))
            .ForMember(dest => dest.FechaSalida, opts => opts.MapFrom(src => src.FechaSalida))
            .ForMember(dest => dest.Importe, opts => opts.MapFrom(src => 0));
            #endregion
        }
    }
}

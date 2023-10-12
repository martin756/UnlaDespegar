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

            #region Map TipoRegimen
            CreateMap<TipoRegimen, TipoRegimenResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Descripcion, opts => opts.MapFrom(src => src.Descripcion));
            #endregion

            #region Map TipoAlojamiento
            CreateMap<TipoAlojamiento, TipoAlojamientoResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Descripcion, opts => opts.MapFrom(src => src.Descripcion));
            #endregion

            #region Map Actividad
            CreateMap<Actividad, ActividadResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.FechaDesde, opts => opts.MapFrom(src => src.FechaDesde))
            .ForMember(dest => dest.FechaHasta, opts => opts.MapFrom(src => src.FechaHasta))
            .ForMember(dest => dest.NombreActividad, opts => opts.MapFrom(src => src.NombreActividad))
            .ForMember(dest => dest.Descripcion, opts => opts.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.FranjaHoraria, opts => opts.MapFrom(src => src.FranjaHoraria))
            .ForMember(dest => dest.Valoracion, opts => opts.MapFrom(src => src.Valoracion))
            .ForMember(dest => dest.AccesoDiscapacitados, opts => opts.MapFrom(src => src.AccesoDiscapacitados))
            .ForMember(dest => dest.Precio, opts => opts.MapFrom(src => src.Precio))
            .ForMember(dest => dest.Link, opts => opts.MapFrom(src => src.Link))

             .ForPath(dest => dest.Destino, opts => opts.MapFrom(src => new DestinoResponse
             {
                 Id = src.DestinoNavigation.Id,
                 Ciudad = src.DestinoNavigation.Ciudad,
                 Pais = src.DestinoNavigation.Pais,
                 Region = src.DestinoNavigation.Region
             }));
            #endregion

            #region Map Alojamiento
            CreateMap<Alojamiento, AlojamientoResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.CantidadEstrellas, opts => opts.MapFrom(src => src.CantidadEstrellas))
            .ForMember(dest => dest.NombreAlojamiento, opts => opts.MapFrom(src => src.NombreAlojamiento))
            .ForMember(dest => dest.Link, opts => opts.MapFrom(src => src.Link))
            .ForMember(dest => dest.TipoServicio, opts => opts.MapFrom(src => src.TipoServicio))
            .ForMember(dest => dest.TipoHabitacion, opts => opts.MapFrom(src => src.TipoHabitacion))
            .ForMember(dest => dest.AccesoDiscapacitados, opts => opts.MapFrom(src => src.AccesoDiscapacitados))
            .ForMember(dest => dest.Precio, opts => opts.MapFrom(src => src.Precio))

            .ForPath(dest => dest.Destino, opts => opts.MapFrom(src => new DestinoResponse
            {
                Id = src.DestinoNavigation.Id,
                Ciudad = src.DestinoNavigation.Ciudad,
                Pais = src.DestinoNavigation.Pais,
                Region = src.DestinoNavigation.Region
            }))

            .ForPath(dest => dest.TipoAlojamiento, opts => opts.MapFrom(src => new TipoAlojamientoResponse
             {
                 Id = src.TipoAlojamientoNavigation.Id,
                 Descripcion = src.TipoAlojamientoNavigation.Descripcion,
             }))

            .ForPath(dest => dest.TipoRegimen, opts => opts.MapFrom(src => new TipoRegimenResponse
                {
                    Id = src.TipoRegimenNavigation.Id,
                    Descripcion = src.TipoRegimenNavigation.Descripcion,
            }));
            #endregion

            #region Map Paquete
            CreateMap<Paquete, PaqueteResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.TipoPaquete, opts => opts.MapFrom(src => src.TipoPaquete))
            .ForMember(dest => dest.FechaIda, opts => opts.MapFrom(src => src.FechaIda))
            .ForMember(dest => dest.FechaVuelta, opts => opts.MapFrom(src => src.FechaVuelta))
            .ForMember(dest => dest.CantidadPersonas, opts => opts.MapFrom(src => src.CantidadPersonas))
            .ForMember(dest => dest.Habitaciones, opts => opts.MapFrom(src => src.Habitaciones))
            .ForMember(dest => dest.AccesoDiscapacitados, opts => opts.MapFrom(src => src.AccesoDiscapacitados))
            .ForMember(dest => dest.Precio, opts => opts.MapFrom(src => (src.AlojamientoNavigation.Precio * Convert.ToDecimal(Math.Round((src.FechaVuelta - src.FechaIda).TotalDays)) * src.Habitaciones) + (src.VueloNavigation.Precio * src.CantidadPersonas) + (src.ActividadNavigation.Precio * src.CantidadPersonas)))

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
                Destino = new DestinoResponse {
                    Id = src.VueloNavigation.DestinoNavigation.Id ,
                    Ciudad = src.VueloNavigation.DestinoNavigation.Ciudad,
                    Pais = src.VueloNavigation.DestinoNavigation.Pais,
                    Region = src.VueloNavigation.DestinoNavigation.Region
                },
                Origen= new DestinoResponse {
                    Id = src.VueloNavigation.OrigenNavigation.Id,
                    Ciudad = src.VueloNavigation.OrigenNavigation.Ciudad,
                    Pais = src.VueloNavigation.OrigenNavigation.Pais,
                    Region = src.VueloNavigation.OrigenNavigation.Region
                }
            }))

            .ForPath(dest => dest.Actividad, opts => opts.MapFrom(src => new ActividadResponse
              {
                  Id = src.ActividadNavigation.Id,
                  FechaDesde = src.ActividadNavigation.FechaDesde,
                  FechaHasta = src.ActividadNavigation.FechaHasta,
                  AccesoDiscapacitados = src.ActividadNavigation.AccesoDiscapacitados,
                  Descripcion = src.ActividadNavigation.Descripcion,
                  FranjaHoraria = src.ActividadNavigation.FranjaHoraria,
                  NombreActividad = src.ActividadNavigation.NombreActividad,
                  Valoracion = src.ActividadNavigation.Valoracion,
                  Precio = src.ActividadNavigation.Precio,
                  Link = src.ActividadNavigation.Link,
                  Destino = new DestinoResponse
                  {
                      Id = src.ActividadNavigation.DestinoNavigation.Id,
                      Ciudad = src.ActividadNavigation.DestinoNavigation.Ciudad,
                      Pais = src.ActividadNavigation.DestinoNavigation.Pais,
                      Region = src.ActividadNavigation.DestinoNavigation.Region
                  }
              }))

            .ForPath(dest => dest.Alojamiento, opts => opts.MapFrom(src => new AlojamientoResponse
             {
                 Id = src.AlojamientoNavigation.Id,
                 CantidadEstrellas = src.AlojamientoNavigation.CantidadEstrellas,
                 Link = src.AlojamientoNavigation.Link,
                 AccesoDiscapacitados = src.AlojamientoNavigation.AccesoDiscapacitados,
                 NombreAlojamiento = src.AlojamientoNavigation.NombreAlojamiento,
                 TipoServicio = src.AlojamientoNavigation.TipoServicio,
                 TipoHabitacion = src.AlojamientoNavigation.TipoHabitacion,
                 Precio = src.AlojamientoNavigation.Precio,
                 Destino = new DestinoResponse
                 {
                     Id = src.AlojamientoNavigation.DestinoNavigation.Id,
                     Ciudad = src.AlojamientoNavigation.DestinoNavigation.Ciudad,
                     Pais = src.AlojamientoNavigation.DestinoNavigation.Pais,
                     Region = src.AlojamientoNavigation.DestinoNavigation.Region
                 },

                TipoAlojamiento = new TipoAlojamientoResponse
                 {
                     Id= src.AlojamientoNavigation.TipoAlojamientoNavigation.Id,
                     Descripcion= src.AlojamientoNavigation.TipoAlojamientoNavigation.Descripcion
                 },

                TipoRegimen = new TipoRegimenResponse
                {
                    Id = src.AlojamientoNavigation.TipoRegimenNavigation.Id,
                    Descripcion = src.AlojamientoNavigation.TipoRegimenNavigation.Descripcion
                }
            }));
            #endregion

            #region Map Reserva
            CreateMap<Reserva, ReservaResponse>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Importe, opts => opts.MapFrom(src => 0))
            .ForMember(dest => dest.NroReserva, opts => opts.MapFrom(src => src.NroReserva))
            .ForMember(dest => dest.EsUnPaquete, opts => opts.MapFrom(src => src.EsUnPaquete))
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

            .ForPath(dest => dest.Actividad, opts => opts.MapFrom(src => new ActividadResponse
            {
                Id = src.ActividadNavigation.Id,
                FechaDesde = src.ActividadNavigation.FechaDesde,
                FechaHasta = src.ActividadNavigation.FechaHasta,
                AccesoDiscapacitados = src.ActividadNavigation.AccesoDiscapacitados,
                Descripcion = src.ActividadNavigation.Descripcion,
                FranjaHoraria = src.ActividadNavigation.FranjaHoraria,
                NombreActividad = src.ActividadNavigation.NombreActividad,
                Valoracion = src.ActividadNavigation.Valoracion,
                Precio = src.ActividadNavigation.Precio,
                Link = src.ActividadNavigation.Link,
                Destino = new DestinoResponse
                {
                    Id = src.ActividadNavigation.DestinoNavigation.Id,
                    Ciudad = src.ActividadNavigation.DestinoNavigation.Ciudad,
                    Pais = src.ActividadNavigation.DestinoNavigation.Pais,
                    Region = src.ActividadNavigation.DestinoNavigation.Region
                }
            }))

            .ForPath(dest => dest.Alojamiento, opts => opts.MapFrom(src => new AlojamientoResponse
            {
                Id = src.AlojamientoNavigation.Id,
                CantidadEstrellas = src.AlojamientoNavigation.CantidadEstrellas,
                Link = src.AlojamientoNavigation.Link,
                AccesoDiscapacitados = src.AlojamientoNavigation.AccesoDiscapacitados,
                NombreAlojamiento = src.AlojamientoNavigation.NombreAlojamiento,
                TipoServicio = src.AlojamientoNavigation.TipoServicio,
                TipoHabitacion = src.AlojamientoNavigation.TipoHabitacion,
                Precio = src.AlojamientoNavigation.Precio,
                Destino = new DestinoResponse
                {
                    Id = src.AlojamientoNavigation.DestinoNavigation.Id,
                    Ciudad = src.AlojamientoNavigation.DestinoNavigation.Ciudad,
                    Pais = src.AlojamientoNavigation.DestinoNavigation.Pais,
                    Region = src.AlojamientoNavigation.DestinoNavigation.Region
                },

                TipoAlojamiento = new TipoAlojamientoResponse
                {
                    Id = src.AlojamientoNavigation.TipoAlojamientoNavigation.Id,
                    Descripcion = src.AlojamientoNavigation.TipoAlojamientoNavigation.Descripcion
                },

                TipoRegimen = new TipoRegimenResponse
                {
                    Id = src.AlojamientoNavigation.TipoRegimenNavigation.Id,
                    Descripcion = src.AlojamientoNavigation.TipoRegimenNavigation.Descripcion
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
            }))

            .ForPath(dest => dest.Paquete, opts => opts.MapFrom(src => new PaqueteResponse
            {
            
                Id= src.PaqueteNavigation.Id, 
                TipoPaquete= src.PaqueteNavigation.TipoPaquete,
                FechaIda = src.PaqueteNavigation.FechaIda,
                FechaVuelta = src.PaqueteNavigation.FechaVuelta,
                CantidadPersonas = src.PaqueteNavigation.CantidadPersonas,
                Habitaciones = src.PaqueteNavigation.Habitaciones,
                AccesoDiscapacitados = src.PaqueteNavigation.AccesoDiscapacitados,
                Precio = (src.PaqueteNavigation.AlojamientoNavigation.Precio * Convert.ToDecimal(Math.Round((src.PaqueteNavigation.FechaVuelta - src.PaqueteNavigation.FechaIda).TotalDays)) * src.PaqueteNavigation.Habitaciones) + (src.PaqueteNavigation.VueloNavigation.Precio * src.PaqueteNavigation.CantidadPersonas) + (src.PaqueteNavigation.ActividadNavigation.Precio * src.PaqueteNavigation.CantidadPersonas),

                Destino = new DestinoResponse
                {
                    Id = src.PaqueteNavigation.DestinoNavigation.Id,
                    Ciudad = src.PaqueteNavigation.DestinoNavigation.Ciudad,
                    Pais = src.PaqueteNavigation.DestinoNavigation.Pais,
                    Region = src.PaqueteNavigation.DestinoNavigation.Region
                },

                Vuelo = new VueloResponse
                {
                    Id = src.PaqueteNavigation.VueloNavigation.Id,
                    AccesoDiscapacitados = src.PaqueteNavigation.VueloNavigation.AccesoDiscapacitados,
                    FechaVuelta = src.PaqueteNavigation.VueloNavigation.FechaVuelta,
                    FechaIda = src.PaqueteNavigation.VueloNavigation.FechaIda,
                    NombreAerolinea = src.PaqueteNavigation.VueloNavigation.NombreAerolinea,
                    Clase = src.PaqueteNavigation.VueloNavigation.Clase,
                    ConEscala = src.PaqueteNavigation.VueloNavigation.ConEscala,
                    IdaVuelta = src.PaqueteNavigation.VueloNavigation.IdaVuelta,
                    ValoracionAerolinea = src.PaqueteNavigation.VueloNavigation.ValoracionAerolinea,
                    Precio = src.PaqueteNavigation.VueloNavigation.Precio,
                    Link = src.PaqueteNavigation.VueloNavigation.Link,
                    Destino = new DestinoResponse
                    {
                        Id = src.PaqueteNavigation.VueloNavigation.DestinoNavigation.Id,
                        Ciudad = src.PaqueteNavigation.VueloNavigation.DestinoNavigation.Ciudad,
                        Pais = src.PaqueteNavigation.VueloNavigation.DestinoNavigation.Pais,
                        Region = src.PaqueteNavigation.VueloNavigation.DestinoNavigation.Region
                    },
                    Origen = new DestinoResponse
                    {
                        Id = src.PaqueteNavigation.VueloNavigation.OrigenNavigation.Id,
                        Ciudad = src.PaqueteNavigation.VueloNavigation.OrigenNavigation.Ciudad,
                        Pais = src.PaqueteNavigation.VueloNavigation.OrigenNavigation.Pais,
                        Region = src.PaqueteNavigation.VueloNavigation.OrigenNavigation.Region
                    }
                },

                Actividad = new ActividadResponse
                {
                    Id = src.PaqueteNavigation.ActividadNavigation.Id,
                    FechaDesde = src.PaqueteNavigation.ActividadNavigation.FechaDesde,
                    FechaHasta = src.PaqueteNavigation.ActividadNavigation.FechaHasta,
                    AccesoDiscapacitados = src.PaqueteNavigation.ActividadNavigation.AccesoDiscapacitados,
                    Descripcion = src.PaqueteNavigation.ActividadNavigation.Descripcion,
                    FranjaHoraria = src.PaqueteNavigation.ActividadNavigation.FranjaHoraria,
                    NombreActividad = src.PaqueteNavigation.ActividadNavigation.NombreActividad,
                    Valoracion = src.PaqueteNavigation.ActividadNavigation.Valoracion,
                    Precio = src.PaqueteNavigation.ActividadNavigation.Precio,
                    Link = src.PaqueteNavigation.ActividadNavigation.Link,
                    Destino = new DestinoResponse
                    {
                        Id = src.PaqueteNavigation.ActividadNavigation.DestinoNavigation.Id,
                        Ciudad = src.PaqueteNavigation.ActividadNavigation.DestinoNavigation.Ciudad,
                        Pais = src.PaqueteNavigation.ActividadNavigation.DestinoNavigation.Pais,
                        Region = src.PaqueteNavigation.ActividadNavigation.DestinoNavigation.Region
                    }
                },

                Alojamiento = new AlojamientoResponse
                {
                    Id = src.PaqueteNavigation.AlojamientoNavigation.Id,
                    CantidadEstrellas = src.PaqueteNavigation.AlojamientoNavigation.CantidadEstrellas,
                    Link = src.PaqueteNavigation.AlojamientoNavigation.Link,
                    AccesoDiscapacitados = src.PaqueteNavigation.AlojamientoNavigation.AccesoDiscapacitados,
                    NombreAlojamiento = src.PaqueteNavigation.AlojamientoNavigation.NombreAlojamiento,
                    TipoServicio = src.PaqueteNavigation.AlojamientoNavigation.TipoServicio,
                    TipoHabitacion = src.PaqueteNavigation.AlojamientoNavigation.TipoHabitacion,
                    Precio = src.PaqueteNavigation.AlojamientoNavigation.Precio,
                    Destino = new DestinoResponse
                    {
                        Id = src.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation.Id,
                        Ciudad = src.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation.Ciudad,
                        Pais = src.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation.Pais,
                        Region = src.PaqueteNavigation.AlojamientoNavigation.DestinoNavigation.Region
                    },

                    TipoAlojamiento = new TipoAlojamientoResponse
                    {
                        Id = src.PaqueteNavigation.AlojamientoNavigation.TipoAlojamientoNavigation.Id,
                        Descripcion = src.PaqueteNavigation.AlojamientoNavigation.TipoAlojamientoNavigation.Descripcion
                    },

                    TipoRegimen = new TipoRegimenResponse
                    {
                        Id = src.PaqueteNavigation.AlojamientoNavigation.TipoRegimenNavigation.Id,
                        Descripcion = src.PaqueteNavigation.AlojamientoNavigation.TipoRegimenNavigation.Descripcion
                    }
                }
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
            .ForMember(dest => dest.Alojamiento, opts => opts.MapFrom(src => src.Alojamiento))
            .ForMember(dest => dest.Actividad, opts => opts.MapFrom(src => src.Actividad))
            .ForMember(dest => dest.Vuelo, opts => opts.MapFrom(src => src.Vuelo))
            .ForMember(dest => dest.EsUnPaquete, opts => opts.MapFrom(src => src.EsUnPaquete))
            .ForMember(dest => dest.Paquete, opts => opts.MapFrom(src => src.Paquete))
            .ForMember(dest => dest.ReservaFinalizada, opts => opts.MapFrom(src => src.ReservaFinalizada))
            .ForMember(dest => dest.FechaEntrada, opts => opts.MapFrom(src => src.FechaEntrada))
            .ForMember(dest => dest.FechaSalida, opts => opts.MapFrom(src => src.FechaSalida))
            .ForMember(dest => dest.Importe, opts => opts.MapFrom(src => 0));
            #endregion
        }
    }
}

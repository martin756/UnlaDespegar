using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnlaDespegar.Models
{
    public partial class UnlaDespegarContext : DbContext
    {
        public UnlaDespegarContext()
        {
        }

        public UnlaDespegarContext(DbContextOptions<UnlaDespegarContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Destino> Destino { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Pasajero> Pasajero { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vuelo> Vuelo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=UnlaDespegar;Trusted_Connection=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destino>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasColumnName("ciudad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnName("pais")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Destino).HasColumnName("destino");

                entity.Property(e => e.ReservaFinalizada).HasColumnName("reservaFinalizada");

                entity.Property(e => e.Importe)
                    .HasColumnName("importe")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.NroReserva)
                    .IsRequired()
                    .HasColumnName("nroReserva")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrada)
                 .HasColumnName("fechaEntrada")
                 .HasColumnType("datetime");

                entity.Property(e => e.FechaSalida)
                 .HasColumnName("fechaSalida")
                 .HasColumnType("datetime");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.Property(e => e.Vuelo).HasColumnName("vuelo");

                entity.HasOne(d => d.DestinoNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Destino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Destino");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Usuario");

                entity.HasOne(d => d.VueloNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Vuelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Vuelo");
            });

            modelBuilder.Entity<Pasajero>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Reserva).HasColumnName("reserva");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasColumnName("domicilio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasColumnName("nacionalidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReservaNavigation)
                   .WithMany(p => p.Pasajero)
                   .HasForeignKey(d => d.Reserva)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_Pasajero_Reserva");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasColumnName("domicilio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasColumnName("nacionalidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccesoDiscapacitados).HasColumnName("accesoDiscapacitados");

                entity.Property(e => e.Clase)
                    .IsRequired()
                    .HasColumnName("clase")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAereolinea)
                  .IsRequired()
                  .HasColumnName("nombreAereolinea")
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.Link)
                  .HasColumnName("link")
                  .IsUnicode(false);

                entity.Property(e => e.ConEscala).HasColumnName("conEscala");

                entity.Property(e => e.Destino).HasColumnName("destino");

                entity.Property(e => e.Precio)
                     .HasColumnName("precio")
                     .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.FechaIda)
                    .HasColumnName("fechaIda")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaVuelta)
                    .HasColumnName("fechaVuelta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdaVuelta).HasColumnName("idaVuelta");

                entity.Property(e => e.Origen).HasColumnName("origen");

                entity.Property(e => e.ValoracionAereolinea).HasColumnName("valoracionAereolinea");

                entity.HasOne(d => d.DestinoNavigation)
                    .WithMany(p => p.VueloDestinoNavigation)
                    .HasForeignKey(d => d.Destino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vuelo_Destino");

                entity.HasOne(d => d.OrigenNavigation)
                    .WithMany(p => p.VueloOrigenNavigation)
                    .HasForeignKey(d => d.Origen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vuelo_Origen");
            });
        }
    }
}

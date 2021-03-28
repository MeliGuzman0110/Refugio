using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DO.Objects;

namespace DAL.EF
{
    public class RefugioAnimalDBContext : DbContext
    {
        public RefugioAnimalDBContext(DbContextOptions<RefugioAnimalDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Adopcion> Adopcion { get; set; }
        public virtual DbSet<Adoptantes> Adoptantes { get; set; }
        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Donacion> Donacion { get; set; }
        public virtual DbSet<Donantes> Donantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=RefugioAnimal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adopcion>(entity =>
            {
                entity.HasKey(e => e.Idadopcion);

                entity.Property(e => e.Idadopcion).HasColumnName("IDAdopcion");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.Edad).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Idadoptante).HasColumnName("IDAdoptante");

                entity.Property(e => e.Raza).HasMaxLength(50);

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.HasOne(d => d.IdadoptanteNavigation)
                    .WithMany(p => p.Adopcion)
                    .HasForeignKey(d => d.Idadoptante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adopcion_Adoptantes");
            });

            modelBuilder.Entity<Adoptantes>(entity =>
            {
                entity.HasKey(e => e.Idadoptante);

                entity.Property(e => e.Idadoptante).HasColumnName("IDAdoptante");

                entity.Property(e => e.Apellidos).HasMaxLength(75);

                entity.Property(e => e.Cedula).HasMaxLength(15);

                entity.Property(e => e.Direccion).HasMaxLength(150);

                entity.Property(e => e.Nombre).HasMaxLength(25);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });


            modelBuilder.Entity<Donacion>(entity =>
            {
                entity.HasKey(e => e.Iddonacion);

                entity.Property(e => e.Iddonacion)
                    .HasColumnName("IDDonacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Iddonante).HasColumnName("IDDonante");

                entity.HasOne(d => d.IddonanteNavigation)
                    .WithMany(p => p.Donacion)
                    .HasForeignKey(d => d.Iddonante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donacion_Donantes1");
            });

            modelBuilder.Entity<Donantes>(entity =>
            {
                entity.HasKey(e => e.Iddonante);

                entity.Property(e => e.Iddonante).HasColumnName("IDDonante");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Telefono).HasMaxLength(15);
            });

        }

    }
}

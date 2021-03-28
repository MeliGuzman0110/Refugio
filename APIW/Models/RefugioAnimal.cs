using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIW.Models
{
    public partial class RefugioAnimal : DbContext
    {
        public RefugioAnimal()
        {
        }

        public RefugioAnimal(DbContextOptions<RefugioAnimal> options)
            : base(options)
        {
        }

        public virtual DbSet<Adopcion> Adopcion { get; set; }
        public virtual DbSet<Adoptantes> Adoptantes { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Donacion> Donacion { get; set; }
        public virtual DbSet<Donantes> Donantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=HappyPets;Trusted_Connection=True;");
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

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

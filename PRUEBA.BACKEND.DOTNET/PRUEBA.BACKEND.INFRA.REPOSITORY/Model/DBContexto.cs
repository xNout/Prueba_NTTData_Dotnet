using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PRUEBA.BACKEND.DOMAIN.Entities;

namespace PRUEBA.BACKEND.INFRA.REPOSITORY.Model
{
    public partial class DBContexto : DbContext
    {
        public DBContexto()
        {
        }

        public DBContexto(DbContextOptions<DBContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuentas { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D594664256668FF3");

                entity.ToTable("Cliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("PK__Cuenta__D41FD70625313A3D");

                entity.ToTable("Cuenta");

                entity.Property(e => e.Numero)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento)
                    .HasName("PK__Movimien__881A6AE033D54183");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TipoMovimiento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__2EC8D2AC8E37F6D6");

                entity.ToTable("Persona");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}

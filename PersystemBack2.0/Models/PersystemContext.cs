using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersystemBack2._0.Models;

public partial class PersystemContext : DbContext
{
    public PersystemContext()
    {
    }

    public PersystemContext(DbContextOptions<PersystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<ContratoPredio> ContratoPredios { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialHasProveedor> MaterialHasProveedors { get; set; }

    public virtual DbSet<MaterialServicio> MaterialServicios { get; set; }

    public virtual DbSet<Predio> Predios { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Representante> Representantes { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    public virtual DbSet<TrabajadorPredio> TrabajadorPredios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8A4S6J7; Database=Persystem; Trusted_Connection=True; TrustServerCertificate=true ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.CodContrato).HasName("PK__contrato__37C07AA4538608D7");

            entity.ToTable("contrato");

            entity.HasIndex(e => e.CodContrato, "UQ_CONTRATO").IsUnique();

            entity.Property(e => e.CodContrato)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_contrato");
            entity.Property(e => e.CodSer)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_ser");
            entity.Property(e => e.FechaFinalContr)
                .HasColumnType("date")
                .HasColumnName("fecha_final_contr");
            entity.Property(e => e.FechaInicioContr)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio_contr");
            entity.Property(e => e.NitPredio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit_predio");
            entity.Property(e => e.PrecioContrato).HasColumnName("precio_contrato");

            entity.HasOne(d => d.CodSerNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.CodSer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contrato_servicio");

            entity.HasOne(d => d.NitPredioNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.NitPredio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contrato_predio");
        });

        modelBuilder.Entity<ContratoPredio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("contrato_predio");

            entity.Property(e => e.CodContrato)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_contrato");
            entity.Property(e => e.CodSer)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_ser");
            entity.Property(e => e.NomPredio)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nom_predio");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.CodUsuario);

            entity.ToTable("login");

            entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");
            entity.Property(e => e.CedulaTrab)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cedula_trab");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.CedulaTrabNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.CedulaTrab)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_login_trabajador");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.CodMat).HasName("PK__material__F822F5F1E9A1090B");

            entity.ToTable("material");

            entity.HasIndex(e => e.CodMat, "UQ_MATERIAL").IsUnique();

            entity.Property(e => e.CodMat)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_mat");
            entity.Property(e => e.DesMat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("des_mat");
            entity.Property(e => e.FechaEntrada)
                .HasColumnType("date")
                .HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("date")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.NomMat)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom_mat");
            entity.Property(e => e.NumUnidades)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("num_unidades");
            entity.Property(e => e.PrecioMat).HasColumnName("precio_mat");
            entity.Property(e => e.TipoMat)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipo_mat");
        });

        modelBuilder.Entity<MaterialHasProveedor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("material_has_proveedor");

            entity.Property(e => e.CodMat)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_mat");
            entity.Property(e => e.CodProveedor)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_proveedor");

            entity.HasOne(d => d.CodMatNavigation).WithMany()
                .HasForeignKey(d => d.CodMat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_has_material_ibfk_2");

            entity.HasOne(d => d.CodProveedorNavigation).WithMany()
                .HasForeignKey(d => d.CodProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_has_material_ibfk_1");
        });

        modelBuilder.Entity<MaterialServicio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("material_servicio");

            entity.Property(e => e.CodContrato)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_contrato");
            entity.Property(e => e.DesSer)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_ser");
            entity.Property(e => e.NomSer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nom_ser");
        });

        modelBuilder.Entity<Predio>(entity =>
        {
            entity.HasKey(e => e.NitPredio).HasName("PK__predio__67CA64AD4AB21A48");

            entity.ToTable("predio");

            entity.HasIndex(e => e.NitPredio, "UQ_NIT").IsUnique();

            entity.Property(e => e.NitPredio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit_predio");
            entity.Property(e => e.CorreoPredio)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo_predio");
            entity.Property(e => e.CuartosPredio).HasColumnName("cuartos_predio");
            entity.Property(e => e.DirPredio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dir_predio");
            entity.Property(e => e.DocumentoRepre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("documento_repre");
            entity.Property(e => e.NomPredio)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nom_predio");
            entity.Property(e => e.TipoCuarto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipo_cuarto");

            entity.HasOne(d => d.DocumentoRepreNavigation).WithMany(p => p.Predios)
                .HasForeignKey(d => d.DocumentoRepre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_predio_representante");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.CodProveedor).HasName("PK__proveedo__D4A662EB95F3E807");

            entity.ToTable("proveedor");

            entity.HasIndex(e => e.CodProveedor, "UQ_PROVEEDOR").IsUnique();

            entity.Property(e => e.CodProveedor)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_proveedor");
            entity.Property(e => e.DirProveedor)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dir_proveedor");
            entity.Property(e => e.NomProveedor)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom_proveedor");
            entity.Property(e => e.TelProveedor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tel_proveedor");
        });

        modelBuilder.Entity<Representante>(entity =>
        {
            entity.HasKey(e => e.DocumentoRepre).HasName("PK__represen__08E51A5F5C41A240");

            entity.ToTable("representante", tb => tb.HasTrigger("VerificarCorreo"));

            entity.HasIndex(e => e.DocumentoRepre, "UQ_DOCUMENTO").IsUnique();

            entity.Property(e => e.DocumentoRepre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("documento_repre");
            entity.Property(e => e.ApellRepre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("apell_repre");
            entity.Property(e => e.CorreoRepre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("correo_repre");
            entity.Property(e => e.DiaAtencion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dia_atencion");
            entity.Property(e => e.HoraAtencion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("hora_atencion");
            entity.Property(e => e.NomRepre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom_repre");
            entity.Property(e => e.TelRepre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tel_repre");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.CodSer).HasName("PK__servicio__F2C26CDFE9D7FB85");

            entity.ToTable("servicio");

            entity.HasIndex(e => e.CodSer, "UQ_SERVICIO").IsUnique();

            entity.Property(e => e.CodSer)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_ser");
            entity.Property(e => e.CodMat)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_mat");
            entity.Property(e => e.DesSer)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_ser");
            entity.Property(e => e.DuracionSer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duracion_ser");
            entity.Property(e => e.NomSer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nom_ser");
            entity.Property(e => e.PrecioSer).HasColumnName("precio_ser");
            entity.Property(e => e.TipoSer)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("tipo_ser");

            entity.HasOne(d => d.CodMatNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.CodMat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_servicio_material");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.CedulaTrab).HasName("PK__trabajad__90BBDBC204147A4F");

            entity.ToTable("trabajador", tb => tb.HasTrigger("VerificarCorreoTrabajador"));

            entity.Property(e => e.CedulaTrab)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cedula_trab");
            entity.Property(e => e.ApellTrab)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("apell_trab");
            entity.Property(e => e.CodContrato)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cod_contrato");
            entity.Property(e => e.CorreoTrab)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("correo_trab");
            entity.Property(e => e.DirTrab)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dir_trab");
            entity.Property(e => e.NomTrab)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom_trab");
            entity.Property(e => e.SalarioTrab).HasColumnName("salario_trab");
            entity.Property(e => e.TelTrab)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tel_trab");

            entity.HasOne(d => d.CodContratoNavigation).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.CodContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_trabajador_contrato");
        });

        modelBuilder.Entity<TrabajadorPredio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("trabajador_predio");

            entity.Property(e => e.CedulaTrab)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cedula_trab");
            entity.Property(e => e.DocumentoRepre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("documento_repre");
            entity.Property(e => e.NomPredio)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nom_predio");
            entity.Property(e => e.NomTrab)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom_trab");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

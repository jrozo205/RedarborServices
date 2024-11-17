using System;
using System.Collections.Generic;
using Employee.Write.Domain.Redarbor.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Write.Infraestructure.Redarbor.Configuration;

public partial class DbEmployeeContext : DbContext
{
    public DbEmployeeContext()
    {
    }

    public DbEmployeeContext(DbContextOptions<DbEmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyEntity> Companies { get; set; }

    public virtual DbSet<EmployeeEntity> Employees { get; set; }

    public virtual DbSet<PortalEntity> Portals { get; set; }

    public virtual DbSet<RoleEntity> Roles { get; set; }

    public virtual DbSet<StatusEntity> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M2QAA4I;Database=RedarborDB;Trusted_Connection=True; User id=dbUserTest; password=admin123; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<CompanyEntity>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<EmployeeEntity>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeletedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Lastlogin).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(300);

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Company");

            entity.HasOne(d => d.Portal).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PortalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Portal");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");

            entity.HasOne(d => d.Status).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Status");
        });

        modelBuilder.Entity<PortalEntity>(entity =>
        {
            entity.ToTable("Portal");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<RoleEntity>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<StatusEntity>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

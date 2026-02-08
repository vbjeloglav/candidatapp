using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CandidatApp.DB;

public partial class CandidatappContext : DbContext
{
    public CandidatappContext()
    {
    }

    public CandidatappContext(DbContextOptions<CandidatappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionStatus> PositionStatuses { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.; database=candidatapp; trusted_connection=true; encrypt=true; trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.ToTable("Application");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppliedAt).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Source).HasMaxLength(50);

            entity.HasOne(d => d.ApplicationStatus).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Status");

            entity.HasOne(d => d.Candidate).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Candidate");

            entity.HasOne(d => d.Position).WithMany(p => p.Applications)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Position");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_applicationstatus");

            entity.ToTable("ApplicationStatus");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.ToTable("Candidate");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_department");

            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Interview");

            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Application).WithMany()
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interview_Application");

            entity.HasOne(d => d.Candidate).WithMany()
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interview_Candidate");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_position");

            entity.ToTable("Position");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Status).WithMany(p => p.Positions)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Position_Status");
        });

        modelBuilder.Entity<PositionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_positionstatus");

            entity.ToTable("PositionStatus");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.ToTable("Technology");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

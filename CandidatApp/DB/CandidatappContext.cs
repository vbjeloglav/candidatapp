using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CandidatApp.DB;

public partial class CandidatappContext : DbContext
{
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

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Application>(entity =>
		{
			entity.ToTable("Application");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.AppliedAt).HasColumnType("datetime");
			entity.Property(e => e.Note).HasMaxLength(500);
			entity.Property(e => e.Source).HasMaxLength(50);
		});

		modelBuilder.Entity<ApplicationStatus>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.ToTable("ApplicationStatus");
			entity.Property(e => e.Name).HasMaxLength(50);
		});

		modelBuilder.Entity<Candidate>(entity =>
		{
			entity.ToTable("Candidate");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.Email).HasMaxLength(100);
			entity.Property(e => e.Name).HasMaxLength(50);
			entity.Property(e => e.Phone).HasMaxLength(50);
			entity.Property(e => e.Surname).HasMaxLength(50);
		});

		modelBuilder.Entity<Department>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.ToTable("Department");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.Name).HasMaxLength(50);
		});

		modelBuilder.Entity<Interview>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.ToTable("Interview");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.Note).HasMaxLength(1000);
			entity.Property(e => e.StartTime).HasColumnType("datetime");
		});

		modelBuilder.Entity<Position>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.ToTable("Position");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.Description).HasMaxLength(2000);
			entity.Property(e => e.Name).HasMaxLength(100);
		});

		modelBuilder.Entity<PositionStatus>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.ToTable("PositionStatus");
			entity.Property(e => e.Name).HasMaxLength(50);
		});

		modelBuilder.Entity<Technology>(entity =>
		{
			entity.ToTable("Technology");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.Name).HasMaxLength(50);
		});
	}
}

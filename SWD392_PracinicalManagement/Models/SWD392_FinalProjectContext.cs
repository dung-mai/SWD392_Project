using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SWD392_PracinicalManagement.Models
{
    public partial class SWD392_FinalProjectContext : DbContext
    {
        public SWD392_FinalProjectContext()
        {
        }

        public SWD392_FinalProjectContext(DbContextOptions<SWD392_FinalProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<ExaminationForm> ExaminationForms { get; set; } = null!;
        public virtual DbSet<ExaminationResult> ExaminationResults { get; set; } = null!;
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public virtual DbSet<PracinicalCategory> PracinicalCategories { get; set; } = null!;
        public virtual DbSet<PracinicalService> PracinicalServices { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-QG4POQ2\\MINHTIEN; database =SWD392_FinalProject;uid=sa;pwd=123456;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("ddddd");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(100)
                    .HasColumnName("departmentName");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Doctor");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.ExpertiseDetail)
                    .HasColumnType("text")
                    .HasColumnName("expertiseDetail");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hireDate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Account");
            });

            modelBuilder.Entity<ExaminationForm>(entity =>
            {
                entity.ToTable("ExaminationForm");

                entity.Property(e => e.MeetingDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.HasOne(d => d.DoctorCodeNavigation)
                    .WithMany(p => p.ExaminationForms)
                    .HasForeignKey(d => d.DoctorCode)
                    .HasConstraintName("FK_ExaminationForm_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ExaminationForms)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_ExaminationForm_Account");
            });

            modelBuilder.Entity<ExaminationResult>(entity =>
            {
                entity.HasKey(e => e.ResultId);

                entity.ToTable("ExaminationResult");

                entity.Property(e => e.ResultId).HasColumnName("resultId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.MedicalRecord).HasColumnName("medicalRecord");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ExaminationResults)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExaminationResult_Doctor");

                entity.HasOne(d => d.MedicalRecordNavigation)
                    .WithMany(p => p.ExaminationResults)
                    .HasForeignKey(d => d.MedicalRecord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExaminationResult_MedicalRecord");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ExaminationResults)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExaminationResult_PracinicalService");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecord");

                entity.Property(e => e.MedicalRecordId).HasColumnName("medicalRecordId");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_MedicalRecord_Account");
            });

            modelBuilder.Entity<PracinicalCategory>(entity =>
            {
                entity.ToTable("PracinicalCategory");

                entity.Property(e => e.PracinicalCategoryId).HasColumnName("pracinicalCategoryId");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.Desctiption)
                    .HasMaxLength(200)
                    .HasColumnName("desctiption");

                entity.Property(e => e.PracinicalCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("pracinicalCategoryName");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PracinicalCategories)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_PracinicalCategory_Account");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PracinicalCategories)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ddddddddddddddddddddd");
            });

            modelBuilder.Entity<PracinicalService>(entity =>
            {
                entity.ToTable("PracinicalService");

                entity.Property(e => e.PracinicalServiceId).HasColumnName("pracinicalServiceId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceDescription)
                    .HasColumnType("text")
                    .HasColumnName("serviceDescription");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(100)
                    .HasColumnName("serviceName");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PracinicalServices)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PracinicalService_PracinicalCategory");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("roleName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eltezam_Coded.DomainModels
{
    public partial class CodedContext : DbContext
    {
        public CodedContext()
        {
        }

        public CodedContext(DbContextOptions<CodedContext> options) : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Code> Codes { get; set; } = null!;
        public virtual DbSet<CodeCategory> CodeCategories { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeAppraisalInfo> EmployeeAppraisalInfos { get; set; } = null!;
        public virtual DbSet<EmployeeJob> EmployeeJobs { get; set; } = null!;
        public virtual DbSet<EmployeePayment> EmployeePayments { get; set; } = null!;
        public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; } = null!;
        public virtual DbSet<EmployeeVacation> EmployeeVacations { get; set; } = null!;
        public virtual DbSet<Enum> Enums { get; set; } = null!;
        public virtual DbSet<EnumsCategory> EnumsCategories { get; set; } = null!;
        public virtual DbSet<Governorate> Governorates { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<SubCity> SubCities { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Coded;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.GovernorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Governorates");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => e.Code1);

                entity.Property(e => e.Code1)
                    .HasMaxLength(25)
                    .HasColumnName("Code");

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Codes_CodeCategory");
            });

            modelBuilder.Entity<CodeCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CodeCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ActualJobNameDescription).HasMaxLength(2000);

                entity.Property(e => e.ActualOrganizationId)
                    .HasMaxLength(30)
                    .HasColumnName("ActualOrganizationID");

                entity.Property(e => e.ActualOrganizationName).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(254);

                entity.Property(e => e.EmployeeStatusCode).HasMaxLength(8);

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(7);

                entity.Property(e => e.EmploymentTypeDescription).HasMaxLength(100);

                entity.Property(e => e.FirstGradeDate).HasColumnType("datetime");

                entity.Property(e => e.FirstNameAr).HasMaxLength(50);

                entity.Property(e => e.FirstNameEn).HasMaxLength(50);

                entity.Property(e => e.GovernmentHireDate).HasColumnType("datetime");

                entity.Property(e => e.JobCatChain).HasMaxLength(9);

                entity.Property(e => e.JobClassDescription).HasMaxLength(100);

                entity.Property(e => e.JobNameDescription).HasMaxLength(100);

                entity.Property(e => e.JobOrganizationId)
                    .HasMaxLength(30)
                    .HasColumnName("JobOrganizationID");

                entity.Property(e => e.JobOrganizationName).HasMaxLength(100);

                entity.Property(e => e.LastNameAr).HasMaxLength(50);

                entity.Property(e => e.LastNameEn).HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.MinistryHireDate).HasColumnType("datetime");

                entity.Property(e => e.Mobile).HasMaxLength(14);

                entity.Property(e => e.NationalityCode).HasMaxLength(3);

                entity.Property(e => e.NextPromotionDate).HasColumnType("datetime");

                entity.Property(e => e.RankCode).HasMaxLength(6);

                entity.Property(e => e.SecondNameAr).HasMaxLength(50);

                entity.Property(e => e.SecondNameEn).HasMaxLength(50);

                entity.Property(e => e.StepDate).HasColumnType("datetime");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.TerminationReasonCode).HasMaxLength(7);

                entity.Property(e => e.ThirdNameAr).HasMaxLength(50);

                entity.Property(e => e.ThirdNameEn).HasMaxLength(50);

                entity.HasOne(d => d.BloodTypeNavigation)
                    .WithMany(p => p.EmployeeBloodTypeNavigations)
                    .HasForeignKey(d => d.BloodType)
                    .HasConstraintName("FK_Employees_Enums2");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.EmployeeGenderNavigations)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Enums");

                entity.HasOne(d => d.HealthstatusNavigation)
                    .WithMany(p => p.EmployeeHealthstatusNavigations)
                    .HasForeignKey(d => d.Healthstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Enums4");

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.EmployeeMaritalStatusNavigations)
                    .HasForeignKey(d => d.MaritalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Enums3");

                entity.HasOne(d => d.ReligionNavigation)
                    .WithMany(p => p.EmployeeReligionNavigations)
                    .HasForeignKey(d => d.Religion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Enums1");
            });

            modelBuilder.Entity<EmployeeAppraisalInfo>(entity =>
            {
                entity.HasKey(e => e.AppraisalId);

                entity.ToTable("EmployeeAppraisalInfo");

                entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");

                entity.Property(e => e.AppraisalTypeCode).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.RatingCode).HasMaxLength(50);

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAppraisalInfos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeAppraisalInfo_Employees");
            });

            modelBuilder.Entity<EmployeeJob>(entity =>
            {
                entity.Property(e => e.DecisionDate).HasColumnType("datetime");

                entity.Property(e => e.DescriptionType).HasColumnType("text");

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(25);

                entity.Property(e => e.EmploymentTypeDescription).HasColumnType("text");

                entity.Property(e => e.GradeDate).HasColumnType("datetime");

                entity.Property(e => e.IqamaNumber).HasMaxLength(10);

                entity.Property(e => e.JobCatChain).HasMaxLength(9);

                entity.Property(e => e.JobClassCode).HasMaxLength(5);

                entity.Property(e => e.JobClassDescription).HasColumnType("text");

                entity.Property(e => e.JobNameCode).HasMaxLength(25);

                entity.Property(e => e.JobNameDescription).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate).HasColumnType("date");

                entity.Property(e => e.LocationCode).HasMaxLength(50);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.RankCode).HasMaxLength(25);

                entity.Property(e => e.StepDate).HasColumnType("datetime");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.Property(e => e.TransactionCode).HasMaxLength(50);

                entity.Property(e => e.TransactionDescription).HasColumnType("text");

                entity.Property(e => e.TransactionEndDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeJobs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeJob_Employees");

                entity.HasOne(d => d.EmploymentTypeCodeNavigation)
                    .WithMany(p => p.EmployeeJobEmploymentTypeCodeNavigations)
                    .HasForeignKey(d => d.EmploymentTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeJob_Codes1");

                entity.HasOne(d => d.JobNameCodeNavigation)
                    .WithMany(p => p.EmployeeJobJobNameCodeNavigations)
                    .HasForeignKey(d => d.JobNameCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeJob_Codes");

                entity.HasOne(d => d.RankCodeNavigation)
                    .WithMany(p => p.EmployeeJobRankCodeNavigations)
                    .HasForeignKey(d => d.RankCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeJob_Codes2");
            });

            modelBuilder.Entity<EmployeePayment>(entity =>
            {
                entity.HasKey(e => e.EmployeePayId);

                entity.Property(e => e.ConsolidationSetDescription).HasColumnType("text");

                entity.Property(e => e.ConsolidationSetId).HasColumnName("ConsolidationSetID");

                entity.Property(e => e.ElementClassification).HasMaxLength(50);

                entity.Property(e => e.EmployeeName).HasMaxLength(200);

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(25);

                entity.Property(e => e.IqamaNumber).HasMaxLength(10);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.PaidDate).HasMaxLength(10);

                entity.Property(e => e.RankCode).HasMaxLength(25);

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.HasOne(d => d.ConsolidationSet)
                    .WithMany(p => p.EmployeePaymentConsolidationSets)
                    .HasForeignKey(d => d.ConsolidationSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Enums");

                entity.HasOne(d => d.ElementCodeNavigation)
                    .WithMany(p => p.EmployeePaymentElementCodeNavigations)
                    .HasForeignKey(d => d.ElementCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Enums1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePayments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Employees");

                entity.HasOne(d => d.EmploymentTypeCodeNavigation)
                    .WithMany(p => p.EmployeePaymentEmploymentTypeCodeNavigations)
                    .HasForeignKey(d => d.EmploymentTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Codes");

                entity.HasOne(d => d.RankCodeNavigation)
                    .WithMany(p => p.EmployeePaymentRankCodeNavigations)
                    .HasForeignKey(d => d.RankCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Codes1");
            });

            modelBuilder.Entity<EmployeeQualification>(entity =>
            {
                entity.HasKey(e => e.QualificationId);

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.CityName).HasMaxLength(100);

                entity.Property(e => e.CountryCode).HasMaxLength(50);

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.GraduationDate).HasColumnType("datetime");

                entity.Property(e => e.QualificationStatus).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Employees");

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithMany(p => p.EmployeeQualificationMajorCodeNavigations)
                    .HasForeignKey(d => d.MajorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Enums1");

                entity.HasOne(d => d.QualificationCodeNavigation)
                    .WithMany(p => p.EmployeeQualificationQualificationCodeNavigations)
                    .HasForeignKey(d => d.QualificationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Enums");

                entity.HasOne(d => d.UniversityCodeNavigation)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.UniversityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Universities");
            });

            modelBuilder.Entity<EmployeeVacation>(entity =>
            {
                entity.HasKey(e => e.VacationId);

                entity.Property(e => e.DecisionDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType).HasMaxLength(10);

                entity.HasOne(d => d.Empoyee)
                    .WithMany(p => p.EmployeeVacations)
                    .HasForeignKey(d => d.EmpoyeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeVacations_Employees");

                entity.HasOne(d => d.VacationCodeNavigation)
                    .WithMany(p => p.EmployeeVacations)
                    .HasForeignKey(d => d.VacationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeVacations_Enums");
            });

            modelBuilder.Entity<Enum>(entity =>
            {
                entity.Property(e => e.EnumValue).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Enums)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enums_EnumsCategory");
            });

            modelBuilder.Entity<EnumsCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("EnumsCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.Property(e => e.GovernorateName).HasMaxLength(200);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(e => e.NationalityCode).HasMaxLength(3);

                entity.Property(e => e.NationalityDescription).HasMaxLength(100);
            });

            modelBuilder.Entity<SubCity>(entity =>
            {
                entity.Property(e => e.SubCityName).HasMaxLength(200);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SubCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCities_Cities");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.UniversityName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class CodedContext : DbContext
    {
        public CodedContext()
        {
        }

        public CodedContext(DbContextOptions<CodedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Code> Codes { get; set; } = null!;
        public virtual DbSet<CodeCategory> CodeCategories { get; set; } = null!;
        public virtual DbSet<CodesTemp> CodesTemps { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeAppraisalInfo> EmployeeAppraisalInfos { get; set; } = null!;
        public virtual DbSet<EmployeeHistoricalInfo> EmployeeHistoricalInfos { get; set; } = null!;
        public virtual DbSet<EmployeeJob> EmployeeJobs { get; set; } = null!;
        public virtual DbSet<EmployeePayment> EmployeePayments { get; set; } = null!;
        public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; } = null!;
        public virtual DbSet<EmployeeVacation> EmployeeVacations { get; set; } = null!;
        public virtual DbSet<Enum> Enums { get; set; } = null!;
        public virtual DbSet<EnumsCategory> EnumsCategories { get; set; } = null!;
        public virtual DbSet<Governorate> Governorates { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<LocationCode> LocationCodes { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<RequestIdentity> RequestIdentities { get; set; } = null!;
        public virtual DbSet<ServiceEntity> ServiceEntities { get; set; } = null!;
        public virtual DbSet<ServiceResponse> ServiceResponses { get; set; } = null!;
        public virtual DbSet<SubCity> SubCities { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=INTALIO-NOHAESS\\MSSQLSERVER03;Initial Catalog=Rafha;Trusted_Connection=False; MultipleActiveResultSets=true;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.GovernorateId, "IX_Cities_GovernorateId");

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.GovernorateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Governorates");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Code1 });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code1)
                    .HasMaxLength(25)
                    .HasColumnName("Code");

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Codes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Codes__CategoryI__6E01572D");
            });

            modelBuilder.Entity<CodeCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CodeCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<CodesTemp>(entity =>
            {
                entity.ToTable("CodesTemp");

                entity.Property(e => e.Code).HasMaxLength(25);

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CodesTemps)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CodesTemp__Categ__10566F31");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ActualJobNameDescription).HasMaxLength(2000);

                entity.Property(e => e.ActualOrganizationId)
                    .HasMaxLength(30)
                    .HasColumnName("ActualOrganizationID");

                entity.Property(e => e.ActualOrganizationName).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasMaxLength(12);

                entity.Property(e => e.BloodTypeCode).HasMaxLength(25);

                entity.Property(e => e.EmailAddress).HasMaxLength(254);

                entity.Property(e => e.EmployeeStatusCode).HasMaxLength(8);

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(7);

                entity.Property(e => e.EmploymentTypeDescription).HasMaxLength(100);

                entity.Property(e => e.FirstGradeDate).HasMaxLength(12);

                entity.Property(e => e.FirstNameAr).HasMaxLength(50);

                entity.Property(e => e.FirstNameEn).HasMaxLength(50);

                entity.Property(e => e.GenderCode).HasMaxLength(25);

                entity.Property(e => e.GovernmentHireDate).HasMaxLength(12);

                entity.Property(e => e.HealthstatusCode).HasMaxLength(25);

                entity.Property(e => e.JobCatChain).HasMaxLength(9);

                entity.Property(e => e.JobClassDescription).HasMaxLength(100);

                entity.Property(e => e.JobNameDescription).HasMaxLength(100);

                entity.Property(e => e.JobOrganizationId)
                    .HasMaxLength(30)
                    .HasColumnName("JobOrganizationID");

                entity.Property(e => e.JobOrganizationName).HasMaxLength(100);

                entity.Property(e => e.LastNameAr).HasMaxLength(50);

                entity.Property(e => e.LastNameEn).HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate).HasMaxLength(12);

                entity.Property(e => e.LocationCode).HasMaxLength(500);

                entity.Property(e => e.MaritalStatusCode).HasMaxLength(25);

                entity.Property(e => e.MinistryHireDate).HasMaxLength(12);

                entity.Property(e => e.Mobile).HasMaxLength(14);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.NationalityCode).HasMaxLength(3);

                entity.Property(e => e.NextPromotionDate).HasMaxLength(12);

                entity.Property(e => e.RankCode).HasMaxLength(6);

                entity.Property(e => e.ReligionCode).HasMaxLength(25);

                entity.Property(e => e.SecondNameAr).HasMaxLength(50);

                entity.Property(e => e.SecondNameEn).HasMaxLength(50);

                entity.Property(e => e.ServiceResponseNumber).HasMaxLength(255);

                entity.Property(e => e.StepDate).HasMaxLength(12);

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.SubAgencyId)
                    .HasColumnName("SubAgencyID")
                    .HasDefaultValueSql("((2122))");

                entity.Property(e => e.TerminationDate).HasMaxLength(12);

                entity.Property(e => e.TerminationReasonCode).HasMaxLength(7);

                entity.Property(e => e.ThirdNameAr).HasMaxLength(50);

                entity.Property(e => e.ThirdNameEn).HasMaxLength(50);

                entity.Property(e => e.TransactionCode).HasMaxLength(50);

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RequestIdentityId);

                entity.HasOne(d => d.BloodTypeNavigation)
                    .WithMany(p => p.EmployeeBloodTypeNavigations)
                    .HasForeignKey(d => new { d.BloodType, d.BloodTypeCode })
                    .HasConstraintName("FK_Employees_Codes2");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.EmployeeGenderNavigations)
                    .HasForeignKey(d => new { d.Gender, d.GenderCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Codes");

                entity.HasOne(d => d.HealthstatusNavigation)
                    .WithMany(p => p.EmployeeHealthstatusNavigations)
                    .HasForeignKey(d => new { d.Healthstatus, d.HealthstatusCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Codes4");

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.EmployeeMaritalStatusNavigations)
                    .HasForeignKey(d => new { d.MaritalStatus, d.MaritalStatusCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Codes3");

                entity.HasOne(d => d.ReligionNavigation)
                    .WithMany(p => p.EmployeeReligionNavigations)
                    .HasForeignKey(d => new { d.Religion, d.ReligionCode })
                    .HasConstraintName("FK_Employees_Codes1");
            });

            modelBuilder.Entity<EmployeeAppraisalInfo>(entity =>
            {
                entity.HasKey(e => e.AppraisalId);

                entity.ToTable("EmployeeAppraisalInfo");

                entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");

                entity.Property(e => e.AppraisalTypeCode).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasMaxLength(12);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.RatingCode).HasMaxLength(50);

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasMaxLength(12);

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAppraisalInfos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeAppraisalInfo_Employees");

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.EmployeeAppraisalInfos)
                    .HasForeignKey(d => d.RequestIdentityId);
            });

            modelBuilder.Entity<EmployeeHistoricalInfo>(entity =>
            {
                entity.ToTable("EmployeeHistoricalInfo");

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(25);

                entity.Property(e => e.JobClassCode).HasMaxLength(25);

                entity.Property(e => e.JobNameCode).HasMaxLength(25);

                entity.Property(e => e.LastUpdateDate).HasMaxLength(12);

                entity.Property(e => e.LocationCode).HasMaxLength(50);

                entity.Property(e => e.NationalId).HasMaxLength(10);

                entity.Property(e => e.RankCode).HasMaxLength(25);

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.TransactionCode).HasMaxLength(50);

                entity.Property(e => e.TransactionStartDate).HasMaxLength(12);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeHistoricalInfos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeH__Emplo__10216507");

                entity.HasOne(d => d.EmploymentTypeCodeNavigation)
                    .WithMany(p => p.EmployeeHistoricalInfoEmploymentTypeCodeNavigations)
                    .HasForeignKey(d => new { d.EmploymentTypeCodeId, d.EmploymentTypeCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeHistoric__12FDD1B2");

                entity.HasOne(d => d.JobClassCodeNavigation)
                    .WithMany(p => p.EmployeeHistoricalInfoJobClassCodeNavigations)
                    .HasForeignKey(d => new { d.JobClassCodeId, d.JobClassCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeHistoric__11158940");

                entity.HasOne(d => d.JobNameCodeNavigation)
                    .WithMany(p => p.EmployeeHistoricalInfoJobNameCodeNavigations)
                    .HasForeignKey(d => new { d.JobNameCodeId, d.JobNameCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeHistoric__1209AD79");

                entity.HasOne(d => d.RankCodeNavigation)
                    .WithMany(p => p.EmployeeHistoricalInfoRankCodeNavigations)
                    .HasForeignKey(d => new { d.RankCodeId, d.RankCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeHistoric__13F1F5EB");
            });

            modelBuilder.Entity<EmployeeJob>(entity =>
            {
                entity.Property(e => e.DecisionDate).HasMaxLength(12);

                entity.Property(e => e.DescriptionType).HasColumnType("text");

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(25);

                entity.Property(e => e.EmploymentTypeDescription).HasColumnType("text");

                entity.Property(e => e.GradeDate).HasMaxLength(12);

                entity.Property(e => e.IqamaNumber).HasMaxLength(10);

                entity.Property(e => e.JobCatChain).HasMaxLength(9);

                entity.Property(e => e.JobClassCode).HasMaxLength(25);

                entity.Property(e => e.JobClassDescription).HasColumnType("text");

                entity.Property(e => e.JobNameCode).HasMaxLength(25);

                entity.Property(e => e.JobNameDescription).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate).HasMaxLength(12);

                entity.Property(e => e.LocationCode).HasMaxLength(50);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.RankCode).HasMaxLength(25);

                entity.Property(e => e.StepDate).HasMaxLength(12);

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.Property(e => e.TransactionCode).HasMaxLength(50);

                entity.Property(e => e.TransactionDescription).HasColumnType("text");

                entity.Property(e => e.TransactionEndDate).HasMaxLength(12);

                entity.Property(e => e.TransactionStartDate).HasMaxLength(12);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeJobs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeJob_Employees");

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.EmployeeJobs)
                    .HasForeignKey(d => d.RequestIdentityId);

                entity.HasOne(d => d.EmploymentTypeCodeNavigation)
                    .WithMany(p => p.EmployeeJobEmploymentTypeCodeNavigations)
                    .HasForeignKey(d => new { d.EmploymentTypeCodeId, d.EmploymentTypeCode })
                    .HasConstraintName("FK__EmployeeJobs__70A8B9AE");

                entity.HasOne(d => d.RankCodeNavigation)
                    .WithMany(p => p.EmployeeJobRankCodeNavigations)
                    .HasForeignKey(d => new { d.RankCodeId, d.RankCode })
                    .HasConstraintName("FK__EmployeeJobs__719CDDE7");
            });

            modelBuilder.Entity<EmployeePayment>(entity =>
            {
                entity.HasKey(e => e.EmployeePayId);

                entity.Property(e => e.ConsolidationSetCode).HasMaxLength(25);

                entity.Property(e => e.ConsolidationSetDescription).HasColumnType("text");

                entity.Property(e => e.ConsolidationSetId).HasColumnName("ConsolidationSetID");

                entity.Property(e => e.ElementClassification).HasMaxLength(50);

                entity.Property(e => e.ElementCode).HasMaxLength(25);

                entity.Property(e => e.EmployeeName).HasMaxLength(200);

                entity.Property(e => e.EmploymentTypeCode).HasMaxLength(25);

                entity.Property(e => e.IqamaNumber).HasMaxLength(10);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.PaidDate).HasMaxLength(12);

                entity.Property(e => e.RankCode).HasMaxLength(25);

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePayments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Employees");

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.EmployeePayments)
                    .HasForeignKey(d => d.RequestIdentityId);

                entity.HasOne(d => d.ConsolidationSet)
                    .WithMany(p => p.EmployeePaymentConsolidationSets)
                    .HasForeignKey(d => new { d.ConsolidationSetId, d.ConsolidationSetCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Codes");

                entity.HasOne(d => d.ElementCodeNavigation)
                    .WithMany(p => p.EmployeePaymentElementCodeNavigations)
                    .HasForeignKey(d => new { d.ElementCodeId, d.ElementCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePayments_Codes1");

                entity.HasOne(d => d.EmploymentTypeCodeNavigation)
                    .WithMany(p => p.EmployeePaymentEmploymentTypeCodeNavigations)
                    .HasForeignKey(d => new { d.EmploymentTypeCodeId, d.EmploymentTypeCode })
                    .HasConstraintName("FK__EmployeePayments__690797E6");

                entity.HasOne(d => d.RankCodeNavigation)
                    .WithMany(p => p.EmployeePaymentRankCodeNavigations)
                    .HasForeignKey(d => new { d.RankCodeId, d.RankCode })
                    .HasConstraintName("FK__EmployeePayments__69FBBC1F");
            });

            modelBuilder.Entity<EmployeeQualification>(entity =>
            {
                entity.HasKey(e => e.QualificationId);

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.CityName).HasMaxLength(100);

                entity.Property(e => e.CountryCode).HasMaxLength(50);

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.GraduationDate).HasMaxLength(12);

                entity.Property(e => e.MajorCode).HasMaxLength(25);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(15)
                    .HasColumnName("NationalID");

                entity.Property(e => e.QualificationCode).HasMaxLength(25);

                entity.Property(e => e.QualificationStatus).HasMaxLength(50);

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Employees");

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.RequestIdentityId);

                entity.HasOne(d => d.UniversityCodeNavigation)
                    .WithMany(p => p.EmployeeQualifications)
                    .HasForeignKey(d => d.UniversityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Universities");

                entity.HasOne(d => d.MajorCodeNavigation)
                    .WithMany(p => p.EmployeeQualificationMajorCodeNavigations)
                    .HasForeignKey(d => new { d.MajorCodeId, d.MajorCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Codes1");

                entity.HasOne(d => d.QualificationCodeNavigation)
                    .WithMany(p => p.EmployeeQualificationQualificationCodeNavigations)
                    .HasForeignKey(d => new { d.QualificationCodeId, d.QualificationCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeQualifications_Codes");
            });

            modelBuilder.Entity<EmployeeVacation>(entity =>
            {
                entity.HasKey(e => e.VacationId);

                entity.Property(e => e.DecisionDate).HasMaxLength(12);

                entity.Property(e => e.EndDate).HasMaxLength(12);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.StartDate).HasMaxLength(12);

                entity.Property(e => e.SubAgencyId).HasColumnName("SubAgencyID");

                entity.Property(e => e.TransactionType).HasMaxLength(10);

                entity.Property(e => e.VacationCode).HasMaxLength(25);

                entity.HasOne(d => d.Empoyee)
                    .WithMany(p => p.EmployeeVacations)
                    .HasForeignKey(d => d.EmpoyeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeVacations_Employees");

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.EmployeeVacations)
                    .HasForeignKey(d => d.RequestIdentityId);

                entity.HasOne(d => d.VacationCodeNavigation)
                    .WithMany(p => p.EmployeeVacations)
                    .HasForeignKey(d => new { d.VacationCodeId, d.VacationCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeVacations_Codes");
            });

            modelBuilder.Entity<Enum>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Enums_CategoryId");

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

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.EndDate).HasMaxLength(12);

                entity.Property(e => e.JobCatChain).HasMaxLength(50);

                entity.Property(e => e.JobNameDescription).HasMaxLength(100);

                entity.Property(e => e.JobPositionCode).HasMaxLength(25);

                entity.Property(e => e.LastUpdateDate).HasMaxLength(12);

                entity.Property(e => e.NationalId).HasMaxLength(10);

                entity.Property(e => e.PositionOrganizationId).HasColumnName("PositionOrganizationID");

                entity.Property(e => e.PositionOrganizationName).HasMaxLength(100);

                entity.Property(e => e.PositionStatus).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasMaxLength(12);

                entity.Property(e => e.VacantDate).HasMaxLength(12);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.RequestIdentity)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.RequestIdentityId);
            });

            modelBuilder.Entity<LocationCode>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.GovernorateCode).HasMaxLength(255);

                entity.Property(e => e.GovernorateName).HasMaxLength(255);

                entity.Property(e => e.LocationName).HasMaxLength(255);

                entity.Property(e => e.RegionCode).HasMaxLength(255);

                entity.Property(e => e.RegionName).HasMaxLength(255);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(e => e.NationalityCode).HasMaxLength(5);

                entity.Property(e => e.NationalityDescription).HasMaxLength(1000);
            });

            modelBuilder.Entity<RequestIdentity>(entity =>
            {
                entity.HasKey(e => e.RequestNumber);

                entity.Property(e => e.Table)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<ServiceEntity>(entity =>
            {
                entity.ToTable("ServiceEntity");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<ServiceResponse>(entity =>
            {
                entity.ToTable("ServiceResponse");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ResponseNumber).HasMaxLength(255);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Appraisal)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.AppraisalId)
                    .HasConstraintName("FK__ServiceRe__Appra__4959E263");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__ServiceRe__Emplo__4865BE2A");

                entity.HasOne(d => d.EmployeeJob)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.EmployeeJobId)
                    .HasConstraintName("FK__ServiceRe__Emplo__4B422AD5");

                entity.HasOne(d => d.EmployeePay)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.EmployeePayId)
                    .HasConstraintName("FK__ServiceRe__Emplo__4C364F0E");

                entity.HasOne(d => d.Historical)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.HistoricalId)
                    .HasConstraintName("FK__ServiceRe__Histo__4A4E069C");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK__ServiceRe__Quali__4D2A7347");

                entity.HasOne(d => d.ServiceEntityNavigation)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.ServiceEntity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceRe__Servi__477199F1");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.ServiceResponses)
                    .HasForeignKey(d => d.VacationId)
                    .HasConstraintName("FK__ServiceRe__Vacat__4E1E9780");
            });

            modelBuilder.Entity<SubCity>(entity =>
            {
                entity.HasIndex(e => e.CityId, "IX_SubCities_CityId");

                entity.Property(e => e.SubCityName).HasMaxLength(200);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SubCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCities_Cities");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.UniversityName).HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

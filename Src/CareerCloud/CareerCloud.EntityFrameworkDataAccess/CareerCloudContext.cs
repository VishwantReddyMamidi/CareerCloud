using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            string _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;

            optionsBuilder.UseSqlServer(_connStr);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEducationPoco>
                (entity =>
                {
                    entity.HasOne(ap => ap.ApplicantProfile)
                    .WithMany(ae => ae.ApplicantEducations)
                    .HasForeignKey(fk => fk.Applicant);
                });
            modelBuilder.Entity<ApplicantJobApplicationPoco>
                (entity =>
                {
                    entity.HasOne(ap => ap.ApplicantProfile)
                    .WithMany(aja => aja.ApplicantJobApplications)
                    .HasForeignKey(fk => fk.Applicant);
                });
            modelBuilder.Entity<ApplicantJobApplicationPoco>
                (entity =>
                {
                    entity.HasOne(cj => cj.CompanyJob)
                    .WithMany(aja => aja.ApplicantJobApplications)
                    .HasForeignKey(fk => fk.Job);
                });
            modelBuilder.Entity<ApplicantProfilePoco>
                (entity =>
                {
                    entity.HasOne(sl => sl.SecurityLogin)
                    .WithMany(ap => ap.ApplicantProfiles)
                    .HasForeignKey(fk => fk.Login);
                });
            modelBuilder.Entity<ApplicantProfilePoco>
                (entity =>
                {
                    entity.HasOne(scc => scc.SystemCountryCode)
                    .WithMany(ap => ap.ApplicantProfiles)
                    .HasForeignKey(fk => fk.Country);
                });
            modelBuilder.Entity<ApplicantResumePoco>
                (entity =>
                {
                    entity.HasOne(ap => ap.ApplicantProfile)
                    .WithMany(ar => ar.ApplicantResumes)
                    .HasForeignKey(fk => fk.Applicant);
                });
             modelBuilder.Entity<ApplicantSkillPoco>
                (entity =>
                {
                    entity.HasOne(ap => ap.ApplicantProfile)
                    .WithMany(ask => ask.ApplicantSkills)
                    .HasForeignKey(fk => fk.Applicant);
                });
            modelBuilder.Entity<ApplicantWorkHistoryPoco>
                   (entity =>
                   {
                       entity.HasOne(ap => ap.ApplicantProfile)
                       .WithMany(awe => awe.applicantWorkHistories)
                       .HasForeignKey(fk => fk.Applicant);
                   });
            modelBuilder.Entity<ApplicantWorkHistoryPoco>
                   (entity =>
                   {
                       entity.HasOne(scc => scc.SystemCountryCode)
                       .WithMany(awe => awe.applicantWorkHistories)
                       .HasForeignKey(fk => fk.CountryCode);
                   });

            modelBuilder.Entity<CompanyDescriptionPoco>
                   (entity =>
                   {
                       entity.HasOne(cp => cp.CompanyProfile)
                       .WithMany(cd=>cd.companyDescriptions)
                       .HasForeignKey(fk => fk.Company);
                   });
            modelBuilder.Entity<CompanyDescriptionPoco>
                    (entity =>
                    {
                        entity.HasOne(slc=>slc.SystemLanguageCode)
                        .WithMany(cd => cd.companyDescriptions)
                        .HasForeignKey(fk => fk.LanguageId);
                    });

            modelBuilder.Entity<CompanyJobEducationPoco>
                     (entity =>
                     {
                         entity.HasOne(cj=>cj.CompanyJob)
                         .WithMany(cje => cje.CompanyJobEducations)
                         .HasForeignKey(fk => fk.Job);
                     });
            modelBuilder.Entity<CompanyJobSkillPoco>
                     (entity =>
                     {
                         entity.HasOne(cj => cj.CompanyJob)
                         .WithMany(cjs => cjs.companyJobSkills)
                         .HasForeignKey(fk => fk.Job);
                     });
            modelBuilder.Entity<CompanyJobPoco>
                     (entity =>
                     {
                         entity.HasOne(cp => cp.CompanyProfile)
                         .WithMany(cj => cj.companyJobs)
                         .HasForeignKey(fk => fk.Company);
                     });
            modelBuilder.Entity<CompanyJobDescriptionPoco>
                     (entity =>
                     {
                         entity.HasOne(cj => cj.CompanyJob)
                         .WithMany(cjd => cjd.CompanyJobDescriptions)
                         .HasForeignKey(fk => fk.Job);
                     });
            modelBuilder.Entity<CompanyLocationPoco>
                     (entity =>
                     {
                         entity.HasOne(cp => cp.CompanyProfile)
                         .WithMany(cl => cl.CompanyLocations)
                         .HasForeignKey(fk => fk.Company);
                     });
            modelBuilder.Entity<SecurityLoginsLogPoco>
                     (entity =>
                     {
                         entity.HasOne(sl => sl.SecurityLogin)
                         .WithMany(sll => sll.SecurityLoginsLogs)
                         .HasForeignKey(fk => fk.Login);
                     });
            modelBuilder.Entity<SecurityLoginsRolePoco>
                     (entity =>
                     {
                         entity.HasOne(sl=>sl.SecurityLogin)
                         .WithMany(slr=>slr.SecurityLoginsRoles)
                         .HasForeignKey(fk => fk.Login);
                     });
            modelBuilder.Entity<SecurityLoginsRolePoco>
                     (entity =>
                     {
                         entity.HasOne(sr=>sr.SecurityRole)
                         .WithMany(slr => slr.SecurityLoginsRoles)
                         .HasForeignKey(fk => fk.Role);
                     });





            base.OnModelCreating(modelBuilder);
        }

    }
}

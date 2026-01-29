using Microsoft.EntityFrameworkCore;
using ResourceryHR.Recruitment.Exercises;
using ResourceryHR.Recruitment.JobPostings;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ResourceryHR.Recruitment.EntityFrameworkCore;

public static class RecruitmentDbContextModelCreatingExtensions
{
    public static void ConfigureRecruitment(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        // Exercise entity configuration
        builder.Entity<Exercise>(b =>
        {
            b.ToTable(RecruitmentDbProperties.DbTablePrefix + "Exercises", RecruitmentDbProperties.DbSchema);
            
            b.ConfigureByConvention();
            
            // Properties
            b.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(ExerciseConsts.MaxTitleLength);
            
            b.Property(e => e.Description)
                .HasMaxLength(ExerciseConsts.MaxDescriptionLength);
            
            b.Property(e => e.ReferenceNumber)
                .HasMaxLength(ExerciseConsts.MaxReferenceNumberLength);
            
            b.Property(e => e.StartDate)
                .IsRequired();
            
            b.Property(e => e.EndDate)
                .IsRequired();
            
            b.Property(e => e.IsActive)
                .IsRequired();
            
            // Indexes
            b.HasIndex(e => e.StartDate);
            b.HasIndex(e => e.EndDate);
            b.HasIndex(e => e.IsActive);
            b.HasIndex(e => e.ReferenceNumber);
        });

        // JobPosting entity configuration
        builder.Entity<JobPosting>(b =>
        {
            b.ToTable(RecruitmentDbProperties.DbTablePrefix + "JobPostings", RecruitmentDbProperties.DbSchema);
            
            b.ConfigureByConvention();
            
            // Properties
            b.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(JobPostingConsts.MaxTitleLength);
            
            b.Property(j => j.Description)
                .HasMaxLength(JobPostingConsts.MaxDescriptionLength);
            
            b.Property(j => j.Requirements)
                .HasMaxLength(JobPostingConsts.MaxRequirementsLength);
            
            b.Property(j => j.Responsibilities)
                .HasMaxLength(JobPostingConsts.MaxResponsibilitiesLength);
            
            b.Property(j => j.Department)
                .IsRequired()
                .HasMaxLength(JobPostingConsts.MaxDepartmentLength);
            
            b.Property(j => j.Location)
                .IsRequired()
                .HasMaxLength(JobPostingConsts.MaxLocationLength);
            
            b.Property(j => j.EmploymentType)
                .HasMaxLength(JobPostingConsts.MaxEmploymentTypeLength);
            
            b.Property(j => j.SalaryRange)
                .HasMaxLength(JobPostingConsts.MaxSalaryRangeLength);
            
            b.Property(j => j.ReferenceNumber)
                .HasMaxLength(JobPostingConsts.MaxReferenceNumberLength);
            
            b.Property(j => j.NumberOfPositions)
                .IsRequired();
            
            b.Property(j => j.IsPublished)
                .IsRequired();
            
            // Foreign Key
            b.Property(j => j.ExerciseId)
                .IsRequired();
            
            // Indexes
            b.HasIndex(j => j.ExerciseId);
            b.HasIndex(j => j.IsPublished);
            b.HasIndex(j => j.ApplicationDeadline);
            b.HasIndex(j => j.ReferenceNumber);
            b.HasIndex(j => new { j.ExerciseId, j.IsPublished });
        });
    }
}

using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ResourceryHR.Recruitment.JobPostings;

/// <summary>
/// Represents a job posting attached to a recruitment exercise
/// </summary>
public class JobPosting : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; protected set; }

    /// <summary>
    /// Reference to the Exercise this job belongs to
    /// </summary>
    public Guid ExerciseId { get; protected set; }
    /// <summary>
    /// Job Code
    /// </summary>
    public string JobCode { get; protected set; }

    /// <summary>
    /// Job title
    /// </summary>
    public string Title { get; protected set; }

    /// <summary>
    /// Job description
    /// </summary>
    public string Description { get; protected set; }

    /// <summary>
    /// Job requirements
    /// </summary>
    public string Requirements { get; protected set; }

    /// <summary>
    /// Job responsibilities
    /// </summary>
    public string Responsibilities { get; protected set; }

    /// <summary>
    /// Department or division
    /// </summary>
    public string Department { get; protected set; }

    /// <summary>
    /// Job location
    /// </summary>
    public string Location { get; protected set; }

    /// <summary>
    /// Employment type (Full-time, Part-time, Contract, etc.)
    /// </summary>
    public string EmploymentType { get; protected set; }

    /// <summary>
    /// Salary range (optional)
    /// </summary>
    public string SalaryRange { get; protected set; }

    /// <summary>
    /// Number of positions available
    /// </summary>
    public int NumberOfPositions { get; protected set; }

    /// <summary>
    /// Application deadline
    /// </summary>
    public DateTime? ApplicationDeadline { get; protected set; }

    /// <summary>
    /// Indicates whether the job posting is published and visible to candidates
    /// </summary>
    public bool IsPublished { get; protected set; }

    /// <summary>
    /// Job reference number or code
    /// </summary>
    public string ReferenceNumber { get; protected set; }

    // Private constructor for EF Core
    protected JobPosting()
    {
    }

    /// <summary>
    /// Constructor for creating a new JobPosting
    /// </summary>
    public JobPosting(
        Guid id,
        Guid exerciseId,
        string jobCode,
        string title,
        string description,
        string department,
        string location,
        int numberOfPositions = 1,
        string referenceNumber = null,
        Guid? tenantId = null) : base(id)
    {
        ExerciseId = exerciseId;
        SetTitle(title);
        SetDescription(description);
        Department = Check.NotNullOrWhiteSpace(department, nameof(department), JobPostingConsts.MaxDepartmentLength);
        Location = Check.NotNullOrWhiteSpace(location, nameof(location), JobPostingConsts.MaxLocationLength);
        SetNumberOfPositions(numberOfPositions);
        ReferenceNumber = referenceNumber;
        IsPublished = false;
        TenantId = tenantId;
    }

    /// <summary>
    /// Sets the job title
    /// </summary>
    public JobPosting SetTitle(string title)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title), JobPostingConsts.MaxTitleLength);
        return this;
    }

    /// <summary>
    /// Sets the job description
    /// </summary>
    public JobPosting SetDescription(string description)
    {
        Description = Check.Length(description, nameof(description), JobPostingConsts.MaxDescriptionLength);
        return this;
    }

    /// <summary>
    /// Sets the requirements
    /// </summary>
    public JobPosting SetRequirements(string requirements)
    {
        Requirements = Check.Length(requirements, nameof(requirements), JobPostingConsts.MaxRequirementsLength);
        return this;
    }

    /// <summary>
    /// Sets the responsibilities
    /// </summary>
    public JobPosting SetResponsibilities(string responsibilities)
    {
        Responsibilities = Check.Length(responsibilities, nameof(responsibilities), JobPostingConsts.MaxResponsibilitiesLength);
        return this;
    }

    /// <summary>
    /// Sets the employment type
    /// </summary>
    public JobPosting SetEmploymentType(string employmentType)
    {
        EmploymentType = Check.Length(employmentType, nameof(employmentType), JobPostingConsts.MaxEmploymentTypeLength);
        return this;
    }

    /// <summary>
    /// Sets the salary range
    /// </summary>
    public JobPosting SetSalaryRange(string salaryRange)
    {
        SalaryRange = Check.Length(salaryRange, nameof(salaryRange), JobPostingConsts.MaxSalaryRangeLength);
        return this;
    }

    /// <summary>
    /// Sets the number of positions
    /// </summary>
    public JobPosting SetNumberOfPositions(int numberOfPositions)
    {
        if (numberOfPositions < 1)
        {
            throw new ArgumentException("Number of positions must be at least 1");
        }

        NumberOfPositions = numberOfPositions;
        return this;
    }

    /// <summary>
    /// Sets the application deadline
    /// </summary>
    public JobPosting SetApplicationDeadline(DateTime? deadline)
    {
        ApplicationDeadline = deadline;
        return this;
    }

    /// <summary>
    /// Publishes the job posting
    /// </summary>
    public void Publish()
    {
        IsPublished = true;
    }

    /// <summary>
    /// Unpublishes the job posting
    /// </summary>
    public void Unpublish()
    {
        IsPublished = false;
    }

    /// <summary>
    /// Checks if applications are still being accepted
    /// </summary>
    public bool IsAcceptingApplications()
    {
        if (!IsPublished)
            return false;

        if (!ApplicationDeadline.HasValue)
            return true;

        return DateTime.UtcNow <= ApplicationDeadline.Value;
    }
}

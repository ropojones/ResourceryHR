using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ResourceryHR.Recruitment.Exercises;

/// <summary>
/// Represents a recruitment exercise/campaign.
/// An exercise is a recruitment activity with a defined start and end date.
/// Jobs are attached to exercises.
/// </summary>
public class Exercise : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; protected set; }

    /// <summary>
    /// The title/name of the recruitment exercise
    /// </summary>
    public string Title { get; protected set; }

    /// <summary>
    /// Reference to the organization that owns this exercise
    /// </summary>
    public Guid OrganizationId { get; protected set; }


    /// <summary>
    /// Description of the recruitment exercise
    /// </summary>
    public string Description { get; protected set; }

    /// <summary>
    /// The start date of the recruitment exercise
    /// </summary>
    public DateTime StartDate { get; protected set; }

    /// <summary>
    /// The end date of the recruitment exercise
    /// </summary>
    public DateTime EndDate { get; protected set; }

    /// <summary>
    /// Indicates whether the exercise is currently active
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Reference number or code for the exercise
    /// </summary>
    public string ReferenceNumber { get; protected set; }

    // Private constructor for EF Core
    protected Exercise()
    {
    }

    /// <summary>
    /// Constructor for creating a new Exercise
    /// </summary>
    public Exercise(
        Guid id,
        Guid organizationId,
        string title,
        string description,
        DateTime startDate,
        DateTime endDate,
        string referenceNumber = null,
        bool isActive = true,
        Guid? tenantId = null) : base(id)
    {
        SetOrganization(organizationId);
        SetTitle(title);
        SetDescription(description);
        SetDates(startDate, endDate);
        ReferenceNumber = referenceNumber;
        IsActive = isActive;
        TenantId = tenantId;
    }

    /// <summary>
    /// Sets the organization for the exercise
    /// </summary>
    public Exercise SetOrganization(Guid organizationId)
    {
        if (organizationId == Guid.Empty)
        {
            throw new ArgumentException("OrganizationId cannot be empty", nameof(organizationId));
        }

        OrganizationId = organizationId;
        return this;
    }

    /// <summary>
    /// Sets the title of the exercise
    /// </summary>
    public Exercise SetTitle(string title)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title), ExerciseConsts.MaxTitleLength);
        return this;
    }

    /// <summary>
    /// Sets the description of the exercise
    /// </summary>
    public Exercise SetDescription(string description)
    {
        Description = Check.Length(description, nameof(description), ExerciseConsts.MaxDescriptionLength);
        return this;
    }

    /// <summary>
    /// Sets the start and end dates with validation
    /// </summary>
    public Exercise SetDates(DateTime startDate, DateTime endDate)
    {
        if (endDate <= startDate)
        {
            throw new ArgumentException("End date must be after start date");
        }

        StartDate = startDate;
        EndDate = endDate;
        return this;
    }

    /// <summary>
    /// Activates the exercise
    /// </summary>
    public void Activate()
    {
        IsActive = true;
    }

    /// <summary>
    /// Deactivates the exercise
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Checks if the exercise is currently running (within date range)
    /// </summary>
    public bool IsRunning()
    {
        var now = DateTime.UtcNow;
        return IsActive && now >= StartDate && now <= EndDate;
    }
}

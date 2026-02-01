using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ResourceryHR.Recruitment.Organizations;

/// <summary>
/// Represents an organization that owns recruitment exercises.
/// </summary>
public class Organization : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; protected set; }

    /// <summary>
    /// Organization name
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Optional description
    /// </summary>
    public string Description { get; protected set; }

    // Private constructor for EF Core
    protected Organization()
    {
    }

    /// <summary>
    /// Constructor for creating a new Organization
    /// </summary>
    public Organization(Guid id, string name, string description = null, Guid? tenantId = null)
        : base(id)
    {
        SetName(name);
        SetDescription(description);
        TenantId = tenantId;
    }

    /// <summary>
    /// Sets the organization name
    /// </summary>
    public Organization SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), OrganizationConsts.MaxNameLength);
        return this;
    }

    /// <summary>
    /// Sets the organization description
    /// </summary>
    public Organization SetDescription(string description)
    {
        Description = Check.Length(description, nameof(description), OrganizationConsts.MaxDescriptionLength);
        return this;
    }
}

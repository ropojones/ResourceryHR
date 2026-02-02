using System.ComponentModel.DataAnnotations;


namespace ResourceryHR.Recruitment.Organizations;

public class CreateUpdateOrganizationDto
{
    [Required]
    [StringLength(256)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace PorchGrants.Data.Models;

public class Organisation
{
    public int OrganisationId { get; set; }
    public string Name { get; set; } = default!;
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? Postcode { get; set; }
    public string? Website { get; set; }
    public string ContactName { get; set; } = default!;
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactMobile { get; set; }
    public string? Notes { get; set; }
    public bool Archived { get; set; }

    [Timestamp]
    public uint Version { get; set; }

    public ICollection<Application> Applications { get; } = new List<Application>();
}

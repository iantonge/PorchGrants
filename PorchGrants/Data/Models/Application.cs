using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorchGrants.Data.Models;

public class Application
{
    public int ApplicationId { get; set; }
    public int OrganisationId { get; set; }
    public bool HasCriteria { get; set; }
    public DateOnly? ApplyByDate { get; set; }
    public DateOnly? AppliedDate { get; set; }
    [Column(TypeName = "money")] public decimal? AmountRequested { get; set; }
    public DateOnly? FollowUpDate { get; set; }
    public ApplicationOutcome? Outcome { get; set; }
    public DateOnly? OutcomeDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdated { get; set; }

    [Timestamp]
    public uint Version { get; set; }

    public Organisation Organisation { get; set; } = default!;
    public ICollection<Grant> Grants { get; } = new List<Grant>();
}

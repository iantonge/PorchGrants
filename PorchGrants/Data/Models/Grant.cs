using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorchGrants.Data.Models;

public class Grant
{
    public int GrantId { get; set; }
    public int ApplicationId { get; set; }
    [Column(TypeName = "money")] public decimal AmountAwarded { get; set; }
    public int NumberOfInstallments { get; set; }
    public bool ReportToDonorRequired { get; set; }
    public DateOnly ReportPrepDate { get; set; }
    public DateOnly ReportSentDate { get; set; }
    public string? Notes { get; set; }
    public bool FullyReveived { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    [Timestamp] public uint Version { get; set; }

    public Application Application { get; set; } = default!;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

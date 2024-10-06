using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorchGrants.Data.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public int GrantId { get; set; }
    [Column(TypeName = "money")] public decimal ExpectedAmount { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly RecievedDate { get; set; }
    [Column(TypeName = "money")] public decimal ReceivedAmount { get; set; }
    [Timestamp] public uint Version { get; set; }


    public Grant Grant { get; set; } = default!;
}

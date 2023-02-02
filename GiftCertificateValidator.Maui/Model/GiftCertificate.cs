#nullable enable
using SQLite;

namespace GiftCertificateValidator.Maui.Model;

public class GiftCertificate
{
    [AutoIncrement, PrimaryKey]
    public int? Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? Discount { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUsed { get; set; }
    public bool? IsUsed { get; set; }
}
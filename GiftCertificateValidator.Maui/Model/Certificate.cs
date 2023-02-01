namespace GiftCertificateValidator.Maui.Model;

public class Certificate
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public string Discount { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public bool Status { get; set; }
}
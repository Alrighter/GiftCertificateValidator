namespace GiftCertificateValidator.Maui.Model;

public class BaseResponse <T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
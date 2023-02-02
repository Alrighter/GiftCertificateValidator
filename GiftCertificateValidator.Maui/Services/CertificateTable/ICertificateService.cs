﻿using GiftCertificateValidator.Maui.Model;

namespace GiftCertificateValidator.Maui.Services.CertificateTable;

public interface ICertificateService
{
    Task<GiftCertificate> GetCertificateAsync(string certificateCode);
    Task<IEnumerable<GiftCertificate>> GetCertificatesAsync();
    Task<bool> AddCertificateAsync(GiftCertificate certificate);
    Task<bool> UpdateCertificateAsync(GiftCertificate certificate);
    Task<bool> ChangeCertificateStatusAsync(string certificateCode);
}
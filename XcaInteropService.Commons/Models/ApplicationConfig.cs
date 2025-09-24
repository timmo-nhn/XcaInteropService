
public class ApplicationConfig
{
    public int TimeoutInSeconds { get; set; }
    public bool WrapRetrievedDocumentInCda { get; set; }
    public bool MultipartResponseForIti43 { get; set; }
    public string? HomeCommunityId { get; set; }
    public string? RepositoryUniqueId { get; set; }
    public bool IgnorePEPForLocalhostRequests { get; set; }
    public int DocumentUploadSizeLimitKb { get; set; }
    public bool ValidateSamlTokenIntegrity { get; set; }
}

namespace XcaInteropService.Commons.Enums;

public enum DomainReturn
{
    /// <summary>
    /// Default, query domain and retrieve document list
    /// </summary>
    DocumentList,

    /// <summary>
    /// Return when the domain is available but shouldnt return anything
    /// </summary>
    EmptyDocumentList,

    /// <summary>
    /// Return when the domain is unable to be contacted due to technical difficulties on the domain end.
    /// </summary>
    RegistryError
}

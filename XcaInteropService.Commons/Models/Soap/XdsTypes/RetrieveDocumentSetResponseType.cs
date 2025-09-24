using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Soap.XdsTypes;

[Serializable]
[XmlType(Namespace = Constants.Xds.Namespaces.Xdsb)]
public partial class RetrieveDocumentSetResponseType
{
    [XmlElement(Namespace = Constants.Xds.Namespaces.Rs, Order = 0)]
    public RegistryResponseType RegistryResponse;

    [XmlElement("DocumentResponse", Order = 1)]
    public DocumentResponseType[] DocumentResponse;

    public void AddDocument(byte[] document, string home, string repoId, string docId, string? mimeType = null)
    {
        if (document == null || home == null || repoId == null || docId == null)
        {
            return;
        }

        var documentResponse = new DocumentResponseType()
        {
            DocumentUniqueId = docId,
            HomeCommunityId = home,
            RepositoryUniqueId = repoId,
            MimeType = mimeType
        };

        documentResponse.SetInlineDocument(document);

        DocumentResponse ??= [];
        DocumentResponse = [.. DocumentResponse, documentResponse];
    }
}

using System.ComponentModel;
using System.ServiceModel;
using System.Xml.Serialization;
using XcaInteropService.Commons.Commons;
using XcaInteropService.Commons.Models.Soap.XdsTypes;


namespace XcaInteropService.Commons.Models.Soap.Actions;

[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "urn:ihe:iti:xds-b:2007")]
[MessageContract(IsWrapped = false)]
public partial class RetrieveDocumentSetbRequest
{
    [XmlElement]
    [MessageBodyMember(Namespace = Constants.Xds.Namespaces.Xdsb, Order = 0)]
    public DocumentRequestType[] DocumentRequest;

    public RetrieveDocumentSetbRequest()
    {
    }

    public void AddDocumentRequest(DocumentRequestType documentRequest)
    {
        DocumentRequest = DocumentRequest.Append(
            new DocumentRequestType
            {
                HomeCommunityId = documentRequest.HomeCommunityId,
                DocumentUniqueId = documentRequest.DocumentUniqueId,
                RepositoryUniqueId = documentRequest.RepositoryUniqueId,
            }).ToArray();
    }

    public RetrieveDocumentSetbRequest(DocumentRequestType[] retrieveDocumentSetRequest)
    {
        DocumentRequest = retrieveDocumentSetRequest;
    }
}

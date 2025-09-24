using Nav.Service.TopicCopier.Types.AuditMessage;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XcaInteropService.Commons.Commons;

public class AuditMessage
{
    public string? eventId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Issuer? Issuer { get; set; }
    public string? PatientNin { get; set; }
    public DateTime DateTime { get; set; }
    public string Event { get; set; }
    public Actor Actor { get; set; }
    public Extra Extra { get; set; }
    public static AuditMessage Empty { get; }

    static AuditMessage() { Empty = new AuditMessage(); }

    public AuditMessage(string sessionId)
    {
        Actor = new Actor();
        Extra = new Extra() { };
        eventId = sessionId;
    }

    public AuditMessage()
    {
        Actor = new Actor();

        Extra = new Extra()
        {

            Resource = new List<Resource>()
        };
    }


    public bool ResourceSectionOk()
    {
        if (Event != null && Extra != null)
        {
            switch (Extra.XcaAction)
            {
                case XcaAction.InitiatingGatewayRetrieve:
                    var resource = Extra.Resource?.FirstOrDefault();
                    if (resource != null &&
                        resource.ResourceRetrieveId != null &&
                        resource.ResourceOwner != null &&
                        resource.ResourceOwnerDetails != null)
                    {
                        return Extra.ResourceSectionFinished = true;
                    }
                    break;

                case XcaAction.InitiatingGatewayQuery:

                    if (Extra.Resource != null && Extra.Resource.Count >= 0)
                    {
                        if (Extra.Resource.Any(res => res.ResourceRetrieveId != null && res.ConfidentialityCode != null))
                        {
                            return Extra.ResourceSectionFinished = true;
                        }
                    }
                    break;


                case XcaAction.Unknown:
                default:
                    break;
            }

        }
        return Extra.ResourceSectionFinished = false;
    }

    public bool SamlSectionOk()
    {
        if (Issuer != null && Actor != null && Actor.ActorType != null && Extra != null)
        {
            return Extra.SamlSectionFinished = true;
        }
        return Extra.SamlSectionFinished = false;
    }
    public bool OtherFieldsOk()
    {
        if (Extra.XcaAction != null && Extra.Resource != null && Extra.Resource.Count != 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Function to test if the auditmessage saml-section, http-section and timespan is OK. Underlying functions modify the "Extra" object to set OK-statuses to true.
    /// </summary>
    public bool TestIfFinished()
    {
        var samlsection = SamlSectionOk();
        var resourceSection = ResourceSectionOk();
        var otherFields = OtherFieldsOk();

        if (samlsection && resourceSection && otherFields)
            return Extra.IsFinished = true;

        return Extra.IsFinished = false;
    }

    /// <summary>
    /// Remove all the stuff in the Resource field so the message doesnt get too long when logging
    /// </summary>
    public AuditMessage ForDisplay()
    {
        if (this.Extra.Resource != null && this.Extra.Resource.Count != 0)
        {
            var displayableMessage = this.CopyMessage();
            displayableMessage.Extra.Resource = displayableMessage.Extra.Resource.Take(3).ToList();
            return displayableMessage;
        }
        return this;
    }

    public bool Equals(AuditMessage? obj)
    {
        var am1 = this.CopyMessage();
        var am2 = obj.CopyMessage();

        // remove values which invalidate the comparison
        am1.Extra.MessageHash = 0;
        am1.Extra.ProcessedCount = 0;
        am1.DateTime = DateTime.MinValue;
        am1.Extra.LastModified = DateTime.MinValue;

        am2.Extra.MessageHash = 0;
        am2.Extra.ProcessedCount = 0;
        am2.DateTime = DateTime.MinValue;
        am2.Extra.LastModified = DateTime.MinValue;

        var am1String = JsonSerializer.Serialize(am1);
        var am2String = JsonSerializer.Serialize(am2);
        return string.Equals(am1String, am2String);
    }

    /// <summary>
    /// Deep copy the entire Audit message
    /// </summary>
    /// <returns>A copy of the provided audit message</returns>
    public AuditMessage CopyMessage()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<AuditMessage>(json);
    }

    private void CalculateMessageHash()
    {
        // Create a modifiable copy of the current audit message
        var auditMessageCopy = CopyMessage();

        // Reset values to avoid infinite hash recursion loop stuff?!? Probably sufficient?
        auditMessageCopy.Extra.MessageHash = 0;
        auditMessageCopy.DateTime = DateTime.MinValue.ToUniversalTime();
        auditMessageCopy.Extra.LastModified = DateTime.MinValue.ToUniversalTime();
        auditMessageCopy.Extra.ProcessedCount = 0;

        // Compute a stable hash
        string serializedMessage = JsonSerializer.Serialize(auditMessageCopy, new JsonSerializerOptions()
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        });
        using (var sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(serializedMessage));
            Extra.MessageHash = BitConverter.ToInt32(hashBytes, 0); // Use as 32-bit hash
        }
    }

    /// <summary>
    /// Update the last modified timestamp of the current message, UNIX style 😛
    /// </summary>
    public void Touch()
    {
        Extra.LastModified = DateTime.UtcNow;
        CalculateMessageHash();
    }

    public void MergeWith(AuditMessage auditMessage)
    {
        MergeIssuerIfNotNull(auditMessage);
        MergePatientNinIfNotNull(auditMessage);
        MergeActorIfNotNull(auditMessage);
        MergeResourceFieldsIfNotNull(auditMessage);
        MergeExtraFieldsIfNotNull(auditMessage);
        //MergeDocumentDetailsIfNotNull(auditMessage);

        TestIfFinished();
        // update this.Extra.LastModified
        Touch();
    }

    internal void MergeExtraFieldsIfNotNull(AuditMessage auditMessage)
    {
        Extra.XcaAction ??= auditMessage.Extra.XcaAction;
    }

    internal void MergeIssuerIfNotNull(AuditMessage auditMessage)
    {
        if (Issuer is null && auditMessage.Issuer is not null)
        {
            Issuer = auditMessage.Issuer;
        }
    }
    internal void MergePatientNinIfNotNull(AuditMessage auditMessage)
    {
        if (PatientNin is null && auditMessage.PatientNin is not null)
        {
            PatientNin = auditMessage.PatientNin;
        }
    }

    internal void MergeActorIfNotNull(AuditMessage auditMessage)
    {
        if (auditMessage.Actor is not null)
        {
            Actor ??= new(); // Lazy init
            if (Actor.ActorType is null && auditMessage.Actor.ActorType is not null)
            {
                Actor.ActorType = auditMessage.Actor.ActorType;
            }
            if (Actor.UserNin is null && auditMessage.Actor.ActorType is not null)
            {
                Actor.UserNin = auditMessage.Actor.UserNin;
            }
            if (Actor.HprNr is null && auditMessage.Actor.HprNr is not null)
            {
                Actor.HprNr = auditMessage.Actor.HprNr;
            }
            if (Actor.HprRole is null && auditMessage.Actor.HprRole is not null)
            {
                Actor.HprRole = auditMessage.Actor.HprRole;
            }
            if (Actor.LegalEntityId is null && auditMessage.Actor.LegalEntityId is not null)
            {
                Actor.LegalEntityId = auditMessage.Actor.LegalEntityId;
            }
            if (Actor.PointOfCareId is null && auditMessage.Actor.PointOfCareId is not null)
            {
                Actor.PointOfCareId = auditMessage.Actor.PointOfCareId;
            }
            if (Actor.PurposeOfUse is null && auditMessage.Actor.PurposeOfUse is not null)
            {
                Actor.PurposeOfUse = auditMessage.Actor.PurposeOfUse;
            }
            if (Actor.AccessBasis is null && auditMessage.Actor.AccessBasis is not null)
            {
                Actor.AccessBasis = auditMessage.Actor.AccessBasis;
            }
        }
    }

    internal void MergeResourceFieldsIfNotNull(AuditMessage auditMessage)
    {
        if (auditMessage?.Extra == null)
            throw new ArgumentNullException(nameof(auditMessage), "AuditMessage or its Extra property is null.");

        if (Extra.XcaAction == XcaAction.InitiatingGatewayRetrieve)
        {
            var targetResource = auditMessage.Extra.Resource?.FirstOrDefault();

            if (Extra.Resource == null || Extra.Resource.Count == 0)
            {
                Extra.Resource = new List<Resource> { new Resource() };
            }

            var sourceResource = Extra.Resource.FirstOrDefault() ?? new Resource();
            if (!Extra.Resource.Contains(sourceResource))
            {
                Extra.Resource.Add(sourceResource);
            }

            var targetSourceField = auditMessage.Extra.SourceField;
            if (sourceResource.ResourceRetrieveId == null && !string.IsNullOrEmpty(targetSourceField) &&
                targetSourceField.Split(";").Length == 3)
            {
                sourceResource.ResourceRetrieveId = targetSourceField;
            }

            if (!string.IsNullOrWhiteSpace(targetSourceField))
            {
                // If ONLY ResourceOwnerDetails is filled out, append ResourceOwner
                if (sourceResource.ResourceOwnerDetails != null &&
                    sourceResource.ResourceOwner == null)
                {
                    sourceResource.ResourceOwner = targetSourceField;
                    Event += $" fra {sourceResource.ResourceOwner.Trim()}";
                }
                if (sourceResource.ResourceOwner != null && sourceResource.ResourceOwner.Contains("oslo kommune", StringComparison.CurrentCultureIgnoreCase))
                {

                }

                // If both ResourceOwner and ResourceOwnerDetails are NOT filled out
                if (sourceResource.ResourceOwnerDetails == null && sourceResource.ResourceOwner == null)
                {
                    if (targetResource?.ResourceOwnerDetails != null && targetResource?.ResourceOwner != null)
                    {
                        sourceResource.ResourceOwner = targetResource.ResourceOwner;
                        sourceResource.ResourceOwnerDetails = targetResource.ResourceOwnerDetails;
                    }
                    else
                    {
                        sourceResource.ResourceOwnerDetails = targetSourceField;
                        Event = $"Tilgang til dine journaldokumenter fra {sourceResource.ResourceOwnerDetails.Trim()}";
                    }
                }

                // If both ResourceOwner and ResourceOwnerDetails are NOT filled out
                if (sourceResource.ResourceOwnerDetails == null && sourceResource.ResourceOwner == null)
                {
                    sourceResource.ResourceOwnerDetails = targetSourceField;
                    Event = $"Tilgang til dine journaldokumenter fra {sourceResource.ResourceOwnerDetails.Trim()}";
                }

                // If both ResourceOwner and ResourceOwnerDetails are already filled out
                if (sourceResource.ResourceOwnerDetails != null && sourceResource.ResourceOwner != null)
                {
                    Event = $"Tilgang til dine journaldokumenter fra {sourceResource.ResourceOwnerDetails.Trim()} fra {sourceResource.ResourceOwner.Trim()}";
                }
            }

            if (targetResource != null)
            {
                sourceResource.ResourceOwner ??= targetResource.ResourceOwner;
                sourceResource.ResourceOwnerDetails ??= targetResource.ResourceOwnerDetails;
                sourceResource.ResourceType ??= targetResource.ResourceType;
                sourceResource.ResourceTitle ??= targetResource.ResourceTitle;
                sourceResource.ResourceRetrieveId ??= targetResource.ResourceRetrieveId;
                sourceResource.ResourceDate ??= targetResource.ResourceDate;
            }
        }

        if (Extra.XcaAction == XcaAction.InitiatingGatewayQuery)
        {
            Event ??= "Tilgang til din dokumentliste";
            if (auditMessage.Extra?.Resource?.Any() == true)
            {
                Extra.Resource = auditMessage.Extra.Resource?
                    .Where(res => res?.ResourceRetrieveId != null)
                    .ToList();
            }
        }
    }
}

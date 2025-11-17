
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
public partial class Envelope
{

    private EnvelopeHeader headerField;

    private EnvelopeBody bodyField;

    /// <remarks/>
    public EnvelopeHeader Header
    {
        get
        {
            return this.headerField;
        }
        set
        {
            this.headerField = value;
        }
    }

    /// <remarks/>
    public EnvelopeBody Body
    {
        get
        {
            return this.bodyField;
        }
        set
        {
            this.bodyField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
public partial class EnvelopeHeader
{

    private Action actionField;

    private string messageIDField;

    private ReplyTo replyToField;

    private FaultTo faultToField;

    private string toField;

    private Security securityField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
    public Action Action
    {
        get
        {
            return this.actionField;
        }
        set
        {
            this.actionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
    public string MessageID
    {
        get
        {
            return this.messageIDField;
        }
        set
        {
            this.messageIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
    public ReplyTo ReplyTo
    {
        get
        {
            return this.replyToField;
        }
        set
        {
            this.replyToField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
    public FaultTo FaultTo
    {
        get
        {
            return this.faultToField;
        }
        set
        {
            this.faultToField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
    public string To
    {
        get
        {
            return this.toField;
        }
        set
        {
            this.toField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    public Security Security
    {
        get
        {
            return this.securityField;
        }
        set
        {
            this.securityField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/08/addressing")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
public partial class Action
{

    private bool mustUnderstandField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public bool mustUnderstand
    {
        get
        {
            return this.mustUnderstandField;
        }
        set
        {
            this.mustUnderstandField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/08/addressing")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
public partial class ReplyTo
{

    private string addressField;

    /// <remarks/>
    public string Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/08/addressing")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
public partial class FaultTo
{

    private string addressField;

    /// <remarks/>
    public string Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
    "")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
    "", IsNullable = false)]
public partial class Security
{

    private Timestamp timestampField;

    private object assertionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xs" +
        "d")]
    public Timestamp Timestamp
    {
        get
        {
            return this.timestampField;
        }
        set
        {
            this.timestampField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    public object Assertion
    {
        get
        {
            return this.assertionField;
        }
        set
        {
            this.assertionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xs" +
    "d")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xs" +
    "d", IsNullable = false)]
public partial class Timestamp
{

    private System.DateTime createdField;

    private System.DateTime expiresField;

    /// <remarks/>
    public System.DateTime Created
    {
        get
        {
            return this.createdField;
        }
        set
        {
            this.createdField = value;
        }
    }

    /// <remarks/>
    public System.DateTime Expires
    {
        get
        {
            return this.expiresField;
        }
        set
        {
            this.expiresField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
public partial class EnvelopeBody
{

    private PRPA_IN201301UV02 pRPA_IN201301UV02Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
    public PRPA_IN201301UV02 PRPA_IN201301UV02
    {
        get
        {
            return this.pRPA_IN201301UV02Field;
        }
        set
        {
            this.pRPA_IN201301UV02Field = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class PRPA_IN201301UV02
{

    private id idField;

    private creationTime creationTimeField;

    private interactionId interactionIdField;

    private processingCode processingCodeField;

    private processingModeCode processingModeCodeField;

    private acceptAckCode acceptAckCodeField;

    private receiver receiverField;

    private sender senderField;

    private controlActProcess controlActProcessField;

    private string iTSVersionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public id id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public creationTime creationTime
    {
        get
        {
            return this.creationTimeField;
        }
        set
        {
            this.creationTimeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public interactionId interactionId
    {
        get
        {
            return this.interactionIdField;
        }
        set
        {
            this.interactionIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public processingCode processingCode
    {
        get
        {
            return this.processingCodeField;
        }
        set
        {
            this.processingCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public processingModeCode processingModeCode
    {
        get
        {
            return this.processingModeCodeField;
        }
        set
        {
            this.processingModeCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public acceptAckCode acceptAckCode
    {
        get
        {
            return this.acceptAckCodeField;
        }
        set
        {
            this.acceptAckCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public receiver receiver
    {
        get
        {
            return this.receiverField;
        }
        set
        {
            this.receiverField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public sender sender
    {
        get
        {
            return this.senderField;
        }
        set
        {
            this.senderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:hl7-org:v3")]
    public controlActProcess controlActProcess
    {
        get
        {
            return this.controlActProcessField;
        }
        set
        {
            this.controlActProcessField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ITSVersion
    {
        get
        {
            return this.iTSVersionField;
        }
        set
        {
            this.iTSVersionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class id
{

    private string rootField;

    private string extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string extension
    {
        get
        {
            return this.extensionField;
        }
        set
        {
            this.extensionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class creationTime
{

    private ulong valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ulong value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class interactionId
{

    private string rootField;

    private string extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string extension
    {
        get
        {
            return this.extensionField;
        }
        set
        {
            this.extensionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class processingCode
{

    private string codeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class processingModeCode
{

    private string codeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class acceptAckCode
{

    private string codeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class receiver
{

    private receiverDevice deviceField;

    private string typeCodeField;

    /// <remarks/>
    public receiverDevice device
    {
        get
        {
            return this.deviceField;
        }
        set
        {
            this.deviceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class receiverDevice
{

    private receiverDeviceID idField;

    private object asAgentField;

    private string classCodeField;

    private string determinerCodeField;

    /// <remarks/>
    public receiverDeviceID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object asAgent
    {
        get
        {
            return this.asAgentField;
        }
        set
        {
            this.asAgentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string determinerCode
    {
        get
        {
            return this.determinerCodeField;
        }
        set
        {
            this.determinerCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class receiverDeviceID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class sender
{

    private senderDevice deviceField;

    private string typeCodeField;

    /// <remarks/>
    public senderDevice device
    {
        get
        {
            return this.deviceField;
        }
        set
        {
            this.deviceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class senderDevice
{

    private senderDeviceID idField;

    private object asAgentField;

    private string classCodeField;

    private string determinerCodeField;

    /// <remarks/>
    public senderDeviceID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object asAgent
    {
        get
        {
            return this.asAgentField;
        }
        set
        {
            this.asAgentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string determinerCode
    {
        get
        {
            return this.determinerCodeField;
        }
        set
        {
            this.determinerCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class senderDeviceID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:hl7-org:v3", IsNullable = false)]
public partial class controlActProcess
{

    private controlActProcessCode codeField;

    private controlActProcessSubject subjectField;

    private string classCodeField;

    private string moodCodeField;

    /// <remarks/>
    public controlActProcessCode code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubject subject
    {
        get
        {
            return this.subjectField;
        }
        set
        {
            this.subjectField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string moodCode
    {
        get
        {
            return this.moodCodeField;
        }
        set
        {
            this.moodCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessCode
{

    private string codeField;

    private string codeSystemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubject
{

    private controlActProcessSubjectRegistrationEvent registrationEventField;

    private string typeCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEvent registrationEvent
    {
        get
        {
            return this.registrationEventField;
        }
        set
        {
            this.registrationEventField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEvent
{

    private controlActProcessSubjectRegistrationEventStatusCode statusCodeField;

    private controlActProcessSubjectRegistrationEventSubject1 subject1Field;

    private object authorField;

    private controlActProcessSubjectRegistrationEventCustodian custodianField;

    private string classCodeField;

    private string moodCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventStatusCode statusCode
    {
        get
        {
            return this.statusCodeField;
        }
        set
        {
            this.statusCodeField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1 subject1
    {
        get
        {
            return this.subject1Field;
        }
        set
        {
            this.subject1Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object author
    {
        get
        {
            return this.authorField;
        }
        set
        {
            this.authorField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventCustodian custodian
    {
        get
        {
            return this.custodianField;
        }
        set
        {
            this.custodianField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string moodCode
    {
        get
        {
            return this.moodCodeField;
        }
        set
        {
            this.moodCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventStatusCode
{

    private string codeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1
{

    private controlActProcessSubjectRegistrationEventSubject1Patient patientField;

    private string typeCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1Patient patient
    {
        get
        {
            return this.patientField;
        }
        set
        {
            this.patientField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1Patient
{

    private controlActProcessSubjectRegistrationEventSubject1PatientID[] idField;

    private controlActProcessSubjectRegistrationEventSubject1PatientStatusCode statusCodeField;

    private controlActProcessSubjectRegistrationEventSubject1PatientPatientPerson patientPersonField;

    private controlActProcessSubjectRegistrationEventSubject1PatientProviderOrganization providerOrganizationField;

    private string classCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("id")]
    public controlActProcessSubjectRegistrationEventSubject1PatientID[] id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientStatusCode statusCode
    {
        get
        {
            return this.statusCodeField;
        }
        set
        {
            this.statusCodeField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientPatientPerson patientPerson
    {
        get
        {
            return this.patientPersonField;
        }
        set
        {
            this.patientPersonField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientProviderOrganization providerOrganization
    {
        get
        {
            return this.providerOrganizationField;
        }
        set
        {
            this.providerOrganizationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientID
{

    private string rootField;

    private string extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string extension
    {
        get
        {
            return this.extensionField;
        }
        set
        {
            this.extensionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientStatusCode
{

    private string codeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientPatientPerson
{

    private controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonName nameField;

    private controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonAdministrativeGenderCode administrativeGenderCodeField;

    private controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonBirthTime birthTimeField;

    private object birthPlaceField;

    private string classCodeField;

    private string determinerCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonName name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonAdministrativeGenderCode administrativeGenderCode
    {
        get
        {
            return this.administrativeGenderCodeField;
        }
        set
        {
            this.administrativeGenderCodeField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonBirthTime birthTime
    {
        get
        {
            return this.birthTimeField;
        }
        set
        {
            this.birthTimeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object birthPlace
    {
        get
        {
            return this.birthPlaceField;
        }
        set
        {
            this.birthPlaceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string determinerCode
    {
        get
        {
            return this.determinerCodeField;
        }
        set
        {
            this.determinerCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonName
{

    private string familyField;

    private string givenField;

    /// <remarks/>
    public string family
    {
        get
        {
            return this.familyField;
        }
        set
        {
            this.familyField = value;
        }
    }

    /// <remarks/>
    public string given
    {
        get
        {
            return this.givenField;
        }
        set
        {
            this.givenField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonAdministrativeGenderCode
{

    private string codeField;

    private string codeSystemField;

    private string displayNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string displayName
    {
        get
        {
            return this.displayNameField;
        }
        set
        {
            this.displayNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientPatientPersonBirthTime
{

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientProviderOrganization
{

    private controlActProcessSubjectRegistrationEventSubject1PatientProviderOrganizationID idField;

    private string nameField;

    private string classCodeField;

    private string determinerCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventSubject1PatientProviderOrganizationID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string determinerCode
    {
        get
        {
            return this.determinerCodeField;
        }
        set
        {
            this.determinerCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventSubject1PatientProviderOrganizationID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventCustodian
{

    private controlActProcessSubjectRegistrationEventCustodianAssignedEntity assignedEntityField;

    private string typeCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventCustodianAssignedEntity assignedEntity
    {
        get
        {
            return this.assignedEntityField;
        }
        set
        {
            this.assignedEntityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventCustodianAssignedEntity
{

    private controlActProcessSubjectRegistrationEventCustodianAssignedEntityID idField;

    private controlActProcessSubjectRegistrationEventCustodianAssignedEntityAssignedOrganization assignedOrganizationField;

    private object representedOrganizationField;

    private string classCodeField;

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventCustodianAssignedEntityID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public controlActProcessSubjectRegistrationEventCustodianAssignedEntityAssignedOrganization assignedOrganization
    {
        get
        {
            return this.assignedOrganizationField;
        }
        set
        {
            this.assignedOrganizationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object representedOrganization
    {
        get
        {
            return this.representedOrganizationField;
        }
        set
        {
            this.representedOrganizationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventCustodianAssignedEntityID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:hl7-org:v3")]
public partial class controlActProcessSubjectRegistrationEventCustodianAssignedEntityAssignedOrganization
{

    private string nameField;

    private string classCodeField;

    private string determinerCodeField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string determinerCode
    {
        get
        {
            return this.determinerCodeField;
        }
        set
        {
            this.determinerCodeField = value;
        }
    }
}


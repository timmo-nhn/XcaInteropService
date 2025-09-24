namespace XcaInteropService.Commons.Commons;

public enum XacmlVersion
{
    Version20,
    Version30
}

public enum StoredQuery
{
    FindDocuments,
    GetAll,
    GetDocuments,

    //Not supported by DIPS
    FindSubmissionSets,
    FindFolders,
    GetFolders,
    GetAssociations,
    GetDocumentsAndAssociations,
    GetSubmissionSets,
    GetSubmissionSetAndContents,
    GetFolderAndContents,
    GetFoldersForDocument,
    GetRelatedDocuments,
    FindDocumentsByReferenceId
}

//public enum DocumentType
//{
//    StableDocumentEntries,
//    OnDemandDocumentEntries
//}

//public enum AssociationType
//{
//    HasMember,
//    Replace,
//    Transformation,
//    Addendum,
//    ReplaceWithTransformation,
//    DigitalSignature,
//    SnapshotOfOnDemandDocumentEntry
//}

public enum ReturnType
{
    LeafClass,
    ObjectRef
}

public enum DocumentEntryQueryParameter
{
    PatientId,
    ClassCode,
    TypeCode,
    PracticeSettingCode,
    CreationTimeFrom,
    CreationTimeTo,
    ServiceStartTimeFrom,
    ServiceStartTimeTo,
    ServiceStopTimeFrom,
    ServiceStopTimeTo,
    HealthcareFacilityTypeCode,
    EventCodeList,
    ConfidentialityCode,
    AuthorPerson,
    FormatCode,
    Status,
    Type,
    UniqueId
}

public enum StatusValue
{
    Submitted,
    Approved,
    Deprecated
}

public enum SubmissionQueryParameter
{
    Status
}

public enum FolderQueryParameter
{
    Status
}

public enum GeneralQueryParameter
{
    PatientId
}

public enum PatientIdType
{
    Fodselsnummer,
    DNummer
}

/// <summary>
///     Based on HL7 Patient Identification Segment
///     http://www.hl7.eu/refactored/segPID.html
/// </summary>
public enum PidType
{
    /// <summary>
    /// Valuetype: string
    /// </summary>
    SetId = 1,

    /// <summary>
    /// Valuetype: Cx
    /// </summary>
    PatientIdentifierList = 3,

    /// <summary>
    /// Valuetype: Xpn
    /// </summary>
    PatientName = 5,

    /// <summary>
    /// Valuetype: Xpn
    /// </summary>
    MothersMaidenName = 6,

    /// <summary>
    /// Valuetype: DTM formatted string (yyyyMMddHHmmss)
    /// </summary>
    DateTimeofBirth = 7,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    AdministrativeSex = 8,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    Race = 10,

    /// <summary>
    /// Valuetype: Xad
    /// </summary>
    PatientAddress = 11,

    /// <summary>
    /// Valuetype: Xtn
    /// </summary>
    HomePhoneNumber = 13,

    /// <summary>
    /// Valuetype: Xtn
    /// </summary>
    BusinessPhoneNumber = 14,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    PrimaryLanguage = 15,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    MaritalStatus = 16,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    Religion = 17,

    /// <summary>
    /// Valuetype: Cx
    /// </summary>
    PatientAccountNumber = 18,

    /// <summary>
    /// Valuetype: Cx
    /// </summary>
    MothersIdentifier = 21,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    EthnicGroup = 22,

    /// <summary>
    /// Valuetype: string
    /// </summary>
    BirthPlace = 23,

    /// <summary>
    /// Valuetype: string
    /// </summary>
    MultipleBirthIndicator = 24,

    /// <summary>
    /// Valuetype: string
    /// </summary>
    BirthOrder = 25,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    Citizenship = 26,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    VeteransMilitaryStatus = 27,

    /// <summary>
    /// Valuetype: DTM formatted string (yyyyMMddHHmmss)
    /// </summary>
    PatientDeathDateandTime = 29,

    /// <summary>
    /// Valuetype: string
    /// </summary>
    PatientDeathIndicator = 30,

    /// <summary>
    /// Valuetype: string
    /// </summary>
    IdentityUnknownIndicator = 31,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    IdentityReliabilityCode = 32,

    /// <summary>
    /// Valuetype: DTM formatted string (yyyyMMddHHmmss)
    /// </summary>
    LastUpdateDateTime = 33,

    /// <summary>
    /// Valuetype: Hd
    /// </summary>
    LastUpdateFacility = 34,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    TaxonomicClassificationCode = 35,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    BreedCode = 36,

    /// <summary>
    /// Valuetype: string
    /// </summary>
    Strain = 37,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    ProductionClassCode = 38,

    /// <summary>
    /// Valuetype: Cwe
    /// </summary>
    TribalCitizenship = 39,

    /// <summary>
    /// Valuetype: Xtn
    /// </summary>
    PatientTelecommunicationInformation = 40
}

public enum ResponseStatusType
{
    Success,
    PartialSuccess,
    Failure
}

public enum ErrorSeverityType
{
    Warning,
    Error
}

public enum XdsErrorCodes
{
    /// <summary>
    /// A recipient queued the submission, for example, a manual process matching it to a patient.
    /// </summary>
    DocumentQueued,

    /// <summary>
    /// the recipient has rejected this submission because it detected that one of the documents does not match the metadata (e.g., formatcode) or has failed other requirements for the document content.
    /// when the registryerror element contains this error code, the codecontext shall contain the uniqueid of the document in error.
    /// if multiple documents are in error, there shall be a separate registryerror element for each document in error.
    /// </summary>
    InvalidDocumentContent,

    /// <summary>
    /// An XDR Document Recipient did not process some part of the content. Specifically, the parts not processed are Append semantics.
    /// </summary>
    PartialAppendContentNotProcessed,

    /// <summary>
    /// An XDR Document Recipient did not process some part of the content. Specifically, the parts not processed are Folder semantics.
    /// </summary>
    PartialFolderContentNotProcessed,

    /// <summary>
    /// An XDR Document Recipient did not process some part of the content. Specifically, the parts not processed are Relationship Association semantics.
    /// </summary>
    PartialRelationshipContentNotProcessed,

    /// <summary>
    /// An XDR Document Recipient did not process some part of the content. Specifically, the parts not processed are Replacement semantics.
    /// </summary>
    PartialReplaceContentNotProcessed,

    /// <summary>
    /// An XDR Document Recipient did not process some part of the content. Specifically, the parts not processed are Transform semantics.
    /// </summary>
    PartialTransformNotProcessed,

    /// <summary>
    /// An XDR Document Recipient did not process some part of the content. Specifically, the parts not processed are Transform and Replace semantics.
    /// </summary>
    PartialTransformReplaceNotProcessed,

    /// <summary>
    /// The recipient cannot resolve an entryUUID reference in the transaction.
    /// </summary>
    UnresolvedReferenceException,

    /// <summary>
    /// The document associated with the uniqueId is not available. This could be because the document is not available, the requestor is not authorized to access that document or the document is no longer available.
    /// </summary>
    XDSDocumentUniqueIdError,

    /// <summary>
    /// UniqueId received was not unique. UniqueId could have been attached to SubmissionSet or Folder.
    /// codeContext shall indicate which and the value of the non-unique uniqueId. This error cannot be thrown for DocumentEntry.
    /// </summary>
    XDSDuplicateUniqueIdInRegistry,

    /// <summary>
    /// This warning is returned if extra metadata was present but not saved.
    /// </summary>
    XDSExtraMetadataNotSaved,

    /// <summary>
    /// DocumentEntry exists in metadata with no matching Document element.
    /// </summary>
    XDSMissingDocument,

    /// <summary>
    /// Document element present with no matching DocumentEntry.
    /// </summary>
    XDSMissingDocumentMetadata,

    /// <summary>
    /// A value for the homeCommunityId is required and has not been specified.
    /// </summary>
    XDSMissingHomeCommunityId,

    /// <summary>
    /// Document being registered was a duplicate (uniqueId already in Document Registry) but hash does not match. The codeContext shall indicate uniqueId.
    /// </summary>
    XDSNonIdenticalHash,

    /// <summary>
    /// Document being registered was a duplicate (uniqueId already in Document Registry) but size does not match. The codeContext shall indicate uniqueId.
    /// </summary>
    XDSNonIdenticalSize,

    /// <summary>
    /// This error is thrown when the patient Id is required to match and does not. The codeContext shall indicate the value of the Patient Id and the nature of the conflict.
    /// </summary>
    XDSPatientIdDoesNotMatch,

    /// <summary>
    /// Too much activity.
    /// </summary>
    XDSRegistryBusy,
    XDSRepositoryBusy,

    /// <summary>
    /// The transaction was rejected because it submitted an Association referencing a deprecated document.
    /// </summary>
    XDSRegistryDeprecatedDocumentError,

    /// <summary>
    /// A uniqueId value was found to be used more than once within the submission. The errorCode indicates where the error was detected. The codeContext shall indicate the duplicate uniqueId.
    /// </summary>
    XDSRegistryDuplicateUniqueIdInMessage,
    XDSRepositoryDuplicateUniqueIdInMessage,

    /// <summary>
    /// Internal Error. 
    /// If one of these error codes is returned, the attribute codeContext shall contain details of the error condition that may be implementation-specific.
    /// </summary>
    XDSRegistryError,
    XDSRepositoryError,

    /// <summary>
    /// Error detected in metadata. Actor name indicates where error was detected. (Document Recipient uses Repository error). codeContext indicates nature of problem.
    /// </summary>
    XDSRegistryMetadataError,
    XDSRepositoryMetadataError,

    /// <summary>
    /// Repository was unable to access the Registry.
    /// </summary>
    XDSRegistryNotAvailable,

    /// <summary>
    /// System Resources are currently unavailable to respond to the request. The request may be retried later.
    /// </summary>
    XDSRegistryOutOfResources,
    XDSRepositoryOutOfResources,

    /// <summary>
    /// This error signals that a single request would have returned content for multiple Patient Ids.
    /// </summary>
    XDSResultNotSinglePatient,

    /// <summary>
    /// A required parameter to a stored query is missing.
    /// </summary>
    XDSStoredQueryMissingParam,

    /// <summary>
    /// A parameter which only accepts a single value is coded with multiple values.
    /// </summary>
    XDSStoredQueryParamNumber,

    /// <summary>
    /// The request cannot be satisfied due to being overly broad or having a response that is too large.
    /// The request should be adjusted, e.g., narrowed to reduce the number of results.
    /// </summary>
    XDSTooManyResults,

    /// <summary>
    /// A community which would have been contacted was not available.
    /// </summary>
    XDSUnavailableCommunity,

    /// <summary>
    /// A value for the homeCommunityId is not recognized.
    /// </summary>
    XDSUnknownCommunity,

    /// <summary>
    /// Patient Id referenced in the transaction is not known by the receiving actor. The codeContext shall include the value of patient Id in question.
    /// </summary>
    XDSUnknownPatientId,

    /// <summary>
    /// The repositoryUniqueId value could not be resolved to a valid document repository or the value does not match the repositoryUniqueId.
    /// </summary>
    XDSUnknownRepositoryId,

    /// <summary>
    /// The Query Id provided in the request is not recognized.
    /// </summary>
    XDSUnknownStoredQuery,

    /// <summary>
    /// An intendedRecipient which would have been contacted was not available.
    /// </summary>
    UnavailableRecipient,

    /// <summary>
    /// A value for intendedRecipient is not recognized.
    /// </summary>
    UnknownRecipient
}

public static class Hl7
{
    // Table 0076 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0076
    public enum MessageType
    {
        // General acknowledgment message
        ACK,

        // ADT response
        ADR,

        // ADT message
        ADT,

        // Add/change billing account
        BAR,

        // Blood product dispense status message
        BPS,

        // Blood product dispense status acknowledgement message
        BRP,

        // Blood product transfusion/disposition acknowledgement message
        BRT,

        // Blood product transfusion/disposition message
        BTS,

        // Clinical study registration message
        CRM,

        // Unsolicited study data message
        CSU,

        // Detail financial transactions
        DFT,

        // Document response
        DOC,

        // Display response
        DSR,

        // Automated equipment command message
        EAC,

        // Automated equipment notification message
        EAN,

        // Automated equipment response message
        EAR,

        // Enhanced display response
        EDR,

        // Embedded query language query
        EQQ,

        // Event replay response
        ERP,

        // Automated equipment status update acknowledgment message
        ESR,

        // Automated equipment status update message
        ESU,

        // Automated equipment inventory request message
        INR,

        // Automated equipment inventory update message
        INU,

        // Automated equipment log/service request message
        LSR,

        // Automated equipment log/service update message
        LSU,

        // Delayed Acknowledgment (Retained for backward compatibility only)
        MCF,

        // Medical document management
        MDM,

        // Master files delayed application acknowledgment
        MFD,

        // Master files application acknowledgment
        MFK,

        // Master files notification
        MFN,

        // Master files query
        MFQ,

        // Master files response
        MFR,

        // Application management data message
        NMD,

        // Application management query message
        NMQ,

        // Application management response message
        NMR,

        // Blood product order message
        OMB,

        // Dietary order
        OMD,

        // General clinical order message
        OMG,

        // Imaging order
        OMI,

        // Laboratory order message
        OML,

        // Non-stock requisition order message
        OMN,

        // Pharmacy/treatment order message
        OMP,

        // Stock requisition order message
        OMS,

        // Blood product order acknowledgement message
        ORB,

        // Dietary order acknowledgment message
        ORD,

        // Query for results of observation
        ORF,

        // General clinical order acknowledgment message
        ORG,

        // Imaging order acknowledgement message
        ORI,

        // Laboratory acknowledgment message (unsolicited)
        ORL,

        // Pharmacy/treatment order message
        ORM,

        // Non-stock requisition - General order acknowledgment message
        ORN,

        // Pharmacy/treatment order acknowledgment message
        ORP,

        // General order response message response to any ORM
        ORR,

        // Stock requisition - Order acknowledgment message
        ORS,

        // Unsolicited transmission of an observation message
        ORU,

        // Query response for order status
        OSQ,

        // Query response for order status
        OSR,

        // Unsolicited laboratory observation message
        OUL,

        // Product experience message
        PEX,

        // Patient goal message
        PGL,

        // Patient insurance information
        PIN,

        // Add personnel record
        PMU,

        // Patient pathway message (goal-oriented)
        PPG,

        // Patient pathway message (problem-oriented)
        PPP,

        // Patient problem message
        PPR,

        // Patient pathway goal-oriented response
        PPT,

        // Patient goal response
        PPV,

        // Patient problem response
        PRR,

        // Patient pathway problem-oriented response
        PTR,

        // Query by parameter
        QBP,

        // Deferred query
        QCK,

        // Cancel query
        QCN,

        // Query, original mode
        QRY,

        // Create subscription
        QSB,

        // Cancel subscription/acknowledge message
        QSX,

        // Query for previous events
        QVR,

        // Pharmacy/treatment administration information
        RAR,

        // Pharmacy/treatment administration message
        RAS,

        // Return clinical information
        RCI,

        // Return clinical list
        RCL,

        // Pharmacy/treatment encoded order message
        RDE,

        // Pharmacy/treatment dispense information
        RDR,

        // Pharmacy/treatment dispense message
        RDS,

        // Display based response
        RDY,

        // Patient referral
        REF,

        // Pharmacy/treatment encoded order information
        RER,

        // Pharmacy/treatment dose information
        RGR,

        // Pharmacy/treatment give message
        RGV,

        // Pharmacy/treatment order response
        ROR,

        // Return patient authorization
        RPA,

        // Return patient information
        RPI,

        // Return patient display list
        RPL,

        // Return patient list
        RPR,

        // Request patient authorization
        RQA,

        // Request clinical information
        RQC,

        // Request patient information
        RQI,

        // Request patient demographics
        RQP,

        // Event replay query
        RQQ,

        // Pharmacy/treatment administration acknowledgment message
        RRA,

        // Pharmacy/treatment dispense acknowledgment message
        RRD,

        // Pharmacy/treatment encoded order acknowledgment message
        RRE,

        // Pharmacy/treatment give acknowledgment message
        RRG,

        // Return referral information
        RRI,

        // Segment pattern response
        RSP,

        // Tabular response
        RTB,

        // Schedule information unsolicited
        SIU,

        // Stored procedure request
        SPQ,

        // Schedule query message
        SQM,

        // Schedule query response
        SQR,

        // Schedule request message
        SRM,

        // Scheduled request response
        SRR,

        // Specimen status request message
        SSR,

        // Specimen status update message
        SSU,

        // Summary product experience report
        SUR,

        // Tabular data response
        TBR,

        // Automated equipment test code settings request message
        TCR,

        // Automated equipment test code settings update message
        TCU,

        // Unsolicited display update message
        UDM,

        // Virtual table query
        VQQ,

        // Query for vaccination record
        VXQ,

        // Vaccination record response
        VXR,

        // Unsolicited vaccination record update
        VXU,

        // Response for vaccination query with multiple PID matches
        VXX
    }

    // Table 0003 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0003
    public enum EventType
    {
        // DT/ACK - Admit/visit notification	
        A01,

        // ADT/ACK - Transfer a patient	
        A02,

        // ADT/ACK -  Discharge/end visit	
        A03,

        // ADT/ACK -  Register a patient	
        A04,

        // ADT/ACK -  Pre-admit a patient	
        A05,

        // ADT/ACK -  Change an outpatient to an inpatient	
        A06,

        // ADT/ACK -  Change an inpatient to an outpatient	
        A07,

        // ADT/ACK -  Update patient information	
        A08,

        // ADT/ACK -  Patient departing - tracking	
        A09,

        // ADT/ACK -  Patient arriving - tracking	
        A10,

        // ADT/ACK -  Cancel admit/visit notification	
        A11,

        // ADT/ACK -  Cancel transfer	
        A12,

        // ADT/ACK -  Cancel discharge/end visit	
        A13,

        // ADT/ACK -  Pending admit	
        A14,

        // ADT/ACK -  Pending transfer	
        A15,

        // ADT/ACK -  Pending discharge	
        A16,

        // ADT/ACK -  Swap patients	
        A17,

        // ADT/ACK -  Merge patient information (for backward compatibility only)	
        A18,

        // QRY/ADR -  Patient query	
        A19,

        // ADT/ACK -  Bed status update	
        A20,

        // ADT/ACK -  Patient goes on a “leave of absence”	
        A21,

        // ADT/ACK -  Patient returns from a “leave of absence”	
        A22,

        // ADT/ACK -  Delete a patient record	
        A23,

        // ADT/ACK -  Link patient information	
        A24,

        // ADT/ACK -  Cancel pending discharge	
        A25,

        // ADT/ACK -  Cancel pending transfer	
        A26,

        // ADT/ACK -  Cancel pending admit	
        A27,

        // ADT/ACK -  Add person information	
        A28,

        // ADT/ACK -  Delete person information	
        A29,

        // ADT/ACK -  Merge person information (for backward compatibility only)	
        A30,

        // ADT/ACK -  Update person information	
        A31,

        // ADT/ACK -  Cancel patient arriving - tracking	
        A32,

        // ADT/ACK -  Cancel patient departing - tracking	
        A33,

        // ADT/ACK -  Merge patient information - patient ID only (for backward compatibility only)	
        A34,

        // ADT/ACK -  Merge patient information - account number only (for backward compatibility only)	
        A35,

        // ADT/ACK -  Merge patient information - patient ID and account number (for backward compatibility only)	
        A36,

        // ADT/ACK -  Unlink patient information	
        A37,

        // ADT/ACK - Cancel pre-admit	
        A38,

        // ADT/ACK - Merge person - patient ID (for backward compatibility only)	
        A39,

        // ADT/ACK - Merge patient - patient identifier list	
        A40,

        // ADT/ACK - Merge account - patient account number	
        A41,

        // ADT/ACK - Merge visit - visit number	
        A42,

        // ADT/ACK - Move patient information - patient identifier list	
        A43,

        // ADT/ACK - Move account information - patient account number	
        A44,

        // ADT/ACK - Move visit information - visit number	
        A45,

        // ADT/ACK - Change patient ID (for backward compatibility only)	
        A46,

        // ADT/ACK - Change patient identifier list	
        A47,

        // ADT/ACK - Change alternate patient ID (for backward compatibility only)	
        A48,

        // ADT/ACK - Change patient account number	
        A49,

        // ADT/ACK - Change visit number	
        A50,

        // ADT/ACK - Change alternate visit ID	
        A51,

        // ADT/ACK - Cancel leave of absence for a patient	
        A52,

        // ADT/ACK - Cancel patient returns from a leave of absence	
        A53,

        // ADT/ACK - Change attending doctor	
        A54,

        // ADT/ACK - Cancel change attending doctor	
        A55,

        // ADT/ACK - Update allergy information	
        A60,

        // ADT/ACK - Change consulting doctor	
        A61,

        // ADT/ACK - Cancel change consulting doctor	
        A62,

        // PMU/ACK - Add personnel record	
        B01,

        // PMU/ACK - Update personnel record	
        B02,

        // PMU/ACK - Delete personnel re cord	
        B03,

        // PMU/ACK - Active practicing person	
        B04,

        // PMU/ACK - Deactivate practicing person	
        B05,

        // PMU/ACK - Terminate practicing person	
        B06,

        // PMU/ACK - Grant Certificate/Permission	
        B07,

        // PMU/ACK - Revoke Certificate/Permission	
        B08,

        // CRM - Register a patient on a clinical trial	
        C01,

        // CRM - Cancel a patient registration on clinical trial (for clerical mistakes only)	
        C02,

        // CRM - Correct/update registration information	
        C03,

        // CRM - Patient has gone off a clinical trial	
        C04,

        // CRM - Patient enters phase of clinical trial	
        C05,

        // CRM - Cancel patient entering a phase (clerical mistake)	
        C06,

        // CRM - Correct/update phase information	
        C07,

        // CRM - Patient has gone off phase of clinical trial	
        C08,

        // CSU - Automated time intervals for reporting, like monthly	
        C09,

        // CSU - Patient completes the clinical trial	
        C10,

        // CSU - Patient completes a phase of the clinical trial	
        C11,

        // CSU - Update/correction of patient order/result information	
        C12,

        // Cancel Query	
        CNQ,

        // RQI/RPI - Request for insurance information	
        I01,

        // RQI/RPL - Request/receipt of patient selection display list	
        I02,

        // RQI/RPR - Request/receipt of patient selection list	
        I03,

        // RQD/RPI - Request for patient demographic data	
        I04,

        // RQC/RCI - Request for patient clinical information	
        I05,

        // RQC/RCL - Request/receipt of clinical data listing	
        I06,

        // PIN/ACK - Unsolicited insurance information	
        I07,

        // RQA/RPA - Request for treatment authorization information	
        I08,

        // RQA/RPA - Request for modification to an authorization	
        I09,

        // RQA/RPA - Request for resubmission of an authorization	
        I10,

        // RQA/RPA - Request for cancellation of an authorization	
        I11,

        // REF/RRI - Patient referral	
        I12,

        // REF/RRI - Modify patient referral	
        I13,

        // REF/RRI - Cancel patient referral	
        I14,

        // REF/RRI - Request patient referral status	
        I15,

        // QCN/ACK - Cancel query/acknowledge message	
        J01,

        // QSX/ACK - Cancel subscription/acknowledge message	
        J02,

        // RSP - Segment pattern response in response to QBP^Q11	
        K11,

        // RTB - Tabular response in response to QBP^Q13	
        K13,

        // RDY - Display response in response to QBP^Q15	
        K15,

        // RSP - Get person demographics response	
        K21,

        // RSP - Find candidates response	
        K22,

        // RSP - Get corresponding identifiers response	
        K23,

        // RSP - Allocate identifiers response	
        K24,

        // RSP - Personnel Information by Segment Response	
        K25,

        // MFN/MFK - Master file not otherwise specified ( for backward compatibility only )	
        M01,

        // MFN/MFK - Master file - staff practitioner	
        M02,

        // MFN/MFK - Master file - test/observation ( for backward compatibility only )	
        M03,

        // MFN/MFK - Master files charge description	
        M04,

        // MFN/MFK - Patient location master file	
        M05,

        // MFN/MFK - Clinical study with phases and schedules master file	
        M06,

        // MFN/MFK - Clinical study without phases but with schedules master file	
        M07,

        // MFN/MFK - Test/observation (numeric) master file	
        M08,

        // MFN/MFK - Test/observation (categorical) master file	
        M09,

        // MFN/MFK - Test /observation batteries master file	
        M10,

        // MFN/MFK - Test/calculated observations master file	
        M11,

        // MFN/MFK - Master file notification message	
        M12,

        // MFN/MFK - Master file notification - general	
        M13,

        // MFN/MFK - Master file notification - site defined	
        M14,

        // MFN/MFK - Inventory item master file notification	
        M15,

        // NMQ/NMR - Application management query message	
        N01,

        // NMD/ACK - Application management data message (unsolicited)	
        N02,

        // ORM - Order message (also RDE, RDS, RGV, RAS)	
        O01,

        // ORR - Order response (also RRE, RRD, RRG, RRA)	
        O02,

        // OMD - Diet order	
        O03,

        // ORD - Diet order acknowledgment	
        O04,

        // OMS - Stock requisition order	
        O05,

        // ORS - Stock requisition acknowledgment	
        O06,

        // OMN - Non-stock requisition order	
        O07,

        // ORN - Non-stock requisition acknowledgment	
        O08,

        // OMP - Pharmacy/treatment order	
        O09,

        // ORP - Pharmacy/treatment order acknowledgment	
        O10,

        // RDE - Pharmacy/treatment encoded order	
        O11,

        // RRE - Pharmacy/treatment encoded order acknowledgment	
        O12,

        // RDS - Pharmacy/treatment dispense	
        O13,

        // RRD - Pharmacy/treatment dispense acknowledgment	
        O14,

        // RGV - Pharmacy/treatment give	
        O15,

        // RRG - Pharmacy/treatment give acknowledgment	
        O16,

        // RAS - Pharmacy/treatment administration	
        O17,

        // RRA - Pharmacy/treatment administration acknowledgment	
        O18,

        // OMG - General clinical order	
        O19,

        // ORG/ORL - General clinical order response	
        O20,

        // OML - Laboratory order	
        O21,

        // ORL - General laboratory order response message to any OML	
        O22,

        // OMI - Imaging order	
        O23,

        // ORI - Imaging order response message to any OMI	
        O24,

        // RDE - Pharmacy/treatment refill authorization request	
        O25,

        // RRE - Pharmacy/Treatment Refill Authorization Acknowledgement	
        O26,

        // OMB - Blood product order	
        O27,

        // ORB - Blood product order acknowledgment	
        O28,

        // BPS - Blood product dispense status	
        O29,

        // BRP - Blood product dispense status acknowledgment	
        O30,

        // BTS - Blood product transfusion/disposition	
        O31,

        // BRT - Blood product transfusion/disposition acknowledgment	
        O32,

        // OML - Laboratory order for multiple orders related to a single specimen	
        O33,

        // ORL - Laboratory order response message to a multiple order related to single specimen OML	
        O34,

        // OML - Laboratory order for multiple orders related to a single container of a specimen	
        O35,

        // ORL - Laboratory order response message to a single container of a specimen OML	
        O36,

        // BAR/ACK - Add patient accounts	
        P01,

        // BAR/ACK - Purge patient accounts	
        P02,

        // DFT/ACK - Post detail financial transaction	
        P03,

        // QRY/DSP - Generate bill and A/R statements	
        P04,

        // BAR/ACK - Update account	
        P05,

        // BAR/ACK - End account	
        P06,

        // PEX - Unsolicited initial individual product experience report	
        P07,

        // PEX - Unsolicited update individual product experience report	
        P08,

        // SUR - Summary product experience report	
        P09,

        // BAR/ACK -Transmit Ambulatory Payment  Classification(APC)	
        P10,

        // DFT/ACK - Post Detail Financial Transactions - New	
        P11,

        // BAR/ACK - Update Diagnosis/Procedure	
        P12,

        // PPR - PC/ problem add	
        PC1,

        // PPR - PC/ problem update	
        PC2,

        // PPR - PC/ problem delete	
        PC3,

        // QRY - PC/ problem query	
        PC4,

        // PRR - PC/ problem response	
        PC5,

        // PGL - PC/ goal add	
        PC6,

        // PGL - PC/ goal update	
        PC7,

        // PGL - PC/ goal delete	
        PC8,

        // QRY - PC/ goal query	
        PC9,

        // PPV - PC/ goal response	
        PCA,

        // PPP - PC/ pathway (problem-oriented) add	
        PCB,

        // PPP - PC/ pathway (problem-oriented) update	
        PCC,

        // PPP - PC/ pathway (problem-oriented) delete	
        PCD,

        // QRY - PC/ pathway (problem-oriented) query	
        PCE,

        // PTR - PC/ pathway (problem-oriented) query response	
        PCF,

        // PPG - PC/ pathway (goal-oriented) add	
        PCG,

        // PPG - PC/ pathway (goal-oriented) update	
        PCH,

        // PPG - PC/ pathway (goal-oriented) delete	
        PCJ,

        // QRY - PC/ pathway (goal-oriented) query	
        PCK,

        // PPT - PC/ pathway (goal-oriented) query response	
        PCL,

        // QRY/DSR - Query sent for immediate response	
        Q01,

        // QRY/QCK - Query sent for deferred response	
        Q02,

        // DSR/ACK - Deferred response to a query	
        Q03,

        // EQQ - Embedded query language query	
        Q04,

        // UDM/ACK - Unsolicited display update message	
        Q05,

        // OSQ/OSR - Query for order status	
        Q06,

        // VQQ - Virtual table query	
        Q07,

        // SPQ - Stored procedure request	
        Q08,

        // RQQ - event replay query	
        Q09,

        // QBP - Query by parameter requesting an RSP segment pattern response	
        Q11,

        // QBP - Query by parameter requesting an  RTB - tabular response	
        Q13,

        // QBP - Query by parameter requesting an RDY display response	
        Q15,

        // QSB - Create subscription	
        Q16,

        // QVR - Query for previous events	
        Q17,

        // QBP - Get person demographics	
        Q21,

        // QBP - Find candidates	
        Q22,

        // QBP - Get corresponding identifiers	
        Q23,

        // QBP - Allocate identifiers	
        Q24,

        // QBP - Personnel Information by Segment Query	
        Q25,

        // ROR - Pharmacy/treatment order response	
        Q26,

        // RAR - Pharmacy/treatment administration information	
        Q27,

        // RDR - Pharmacy/treatment dispense information	
        Q28,

        // RER - Pharmacy/treatment encoded order information	
        Q29,

        // RGR - Pharmacy/treatment dose information	
        Q30,

        // ORU/ACK - Unsolicited transmission of an observation message	
        R01,

        // QRY - Query for results of observation	
        R02,

        // QRY/DSR Display-oriented results, query/unsol. update (for backward compatibility only) (Replaced by Q05)	
        R03,

        // ORF - Response to query; transmission of requested observation	
        R04,

        // EDR - Enhanced Display Response	
        R07,

        // TBR - Tabular Data Response	
        R08,

        // ERP - Event Replay Response	
        R09,

        // OUL - Unsolicited laboratory observation	
        R21,

        // OUL - Unsolicited Specimen Oriented Observation Message	
        R22,

        // OUL - Unsolicited Specimen Container Oriented Observation Message	
        R23,

        // OUL - Unsolicited Order Oriented Observation Message	
        R24,

        // ORU - Unsolicited Point-Of-Care Observation Message Without Existing Order - Place An Order	
        R30,

        // ORU - Unsolicited New Point-Of-Care Observation Message - Search For An Order	
        R31,

        // ORU - Unsolicited Pre-Ordered Point-Of-Care Observation	
        R32,

        // ROR - Pharmacy prescription order query response	
        ROR,

        // SRM/SRR - Request new appointment booking	
        S01,

        // SRM/SRR - Request appointment rescheduling	
        S02,

        // SRM/SRR - Request appointment modification	
        S03,

        // SRM/SRR - Request appointment cancellation	
        S04,

        // SRM/SRR - Request appointment discontinuation	
        S05,

        // SRM/SRR - Request appointment deletion	
        S06,

        // SRM/SRR - Request addition of service/resource on appointment	
        S07,

        // SRM/SRR - Request modification of service/resource on appointment	
        S08,

        // SRM/SRR - Request cancellation of service/resource on appointment	
        S09,

        // SRM/SRR - Request discontinuation of service/resource on appointment	
        S10,

        // SRM/SRR - Request deletion of service/resource on appointment	
        S11,

        // SIU/ACK - Notification of new appointment booking	
        S12,

        // SIU/ACK - Notification of appointment rescheduling	
        S13,

        // SIU/ACK - Notification of appointment modification	
        S14,

        // SIU/ACK - Notification of appointment cancellation	
        S15,

        // SIU/ACK - Notification of appointment discontinuation	
        S16,

        // SIU/ACK - Notification of appointment deletion	
        S17,

        // SIU/ACK - Notification of addition of service/resource on appointment	
        S18,

        // SIU/ACK - Notification of modification of service/resource on appointment	
        S19,

        // SIU/ACK - Notification of cancellation of service/resource on appointment	
        S20,

        // SIU/ACK - Notification of discontinuation of service/resource on appointment	
        S21,

        // SIU/ACK - Notification of deletion of service/resource on appointment	
        S22,

        // SIU/ACK - Notification of blocked schedule time slot(s)	
        S23,

        // SIU/ACK - Notification of opened (“unblocked”) schedule time slot(s)	
        S24,

        // SQM/SQR - Schedule query message and response	
        S25,

        // SIU/ACK Notification that patient did not show up for schedule appointment	
        S26,

        // MDM/ACK - Original document notification	
        T01,

        // MDM/ACK - Original document notification and content	
        T02,

        // MDM/ACK - Document status change notification	
        T03,

        // MDM/ACK - Document status change notification and content	
        T04,

        // MDM/ACK - Document addendum notification	
        T05,

        // MDM/ACK - Document addendum notification and content	
        T06,

        // MDM/ACK - Document edit notification	
        T07,

        // MDM/ACK - Document edit notification and content	
        T08,

        // MDM/ACK - Document replacement notification	
        T09,

        // MDM/ACK - Document replacement notification and content	
        T10,

        // MDM/ACK - Document cancel notification	
        T11,

        // QRY/DOC - Document query	
        T12,

        // ESU/ACK - Automated equipment status update	
        U01,

        // ESR/ACK - Automated equipment status request	
        U02,

        // SSU/ACK - Specimen status update	
        U03,

        // SSR/ACK - specimen status request	
        U04,

        // INU/ACK  - Automated equipment inventory update	
        U05,

        // INR/ACK - Automated equipment inventory request	
        U06,

        // EAC/ACK - Automated equipment command	
        U07,

        // EAR/ACK - Automated equipment response	
        U08,

        // EAN/ACK - Automated equipment notification	
        U09,

        // TCU/ACK - Automated equipment test code settings update	
        U10,

        // TCR/ACK - Automated equipment test code settings request	
        U11,

        // LSU/ACK - Automated equipment log/service update	
        U12,

        // LSR/ACK - Automated equipment log/service request	
        U13,

        // VXQ - Query for vaccination record	
        V01,

        // VXX - Response to vaccination query returning multiple PID matches	
        V02,

        // VXR - Vaccination record response	
        V03,

        // VXU - Unsolicited vaccination record update	
        V04,

        // MFQ/MFR - Master files query (use event same as asking for e.g., M05 - location)	
        Varies,

        // ORU - Waveform result, unsolicited transmission of requested information	
        W01,

        // QRF - Waveform result, response to query
        W02
    }

    // Table 0354 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0354
    public enum MessageStructure
    {
        // Varies	
        ACK,

        // A19	
        ADR_A19,

        // A01, A04, A08, A13	
        ADT_A01,

        // A02	
        ADT_A02,

        // A03	
        ADT_A03,

        // A05, A14, A28, A31	
        ADT_A05,

        // A06, A07	
        ADT_A06,

        // A09, A10, A11, A12	
        ADT_A09,

        // A15	
        ADT_A15,

        // A16	
        ADT_A16,

        // A17	
        ADT_A17,

        // A18	
        ADT_A18,

        // A20	
        ADT_A20,

        // A21, A22, A23, A25, A26, A27, A29, A32, A33	
        ADT_A21,

        // A24	
        ADT_A24,

        // A30, A34, A35, A36, A46, A47, A48, A49	
        ADT_A30,

        // A37	
        ADT_A37,

        // A38	
        ADT_A38,

        // A39, A40, A41, A42	
        ADT_A39,

        // A43, A44	
        ADT_A43,

        // A45	
        ADT_A45,

        // A50, A51	
        ADT_A50,

        // A52, A53, A55	
        ADT_A52,

        // A54	
        ADT_A54,

        // A60	
        ADT_A60,

        // A61, A62	
        ADT_A61,

        // P01	
        BAR_P01,

        // P02	
        BAR_P02,

        // P05	
        BAR_P05,

        // P06	
        BAR_P06,

        // P10	
        BAR_P10,

        // P12	
        BAR_P12,

        // O29	
        BPS_O29,

        // O30	
        BRP_030,

        // O32	
        BRT_O32,

        // O31	
        BTS_O31,

        // C01, C02, C03, C04, C05, C06, C07, C08	
        CRM_C01,

        // C09, C10, C11, C12	
        CSU_C09,

        // P03	
        DFT_P03,

        // P11	
        DFT_P11,

        // T12	
        DOC_T12,

        // P04	
        DSR_P04,

        // Q01	
        DSR_Q01,

        // Q03	
        DSR_Q03,

        // U07	
        EAC_U07,

        // U09	
        EAN_U09,

        // U08	
        EAR_U08,

        // R07	
        EDR_R07,

        // Q04	
        EQQ_Q04,

        // R09	
        ERP_R09,

        // U02	
        ESR_U02,

        // U01	
        ESU_U01,

        // U06	
        INR_U06,

        // U05	
        INU_U05,

        // U12, U13	
        LSU_U12,

        // T01, T03, T05, T07, T09, T11	
        MDM_T01,

        // T02, T04, T06, T08, T10	
        MDM_T02,

        // MFA	
        MFD_MFA,

        // M01, M02, M03, M04, M05, M06, M07, M08, M09, M10, M11	
        MFK_M01,

        // M01	
        MFN_M01,

        // M02	
        MFN_M02,

        // M03	
        MFN_M03,

        // M04	
        MFN_M04,

        // M05	
        MFN_M05,

        // M06	
        MFN_M06,

        // M07	
        MFN_M07,

        // M08	
        MFN_M08,

        // M09	
        MFN_M09,

        // M10	
        MFN_M10,

        // M11	
        MFN_M11,

        // M12	
        MFN_M12,

        // M13	
        MFN_M13,

        // M15	
        MFN_M15,

        // M01, M02, M03, M04, M05, M06	
        MFQ_M01,

        // M01, M02, M03, M04, M05, M06	
        MFR_M01,

        // N02	
        NMD_N02,

        // N01	
        NMQ_N01,

        // N01	
        NMR_N01,

        // O27	
        OMB_O27,

        // O03	
        OMD_O03,

        // O19	
        OMG_O19,

        // O23	
        OMI_O23,

        // O21	
        OML_O21,

        // O33	
        OML_O33,

        // O35	
        OML_O35,

        // O07	
        OMN_O07,

        // O09	
        OMP_O09,

        // O05	
        OMS_O05,

        // O28	
        ORB_O28,

        // O04	
        ORD_O04,

        // R04	
        ORF_R04,

        // O20	
        ORG_O20,

        // O24	
        ORI_O24,

        // O22	
        ORL_O22,

        // O34	
        ORL_O34,

        // O36	
        ORL_O36,

        // O01	
        ORM_O01,

        // O08	
        ORN_O08,

        // O10	
        ORP_O10,

        // O02	
        ORR_R02,

        // O06	
        ORS_O06,

        // R01	
        ORU_R01,

        // R30	
        ORU_R30,

        // R31	
        ORU_R31,

        // R32	
        ORU_R32,

        // W01	
        ORU_W01,

        // Q06	
        OSQ_Q06,

        // Q06	
        OSR_Q06,

        // R21	
        OUL_R21,

        // R22	
        OUL_R22,

        // R23	
        OUL_R23,

        // R24	
        OUL_R24,

        // P07, P08	
        PEX_P07,

        // PC6, PC7, PC8	
        PGL_PC6,

        // B01, B02	
        PMU_B01,

        // B03	
        PMU_B03,

        // B04, B05, B06	
        PMU_B04,

        // B07	
        PMU_B07,

        // B08	
        PMU_B08,

        // PCC, PCG, PCH, PCJ	
        PPG_PCG,

        // PCB, PCD	
        PPP_PCB,

        // PC1, PC2, PC3	
        PPR_PC1,

        // PCL	
        PPT_PCL,

        // PCA	
        PPV_PCA,

        // PC5	
        PRR_PC5,

        // PCF	
        PTR_PCF,

        // Q11	
        QBP_Q11,

        // Q13	
        QBP_Q13,

        // Q15	
        QBP_Q15,

        // Q21, Q22, Q23,Q24, Q25	
        QBP_Q21,

        // Q02	
        QCK_Q02,

        // J01, J02	
        QCN_J01,

        // W02	
        QRF_W02,

        // A19	
        QRY_A19,

        // P04	
        QRY_P04,

        // PC4, PC9, PCE, PCK	
        QRY_PC4,

        // Q01, Q26, Q27, Q28, Q29, Q30	
        QRY_Q01,

        // Q02	
        QRY_Q02,

        // R02	
        QRY_R02,

        // T12	
        QRY_T12,

        // Q16	
        QSB_Q16,

        // Q17	
        QVR_Q17,

        // RAR	
        RAR_RAR,

        // O17	
        RAS_O17,

        // I05	
        RCI_I05,

        // I06	
        RCL_I06,

        // O01	
        RDE_O01,

        // O11, O25	
        RDE_O11,

        // RDR	
        RDR_RDR,

        // O13	
        RDS_O13,

        // K15	
        RDY_K15,

        // I12, I13, I14, I15	
        REF_I12,

        // RER	
        RER_RER,

        // RGR	
        RGR_RGR,

        // O15	
        RGV_O15,

        // ROR	
        ROR_ROR,

        // I08, I09. I10, I11	
        RPA_I08,

        // I01, I04	
        RPI_I01,

        // I02	
        RPL_I02,

        // I03	
        RPR_I03,

        // I08, I09, I10, I11	
        RQA_I08,

        // I05, I06	
        RQC_I05,

        // I01, I02, I03, I07	
        RQI_I01,

        // I04	
        RQP_I04,

        // Q09	
        RQQ_Q09,

        // O02	
        RRA_O02,

        // O18	
        RRA_O18,

        // O14	
        RRD_O14,

        // O12, O26	
        RRE_O12,

        // O16	
        RRG_O16,

        // I12, I13, I14, I15	
        RRI_I12,

        // K11	
        RSP_K11,

        // K21	
        RSP_K21,

        // K22	
        RSP_K22,

        // K23, K24	
        RSP_K23,

        // K13	
        RTB_K13,

        // S12, S13, S14, S15, S16, S17, S18, S19, S20, S21, S22, S23, S24, S26	
        SIU_S12,

        // Q08	
        SPQ_Q08,

        // S25	
        SQM_S25,

        // S25	
        SQR_S25,

        // S01, S02, S03, S04, S05, S06, S07, S08, S09, S10, S11	
        SRM_S01,

        // S01, S02, S03, S04, S05, S06, S07, S08, S09, S10, S11	
        SRR_S01,

        // U04	
        SSR_U04,

        // U03	
        SSU_U03,

        // P09	
        SUR_P09,

        // R08	
        TBR_R08,

        // R09	
        TBR_R09,

        // U10, U11	
        TCU_U10,

        // Q05	
        UDM_Q05,

        // Q07	
        VQQ_Q07,

        // V01	
        VXQ_V01,

        // V03	
        VXR_V03,

        // V04	
        VXU_V04,
        // V02
        VXX_V02
    }

    // Table 0103 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0103
    public enum ProcessingId
    {
        // Debugging
        D,

        // Production
        P,

        // Training
        T
    }

    // Table 0207 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0207
    public enum ProcessingMode
    {
        // Archive
        A,

        // Initial load
        I,

        // Not present (the deafult, meaning current processing)
        Not_Present,

        // Restore from archive
        R,

        // Current processing, transmitted at intervals (scheduled or on demand)
        T
    }

    // Table 0104 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0104
    public enum VersionId
    {
        // Release 2.0	
        V20,

        // Demo 2.0	
        V20D,

        // Release 2.1	
        V21,

        // Release 2.2	
        V22,

        // Release 2.3	
        V23,

        // Release 2.3.1	
        V231,

        // Release 2.4	
        V24,

        // Release 2.5	
        V25,

        // Release 2.5.1	
        V251,

        // Release 2.6	
        V26,

        // Release 2.7
        V27,
    }

    // Table 0211 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0211
    public enum AlternateCharacterSets
    {
        // The printable characters from the ISO 8859/1 Character set
        ISO8859_1,

        // The printable characters from the ISO 8859/15 (Latin-15)
        ISO8859_15,

        // The printable characters from the ISO 8859/2 Character set
        ISO8859_2,

        // The printable characters from the ISO 8859/3 Character set
        ISO8859_3,

        // The printable characters from the ISO 8859/4 Character set
        ISO8859_4,

        // The printable characters from the ISO 8859/5 Character set
        ISO8859_5,

        // The printable characters from the ISO 8859/6 Character set
        ISO8859_6,

        // The printable characters from the ISO 8859/7 Character set
        ISO8859_7,

        // The printable characters from the ISO 8859/8 Character set
        ISO8859_8,

        // The printable characters from the ISO 8859/9 Character set
        ISO8859_9,

        // The printable 7-bit ASCII character set.
        ASCII,

        // Code for Taiwanese Character Set (BIG-5)
        BIG_5,

        // Code for Taiwanese Character Set (CNS 11643-1992)
        CNS11643_1992,

        // Code for Chinese Character Set (GB 18030-2000)
        GB18030_2000,

        // Code for Information Exchange (one byte)(JIS X 0201-1976).
        ISOIR14,

        // Code of the supplementary Japanese Graphic Character set for information interchange (JIS X 0212-1990).
        ISOIR159,

        // ASCII graphic character set consisting of 94 characters.
        ISOIR6,

        // Code for the Japanese Graphic Character set for information interchange (JIS X 0208-1990),
        ISOIR87,

        // Code for Korean Character Set (KS X 1001)
        KSX1001,

        // The world wide character standard from ISO/IEC 10646-1-1993
        UNICODE,

        // UCS Transformation Format, 16-bit form
        UNICODEUTF16,

        // UCS Transformation Format, 32-bit form
        UNICODEUTF32,

        // UCS Transformation Format, 8-bit form
        UNICODEUTF8
    }

    // Table 0356 https://hl7-definition.caristix.com/v2/HL7v2.5/Tables/0356
    public enum AlternateCharacterSetsHandlingSheme
    {
        // This is the default, indicating that there is no character set switching occurring in this message.	
        @null,

        // The character set switching mode specified in HL7 2.5, section 2.7.2 and section 2.A.46, "XPN - extended person name".	
        V23,

        // This standard is titled "Information Technology - Character Code Structure and Extension Technique". .	
        ISO2022_1994
    }

    public enum ErrorSeverity
    {
        // Error	
        E,

        // Fatal Error	
        F,

        // Information
        I,

        // Warning
        W
    }

    public enum QueryPriority
    {
        // Deferred
        D,

        // Immediate
        I
    }

    public enum ModifyIndicator
    {
        // Modified Subscription
        M,

        // New Subscription
        N
    }

    public enum Sequencing
    {
        // Ascending
        A,
        // Ascending, case insensitive
        AN,
        // Descending
        D,
        // Descending, case insensitive
        DN,
        // None
        N
    }
}

public enum ActorType
{
    HELSEPERSONELL,
    INNBYGGER,
    VERIFIKASJONSPERSONELL,
    SAKSBEHANDLER,

}

public enum AccessBasis
{
    SEGSELV,
    FULLMAKT,
    VERGEMAL,
    FORELDREREPRESENTASJON,

    // GP Accessbasis
    UNNTAK,
    SAMTYKKE,
    AKUTT,
    FORHOYET_SAMTYKKE,
    FORHOYET_AKUTT
}

public enum AnonymizeUser
{
    AMK,
    LEGEVAKT
}

public enum Issuer
{
    helsenorge,
    helseID
}

public enum MessageType
{
    NotApplicable,
    ClinicalDocument,
    Unknown
}
public enum XcaAction
{
    InitiatingGatewayQuery,
    InitiatingGatewayRetrieve,
    Unknown
}

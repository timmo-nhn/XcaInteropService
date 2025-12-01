# Patient Identity Management

**XcaInteropService** has functionality for querying Responding Gateways with Domain-specific identifiers, if known. The Domain Config Map contains fields for specifying whether a domain should be queried with the incoming request identifier or the Domain-specific identifier

```mermaid

flowchart

dcm["Domain Config Map"]
xcai["XCA IGW"]
usespix{"Uses PIX?"}
resgw[Responding Gateway]

subgraph "Xca Initiating"
    xcai
    usespix
end

Request --> xcai
xcai --> usespix 
usespix <-- Yes - Replace Identifier for that specific domain query --> dcm
usespix -- No - Query with incoming Identifier --> resgw

```
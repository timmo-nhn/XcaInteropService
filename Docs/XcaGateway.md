# XCA Initiating Gateway
An XCA Initiating Gateway accepts requests from a document consumer wishing to retrieve either document metadata or documents. The Initiating Gateway has a **Domain Config**, which defines a set of endpoints to query to retrieve metadata or documents. In IHE terminology, these are called **Affinity Domains** or **Communities**.

## Initiating and Responding Gateways
The Initiating Gateway is an actor that receives an initial request, and forwards it to all known Responding Gateways.  
Initiating Gateways send requests to Responding gateways. To know which Responding Gateways to call, the **Domain Config Map** is used.

```mermaid
flowchart

irq[Incoming Request]
ig[Initiating Gateway]
rg1[Responding Gateway #1]
rg2[Responding Gateway #2]
rg3[Responding Gateway #3]
dcm[Domain Config Map]@{ shape: doc}

subgraph "XcaInteropService"
    ig
    dcm
end

irq --ITI-18--> ig
ig <--ITI-38---> rg1
ig <--ITI-38---> rg2
ig <--ITI-38---> rg3

ig <-.-> dcm

```

>**🚩 National Extension** <br> The Norwegian usage of IHE XCA infrastructure is set up with a single Initiating Gateway that queries multiple Responding Gateways.

For each domain in the domain config map, the XCA Initiating Gateway sends a ITI-38 message
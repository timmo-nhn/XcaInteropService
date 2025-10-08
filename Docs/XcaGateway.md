# XCA Initiating Gateway
An XCA Initiating Gateway accepts requests from a document consumer wishing to retrieve either document metadata or documents. The Initiating Gateway has a **Domain Config**, which defines a set of endpoints to query to retrieve metadata or documents. In IHE terminology, these are called **Affinity Domains** or **Communities**.

## Initiating and Responding Gateways
The Initiating Gateway is an actor that receives an initial request, and forwards it to all known Responding Gateways. 
```mermaid
flowchart

ig[Initiating Gateway]
rs1[Responding Gateway #1]
rs2[Responding Gateway #2]
rs3[Responding Gateway #3]
rs4[Responding Gateway #4]

ig <--> rs1
ig <--> rs2
ig <--> rs3
ig <--> rs4

```
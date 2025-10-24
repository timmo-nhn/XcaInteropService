# XCA Initiating Gateway
An XCA Initiating Gateway accepts requests from a document consumer wishing to retrieve either document metadata or documents. The Initiating Gateway has a **Domain Config**, which defines a set of endpoints to query to retrieve metadata or documents. In IHE terminology, these are called **Affinity Domains** or **Communities**.

## Preface: Initiating and Responding Gateways
The Initiating Gateway is an actor that receives an initial request, and forwards it to all known Responding Gateways.  
Initiating Gateways send requests to Responding gateways. To know which Responding Gateways to call, a Config Map is used.
```mermaid
flowchart

ig["Initiating Gateway<br>(XcaInteropService)"]
rg1[Responding Gateway #1]
rg2[Responding Gateway #2]
rg3[Responding Gateway #3]
rg4[Responding Gateway #4]

ig <--> rg1
ig <--> rg2
ig <--> rg3
ig <--> rg4

```
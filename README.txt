Project: AIGA
Authors: Abhishek Kumar, Roshan Sumbaly, Shubham Malhotra, Gaurav Paruthi
Last updated: Dec, 2008

DESCRIPTION
AIGA is a Grid based application which works in collaboration with natural language processing (NLP), to act as a virtual assistant. The application can answer queries in a conversational manner and is capable of being deployed in various scenarios.

Given the prevalence of large data sources in natural language engineering and the need for raw computational power in analysis of such data, the Grid Computing paradigm provides efficiencies and scalability otherwise unavailable to researchers.  This project explores the integration of Grid with NLP, to mine relevant answers from these distributed resources. 

AIGA receives queries from various interfaces and then uses NLP to understand the domain of the question. The Grid then routes the queries to the correct knowledge farm, depending on the domain found. Knowledge farms are distributed components which have large annotated domain specific datasets. 

NOTE: The structure of this project is a bit adhoc - it was built on top of the alchemi framework, and then integrated with various interfaces such as Microsoft Conference XP. As such the source of these sub projects are found progressively within the outer project (Eg: AIGA --> edugrid_framework --> edugrid_client --> MsConfXP). The subprojects have been provided with the library files that are built elsewhere in the project for ease of use.


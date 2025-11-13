# Problem Set Variations: CL, CR, and RC Types

To evaluate the scalability and robustness of the proposed CRO-SCM algorithm, several large-scale benchmark problem sets were used: CL1, CL2, CR1, CR2, RC1, and RC2. These datasets originate from the Solomon benchmark suite, a standard in logistics and transportation optimization research.

# Dataset Characteristics

Each problem type represents a different spatial distribution of transportation nodes within the supply chain network:

## CL (Clustered Layout):
Transportation nodes are grouped into distinct clusters. This setup simulates logistics networks where delivery points are concentrated within specific regions or zones.

## CR (Random Layout):
Nodes are distributed randomly across the service area. This represents supply chain systems with widely dispersed customers and destinations.

## RC (Random-Clustered Layout):
A mixed distribution where some nodes are clustered and others are randomly placed. This reflects the most realistic and complex logistics environments, containing both dense and sparse delivery regions.

# Purpose of These Problem Sets

These variations were used to test how well CRO-SCM performs under different network topologies and spatial complexities.
By analyzing performance on clustered (CL), random (CR), and mixed (RC) node distributions, the authors demonstrated that:

CRO-SCM adapts effectively to diverse transportation network structures.

It maintains low transportation cost and computation time across all node distribution types.

The algorithm’s collaborative scheduling strategy remains efficient even in highly complex or unevenly distributed supply chain networks.

In summary, the CL, CR, and RC problem sets were used to verify that CRO-SCM is robust, scalable, and suitable for both structured and unstructured real-world logistics scenarios.

# Chemical Reaction Optimization for Supply Chain Management Transportation (CRO-SCM)

## Overview

This repository provides the source code implementation of the research paper titled **Transportation Scheduling Optimization by a Collaborative Strategy in Supply Chain Management with Third Party Logistics using Chemical Reaction Optimization**.  
The project proposes a meta-heuristic optimization algorithm named **CRO-SCM (Chemical Reaction Optimization for Supply Chain Management)**, designed to minimize collaborative transportation costs within a supply chain network that integrates third party logistics (TPL) enterprises.

The CRO-SCM algorithm applies the principles of Chemical Reaction Optimization (CRO) to address the NP-hard problem of transportation scheduling in supply chain management. It determines optimal routing and vehicle scheduling among manufacturing enterprises, self-support logistics vehicles, and TPL enterprises to minimize total transportation cost and computation time.

## Key Features

1. Implementation of the Chemical Reaction Optimization (CRO) algorithm for supply chain transportation scheduling.
2. Classification of transportation nodes into three categories  
   - Category 1: Nodes served by self-support logistics vehicles  
   - Category 2a: Nodes served directly by TPL vehicles  
   - Category 2b: Nodes served collaboratively by both self-support and TPL vehicles  
3. Use of a collaborative transportation scheduling strategy for efficient logistics planning.
4. Integration of four fundamental CRO reaction operators with an additional repair operator to maintain feasible and cost-effective routing solutions.
5. Random matrix generation for TPL vehicle scheduling to simulate dynamic enterprise assignments.
6. Capability to minimize total transportation cost, improve vehicle utilization, and reduce computation time.
7. Performance comparison with existing Ant Colony Optimization (ACO) and modified ACO-NSO algorithms, demonstrating superior efficiency and robustness.

## Algorithm Description

The CRO-SCM algorithm models the behavior of molecules in a chemical reaction system to perform global and local search within a large solution space. It operates in three main stages:

1. **Initialization**  
   Generation of an initial population (molecules) representing candidate transportation routes.  
   Each molecule encodes a potential solution with transportation costs as potential energy.

2. **Iteration**  
   Execution of CRO reaction operators to refine solutions:  
   - On-wall ineffective collision  
   - Inter-molecular ineffective collision  
   - Decomposition  
   - Synthesis  
   Additionally, a repair operator is applied to reassign nodes and improve underutilized vehicle routes.

3. **Finalization**  
   The algorithm terminates when convergence criteria are met, returning the optimal transportation route configuration with the minimum total cost.

## Experimental Evaluation

The CRO-SCM algorithm was tested using benchmark and randomly generated datasets involving multiple transportation nodes and vehicle types.  
Simulation results show that CRO-SCM achieves lower total transportation costs and shorter execution times compared to traditional ACO, modified ACO-NSO, Genetic Algorithm (GA), and IBM CPLEX solver.

The experiments confirmed that CRO-SCM provides more efficient, practical, and stable results for collaborative supply chain transportation scheduling problems.

## Software and Implementation Details

- Language: C Sharp (C#)
- Platform: Microsoft Visual Studio Community Edition
- Operating System: macOS or Windows
- Algorithm Type: Meta-heuristic Optimization
- Problem Type: NP-hard Combinatorial Optimization

## Citation

If you use this implementation in your research, please cite the following paper:

Md. Rafiqul Islam, Md. Riaz Mahmud, and Rayhan Morshed Pritom,  
**Transportation Scheduling Optimization by a Collaborative Strategy in Supply Chain Management with TPL using Chemical Reaction Optimization**,  
Neural Computing and Applications, Springer Nature, 2020.  
DOI: 10.1007/s00521-019-04218-5

## License

This code is provided for academic and research purposes. Proper citation to the original publication is required in any derived works or publications.

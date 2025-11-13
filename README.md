# Chemical Reaction Optimization for Supply Chain Management Transportation (CRO-SCM)

## Overview

This repository provides the source code implementation of the research paper titled **Transportation Scheduling Optimization by a Collaborative Strategy in Supply Chain Management with Third Party Logistics using Chemical Reaction Optimization**.  
The research work proposes a meta-heuristic optimization algorithm named **CRO-SCM (Chemical Reaction Optimization for Supply Chain Management)**, designed to minimize collaborative transportation costs within a supply chain network that integrates third party logistics (TPL) enterprises.

The CRO-SCM algorithm applies the principles of Chemical Reaction Optimization (CRO) to address the NP-hard problem of transportation scheduling in supply chain management. It determines optimal routing and vehicle scheduling among manufacturing enterprises, self-support logistics vehicles, and TPL enterprises to minimize total transportation cost and computation time using local and global solution space.

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

The CRO-SCM algorithm was extensively evaluated using both standard benchmark datasets and randomly generated datasets with different scales of transportation nodes and vehicle types.

In the primary experiments, a standard dataset with 20 total transportation nodes was used, following the benchmark proposed by Xu et al. This included 10 category-1 nodes, 6 category-2 nodes-b, and 4 category-2 nodes-a. Three types of self-support logistics vehicles and three types of TPL enterprise vehicles were considered. Simulation results showed that CRO-SCM achieved lower total transportation costs and shorter computation times compared to the traditional Ant Colony Optimization (ACO), modified ACO-NSO, Genetic Algorithm (GA), and IBM CPLEX optimizer.

To further analyze scalability and robustness, the authors extended the experiments to 30-node and 40-node problem instances. In the 30-node dataset (15 category-1, 10 category-2b, and 5 category-2a), CRO-SCM maintained superior performance, producing lower average transportation costs and significantly faster convergence compared to modified ACO-NSO. In the 40-node dataset (20 category-1, 10 category-2b, and 10 category-2a), CRO-SCM again outperformed other algorithms, demonstrating stable optimization behavior and reduced standard deviation in results.

Additionally, six large-scale problem sets were constructed to evaluate the robustness of CRO-SCM under different node distributions and problem complexities. These sets—CL1, CL2, CR1, CR2, RC1, and RC2—varied in the spatial distribution of transportation nodes (clustered, random, and semi-clustered) and in total problem size, with some including up to 70–80 category-1 nodes. Across all these scenarios, CRO-SCM consistently achieved lower transportation costs and required less execution time compared to the modified ACO-NSO and other baseline algorithms.

A key enhancement in CRO-SCM, the repair operator, was shown to significantly improve the final results by re-routing underutilized self-support vehicles to maximize vehicle startup cost utilization. Comparative runs with and without the repair operator demonstrated notable reductions in total transportation cost and runtime.

Overall, the experiments confirm that CRO-SCM provides an efficient, scalable, and stable solution for collaborative transportation scheduling in supply chain networks. It consistently outperforms ACO-based and GA-based methods in both cost optimization and computational efficiency across all dataset scales.

## Software and Implementation Details

- Language: C Sharp (C#)
- Platform: Microsoft Visual Studio Community Edition
- Operating System: Windows
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

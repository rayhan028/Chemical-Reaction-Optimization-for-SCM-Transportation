using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagementUsingCRO
{
    public class CROReactionOperator
    {

        //static Random random = new Random();
        //public void OnWallInEffectiveCollision(Molecule molecule)
        //{
            
        //static string[] testSeqence;
        //public int firstSequenceIndex;
        //public int lastSequenceIndex;
        //public float OnWallInEffectiveCollision(string[] molecules, string molecule, int noOfNode, float[,] cost_X, float[,] cost_Y, float[,] distance, float cost)
        //{

        //    GeneratePopulation generatePopulation = new GeneratePopulation();

        //    int flag = 0;
        //    int j;

        //    for (; ; )
        //    {
        //        //Call generateMolecules for new molecule
        //        generatePopulation.generateMolequles(1, noOfNode, cost_X, cost_Y, distance, "default");
               
        //        //check new molecule with existing molecules
        //        //for (j = 0; j < molecules.Length; j++)
        //        //{
        //        //    //Console.WriteLine(molecules[j] + "     " + generatePopulation.molecule +"     Not match");
        //        //    if (molecules[j] == generatePopulation.molecule)
        //        //    {
        //        //        flag = 1;
        //        //        break;
        //        //    }
        //        //}
        //        if (flag == 0)
        //        {
        //            break;
        //        }
        //    }
        //    //Console.WriteLine("OnWall ori" + cost + "new " + generatePopulation.cost);
        //    //take min seqence cost and return it
        //    if (generatePopulation.cost < cost)
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return generatePopulation.cost;
        //    }
        //    else
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return cost;
        //    }

        //}

        //public float decomposition(string[] molecules, string molecule, int noOfNode, float[,] cost_X, float[,] cost_Y, float[,] distance, float cost)
        //{

        //    GeneratePopulation generatePopulation;
        //    //Console.WriteLine(molecule);
        //    int flag = 0;
        //    int j;
        //    float firstHalfSequenceCost = 0;
        //    string firstHalfSequence = "";
        //    float lastHalfSequenceCost = 0;
        //    string lastHalfSequence = "";
        //    float seqenceCost = 0;
        //    for (; ; )
        //    {
        //        //Call generateMolecules for one new molecule

        //        //decompose one molecule to two parts
        //        generatePopulation = new GeneratePopulation();
        //        generatePopulation.generateMolequles(1, noOfNode / 2, cost_X, cost_Y, distance, "default");
        //        firstHalfSequence = generatePopulation.molecule;
        //        firstHalfSequenceCost = generatePopulation.cost;

        //        generatePopulation = new GeneratePopulation();
        //        generatePopulation.generateMolequles(1, noOfNode / 2, cost_X, cost_Y, distance, "NotDefault");
        //        lastHalfSequence = generatePopulation.molecule;
        //        lastHalfSequenceCost = generatePopulation.cost;

        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(firstHalfSequence);
        //        sb.Append(" ");
        //        sb.Append(lastHalfSequence);

        //        //Console.WriteLine(sb.ToString());

        //        seqenceCost = firstHalfSequenceCost + lastHalfSequenceCost;
        //        firstHalfSequenceCost = 0;
        //        lastHalfSequenceCost = 0;
        //        //Console.WriteLine("Decomposition new:"+seqenceCost);
        //        //check new molecule with existing molecules
        //        //for (j = 0; j < molecules.Length; j++)
        //        //{
        //        //    //Console.WriteLine(molecules[j] + "     " + generatePopulation.molecule +"     Not match");
        //        //    if (molecules[j] == generatePopulation.molecule)
        //        //    {
        //        //        flag = 1;
        //        //        break;
        //        //    }
        //        //}
        //        if (flag == 0)
        //        {
        //            break;
        //        }
        //    }

        //    //take min seqence cost and return it
        //    //Console.WriteLine("Decomposition ori:" + cost);
        //    if (seqenceCost < cost)
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return seqenceCost;
        //    }
        //    else
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return cost;
        //    }
        //}

        //public float Synthesis(float firstCost, float lastCost)
        //{
        //    GeneratePopulation generatePopulation = new GeneratePopulation();
        //    //Console.WriteLine("f" + firstCost + " l" + lastCost);
        //    if (firstCost < lastCost)
        //    {
             
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return firstCost;
        //    }
        //    else
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return lastCost;
        //    }

        //}

        //public float InterMoleculerInEffectiveCollision(string[] molecules, string firstMolecule, string lastMolecule, int noOfNode, float[,] cost_X, float[,] cost_Y, float[,] distance, float firstCost, float lastCost)
        //{

        //    GeneratePopulation generatePopulation = new GeneratePopulation();
        //    int flag = 0;
        //    int j;
        //    float testCost1;
        //    float testCost2;
        //    for (; ; )
        //    {
        //        //Call generateMolecules for new molecule
        //        generatePopulation.generateMolequles(1, noOfNode, cost_X, cost_Y, distance, "default");
        //        //check new molecule with existing molecules                         
        //        //for (j = 0; j < molecules.Length; j++)
        //        //{
        //        //    //Console.WriteLine(molecules[j] + "     " + generatePopulation.molecule +"     Not match");
        //        //    if (molecules[j] == generatePopulation.molecule)
        //        //    {
        //        //        flag = 1;
        //        //        break;
        //        //    }
        //        //}
        //        if (flag == 0)
        //        {
        //            break;
        //        }
        //    }

        //    testCost1 = generatePopulation.cost;

        //    for (; ; )
        //    {
        //        //Call generateMolecules for new molecule
        //        generatePopulation.generateMolequles(1, noOfNode, cost_X, cost_Y, distance, "default");

        //        //check new molecule with existing molecules              
        //        //for (j = 0; j < molecules.Length; j++)
        //        //{
        //        //    //Console.WriteLine(molecules[j] + "     " + generatePopulation.molecule +"     Not match");
        //        //    if (molecules[j] == generatePopulation.molecule)
        //        //    {
        //        //        flag = 1;
        //        //        break;
        //        //    }
        //        //}
        //        if (flag == 0)
        //        {
        //            break;
        //        }
        //    }
        //    //Console.WriteLine(firstCost + " " + lastCost);
        //    testCost2 = generatePopulation.cost;
        //    if (testCost2 < testCost1)
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        testCost1 = testCost2;
        //    }
        //    if (lastCost < firstCost)
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        firstCost = lastCost;
        //    }
          
        //    //Console.WriteLine(testCost1 + " " + testCost2);
        //    //take min seqence cost and return it
        //    if (testCost1 < firstCost)
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return testCost1;
                   
        //    }
        //    else
        //    {
        //        lastSequenceIndex = generatePopulation.seqenceIndex;
        //        return firstCost;
        //    }
           
        //}

        //public int getSequenceIndex()
        //{
        //       GeneratePopulation generatePopulation = new GeneratePopulation();

        //       return lastSequenceIndex;
        //}

    }
}

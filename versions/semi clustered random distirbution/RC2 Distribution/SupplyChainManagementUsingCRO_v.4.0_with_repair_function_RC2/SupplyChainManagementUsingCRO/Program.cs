using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagementUsingCRO
{
    class Program
    {

        //initialization

        static int populationSize = 200;
        static double initialKE = 100000.0;
        //static double initialKE_2 = populationSize / 1.5;
        static double KElossRate = 0.2;
        static double moleColl = 0.2;
        // static int decomThresh = 70;
        // static int synThres = 50;
        static int buffer = 0;
        static double minPE = 999;
        static int numHit = 0;
        static int minHit = 0;
        static int noOfIteration = 40;
        static double minCost = 99999;
        static Random random = new Random();
        static Stopwatch sw;
        static int hit = 0;
        static double alfa = 2;
        static double beta = 3;
        static int subroute = 3;
        static double minimum = 99999;
        static double max = 0;
        static double time = 0;
        static double sum = 0;
        static int countZero=0;
        //static StreamWriter sw1;
        static void Main(string[] args)
        {

            //GeneratePopulation gp = new GeneratePopulation();
            //gp.generateMolequles(populationSize, 0, initialKE, minPE);

            //populationSize = 5;
            //ReInitialize();

            //for (int i = 1; i <= noOfIteration; i++)
            //{
            //    try
            //    {
            //        sw = Stopwatch.StartNew();
            //        gp.generateMolequles(populationSize, 0, initialKE, minPE);
            //        Console.WriteLine("Iteration : " + i + " Execution time: " + sw.Elapsed.TotalMilliseconds + "ms");
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            SCM_Transport();
        }
        static void ReInitialize()
        {

            initialKE = 100000.0;
            KElossRate = 0.2;
            moleColl = 0.35;
            //decomThresh = 70;
            //synThres = 50;
            buffer = 10;
            minPE = 99999;
            numHit = 0;
            minHit = 0;
            minCost = 99999;

        }
        static int index1;
        static int index2;
        static double[] solution = new double[populationSize];

        //RepairFunction rf = new RepairFunction();
        private static void SCM_Transport()
        {


            GeneratePopulation gp = new GeneratePopulation();
            OnWallInEffectiveCollision onWallInEffectiveCollission = new OnWallInEffectiveCollision();
            Attributes attributes = new Attributes(KElossRate, buffer);
            InterMolecularInEffectiveCollision interMolecularInEffectiveCollision = new InterMolecularInEffectiveCollision();
            Synthesis synthesis = new Synthesis();
            Decomposition decomposition = new Decomposition();
            StandardDeviation std = new StandardDeviation();
            RepairOperator rf = new RepairOperator();

            random = new Random();

            try
            {


                for (int i = 0; i < noOfIteration; i++)
                {
                    ReInitialize();
                    int iter = 0;
                    int solu_index = 0;
                    MoleculeAttribute moleculeAttribute = new MoleculeAttribute();
                    //(initialKE, KElossRate, moleColl, decomThresh, synThres, buffer, numHit, minPE, minHit);
                    sw = Stopwatch.StartNew();
                    gp.generateMolequles(populationSize, 0, initialKE, minPE);
                    //sw = Stopwatch.StartNew();
                    int counter_2 = 0;

                    for (;;)
                    {
                        iter++;
                        index1 = random.Next(0, populationSize);
                        index2 = random.Next(0, populationSize);
                        double selector = random.NextDouble();


                    
                        if (selector > moleColl)
                        {

                            //Console.WriteLine(selector);

                            if (gp.molecules[index1].getNumHit() - gp.molecules[index1].getMinHit() > alfa)
                            {

                                //Decomposition Operator Call
                                decomposition.startDecomposition(gp.molecules[index1], gp.getInput, index1, attributes, gp);

                                if (gp.molecules[index1].getMinPE() < minCost)
                                {
                                    minCost = gp.molecules[index1].getMinPE();
                                }


                                // Console.WriteLine("Decomposition");
                                //numHit++;
                                //j++;

                            }
                            else
                            {
                                //OnWallInEffective Operator Call
                                //Console.WriteLine("onWallOriginal");
                                //Console.WriteLine("getMINPE " + gp.molecules[index1].getMinPE());
                                //Console.WriteLine("GETMINCOST " + minCost);
                                onWallInEffectiveCollission.startOnWallInEffectiveCollision(gp.molecules[index1], gp.getInput, attributes);
                                if (gp.molecules[index1].getMinPE() < minCost)
                                {
                                    //Console.WriteLine("onWallHIT");
                                    //Console.WriteLine(gp.molecules[index1].getMinPE());
                                    minCost = gp.molecules[index1].getMinPE();
                                }

                                //numHit++;
                                //j++;
                            }

                        }
                        else
                        {

                            //Console.WriteLine(selector);
                            if (gp.molecules[index1].getKE() <= beta)
                            {
                                //Synthesis Operator Call
                                synthesis.startSynthesis(gp.molecules[index1], gp.molecules[index2], index1, index2, attributes, gp);
                                if (gp.molecules[index1].getMinPE() < minCost)
                                {
                                    minCost = gp.molecules[index1].getMinPE();
                                }
                                //Console.WriteLine("synthesis");
                                //j += 2;
                            }
                            else
                            {
                                //Console.WriteLine("interMolecularOriginal-1");
                                //Console.WriteLine(gp.molecules[index1].getPE());
                                //interMolecularInEffectiveCollision Complete
                                interMolecularInEffectiveCollision.startInterMolecularInEffectiveCollision(gp.molecules[index1], gp.molecules[index2], gp.getInput, attributes);
                                if (gp.molecules[index1].getMinPE() < minCost)
                                {
                                    //Console.WriteLine("interMolecularHIT-1");
                                    minCost = gp.molecules[index1].getMinPE();
                                    //Console.WriteLine(gp.molecules[index1].getPE());
                                }
                                //Console.WriteLine("interMolecularOriginal-2");
                                //Console.WriteLine(gp.molecules[index2].getPE());
                                //if (gp.molecules[index2].getMinPE() < minCost)
                                //{
                                //    //Console.WriteLine("interMolecularHIT-2");
                                //    minCost = gp.molecules[index2].getMinPE();
                                //    //Console.WriteLine(gp.molecules[index2].getPE());
                                //}


                            }
                            counter_2++;
                        }
                      
                        //calling repair function for repairing the original solution to get new updated solution

                        if (gp.molecules[index1].getTotalCost() >= 17000)
                        {
                            rf.startRepairing(gp.molecules[index1], gp.getInput, attributes, subroute);
                            minCost = gp.molecules[index1].getTotalCost();
                        }

                      
                        if (minCost < 17000)
                        {
                            solution[solu_index] = minCost;
                            solu_index++;
                            break;
                        }
                    }
                    //Console.WriteLine("Iteration No: " + (i + 1) + " - Cost: " + minCost + " - Execution time: " + sw.Elapsed.TotalMilliseconds + "ms");


                    //int[] temp = gp.molecules[index1].getCat_1();

                    //Console.WriteLine("Selected Route for the solution : ");
                    //try
                    //{
                    //    for (int k = 0; k < temp.Length; k++)
                    //    {
                    //        Console.Write(temp[k]);
                    //        if (k < temp.Length - 1)
                    //            Console.Write("-");
                    //    }

                    //    Console.WriteLine();
                    //    temp = gp.molecules[index1].getCat_2b();

                    //    for (int k = 0; k < temp.Length; k++)
                    //    {
                    //        Console.Write(temp[k]);
                    //        if (k < temp.Length - 1)
                    //            Console.Write("-");
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine("XXXXX----" + ex.Message);
                    //}
                    //Console.WriteLine();
                  
                  
                    //Console.WriteLine("Standard Deviation among Population : " + std.calculateStandardDeviationAmongPopulation(gp.molecules));
                    //Console.WriteLine("Standard Deviation among Solution : " + std.calculateStandardDeviationAmongBestSolution(solution));
                    //Console.WriteLine("-----------------------------------------------------------------------------");

                    attributes.setBuffer(buffer);
                    attributes.setSynCounter(0);
                    attributes.setKELossRate(KElossRate);
                    attributes.setInterCounter(0);
                    attributes.setDecomCounter(0);
                    attributes.setOnwallCounter(0);
                    if(minCost < minimum && minCost>0)
                    {
                        minimum = minCost;
                    }
                    if(minCost>max)
                    {
                        max = minCost;
                    }

                        
                    sum += minCost;
                    time += sw.Elapsed.TotalMilliseconds;
                    if(minCost<=0)
                    {
                        countZero++;
                    }
                    //Console.WriteLine(gp.molecules[gp.molecules.Length-1].getTotalCost());
                    sw.Restart();

                }
                Console.WriteLine(minCost);
                Console.WriteLine("Max: " +max+" Min: "+minimum+" Avg: "+sum/(noOfIteration-countZero)+" Avg.Time: "+time/(noOfIteration-countZero));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("last  " + ex.Message);
            }

        }


    }

}



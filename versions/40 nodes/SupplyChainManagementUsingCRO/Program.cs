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
        static int noOfIteration = 60;
        static double minCost = 19000;
        static Random random;
        static int stopIter = 600;
        static Stopwatch sw;
        static double[] solution;




        static void Main(string[] args)
        {
            try
            {

                sw = Stopwatch.StartNew();
                GeneratePopulation gp = new GeneratePopulation();
                MoleculeAttribute moleculeAttribute = new MoleculeAttribute();

                for (int i = 0; i < noOfIteration; i++)
                {
                    minCost = 2000;
                    stopIter = 0;
                    for (;;)
                    {

                        gp.generateMolequles(1);
                        //solution[stopIter] = gp.molecules[0].getTotalCost();
                        stopIter++;
                        if (gp.molecules[0].getTotalCost() < minCost || stopIter == 100)
                        {
                            //minCost = gp.molecules[0].getTotalCost();
                            //solution[i] = gp.molecules[0].getTotalCost();
                            Console.WriteLine((i + 1) + " " + gp.molecules[0].getTotalCost() + " " + sw.Elapsed.TotalMilliseconds);
                            //Console.WriteLine("Standard Deviation : " + standardDeviation());
                            Console.WriteLine("----------------------------------------------------------");
                            break;
                        }

                    }
                    sw.Restart();
                }
                for (int j = 0; j < noOfIteration; j++)
                {
                    minCost = 19000;
                    solution = new double[400];
                    for (int i = 0; i < 400;)
                    {
                        gp.generateMolequles(1);
                        if (gp.molecules[0].getTotalCost() < minCost)
                        {
                            solution[i] = gp.molecules[0].getTotalCost();
                            i++;
                        }
                    }
                    Console.WriteLine("Standard Deviation for Iteration : " + (j + 1) + " : " + standardDeviation());
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        static double standardDeviation()
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < solution.Length; i++)
                {
                    sum += solution[i];
                }

                double avg = sum / solution.Length;
                double temp = 0;

                for (int i = 0; i < solution.Length; i++)
                {
                    temp = Math.Pow(solution[i] - avg, 2);
                }
                temp = temp / solution.Length;
                double std = Math.Sqrt(temp);

                //Console.WriteLine(std.ToString());
                return std;
            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}





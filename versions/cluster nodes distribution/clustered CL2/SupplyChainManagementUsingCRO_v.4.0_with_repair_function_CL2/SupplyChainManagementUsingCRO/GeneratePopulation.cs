using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagementUsingCRO
{

    public class GeneratePopulation
    {
        public Molecule[] molecules;
        static NodeInformation nodeInfo = new NodeInformation();
        static Random random = new Random();
        static float selfCost = 0;
        static float tplCost = 0;
        static float tplCost2 = 0;

        static int numOfcat_1 = nodeInfo.getNoOfCat_1();
        static int numOfcat_2b = nodeInfo.getNoOfCat_2b();
        static int numOfcat_2a = nodeInfo.getNoOfCat_2a();

        static int subroute = Convert.ToInt32((.4 * numOfcat_1) - 1);

        static int[] cat_1 = new int[numOfcat_1 + subroute];
        static int[] cat_2b = new int[numOfcat_1 + subroute];
        static int[] cat_2b_2 = new int[numOfcat_1 + subroute];
        static float demand = 0;
        static float f = 0;
        static StringBuilder sb = new StringBuilder();
        public GetInput getInput;
        public Molecule synthesisMolecule;

        public void generateMolequles(int populationSize, int tracker, double KE, double minPE)
        {
            try
            {
                molecules = new Molecule[populationSize];
                try
                {
                    for (int i = 0; i < populationSize; i++)
                    {
                        molecules[i] = new Molecule();
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                getInput = new GetInput();

                getMinTPL_TypeACost();
                //Console.WriteLine(tplCost2);
                //call getinput class for taking value from text file


                //get demnad
                getInput.getDemand();

                //get capacity
                getInput.getCapacity();

                //get startup cost
                getInput.getStartupCost();

                //get x, y, z self support cost of vehicle of the category 1 nodes
                getInput.getcost_SelfSupport_X();
                getInput.getcost_SelfSupport_Y();
                getInput.getcost_SelfSupport_Z();

                //get tpl class 1, 2 and 3 enterprize cost of vehile of the category 2-b nodes
                getInput.getcost_TPL_1b();
                getInput.getcost_TPL_2b();
                getInput.getcost_TPL_3b();


                //loop continue about eqaul number of the population size 
                for (int m = 0; m < populationSize;)
                {


                   int flag = 0;
                    //Console.WriteLine("Iteration : " + m);
                    selfCost = 0;
                    tplCost = 0;

                    //initialize cat_1 array
                    for (int i = 0; i < cat_1.Length; i++)
                    {
                        cat_1[i] = 99;
                    }
                    //fill first and last position with 0 which indicated start and end point
                    cat_1[0] = 0;
                    cat_1[numOfcat_1 + subroute - 1] = 0;
                    //cat_1[2] = 0;
                    //cat_1[4] = 0;
                    //cat_1[6] = 0;
                    //generate 3 random position which will be filled with 0 
                    //int subrouteNo = 27;
                    //int[] subRoute = new int[subrouteNo];
                    int a = random.Next(2, 5);
                    //int differ = Convert.ToInt32((numOfcat_1+numOfcat_2b)/subroute);
                    //if (subrouteNo == 5)
                    //a = 0;
                    //Console.Write(subRoute[0] + " ");
                    int differ = 0;
                    // Console.WriteLine(cat_1.Length);
                    for (int i = 0; ; i++)
                    {
                        a = a + differ;
                        if (a >= cat_1.Length)
                        {
                            break;
                        }
                        else
                        {

                            //Console.WriteLine(a);
                            if ((numOfcat_1 + subroute) - a > 2)
                                cat_1[a] = 0;
                            differ = random.Next(3, 4);
                        }

                        //subRoute[i] = a;
                    }

                    //Console.WriteLine("Sub " + (subrouteNo + 1));
                    //generate random positions which will be filled with 0 
                    //for (;;)
                    //{
                    //    int b1 = random.Next(2, 10);
                    //    int b2 = random.Next(2, 10);
                    //    int b3 = random.Next(2, 10);
                    //    //int b4 = random.Next(2, 10);
                    //    // three 0 are used to fill the random three positions to makes 4 subroutes
                    //    if ((b1 - b2 > 1 || b2 - b1 > 1) && (b1 - b3 > 1 || b3 - b1 > 1) && (b2 - b3 > 1 || b3 - b2 > 1))
                    //    {
                    //        cat_1[b1] = 0;
                    //        cat_1[b2] = 0;
                    //        cat_1[b3] = 0;
                    //        break;
                    //    }
                    //    //Console.WriteLine("A");
                    //}
                    //Console.WriteLine();


                    // Console.WriteLine("a");
                    //fill the other position with node value between 1 to 70 randomly to get a proper 4 subroute sequences
                    for (int i = 0; i < cat_1.Length - 1;)
                    {
                        //Console.WriteLine(i);
                        a = random.Next(1, (numOfcat_1 + 1));
                        //Console.WriteLine(a);
                        if (!(cat_1.Contains(a)))
                        {

                            if (cat_1[i] == 0)
                            {
                                cat_1[i + 1] = a;
                                i++;
                            }
                            else
                            {
                                cat_1[i] = a;
                                i++;
                            }

                        }
                    }


                    //display cat_1 nodes sequence with subroutes
                    //for (int i = 0; i < cat_1.Length; i++)
                    //{
                    //    Console.Write(cat_1[i].ToString() + " ");
                    //}
                    //Console.WriteLine();



                    //initialize cat_2b array
                    for (int i = 0; i < cat_2b.Length; i++)
                    {
                        cat_2b[i] = 0;
                    }

                    //fill cat_1 position where 0 doesn't exist with value 

                    for (int i = (numOfcat_1 + 1); i < (numOfcat_1 + numOfcat_2b + 1);)
                    {
                        //generates random position to put value
                        int b1 = random.Next(1, (numOfcat_1 + subroute - 1));
                        //int flag3 = 0;
                        if (cat_1[b1] != 0 && !(cat_2b.Contains(i)))
                        {
                            cat_2b[b1] = i;
                            i++;
                        }
                        //if (cat_1[b1] != 0)
                        //{
                        //    for (int j = (numOfcat_1 + 1); j < (numOfcat_1 + numOfcat_2b + 1); j++)
                        //    {
                        //        if (cat_1[b1] == j)
                        //        {
                        //            flag3 = 1;
                        //            break;
                        //        }
                        //    }
                        //}
                        //if (flag3 == 0)
                        //{
                        //    cat_2b[b1] = i;
                        //    i++;
                        //}
                    }
                    //for (int i = 11; i < 17;)
                    //{
                    //  //generates random position to put value between 11 to 16
                    //   int b1 = random.Next(1, 5);

                    //  if (cat_1[b1] != 0 && cat_2b[b1] != 11 && cat_2b[b1] != 12 && cat_2b[b1] != 13 && cat_2b[b1] != 14 && cat_2b[b1] != 15 && cat_2b[b1] != 16)
                    //  {
                    //      cat_2b[b1] = i;
                    //      i++;                
                    //  }
                    //}
                    //display cat_2b nodes sequence
                    //for (int i = 0; i < cat_2b.Length; i++)
                    //{
                    //    Console.Write(cat_2b[i].ToString() + " "); //}
                    //Console.WriteLine();

                    //for (int i = 0; i < cat_2b_2.Length; i++)
                    //{
                    //	cat_2b_2[i] = 0;
                    //}

                    //for (int i = 11; i < 17;)
                    //{
                    //	//generates random position to put value between 11 to 16
                    //	int b1 = random.Next(1, 12);
                    //	if (cat_1[b1] != 0 && cat_2b_2[b1] != 11 && cat_2b_2[b1] != 12 && cat_2b_2[b1] != 13 && cat_2b_2[b1] != 14 && cat_2b_2[b1] != 15 && cat_2b_2[b1] != 16)
                    //	{
                    //		cat_2b_2[b1] = i;
                    //		i++;
                    //	}
                    //}

                    ////display cat_2b nodes sequence
                    //for (int i = 0; i < cat_2b_2.Length; i++)
                    //{
                    //	Console.Write(cat_2b_2[i].ToString() + " ");
                    //}
                    //Console.WriteLine();


                    //calculate the cost of the one sequence consisting of cat_1 and cat_2b nodes which is generated early
                    int counter = 0;
                    for (int i = 1; i < cat_1.Length; i++)
                    {
                        //check for not containing 0 node 
                        //calculate the cost of the one subroute sequence
                        if (cat_1[i] != 0)
                        {
                            //take the node value of the i position
                            int index1 = cat_1[i];

                            //add it's demand value
                            demand += getInput.demand[index1 - 1];

                            //similarly done for cat_2b nodes
                            if (cat_2b[i] != 0)
                            {
                                int index2 = cat_2b[i];
                                demand += getInput.demand[index2 - 1];
                            }
                            //counter is used for determing the no of nodes that a subroute contains 
                            counter++;

                            //take similar position nodes value to ditermine cost
                            int selfNode = cat_1[i];
                            int tplNode = cat_2b[i];
                            //Console.WriteLine((selfNode+"  "+tplNode));
                            if (tplNode != 0)
                            {
                                try
                                {
                                    //takes three types of vehicle cost to go from the cat_1 to cat_2b
                                    float tplCost_1b = getInput.cost_TPL_1b[selfNode - 1, tplNode - numOfcat_1 - 1];
                                    float tplCost_2b = getInput.cost_TPL_2b[selfNode - 1, tplNode - numOfcat_1 - 1];
                                    float tplCost_3b = getInput.cost_TPL_3b[selfNode - 1, tplNode - numOfcat_1 - 1];

                                    //check for min cost and add min value
                                    if (tplCost_1b < tplCost_2b && tplCost_1b < tplCost_3b)
                                    {
                                        tplCost += tplCost_1b;
                                    }
                                    else if (tplCost_2b < tplCost_1b && tplCost_2b < tplCost_3b)
                                    {
                                        tplCost += tplCost_2b;
                                    }
                                    else
                                    {
                                        tplCost += tplCost_3b;
                                    }
                                    //Console.WriteLine(tplCost_1b + " " + tplCost_2b + " " + tplCost_3b);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                        }
                        else
                        {
                            //end of the subroute and check it for the validity of that subroute
                            if (demand <= getInput.capacity[getInput.capacity.Length - 1])
                            {
                                f = demand;
                                //Select a subroute and calculate cost
                                //Console.WriteLine("demand " + demand);
                                //demand = 0;
                                //Console.WriteLine(("Counter " + counter + " i " + i));
                                //counter = 0;
                                try
                                {
                                    int fisrtNode;
                                    int lastNode;
                                    int demandChecker = 0;
                                    for (int j = 0; j < getInput.capacity.Length; j++)
                                    {

                                        if (demand <= getInput.capacity[j] && demandChecker == 0)
                                        {
                                            //check for if it is vehicle class type X
                                            if (j == 0)
                                            {
                                                //select vehicle X 
                                                //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                                if (counter > 1)
                                                {
                                                    selfCost += getInput.startupCost[j];
                                                    for (int k = i - counter; k < i; k++)
                                                    {

                                                        fisrtNode = cat_1[k];
                                                        lastNode = cat_1[k + 1];
                                                        if (lastNode != 0)
                                                        {
                                                            //Console.WriteLine("X");
                                                            // Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                            selfCost += getInput.cost_SelfSupport_X[fisrtNode - 1, lastNode - 1];
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Console.WriteLine("X");
                                                    selfCost += getInput.startupCost[j];
                                                }
                                            }
                                            //check for if it is vehicle class type Y
                                            else if (j == 1)
                                            {
                                                //select vehicle Y
                                                //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                                if (counter > 1)
                                                {
                                                    selfCost += getInput.startupCost[j];
                                                    for (int k = i - counter; k < i; k++)
                                                    {

                                                        fisrtNode = cat_1[k];
                                                        lastNode = cat_1[k + 1];
                                                        if (lastNode != 0)
                                                        {
                                                            //Console.WriteLine("Y");
                                                            //Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                            selfCost += getInput.cost_SelfSupport_Y[fisrtNode - 1, lastNode - 1];
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Console.WriteLine("Y");
                                                    selfCost += getInput.startupCost[j];
                                                }
                                            }
                                            //check for if it is vehicle class type Z
                                            else if (j == 2)
                                            {
                                                //select vehicle Z
                                                //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                                if (counter > 1)
                                                {
                                                    selfCost += getInput.startupCost[j];
                                                    for (int k = i - counter; k < i; k++)
                                                    {


                                                        fisrtNode = cat_1[k];
                                                        lastNode = cat_1[k + 1];
                                                        if (lastNode != 0)
                                                        {
                                                            //Console.WriteLine("Z");
                                                            //Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                            selfCost += getInput.cost_SelfSupport_Z[fisrtNode - 1, lastNode - 1];
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Console.WriteLine("Z");
                                                    selfCost += getInput.startupCost[j];
                                                }
                                            }
                                            demandChecker = 0;
                                            break;
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                counter = 0;
                                demand = 0;
                            }
                            else
                            {
                                counter = 0;
                                demand = 0;
                                flag = 1;
                                //Console.WriteLine("                                        Discard");
                            }

                            // Console.WriteLine("Cost " + (selfCost));
                        }

                    }
                    //Console.WriteLine("CostSelf " + (selfCost));
                    //Console.WriteLine("TplCost " + tplCost);
                    //Console.WriteLine("TplCost2 " + tplCost2);
                    //Console.WriteLine("TotalMinCost                               " + (selfCost + tplCost + tplCost2));
                    //Console.WriteLine();
                    if (flag == 0)
                    {
                        try
                        {
                            if (tracker == 0) //&& (selfCost + tplCost + tplCost2)<2100)
                            {
                                molecules[m].setCat_1(cat_1);
                                molecules[m].setCat_2b(cat_2b);
                                //Console.WriteLine(demand);
                                molecules[m].setDemand(f);
                                molecules[m].setTpl_Cat2aCost(tplCost2);
                                molecules[m].setTotalCost(selfCost + tplCost + tplCost2);

                                //Console.WriteLine(molecules[m].getTotalCost()+ " - "+m);

                                molecules[m].setPE(selfCost + tplCost + tplCost2);
                                molecules[m].setKE(KE);
                                molecules[m].setNumHit(0);
                                molecules[m].setMinHit(0);
                                molecules[m].setMinPE(minPE);
                                m++;
                            }
                            else //&& (selfCost + tplCost + tplCost2) < 2100)
                            {
                                synthesisMolecule = new Molecule();
                                synthesisMolecule.setCat_1(cat_1);
                                synthesisMolecule.setCat_2b(cat_2b);
                                synthesisMolecule.setDemand(f);
                                synthesisMolecule.setTpl_Cat2aCost(tplCost2);
                                synthesisMolecule.setTotalCost(selfCost + tplCost + tplCost2);
                                synthesisMolecule.setPE(selfCost + tplCost + tplCost2);
                                synthesisMolecule.setKE(KE);
                                synthesisMolecule.setNumHit(0);
                                synthesisMolecule.setMinHit(0);
                                synthesisMolecule.setMinPE(minPE);
                                break;
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //calculate the minimum cost of the tpl enterprizes of the cat_2a nodes
        static void getMinTPL_TypeACost()
        {
            try
            {
                tplCost2 = 0;
                GetInput getInput = new GetInput();
                getInput.getcost_TPL_1a();
                getInput.getcost_TPL_2a();
                getInput.getcost_TPL_3a();
                for (int i = 0; i < getInput.cost_TPL_1a.Length; i++)
                {
                    float tplCost_1a = getInput.cost_TPL_1a[i];
                    float tplCost_2a = getInput.cost_TPL_2a[i];
                    float tplCost_3a = getInput.cost_TPL_3a[i];
                    //Console.WriteLine(tplCost_1a + " " + tplCost_2a + " " + tplCost_3a);
                    if (tplCost_1a < tplCost_2a && tplCost_1a < tplCost_3a)
                    {
                        tplCost2 += tplCost_1a;
                    }
                    else if (tplCost_2a < tplCost_1a && tplCost_2a < tplCost_3a)
                    {
                        tplCost2 += tplCost_2a;
                    }
                    else
                    {
                        tplCost2 += tplCost_3a;
                    }
                }
                //Console.WriteLine("cost" + tplCost2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deleteMolecule(int index)
        {
            molecules[index] = null;
        }
        public void updateOneMolecule(int index, Molecule molecule)
        {
            molecules[index] = molecule;
        }
        public void updateMoleculesForDecomposition(int index, Molecule molecule1, Molecule molecule2)
        {
            if (molecule1.getPE() < molecule2.getPE())
            {
                molecules[index] = molecule1;

            }
            else
            {
                molecules[index] = molecule2;
            }

        }
        public void updateMoleculeForSynthesis(int index1, int index2, Molecule molecule)
        {
            molecules[index1] = molecule;
            molecules[index2] = molecule;
        }

    }
}

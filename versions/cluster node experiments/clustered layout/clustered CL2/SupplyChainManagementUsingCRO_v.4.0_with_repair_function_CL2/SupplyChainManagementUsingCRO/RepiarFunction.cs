using System;
namespace SupplyChainManagementUsingCRO
{
    public class RepiarFunction
    {
        static float demand = 0;
        static float selfCost = 0;
        static float tplCost = 0;
        static float tplCost2 = 0;
        static float f = 0;
        static NodeInformation nodeInfo = new NodeInformation();
        static Random random = new Random();
       

        static int numOfcat_1 = nodeInfo.getNoOfCat_1();
        static int numOfcat_2b = nodeInfo.getNoOfCat_2b();
        static int numOfcat_2a = nodeInfo.getNoOfCat_2a();

        public void startRepairing(Molecule molecule, GetInput getInput, Attributes attributes, int subrouteNo)
        {
            try
            {
                int checkIndex = molecule.getCat_1().Length / subrouteNo;
                int[] cat_1 = molecule.getCat_1();
                int[] cat_2b = molecule.getCat_2b();
                //Console.WriteLine("Repair start");
                //display cat_1 nodes sequence with 4 subroutes
                //for (int i = 0; i < cat_1.Length; i++)
                //{
                //    Console.Write(cat_1[i].ToString() + " ");
                //}
                //Console.WriteLine();
                //display cat_2b nodes sequence
                //for (int i = 0; i < cat_2b.Length; i++)
                //{
                //    Console.Write(cat_2b[i].ToString() + " ");
                //}
                //Console.WriteLine();
                for (int i = 0; i < subrouteNo - 1; i++)
                {
                    if (cat_1[checkIndex] != 0)
                    {
                        for (int j = (checkIndex - (subrouteNo - 2)); j <= (checkIndex + (subrouteNo - 2)); j++)
                        {
                            if (cat_1[j] == 0)
                            {
                                int[] temp_1 = cat_1;
                                int[] temp_2 = cat_2b;

                                cat_1[j] = cat_1[checkIndex];
                                cat_1[checkIndex] = 0;

                                cat_2b[j] = cat_2b[checkIndex];
                                cat_2b[checkIndex] = 0;
                            }
                        }
                    }
                    checkIndex += (subrouteNo - 1);
                    // Console.WriteLine(checkIndex);
                }
                //display cat_1 nodes sequence with 4 subroutes
                //for (int i = 0; i < cat_1.Length; i++)
                //{
                //    Console.Write(cat_1[i].ToString() + " ");
                //}
                //Console.WriteLine();
                //////display cat_2b nodes sequence
                //for (int i = 0; i < cat_2b.Length; i++)
                //{
                //    Console.Write(cat_2b[i].ToString() + " ");
                //}
                //Console.WriteLine();
                //Console.WriteLine("Repair End");
                int flag = 0;
                f = 0;
                //Console.WriteLine("Iteration : " + m);
                selfCost = 0;
                tplCost = 0;
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
                        //Console.WriteLine(demand);
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
                                //Console.WriteLine("TPLCost : "+tplCost);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                    }
                    else
                    {
                        //Console.WriteLine("subroute : " + i + " Demand : " + demand);
                        //end of the subroute and check it for the validity of that subroute
                        if (demand < getInput.capacity[getInput.capacity.Length - 1])
                        {

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

                                    if (demand < getInput.capacity[j] && demandChecker == 0)
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
                                                //Console.WriteLine("X-S");
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
                                                //Console.WriteLine("Y-S");
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
                                                //Console.WriteLine("Z-S");
                                                selfCost += getInput.startupCost[j];
                                            }
                                        }
                                        //Console.WriteLine("SelfCost : "+selfCost);
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
                            f += demand;
                            demand = 0;
                        }
                        else
                        {
                            counter = 0;
                            f += demand;
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
                        molecule.setCat_1(cat_1);
                        molecule.setCat_2b(cat_2b);
                        //Console.WriteLine("Total Demand : "+f);
                        molecule.setDemand(f);
                        molecule.setTpl_Cat2aCost(tplCost2);
                        molecule.setTotalCost(selfCost + tplCost + tplCost2);
                        //Console.WriteLine("Tatal Cost : " +molecules[m].getTotalCost());
                        molecule.setPE(selfCost + tplCost + tplCost2);
                        molecule.setNumHit(0);
                        molecule.setMinHit(0);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}

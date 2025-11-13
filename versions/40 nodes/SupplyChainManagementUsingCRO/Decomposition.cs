using System;
using System.Linq;
using System.Text;

namespace SupplyChainManagementUsingCRO
{
    public class Decomposition
    {
        static Random random = new Random();


        double KE = 1000 / 1.5;
        static NodeInformation nodeInfo = new NodeInformation();
        static int numOfcat_1 = nodeInfo.getNoOfCat_1();
        static int numOfcat_2b = nodeInfo.getNoOfCat_2b();
        static int numOfcat_2a = nodeInfo.getNoOfCat_2a();
        static int subroute = Convert.ToInt32((.4 * numOfcat_1) - 1);

        static float selfCost = 0;
        static float tplCost = 0;
        static float tplCost2 = 0;
        static int[] cat_1_1 = new int[numOfcat_1 + subroute];
        static int[] cat_2b_1 = new int[numOfcat_1 + subroute];
        static int[] cat_1_2 = new int[numOfcat_1 + subroute];
        static int[] cat_2b_2 = new int[numOfcat_1 + subroute];
        static float demand = 0;
        static float totalcost_1 = 0;
        static float totalcost_2 = 0;

        static StringBuilder sb = new StringBuilder();
        Molecule newMo1ecule1 = new Molecule();
        Molecule newMo1ecule2 = new Molecule();
        //static Molecule[] molecule;
        public GetInput getInput;
        public void startDecomposition(Molecule molecule, GetInput getInput, int index, Attributes attributes, GeneratePopulation gp)
        {

            //Console.WriteLine("decom");

            Molecule molcule_1 = new Molecule();
            Molecule molcule_2 = new Molecule();
		    selfCost = 0;
			tplCost = 0;
			tplCost2 = 0;
            totalcost_1 = 0;
            totalcost_2 = 0;
            int count = 0;
            //create first molecule where first half comes from original molecule
            try
            {
                

                int flag = 0;
                //Console.WriteLine("Iteration : " + m);
                selfCost = 0;
                tplCost = 0;

                //initialize cat_1 array
                for (int i = 0; i < cat_1_1.Length; i++)
                {
                    cat_1_1[i] = 99;
                }
                //fill first and last position with 0 which indicated start and end point
                cat_1_1[0] = 0;
                cat_1_1[numOfcat_1 + subroute - 1] = 0;
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
                    if (a >= cat_1_1.Length)
                    {
                        break;
                    }
                    else
                    {

                        //Console.WriteLine(a);
                        if ((numOfcat_1 + subroute) - a > 2)
                            cat_1_1[a] = 0;
                        differ = random.Next(2, 5);
                    }
                }

              
                //fill the other position with node value between 1 to 70 randomly to get a proper 4 subroute sequences
                for (int i = 0; i < cat_1_1.Length - 1;)
                {
                    //Console.WriteLine(i);
                    a = random.Next(1, (numOfcat_1 + 1));
                    //Console.WriteLine(a);
                    if (!(cat_1_1.Contains(a)))
                    {

                        if (cat_1_1[i] == 0)
                        {
                            cat_1_1[i + 1] = a;
                            i++;
                        }
                        else
                        {
                            cat_1_1[i] = a;
                            i++;
                        }

                    }
                }

                for (int i = 0; i < cat_2b_1.Length; i++)
                {
                    cat_2b_1[i] = 0;
                }

                //fill cat_1 position where 0 doesn't exist with value 

                for (int i = (numOfcat_1 + 1); i < (numOfcat_1 + numOfcat_2b + 1);)
                {
                    //generates random position to put value
                    int b1 = random.Next(1, (numOfcat_1 + subroute - 1));
                    //int flag3 = 0;
                    if (cat_1_1[b1] != 0 && !(cat_2b_1.Contains(i)))
                    {
                        cat_2b_1[b1] = i;
                        i++;
                    }
                 
                }
             
                //calculate the cost of the one sequence consisting of cat_1 and cat_2b nodes which is generated early
                int counter = 0;
                for (int i = 1; i < cat_1_1.Length; i++)
                {
                    //check for not containing 0 node 
                    //calculate the cost of the one subroute sequence
                    if (cat_1_1[i] != 0)
                    {
                        //take the node value of the i position
                        int index1 = cat_1_1[i];

                        //add it's demand value
                        demand += getInput.demand[index1 - 1];

                        //similarly done for cat_2b nodes
                        if (cat_2b_1[i] != 0)
                        {
                            int index2 = cat_2b_1[i];
                            demand += getInput.demand[index2 - 1];
                        }
                        //counter is used for determing the no of nodes that a subroute contains 
                        counter++;

                        //take similar position nodes value to ditermine cost
                        int selfNode = cat_1_1[i];
                        int tplNode = cat_2b_1[i];
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
                                // Console.WriteLine(tplCost_1b + " " + tplCost_2b + " " + tplCost_3b);
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

                                                    fisrtNode = cat_1_1[k];
                                                    lastNode = cat_1_1[k + 1];
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

                                                    fisrtNode = cat_1_1[k];
                                                    lastNode = cat_1_1[k + 1];
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


                                                    fisrtNode = cat_1_1[k];
                                                    lastNode = cat_1_1[k + 1];
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

                //Console.WriteLine("TotalMinCost " + (selfCost + tplCost + tplCost2));
                if (flag == 0)
                {
                    try
                    {
                        getMinTPL_TypeACost();
                        totalcost_1 = selfCost + tplCost + tplCost2;
                        newMo1ecule1.setCat_1(cat_1_1);
                        newMo1ecule1.setCat_2b(cat_2b_1);
                        newMo1ecule1.setDemand(demand);
                        newMo1ecule1.setTpl_Cat2aCost(tplCost2);
                        newMo1ecule1.setTotalCost(totalcost_1);
                        newMo1ecule1.setPE(totalcost_1);
                        newMo1ecule1.setKE(KE);
                        newMo1ecule1.setNumHit(0);
                        newMo1ecule1.setMinPE(99999.0);


                        //Console.WriteLine("1st "+totalcost_1);
                        //if (molecule.getTotalCost() < totalCost)
                        //{
                        //    molecule.setCat_1(cat_1_1);
                        //    molecule.setCat_2b(cat_2b_1);
                        //    molecule.setDemand(demand);
                        //    molecule.setTotalCost(totalCost);
                        //    molecule.setTpl_Cat2aCost(tplCost2);

                        //}
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



            //create second molecule where second half comes from original molecule
            try
            {
                selfCost = 0;
                tplCost = 0;
                tplCost2 = 0;
                demand = 0;
                count = 0;
				
				totalcost_1 = 0;
				totalcost_2 = 0;
               
                int flag = 0;
              

                //initialize cat_1 array
                for (int i = 0; i < cat_1_2.Length; i++)
                {
                    cat_1_2[i] = 99;
                }
                //fill first and last position with 0 which indicated start and end point
                cat_1_2[0] = 0;
                cat_1_2[numOfcat_1 + subroute - 1] = 0;
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
                    if (a >= cat_1_2.Length)
                    {
                        break;
                    }
                    else
                    {

                        //Console.WriteLine(a);
                        if ((numOfcat_1 + subroute) - a > 2)
                            cat_1_2[a] = 0;
                        differ = random.Next(2, 5);
                    }
                }


                //fill the other position with node value between 1 to 70 randomly to get a proper 4 subroute sequences
                for (int i = 0; i < cat_1_2.Length - 1;)
                {
                    //Console.WriteLine(i);
                    a = random.Next(1, (numOfcat_1 + 1));
                    //Console.WriteLine(a);
                    if (!(cat_1_2.Contains(a)))
                    {

                        if (cat_1_2[i] == 0)
                        {
                            cat_1_2[i + 1] = a;
                            i++;
                        }
                        else
                        {
                            cat_1_2[i] = a;
                            i++;
                        }

                    }
                }

                for (int i = 0; i < cat_2b_2.Length; i++)
                {
                    cat_2b_2[i] = 0;
                }

                //fill cat_1 position where 0 doesn't exist with value 

                for (int i = (numOfcat_1 + 1); i < (numOfcat_1 + numOfcat_2b + 1);)
                {
                    //generates random position to put value
                    int b1 = random.Next(1, (numOfcat_1 + subroute - 1));
                    //int flag3 = 0;
                    if (cat_1_2[b1] != 0 && !(cat_2b_2.Contains(i)))
                    {
                        cat_2b_2[b1] = i;
                        i++;
                    }

                }


                //calculate the cost of the one sequence consisting of cat_1 and cat_2b nodes which is generated early
                int counter = 0;
                for (int i = 1; i < cat_1_2.Length; i++)
                {
                    //check for not containing 0 node 
                    //calculate the cost of the one subroute sequence
                    if (cat_1_2[i] != 0)
                    {
                        //take the node value of the i position
                        int index1 = cat_1_2[i];

                        //add it's demand value
                        demand += getInput.demand[index1 - 1];

                        //similarly done for cat_2b nodes
                        if (cat_2b_2[i] != 0)
                        {
                            int index2 = cat_2b_2[i];
                            demand += getInput.demand[index2 - 1];
                        }
                        //counter is used for determing the no of nodes that a subroute contains 
                        counter++;

                        //take similar position nodes value to ditermine cost
                        int selfNode = cat_1_2[i];
                        int tplNode = cat_2b_2[i];
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
                                // Console.WriteLine(tplCost_1b + " " + tplCost_2b + " " + tplCost_3b);
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

                                                    fisrtNode = cat_1_2[k];
                                                    lastNode = cat_1_2[k + 1];
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

                                                    fisrtNode = cat_1_2[k];
                                                    lastNode = cat_1_2[k + 1];
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


                                                    fisrtNode = cat_1_2[k];
                                                    lastNode = cat_1_2[k + 1];
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

                //Console.WriteLine("TotalMinCost " + (selfCost + tplCost + tplCost2));
                if (flag == 0)
                {
                    try
                    {
                        getMinTPL_TypeACost();
                        totalcost_2 = selfCost + tplCost + tplCost2;



                        newMo1ecule2.setCat_1(cat_1_2);
                        newMo1ecule2.setCat_2b(cat_2b_2);
                        newMo1ecule2.setDemand(demand);
                        newMo1ecule2.setTpl_Cat2aCost(tplCost2);
                        newMo1ecule2.setTotalCost(totalcost_2);
                        newMo1ecule2.setPE(totalcost_2);
                        newMo1ecule2.setKE(KE);
                        newMo1ecule2.setNumHit(0);
                        newMo1ecule2.setMinPE(999999.0);




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

            //Checking Criteria
            try
            {
                DecompositionCondition decompositionCondition = new DecompositionCondition();


                if (decompositionCondition.checkDecompositionCondition(molecule, newMo1ecule1, newMo1ecule2, index, attributes, gp))
                {
                    //Console.WriteLine("D-M");
                    //attributes.setDecomCounter(0);
                    attributes.setDecomCounter(attributes.getDecomCounter() + 1);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


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

    }
}


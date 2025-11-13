using System;
namespace SupplyChainManagementUsingCRO
{
    public class OnWallInEffectiveCollision
    {
        static Random random = new Random();
        Molecule tempMolecule1 = new Molecule();
        NodeInformation nodeInfo = new NodeInformation();
        OnWallInEffectiveCollisionCondition onWallInEffectiveCollisionCondition = new OnWallInEffectiveCollisionCondition();
        static float tplCost2 = 0;
        public void startOnWallInEffectiveCollision(Molecule molecule,GetInput getInput, Attributes attributes)
        {
           
            try
            {
                //Generate two random index for swapping and create new molecule
                int index_1;
                int index_2;
                //int index_3;
                //int index_4;
                //checking for valid route for case of creating new route
                for (;;)
                {
                    index_1 = random.Next(1,nodeInfo.getNoOfCat_1());
                    index_2 = random.Next(1, nodeInfo.getNoOfCat_1());
                    //index_3 = random.Next(1, 12);
                    //index_4 = random.Next(1, 12);

                    if (molecule.cat_1[index_1] != 0 && molecule.cat_1[index_2] != 0)
                        //&& molecule.cat_1[index_3] != 0 && molecule.cat_1[index_3] != 0 && molecule.cat_2b[index_4] != 0 && molecule.cat_2b[index_4] != 0)
                    {
                        break;
                    }
                }

               
                //create new route
                int[] original_Cat_1 = molecule.cat_1;
                int[] oringinal_Cat_2b = molecule.cat_2b;

                //exchange route node
                int temp = original_Cat_1[index_1];
                original_Cat_1[index_1] = original_Cat_1[index_2];
                original_Cat_1[index_2] = temp;

                //temp = oringinal_Cat_2b[index_1];
                //oringinal_Cat_2b[index_1] = oringinal_Cat_2b[index_2];
                //oringinal_Cat_2b[index_2] = temp;

				//temp = original_Cat_1[index_3];
				//original_Cat_1[index_3] = original_Cat_1[index_4];
				//original_Cat_1[index_4] = temp;

				//temp = oringinal_Cat_2b[index_3];
				//oringinal_Cat_2b[index_3] = oringinal_Cat_2b[index_4];
				//oringinal_Cat_2b[index_4] = temp;

                float demand = 0;
                float selfCost = 0;
                float tplCost = 0;
               

                //calculate the cost of the one sequence consisting of cat_1 and cat_2b nodes which is generated early
                int counter = 0;
                for (int i = 1; i < original_Cat_1.Length; i++)
                {
                    //check for not containing 0 node 
                    //calculate the cost of the one subroute sequence
                    if (original_Cat_1[i] != 0)
                    {
                        //take the node value of the i position
                        int index1 = original_Cat_1[i];

                        //add it's demand value
                        demand += getInput.demand[index1 - 1];

                        //similarly done for cat_2b nodes
                        if (oringinal_Cat_2b[i] != 0)
                        {
                            int index2 = oringinal_Cat_2b[i];
                            demand += getInput.demand[index2 - 1];
                        }
                        //counter is used for determing the no of nodes that a subroute contains 
                        counter++;

                        //take similar position nodes value to dtermine cost
                        int selfNode = original_Cat_1[i];
                        int tplNode = oringinal_Cat_2b[i];
                        //Console.WriteLine((selfNode+"  "+tplNode));
                        if (tplNode != 0)
                        {
                            try
                            {
                                //takes three types of vehicle cost to go from the cat_1 to cat_2b
                                float tplCost_1b = getInput.cost_TPL_1b[selfNode - 1, tplNode - nodeInfo.getNoOfCat_1() - 1];
                                float tplCost_2b = getInput.cost_TPL_2b[selfNode - 1, tplNode - nodeInfo.getNoOfCat_1() - 1];
                                float tplCost_3b = getInput.cost_TPL_3b[selfNode - 1, tplNode - nodeInfo.getNoOfCat_1() - 1];

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

                                                    fisrtNode = original_Cat_1[k];
                                                    lastNode = original_Cat_1[k + 1];
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

                                                    fisrtNode = original_Cat_1[k];
                                                    lastNode = original_Cat_1[k + 1];
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
                                                    fisrtNode = original_Cat_1[k];
                                                    lastNode = original_Cat_1[k + 1];
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
                        }
                    }
                }


                //Console.WriteLine("onwall");

				getMinTPL_TypeACost();
                float cost = selfCost + tplCost + tplCost2;
               // Console.WriteLine("Inner NewCost "+cost);
				//tempMolecule1.setCat_1(original_Cat_1);
				//tempMolecule1.setCat_2b(oringinal_Cat_2b);
				//tempMolecule1.setDemand(demand);
                //tempMolecule1.setTpl_Cat2aCost(tplCost2);
                //tempMolecule1.setTotalCost(cost);
                //tempMolecule1.setPE(cost);
                //tempMolecule1.setKE(999999.0);
                //tempMolecule1.setNumHit(0);
                //tempMolecule1.setMinHit(0);
                //tempMolecule1.setMinPE(99999.0);
              
               
               
                //Checking criteria
              
                if (onWallInEffectiveCollisionCondition.CheckOnWallInEffectiveCollisionCondition(molecule, cost,attributes))
                {
                    //Console.WriteLine("O-M");
                   // attributes.setOnwallCounter(0);
                    attributes.setOnwallCounter(attributes.getOnwallCounter() + 1);
                    //molecule.setCat_1(original_Cat_1);
                    //molecule.setCat_2b(oringinal_Cat_2b);
                    //molecule.setDemand(demand);
                    //molecule.setTpl_Cat2aCost(tplCost2);
                    //molecule.setTotalCost(selfCost + tplCost + tplCost2);
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


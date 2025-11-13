using System;
namespace SupplyChainManagementUsingCRO
{
    public class InterMolecularInEffectiveCollision
    {
        static Random random = new Random();
        NodeInformation nodeInfo = new NodeInformation();
        static float tplCost2_1 = 0;
		float demand_1 = 0;
        float demand_2 = 0;
		float selfCost_1 = 0;
        float selfCost_2 = 0;
		float tplCost_1 = 0;
        float tplCost_2 = 0;
		float cost_1 = 0;
		float cost_2 = 0;
		public void startInterMolecularInEffectiveCollision(Molecule molecule_1, Molecule molecule_2, GetInput getInput,Attributes attributes)
        {
            cost_1 = 0;
			tplCost_1 = 0;
			selfCost_1 = 0;
            demand_1 = 0;
            tplCost2_1 = 0;
			int[] original_Cat_1_1 = molecule_1.cat_1;
			int[] oringinal_Cat_2b_1 = molecule_1.cat_2b;
			int[] original_Cat_1_2 = molecule_1.cat_1;
			int[] oringinal_Cat_2b_2 = molecule_1.cat_2b;
            //Console.WriteLine("inter");
			//Calculation for first molecule
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
                    index_1 = random.Next(1, nodeInfo.getNoOfCat_1());
                    index_2 = random.Next(1, nodeInfo.getNoOfCat_1());
                    //index_3 = random.Next(1, 12);
                    //index_4 = random.Next(1, 12);

                    if (molecule_1.cat_1[index_1] != 0 && molecule_1.cat_1[index_2] != 0)
                    //&& molecule.cat_1[index_3] != 0 && molecule.cat_1[index_3] != 0 && molecule.cat_2b[index_4] != 0 && molecule.cat_2b[index_4] != 0)
                    {
                        break;
                    }
                }

                Molecule tempMolecule = molecule_1;
                //create new route
              

                //exchange route node
                int temp = original_Cat_1_1[index_1];
                original_Cat_1_1[index_1] = original_Cat_1_1[index_2];
                original_Cat_1_1[index_2] = temp;

                //temp = oringinal_Cat_2b_1[index_1];
                //oringinal_Cat_2b_1[index_1] = oringinal_Cat_2b_1[index_2];
                //oringinal_Cat_2b_1[index_2] = temp;

                //temp = original_Cat_1[index_3];
                //original_Cat_1[index_3] = original_Cat_1[index_4];
                //original_Cat_1[index_4] = temp;

                //temp = oringinal_Cat_2b[index_3];
                //oringinal_Cat_2b[index_3] = oringinal_Cat_2b[index_4];
                //oringinal_Cat_2b[index_4] = temp;

             

                //calculate the cost of the one sequence consisting of cat_1 and cat_2b nodes which is generated early
                int counter = 0;
                for (int i = 1; i < original_Cat_1_1.Length; i++)
                {
                    //check for not containing 0 node 
                    //calculate the cost of the one subroute sequence
                    if (original_Cat_1_1[i] != 0)
                    {
                        //take the node value of the i position
                        int index1 = original_Cat_1_1[i];

                        //add it's demand value
                        demand_1 += getInput.demand[index1 - 1];

                        //similarly done for cat_2b nodes
                        if (oringinal_Cat_2b_1[i] != 0)
                        {
                            int index2 = oringinal_Cat_2b_1[i];
                            demand_1 += getInput.demand[index2 - 1];
                        }
                        //counter is used for determing the no of nodes that a subroute contains 
                        counter++;

                        //take similar position nodes value to dtermine cost
                        int selfNode = original_Cat_1_1[i];
                        int tplNode = oringinal_Cat_2b_1[i];
                        //Console.WriteLine((selfNode+"  "+tplNode));
                        if (tplNode != 0)
                        {
                            try
                            {
                                //takes three types of vehicle cost to go from the cat_1 to cat_2b
                                float tplCost_1b = getInput.cost_TPL_1b[selfNode - 1, tplNode -nodeInfo.getNoOfCat_1()- 1];
                                float tplCost_2b = getInput.cost_TPL_2b[selfNode - 1, tplNode -nodeInfo.getNoOfCat_1()- 1];
                                float tplCost_3b = getInput.cost_TPL_3b[selfNode - 1, tplNode -nodeInfo.getNoOfCat_1()- 1];

                                //check for min cost and add min value
                                if (tplCost_1b < tplCost_2b && tplCost_1b < tplCost_3b)
                                {
                                    tplCost_1 += tplCost_1b;
                                }
                                else if (tplCost_2b < tplCost_1b && tplCost_2b < tplCost_3b)
                                {
                                    tplCost_1 += tplCost_2b;
                                }
                                else
                                {
                                    tplCost_1 += tplCost_3b;
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
                        if (demand_1 <= getInput.capacity[getInput.capacity.Length - 1])
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

                                    if (demand_1 <= getInput.capacity[j] && demandChecker == 0)
                                    {
                                        //check for if it is vehicle class type X
                                        if (j == 0)
                                        {
                                            //select vehicle X 
                                            //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                            if (counter > 1)
                                            {
                                                selfCost_1 += getInput.startupCost[j];
                                                for (int k = i - counter; k < i; k++)
                                                {

                                                    fisrtNode = original_Cat_1_1[k];
                                                    lastNode = original_Cat_1_1[k + 1];
                                                    if (lastNode != 0)
                                                    {
                                                        //Console.WriteLine("X");
                                                        // Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                        selfCost_1 += getInput.cost_SelfSupport_X[fisrtNode - 1, lastNode - 1];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("X");
                                                selfCost_1 += getInput.startupCost[j];
                                            }
                                        }
                                        //check for if it is vehicle class type Y
                                        else if (j == 1)
                                        {
                                            //select vehicle Y
                                            //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                            if (counter > 1)
                                            {
                                                selfCost_1 += getInput.startupCost[j];
                                                for (int k = i - counter; k < i; k++)
                                                {

                                                    fisrtNode = original_Cat_1_1[k];
                                                    lastNode = original_Cat_1_1[k + 1];
                                                    if (lastNode != 0)
                                                    {
                                                        //Console.WriteLine("Y");
                                                        //Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                        selfCost_1 += getInput.cost_SelfSupport_Y[fisrtNode - 1, lastNode - 1];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("Y");
                                                selfCost_1 += getInput.startupCost[j];
                                            }
                                        }
                                        //check for if it is vehicle class type Z
                                        else if (j == 2)
                                        {
                                            //select vehicle Z
                                            //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                            if (counter > 1)
                                            {
                                                selfCost_1 += getInput.startupCost[j];
                                                for (int k = i - counter; k < i; k++)
                                                {


                                                    fisrtNode = original_Cat_1_1[k];
                                                    lastNode = original_Cat_1_1[k + 1];
                                                    if (lastNode != 0)
                                                    {
                                                        //Console.WriteLine("Z");
                                                        //Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                        selfCost_1 += getInput.cost_SelfSupport_Z[fisrtNode - 1, lastNode - 1];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("Z");
                                                selfCost_1 += getInput.startupCost[j];
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
                            demand_1 = 0;
                        }
                        else
                        {
                            counter = 0;
                            demand_1 = 0;
                        }
                    }
                }
                getMinTPL_TypeACost();
                //checking criteria
                cost_1 = selfCost_1 + tplCost_1 + tplCost2_1;
                //if (cost_1 < molecule_1.getTotalCost())
                //{
                //    //Console.WriteLine("I-M-1");
                //    molecule_1.setCat_1(original_Cat_1_1);
                //    molecule_1.setCat_2b(oringinal_Cat_2b_1);
                //    molecule_1.setDemand(demand_1);
                //    molecule_1.setTpl_Cat2aCost(tplCost2_1);
                //    molecule_1.setTotalCost(selfCost_1 + tplCost_1 + tplCost2_1);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Calculation for second molecule

            try
            {


				cost_2 = 0;
				tplCost_2 = 0;
				selfCost_2 = 0;
				demand_2 = 0;
				tplCost2_1 = 0;
                //Generate two random index for swapping and create new molecule

                int index_1;
                int index_2;
                //int index_3;
                //int index_4;
                //checking for valid route for case of creating new route
                for (;;)
                {
                    index_1 = random.Next(1, nodeInfo.getNoOfCat_1());
                    index_2 = random.Next(1, nodeInfo.getNoOfCat_1());
                    //index_3 = random.Next(1, 12);
                    //index_4 = random.Next(1, 12);

                    if (molecule_2.cat_1[index_1] != 0 && molecule_2.cat_1[index_2] != 0 )
                    //&& molecule.cat_1[index_3] != 0 && molecule.cat_1[index_3] != 0 && molecule.cat_2b[index_4] != 0 && molecule.cat_2b[index_4] != 0)
                    {
                        break;
                    }
                }

                Molecule tempMolecule = molecule_2;
                //create new route
                //int[] original_Cat_1 = molecule_2.cat_1;
                //int[] oringinal_Cat_2b = molecule_2.cat_2b;

                //exchange route node
                int temp = original_Cat_1_2[index_1];
                original_Cat_1_2[index_1] = original_Cat_1_2[index_2];
                original_Cat_1_2[index_2] = temp;

                //temp = oringinal_Cat_2b_2[index_1];
                //oringinal_Cat_2b_2[index_1] = oringinal_Cat_2b_2[index_2];
                //oringinal_Cat_2b_2[index_2] = temp;

                //temp = original_Cat_1[index_3];
                //original_Cat_1[index_3] = original_Cat_1[index_4];
                //original_Cat_1[index_4] = temp;

                //temp = oringinal_Cat_2b[index_3];
                //oringinal_Cat_2b[index_3] = oringinal_Cat_2b[index_4];
                //oringinal_Cat_2b[index_4] = temp;

              


                //calculate the cost of the one sequence consisting of cat_1 and cat_2b nodes which is generated early
                int counter = 0;
                for (int i = 1; i < original_Cat_1_2.Length; i++)
                {
                    //check for not containing 0 node 
                    //calculate the cost of the one subroute sequence
                    if (original_Cat_1_2[i] != 0)
                    {
                        //take the node value of the i position
                        int index1 = original_Cat_1_2[i];

                        //add it's demand value
                        demand_2 += getInput.demand[index1 - 1];

                        //similarly done for cat_2b nodes
                        if (oringinal_Cat_2b_2[i] != 0)
                        {
                            int index2 = oringinal_Cat_2b_2[i];
                            demand_2 += getInput.demand[index2 - 1];
                        }
                        //counter is used for determing the no of nodes that a subroute contains 
                        counter++;

                        //take similar position nodes value to dtermine cost
                        int selfNode = original_Cat_1_2[i];
                        int tplNode = oringinal_Cat_2b_2[i];
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
                                    tplCost_2 += tplCost_1b;
                                }
                                else if (tplCost_2b < tplCost_1b && tplCost_2b < tplCost_3b)
                                {
                                    tplCost_2 += tplCost_2b;
                                }
                                else
                                {
                                    tplCost_2 += tplCost_3b;
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
                        if (demand_2 <= getInput.capacity[getInput.capacity.Length - 1])
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

                                    if (demand_2 <= getInput.capacity[j] && demandChecker == 0)
                                    {
                                        //check for if it is vehicle class type X
                                        if (j == 0)
                                        {
                                            //select vehicle X 
                                            //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                            if (counter > 1)
                                            {
                                                selfCost_2 += getInput.startupCost[j];
                                                for (int k = i - counter; k < i; k++)
                                                {

                                                    fisrtNode = original_Cat_1_2[k];
                                                    lastNode = original_Cat_1_2[k + 1];
                                                    if (lastNode != 0)
                                                    {
                                                        //Console.WriteLine("X");
                                                        // Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                        selfCost_2 += getInput.cost_SelfSupport_X[fisrtNode - 1, lastNode - 1];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("X");
                                                selfCost_2 += getInput.startupCost[j];
                                            }
                                        }
                                        //check for if it is vehicle class type Y
                                        else if (j == 1)
                                        {
                                            //select vehicle Y
                                            //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                            if (counter > 1)
                                            {
                                                selfCost_2 += getInput.startupCost[j];
                                                for (int k = i - counter; k < i; k++)
                                                {

                                                    fisrtNode = original_Cat_1_2[k];
                                                    lastNode = original_Cat_1_2[k + 1];
                                                    if (lastNode != 0)
                                                    {
                                                        //Console.WriteLine("Y");
                                                        //Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                        selfCost_2 += getInput.cost_SelfSupport_Y[fisrtNode - 1, lastNode - 1];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("Y");
                                                selfCost_2 += getInput.startupCost[j];
                                            }
                                        }
                                        //check for if it is vehicle class type Z
                                        else if (j == 2)
                                        {
                                            //select vehicle Z
                                            //if subroute contains more than one nodes then calcule node to node cost and startup cost
                                            if (counter > 1)
                                            {
                                                selfCost_2 += getInput.startupCost[j];
                                                for (int k = i - counter; k < i; k++)
                                                {


                                                    fisrtNode = original_Cat_1_2[k];
                                                    lastNode = original_Cat_1_2[k + 1];
                                                    if (lastNode != 0)
                                                    {
                                                        //Console.WriteLine("Z");
                                                        //Console.WriteLine(("f " + fisrtNode + " l " + lastNode));
                                                        selfCost_2 += getInput.cost_SelfSupport_Z[fisrtNode - 1, lastNode - 1];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("Z");
                                                selfCost_2 += getInput.startupCost[j];
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
                            demand_2 = 0;
                        }
                        else
                        {
                            counter = 0;
                            demand_2 = 0;
                        }
                    }
                }
                getMinTPL_TypeACost();
                cost_2 = selfCost_2 + tplCost_2 + tplCost2_1;
                //if (cost_2 < molecule_2.getTotalCost())
                //{
                //    //Console.WriteLine("I-M-2");
                //    molecule_2.setCat_1(original_Cat_1_2);
                //    molecule_2.setCat_2b(oringinal_Cat_2b_2);
                //    molecule_2.setDemand(demand_2);
                //    molecule_2.setTpl_Cat2aCost(tplCost2_1);
                //    molecule_2.setTotalCost(selfCost_2 + tplCost_2 + tplCost2_1);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            try
            { 
               
                InterMolecularInEffectiveCollisionCondition interMolecularInEffectiveCollisionCondition = new InterMolecularInEffectiveCollisionCondition();
               
                if (interMolecularInEffectiveCollisionCondition.checkInterMolecularInEffectiveCollisionCondition(molecule_1,molecule_2,cost_1,cost_2))
				{
				    //Console.WriteLine("I-M");
                   // attributes.setInterCounter(0);
                    attributes.setInterCounter(attributes.getInterCounter() + 1);
				    //molecule_2.setCat_1(original_Cat_1_2);
				    //molecule_2.setCat_2b(oringinal_Cat_2b_2);
				    //molecule_2.setDemand(demand_2);
				    //molecule_2.setTpl_Cat2aCost(tplCost2_1);
				    //molecule_2.setTotalCost(selfCost_2 + tplCost_2 + tplCost2_1);
				}
			}
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        static void getMinTPL_TypeACost()
        {
            try
            {
                tplCost2_1 = 0;
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
                        tplCost2_1 += tplCost_1a;
                       
                    }
                    else if (tplCost_2a < tplCost_1a && tplCost_2a < tplCost_3a)
                    {
                        tplCost2_1 += tplCost_2a;
                       
                    }
                    else
                    {
                        tplCost2_1 += tplCost_3a;
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

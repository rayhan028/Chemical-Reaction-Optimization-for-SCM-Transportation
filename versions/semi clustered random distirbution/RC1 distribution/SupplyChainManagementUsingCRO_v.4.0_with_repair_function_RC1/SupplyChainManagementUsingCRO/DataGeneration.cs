using System;
using System.IO;
namespace SupplyChainManagementUsingCRO
{
    public class DataGeneration
    {
        static Random random = new Random();
        static StreamWriter sw;
        //int[,] cost = new int[200, 200];
        NodeInformation nodeInfo = new NodeInformation();
        public void generateData()
        {


            //for cat_1 (selfsupport vehicle) 
            //for X
            double[,] cost;
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/XcostInput.txt");
            cost = new double[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_1()];
            try
            {
                
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_1(); n++)
                    {
                        cost[m, n] = random.Next(50, 150);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();
            ////for Y
            cost = new double[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_1()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/YcostInput.txt");
            try
            {
              
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_1(); n++)
                    {
                        cost[m, n] = random.Next(60, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();
            ////for Z
            cost = new double[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_1()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/ZcostInput.txt");
            try
            {
                
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_1(); n++)
                    {
                        cost[m, n] = random.Next(60, 250);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();

            //for cat_2b
            //for class 1
            cost = new double[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_2b()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/TPL_I(b).txt");
            try
            {
                
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2b(); n++)
                    {
                        cost[m, n] = random.Next(100, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();
           
            //for class 2
            cost = new double[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_2b()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/TPL_II(b).txt");
            try
            {
                
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2b(); n++)
                    {
                        cost[m, n] = random.Next(100, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();
            ////for class 2
            cost = new double[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_2b()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/TPL_III(b).txt");
            try
            {
               
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2b(); n++)
                    {
                        cost[m, n] = random.Next(100, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();

            //for cat_2a
            //for class 1
            cost = new double[1, nodeInfo.getNoOfCat_2a()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/TPL_I(a).txt");
            try
            {
                
                for (int m = 0; m < 1; m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2a(); n++)
                    {
                        cost[m, n] = random.Next(100, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();

            //for cat_2a
            //for class 2
            cost = new double[1, nodeInfo.getNoOfCat_2a()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/TPL_II(a).txt");
            try
            {
               
                for (int m = 0; m < 1; m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2a(); n++)
                    {
                        cost[m, n] = random.Next(100, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();

            //for cat_2a
            //for class 3
            cost = new double[1, nodeInfo.getNoOfCat_2a()];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/TPL_III(a).txt");
            try
            {
               
                for (int m = 0; m < 1; m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2a(); n++)
                    {
                        cost[m, n] = random.Next(100, 200);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= cost.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cost.GetUpperBound(1); j++)
                {
                    output += cost[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();


            //demand
            double[,] demand = new double[1, (nodeInfo.getNoOfCat_1()+nodeInfo.getNoOfCat_2a()+nodeInfo.getNoOfCat_2b())];
            sw = new StreamWriter(@"/Users/riazmahmud/Documents/Thesis/Input_SupplyChainManagementUsingCRO_v.4.0/Demand.txt");
            try
            {

                for (int m = 0; m < 1; m++)
                {
                    for (int n = 0; n < (nodeInfo.getNoOfCat_1() + nodeInfo.getNoOfCat_2a() + nodeInfo.getNoOfCat_2b()); n++)
                    {
                        demand[m, n] = random.Next(1, 10);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            output = "";
            for (int i = 0; i <= demand.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= demand.GetUpperBound(1); j++)
                {
                    output += demand[i, j].ToString() + " ";
                }
                sw.WriteLine(output);
                output = "";
            }
            sw.Close();


        }
    }
}

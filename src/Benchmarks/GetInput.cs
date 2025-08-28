using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagementUsingCRO
{
    public class GetInput
    {

        NodeInformation nodeInfo = new NodeInformation();
        public float[,] cost_SelfSupport_X;
        public float[,] cost_SelfSupport_Y;
        public float[,] cost_SelfSupport_Z;

        public float[] demand;
        public float[] capacity;
        public float[] startupCost;

        public float[,] cost_TPL_1b;
        public float[,] cost_TPL_2b;
        public float[,] cost_TPL_3b;

        public float[] cost_TPL_1a;
        public float[] cost_TPL_2a;
        public float[] cost_TPL_3a;
        Random random = new Random();
        public GetInput()
        {
            cost_SelfSupport_X = new float[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_1()];
            cost_SelfSupport_Y = new float[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_1()];
            cost_SelfSupport_Z = new float[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_1()];
            demand = new float[nodeInfo.getNoOfCat_1() + nodeInfo.getNoOfCat_2a() + nodeInfo.getNoOfCat_2b()];
            capacity = new float[3];
            startupCost = new float[3];
            cost_TPL_1b = new float[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_2b()];
            cost_TPL_2b = new float[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_2b()];
            cost_TPL_3b = new float[nodeInfo.getNoOfCat_1(), nodeInfo.getNoOfCat_2b()];
            cost_TPL_1a = new float[nodeInfo.getNoOfCat_2a()];
            cost_TPL_2a = new float[nodeInfo.getNoOfCat_2a()];
            cost_TPL_3a = new float[nodeInfo.getNoOfCat_2a()];
        }

        public void getDemand()
        {
            try
            {
                for (int n = 0; n < (nodeInfo.getNoOfCat_1() + nodeInfo.getNoOfCat_2a() + nodeInfo.getNoOfCat_2b()); n++)
                {
                    demand[n] = random.Next(1, 10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void getCapacity()
        {

            try
            {
                String input = File.ReadAllText(@"E:\Input_CRO\Capacity_SelfSupport.txt");
                int i = 0;
                foreach (var row in input.Split(' '))
                {
                    capacity[i] = float.Parse(row.Trim());
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void getStartupCost()
        {
            try
            {
                String input = File.ReadAllText(@"E:\Input_CRO\StartupCost_SelfSupport.txt");
                int i = 0;
                foreach (var row in input.Split(' '))
                {
                    startupCost[i] = float.Parse(row.Trim());
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void getcost_SelfSupport_X()
        {
            try
            {

                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_1(); n++)
                    {
                        cost_SelfSupport_X[m, n] = random.Next(1000, 2000)* (.123f);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void getcost_SelfSupport_Y()
        {
            try
            {

                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_1(); n++)
                    {
                        cost_SelfSupport_Y[m, n] = random.Next(900, 2000)* (.117f);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void getcost_SelfSupport_Z()
        {
            try
            {

                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_1(); n++)
                    {
                        cost_SelfSupport_Z[m, n] = random.Next(1000, 2500)* (.113f);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void getcost_TPL_1b()
        {
            try
            {

                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2b(); n++)
                    {
                        cost_TPL_1b[m, n] = random.Next(1200, 2500)* (.1235f);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void getcost_TPL_2b()
        {
            try
            {

                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2b(); n++)
                    {
                        cost_TPL_2b[m, n] = random.Next(1200, 2500)* (.1113f);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void getcost_TPL_3b()
        {
            try
            {
                for (int m = 0; m < nodeInfo.getNoOfCat_1(); m++)
                {
                    for (int n = 0; n < nodeInfo.getNoOfCat_2b(); n++)
                    {
                        cost_TPL_3b[m, n] = random.Next(1200, 2500)* (.223f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void getcost_TPL_1a()
        {
            try
            {
                for (int n = 0; n < nodeInfo.getNoOfCat_2a(); n++)
                {
                    cost_TPL_1a[n] = random.Next(2000, 3000)* (.123f);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getcost_TPL_2a()
        {
            try
            {
                for (int n = 0; n < nodeInfo.getNoOfCat_2a(); n++)
                {
                    cost_TPL_2a[n] = random.Next(2000, 3000)*(.1123f);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void getcost_TPL_3a()
        {
            try
            {
                for (int n = 0; n < nodeInfo.getNoOfCat_2a(); n++)
                {
                    cost_TPL_3a[n] = random.Next(2000, 3000)* (.122f);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}


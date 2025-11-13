using System;

namespace SupplyChainManagementUsingCRO
{
    public class StandardDeviation
    {
        
        public double calculateStandardDeviationAmongPopulation(Molecule[] molecule)
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < molecule.Length; i++)
                {
                    sum += molecule[i].getTotalCost();
                }

                double avg = sum / molecule.Length;
                double temp = 0;

                for (int i = 0; i < molecule.Length; i++)
                {
                    temp = Math.Pow(molecule[i].getTotalCost() - avg,2);
                }
                temp = temp / molecule.Length;
                double std = Math.Sqrt(temp);

                //Console.WriteLine(std.ToString());
                return std;
            }
            catch(Exception)
            {
                return -1;
            }
        }
        public double calculateStandardDeviationAmongBestSolution(double[] solution)
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
                    temp = Math.Pow((solution[i] - avg),2);
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

using System;
namespace SupplyChainManagementUsingCRO
{
    public class InterMolecularInEffectiveCollisionCondition
    {
		
        Random random = new Random();
        public bool checkInterMolecularInEffectiveCollisionCondition(Molecule molecule1, Molecule molecule2,double cost1, double cost2)
        {
			try
			{
                double PE_1 = molecule1.getPE();
                double PE_2 = molecule2.getPE();
                double PE_3 = cost1;
                double PE_4 = cost2;

                double KE_1 = molecule1.getKE();
                double KE_2 = molecule2.getKE();
                double KE_3;
                double KE_4;

				int numHit = molecule1.getNumHit();
				numHit++;
                molecule1.setNumHit(numHit);
                numHit = molecule2.getNumHit();
                numHit++;
                molecule2.setNumHit(numHit);
				
    //            Console.WriteLine("Ori PE_1 " + PE_1);
				//Console.WriteLine("Ori PE_2 " + PE_2);
				//Console.WriteLine("New PE_1 " + PE_3);
				//Console.WriteLine("New PE_2 " + PE_4);
				//Console.WriteLine("Ori KE_1 " + KE_1);
				//Console.WriteLine("Ori KE_2 " + KE_2);


                double e = (PE_1 + PE_2 + KE_1 + KE_2) - (PE_3 + PE_4);
				if (e >= 0)
				{
					double d4 = random.NextDouble();
					KE_3 = e * d4;
					KE_4 = e * (1 - d4);
                    molecule1.setPE(PE_3);
                    molecule2.setPE(PE_4);
                    //molecule1.setKE(KE_3);
                    //molecule2.setKE(KE_4);
                    if(molecule1.getPE() < molecule1.getMinPE())
                    {
                        molecule1.setMinPE(molecule1.getPE());
                        molecule1.setMinHit(molecule1.getNumHit());
                    }
					if (molecule2.getPE() < molecule2.getMinPE())
					{
						molecule2.setMinPE(molecule2.getPE());
						molecule2.setMinHit(molecule2.getNumHit());
					}		
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
        }
    }
}

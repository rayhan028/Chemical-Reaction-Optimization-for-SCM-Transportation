using System;
namespace SupplyChainManagementUsingCRO
{
    public class DecompositionCondition
    {
      
        public bool checkDecompositionCondition(Molecule molecule, Molecule newMolecule1,Molecule newMolecule2,int index, Attributes attributes,GeneratePopulation gp)
        {
            try
            {
                double PE = molecule.getPE();
                double PE_1 = newMolecule1.getPE();
                double PE_2 = newMolecule2.getPE();
                double KE = molecule.getKE();
                double e;
                Random random = new Random();
                double d1;
                double d2;
                double d3;
    //            Console.WriteLine("Original PE "+molecule.getPE());
    //            Console.WriteLine("Original KE " + molecule.getKE());
				//Console.WriteLine("NEW PE_1 " + newMolecule1.getPE());
				//Console.WriteLine("NEW PE_2 " + newMolecule2.getPE());
                int buffer = attributes.getBuffer();
                if (PE + KE >= PE_1 + PE_2)
                {
                    e = PE + KE - (PE_1 + PE_2);
                    d3 = random.NextDouble();
                    double KE_1 = e * d3;
                    double KE_2 = e * (1 - d3);
                    //newMolecule1.setKE(KE_1);
                    //newMolecule2.setKE(KE_2);
                    newMolecule1.setMinPE(PE_1);
                    newMolecule2.setMinPE(PE_2);
                    gp.updateMoleculesForDecomposition(index,newMolecule1,newMolecule2);
     //               Console.WriteLine("abdmnadmabmdbasmndbmasdbmd ------- 1");
					//Console.WriteLine("               AFTER Original PE " + molecule.getPE());
					//Console.WriteLine("               AFTER NEW PE_1 " + newMolecule1.getPE());
					//Console.WriteLine("               AFTER NEW PE_2 " + newMolecule2.getPE());
                    return true;
                }
                else
                {
                    d1 = random.NextDouble();
                    d2 = random.NextDouble();
                    e = PE + KE + (d1 * d2 * buffer) - (PE_1 + PE_2);
                    if(e>=0)
                    {
                        buffer =Convert.ToInt32( buffer * (1 - (d1 * d2)));
                        attributes.setBuffer(buffer);
						d3 = random.NextDouble();
						double KE_1 = e * d3;
						double KE_2 = e * (1 - d3);
						//newMolecule1.setKE(KE_1);
						//newMolecule2.setKE(KE_2);
						newMolecule1.setMinPE(PE_1);
						newMolecule2.setMinPE(PE_2);
						gp.updateMoleculesForDecomposition(index, newMolecule1, newMolecule2);
						//Console.WriteLine("abdmnadmabmdbasmndbmasdbmd ------- 2");
						//Console.WriteLine("               AFTER Original PE " + molecule.getPE());
						//Console.WriteLine("               AFTER NEW PE_1 " + newMolecule1.getPE());
						//Console.WriteLine("               AFTER NEW PE_2 " + newMolecule2.getPE());
                        return true;
                    }
                    else
                    {
                        int numHit = molecule.getNumHit();
                        numHit += 1;
                        molecule.setNumHit(numHit);
						//Console.WriteLine("AFTER Original PE " + molecule.getPE());
						//Console.WriteLine("AFTER NEW PE_1 " + newMolecule1.getPE());
						//Console.WriteLine("AFTER NEW PE_2 " + newMolecule2.getPE());
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}

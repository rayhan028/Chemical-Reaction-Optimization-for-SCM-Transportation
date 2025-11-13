using System;
namespace SupplyChainManagementUsingCRO
{
    public class SynthesisCondition
    {
        
        public bool checkSynthesisCondition(Molecule molecule1, Molecule molecule2, Molecule newMolecule,int index1,int index2, Attributes attributes,GeneratePopulation gp)
        {
            try
            {
                double PE_1 = molecule1.getPE();
                double PE_2 = molecule2.getPE();
                double PE_3 = newMolecule.getPE();
                double KE_1 = molecule1.getKE();
                double KE_2 = molecule2.getKE();
				//Console.WriteLine("Original PE_1 " + molecule1.getPE());
    //            Console.WriteLine("Original PE_2 " + molecule2.getPE());
				//Console.WriteLine("NEW PE " + newMolecule.getPE());
				//Console.WriteLine("Original KE_1 " + molecule1.getKE());
				//Console.WriteLine("Original KE_2 " + molecule2.getKE());
				if (PE_1 + PE_2 + KE_1 + KE_2 >= PE_3)
                {
                    double KE_3 = (PE_1 + PE_2 + KE_1 + KE_2) - PE_3;
                    //newMolecule.setKE(KE_3);
                    newMolecule.setMinPE(PE_3);
                    gp.updateMoleculeForSynthesis(index1,index2,newMolecule);
                    return true;
                }
                else
                {
                    int numHit = molecule1.getNumHit();
                    numHit += 1;
                    molecule1.setNumHit(numHit);

				    numHit = molecule2.getNumHit();
					numHit += 1;
					molecule2.setNumHit(numHit);
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

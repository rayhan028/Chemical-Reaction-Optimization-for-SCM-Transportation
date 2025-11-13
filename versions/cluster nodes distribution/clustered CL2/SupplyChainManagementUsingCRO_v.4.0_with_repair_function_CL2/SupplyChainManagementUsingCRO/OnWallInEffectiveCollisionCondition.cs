using System;
namespace SupplyChainManagementUsingCRO
{
    public class OnWallInEffectiveCollisionCondition
    {
       
        public bool CheckOnWallInEffectiveCollisionCondition(Molecule originalMolcule,double PE, Attributes attributes)
        {
            try
            {
                MoleculeAttribute moleculeAttribute = new MoleculeAttribute();
                //Console.WriteLine("Innner OriPE "+originalMolcule.getPE());
                //Console.WriteLine("Innner OriKE " + originalMolcule.getKE());
                //Console.WriteLine("Inner NewPE " + PE);
                double originalKE = originalMolcule.getKE();
                double newKE;
                int numHit = originalMolcule.getNumHit();
                numHit++;
                originalMolcule.setNumHit(numHit);
                double originalPE = originalMolcule.getPE();
                double newPE = PE;

                if (originalPE + originalKE >= newPE)
                {
                    Random random = new Random();
                    double a;
                    double KELossRate = attributes.getKELossRate();
                    a = random.NextDouble();
                    for (;;)
                    {
                        if (a >= KELossRate)
                        {
                            break;
                        }
                        else
                        {
                            a = random.NextDouble();
                        }

                    }
                    newKE = (originalPE - newPE + originalKE) * a;
					//Console.WriteLine("After Inner NewKE " + newKE);
                    int buffer = attributes.getBuffer();
                    buffer = buffer + Convert.ToInt32(newKE * (1 - a));
                    attributes.setBuffer(buffer);
                    originalMolcule.setPE(newPE);
                    //originalMolcule.setKE(newKE);
                    if (originalMolcule.getPE() < originalMolcule.getMinPE())
                    {
                        //Console.WriteLine("aAA");
                        originalMolcule.setMinPE(newPE);
                        originalMolcule.setMinHit(originalMolcule.getNumHit());
                    }
					//Console.WriteLine("Afetr Innner Ori " + originalMolcule.getPE());
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

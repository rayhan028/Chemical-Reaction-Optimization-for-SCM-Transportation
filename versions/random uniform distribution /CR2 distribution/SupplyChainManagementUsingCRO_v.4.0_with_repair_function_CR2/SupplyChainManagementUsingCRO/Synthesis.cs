using System;
namespace SupplyChainManagementUsingCRO
{
    public class Synthesis
    {

		static Random random = new Random();

		double KE = 1000 / 1.5;

        SynthesisCondition synthesisCondition = new SynthesisCondition();
		//static float tplCost2 = 0;
		GeneratePopulation gp1 = new GeneratePopulation();
		public void startSynthesis(Molecule molecule_1, Molecule molecule_2,int index1, int index2, Attributes attributes,GeneratePopulation gp)
        {
            //Generate new molecule
            try
            {
               
                gp1.generateMolequles(1, 1,KE,99999.0);
               

                if (synthesisCondition.checkSynthesisCondition(molecule_1,molecule_2,gp1.synthesisMolecule,index1,index2, attributes,gp))
                {
                    //Console.WriteLine("S-M");
                    //attributes.setSynCounter(0);
                    attributes.setSynCounter(attributes.getSynCounter() + 1);
                    //molecule_1.setCat_1(gp.synthesisMolecule.getCat_1());
                    //molecule_1.setCat_2b(gp.synthesisMolecule.getCat_2b());
                    //molecule_1.setDemand(gp.synthesisMolecule.getdemand());
                    //molecule_1.setTotalCost(gp.synthesisMolecule.getTotalCost());
                    // molecule_1.setTpl_Cat2aCost(gp.synthesisMolecule.getTpl_Cat2aCost());
                    // molecule_1.setVehicleSequence(gp.synthesisMolecule.getVehicleSequence());
                }
                //if (gp.synthesisMolecule.getTotalCost() < molecule_2.getTotalCost())
                //{
                //    //Console.WriteLine("S-M-2");
                //    molecule_2.setCat_1(gp.synthesisMolecule.getCat_1());
                //    molecule_2.setCat_2b(gp.synthesisMolecule.getCat_2b());
                //    molecule_2.setDemand(gp.synthesisMolecule.getdemand());
                //    molecule_2.setTotalCost(gp.synthesisMolecule.getTotalCost());
                //    //molecule_2.setTpl_Cat2aCost(gp.synthesisMolecule.getTpl_Cat2aCost());
                //    //molecule_2.setVehicleSequence(gp.synthesisMolecule.getVehicleSequence());
                //}
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		}
		
    }
}

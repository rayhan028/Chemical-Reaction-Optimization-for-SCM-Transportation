using System;
namespace SupplyChainManagementUsingCRO
{
    public class Molecule : MoleculeAttribute
    {
        public int[] cat_1;
        public int[] cat_2b;
        public float demand;
        public float tplCat_2aCost;
        public float totalCost;
        public string vehicleSequence;


        public void setCat_1(int[] nodes)
        {
            cat_1 = nodes;

        }
        public int[] getCat_1()
        {
            return cat_1;
        }

        public void setCat_2b(int[] nodes)
        {
            cat_2b = nodes;
        }

        public int[] getCat_2b()
        {
            return cat_2b;
        }
        public void setDemand(float d)
        {
            demand = d;
        }

        public float getdemand()
        {
            return demand;
        }
		public void setTpl_Cat2aCost(float c)
		{
            tplCat_2aCost = c;
		}

		public float getTpl_Cat2aCost()
		{
			return tplCat_2aCost;
		}

        public void setTotalCost(float c)
        {
            totalCost = c;
        }

        public float getTotalCost()
        {
            return totalCost;
        }

        public void setVehicleSequence(string s)
        {
            vehicleSequence = s;
        }

        public string getVehicleSequence()
        {
            return vehicleSequence;
        }

    }
}

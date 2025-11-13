using System;
namespace SupplyChainManagementUsingCRO
{
    public class MoleculeAttribute
    {
        double PE;	
        double minPE;
        double KE;
     
        double moleColl;
        int decomThresh;
        int synThresh;
       
        int numHit;
        int minHit;
      
        //public void SetMoleculeAttribute(double KE, double KElossRate, double moleColl, int decomThresh, int synThresh, int buffer,int numHit,double minPE,int minHit)
        //{
          
        //    this.KElossRate = KElossRate;
           
          
        //    this.buffer = buffer;
         
        //    this.minPE = minPE;
        //    this.minHit = minHit;
        //}

        public void setPE(double PE)
        {
            this.PE = PE;
        }
        public double getPE()
        {
            return PE;
        }
		public void setMinPE(double minPE)
		{
            this.minPE = minPE;
		}
		public double getMinPE()
		{
            return minPE;
		}

        public void setKE(double KE)
        {
            this.KE = KE;
        }
        public double getKE()
        {
            return KE;
        }
       
        public void setMoleColl(double moleColl)
        {
            this.moleColl = moleColl;
        }
        public double getMoleColl()
        {
            return moleColl;
        }
        public void setDecomThresh(int decomThresh)
        {
            this.decomThresh = decomThresh;
        }
        public int getDecomThresh()
        {
            return decomThresh;
        }
        public void setSynThresh(int synThresh)
        {
            this.synThresh = synThresh;
        }
        public int getSynThresh()
        {
            return synThresh;
        }
       
        public void setNumHit(int numHit)
        {
            this.numHit = numHit;
        }
        public int getNumHit()
        {
            return numHit;
        }
		public void setMinHit(int minHit)
		{
			this.minHit = minHit;
		}
		public int getMinHit()
		{
			return minHit;
		}

    }
}

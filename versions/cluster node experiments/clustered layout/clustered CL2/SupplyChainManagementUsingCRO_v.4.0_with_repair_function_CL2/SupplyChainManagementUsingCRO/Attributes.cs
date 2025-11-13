using System;
namespace SupplyChainManagementUsingCRO
{
    public class Attributes
    {
		double KElossRate;
		int buffer;
		int onwall = 0;
		int decom = 0;
		int inter = 0;
		int syn = 0;
        public Attributes(double KElossRate, int buffer)
        {
            this.KElossRate = KElossRate;
            this.buffer = buffer;
        }

		public void setKELossRate(double KElossRate)
		{
			this.KElossRate = KElossRate;
		}
		public double getKELossRate()
		{
			return KElossRate;
		}
		public void setBuffer(int buffer)
		{
			this.buffer = buffer;
		}
		public int getBuffer()
		{
			return buffer;
		}
        public void setOnwallCounter(int onwall)
        {
            this.onwall = onwall;
        }
        public int getOnwallCounter()
        {
            return onwall;
        }
		public void setDecomCounter(int decom)
		{
            this.decom = decom;
		}
		public int getDecomCounter()
		{
			return decom;
		}
		public void setInterCounter(int inter)
		{
            this.inter = inter;
		}
		public int getInterCounter()
		{
            return inter;
		}
		public void setSynCounter(int syn)
		{
            this.syn= syn;
		}
		public int getSynCounter()
		{
            return syn;
		}
    }
}

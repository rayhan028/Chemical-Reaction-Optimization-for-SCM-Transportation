using System;
namespace SupplyChainManagementUsingCRO
{
    public class NodeInformation
    {
        public int noOfCat_1 = 80;
        public int noOfCat_2a = 15;
        public int noOfCat_2b = 10;

        public void setNofoCat_1(int noOfCat_1)
        {
            this.noOfCat_1 = noOfCat_1;
        }
        public int getNoOfCat_1()
        {
            return noOfCat_1;
        }

		public void setNofoCat_2a(int noOfCat_2a)
		{
			this.noOfCat_2a = noOfCat_2a;
		}
		public int getNoOfCat_2a()
		{
			return noOfCat_2a;
		}

		public void setNofoCat_2b(int noOfCat_2b)
		{
			this.noOfCat_2b = noOfCat_2b;
		}
		public int getNoOfCat_2b()
		{
			return noOfCat_2b;
		}
    }
}

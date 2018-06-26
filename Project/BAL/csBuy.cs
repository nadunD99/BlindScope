using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class csBuy
    {
        private static int min;
        private List<int> array = new List<int>();
        static int buycount=0;
        static int  stocks = 50;
        static int price;
        public static int x = 0;public static int ccom=0;
        int[] valu = {10,50,100,200};
        int arrycount = 0; 
        public int Analysis(int val)
        {
            try
            {
                array.Add(val);
                if (array.Count == valu[arrycount])
                {
                    min = array[0];
                    for (int i = 0; i < array.Count; i++)
                    {
                        if (min > array[i])
                        {
                            min = array[i];
                            break;
                        }
                        else
                        {
                            min = array[0];
                        }
                    }
                    arrycount++;
                }
                else if (array.Count > valu[arrycount - 1] && array.Count < valu[arrycount])
                {
                    int x = array.Count - 1;
                    if (min == array[x])
                    {
                        if (buycount < 1)
                        {
                            buycount++;
                            Buy();
                        }
                    }
                }

                else
                {
                    min = array[0];
                }
                return min;
            }
            catch (Exception)
            {
                min = array[0];
                return min;
            }
          
        }
        public static string Buy()
        {
            price = stocks * min;
            csDBOperator obj = new csDBOperator();
            string s= obj.mdbuyWithAI(min,price,stocks);
            ccom = 1;
            csSale obj2 = new csSale(1,price,stocks);
            return s;
        }
    }
}

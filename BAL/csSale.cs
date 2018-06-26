using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class csSale :csBuy
    {
        int com, perprice, perstock;
        int pro,lost,tot,btot,ftot;
        static List<int> getVal = new List<int>();
        static int max;
        public csSale()
        {
            //nothing happend at all
        }
        void hidePlay()
        {

        }
        public csSale(int val)
        {
            getVal.Add(val);
            saleAi();
        }
        public csSale(int ccom, int perprice, int perstock)
        {
            this.com = ccom;
            this.perprice = perprice;
            this.perstock = perstock;
        }
         public static void saleAi()
        {
            if (ccom == 1)
            {
                max = getVal[0];
                for (int i = 0; i < getVal.Count; i++)
                {
                    if (max < getVal[i])
                    {
                        max = getVal[i];
                        ccom = 0;
                        csSale obj = new csSale();
                        obj.sale();
                    }

                }
            }
        }
        public void sale()
        {
            tot = max * 50;
            btot = perprice * perstock;
            ftot = tot - btot;
            if (ftot > 0)
            {
                pro = ftot;
                lost = 0;
            }
            else
            {
                lost = ftot;
                pro = 0;
            }
        }
    }
}

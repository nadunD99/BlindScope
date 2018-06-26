using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class csAnalysiscs
    {
        static List<int> lsitAnalysis = new List<int>();
        static int val;
        static int min;
        static int max;
        static string stat;
        public csAnalysiscs(int i)
        {
            lsitAnalysis.Add(i);
            val = i;
        }
        public static string AnalysisData()
        {
            
            for (int i = 0; i < lsitAnalysis.Count; i++)
            {
                if (val > lsitAnalysis[i])
                {
                    max++;
                }
                else if(val < lsitAnalysis[i])
                {
                    min++;
                }
            }
            if (max > min)
            {
                stat = "Sale";
            }
            else
            {
                stat = "Buy";
            }
            return stat;
        }        
    }
}

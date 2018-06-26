using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class csGetVal
    {
        public static List<string> city1 = new List<string>();
        public static List<string> numb = new List<string>();
        string x; string s;
        private static Regex rxDigits = new Regex(@"[\d]+");

        public string getValuesFromYFinance(out List<string> num)
        {
           
            try
            {
                WebClient w = new WebClient();
                if (csProperties.IDD == 1)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 2)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 3)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 4)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 5)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 6)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 7)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 8)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 9)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 10)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 11)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                else if (csProperties.IDD == 12)
                {
                     s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");
                }
                // 2.
                foreach (csLinkItem i in LinkFinder.Find(s))
                {
                    city1.Add(i.ToString());
                }

                for (int i = 0; i < city1.Count; i++)
                {
                    numb.Add(CleanStringOfNonDigits_V3(city1[i]));
                    if (numb[i] == "")
                    {
                        numb[i] = "10";
                    }
                }
                //listBox1.DataSource = numb;
                num = numb;
                return "done";

            }
            catch (Exception)
            {
                num = numb;
                return "check the internet connection";
            }
        }
        

        private string CleanStringOfNonDigits_V3(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            StringBuilder sb = new StringBuilder();
            for (Match m = rxDigits.Match(s); m.Success; m = m.NextMatch())
            {
                sb.Append(m.Value);
            }
            string cleaned = sb.ToString();
            return cleaned;
        }
    }
}

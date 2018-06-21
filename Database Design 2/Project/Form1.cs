using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BAL;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace Project
{
    public partial class Form1 : Form
    {

        #region variables
        int[] myarray = { 1, 2, 4, 2, 1, 3, 5 };
        List<string> city1 = new List<string>();
        List<string> numb = new List<string>();
        private string date = DateTime.Now.Date.ToString("MM/dd/yyyy");
        string ex;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        List<int> GetVala = new List<int>();
        decimal OLOST, OBALACE, OPROFIT, OPPRICE,OPSTOCK;
        private List<int> DID = new List<int>();
        private List<int> DValue = new List<int>();
        private List<string> DDATE = new List<string>();
        private static List<int> DDValueTrim = new List<int>();
        string uname;
        #endregion
        csDBOperator obj = new csDBOperator();
        public Form1(string UNAME)
        {
            uname = UNAME;
            InitializeComponent();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            getdata(); mLoadplyerStat();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        void getdata()
        {
            obj.mcbgetTableAvailable(out GetVala);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //chart1.Series[0].Points.DataBindY(GetVala);
            //chart1.Series[1].Points.DataBindY(myarray);
           
        }
        void getValuesFromYFinance()
        {
            try
            {
                WebClient w = new WebClient();
                string s = w.DownloadString("https://finance.yahoo.com/quote/CSV/history/?guccounter=1");

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
            }
            catch (Exception)
            {
                MessageBox.Show("check the internet connection");
            }
        }
        
        private static Regex rxDigits = new Regex(@"[\d]+");

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

        private void button1_Click(object sender, EventArgs e)
        {
            getValuesFromYFinance();
            SetValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                csDBOperator obj001 = new csDBOperator();
                string msg = obj001.mdDataFEED();
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void SetValues()
        {
            csProperties.Value = numb;
            csProperties.ID = 1;
            csProperties.Date = date;
                          
        }
        void GetValues()
        {
            csDBOperator obj00 = new csDBOperator();
            obj00.mcbgetTableAvailable(out DID,out DDATE,out DValue,out ex);
            for (int i = 0; i < DValue.Count; i++)
            {
                if (DValue[i] < 1000)
                {
                    DDValueTrim.Add(DValue[i]);
                }
             }
            MessageBox.Show(DDValueTrim.Count.ToString());
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetValues();
        }
        int c;
        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.DataBindY(TempVal);
            c = TempVal.Count;
            label1.Text = TempVal[c-1].ToString();
        }
        static List<int> TempVal = new List<int>();
        Thread t1 = new Thread(new ThreadStart(printNumbers));
        static void printNumbers()
        {

            
            for (int i = 0; i < DDValueTrim.Count; i++)
            {
                Form1 obj = new Form1("v");
                TempVal.Add(DDValueTrim[i]);
                obj.chart1.Series[0].Points.DataBindY(TempVal);
                Thread.Sleep(5000);
            }
        }

      
        private void button5_Click(object sender, EventArgs e)
        {
            t1.Start();
            timer.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BuyStock obb = new BuyStock(label1.Text,OBALACE);
            obb.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label9.Text = csProperties.Number.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mLoadSecondList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            t1.Abort();
            timer.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            csProperties.StockValu = Convert.ToInt32(label1.Text);
            Sale obj = new Sale();
            obj.ShowDialog();
        }
        List<string> data = new List<string>();
        void clearList()
        {
            data.Clear();
            //listBox2.Items.Clear();
        }
        

        void mLoadplyerStat()
        {
            obj.mcbgetPlayerStat(out OPPRICE,out OPSTOCK,out OLOST,out OPROFIT,out OBALACE,uname);
           data.Add(uname);
            data.Add(OPROFIT.ToString());
            data.Add(OLOST.ToString());
            data.Add(OBALACE.ToString());
            data.Add(OPPRICE.ToString());
            data.Add(OPSTOCK.ToString());
            listBox2.DataSource = data;

        }
        void mLoadSecondList()
        {
            listBox1.Items.Add(csProperties.Number);
            listBox1.Items.Add(csProperties.Balance);
            listBox1.Items.Add(csProperties.Price);

        }
    }
}


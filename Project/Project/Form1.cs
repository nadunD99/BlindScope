﻿using System;
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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        #region variables
        int[] myarray = { 1, 2, 4, 2, 1, 3, 5 };
        static int iddd;
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
        private static List<int> IDValueTrim = new List<int>();
        string uname;int users;
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
            csProperties.Date = date;
            hide();
        }
        private void Active()
        {
            try
            {
                csDBOperator obj001 = new csDBOperator();
                obj001.mcbgetCurrentID(out iddd);
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
            
            csGetVal obj = new csGetVal();
            obj.getValuesFromYFinance(out numb);
            csProperties.Value = numb;
            csProperties.ID = 1;
            csProperties.Date = date;
            MessageBox.Show(numb.Count.ToString());
                          
        }
        void track_current_value()
        {

        }

        void GetValues()
        {
            csDBOperator obj00 = new csDBOperator();
            obj00.mcbgetTableAvailable(out DID,out DDATE,out DValue,out ex);
            for (int i = 0; i < DValue.Count; i++)
            {
                if (DValue[i] < 5000)
                {
                    DDValueTrim.Add(DValue[i]);
                    IDValueTrim.Add(DID[i]);
                }
             }
            MessageBox.Show(DValue.Count.ToString());
           
        }

       
        int c;
       
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series[0].Points.DataBindY(TempVal);
                c = TempVal.Count;
                label1.Text = TempVal[c - 1].ToString();
            }
            catch (Exception) { }
        }
        static List<int> TempVal = new List<int>();
        static List<int> TempIDVal = new List<int>();
        Thread t1 = new Thread(new ThreadStart(printNumbers));
        Thread t2 = new Thread(new ThreadStart(printNumbers1));

        private static void printNumbers1()
        {
            csDBOperator obj2 = new csDBOperator();
            for (int i = 0; i < DDValueTrim.Count; i++)
            {
                if (IDValueTrim[i] == iddd)
                {
                    Form1 obj = new Form1("v");
                    TempVal.Add(DDValueTrim[i]);
                    TempIDVal.Add(IDValueTrim[i]);
                    obj.chart1.Series[0].Points.DataBindY(TempVal);
                   
                    obj2.mdDataFEED5(IDValueTrim[i]);
                    Thread.Sleep(5000);
                    for (int j = i + 1; j < DDValueTrim.Count; j++)
                    {
                        Form1 obj1 = new Form1("v");
                        TempVal.Add(DDValueTrim[j]);
                        TempIDVal.Add(IDValueTrim[j]);
                        obj1.chart1.Series[0].Points.DataBindY(TempVal);
                       
                        obj2.mdDataFEED5(IDValueTrim[j]);
                        csDBOperator obj001 = new csDBOperator();
                        obj001.mcbgetCurrentID(out iddd);
                        obj.label11.Text = iddd.ToString();
                        Thread.Sleep(5000);
                    }
                }
            }
        }

        Thread ai = new Thread(new ThreadStart(activeai));
        static void printNumbers()
        {
            csDBOperator obj2 = new csDBOperator();
            for (int i = 0; i < DDValueTrim.Count; i++)
            {
               Form1 obj = new Form1("v");
               TempVal.Add(DDValueTrim[i]);
               TempIDVal.Add(IDValueTrim[i]);
               obj.chart1.Series[0].Points.DataBindY(TempVal);
               obj2.mdDataFEED5(IDValueTrim[i]);
               obj.setVAl();
               Thread.Sleep(5000);
            }
        }
        void setVAl()
        {
            csDBOperator obj001 = new csDBOperator();
            obj001.mcbgetCurrentID(out iddd);
            label11.Text = iddd.ToString();
        }

        void start()
        {
            t1.Start();
            timer.Start();
        }
        void start1()
        {
            t2.Start();
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void catarpillarINCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void boeingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bMWToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sAMPATHBANKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csProperties.Sectorid = 1;
            csProperties.Stockid = 1;
            csProperties.IDD = 1;
        }

        private void bOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csProperties.Sectorid = 2;
            csProperties.Stockid = 1;
            csProperties.IDD = 2;
        }

        private void hNBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csProperties.Sectorid = 3;
            csProperties.Stockid = 1;
            csProperties.IDD = 3;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            PlayerStar();
            Thread.Sleep(2000);
            label11.Text = users.ToString();
            visible();
            Thread.Sleep(2000);
            if (users == 1)
            {
                SetValues();
                Thread.Sleep(2000);
                Active();
                Thread.Sleep(2000);
                GetValues();
                Thread.Sleep(2000);
                start();
                Thread.Sleep(2000);
                MessageBox.Show("Minimum no of players not available,computer player will be activate..");
                //ai.Start();
            }
            else
            {
                csDBOperator obj001 = new csDBOperator();
                obj001.mcbgetCurrentID(out iddd);
                label11.Text = iddd.ToString();
                GetValues();
                Thread.Sleep(2000);
                start1();
                Thread.Sleep(2000);
            }

        }
        void hide()
        {
            chart1.Hide();
            button1.Hide();
            button2.Hide();
            button4.Hide();
            button6.Hide();
            button7.Hide();
            button9.Hide();
            button10.Hide();
            button8.Hide();
           

        }
        void visible()
        {
            chart1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button8.Visible = true;

        }
        void PlayerStar()
        {
            csDBOperator obj = new csDBOperator();
            string msg= obj.mdDataFEED4(out users);
           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ai.Start();
        }

        List<string> data = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            ai.Suspend();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        void clearList()
        {
            data.Clear();
            //listBox2.Items.Clear();
        }
        static void activeai()
        {


            csBuy obj = new csBuy();
            Form1 oobj = new Form1("sds");
            for (int i = 0; i < 100000; i++)
            {

                int d = TempVal.Count-1;
                int x = TempVal[d];
                int ms = obj.Analysis(x);
                new csSale(x);
                MessageBox.Show(ms.ToString());
                Thread.Sleep(5000);
            }
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


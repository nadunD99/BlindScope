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

namespace Project
{
    public partial class Sale : MetroFramework.Forms.MetroForm
    {
        int price, stock;
        string name, name2,x;
        public Sale()
        {
            InitializeComponent(); Display();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetSalesVal(); SalesSet();
            
        }
        void SetSalesVal()
        {
            csProperties.SECNAME = lblsectorname.Text;
            csProperties.STOCKNAME = lblstockname.Text;
            csProperties.STOKCVAL = Convert.ToInt16(lblpst.Text);
            csProperties.STOCKS = Convert.ToInt16(textBox1.Text);
            csProperties.PSTROKPRICE = Convert.ToInt16(label6.Text);
            csProperties.CURRENT = Convert.ToInt16(label6.Text);
            csProperties.SALESSTOCKVAL = Convert.ToInt16(lblst.Text);
            csProperties.PROFIT = pro;
            csProperties.LOST = lost;

        }
       static int current, purchaseprice, val, ptot,stot, pro, lost,gtot;

        private void Sale_Load(object sender, EventArgs e)
        {

        }
        void Display()
        {
            csDBOperator obj = new csDBOperator();
            dataGridView1.DataSource = obj.mViewSALE(out x).DefaultView;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cal(); 
        }

        void cal()
        {
            current = Convert.ToInt16(label6.Text);
            purchaseprice = Convert.ToInt16(lblpst.Text);
            val = Convert.ToInt16(textBox1.Text);
            stot = val * current;
            ptot = val * purchaseprice;
            gtot = stot - ptot;
            if (gtot > 0)
            {
                pro = gtot;
                lost = 0;
            }
            else
            {
                lost = gtot;
                pro = 0;
            }
            MessageBox.Show("pro" + pro + "  lost"+lost+" ");
        }
        void SalesSet()
        {
            csDBOperator obj1 = new csDBOperator();
            string x= obj1.mdDataFEED3();
            MessageBox.Show(x);
        }

        void SetVal()
        {
            csDBOperator obj = new csDBOperator();
            obj.mgetSALE(out price,out stock,out name,out name2);
            lblsectorname.Text = name;
            lblstockname.Text = name2;
            lblpst.Text = price.ToString();
            lblst.Text = stock.ToString();
            label6.Text = csProperties.StockValu.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetVal();
        }
    }
}

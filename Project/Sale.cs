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
    public partial class Sale : Form
    {
        int price, stock;
        string name, name2;
        public Sale()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
